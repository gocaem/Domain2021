Imports System
Imports System.Data
Imports System.IO
Imports System.Threading

Partial Class AboutUs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("page") = "About"
        Try
            Dim lang As New Languages(Session("lang"))
            td1.Style.Add("direction", lang.dir)
            If Session("lang") = "en" Then
                td1.Style.Add("direction", lang.dir)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetEnglishContent("AboutUs"))
            Else
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetArabicContent("AboutUs"))
                td1.Style.Add("direction", lang.dir)
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\aboutus:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
