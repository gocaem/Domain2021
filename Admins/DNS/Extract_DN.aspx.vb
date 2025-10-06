Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Threading
Imports Microsoft.Security.Application
Public Class Extract_DN
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        fill_datalist()
    End Sub
    Sub fill_datalist()
        Try


            If Not Trim((CStr(txt_domain_name.Text).ToLower).Replace(" ", "")) = "" Then
                Dim ocmd As New Data.SqlClient.SqlCommand
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim odr As Data.SqlClient.SqlDataReader
                ocmd.CommandText = "search_tosend"
                ocmd.Parameters.AddWithValue("domain_name", Server.HtmlEncode(txt_domain_name.Text))
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.Connection = ocon
                ocon.Open()
                odr = ocmd.ExecuteReader
                If odr.HasRows = False Then
                    Me.DataGrid1.DataSource = odr
                    Me.DataGrid1.DataBind()
                    d2.Visible = False
                    ShowToastr(Page, "There is no record", "not available", "info")
                Else
                    Me.DataGrid1.DataSource = odr
                    Me.DataGrid1.DataBind()
                    d2.Visible = True
                End If
                odr.Close()
                ocon.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try


            If txt_email.Text = "" Then
                lbl_error.Text = "You have to enter E-Mail"
            Else
                lbl_Result.Text = ""
                lbl_error.Text = ""
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm As New Data.SqlClient.SqlCommand
                Dim New_admin_id As Integer
                Dim gridrow As DataGridItem
                Dim cchek As Boolean
                Dim dd As DateTime = Now
                Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
                For Each gridrow In DataGrid1.Items
                    cchek = CType(gridrow.Cells(5).FindControl("CheckBox1"), CheckBox).Checked
                    If cchek Then
                        Try
                            If check_Many_Domains(gridrow.Cells(6).Text) Then

                                If New_admin(New_admin_id, gridrow.Cells(2).Text, get_old_nameserver(gridrow.Cells(6).Text), gridrow.Cells(0).Text) Then
                                    If send_forgot_EMail(New_admin_id) Then
                                        lbl_Result.Text = "Send Ok ..."
                                        SAVE_LOG(gridrow.Cells(0).Text)
                                    Else
                                        ShowToastr(Page, "error", "error.1", "error")
                                    End If

                                Else
                                    ShowToastr(Page, "Update Admin Error.1", "error.1", "error")
                                End If
                            Else
                                If update_admin(gridrow.Cells(6).Text, gridrow.Cells(2).Text) Then
                                    If send_forgot_EMail(gridrow.Cells(6).Text) Then
                                        lbl_Result.Text = "Send Ok"
                                        SAVE_LOG(gridrow.Cells(0).Text)
                                    Else
                                        ShowToastr(Page, "error", "error", "error")
                                    End If
                                Else
                                    ShowToastr(Page, "Update Admin Error", "error", "error")
                                End If

                            End If




                        Catch ex As Exception
                            lbl_error.Text = ex.ToString
                            conn.Close()
                        Finally
                            comm.Parameters.Clear()
                            comm.Dispose()
                            conn.Close()
                        End Try
                        conn.Close()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Private Function New_admin(ByRef admin_idd As Integer, ByVal domain_name As String, ByVal Old_NamesServer As Integer, ByVal DOMAIN_ID As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn3 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm1 As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim comm3 As New Data.SqlClient.SqlCommand

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "INSERT_COMMAND"
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("COMPANY_USER_NAME", get_uonik_user_name(domain_name))
            comm.Parameters.AddWithValue("USER_PASSWORD", ReusableCode.DES_ENC(randompasswowrd(domain_name), get_uonik_user_name(domain_name)))
            comm.Parameters.AddWithValue("ADMIN_CONTACT", "''")
            comm.Parameters.AddWithValue("ADDRESS", "''")
            comm.Parameters.AddWithValue("PHONE", "''")
            comm.Parameters.AddWithValue("FAX", "''")
            comm.Parameters.AddWithValue("EMAIL", Trim(Server.HtmlEncode(txt_email.Text)))
            comm.Parameters.AddWithValue("NAME_SERVER_ID", Old_NamesServer)
            comm.ExecuteNonQuery()
            conn.Close()
            conn2.Open()
            comm2.Connection = conn2
            comm2.CommandText = "MAX_ADMIN"
            comm2.CommandType = CommandType.StoredProcedure
            admin_idd = comm2.ExecuteScalar()
            conn2.Close()
            conn3.Open()
            comm3.Connection = conn3
            comm3.CommandText = "UPDATE_DOMAIN_PROC"
            comm3.CommandType = CommandType.StoredProcedure
            comm3.Parameters.AddWithValue("DOMAIN_ID", DOMAIN_ID)
            comm3.Parameters.AddWithValue("ADMIN_ID", admin_idd)
            comm3.ExecuteNonQuery()
            conn3.Close()
            New_admin = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Update Admin Error.1", "error.1", "error")
            conn.Close()
        End Try
        Return New_admin
    End Function

    Private Function randompasswowrd(ByVal domain_name As String) As String
        Dim rngCrypto As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim randomString As String = ""
        For i As Integer = 0 To 6 - 1
            Dim randomUnsignedInteger32Bytes As Byte() = New Byte(3) {}
            rngCrypto.GetBytes(randomUnsignedInteger32Bytes)
            randomString = BitConverter.ToString(randomUnsignedInteger32Bytes, 0)
        Next
        Return randomString

    End Function
    Private Function get_uonik_user_name(ByVal domainName As String) As String
        Dim a As String = domainName
        Const min As Integer = 100
        Const max As Integer = 999
        Const elemInRange As Integer = max - min + 1
        Dim randomData = New Byte(3) {}

        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()


        rng.GetBytes(randomData)
        Dim randomInt = BitConverter.ToUInt32(randomData, 0)
        Dim [mod] = randomInt Mod elemInRange
        Dim secureNumber = min + [mod]
        While Not check_update(a)
            a = a & secureNumber
            check_update(a)
        End While
        get_uonik_user_name = a
        Return get_uonik_user_name

    End Function
    Private Function check_update(ByVal COMPANY_USER_NAME As String) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm1 As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Try
            conn.Open()
            comm1.Connection = conn
            comm1.CommandText = "GET_ADMIN_INFO"
            comm1.CommandType = CommandType.StoredProcedure
            comm1.Parameters.AddWithValue("company_user_name", COMPANY_USER_NAME)
            red1 = comm1.ExecuteReader()
            If red1.HasRows = False Then
                check_update = True
            Else
                check_update = False
            End If
            red1.Close()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try
        Return check_update
    End Function
    Private Function send_forgot_EMail(ByVal admin_id As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim recipant_email, recipant_name, Subject, USER_PASSWORD, message_body3 As String
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "admin_info"
            comm.Parameters.AddWithValue("admin_id", admin_id)
            comm.CommandType = CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                If red1.HasRows = True Then
                    recipant_email = red1("EMAIL")
                    recipant_name = red1.Item("COMPANY_USER_NAME")
                    USER_PASSWORD = ReusableCode.Decrypt(red1.Item("USER_PASSWORD"))
                    Subject = "Forgot your password"
                    message_body3 = "www.dns.jo<br><br><br><br>"
                    message_body3 += "Your User Name : " & recipant_name & "<br>"
                    message_body3 += "password: " & USER_PASSWORD & "<br>"
                    message_body3 += "Your e-mail address : " & recipant_email & "<br>"
                    ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body3)
                Else
                    recipant_email = ""
                    recipant_name = ""
                    USER_PASSWORD = ""
                End If
            End While

            red1.Close()
            send_forgot_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            lbl_error.Text = ex.ToString
            conn.Close()
            Response.Write(ex.ToString)
        End Try
        conn.Close()
    End Function

    Private Function get_old_nameserver(ByVal admin_id As Integer) As Integer
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm1 As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Try
            conn.Open()
            comm1.Connection = conn
            comm1.CommandText = "admin_name_server"
            comm1.Parameters.AddWithValue("admin_id", admin_id)
            comm1.CommandType = CommandType.StoredProcedure
            red1 = comm1.ExecuteReader()
            red1.Read()
            If red1.HasRows Then
                get_old_nameserver = red1.Item(0)
            Else
                get_old_nameserver = 0
            End If
            red1.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try
        conn.Close()
        Return get_old_nameserver
    End Function

    Private Function check_Many_Domains(ByVal admin_idd As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm1 As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Try
            conn.Open()
            comm1.Connection = conn
            comm1.CommandText = "count_domains"
            comm1.Parameters.AddWithValue("admin_id", admin_idd)
            comm1.CommandType = CommandType.StoredProcedure
            red1 = comm1.ExecuteReader()
            red1.Read()
            If red1.Item(0) > 1 Then
                check_Many_Domains = True
            Else
                check_Many_Domains = False
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try
        conn.Close()
        Return check_Many_Domains
    End Function


    Private Function update_admin(ByVal admin_idd As Integer, ByVal domain_name As String) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))

        Dim comm As New Data.SqlClient.SqlCommand

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "update_admin_contacts"
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("ad", admin_idd)
            comm.Parameters.AddWithValue("cu", get_uonik_user_name(domain_name))
            comm.Parameters.AddWithValue("up", ReusableCode.DES_ENC(randompasswowrd(domain_name), get_uonik_user_name(domain_name)))
            comm.Parameters.AddWithValue("email", Trim(Server.HtmlEncode(txt_email.Text)))
            comm.ExecuteNonQuery()
            update_admin = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
            update_admin = False
        End Try
        conn.Close()
    End Function

    Public Function SAVE_LOG(ByVal domain As String)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "LOG_SEND"
            comm.CommandType = CommandType.StoredProcedure
            comm.Parameters.AddWithValue("USER", 8)
            comm.Parameters.AddWithValue("dOMAIN", domain)
            comm.Parameters.AddWithValue("req", Now)
            comm.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Extract_DN:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Function


End Class

