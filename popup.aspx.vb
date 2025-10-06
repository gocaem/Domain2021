Public Class popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lang As New Languages(Session("lang"))
        SetLanguage()
        If Session("value") = "" Or Session("value") = Nothing Then
            Response.Redirect("FirstPage.aspx")
        ElseIf Session("value") = "reset" Then
            lblupdate.Text = lang.reseted
            LinkButton1.Text = lang.LoginArea
            Button4.Text = lang.LoginArea
            btnc.InnerText = lang.close
        Else
            lblupdate.Text = lang.AdminAccount
            LinkButton1.Text = lang.LoginArea
            Button4.Text = lang.LoginArea
            btnc.InnerText = lang.close
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
    End Sub
    Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        lblupdate.Style.Add("font-family", lang.fonta)
        LinkButton1.Style.Add("font-family", lang.fonta)
        Button4.Style.Add("font-family", lang.fonta)
        btnc.InnerText = lang.close
        btnc.Style.Add("font-family", lang.fonta)
    End Sub
    Protected Sub lk_Click(sender As Object, e As EventArgs)
        Response.Redirect("LoginUser.aspx")
    End Sub

End Class