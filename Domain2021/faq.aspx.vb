Imports System
Imports System.Data
Imports System.IO
Imports System.Threading

Partial Class faq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Session("page") = "faq"
            Dim lang As New Languages(Session("lang"))
            If Session("lang") = "ar" Then
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetArabicContent("FAQ"))

            Else
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetEnglishContent("FAQ"))
            End If


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\faq:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") Is Nothing Then
            Session("lang") = "ar"
        End If
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "~/MasterPageAr.master"
        Else
            Me.MasterPageFile = "~/MasterPage_En.master"
        End If
    End Sub
End Class
