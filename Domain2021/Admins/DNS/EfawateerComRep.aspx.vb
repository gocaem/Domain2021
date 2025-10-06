Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports Microsoft.Security.Application
Imports System.IO
Imports System.Threading

Public Class EfawateerComRep
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        Dim i As Integer = 1
        For Each row As GridViewRow In GridView1.Rows
            CType(row.FindControl("Label63"), Label).Text = i
            i = i + 1
        Next
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try

            GridView1.PageIndex = e.NewPageIndex
            If txt_domain_name.Text <> "" And RadDatePicker1.Text <> "" Then
                ''select Reports by Date and Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDateDomain"
                ocmd.Parameters.AddWithValue("Domain_name", Me.txt_domain_name.Text)
                ocmd.Parameters.AddWithValue("DDate", RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
                ocon.Close()
            ElseIf txt_domain_name.Text <> "" And RadDatePicker1.Text = "" Then
                ''select Reports by  Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDomain"
                ocmd.Parameters.AddWithValue("domain", Me.txt_domain_name.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
                ocon.Close()

            ElseIf txt_domain_name.Text = "" And RadDatePicker1.Text <> "" Then
                ''select Reports by Date 
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactions"
                ocmd.Parameters.AddWithValue("DDate", Me.RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
                ocon.Close()
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Efawateercom:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub

    Protected Sub LButtonID_Click(sender As Object, e As EventArgs)
        Try


            If txt_domain_name.Text <> "" And RadDatePicker1.Text <> "" Then
                ''select Reports by Date and Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDateDomain"
                ocmd.Parameters.AddWithValue("Domain", Me.txt_domain_name.Text)
                ocmd.Parameters.AddWithValue("DDate", RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.AllowPaging = False
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView3.DataSource = dt
                        GridView3.DataBind()
                        Dim amount As Integer = 0
                        For Each row As GridViewRow In GridView1.Rows
                            amount = amount + row.Cells(4).Text
                        Next
                        amountL.Text = ""
                        amountL.Text = "Amount:" & amount & "JD"

                        GridView1.AllowPaging = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        Session.Add("dt", dt)
                    End Using
                End Using
                ocon.Close()
            ElseIf txt_domain_name.Text <> "" And RadDatePicker1.Text.ToString = "" Then
                ''select Reports by  Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDomain"
                ocmd.Parameters.AddWithValue("domain", Me.txt_domain_name.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.AllowPaging = False
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView3.DataSource = dt
                        GridView3.DataBind()
                        Dim amount As Integer = 0
                        For Each row As GridViewRow In GridView1.Rows
                            amount = amount + row.Cells(4).Text
                        Next
                        amountL.Text = ""
                        amountL.Text = "Amount:" & amount & "JD"

                        GridView1.AllowPaging = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        Session.Add("dt", dt)
                    End Using
                End Using
                ocon.Close()
            ElseIf txt_domain_name.Text = "" And RadDatePicker1.Text <> "" Then
                ''select Reports by Date 
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactions"
                ocmd.Parameters.AddWithValue("DDate", Me.RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                Using sda As New SqlDataAdapter()
                    sda.SelectCommand = ocmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.AllowPaging = False
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView3.DataSource = dt
                        GridView3.DataBind()
                        Dim amount As Integer = 0
                        For Each row As GridViewRow In GridView1.Rows
                            amount = amount + row.Cells(4).Text
                        Next
                        amountL.Text = ""
                        amountL.Text = "Amount:" & amount & "JD"

                        GridView1.AllowPaging = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        Session.Add("dt", dt)
                    End Using
                End Using
                ocon.Close()
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Efawateercom:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub

    Private Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        Dim i As Integer = 1
        For Each row As GridViewRow In GridView1.Rows
            CType(row.FindControl("Label63"), Label).Text = i
            i = i + 1
        Next
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try

            If e.CommandName = "det" Then

                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim SID As Integer = Convert.ToInt32(e.CommandArgument)
                Label64.Text = SID
                Panel1.Visible = True
                GridView2.DataBind()
                Dim ODR As SqlClient.SqlDataReader
                Dim connectionstr As DAL = New DAL()
                Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm2 As New Data.SqlClient.SqlCommand("efawatercomInvoicesdet", conn2)
                comm2.CommandType = CommandType.StoredProcedure
                comm2.Parameters.AddWithValue("invoice_settingID", Label64.Text)
                conn2.Open()
                ODR = comm2.ExecuteReader
                While ODR.Read
                    If Not ODR("PaidAmt") Is DBNull.Value Then
                        Label65.Text = ODR("PaidAmt")
                        Label68.Text = ODR("DDate")
                    End If
                End While
                DDate.Text = "التاريخ" & "  " & ":" & "   "
                AAmount.Text = " المبلغ الإجمالي:" & "  "
                Label65.Text &= "  " & "دينار أردني"
                ODR.Close()
                conn2.Close()
            ElseIf e.CommandName = "print" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim SID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("pid") = SID
                Session("TranNo") = GridView1.Rows.Item(0).Cells(3).Text


                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('InvoicePrint.aspx');", True)
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Efawateercom:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    Protected Sub exportExcel_Click(sender As Object, e As EventArgs)
        Try
            ExportGridToExcel()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Efawateercom:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub ExportGridToExcel()
        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Dim FileName As String = "Transactions" & DateTime.Now & ".xls"
        Dim strwritter As StringWriter = New StringWriter()
        Dim htmltextwrtter As HtmlTextWriter = New HtmlTextWriter(strwritter)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.ContentEncoding = Encoding.UTF8
        Response.AddHeader("Content-Disposition", "attachment;filename=" & FileName)
        GridView3.GridLines = GridLines.Both
        GridView3.HeaderStyle.Font.Bold = True
        GridView3.RenderControl(htmltextwrtter)
        Response.Write(strwritter.ToString())
        Response.[End]()
    End Sub

    Protected Sub Printit_Click(sender As Object, e As EventArgs)
        Session("PrintedDoc") = Session("dt")
        Session("Amount") = amountL.Text
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('PrintedReports.aspx');", True)
    End Sub
End Class