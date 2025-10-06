Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports Newtonsoft.Json
Imports System.Net
Imports Domain2021.Toastr
Imports System.Net.Mail
Imports Microsoft.Security.Application
Imports System.Threading

Public Class LoginUser
    Inherits System.Web.UI.Page
    Dim errorMessage As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim lang As New Languages(Session("lang"))
        Session("page") = "login"
        lbl_error.Visible = True
        login.Visible = True
        Div1.Visible = False
        usernameL.Text = lang.Username
        Password.Text = lang.PPassword
        Password.Style.Add("font-family", lang.fonta)
        usernameL.Style.Add("font-family", lang.fonta)
        login.Style.Add("direction", lang.dir)
        login.Style.Add("align", lang.right)
        usernameL.Style.Add("align", lang.right)
        Div1.Style.Add("direction", lang.dir)
        Div1.Style.Add("align", lang.right)
        Div1.Style.Add("font-family", lang.fonta)
        fg.Style.Add("direction", lang.dir)
        fg.Style.Add("align", lang.right)
        fg1.Style.Add("direction", lang.dir)
        fg1.Style.Add("align", lang.right)
        Inputfor.Style.Add("float", lang.right)
        Loctio.Style.Add("float", lang.right)
        fg1.Style.Add("direction", lang.dir)
        fg1.Style.Add("align", lang.right)
        loginbutton.Text = lang.Login
        ForgetLinkButton.Text = lang.Forget + " " + "<i class='fa fa-question-circle-o'></i>"
        ForgetLinkButton.Style.Add("float", lang.right)
        ForgetLinkButton.Style.Add("font-family", lang.fonta)
        MobileLabel.Font.Bold = False
        MobileLabel.Style.Add("font-family", lang.fonta)
        MobileLabel.Style.Add("align", lang.right)
        OTPLabel.Text = lang.endswith
        OTPLabel.Font.Bold = False
        OTPLabel.Style.Add("font-family", lang.fonta)
        OTPLabel.Style.Add("align", lang.right)
        MobileLabel.Text = lang.MobileNotCorrect
        Label1.Attributes.Add("align", lang.right)
        Button1.Text = lang.Sendit
        head.Style.Add("direction", lang.dir)
        head.InnerText = lang.LoginArea
        Label1.InnerText = lang.OTP2
        head.Style.Add("font-family", lang.fonta)
        loginbutton.Style.Add("font-family", lang.fonta)
        RequiredFieldValidator1.ErrorMessage = lang.RequiredField2
        RequiredFieldValidator2.ErrorMessage = lang.RequiredField2
        RequiredFieldValidator3.ErrorMessage = lang.RequiredField2
        OTPCodeLB.Text = lang.OTP
        OTPCodeLB.Font.Bold = False
        OTPCodeLB.Style.Add("font-family", lang.fonta)
        OTPCodeLB.Style.Add("align", lang.right)
        Label1.Attributes.Add("align", lang.right)
        Div3.Style.Add("direction", lang.dir)
        Div3.Style.Add("text-align", lang.right)
        Div3.Style.Add("text-align", lang.right)
        If Page.IsPostBack = False Then
            Session("entered") = "0"
            Session("wrong") = 0
        End If

    End Sub
    Dim a() = {"$", "%", "@", "*", "&", "^", "#", "/", "\", "|", "?"}



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
    Protected Sub loginbutton_Click(sender As Object, e As EventArgs) Handles loginbutton.Click
        Try


            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = ""
            Dim enc_password As String = ReusableCode.DES_ENC(InputPassword.Text, InputUsername.Text)
            Dim isValidCaptcha As Boolean = ValidateReCaptcha(errorMessage)
            If (isValidCaptcha = False) Then
                lbl_error.Visible = True
                lbl_error.Text = errorMessage
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "g-recaptcha", "loadGrecaptcha()", True)
                Toastr.ShowToast(Me, ToastType.Error, errorMessage, errorMessage, ToastPosition.TopCenter)
            Else
                If InputPassword.Text = "" Or InputUsername.Text = "" Then
                    lbl_error.Text = ""
                    lbl_error.Text = lang.enterlogin
                Else
                    If Page.IsValid = True Then
                        Dim em As String = ""
                        '------------------------------------------------------
                        Dim message_body As String = ""
                        Dim connectionstr As DAL = New DAL()
                        Dim connemailText As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmdemailText As New Data.SqlClient.SqlCommand
                        Dim reader As SqlClient.SqlDataReader
                        connemailText.Open()
                        ocmdemailText.Connection = connemailText
                        ocmdemailText.CommandText = "SelectEmailTextID"
                        If Session("lang") = "en" Then
                            ocmdemailText.Parameters.AddWithValue("id", 16)
                        Else
                            ocmdemailText.Parameters.AddWithValue("id", 17)
                        End If

                        ocmdemailText.CommandType = CommandType.StoredProcedure
                        reader = ocmdemailText.ExecuteReader()
                        While reader.Read
                            message_body = reader.Item("part1") & " " & InputUsername.Text & " " & reader.Item("part2") & reader.Item("footer")
                        End While
                        reader.Close()
                        connemailText.Close()
                        Dim Subject As String = lang.blockedSub + "(" + InputUsername.Text + ")"
                        Dim AdminEmailconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim AdminEmail As New Data.SqlClient.SqlCommand("select_admin_email", AdminEmailconn)
                        AdminEmailconn.Open()
                        AdminEmail.CommandType = Data.CommandType.StoredProcedure
                        AdminEmail.Parameters.AddWithValue("uname", InputUsername.Text)
                        AdminEmail.Parameters.Add("Message", SqlDbType.VarChar, 200)
                        AdminEmail.Parameters.Add("MessageEn", SqlDbType.VarChar, 200)
                        AdminEmail.Parameters("Message").Direction = ParameterDirection.Output
                        AdminEmail.Parameters("MessageEn").Direction = ParameterDirection.Output
                        em = AdminEmail.ExecuteScalar()
                        AdminEmailconn.CreateCommand()
                        If Not em = "" Then
                            lbl_error.Visible = True
                            If (Session("lang") = "ar") Then
                                lbl_error.Text = Convert.ToString(AdminEmail.Parameters("Message").Value)
                            Else
                                lbl_error.Text = Convert.ToString(AdminEmail.Parameters("MessageEn").Value)
                            End If
                            AdminEmailconn.Close()

                            Toastr.ShowToast(Me, ToastType.Error, lang.blockedSub, lang.blockedSub, ToastPosition.TopCenter)

                            ReusableCode.sndMail(em, "dns@modee.gov.jo", Subject, message_body)
                            ReusableCode.sndMail("dns@modee.gov.jo", "dns@modee.gov.jo", Subject, message_body)

                        Else

                            If (lbl_error.Text = "") Then
                                Dim Loginconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                                Dim Loginocmd As New Data.SqlClient.SqlCommand("login_user", Loginconn)

                                Dim parm(33) As Object
                                Dim reader1 As SqlDataReader


                                Dim dd As DateTime = Now
                                Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

                                Try
                                    Loginconn.Open()
                                    Loginocmd.Parameters.AddWithValue("COMPANY_USER_NAME", Server.HtmlEncode(InputUsername.Text))
                                    Loginocmd.Parameters.AddWithValue("USER_PASSWORD", enc_password)
                                    Loginocmd.CommandType = Data.CommandType.StoredProcedure
                                    reader1 = Loginocmd.ExecuteReader()


                                    If reader1.HasRows Then
                                        reader1.Read()
                                        login.Visible = False
                                        Div1.Visible = True
                                        Session("Mobile") = reader1("Mobile")
                                        Session("Email") = reader1("Email")
                                        OTPLabel.Text += "X X X X X X X X X" + Session("Mobile").ToString.Substring(9, 3)
                                        OTPLabel.Text += lang.endswith2
                                        OTPLabel.Text += "  :  " + Session("Email").ToString.Substring(0, 4) + "X X X X X"
                                        Session("User_ID") = reader1("ADMIN_ID")
                                        head.InnerText = lang.OTP
                                        Session("OTP") = ReusableCode.GenerateRandomNo()
                                        ReusableCode.sndMail(reader1("Email").ToString, "dns@modee.gov.jo", lang.OTP, lang.OTP + ":" + Session("OTP").ToString())
                                        Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & Session("OTP") & "&mobile_number=" & reader1("Mobile").ToString.Trim().Replace("+", "").Replace(" ", "") & "&from=" & "domain.jo" & "&tag=" & 1 & "&Charset=" & "UTF-8" & "&unicode=" & 1
                                        ReusableCode.VisitURL(Url1)

                                        ReusableCode.sndMail(reader1("Email").ToString, "dns@modee.gov.jo", lang.OTP, lang.OTP + ":" + Session("OTP"))

                                        reader.Close()
                                    Else

                                        ' ----------------------------------------
                                        Dim blockconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                                        Dim blockcomm As New Data.SqlClient.SqlCommand("update_block", blockconn)
                                        blockconn.Open()
                                        blockcomm.CommandType = Data.CommandType.StoredProcedure
                                        blockcomm.Parameters.AddWithValue("uname", Me.InputUsername.Text)
                                        blockcomm.ExecuteNonQuery()
                                        blockconn.Close()
                                        '------------------------------------------------------
                                        lbl_error.Visible = True
                                        lbl_error.Text = lang.failedLogin + "<br>"
                                        Toastr.ShowToast(Me, ToastType.Error, lang.failedLogin, lang.failedLogin, ToastPosition.TopCenter)

                                        InputUsername.Text = ""
                                        InputPassword.Text = ""



                                    End If


                                    reader1.Close()
                                Catch ex As Exception
                                    Loginconn.Close()
                                End Try
                                Loginconn.Close()

                            Else
                                Toastr.ShowToast(Me, ToastType.Error, lang.loginerror, lang.loginerror, ToastPosition.TopCenter)
                                lbl_error.Text = lang.loginerror
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\loginuser:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try


            If Session("OTP") Is Nothing Then
                Response.Redirect("LoginUser.aspx")
            Else
                If OTPTextBox.Text = Session("OTP") Then
                    Session("entered") = "1"
                    Response.Redirect("Users/mydomains.aspx")
                Else
                    Dim lang As New Languages(Session("lang"))
                    errorOtp.Text = lang.notmatched
                    errorOtp.Font.Bold = True
                    Session("entered") = "0"
                    Session("wrong") = Session("wrong") + 1
                    If Session("wrong") >= 4 Then
                        Response.Redirect("/Users/Logout.aspx")
                    End If
                    Div1.Visible = True
                    login.Visible = False

                    Toastr.ShowToast(Me, ToastType.Error, lang.notmatched, lang.notmatched, ToastPosition.TopCenter)
                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\loginuser:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub ForgetLinkButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("ForgetPass.aspx")
    End Sub
End Class