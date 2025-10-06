Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class Approve
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If

        Try
            Dim connectionstr As DAL = New DAL()
            send_AutoDelete_EMail()
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd2 As New Data.SqlClient.SqlCommand
            Dim reader As Data.SqlClient.SqlDataReader
            ocmd2.CommandText = "AutoDelete"
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

            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
            Dim odr As Data.SqlClient.SqlDataReader
            ocmd.CommandText = "approve_admin2"
            ocmd.CommandType = Data.CommandType.StoredProcedure
            ocmd.Connection = ocon
            ocon.Open()
            odr = ocmd.ExecuteReader
            Me.dg.DataSource = odr
            Me.dg.DataBind()
            ocon2.Close()
            ocon.Close()
            odr.Close()
            reader.Close()
            ocondel.Close()
        Catch ex As Exception
            ShowToastr(Page, "Failed", "Error!", "error")
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\approve:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try



    End Sub

    Private Sub send_AutoDelete_EMail()
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim reader As Data.SqlClient.SqlDataReader
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim reader2 As Data.SqlClient.SqlDataReader

        Dim Recipient_email, Subject As String
        Dim message_body, message_body1 As String
        Dim LangFlag, DOMAIN_NAME, SECOND_DOMAIN As String
        message_body1 = ""
        Subject = ""
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "AutoDeleteDomains"
            comm.CommandType = Data.CommandType.StoredProcedure
            reader = comm.ExecuteReader()
            While reader.Read
                Recipient_email = reader.Item("EMAIL")
                LangFlag = reader.Item("LangFlag")
                DOMAIN_NAME = reader.Item("DOMAIN_NAME")
                SECOND_DOMAIN = reader.Item("SECOND_DOMAIN")
                conn2.Open()
                comm2.Connection = conn2
                comm2.CommandText = "SelectEmailTextID"
                If (LangFlag.Contains("en")) Then
                    comm2.Parameters.AddWithValue("id", 20)
                Else
                    comm2.Parameters.AddWithValue("id", 21)
                End If

                comm2.CommandType = Data.CommandType.StoredProcedure
                reader2 = comm2.ExecuteReader()
                While reader2.Read
                    Subject = reader2.Item("EmailName") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
                    message_body1 = reader2.Item("part1") & "(" & DOMAIN_NAME & SECOND_DOMAIN & ")" & reader2.Item("part2") & reader2.Item("footer")
                End While
                reader2.Close()
                conn2.Close()
                Subject = Subject + "-autodelete"
                message_body = message_body1
                ReusableCode.sndMail(Recipient_email, "dns@modee.gov.jo", Subject, message_body)
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            conn.Close()
            ShowToastr(Page, "Failed", "Error!", "error")
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Approve:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try


    End Sub

    Private Sub dg_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg.ItemCommand
        If e.CommandName = "view" Then
            Session("DId") = e.Item.Cells(4).Text
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('Details.aspx');", True)
        End If
    End Sub


    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
End Class