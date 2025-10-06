Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Threading

Public Class ExpiredDomains
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        Try
            Dim connectionstr As DAL = New DAL()
            Dim CountEmailconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim CountEmailcomm As New System.Data.SqlClient.SqlCommand("CountMailsent", CountEmailconn)
            Dim MailCount As Integer
            CountEmailcomm.Parameters.AddWithValue("Month", ddl.SelectedValue)
            CountEmailconn.Open()
            CountEmailcomm.CommandType = System.Data.CommandType.StoredProcedure
            MailCount = CountEmailcomm.ExecuteScalar()
            CountEmailconn.Close()
            If MailCount >= 2 Then
                LinkButton1.Enabled = False
            End If
            If Not Page.IsPostBack Then
                ddl.DataBind()
                gridbind()
            End If
            CountEmailconn.Close()
            AddYears(1955)
            Years.SelectedValue = Now.Year
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ExpiredDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub AddYears(Optional startYear As Integer = 1955)

        Dim currentYear = Date.Now.Year + 200

        For i = startYear To currentYear
            Years.Items.Add(New ListItem(Convert.ToString(i)))
        Next
    End Sub

    Protected Sub LK_Click(sender As Object, e As EventArgs)
        gridbind()
    End Sub
    Sub gridbind()
        Try


            Dim connectionstr As DAL = New DAL()
            Dim connExpired As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commExpired As New System.Data.SqlClient.SqlCommand("send_financial_invoices", connExpired)
            commExpired.Parameters.AddWithValue("end_date", ddl.SelectedValue)
            commExpired.Parameters.AddWithValue("date", Years.SelectedValue)
            connExpired.Open()
            commExpired.CommandType = System.Data.CommandType.StoredProcedure
            Dim da As SqlDataAdapter = New SqlDataAdapter(commExpired)
            Dim ds As New DataSet
            da.Fill(ds)
            commExpired.ExecuteNonQuery()
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ExpiredDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub LK2_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        Try

            GridView2.AllowPaging = False

            gridbind()
            '    'send mail
            Dim row As GridViewRow

            For Each row In GridView2.Rows
                If (LangFlag.SelectedValue = 1) Then
                    ReusableCode.sndMail(row.Cells.Item(2).Text, "dns@modee.gov.jo", row.Cells.Item(5).Text & "مطالبة مالية للنطاق", text_msg(row.Cells.Item(6).Text, row.Cells.Item(7).Text, row.Cells.Item(5).Text, row.Cells.Item(8).Text, row.Cells(9).Text))
                Else
                    ReusableCode.sndMail(row.Cells.Item(2).Text, "dns@modee.gov.jo", row.Cells.Item(5).Text & "Financial Invoice for the domain", text_msg(row.Cells.Item(6).Text, row.Cells.Item(7).Text, row.Cells.Item(5).Text, row.Cells.Item(8).Text, row.Cells(9).Text))

                End If
            Next
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ExpiredDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
        Try
            Dim connectionstr As DAL = New DAL()
            Dim connMailLog As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commMailLog As New System.Data.SqlClient.SqlCommand("insert_Mail_sent_log", connMailLog)
            commMailLog.Parameters.AddWithValue("Month", ddl.SelectedValue)
            commMailLog.Parameters.AddWithValue("User_ID", Session("Admin_User_ID"))
            connMailLog.Open()
            commMailLog.CommandType = System.Data.CommandType.StoredProcedure
            commMailLog.ExecuteNonQuery()
            ShowToastr(Page, "Updated Successfully..", "Done", "success")
            connMailLog.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ExpiredDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
        GridView2.AllowPaging = True

        gridbind()

    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Public Function text_msg(ByVal strEndDate As String, ByVal strRenewFees As String, ByVal strDomainName As String, ByVal strRenewFeesUSD As String, ByVal admin_id As String) As String
        Try


            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New SqlClient.SqlCommand
            Dim reader As SqlClient.SqlDataReader
            Dim messageBody As String
            Dim intLoopIndex As Integer

            If (LangFlag.SelectedValue = 1) Then
                For intLoopIndex = 50 To 53
                    conn.Open()
                    comm.Connection = conn
                    comm.CommandText = "ma_t"
                    comm.Parameters.Clear()
                    comm.Parameters.AddWithValue("id", intLoopIndex)
                    comm.CommandType = CommandType.StoredProcedure
                    reader = comm.ExecuteReader()
                    While reader.Read
                        If intLoopIndex = 51 Then
                            messageBody = messageBody & reader.Item("body_h") & strRenewFees & reader.Item("body_t") & "<p dir=rtl><br><b><font color=black size=4>الرقم المرجعي المخصص لعملية الدفع هو:" & admin_id & "</b></font></p>"
                        Else
                            messageBody = messageBody & reader.Item("body_h") & strDomainName & reader.Item("body_t") & strEndDate
                        End If
                    End While
                    strDomainName = ""
                    strEndDate = ""
                    reader.Close()
                    conn.Close()
                Next intLoopIndex
                messageBody = messageBody & "<p dir=rtl><br><font color=red>:يُرجى العلم بأن الرقم المرجعي لغايات الدفع هو " & admin_id & "</p>"

            ElseIf (LangFlag.SelectedValue = 0) Then
                intLoopIndex = 101
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "ma_t"
                comm.Parameters.Clear()
                comm.Parameters.Add("id", intLoopIndex)
                comm.CommandType = CommandType.StoredProcedure
                reader = comm.ExecuteReader()
                While reader.Read
                    messageBody = reader.Item("body_h") & strDomainName & reader.Item("body_t") & strEndDate & reader.Item("body_h1") & strRenewFeesUSD & reader.Item("body_h2") & "<br><b><font color=black size=4>Reference Payment Number is:" & admin_id & "</b></font>" & reader.Item("body_h3")
                End While
                strDomainName = ""
                strEndDate = ""
                reader.Close()
                conn.Close()
            End If

            Return messageBody
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ExpiredDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Function

    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        gridbind()
    End Sub
End Class