Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class SecondDomains
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

    Protected Sub Insert_Click(sender As Object, e As EventArgs)
        Try
            'insertNewSecond
            Dim connectionstr As DAL = New DAL()
            Dim conn_second As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd_second As New Data.SqlClient.SqlCommand("insertNewSecond", conn_Second)
            conn_Second.Open()
            ocmd_second.CommandType = CommandType.StoredProcedure
            ocmd_second.Parameters.AddWithValue("second_name", Server.HtmlEncode(Second_name.Text))
            ocmd_second.Parameters.Add("ID", SqlDbType.Int)
            ocmd_second.Parameters("ID").Direction = ParameterDirection.Output
            ocmd_second.ExecuteNonQuery()
            Session("ID") = Convert.ToString(ocmd_second.Parameters("ID").Value)
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand("insert_feessecond", conn)
            conn.Open()
            ocmd.CommandType = CommandType.StoredProcedure
            ocmd.Parameters.AddWithValue("TLD", Session("ID"))
            ocmd.Parameters.AddWithValue("newValue", Server.HtmlEncode(FeesJD.Text.Trim))
            ocmd.Parameters.AddWithValue("renewValue", Server.HtmlEncode(FeesJD.Text.Trim))
            ocmd.Parameters.AddWithValue("ValueUSD", Server.HtmlEncode(FeesUSD.Text.Trim))
            ocmd.ExecuteNonQuery()
            GridView2.DataBind()
            ShowToastr(Page, "Inserted Successfully...", "Done", "success")
            conn.Close()
            conn_Second.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SecondDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
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
                Dim second_domain_ID As String = Convert.ToString(e.CommandArgument)
                Session("ID") = second_domain_ID
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("delete_second", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("ID", Session("ID").ToString.Trim)
                ocmd.Parameters.Add("Message", SqlDbType.VarChar, 200)
                ocmd.Parameters("Message").Direction = ParameterDirection.Output
                ocmd.ExecuteNonQuery()
                GridView2.DataBind()

                Dim message As String = Convert.ToString(ocmd.Parameters("Message").Value)
                ShowToastr(Page, message, "Done", "success")
                conn.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SecondDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try



    End Sub
End Class