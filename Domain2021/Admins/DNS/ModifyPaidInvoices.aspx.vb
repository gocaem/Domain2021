Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class ModifyPaidInvoices
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        calculateamount()
    End Sub
    Private Sub calculateamount()
        Try


            Dim griditem As GridViewRow
            Dim amount As Integer = 0
            GridView1.AllowCustomPaging = False
            For Each griditem In GridView3.Rows
                Dim connectionstr As DAL = New DAL()
                Dim connUpdateInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdUpdateInvoice As New System.Data.SqlClient.SqlCommand("calculate_total", connUpdateInvoice)
                ocmdUpdateInvoice.Parameters.AddWithValue("domain_id", griditem.Cells(3).Text)
                ocmdUpdateInvoice.Parameters.AddWithValue("years", griditem.Cells(1).Text)
                connUpdateInvoice.Open()
                ocmdUpdateInvoice.CommandType = System.Data.CommandType.StoredProcedure
                Dim amountP = ocmdUpdateInvoice.Parameters.Add("amount", SqlDbType.Int)
                amountP.Direction = ParameterDirection.ReturnValue
                totalvalue = ocmdUpdateInvoice.ExecuteScalar()
                connUpdateInvoice.Close()
                amount += amountP.Value

            Next
            Label4.Text = "Total Amount:" & amount & "JD"
            GridView1.AllowPaging = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ModifyPaidInvoices:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Protected Sub LK2_Click(sender As Object, e As EventArgs)
        GridView2.Visible = True
        GridView2.DataBind()
        adddomains.Visible = True
    End Sub
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim i As Integer = 1
        For Each row In GridView1.Rows
            CType(row.FindControl("Label64"), Label).Text = i
            i = i + 1
        Next

    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Protected Sub LK_Click(sender As Object, e As EventArgs)
        GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try


            If e.CommandName = "det" Then
                System.Threading.Thread.Sleep(3000)
                'delete domain from invoice
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Session("invoiceid") = Convert.ToInt32(e.CommandArgument)
                GridView3.DataBind()
                GridView3.Visible = True
                LK2.Visible = True
                If GridView3.Rows.Count = 0 Then
                    Label2.Text = "there is not any domain inside this invoice"
                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ModifyPaidInvoices:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub GridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try


            If e.CommandName = "delete" Then
                System.Threading.Thread.Sleep(3000)
                'delete domain from invoice
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("DID") = DomainID
                Dim connectionstr As DAL = New DAL()
                Dim connDelete As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDelete As New System.Data.SqlClient.SqlCommand("delete_domainfromInvoice", connDelete)
                ocmdDelete.Parameters.AddWithValue("domain_id", Session("DID"))
                ocmdDelete.Parameters.AddWithValue("invoicesetting_id", row.Cells(4).Text)
                connDelete.Open()
                ocmdDelete.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDelete.ExecuteNonQuery()
                connDelete.Close()
                GridView3.DataBind()
                GridView3.Visible = True
                calculateamount()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ModifyPaidInvoices:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Private Sub GridView3_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView3.RowDataBound
        Dim i As Integer = 1
        For Each row In GridView3.Rows
            CType(row.FindControl("Label65"), Label).Text = i
            i = i + 1
            calculateamount()
        Next

    End Sub

    Protected Sub adddomains_Click(sender As Object, e As EventArgs)
        Try


            Dim ck As CheckBox
            For Each row In GridView2.Rows
                ck = CType(row.FindControl("ck"), CheckBox)
                If ck.Checked = True Then
                    Dim connectionstr As DAL = New DAL()
                    Dim conndet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmddet As New Data.SqlClient.SqlCommand("savedefault_det", conndet)
                    ocmddet.Parameters.AddWithValue("domain_id", row.Cells(2).Text)
                    ocmddet.Parameters.AddWithValue("years", CType(row.Cells(1).FindControl("DDl"), DropDownList).SelectedValue)
                    ocmddet.Parameters.AddWithValue("invoicesetting_id", Session("invoiceid"))
                    conndet.Open()
                    ocmddet.CommandType = Data.CommandType.StoredProcedure
                    ocmddet.ExecuteNonQuery()
                    conndet.Close()
                    GridView3.DataBind()
                End If
            Next
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ModifyPaidInvoices:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class