Imports System.Data
Imports System
Imports System.Threading
Imports System.IO

Public Class eFAWATEERcom
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Session("page") = "efawateercom"
            Dim lang As New Languages(Session("lang"))
            If Session("lang") = "ar" Then
                '   help.ImageUrl = "1.jpg"
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetArabicContent("EfawaterCom"))

            Else
                ' help.ImageUrl = "2.jpg"
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetEnglishContent("EfawaterCom"))
            End If


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\efawateercom:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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

