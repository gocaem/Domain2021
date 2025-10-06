Public Class popupU
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("logout.aspx")
        End If
        Dim lang As New Languages(Session("lang"))
        SetLanguage()
        If Session("value") = "" Or Session("value") = Nothing Then
            Response.Redirect("mydomains.aspx")
        ElseIf Session("value") = "register" Then
            lblupdate.Text = lang.thankyouMSg2
            LinkButton1.Text = ""
            Button4.Text = lang.DomainList
        Else
            lblupdate.Text = lang.thankyouMSg2
            Button4.Text = lang.LoginArea
            Response.Redirect("mydomains.aspx")
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
    End Sub
    Sub SetLanguage()
        Dim lang As New Languages("ar")
        lblupdate.Style.Add("font-family", lang.fonta)
        LinkButton1.Style.Add("font-family", lang.fonta)

        Button4.Style.Add("font-family", lang.fonta)
        btnc.InnerText = lang.close
        btnc.Style.Add("font-family", lang.fonta)
    End Sub
    Protected Sub lk_Click(sender As Object, e As EventArgs)
        Response.Redirect("mydomains.aspx")
    End Sub

    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Session("page") = "popup"
    End Sub
End Class