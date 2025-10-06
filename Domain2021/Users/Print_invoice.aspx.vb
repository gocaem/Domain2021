Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Xml

Public Class Print_invoice
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Try


            TotAm0.Text = Session("dueamt")
            DataGrid2.DataBind()

            SetLanguage()


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Print_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

	End Sub


	Private Sub SetLanguage()

        Dim lang As New Languages(Session("lang"))
        DataGrid2.Columns(0).HeaderText = lang.DomainName
        DataGrid2.Columns(1).HeaderText = lang.years
        DataGrid2.HeaderStyle.Font.Name = lang.fonta
        DataGrid2.Style.Add("Font-family", lang.fonta)
        DataGrid2.Style.Add("direction", lang.dir)
        tab1.Style.Add("Font-family", lang.fonta)
        tab1.Style.Add("direction", lang.dir)
        div1.Style.Add("Font-family", lang.fonta)
        date0.Text = lang.DDate & "  " & ":" & "   "
        TotAm.Text = lang.Amount & "  "
        TotAm0.Text &= "  " & lang.JD
        tab1.Attributes.Add("Text-align", lang.dir)
        ClientName.Text = lang.Client_Name & ":"
        ClientName0.Text = Session("ADMIN_CONTACT")
    End Sub

    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Session("page") = "printinvoice"
    End Sub

End Class
