Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports Newtonsoft.Json
Imports Microsoft.Security.Application
Imports System.Threading

Public Class ChangePassword
    Inherits System.Web.UI.Page
    Dim errorMessage As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Session("page") = "ChangePassword"
        fill_db(Session("User_ID"))
        SetLanguage()
    End Sub
    Private Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        head.InnerText = lang.changepass
        usernameL.Text = lang.Username
        Loctio.InnerText = lang.PPassword
        Label1.InnerText = lang.rePPassword
        login.Style.Add("Font-Family", lang.fonta)
        login.Style.Add("font-size", "Medium")
        login.Style.Add("Direction", lang.dir)
        login.Style.Add("text-align", lang.right)
        login.Style.Add("Font-weight", "bold")
        Me.Button1.Text = lang.changepass
        Button1.Style.Add("Font-weight", "bold")
        RequiredFieldValidator1.Style.Add("Font-Family", lang.fonta)
        RequiredFieldValidator1.Style.Add("Font-size", "12px")
        RequiredFieldValidator1.ErrorMessage = lang.RequiredField2
        RequiredFieldValidator2.Style.Add("Font-Family", lang.fonta)
        RequiredFieldValidator2.Style.Add("Font-size", "12px")
        RequiredFieldValidator2.ErrorMessage = lang.RequiredField2
        RegularExpressionValidator1.ErrorMessage = lang.PasswordStrenght
        RegularExpressionValidator1.Text = lang.PasswordStrenght
        RegularExpressionValidator1.Style.Add("Font-Family", lang.fonta)
        RegularExpressionValidator1.Style.Add("Font-size", "12px")
        CompareValidator1.ErrorMessage = lang.confirm
        CompareValidator1.Text = lang.confirm
        CompareValidator1.Style.Add("Font-Family", lang.fonta)
        CompareValidator1.Style.Add("Font-size", "12px")
        OldPasswordlbl.Text = lang.oldpassword
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.master"
        Else
            Me.MasterPageFile = "MasterPageEnn.master"
        End If
    End Sub
    Private Sub fill_db(ByVal admin_id As Integer)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd2 As New SqlClient.SqlCommand("select_AdminData", ocon2)
            Dim odr As SqlDataReader
            ocon2.Open()
            ocmd2.CommandType = CommandType.StoredProcedure
            ocmd2.Parameters.AddWithValue("DomainId", admin_id)
            odr = ocmd2.ExecuteReader()
            While odr.Read
                If Not odr("company_user_name") Is DBNull.Value Then
                    InputUsernameL.Text = odr("company_user_name")
                End If
            End While
            odr.Close()
            ocon2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\changePassword:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Public Function ValidateReCaptcha(ByRef errorMessage As String) As Boolean
        Dim gresponse = Request("g-recaptcha-response")
        Dim lang As Languages = New Languages("en")
        Dim secret As String = lang.PublicSecret
        Dim ipAddress As String = ReusableCode.GetIPAddress()
        Dim client = New WebClient()
        Dim url As String = String.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}&remoteip={2}", secret, gresponse, ipAddress)
        Dim response = client.DownloadString(url)
        Dim captchaResponse = JsonConvert.DeserializeObject(Of ReCaptchaResponse)(response)

        If captchaResponse.Success Then
            Return True
        Else
            Dim [error] = captchaResponse.ErrorCodes(0).ToLower()

            Select Case [error]
                Case ("missing-input-secret")
                    errorMessage = "The secret key parameter is missing."
                Case ("invalid-input-secret")
                    errorMessage = "The given secret key parameter is invalid."
                Case ("missing-input-response")
                    errorMessage = "The g-recaptcha-response parameter is missing."
                Case ("invalid-input-response")
                    errorMessage = "The given g-recaptcha-response parameter is invalid."
                Case Else
                    errorMessage = "reCAPTCHA Error. Please try again!"
            End Select

            Return False
        End If
    End Function
    Public Class ReCaptchaResponse
        <JsonProperty("success")>
        Public Property Success As Boolean
        <JsonProperty("error-codes")>
        Public Property ErrorCodes As List(Of String)
    End Class


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            lbl_error.Text = ""
            Dim lang As New Languages(Session("lang"))
            Dim isValidCaptcha As Boolean = ValidateReCaptcha(errorMessage)
            If (isValidCaptcha = False) Then
                lbl_error.Visible = True
                lbl_error.Text = errorMessage
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "g-recaptcha", "loadGrecaptcha()", True)
            Else
                Dim ocmd As New Data.SqlClient.SqlCommand
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                ocmd.Connection = ocon
                ocmd.CommandText = "update_password"
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocon.Open()
                ocmd.Parameters.AddWithValue("admin", Session("User_ID"))
                ocmd.Parameters.AddWithValue("oldpassword", ReusableCode.DES_ENC(OldPassword.Text, Session("User_ID")))
                ocmd.Parameters.AddWithValue("pass", ReusableCode.DES_ENC(Server.HtmlEncode(password.Text), Session("User_ID")))
                ocmd.Parameters.Add("message", SqlDbType.Bit, 200)
                ocmd.Parameters("message").Direction = ParameterDirection.Output
                Session("Message") = Convert.ToBoolean(ocmd.Parameters("message").Value)
                ocmd.ExecuteNonQuery()
                ocon.Close()
                If Session("Message") = True Then
                    lbl_error.Text = lang.Updated
                Else
                    lbl_error.Text = lang.updatefailed
                End If

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\changePassword:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class