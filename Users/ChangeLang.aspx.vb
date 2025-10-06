Public Class ChangeLang1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        If Session("lang") = "ar" Then
            If Session("page") = "WhoIS" Then
                Session("lang") = "en"
                Response.Redirect("WhoIs.aspx")
            ElseIf Session("page") = "ChangePassword" Then
                Session("lang") = "en"
                Response.Redirect("ChangePassword.aspx")
            ElseIf Session("page") = "popup" Then
                Session("lang") = "en"
                Response.Redirect("popupU.aspx")
            ElseIf Session("page") = "invoicedet" Then
                Session("lang") = "en"
                Response.Redirect("invoicedet.aspx")
            ElseIf Session("page") = "popup" Then
                Session("lang") = "en"
                Response.Redirect("popupU.aspx")
            ElseIf Session("page") = "DomDet" Then
                Session("lang") = "en"
                Response.Redirect("WhoisDetails.aspx")
            ElseIf Session("page") = "Objection" Then
                Session("lang") = "en"
                Response.Redirect("DomainObjection.aspx")
            ElseIf Session("page") = "DomainDetails" Then
                Session("lang") = "en"
                Response.Redirect("DomainDetails.aspx")
            ElseIf Session("page") = "Include" Then
                Session("lang") = "en"
                Response.Redirect("Include.aspx")
            ElseIf Session("page") = "Invoice" Then
                Session("lang") = "en"
                Response.Redirect("Invoice.aspx")
            ElseIf Session("page") = "mydomains" Then
                Session("lang") = "en"
                Response.Redirect("mydomains.aspx")
            ElseIf Session("page") = "Profile" Then
                Session("lang") = "en"
                Response.Redirect("Profile.aspx")
            ElseIf Session("page") = "register" Then
                Session("lang") = "en"
                Response.Redirect("Register.aspx")
            ElseIf Session("page") = "report_invoice" Then
                Session("lang") = "en"
                Response.Redirect("report_invoice.aspx")
            ElseIf Session("page") = "sub" Then
                Session("lang") = "en"
                Response.Redirect("sub.aspx")
            ElseIf Session("page") = "upload" Then
                Session("lang") = "en"
                Response.Redirect("UploadDoc.aspx")
            ElseIf Session("page") Is Nothing Then
                Session("lang") = "en"
                Response.Redirect("../FirstPageEn.aspx")
            End If

        Else
            If Session("page") = "WhoIS" Then
                Session("lang") = "ar"
                Response.Redirect("WhoIs.aspx")
            ElseIf Session("page") = "ChangePassword" Then
                Session("lang") = "ar"
                Response.Redirect("ChangePassword.aspx")
            ElseIf Session("page") = "invoicedet" Then
                Session("lang") = "ar"
                Response.Redirect("invoicedet.aspx")
            ElseIf Session("page") = "printinvoice" Then
                Session("lang") = "ar"
                Response.Redirect("Print_invoice.aspx")
            ElseIf Session("page") = "popup" Then
                Session("lang") = "ar"
                Response.Redirect("popupU.aspx")
            ElseIf Session("page") = "DomDet" Then
                Session("lang") = "ar"
                Response.Redirect("WhoisDetails.aspx")
            ElseIf Session("page") = "Objection" Then
                Session("lang") = "ar"
                Response.Redirect("DomainObjection.aspx")
            ElseIf Session("page") = "ChangePassword" Then
                Session("lang") = "ar"
                Response.Redirect("ChangePassword.aspx")
            ElseIf Session("page") = "DomainDetails" Then
                Session("lang") = "ar"
                Response.Redirect("DomainDetails.aspx")
            ElseIf Session("page") = "Include" Then
                Session("lang") = "ar"
                Response.Redirect("Include.aspx")
            ElseIf Session("page") = "Invoice" Then
                Session("lang") = "ar"
                Response.Redirect("Invoice.aspx")
            ElseIf Session("page") = "mydomains" Then
                Session("lang") = "ar"
                Response.Redirect("mydomains.aspx")
            ElseIf Session("page") = "Profile" Then
                Session("lang") = "ar"
                Response.Redirect("Profile.aspx")
            ElseIf Session("page") = "register" Then
                Session("lang") = "ar"
                Response.Redirect("Register.aspx")
            ElseIf Session("page") = "report_invoice" Then
                Session("lang") = "ar"
                Response.Redirect("report_invoice.aspx")
            ElseIf Session("page") = "sub" Then
                Session("lang") = "ar"
                Response.Redirect("sub.aspx")
            ElseIf Session("page") = "upload" Then
                Session("lang") = "ar"
                Response.Redirect("UploadDoc.aspx")
            ElseIf Session("page") Is Nothing Then
                Session("lang") = "ar"
                Response.Redirect("../FirstPage.aspx")
            End If
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.master"
        Else
            Me.MasterPageFile = "MasterPageEnn.master"
        End If
    End Sub
End Class