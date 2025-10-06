Public Class DomainOfAdminV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub DataGrid2_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs)
        DataGrid2.CurrentPageIndex = e.NewPageIndex
        DataGrid2.DataBind()
    End Sub

    Protected Sub DataGrid1_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs)
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataGrid1.DataBind()
    End Sub

    Protected Sub DataGrid1_ItemCommand(source As Object, e As DataGridCommandEventArgs)
        If e.CommandName = "view" Then
            Session("did") = CType(e.Item.Cells(4).FindControl("lk"), LinkButton).Text
            Session("DomainName") = e.Item.Cells(2).Text
            Session("Admin_id") = txt_admin_id.Text
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('viewDetails.aspx');", True)

        End If
    End Sub

    Protected Sub DataGrid2_ItemCommand(source As Object, e As DataGridCommandEventArgs)
        If e.CommandName = "view" Then
            Session("did") = CType(e.Item.Cells(4).FindControl("lk2"), LinkButton).Text
            Session("DomainName") = e.Item.Cells(2).Text
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('viewDetails.aspx');", True)

        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        DataGrid1.CurrentPageIndex = 0
        DataGrid1.DataBind()
        DataGrid2.CurrentPageIndex = 0
        DataGrid2.DataBind()

    End Sub
End Class