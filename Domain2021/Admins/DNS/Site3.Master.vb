Imports System.Web.Helpers

Public Class Site3
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lusername.Text = Session("Admin_User_ID")
    End Sub

End Class