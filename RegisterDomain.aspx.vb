Imports System.IO
Imports System.Net
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Newtonsoft.Json.Linq
Imports Domain2021.Toastr
Imports System.Security.Cryptography
Imports Microsoft.Security.Application
Imports Newtonsoft.Json
Imports System.Threading

Public Class RegisterDomain
    Inherits System.Web.UI.Page
    Dim errorMessage As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("page") = "register"
        SetLanguage()
        If Page.IsPostBack = False Then
            Dim lang As New Languages(Session("lang"))
            Note.Text = lang.haveAccount
        End If

    End Sub

    Private Sub Disableall()
        CreateAccountbtn.Enabled = False
        AdminEmailTextBox.Enabled = False
        AdminMobileTextBox.Enabled = False
        AdminTextBox.Enabled = False
        ConfirmPassword.Enabled = False
        PasswordT.Enabled = False
    End Sub
    Private Sub Enableall()
        CreateAccountbtn.Enabled = True
        AdminEmailTextBox.Enabled = True
        AdminMobileTextBox.Enabled = True
        AdminTextBox.Enabled = True
        ConfirmPassword.Enabled = True
        PasswordT.Enabled = True
        Username.Enabled = True
    End Sub


    Public Function ValidateReCaptcha(ByRef errorMessage As String) As Boolean
        Dim lang As New Languages(Session("lang"))
        Dim gresponse = Request("g-recaptcha-response")

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
    Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        RegularExpressionValidator2.Text = lang.OnlyJordanian
        RegularExpressionValidator2.ForeColor = System.Drawing.Color.Red
        UsernameL.Text = lang.Username.Replace(":", "")
        PasswordL.Text = lang.PPassword.Replace(":", "")
        ConfirmPasswordL.Text = lang.reenterpass
        CreateAccountbtn.Style.Add("font-family", lang.fonta)
        CreateAccountbtn.Style.Add("font-weight", "bold")
        UsernameL.Style.Add("font-family", lang.fonta)
        PasswordL.Style.Add("font-family", lang.fonta)
        Div5.Style.Add("font-weight", "normal")
        Div6.Style.Add("font-weight", "normal")
        Div7.Style.Add("font-weight", "normal")
        AccountInfotab.InnerHtml = lang.creataccount
        Alert.Style.Add("font-family", lang.fonta)
        LinkButton1.Style.Add("font-family", lang.fonta)
        LinkButton1.Style.Add("font-weight", "bold")
        ConfirmPasswordL.Style.Add("font-family", lang.fonta)
        CompareValidator1.Text = lang.confirm
        CreateAccountbtn.Text = lang.creataccount
        UsernamerequiredValidator.ErrorMessage = lang.RequiredField2
        UsernamerequiredValidator.ForeColor = System.Drawing.Color.Red
        PassValidator.ErrorMessage = lang.RequiredField2
        Confirmpassvalidator.ErrorMessage = lang.RequiredField2
        AccountInfotab.Style.Add("font-family", lang.fonta)
        AccountInfo.Style.Add("font-weight", "normal")
        container.Style.Add("Direction", lang.dir)
        container.Style.Add("font-family", lang.fonta)
        nav.Style.Add("Direction", lang.dir)
        UserValidchar.ErrorMessage = lang.UserValidchar
        nav.Style.Add("font-family", lang.fonta)
        lbl_user_name_error.Style.Add("text-align", lang.right)
        AdminTextBoxValidator.Text = lang.RequiredField2
        AdminEmailTextBoxValidator.Text = lang.RequiredField2
        AdminEmailTextBoxValidator.ForeColor = System.Drawing.Color.Red
        AdminMobileTextBoxValidator.Text = lang.RequiredField2
        AdminMobileTextBoxValidator.ForeColor = System.Drawing.Color.Red
        UsernamerequiredValidator.Text = lang.RequiredField2
        Confirmpassvalidator.Text = lang.RequiredField2
        PassValidator.Text = lang.RequiredField2
        Confirmpassvalidator.ForeColor = System.Drawing.Color.Red
        PassValidator.ForeColor = System.Drawing.Color.Red
        RegularExpressionValidator1.Text = lang.PasswordStrenght
        AdminEmailExpressionValidator.ForeColor = System.Drawing.Color.Red
        RegularExpressionValidator1.ForeColor = System.Drawing.Color.Red
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.ForeColor = System.Drawing.Color.Red
        AdminDetailsLabel.Text = lang.Admin
        AdminMobileLabel.Text = lang.Mobile
        AdminEmailLabel.Text = lang.Email
        Note.Style.Add("font-family", lang.fonta)
    End Sub
    Protected Sub NextStep1_Click(sender As Object, e As EventArgs)
        Try


            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = ""
            Dim isValidCaptcha As Boolean = ValidateReCaptcha(errorMessage)
            If (isValidCaptcha = False) Then
                lbl_error.Visible = True
                lbl_error.Text = errorMessage
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "g-recaptcha", "loadGrecaptcha()", True)
                Toastr.ShowToast(Me, ToastType.Error, errorMessage, errorMessage, ToastPosition.TopCenter)
            ElseIf Regex.IsMatch(Username.Text, "^[ء-ي0-9\-]{1,63}$") = True Then
                Disableall()
                Toastr.ShowToast(Me, ToastType.Error, lang.invalidusername, lang.EError, ToastPosition.TopCenter)
            Else
                If Username.Text = "" Or PasswordT.Text = "" Then
                    Disableall()
                    Toastr.ShowToast(Me, ToastType.Error, lang.Errorlbl, lang.Errorlbl, ToastPosition.TopCenter)
                Else
                    Enableall()
                    Dim connectionstr As DAL = New DAL()
                    Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim comm As New SqlClient.SqlCommand

                    Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim comm2 As New SqlClient.SqlCommand

                    Try
                        conn.Open()
                        comm.Connection = conn
                        comm.CommandText = "admin_company_user_name"
                        comm.Parameters.AddWithValue("cu", Username.Text.Trim)
                        comm.CommandType = CommandType.StoredProcedure
                        If comm.ExecuteReader().HasRows = False Then
                            conn2.Open()
                            comm2.Connection = conn2
                            comm2.CommandText = "insert_adminFirstTime"
                            comm2.Parameters.AddWithValue("cu", Server.HtmlEncode(Username.Text))
                            comm2.Parameters.AddWithValue("up", ReusableCode.DES_ENC(Server.HtmlEncode(PasswordT.Text), Username.Text))
                            comm2.Parameters.AddWithValue("admin", Server.HtmlEncode(AdminTextBox.Text))
                            comm2.Parameters.AddWithValue("mob", Server.HtmlEncode(AdminMobileTextBox.Text))
                            comm2.Parameters.AddWithValue("email", Server.HtmlEncode(AdminEmailTextBox.Text))
                            comm2.Parameters.Add("message_ar", SqlDbType.NVarChar, 200)
                            comm2.Parameters("message_ar").Direction = ParameterDirection.Output
                            comm2.Parameters.Add("message_en", SqlDbType.NVarChar, 200)
                            comm2.Parameters("message_en").Direction = ParameterDirection.Output
                            comm2.Parameters.Add("bitvalue", SqlDbType.Bit)
                            comm2.Parameters("bitvalue").Direction = ParameterDirection.Output
                            comm2.CommandType = CommandType.StoredProcedure
                            comm2.ExecuteNonQuery()
                            conn2.Close()
                            Session("bitvalue") = Convert.ToString(comm2.Parameters("bitvalue").Value)
                            Session("Message_ar") = Convert.ToString(comm2.Parameters("message_ar").Value)
                            Session("Message_en") = Convert.ToString(comm2.Parameters("message_en").Value)
                            If Session("bitvalue") = True Then
                                Toastr.ShowToast(Me, ToastType.Success, lang.AdminAccount, lang.created, ToastPosition.TopCenter)
                                Session("value") = "registerD"
                                Response.Redirect("popup.aspx")
                            Else
                                If Session("lang") = "en" Then
                                    Toastr.ShowToast(Me, ToastType.Error, Session("Message_en"), Session("Message_en"), ToastPosition.TopCenter)
                                Else
                                    Toastr.ShowToast(Me, ToastType.Error, Session("Message_ar"), Session("Message_ar"), ToastPosition.TopCenter)

                                End If
                            End If


                        Else
                            conn.Close()
                            Toastr.ShowToast(Me, ToastType.Error, lang.invalidusername2, lang.EError, ToastPosition.TopCenter)
                            Disableall()
                        End If

                    Catch ex As Exception
                        If Not (TypeOf ex Is ThreadAbortException) Then
                            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\RegisterDomain:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                        End If
                        conn.Close()
                        conn2.Close()

                    End Try

                    conn2.Close()
                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\RegisterDomain:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        Response.Redirect("LoginUser.aspx")
    End Sub

    Protected Sub Username_TextChanged(sender As Object, e As EventArgs)
        Try


            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = ""

            If Regex.IsMatch(Username.Text, "^[ء-ي0-9\-]{1,63}$") = True Then
                Disableall()
                Toastr.ShowToast(Me, ToastType.Error, lang.invalidusername, lang.EError, ToastPosition.TopCenter)
            Else

                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm As New SqlClient.SqlCommand
                Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm2 As New SqlClient.SqlCommand

                Try
                        conn.Open()
                        comm.Connection = conn
                        comm.CommandText = "admin_company_user_name"
                        comm.Parameters.AddWithValue("cu", Username.Text.Trim)
                        comm.CommandType = CommandType.StoredProcedure
                    If comm.ExecuteReader().HasRows = True Then

                        Toastr.ShowToast(Me, ToastType.Error, lang.invalidusername2, lang.EError, ToastPosition.TopCenter)
                        Disableall()

                        conn.Close()

                    Else
                        Enableall()
                    End If

                    Catch ex As Exception
                        If Not (TypeOf ex Is ThreadAbortException) Then
                            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\RegisterDomain:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                        End If
                        conn.Close()
                        conn2.Close()

                    End Try

                    conn2.Close()
                End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\RegisterDomain:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class