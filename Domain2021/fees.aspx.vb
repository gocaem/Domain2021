Imports System
Imports System.Data
Imports System.IO
Imports System.Threading

Partial Class fees
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim lang As New Languages(Session("lang"))
            Session("page") = "fees"
            If Session("lang") = "ar" Then
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetArabicContent("Fees_1"))

            Else
                td1.Attributes.Add("direction", lang.dir)
                td1.Attributes.Add("align", lang.right)
                td1.InnerHtml = Server.HtmlDecode(ReusableCode.GetEnglishContent("Fees_1"))
            End If

            table2.Style.Add("direction", lang.dir)
            table2.Align = lang.right
            ref3.Font.Name = lang.fonta
            ref3.Text = ""
            ref3.Text = lang.RefrenceNo + ":" + lang.ReferenceID
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\fees:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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

