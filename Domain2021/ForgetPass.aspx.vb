Imports System.Net
Imports Domain2021.Toastr
Imports Newtonsoft.Json
Imports Microsoft.Security.Application
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net.Mail
Imports System.Threading

Public Class ForgetPass
    Inherits System.Web.UI.Page
    Dim errorMessage As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("page") = "forget"
        Dim lang As New Languages(Session("lang"))
        RequiredFieldValidator2.ErrorMessage = lang.RequiredField2
        RequiredFieldValidator3.ErrorMessage = lang.RequiredField2
        regexEmailValid.ErrorMessage = lang.MailVal
        regexpReuesterName.ErrorMessage = lang.InvalidRequester
        EmailLabelL.Text = lang.Email
        RequesterL.Text = lang.Username
        head.InnerText = lang.Forget
        EmailLabelL.Font.Name = lang.fonta
        RequesterL.Font.Name = lang.fonta
        loginbutton.Text = lang.orderPass
        loginbutton.Font.Name = lang.fonta
        login.Style.Add("font-family", lang.fonta)
        login.Style.Add("Direction", lang.dir)
        login.Style.Add("align", lang.right)
        login.Style.Add("text-align", lang.right)

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
    Protected Sub loginbutton_Click(sender As Object, e As EventArgs)
        Dim lang As New Languages(Session("lang"))
        lbl_error.Text = ""
        Dim isValidCaptcha As Boolean = ValidateReCaptcha(errorMessage)
        If (isValidCaptcha = False) Then
            lbl_error.Visible = True
            lbl_error.Text = errorMessage
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "g-recaptcha", "loadGrecaptcha()", True)
            Toastr.ShowToast(Me, ToastType.Error, errorMessage, errorMessage, ToastPosition.TopCenter)
        ElseIf Validation.validate_experssion(Server.HtmlEncode(txt_email_id.Text)) = True Then
            Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.ErrorlblEmail, ToastPosition.TopCenter)
        Else
            send_Validation_code()
        End If

    End Sub
    Sub send_Validation_code()
        Dim lang As New Languages(Session("lang"))
        Try
            Dim dateoftoday As DateTime = DateTime.Now
            Dim DisplayDate As String = dateoftoday.ToString("dd/MM/yyyy hh:mm tt")
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New SqlClient.SqlCommand
            Dim dr As SqlClient.SqlDataReader
            Try

                conn.Open()
                comm.Connection = conn
                comm.CommandText = "forgetPassword2"
                comm.Parameters.AddWithValue("email", txt_email_id.Text)
                comm.Parameters.AddWithValue("username", txt_requester_Name.Text)
                comm.CommandType = CommandType.StoredProcedure
                dr = comm.ExecuteReader()
                If dr.HasRows = True Then
                    dr.Read()
                    Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmd As New Data.SqlClient.SqlCommand
                    ocmd.Connection = ocon
                    ocmd.CommandText = "insertreset"
                    ocmd.CommandType = Data.CommandType.StoredProcedure
                    ocon.Open()
                    ocmd.Parameters.AddWithValue("admin_id", dr("Admin_id"))
                    ocmd.Parameters.AddWithValue("URl", "https://dns.jo/reset_pwd.aspx?email=" + ReusableCode.DES_ENC(txt_email_id.Text) + "&Admin_id=" + ReusableCode.DES_ENC(dr("Admin_id").ToString()))
                    ocmd.ExecuteNonQuery()
                    ocon.Close()

                    If Session("lang") = "ar" Then
                        'forgetPass
                        Dim subject As String = "نسيت كلمة العبور"
                        Dim message_body3 As String = "<p dir='rtl'>" + "عميلنا العزيز ،بالإمكان تغيير كلمة العبور من الرابط أسفل:"
                        message_body3 += "<p dir='rtl'>"
                        message_body3 += "عنوان البريد الإلكتروني: " & txt_email_id.Text & "<br>"
                        message_body3 += "اسم مقدم الطلب : " & txt_requester_Name.Text & "<br>"
                        message_body3 += "</p>"
                        message_body3 += "<br>" + "<p dir='rtl'>" + "<a href=https://dns.jo/reset_pwd.aspx?email=" + ReusableCode.DES_ENC(txt_email_id.Text) + "&Admin_id=" + ReusableCode.DES_ENC(dr("Admin_id").ToString()) + ">اضغط هنا لتغيير كلمة السرّ</a>"
                        ReusableCode.sndMail(txt_email_id.Text, "dns@modee.gov.jo", subject, message_body3)
                        lbl_error.Visible = True
                        lbl_error.Text = "تم ارسال الطلب بنجاح..."
                        Toastr.ShowToast(Me, ToastType.Info, "تم ارسال الطلب بنجاح...", "تم ارسال الطلب بنجاح...", ToastPosition.TopCenter)

                    Else
                        Dim subject As String = "Forgot my Password"
                        Dim message_body3 As String = "Dear Valued Client, Here is a link to reset your password:"
                        message_body3 += "<br>Email ID: " & Server.HtmlEncode(txt_email_id.Text) & "<br>"
                        message_body3 += "User Name : " & Server.HtmlEncode(txt_requester_Name.Text) & "<br>"
                        message_body3 += "<br>" + "<a href=https://dns.jo/reset_pwd.aspx?email=" + ReusableCode.DES_ENC(txt_email_id.Text) + "&Admin_id=" + ReusableCode.DES_ENC(dr("Admin_id").ToString()) + ">Press here to reset password</a>"
                        ReusableCode.sndMail(txt_email_id.Text, "dns@modee.gov.jo", subject, message_body3)
                        lbl_error.Visible = True
                        lbl_error.Text = "Email Sent to you"
                        Toastr.ShowToast(Me, ToastType.Info, "Email Sent to you", "Email Sent to you", ToastPosition.TopCenter)

                    End If


                Else
                    conn.Close()
                    lbl_error.Visible = True
                    lbl_error.Text = lang.AdminError
                    Toastr.ShowToast(Me, ToastType.Error, lang.AdminError, lang.EError, ToastPosition.TopCenter)
                End If
                conn.Close()

            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\forgetpass:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                conn.Close()
            End Try


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\forgetpass:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            lbl_error.Visible = False
            lbl_error.Text = ""
        End Try
    End Sub


End Class