Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class ActivateThisV
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
            Response.Redirect("../logout.aspx")
        End If
        If Not Page.IsPostBack Then
            Try

                Dim connectionstr As DAL = New DAL()
                FILL_DATAGRED()
                FILL_DATAGRED_delete()
                Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd2 As New Data.SqlClient.SqlCommand
                Dim reader As Data.SqlClient.SqlDataReader
                ocmd2.CommandText = "AutoDelete2"
                ocmd2.CommandType = Data.CommandType.StoredProcedure
                ocmd2.Connection = ocon2
                ocon2.Open()
                reader = ocmd2.ExecuteReader()
                While reader.Read
                    Dim Dns_WebContentconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim Dns_WebContentCmd As New SqlClient.SqlCommand("DNSWebsite_SelectPageContent", Dns_WebContentconn)
                    Dns_WebContentconn.Open()
                    Dns_WebContentCmd.CommandType = CommandType.StoredProcedure
                    Dns_WebContentCmd.CommandText = "insertAdminBan"
                    Dns_WebContentCmd.Parameters.AddWithValue("admin_id", reader("admin_id"))
                    Dns_WebContentCmd.Parameters.AddWithValue("domain", reader("domain_name"))
                    Dns_WebContentCmd.Parameters.Add("Message", SqlDbType.NVarChar, 200)
                    Dns_WebContentCmd.Parameters("Message").Direction = ParameterDirection.Output
                    Dns_WebContentCmd.ExecuteNonQuery()
                    Session("Message") = Convert.ToString(Dns_WebContentCmd.Parameters("Message").Value)
                    Dns_WebContentconn.Close()
                End While

                Dim ocondel As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmddel As New Data.SqlClient.SqlCommand
                ocmddel.CommandText = "removedomains"
                ocmddel.CommandType = Data.CommandType.StoredProcedure
                ocmddel.Connection = ocondel
                ocondel.Open()
                ocmddel.ExecuteNonQuery()
                ocondel.Close()
                ocon2.Close()
                reader.Close()
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                ShowToastr(Page, "Failed", "Error!", "error")

            End Try
        End If



    End Sub



    Private Function send_admin_EMail_cancel(ByVal domanes_id As Integer, ByVal message_body_text As String) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader

        Dim dd As DateTime = Now 'CDate(txt_DateOfEnter.Text)
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Dim recipant_email, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4NITC, message_body4 As String
        DOMAIN_NAME = ""
        SECOND_DOMAIN = ""
        message_body1 = ""
        message_body4 = ""
        message_body2 = ""
        recipant_email = ""
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "send_admin_EMail"
            comm.Parameters.AddWithValue("DOMAIN_ID", domanes_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                recipant_email = red1.Item("EMAIL")
                recipant_name = red1.Item("COMPANY_USER_NAME")
                USER_PASSWORD = ReusableCode.Decrypt(red1.Item("USER_PASSWORD"))
                OWNER_NAME = red1.Item("OWNER_NAME")
                DOMAIN_NAME = red1.Item("DOMAIN_NAME").ToString.ToLower
                SECOND_DOMAIN = red1.Item("SECOND_DOMAIN")
            End While
            red1.Close()
            conn.Close()


            Subject = "Cancel Update (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
            message_body = message_body_text
            message_body_4NITC = message_body1 & message_body4 & message_body2

            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, nitc_m, Subject, message_body)
            send_admin_EMail_cancel = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

            conn.Close()
        End Try
        Return True
    End Function
    Private Function send_admin_EMail(ByVal domanes_id As Integer, ByVal message_body_text As String) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim red2 As Data.SqlClient.SqlDataReader
        Dim lang As Languages = New Languages("en")
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim LangFlag As String = ""
        Dim intLoopIndex As Integer

        Dim recipant_email, mob, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4NITC, message_body4 As String
        Subject = ""
        message_body1 = ""
        DOMAIN_NAME = ""
        recipant_email = ""
        SECOND_DOMAIN = ""
        mob = ""
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "send_admin_EMail"
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.Parameters.AddWithValue("DOMAIN_ID ", domanes_id)
            red1 = comm.ExecuteReader()
            While red1.Read
                recipant_email = red1.Item("EMAIL")
                recipant_name = red1.Item("COMPANY_USER_NAME")
                USER_PASSWORD = ReusableCode.Decrypt(red1.Item("USER_PASSWORD"))
                OWNER_NAME = red1.Item("OWNER_NAME")
                DOMAIN_NAME = red1.Item("DOMAIN_NAME").ToString.ToLower
                SECOND_DOMAIN = red1.Item("SECOND_DOMAIN")
                LangFlag = red1.Item("LangFlag")
                mob = red1.Item("mobile")
            End While
            red1.Close()
            conn.Close()

            If (LangFlag.Contains("en")) Then
                conn2.Open()
                comm2.Connection = conn2
                comm2.CommandText = "ma_t"
                comm2.Parameters.AddWithValue("id", 87)
                comm2.CommandType = Data.CommandType.StoredProcedure
                red2 = comm2.ExecuteReader()
                While red2.Read
                    Subject = red2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
                    message_body1 += red2.Item("body_h") & red2.Item("body_t") & red2.Item("body_h1") & red2.Item("body_h2") & red2.Item("body_h3")
                End While
                red2.Close()
                conn2.Close()
            ElseIf (LangFlag.Contains("ar")) Then
                For intLoopIndex = 88 To 90
                    conn2.Open()
                    comm2.Connection = conn2
                    comm2.CommandText = "ma_t"
                    comm2.Parameters.Clear()
                    comm2.Parameters.AddWithValue("id", intLoopIndex)
                    comm2.CommandType = Data.CommandType.StoredProcedure
                    red2 = comm2.ExecuteReader()
                    While red2.Read
                        Subject = red2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
                        message_body1 += red2.Item("body_h") & red2.Item("body_t") & red2.Item("body_h1") & red2.Item("body_h2") & red2.Item("body_h3")

                    End While
                    red2.Close()
                    conn2.Close()
                Next intLoopIndex
            End If

            message_body = message_body1
            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, nitc_m, Subject, message_body)

            Dim str20 As String = mob
            Dim str2 As String = ""
            Dim str3 As String = ""
            Dim str4 As String = ""
            Dim str5 As String = ""
            str2 = Trim(str20)
            str3 = str2.Replace(".", "")
            str4 = str3.Substring(str3.Length - 9, 9)
            str5 = "962" & str4
            Dim str11 As String = message_body_text
            str11 &= " " & DOMAIN_NAME & SECOND_DOMAIN
            str11 &= ", from DNS Team in NITC"
            Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & str11 & "&mobile_number=" & str5 & "&from=" & "domain.jo" & "&tag=" & 1

            ReusableCode.VisitURL(Url1)



            send_admin_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

            conn.Close()
        End Try
        conn.Close()
        Return send_admin_EMail
    End Function

    Private Function update_domains_cancel(ByVal DOMAIN_ID As Integer, ByVal Comment As String, ByVal TestDomain As Boolean) As Boolean
        lbl_Result.Text = ""
        lbl_error.Text = ""
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand
        Try

            conn.Open()
            comm.Connection = conn
            comm.CommandText = "update_status"
            comm.Parameters.AddWithValue("domain_id", DOMAIN_ID)
            comm.Parameters.AddWithValue("TestDomain", TestDomain)
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
            conn2.Open() 'insert Log
            comm2.Connection = conn2
            comm2.CommandText = "insert_log3"
            comm2.Parameters.AddWithValue("domain_id", DOMAIN_ID)
            comm2.Parameters.AddWithValue("status", 9)
            comm2.Parameters.AddWithValue("date", Now)
            comm2.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm2.Parameters.AddWithValue("admin", Session("Users_ID"))
            comm2.Parameters.AddWithValue("comment", Comment)
            comm2.CommandType = Data.CommandType.StoredProcedure
            comm2.ExecuteNonQuery()
            comm2.CommandType = Data.CommandType.StoredProcedure
            comm2.ExecuteNonQuery()
            conn2.Close()
            update_domains_cancel = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

            conn.Close()
            update_domains_cancel = False
        Finally
            comm.Parameters.Clear()
            comm.Dispose()
            conn.Close()
        End Try


    End Function
    Private Function update_domains(ByVal DOMAIN_ID As Integer, ByVal Comment As String, ByVal TestDomain As Boolean) As Boolean
        lbl_Result.Text = ""
        lbl_error.Text = ""
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand

        Try

            conn.Open()
            comm.Connection = conn
            comm.CommandText = "UPDATE_STATUS "
            comm.Parameters.AddWithValue("DOMAIN_ID", DOMAIN_ID)
            comm.Parameters.AddWithValue("TestDomain", TestDomain)
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
            conn2.Open() 'insert Log
            comm2.Connection = conn2
            comm2.CommandText = "insert_log3"
            comm2.Parameters.AddWithValue("domain_id", DOMAIN_ID)
            comm2.Parameters.AddWithValue("status", 8)
            comm2.Parameters.AddWithValue("date", Now)
            comm2.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm2.Parameters.AddWithValue("admin", Session("Users_ID"))
            comm2.Parameters.AddWithValue("comment", Comment)
            comm2.CommandType = Data.CommandType.StoredProcedure
            comm2.ExecuteNonQuery()
            conn2.Close()
            update_domains = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

            conn.Close()
            update_domains = False
        Finally
            comm.Parameters.Clear()
            comm.Dispose()
            conn.Close()
        End Try
        conn2.Close()

    End Function

    Private Function update_domains_delete(ByVal DOMAIN_ID As Integer, ByVal Comment As String) As Boolean
        lbl_Result.Text = ""
        lbl_error.Text = ""
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim comm2 As New Data.SqlClient.SqlCommand

        Try

            conn.Open()
            comm.Connection = conn
            comm.CommandText = "update_status2 "
            comm.Parameters.AddWithValue("DOMAIN_ID", DOMAIN_ID)
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
            conn2.Open() 'insert Log
            comm2.Connection = conn2
            comm2.CommandText = "insert_log3"
            comm2.Parameters.AddWithValue("domain_id", DOMAIN_ID)
            comm2.Parameters.AddWithValue("status", 16)
            comm2.Parameters.AddWithValue("date", Now)
            comm2.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm2.Parameters.AddWithValue("admin", Session("Users_ID"))
            comm2.Parameters.AddWithValue("comment", Comment)
            comm2.CommandType = Data.CommandType.StoredProcedure
            comm2.ExecuteNonQuery()
            conn2.Close()
            update_domains_delete = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

            conn.Close()
            update_domains_delete = False
        Finally
            comm.Parameters.Clear()
            comm.Dispose()
            conn.Close()
        End Try

    End Function
    Private Function UPDATE_DNS_ONLINE(ByVal Dom_id As Integer) As Boolean 'ByVal ID As Integer)
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn3 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn4 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim comm3 As New Data.SqlClient.SqlCommand
        Dim red13 As Data.SqlClient.SqlDataReader
        Dim comm4 As New Data.SqlClient.SqlCommand
        conn.Open()
        comm.Connection = conn
        comm.CommandText = "dom_dns"
        comm.Parameters.AddWithValue("did", Dom_id)
        comm.CommandType = Data.CommandType.StoredProcedure
        Try
            red1 = comm.ExecuteReader() ' . ExecuteReader()
            While red1.Read
                If red1.Item("Status_ID") = 3 Then
                    conn2.Open()
                    comm2.Connection = conn2
                    comm2.CommandText = "insert_dns"
                    comm2.Parameters.AddWithValue("org", red1.Item("ORG_NAME"))
                    comm2.Parameters.AddWithValue("imm", red1.Item("IMMEDIATE_FUTURE"))
                    comm2.Parameters.AddWithValue("dn", red1.Item("DOMAIN_NAME"))
                    comm2.Parameters.AddWithValue("sec", red1.Item("SECOND_DOMAIN_ID"))
                    comm2.Parameters.AddWithValue("p_server", red1.Item("P_SERVER_NAME"))
                    comm2.Parameters.AddWithValue("s_server", red1.Item("S_SERVER_NAME"))
                    comm2.Parameters.AddWithValue("p_ip", red1.Item("P_SERVER_IP"))
                    comm2.Parameters.AddWithValue("s_ip", red1.Item("S_SERVER_IP"))
                    comm2.CommandType = Data.CommandType.StoredProcedure
                    comm2.ExecuteNonQuery()
                    conn2.Close()
                    Dim Max_DNS_ONLINE As Integer
                    conn3.Open()
                    comm3.Connection = conn3
                    comm3.CommandText = "dnsonline"
                    red13 = comm3.ExecuteReader()
                    comm3.CommandType = Data.CommandType.StoredProcedure
                    While red13.Read
                        Max_DNS_ONLINE = CInt(red13.Item(0))
                    End While
                    red13.Close()
                    conn3.Close()
                    conn4.Open()
                    comm4.Connection = conn4
                    comm4.CommandText = "update_dns "
                    comm4.Parameters.AddWithValue("dns", Max_DNS_ONLINE)
                    comm4.Parameters.AddWithValue("did", red1.Item("DOMAIN_ID"))
                    comm4.CommandType = Data.CommandType.StoredProcedure
                    comm4.ExecuteNonQuery()
                    conn4.Close()
                    UPDATE_DNS_ONLINE = True
                Else
                    conn2.Open()
                    comm2.Connection = conn2
                    comm2.CommandText = "update_dns2"
                    comm2.Parameters.AddWithValue("dns", red1.Item("DOMAIN_ID"))
                    comm2.Parameters.AddWithValue("org", red1.Item("ORG_NAME"))
                    comm2.Parameters.AddWithValue("imm", red1.Item("IMMEDIATE_FUTURE"))
                    comm2.Parameters.AddWithValue("dn", red1.Item("DOMAIN_NAME"))
                    comm2.Parameters.AddWithValue("sec", red1.Item("SECOND_DOMAIN_ID"))
                    comm2.Parameters.AddWithValue("p_server", red1.Item("P_SERVER_NAME"))
                    comm2.Parameters.AddWithValue("s_server", red1.Item("S_SERVER_NAME"))
                    comm2.Parameters.AddWithValue("p_ip", red1.Item("P_SERVER_IP"))
                    comm2.Parameters.AddWithValue("s_ip", red1.Item("S_SERVER_IP"))
                    comm2.CommandType = Data.CommandType.StoredProcedure
                    comm2.ExecuteNonQuery()
                    conn2.Close()
                    UPDATE_DNS_ONLINE = True
                End If

            End While
            red1.Close()
            conn.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
            UPDATE_DNS_ONLINE = False
            ShowToastr(Page, "Failed", "Error!", "error")

        Finally

        End Try

        conn.Close()

    End Function
    Private Sub FILL_DATAGRED()
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim red1 As Data.SqlClient.SqlDataReader
            comm.Connection = conn
            comm.CommandText = "engineers_sql1"
            conn.Open()
            red1 = comm.ExecuteReader()
            If red1.HasRows = False Then
                lbl_Result.Text = "<p class='aText'><b>There is no updates</b></p>"
                DataGrid1.DataBind()
                DataGrid1.Visible = False
            Else
                DataGrid1.DataSource = red1
                DataGrid1.DataBind()
            End If
            red1.Close()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

        End Try
    End Sub
    Private Sub FILL_DATAGRED_delete()
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim red1 As Data.SqlClient.SqlDataReader
            comm.Connection = conn
            comm.CommandText = "engineers_sql2"
            conn.Open()
            red1 = comm.ExecuteReader()
            If red1.HasRows = False Then
                lbl_Result.Text = "<p class='aText'><b>There is no updates</b></p>"
                DataGrid2.DataBind()
                DataGrid2.Visible = False
            Else
                DataGrid2.DataSource = red1
                DataGrid2.DataBind()
            End If
            red1.Close()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

        End Try
    End Sub

    Protected Sub DataGrid1_ItemCommand(source As Object, e As DataGridCommandEventArgs)
        Try

            If e.CommandName = "more" Then
                Dim Dom_id As String = e.Item.Cells(0).Text
                Dim connectionstr As DAL = New DAL()
                Dim conn15seldet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("server_data_domain", conn15seldet)
                Dim reader As SqlClient.SqlDataReader
                ocmd15seldet.Parameters.AddWithValue("did", Dom_id)
                conn15seldet.Open()
                ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
                reader = ocmd15seldet.ExecuteReader()
                While reader.Read
                    If Not reader("P_SERVER_NAME") Is DBNull.Value Then
                        p_name.Text = reader("P_SERVER_NAME")
                    End If
                    If Not reader("P_SERVER_IP") Is DBNull.Value Then
                        TextBox1.Text = reader("P_SERVER_IP")
                    End If
                    If Not reader("S_SERVER_NAME") Is DBNull.Value Then
                        TextBox2.Text = reader("S_SERVER_NAME")
                    End If
                    If Not reader("S_SERVER_IP") Is DBNull.Value Then
                        TextBox3.Text = reader("S_SERVER_IP")
                    End If
                    If Not reader("S_SERVER_NAME2") Is DBNull.Value Then
                        TextBox4.Text = reader("S_SERVER_NAME2")
                    End If
                    If Not reader("S_SERVER_IP2") Is DBNull.Value Then
                        TextBox5.Text = reader("S_SERVER_IP2")
                    End If
                    If Not reader("S_SERVER_NAME3") Is DBNull.Value Then
                        TextBox6.Text = reader("S_SERVER_NAME3")
                    End If
                    If Not reader("S_SERVER_IP3") Is DBNull.Value Then
                        TextBox7.Text = reader("S_SERVER_IP3")
                    End If
                    If Not reader("S_SERVER_NAME4") Is DBNull.Value Then
                        TextBox8.Text = reader("S_SERVER_NAME4")
                    End If
                    If Not reader("S_SERVER_IP4") Is DBNull.Value Then
                        TextBox9.Text = reader("S_SERVER_IP4")
                    End If
                    If Not reader("S_SERVER_NAME5") Is DBNull.Value Then
                        TextBox10.Text = reader("S_SERVER_NAME5")
                    End If
                    If Not reader("S_SERVER_IP5") Is DBNull.Value Then
                        TextBox11.Text = reader("S_SERVER_IP5")
                    End If
                    If Not reader("S_SERVER_NAME6") Is DBNull.Value Then
                        TextBox12.Text = reader("S_SERVER_NAME6")
                    End If
                    If Not reader("S_SERVER_IP6") Is DBNull.Value Then
                        TextBox13.Text = reader("S_SERVER_IP6")
                    End If
                    If Not reader("S_SERVER_NAME7") Is DBNull.Value Then
                        TextBox14.Text = reader("S_SERVER_NAME7")
                    End If
                    If Not reader("S_SERVER_IP7") Is DBNull.Value Then
                        TextBox15.Text = reader("S_SERVER_IP7")
                    End If
                    If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                        TextBox16.Text = reader("S_SERVER_NAME8")
                    End If
                    If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                        TextBox17.Text = reader("S_SERVER_IP8")
                    End If
                    If Not reader("S_SERVER_NAME9") Is DBNull.Value Then
                        TextBox18.Text = reader("S_SERVER_NAME9")
                    End If
                    If Not reader("S_SERVER_IP9") Is DBNull.Value Then
                        TextBox19.Text = reader("S_SERVER_IP9")
                    End If
                    If Not reader("S_SERVER_NAME10") Is DBNull.Value Then
                        TextBox20.Text = reader("S_SERVER_NAME10")
                    End If
                    If Not reader("S_SERVER_IP10") Is DBNull.Value Then
                        TextBox21.Text = reader("S_SERVER_IP10")
                    End If

                End While
                reader.Close()
                conn15seldet.Close()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal2();", True)
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewOnly\ActivateThisV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")

        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

End Class
