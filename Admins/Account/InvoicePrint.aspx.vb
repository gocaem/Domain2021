Imports System.IO
Imports System.Threading

Public Class InvoicePrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 2 Then
            Response.Redirect("../logout.aspx")
        End If
        Session("lang") = "en"
        Try


            Dim lang As New Languages(Session("lang"))
            DataGrid2.Columns(0).HeaderText = lang.DomainName
            DataGrid2.Columns(1).HeaderText = lang.years
            DataGrid2.HeaderStyle.Font.Name = lang.fonta
            DataGrid2.Style.Add("Font-family", lang.fonta)
            DataGrid2.Style.Add("direction", lang.dir)
            tab1.Style.Add("Font-family", lang.fonta)
            tab1.Style.Add("direction", lang.dir)
            div1.Style.Add("Font-family", lang.fonta)
            DataGrid2.DataBind()
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
                    Session("Client_ID") = ODR("ADMIN_ID")
                End If
            End While
            ODR.Close()
            conn2.Close()
            date0.Text = lang.DDate & "  " & ":" & "   "
            TotAm.Text = lang.Amount & "  "
            TotAm0.Text &= "  " & lang.JD
            tab1.Attributes.Add("Text-align", lang.dir)
            ClientName.Text = "Client ID" & ":"
            ClientName0.Text = Session("Client_ID")
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "account\invoicePrint:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try

    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
End Class
