Imports System
Imports Microsoft.Security.Application
Public Class ASCII
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        Label1.Text = SimpleDnsPlus.IDNLib.Encode(Server.HtmlEncode(Me.txt_admin_id.Text))
    End Sub
End Class
