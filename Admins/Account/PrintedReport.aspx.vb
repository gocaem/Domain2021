Public Class PrintedReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 2 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("PrintedDoc") Is Nothing Then
            Response.Redirect("../logout.aspx")
        End If
        GridView1.DataSource = Session("PrintedDoc")
        GridView1.DataBind()
        Amount.Text = Session("Amount").ToString()
        Label1.Text = "Print Date:" & Now().ToString("dd/MM/yyyy")
    End Sub

End Class