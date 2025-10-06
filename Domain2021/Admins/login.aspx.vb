Imports System.Net
Imports Newtonsoft.Json
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports RestSharp
Imports Newtonsoft.Json.Linq
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports ASPSnippets
Imports ASPSnippets.Captcha
Imports System.Drawing
Imports System.Threading

Public Class login
    Inherits System.Web.UI.Page
    Dim User_Role, Admin_User_ID, User_Type, Users_ID, USER_Mobile, USER_Email As String
    Dim arraysession As New ArrayList
    Dim errorMessage As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub




    Shared Function validate_experssion(ByVal value As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "[\']|[\;]|[\/*|\|]|[\*/|=]|[\+]|(--)|(___)|(%)|(%%)")
    End Function
    Public Function getallemails(ByVal txtusername As String, ByVal txtpassword As String, ByVal domain As String) As String
        Try

            Dim client = New RestClient("https://10.0.216.29/Ldap_API/Contract/EmailAddress")
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("x-api-key", lang.apikey)
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

            Dim body = "{
                        " & vbLf & "  ""username"": """ + txtusername + """,
                        " & vbLf & "  ""password"": """ + txtpassword + """,
                        " & vbLf & "  ""domain"": """ + domain + """
                        " & vbLf & "}"
            request.AddParameter("application/json", body, ParameterType.RequestBody)
            System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(senderX, certificate, chain, sslPolicyErrors) True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
            Dim response As IRestResponse = client.Execute(request)
            Dim jsonarr As JArray = JArray.Parse(response.Content)
            For arrcount = 0 To jsonarr.Count - 1

                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("login_admin", conn)
                Dim red1 As SqlClient.SqlDataReader
                ocmd.CommandType = CommandType.StoredProcedure
                conn.Open()
                ocmd.Parameters.AddWithValue("User_Email", jsonarr(arrcount).ToString())
                red1 = ocmd.ExecuteReader()
                If red1.HasRows = True Then
                    While red1.Read

                        Select Case Trim(red1.Item("USER_Role"))
                            Case 2
                                If Not red1.Item(1) Is DBNull.Value Then
                                    Admin_User_ID = Trim(red1.Item(1))
                                End If
                                If Not red1.Item(0) Is DBNull.Value Then
                                    Users_ID = Trim(red1.Item(0))
                                End If
                                If Not red1.Item(2) Is DBNull.Value Then
                                    USER_Email = Trim(red1.Item(2))
                                End If
                                If Not red1.Item(4) Is DBNull.Value Then
                                    User_Role = Trim(red1.Item(4))
                                End If

                                User_Type = "ACCOUNT"

                                Session("USER_Mobile") = USER_Mobile
                                USER_Email = jsonarr(arrcount).ToString()
                            Case 3
                                If Not red1.Item(1) Is DBNull.Value Then
                                    Admin_User_ID = Trim(red1.Item(1))
                                End If
                                If Not red1.Item(2) Is DBNull.Value Then
                                    USER_Email = Trim(red1.Item(2))
                                End If
                                If Not red1.Item(0) Is DBNull.Value Then
                                    Users_ID = Trim(red1.Item(0))
                                End If
                                If Not red1.Item(4) Is DBNull.Value Then
                                    User_Role = Trim(red1.Item(4))
                                End If

                                User_Type = "DNS"
                            Case 1
                                If Not red1.Item(1) Is DBNull.Value Then
                                    Admin_User_ID = Trim(red1.Item(1))
                                End If
                                If Not red1.Item(2) Is DBNull.Value Then
                                    USER_Email = Trim(red1.Item(2))
                                End If
                                If Not red1.Item(0) Is DBNull.Value Then
                                    Users_ID = Trim(red1.Item(0))
                                End If
                                If Not red1.Item(4) Is DBNull.Value Then
                                    User_Role = Trim(red1.Item(4))
                                End If
                                If Not Trim(red1.Item(6)) Is DBNull.Value Then
                                    USER_Mobile = Trim(red1.Item(6))
                                End If
                                User_Type = "ViewOnly"
                        End Select

                        arraysession.Add(Admin_User_ID)
                        arraysession.Add(Users_ID)
                        arraysession.Add(User_Role)
                        arraysession.Add(User_Type)
                        arraysession.Add(USER_Email)

                        Session("arraySession") = arraysession
                        Session("username") = username.Text
                        Session("USER_Email") = USER_Email
                    End While
                    Return Session("USER_Email")
                    Exit For
                    conn.Close()
                Else

                End If
            Next
            Return Session("USER_Email")

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "admins\login:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function
    Dim lang As New Languages("en")
    Private Sub login_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try


            captcha1.ValidateCaptcha(txtCaptcha.Text.Trim())
            If captcha1.UserValidated = False Then
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "InValid Capcha"
            ElseIf userpassword.Text = "" Or username.Text = "" Then
                lblMessage.Text = ""
                Result.InnerText = "Enter user name and password"
            ElseIf validate_experssion(username.Text) = True Or validate_experssion(userpassword.Text) = True Then
                lblMessage.Text = ""
                Result.InnerText = "Enter a valid experssion"
            Else
                lblMessage.Text = ""
                Dim client = New RestClient("https://10.0.216.29/Ldap_API/Contract/isAuthunticated")
                client.Timeout = -1
                Dim request = New RestRequest(Method.POST)
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(senderX, certificate, chain, sslPolicyErrors) True
                request.AddHeader("x-api-key", lang.apikey)
                request.AddHeader("Content-Type", "application/json")
                Dim body = "{
                            " & vbLf & "  ""username"": """ & Server.HtmlEncode(username.Text) & """,
                            " & vbLf & "  ""password"":""" & Server.HtmlEncode(userpassword.Text) & """,
                            " & vbLf & "  ""domain"": ""moictgov""
                            " & vbLf & "}"
                request.AddParameter("application/json", body, ParameterType.RequestBody)
                Dim response As IRestResponse = client.Execute(request)

                If response.Content <> Nothing Then

                    If response.Content <> "" And response.Content = "true" Then
                        Try
                            If getallemails(Server.HtmlEncode(username.Text), Server.HtmlEncode(userpassword.Text), "moictgov") <> Nothing Then
                                divOTP.Visible = True
                                divLogin.Visible = False
                                Session("OTP") = ReusableCode.GenerateRandomNo()
                                ReusableCode.sndMail(Session("USER_Email").ToString, "dns@modee.gov.jo", "Enter OTP Code sent To your Email address", "Enter OTP Code sent To your Email address" + ":" + Session("OTP").ToString())
                                divOTP.Visible = True

                            Else
                                Result.Visible = True
                                ShowToastr(Me.Page, "You are Not authorized to enter this page", "Error!", "error")
                                username.Text = ""
                                userpassword.Text = ""
                                Result.InnerText = "You are Not authorized to enter this page"

                            End If


                        Catch ex As Exception

                        End Try
                    Else
                        Result.Visible = True
                        ShowToastr(Me.Page, "You are Not authorized to enter this page", "Error!", "error")
                        username.Text = ""
                        userpassword.Text = ""
                        Result.InnerText = "You are Not authorized to enter this page"
                    End If

                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "admins\login:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Dim OtpCount As Integer = 0
    Protected Sub LinkButton1_Click1(sender As Object, e As EventArgs)
        Try


            If Session("OTP") Is Nothing Then
            Else
                If OtpCount >= 4 Then
                    Response.Redirect("logout.aspx")
                Else

                    If OTPCode.Text = Session("OTP") Then
                        Dim arraysession As New ArrayList
                        arraysession = Session("arraySession")
                        Select Case Trim(arraysession(2))
                            Case 2

                                Session("entered") = "1"
                                Session("Admin_User_ID") = arraysession(0)
                                Session("Users_ID") = arraysession(1)
                                Session("USER_Role") = arraysession(2)
                                Session("USER_TYPE") = arraysession(3)


                                Dim _browserInfo As String = Request.Browser.Browser & Request.Browser.Version & Request.UserAgent & "~" & Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                                Dim _sessionValue As String = Convert.ToString(Session("User_ID")) & "^" & DateTime.Now.Ticks & "^" & _browserInfo & "^" & Convert.ToString(System.Guid.NewGuid())
                                Dim _encodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(_sessionValue)
                                Dim _encryptedString As String = System.Convert.ToBase64String(_encodeAsBytes)
                                Session("encryptedSession") = _encryptedString
                                Response.Redirect("account/EfawatercomReport.aspx")
                            Case 3
                                Session("entered") = "1"
                                Session("Admin_User_ID") = arraysession(0)
                                Session("Users_ID") = arraysession(1)
                                Session("USER_Role") = arraysession(2)
                                Session("USER_TYPE") = arraysession(3)


                                Dim _browserInfo As String = Request.Browser.Browser & Request.Browser.Version & Request.UserAgent & "~" & Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                                Dim _sessionValue As String = Convert.ToString(Session("User_ID")) & "^" & DateTime.Now.Ticks & "^" & _browserInfo & "^" & Convert.ToString(System.Guid.NewGuid())
                                Dim _encodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(_sessionValue)
                                Dim _encryptedString As String = System.Convert.ToBase64String(_encodeAsBytes)
                                Session("encryptedSession") = _encryptedString
                                Response.Redirect("DNS/ActivateThis.aspx")
                            Case 1
                                Session("entered") = "1"
                                Session("Admin_User_ID") = arraysession(0)
                                Session("Users_ID") = arraysession(1)
                                Session("USER_Role") = arraysession(2)
                                Session("USER_TYPE") = arraysession(3)


                                Dim _browserInfo As String = Request.Browser.Browser & Request.Browser.Version & Request.UserAgent & "~" & Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                                Dim _sessionValue As String = Convert.ToString(Session("User_ID")) & "^" & DateTime.Now.Ticks & "^" & _browserInfo & "^" & Convert.ToString(System.Guid.NewGuid())
                                Dim _encodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(_sessionValue)
                                Dim _encryptedString As String = System.Convert.ToBase64String(_encodeAsBytes)
                                Session("encryptedSession") = _encryptedString
                                Response.Redirect("ViewOnly/ActivateThisV.aspx")

                        End Select
                    Else
                        If OtpCount >= 4 Then
                            Response.Redirect("logout.aspx")
                        End If
                        OtpCount = OtpCount + 1
                        ShowToastr(Me.Page, "You are Not authorized to enter this page", "Error!", "error")
                        Label1.Visible = True
                        Label1.InnerText = "Wrong OTP"

                    End If
                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "admins\login:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub


End Class
