Imports System
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Web.Mvc.Html
Imports System.Web.UI
Imports Microsoft.VisualBasic.CompilerServices


Partial Public Class PrintInvoice
    Inherits Page
    Public Sub New()
        AddHandler Load, AddressOf Page_Load
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If MyBase.Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        MyBase.Session("lang") = "en"
        Dim lang = New Languages(Conversions.ToString(MyBase.Session("lang")))
        DataGrid2.Columns(0).HeaderText = lang.DomainName
        Me.DataGrid2.Columns(1).HeaderText = lang.years
        Me.DataGrid2.HeaderStyle.Font.Name = lang.fonta
        Me.DataGrid2.Style.Add("Font-family", lang.fonta)
        Me.DataGrid2.Style.Add("direction", lang.dir)
        Me.tab1.Style.Add("Font-family", lang.fonta)
        Me.tab1.Style.Add("direction", lang.dir)
        Me.div1.Style.Add("Font-family", lang.fonta)
        Me.DataGrid2.DataBind()
        Try


            Dim ODR As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm2 = New SqlClient.SqlCommand("efawatercomInvoicesdet", conn2)
            comm2.CommandType = CommandType.StoredProcedure
            comm2.Parameters.AddWithValue("invoice_settingID", MyBase.Session("pid"))
            conn2.Open()
            ODR = comm2.ExecuteReader()
            While ODR.Read()
                If Not ReferenceEquals(ODR("PaidAmt"), DBNull.Value) Then
                    Me.TotAm0.Text = Conversions.ToString(ODR("PaidAmt"))
                    Me.date1.Text = Conversions.ToString(ODR("DDate"))
                    MyBase.Session("Client_ID") = ODR("ADMIN_ID")
                End If
            End While
            ODR.Close()
            conn2.Close()
            Me.date0.Text = lang.DDate.ToString() & "  ".ToString() & ":".ToString() & "   "
            Me.TotAm.Text = lang.Amount.ToString() & "  "
            Me.TotAm0.Text += "  " & lang.JD.ToString()
            Me.tab1.Attributes.Add("Text-align", lang.dir)
            Me.ClientName.Text = "Client ID" & ":"
            Me.ClientName0.Text = Conversions.ToString(MyBase.Session("Client_ID"))
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\PrintInvoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Sub

End Class
