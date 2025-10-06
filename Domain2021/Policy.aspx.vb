Imports System
Imports System.Data
Imports System.IO
Imports System.Threading

Public Class Policy
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("page") = "policy"
            If Session("lang") = "en" Then
                td2.InnerHtml = Server.HtmlDecode(ReusableCode.GetEnglishContent("RegPolicy"))
                td2.Style.Add("direction", "ltr")
                Me.MasterPageFile = "~/MasterPage_En.master"
            Else
                td2.InnerHtml = Server.HtmlDecode(ReusableCode.GetArabicContent("RegPolicy"))
                td2.Style.Add("direction", "rtl")
                Me.MasterPageFile = "~/MasterPageAr.master"
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\policy:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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