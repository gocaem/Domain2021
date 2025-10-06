Imports System.Data
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class BanAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim connectionstr As DAL = New DAL()
            Dim Dns_WebContentconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim Dns_WebContentCmd As New SqlClient.SqlCommand("DNSWebsite_SelectPageContent", Dns_WebContentconn)
            Dns_WebContentconn.Open()
            Dns_WebContentCmd.CommandType = CommandType.StoredProcedure
            Dns_WebContentCmd.CommandText = "insertAdminBan"
            Dns_WebContentCmd.Parameters.AddWithValue("admin_id", Server.HtmlEncode(txt_admin_id.Text))
            Dns_WebContentCmd.Parameters.AddWithValue("domain", Server.HtmlEncode(domain.Text))
            Dns_WebContentCmd.Parameters.Add("Message", SqlDbType.NVarChar, 200)
            Dns_WebContentCmd.Parameters("Message").Direction = ParameterDirection.Output
            Dns_WebContentCmd.ExecuteNonQuery()
            Session("Message") = Convert.ToString(Dns_WebContentCmd.Parameters("Message").Value)
            ShowToastr(Page, Session("Message"), "Done", "info")
            GridView2.DataBind()
            Dns_WebContentconn.Close()

        Catch ex As Exception
            ShowToastr(Page, ex.Message, "Error", "error")
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\BanAdmin:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "delete1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As String = Convert.ToString(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("deleteBan", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("ID", Session("ID").ToString.Trim)
                ocmd.ExecuteNonQuery()
                GridView2.DataBind()
                ShowToastr(Page, "Deleted Successfully", "Done", "success")
                conn.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\BanAdmin:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try



    End Sub

End Class