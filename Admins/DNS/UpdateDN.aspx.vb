Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class UpdateDN
    Inherits System.Web.UI.Page

    Private Sub DataGrid1_EditCommand(ByVal source As Object,
    ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) _
    Handles DataGrid1.EditCommand
        DataGrid1.EditItemIndex = e.Item.ItemIndex
        DataGrid1.DataBind()
    End Sub



    Protected Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
        Try

            Dim tb, tb1, tb2, tb3, tb4 As TextBox
            Dim ocon2 As New Data.SqlClient.SqlConnection
            Dim ocmd As New Data.SqlClient.SqlCommand
            ocon2.ConnectionString = Me.SqlDataSource1.ConnectionString
            ocmd.Connection = ocon2
            ocmd.CommandText = "updateDomainName"
            ocmd.CommandType = CommandType.StoredProcedure
            ocon2.Open()
            DataGrid1.EditItemIndex = e.Item.ItemIndex
            tb = CType(e.Item.Cells(3).Controls(0), TextBox)
            tb1 = CType(e.Item.Cells(1).Controls(0), TextBox)
            tb2 = CType(e.Item.Cells(5).Controls(0), TextBox)
            tb3 = CType(e.Item.Cells(6).Controls(0), TextBox)
            tb4 = CType(e.Item.Cells(2).Controls(0), TextBox)
            ocmd.Parameters.AddWithValue("domain", Server.HtmlEncode(tb.Text))
            ocmd.Parameters.AddWithValue("admin", Server.HtmlEncode(tb1.Text))
            ocmd.Parameters.AddWithValue("org", Server.HtmlEncode(tb2.Text))
            ocmd.Parameters.AddWithValue("owner", Server.HtmlEncode(tb3.Text))
            ocmd.Parameters.AddWithValue("d_id", Server.HtmlEncode(tb4.Text))
            ocmd.ExecuteNonQuery()

            DataGrid1.EditItemIndex = -1

            Me.DataGrid1.DataBind()
            ocon2.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\updatedn:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        Me.DataGrid1.EditItemIndex = -1
        Me.DataGrid1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class