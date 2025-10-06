Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class UpFees
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
                ocmd.Parameters.AddWithValue("OldFeesUSD", Server.HtmlEncode(Session("USD").ToString().Trim))
                ocmd.Parameters.AddWithValue("OldFeesJD", Server.HtmlEncode(Session("JD").ToString().Trim))
                ocmd.Parameters.AddWithValue("UserID", Server.HtmlEncode(Session("Users_ID").ToString().Trim))
                ocmd.Parameters.AddWithValue("mode", "E")
                ocmd.Parameters.AddWithValue("ipaddress", ReusableCode.GetIPAddress)
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\UpFees:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub


    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "delete1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As String = Convert.ToString(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("delete_feessecond", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("ID", Session("ID").ToString.Trim)
                ocmd.Parameters.AddWithValue("TLD", row.Cells.Item(6).Text)
                ocmd.Parameters.AddWithValue("OldFeesUSD", row.Cells.Item(3).Text)
                ocmd.Parameters.AddWithValue("OldFeesJD", row.Cells.Item(2).Text)
                ocmd.Parameters.AddWithValue("mode", "D")
                ocmd.Parameters.AddWithValue("Ipaddress", ReusableCode.GetIPAddress)
                ocmd.Parameters.AddWithValue("UserID", Server.HtmlEncode(Session("Users_ID").ToString().Trim))
                ocmd.ExecuteNonQuery()
                GridView2.DataBind()
                ShowToastr(Page, "Deleted Successfully...", "Done", "success")
                conn.Close()
            ElseIf e.CommandName = "edit1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As String = Convert.ToString(e.CommandArgument)
                Dim dr As SqlClient.SqlDataReader
                Session("ID") = ID
                Session("type") = "edit"
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("select_feessecondID", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("ID", Session("ID").ToString.Trim)
                dr = ocmd.ExecuteReader()
                While dr.Read
                    USD.Text = dr("ValueUSD").ToString()
                    JD.Text = dr("renewValue").ToString()
                    Session("USD") = USD.Text
                    Session("JD") = USD.Text
                    Session("ID") = dr("ID").ToString()
                    ddl.SelectedValue = dr("TLD").ToString()
                End While
                Button1.CssClass = "form-group btn btn-success"
                Button1.Text = "Edit"

                conn.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\UpFees:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try



    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

End Class