Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Threading
Imports Newtonsoft.Json

Public Class reset_pwd
    Inherits System.Web.UI.Page
    Dim errorMessage As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try



            Dim lang As New Languages(Session("lang"))
            fill_email()
            head.InnerText = lang.changepass
            usernameL.Text = lang.Email + ":" + " "
            Loctio.InnerText = lang.PPassword
            Label1.InnerText = lang.rePPassword
            Button1.Text = lang.reset
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
            If Not Request.QueryString("email") Is Nothing And Not Request.QueryString("admin_id") Is Nothing Then
                Dim ocon As New Data.SqlClient.SqlConnection
                Dim ocmd As New Data.SqlClient.SqlCommand
                Dim dr As SqlDataReader
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                ocmd.Connection = conn
                ocmd.CommandText = "select_reset"
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocon.Open()
                ocmd.Parameters.AddWithValue("adminid", Convert.ToInt32(ReusableCode.Decrypt(HttpUtility.UrlDecode(Request.QueryString("admin_id")))))
                dr = ocmd.ExecuteReader()
                If dr.HasRows = True Then
                    While dr.Read
                        If Not dr("creationtime") Is DBNull.Value Then
                            Dim T2 As DateTime = dr("creationtime").ToString()
                            If DateDiff(DateInterval.Minute, T2, Now) >= 15 Then
                                Response.Redirect("Users/Logout.aspx")

                            End If
                        End If


                    End While
                    dr.Close()
                    ocon.Close()
                Else
                    Response.Redirect("Users/Logout.aspx")
                End If

            Else
                Response.Redirect("Users/Logout.aspx")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\reset_pwd:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") Is Nothing Then
            Session("lang") = "ar"
        End If
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "~/MasterPageAr.master"
        Else
            Me.MasterPageFile = "~/MasterPage_En.master"
        End If
    End Sub
    Private Sub fill_email()
        If Request.QueryString("email") Is Nothing Or Request.QueryString("admin_id") Is Nothing Then
            Response.Redirect("Users/Logout.aspx")
        Else
            EmailL.Text = ReusableCode.Decrypt(Request.QueryString("email"))

        End If

    End Sub

    Public Function ValidateReCaptcha(ByRef errorMessage As String) As Boolean
        Dim gresponse = Request("g-recaptcha-response")
        Dim lang As New Languages("en")
        
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



    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)


        Try


            lbl_error.Text = ""
            Dim lang As New Languages(Session("lang"))
            Dim isValidCaptcha As Boolean = ValidateReCaptcha(errorMessage)
            If (isValidCaptcha = False) Then
                lbl_error.Visible = True
                lbl_error.Text = errorMessage
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "g-recaptcha", "loadGrecaptcha()", True)
            Else
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand
                ocmd.Connection = ocon
                ocmd.CommandText = "UPDATE_PASSWORD2"
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocon.Open()
                ocmd.Parameters.AddWithValue("admin", ReusableCode.Decrypt(Request.QueryString("Admin_id")))
                ocmd.Parameters.AddWithValue("pass", ReusableCode.DES_ENC(password.Text, ReusableCode.Decrypt(System.Uri.UnescapeDataString(Request.QueryString("admin_id")))))
                ocmd.ExecuteNonQuery()
                ocon.Close()
                Session("value") = "reset"
                Response.Redirect("popup.aspx")

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\reset_pwd:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class