Imports System.IO

Public Class SearchclassV
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

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView1.DataBind()
        div11.Visible = True
        DomainInfo.Visible = True
    End Sub


    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    Protected Sub exportExcel_Click(sender As Object, e As EventArgs)
        Try
            ExportGridToExcel()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ExportGridToExcel()
        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Dim FileName As String = "Classification" & DateTime.Now & ".xls"
        Dim strwritter As StringWriter = New StringWriter()
        Dim htmltextwrtter As HtmlTextWriter = New HtmlTextWriter(strwritter)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.ContentEncoding = Encoding.UTF8
        Response.AddHeader("Content-Disposition", "attachment;filename=" & FileName)
        GridView2.GridLines = GridLines.Both
        GridView2.HeaderStyle.Font.Bold = True
        GridView2.RenderControl(htmltextwrtter)
        Response.Write(strwritter.ToString())
        Response.[End]()
    End Sub
    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "view" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
            Dim DomainName As String = Convert.ToString(GridView1.Rows(row.RowIndex).Cells(1).Text)
            Session("Domain_ID") = DomainID
            Session("dID") = DomainID
            Session("DomainName") = DomainName
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('ViewDetails.aspx');", True)
        End If

    End Sub


End Class