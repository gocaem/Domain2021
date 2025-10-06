Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class UpFeesV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            If Session("type") = "edit" Then
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("update_feessecond", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("TLD", ddl.SelectedValue)
                ocmd.Parameters.AddWithValue("newValue", Server.HtmlEncode(JD.Text.Trim))
                ocmd.Parameters.AddWithValue("renewValue", Server.HtmlEncode(JD.Text.Trim))
                ocmd.Parameters.AddWithValue("ValueUSD", Server.HtmlEncode(USD.Text.Trim))
                ocmd.Parameters.AddWithValue("id", Server.HtmlEncode(Session("ID").Trim))
                ocmd.ExecuteNonQuery()
                ShowToastr(Page, "Updated Sucessfully", "Done", "success")
                conn.Close()
                Session("type") = ""
                ddl.ClearSelection()
                USD.Text = ""
                JD.Text = ""
                Session("ID") = ""
                Button1.Text = "Add"
                Button1.CssClass = " form-group btn btn-cyan"
                GridView2.DataBind()
            Else
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("insert_feessecond", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("TLD", ddl.SelectedValue)
                ocmd.Parameters.AddWithValue("newValue", Server.HtmlEncode(JD.Text.Trim))
                ocmd.Parameters.AddWithValue("renewValue", Server.HtmlEncode(JD.Text.Trim))
                ocmd.Parameters.AddWithValue("ValueUSD", Server.HtmlEncode(USD.Text.Trim))
                ocmd.ExecuteNonQuery()
                ShowToastr(Page, "Added Sucessfully", "Done", "success")
                conn.Close()
                GridView2.DataBind()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\UpFeesV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub



    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

End Class