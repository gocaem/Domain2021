Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class Classification
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
            If Session("update") <> "1" Then
                Session("update") = ""
                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim COMM As New Data.SqlClient.SqlCommand
                Dim i As Integer = 0
                COMM.Connection = ocon
                ocon.Open()
                COMM.CommandText = "insert_class"
                COMM.CommandType = Data.CommandType.StoredProcedure
                COMM.Parameters.AddWithValue("ClassificationNameAr", Server.HtmlEncode(txt_admin_id.Text))
                COMM.Parameters.AddWithValue("ClassificationNameEn", Server.HtmlEncode(TextBox1.Text))
                COMM.Parameters.AddWithValue("Integration", False)
                COMM.Parameters.AddWithValue("Type", "none")
                i = COMM.ExecuteNonQuery
                ocon.Close()
                ShowToastr(Page, "Updated Successfully..", "Done", "success")

            Else
                Dim connectionstr As DAL = New DAL()
                Dim ClassConn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ClassComm As New System.Data.SqlClient.SqlCommand("update_class", ClassConn)
                ClassComm.Parameters.AddWithValue("ClassificationID", Session("ClassificationID"))
                ClassComm.Parameters.AddWithValue("EnName", TextBox1.Text)
                ClassComm.Parameters.AddWithValue("ArName", txt_admin_id.Text)
                ClassConn.Open()
                ClassComm.CommandType = System.Data.CommandType.StoredProcedure
                ClassComm.ExecuteNonQuery()
                ClassConn.Close()
                GridView2.DataBind()
                ShowToastr(Page, "Update Successfully", "Done", "success")
                Session("update") = ""
                Button1.Text = "Add"
                Button1.CssClass = "btn btn-info"
                TextBox1.Text = ""
                txt_admin_id.Text = ""
            End If


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\classification:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
                'view all domain details
                Session("update") = ""
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ClassificationID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ClassificationID") = ClassificationID
                Dim connectionstr As DAL = New DAL()
                Dim ClassConn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ClassComm As New System.Data.SqlClient.SqlCommand("delete_class", ClassConn)
                ClassComm.Parameters.AddWithValue("ClassificationID", ClassificationID)
                ClassComm.Parameters.Add("message", SqlDbType.VarChar, 200)
                ClassComm.Parameters("message").Direction = ParameterDirection.Output
                ClassComm.Parameters.Add("messageType", SqlDbType.VarChar, 200)
                ClassComm.Parameters("messageType").Direction = ParameterDirection.Output
                ClassConn.Open()
                ClassComm.CommandType = System.Data.CommandType.StoredProcedure
                ClassComm.ExecuteNonQuery()
                GridView2.DataBind()
                ClassConn.Close()
                GridView2.Visible = True
                Dim title As String
                If Convert.ToString(ClassComm.Parameters("messageType").Value) = "warning" Then
                    title = "Warning"
                Else
                    title = "Done"
                End If
                ShowToastr(Page, Convert.ToString(ClassComm.Parameters("message").Value), title, Convert.ToString(ClassComm.Parameters("messageType").Value))
                Session("update") = "0"
            ElseIf e.CommandName = "edit1" Then
                Dim ClassificationID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ClassificationID") = ClassificationID
                Session("update") = "1"
                Button1.Text = "Update"
                Button1.CssClass = "btn btn-success"


            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\classification:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try

    End Sub
End Class