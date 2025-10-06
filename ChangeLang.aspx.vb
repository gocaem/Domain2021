Public Class ChangeLang
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("lang") = "ar" Then
            If Session("page") = "policy" Then
                Session("lang") = "en"
                Response.Redirect("Policy.aspx")
            ElseIf Session("page") = "Premuim" Then
                Session("lang") = "en"
                Response.Redirect("Premuim.aspx")
            ElseIf Session("page") = "fees" Then
                Session("lang") = "en"
                Response.Redirect("fees.aspx")
            ElseIf Session("page") = "Banned" Then
                Session("lang") = "en"
                Response.Redirect("BannedDomains.aspx")
            ElseIf Session("page") = "forget" Then
                Session("lang") = "en"
                Response.Redirect("ForgetPass.aspx")
            ElseIf Session("page") = "First" Then
                Session("lang") = "en"
                Response.Redirect("FirstPageEn.aspx")
            ElseIf Session("page") = "faq" Then
                Session("lang") = "en"
                Response.Redirect("faq.aspx")
            ElseIf Session("page") = "login" Then
                Session("lang") = "en"
                Response.Redirect("LoginUser.aspx")
            ElseIf Session("page") = "efawateercom" Then
                Session("lang") = "en"
                Response.Redirect("Efawateercom.aspx")
            ElseIf Session("page") = "stat" Then
                Session("lang") = "en"
                Response.Redirect("DomStat.aspx")
            ElseIf Session("page") = "DomDet" Then
                Session("lang") = "en"
                Response.Redirect("WhoisDetails.aspx")
            ElseIf Session("page") = "custom" Then
                Session("lang") = "en"
                Response.Redirect("CustomError.aspx")
            ElseIf Session("page") = "contactus" Then
                Session("lang") = "en"
                Response.Redirect("contactus.aspx")
            ElseIf Session("page") = "About" Then
                Session("lang") = "en"
                Response.Redirect("AboutUs.aspx")
            ElseIf Session("page") = "register" Then
                Session("lang") = "en"
                Response.Redirect("RegisterDomain.aspx")
            ElseIf Session("page") = "paper" Then
                Session("lang") = "en"
                Response.Redirect("papers.aspx")
            ElseIf Session("page") = "family" Then
                Session("lang") = "en"
                Response.Redirect("JoFamily.aspx")
            ElseIf Session("page") Is Nothing Then
                Session("lang") = "en"
                Response.Redirect("FirstPageEn.aspx")
            End If
        Else
            If Session("page") = "policy" Then
                Session("lang") = "ar"
                Response.Redirect("Policy.aspx")
            ElseIf Session("page") = "fees" Then
                Session("lang") = "ar"
                Response.Redirect("fees.aspx")
            ElseIf Session("page") = "Premuim" Then
                Session("lang") = "ar"
                Response.Redirect("Premuim.aspx")
            ElseIf Session("page") = "login" Then
                Session("lang") = "ar"
                Response.Redirect("LoginUser.aspx")
            ElseIf Session("page") = "forget" Then
                Session("lang") = "ar"
                Response.Redirect("ForgetPass.aspx")
            ElseIf Session("page") = "First" Then
                Session("lang") = "ar"
                Response.Redirect("FirstPageEn.aspx")
            ElseIf Session("page") = "faq" Then
                Session("lang") = "ar"
                Response.Redirect("faq.aspx")
            ElseIf Session("page") = "Banned" Then
                Session("lang") = "ar"
                Response.Redirect("BannedDomains.aspx")
            ElseIf Session("page") = "efawateercom" Then
                Session("lang") = "ar"
                Response.Redirect("Efawateercom.aspx")
            ElseIf Session("page") = "stat" Then
                Session("lang") = "ar"
                Response.Redirect("DomStat.aspx")
            ElseIf Session("page") = "DomDet" Then
                Session("lang") = "ar"
                Response.Redirect("WhoisDetails.aspx")
            ElseIf Session("page") = "custom" Then
                Session("lang") = "ar"
                Response.Redirect("CustomError.aspx")
            ElseIf Session("page") = "contactus" Then
                Session("lang") = "ar"
                Response.Redirect("contactus.aspx")
            ElseIf Session("page") = "About" Then
                Session("lang") = "ar"
                Response.Redirect("AboutUs.aspx")
            ElseIf Session("page") = "register" Then
                Session("lang") = "ar"
                Response.Redirect("RegisterDomain.aspx")
            ElseIf Session("page") = "paper" Then
                Session("lang") = "ar"
                Response.Redirect("papers.aspx")
            ElseIf Session("page") = "family" Then
                Session("lang") = "ar"
                Response.Redirect("JoFamily.aspx")
            ElseIf Session("page") Is Nothing Then
                Session("lang") = "ar"
                Response.Redirect("FirstPage.aspx")
            End If
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") Is Nothing Then
            Session("lang") = "ar"
        End If
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPageAr.master"
        Else
            Me.MasterPageFile = "MasterPage_En.master"
        End If
    End Sub

End Class