Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class InvoiceSetting
    Inherits System.Web.UI.Page
    Dim maxid As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If

        If Page.IsPostBack = False Then
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub LK_Click(sender As Object, e As EventArgs)
        If projectinput1.Text <> "" Then
            GridView1.DataBind()
            GridView1.Visible = False
            GridView2.Columns(0).Visible = False
            LinkButton1.Visible = False
            LinkButton2.Visible = False
            LK2.Visible = False
        End If
        If GridView2.Rows.Count > 0 Then
            If GridView2.Rows(0).Cells(2).Text = "Invalid Reference ID" Then

                GridView2.Visible = False
                Label1.Visible = True
                GridView2.Rows(0).Cells(1).ForeColor = System.Drawing.Color.Red
                Label1.Text = "Invalid Reference ID	"
                Label1.ForeColor = System.Drawing.Color.Red
                LinkButton1.Visible = False
                LinkButton2.Visible = False
                LinkButton1.Text = ""
                LK2.Visible = False
            Else
                GridView2.Visible = True
                Label1.Visible = True
                Label1.Text = "Currently Available invoice"
                LinkButton1.Visible = True
                LinkButton2.Visible = True
                LinkButton1.Text = "Update Current Invoice"
            End If


        Else

            GridView2.Visible = False
            Label1.Visible = True
            LinkButton1.Visible = True
            LinkButton2.Visible = False
            Label1.Text = "There is no available invoice!"
            LinkButton1.Text = "Insert New Invoice"
        End If
    End Sub

    Private Sub calculate_total(ByVal years As Integer, ByVal Domain_id As Integer)

    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        GridView2.Columns(0).Visible = True
        GridView1.Visible = True
        LK2.Visible = True
        If GridView1.Rows.Count > 0 Then
            If GridView2.Rows.Count > 0 Then
                LK2.Visible = True
                GridView1.DataBind()
                GridView1.Visible = True
                LK2.Text = "Save Updates"
            Else
                GridView1.DataBind()
                GridView1.Visible = True
                LK2.Text = "Save Invoice"
            End If
        Else
            LK2.Visible = False
            Label1.Text = "There isn't any domain can be renewed"
        End If

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim maxidconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim maxidcomm As New System.Data.SqlClient.SqlCommand("delete_Lastinvoice", maxidconn)
            maxidcomm.Parameters.AddWithValue("admin_id", Server.HtmlEncode(projectinput1.Text))
            maxidconn.Open()
            maxidcomm.CommandType = Data.CommandType.StoredProcedure
            maxidcomm.ExecuteNonQuery()
            maxidconn.Close()
            Label1.Text = "Deleted Successfully"
            GridView2.DataBind()
            GridView2.Visible = True
            GridView2.Visible = False
            Label1.Visible = True
            LinkButton1.Visible = True
            LinkButton2.Visible = False
            Label1.Text = "There is no available invoice!"
            LinkButton1.Text = "Insert New Invoice"
            Label2.Text = "Amount:0JD"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\InvoiceSetting:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Protected Sub LK2_Click(sender As Object, e As EventArgs)
        'Save Invoice
        Try


            If (Not LK2.Text.Contains("Update")) Then
                Dim connectionstr As DAL = New DAL()
                Dim connsavedef As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdsavedef As New System.Data.SqlClient.SqlCommand("savedefault", connsavedef)
                ocmdsavedef.Parameters.AddWithValue("Admin_ID", Server.HtmlEncode(projectinput1.Text))
                connsavedef.Open()
                ocmdsavedef.CommandType = Data.CommandType.StoredProcedure
                ocmdsavedef.ExecuteNonQuery()
                connsavedef.Close()
                Dim maxidconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim maxidcomm As New System.Data.SqlClient.SqlCommand("selectmaxsettingID", maxidconn)
                maxidcomm.Parameters.AddWithValue("Admin_ID", projectinput1.Text)
                maxidconn.Open()
                maxidcomm.CommandType = Data.CommandType.StoredProcedure
                If Not maxidcomm.ExecuteScalar() Is DBNull.Value Then
                    maxid = maxidcomm.ExecuteScalar()
                End If
                maxidconn.Close()
                Dim SelectedCount = 0
                Dim cb As CheckBox = New CheckBox()
                Dim ddl As DropDownList = New DropDownList()
                Dim row As GridViewRow
                For Each row In GridView1.Rows
                    cb = CType(row.FindControl("ck"), CheckBox)
                    If (cb.Checked) Then
                        Dim connsavedefu As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmdsavedefu As New System.Data.SqlClient.SqlCommand("savedefault_det", connsavedefu)
                        ocmdsavedefu.Parameters.AddWithValue("domain_id", row.Cells(2).Text)
                        ocmdsavedefu.Parameters.AddWithValue("years", CType(row.FindControl("DDl"), DropDownList).SelectedItem.Text)
                        ocmdsavedefu.Parameters.AddWithValue("invoicesetting_id", maxid)
                        connsavedefu.Open()
                        ocmdsavedefu.CommandType = System.Data.CommandType.StoredProcedure
                        ocmdsavedefu.ExecuteNonQuery()
                        connsavedefu.Close()
                        SelectedCount = SelectedCount + 1
                    End If

                Next
                If SelectedCount = 0 Then
                    Label1.Text = "You have not selected any domain"
                    Label1.ForeColor = System.Drawing.Color.Red
                End If
                GridView2.Visible = True
                GridView2.DataBind()
            Else
                Dim connectionstr As DAL = New DAL()
                Dim maxidconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim maxidcomm As New System.Data.SqlClient.SqlCommand("selectmaxsettingID", maxidconn)
                maxidcomm.Parameters.AddWithValue("Admin_ID", Server.HtmlEncode(projectinput1.Text))
                maxidconn.Open()
                maxidcomm.CommandType = Data.CommandType.StoredProcedure
                If Not maxidcomm.ExecuteScalar() Is DBNull.Value Then
                    maxid = maxidcomm.ExecuteScalar()
                End If
                Dim SelectedCount = 0
                Dim isSelectedCount = 0
                Dim cb As CheckBox = New CheckBox()
                Dim ddl As DropDownList = New DropDownList()
                Dim row As GridViewRow
                Dim row2 As GridViewRow
                For Each row In GridView1.Rows
                    Label2.Text = ""
                    cb = CType(row.FindControl("ck"), CheckBox)
                    If (cb.Checked) Then
                        isSelectedCount = isSelectedCount + 1
                        Dim connUpdateInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmdUpdateInvoice As New System.Data.SqlClient.SqlCommand("addmoreDomains_invoice", connUpdateInvoice)
                        ocmdUpdateInvoice.Parameters.AddWithValue("domain_id", row.Cells(2).Text)
                        ocmdUpdateInvoice.Parameters.AddWithValue("years", CType(row.FindControl("DDl"), DropDownList).SelectedItem.Text)
                        ocmdUpdateInvoice.Parameters.AddWithValue("invoicesetting_id", maxid)
                        connUpdateInvoice.Open()
                        ocmdUpdateInvoice.CommandType = System.Data.CommandType.StoredProcedure
                        ocmdUpdateInvoice.ExecuteNonQuery()
                        connUpdateInvoice.Close()
                        SelectedCount = SelectedCount + 1


                        If SelectedCount = 0 Then
                            Dim connsavedef As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                            Dim ocmdsavedef As New System.Data.SqlClient.SqlCommand("savedefault_det", connsavedef)
                            ocmdsavedef.Parameters.AddWithValue("domain_id", row.Cells(2).Text)
                            ocmdsavedef.Parameters.AddWithValue("years", CType(row.FindControl("DDl"), DropDownList).SelectedItem.Text)
                            ocmdsavedef.Parameters.AddWithValue("invoicesetting_id", maxid)
                            connsavedef.Open()
                            ocmdsavedef.CommandType = System.Data.CommandType.StoredProcedure
                            ocmdsavedef.ExecuteNonQuery()
                            connsavedef.Close()
                            SelectedCount = SelectedCount + 1
                        End If


                    End If

                Next
                If isSelectedCount = 0 Then
                    Label2.Text = "You have not selected any domain"
                    Label2.ForeColor = System.Drawing.Color.Red
                    ShowToastr(Page, "You have not select any domain", "Note", "error")

                End If
                GridView2.Visible = True
                GridView2.DataBind()

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\InvoiceSetting:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub


    Dim totalvalue As Integer
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        For Each row In GridView1.Rows
            For i = 1 To 20
                CType(row.FindControl("DDl"), DropDownList).Items.Add(i)
            Next


        Next

    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Try


            If e.CommandName = "ddelete" Then
                System.Threading.Thread.Sleep(3000)
                'delete domain from invoice
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Dim connectionstr As DAL = New DAL()
                Dim connDelete As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDelete As New System.Data.SqlClient.SqlCommand("delete_domainfromInvoice", connDelete)
                ocmdDelete.Parameters.AddWithValue("domain_id", DomainID)
                ocmdDelete.Parameters.AddWithValue("invoicesetting_id", row.Cells(4).Text)
                connDelete.Open()
                ocmdDelete.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDelete.ExecuteNonQuery()
                connDelete.Close()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\InvoiceSetting:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Dim amount As Integer = 0
    Dim i As Integer = 0

    Private Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        Try


            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.RowType <> DataControlRowType.Header Then


                    Dim connectionstr As DAL = New DAL()
                    Dim connUpdateInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdUpdateInvoice As New System.Data.SqlClient.SqlCommand("calculate_totalFirst", connUpdateInvoice)
                    ocmdUpdateInvoice.Parameters.AddWithValue("domain_id", e.Row.Cells(1).Text)
                    ocmdUpdateInvoice.Parameters.AddWithValue("years", e.Row.Cells(3).Text)
                    connUpdateInvoice.Open()
                    ocmdUpdateInvoice.CommandType = System.Data.CommandType.StoredProcedure
                    Dim amountP = ocmdUpdateInvoice.Parameters.Add("amount", SqlDbType.Int)
                    amountP.Direction = ParameterDirection.ReturnValue
                    totalvalue = Convert.ToInt32(ocmdUpdateInvoice.ExecuteScalar())
                    amount += Convert.ToInt32(amountP.Value)

                    Label2.Text = "Amount:" & amount & "JD"

                End If
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\InvoiceSetting:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
End Class