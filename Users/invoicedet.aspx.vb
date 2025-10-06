Imports System.IO
Imports System.Threading

Public Class invoicedet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("pid") Is Nothing Then
            Response.Redirect("report_invoice.aspx")
        End If
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If

        DataGrid2.DataBind()
        Try


            Dim ODR As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm2 As New Data.SqlClient.SqlCommand("efawatercomInvoicesdet", conn2)
            comm2.CommandType = CommandType.StoredProcedure
            comm2.Parameters.AddWithValue("invoice_settingID", Session("pid"))
            conn2.Open()
            ODR = comm2.ExecuteReader
            While ODR.Read
                If Not ODR("PaidAmt") Is DBNull.Value Then
                    TotAm0.Text = ODR("PaidAmt")
                    date1.Text = ODR("DDate")
                End If
            End While
            ODR.Close()
            conn2.Close()
            SetLanguage()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoicedet:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Session("page") = "invoicedet"
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.master"
        Else
            Me.MasterPageFile = "MasterPageEnn.master"
        End If
    End Sub


End Class