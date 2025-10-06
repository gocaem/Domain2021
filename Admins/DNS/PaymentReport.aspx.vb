Imports System.Data
Imports System
Imports Microsoft.Security.Application
Imports System.Threading
Imports System.IO

Public Class PaymentReport
    Inherits System.Web.UI.Page

    Protected Sub ButtonID_Click(sender As Object, e As EventArgs) Handles ButtonID.Click
        Try


            If Server.HtmlEncode(txt_domain_name.Text) <> "" And RadDatePicker1.Text.ToString <> "" Then
                ''select Reports by Date and Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                Dim odr As SqlClient.SqlDataReader
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDateDomain"
                ocmd.Parameters.AddWithValue("Domain", Server.HtmlEncode(Me.txt_domain_name.Text))
                ocmd.Parameters.AddWithValue("DDate", RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                odr = ocmd.ExecuteReader()
                DataGrid1.DataSource = odr
                DataGrid1.DataBind()
                ocon.Close()
                odr.Close()
            ElseIf Server.HtmlEncode(txt_domain_name.Text) <> "" And RadDatePicker1.Text.ToString = "" Then
                ''select Reports by  Domain name
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                Dim odr As SqlClient.SqlDataReader
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactionsDomain"
                ocmd.Parameters.AddWithValue("domain", Server.HtmlEncode(Me.txt_domain_name.Text))
                ocmd.Connection = ocon
                ocon.Open()
                odr = ocmd.ExecuteReader()
                DataGrid1.DataSource = odr
                DataGrid1.DataBind()
                ocon.Close()
                odr.Close()
            ElseIf Server.HtmlEncode(txt_domain_name.Text) = "" And RadDatePicker1.Text.ToString <> "" Then
                ''select Reports by Date 
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand
                Dim odr As SqlClient.SqlDataReader
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.CommandText = "SelectTransactions"
                ocmd.Parameters.AddWithValue("DDate", Me.RadDatePicker1.Text)
                ocmd.Parameters.AddWithValue("DDate2", RadDatePicker2.Text)
                ocmd.Connection = ocon
                ocon.Open()
                odr = ocmd.ExecuteReader()
                DataGrid1.DataSource = odr
                DataGrid1.DataBind()
                ocon.Close()
                odr.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\PaymentReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        Dim dg As DataGridItem
        Dim i As Integer = 1
        For Each dg In DataGrid1.Items
            CType(dg.FindControl("Label63"), Label).Text = i
            i = i + 1
        Next
        DataGrid1.Columns(2).Visible = False
    End Sub

    Protected Sub DataGrid1_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        Dim dg As DataGridItem
        Dim i As Integer = 1
        For Each dg In DataGrid1.Items
            CType(dg.FindControl("Label63"), Label).Text = i
            i = i + 1
        Next
    End Sub

    Protected Sub DataGrid1_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Try


            If e.CommandName = "det" Then

                Label64.Text = e.Item.Cells(2).Text
                Panel1.Visible = True
                DataGrid2.DataBind()
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
                Session("TranNo") = e.Item.Cells(3).Text
                Session("pid") = e.Item.Cells(2).Text
                Session("Client_ID") = e.Item.Cells(4).Text
                Response.Redirect("PrintInvoice.aspx")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\PaymentReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

End Class