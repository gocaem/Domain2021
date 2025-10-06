Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class Unused
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
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "delete1" Then
                'view all domain details
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim Admin_ID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Admin_ID") = Admin_ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_ADMIN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_ADMIN As New System.Data.SqlClient.SqlCommand("DELETE_ADMIN", connDELETE_ADMIN)
                ocmdDELETE_ADMIN.Parameters.AddWithValue("ADMIN", Admin_ID)
                connDELETE_ADMIN.Open()
                ocmdDELETE_ADMIN.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_ADMIN.ExecuteNonQuery()
                GridView2.DataBind()
                connDELETE_ADMIN.Close()
                GridView1.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try

            For Each row As GridViewRow In GridView1.Rows
                Dim ID As Integer = Convert.ToInt32(row.Cells(1).Text)
                Session("ID") = ID

                Dim connectionstr As DAL = New DAL()
                Dim conndeleteinvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmddeleteinvoice As New System.Data.SqlClient.SqlCommand("deleteinvoice", conndeleteinvoice)
                ocmddeleteinvoice.Parameters.AddWithValue("ID", ID)
                conndeleteinvoice.Open()
                ocmddeleteinvoice.CommandType = System.Data.CommandType.StoredProcedure
                ocmddeleteinvoice.ExecuteNonQuery()
                GridView1.DataBind()
                conndeleteinvoice.Close()
                GridView1.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            Next


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "delete1" Then
                'view all domain details
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conndeletebilling As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmddeletebilling As New System.Data.SqlClient.SqlCommand("deletebilling", conndeletebilling)
                ocmddeletebilling.Parameters.AddWithValue("id", ID)
                conndeletebilling.Open()
                ocmddeletebilling.CommandType = System.Data.CommandType.StoredProcedure
                ocmddeletebilling.ExecuteNonQuery()
                GridView1.DataBind()
                conndeletebilling.Close()
                GridView1.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub GridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "delete1" Then
                'view all domain details
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_CON As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_CON As New System.Data.SqlClient.SqlCommand("DELETE_CON", connDELETE_CON)
                ocmdDELETE_CON.Parameters.AddWithValue("ID", ID)
                connDELETE_CON.Open()
                ocmdDELETE_CON.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_CON.ExecuteNonQuery()
                GridView3.DataBind()
                connDELETE_CON.Close()
                GridView3.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub GridView4_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "delete1" Then
                'view all domain details
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_NS As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_NS As New System.Data.SqlClient.SqlCommand("DELETE_NS", connDELETE_NS)
                ocmdDELETE_NS.Parameters.AddWithValue("ID", ID)
                connDELETE_NS.Open()
                ocmdDELETE_NS.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_NS.ExecuteNonQuery()
                GridView4.DataBind()
                connDELETE_NS.Close()
                GridView4.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub GridView5_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "delete1" Then
                'view all domain details
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conndeleteinvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmddeleteinvoice As New System.Data.SqlClient.SqlCommand("deleteinvoice", conndeleteinvoice)
                ocmddeleteinvoice.Parameters.AddWithValue("ID", ID)
                conndeleteinvoice.Open()
                ocmddeleteinvoice.CommandType = System.Data.CommandType.StoredProcedure
                ocmddeleteinvoice.ExecuteNonQuery()
                GridView5.DataBind()
                conndeleteinvoice.Close()
                GridView5.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs)
        Try
            'view all domain details

            GridView5.AllowPaging = False
            GridView5.DataBind()
            For Each row As GridViewRow In GridView5.Rows
                Dim ID As Integer = Convert.ToInt32(row.Cells(1).Text)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conndeleteinvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmddeleteinvoice As New System.Data.SqlClient.SqlCommand("deleteinvoice", conndeleteinvoice)
                ocmddeleteinvoice.Parameters.AddWithValue("ID", ID)
                conndeleteinvoice.Open()
                ocmddeleteinvoice.CommandType = System.Data.CommandType.StoredProcedure
                ocmddeleteinvoice.ExecuteNonQuery()
                GridView5.DataBind()
                conndeleteinvoice.Close()
                GridView5.Visible = True
                ShowToastr(Page, "Deleted Successfully..", "Done", "success")
            Next
            GridView5.AllowPaging = True
            GridView5.DataBind()


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub Button0_Click(sender As Object, e As EventArgs)
        Try


            GridView4.AllowPaging = False
            GridView4.DataBind()
            For Each row As GridViewRow In GridView2.Rows
                Dim Admin_ID As Integer = Convert.ToInt32(row.Cells(1).Text)
                Session("Admin_ID") = Admin_ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_ADMIN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_ADMIN As New System.Data.SqlClient.SqlCommand("DELETE_ADMIN", connDELETE_ADMIN)
                ocmdDELETE_ADMIN.Parameters.AddWithValue("ADMIN", Admin_ID)
                connDELETE_ADMIN.Open()
                ocmdDELETE_ADMIN.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_ADMIN.ExecuteNonQuery()
                GridView2.DataBind()
                connDELETE_ADMIN.Close()
                GridView2.Visible = True
            Next
            GridView2.AllowPaging = True
            GridView2.DataBind()
            ShowToastr(Page, "Deleted Successfully..", "Done", "success")

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Try

            For Each row As GridViewRow In GridView3.Rows
                Dim ID As Integer = Convert.ToInt32(row.Cells(1).Text)
                Session("Admin_ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_CON As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_CON As New System.Data.SqlClient.SqlCommand("DELETE_CON", connDELETE_CON)
                ocmdDELETE_CON.Parameters.AddWithValue("ID", ID)
                connDELETE_CON.Open()
                ocmdDELETE_CON.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_CON.ExecuteNonQuery()
                GridView3.DataBind()
                connDELETE_CON.Close()
                GridView3.Visible = True

            Next
            ShowToastr(Page, "One Page Deleted Successfully..", "Done", "success")


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs)
        Try

            For Each row As GridViewRow In GridView4.Rows
                Dim ID As Integer = Convert.ToInt32(row.Cells(1).Text)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim connDELETE_NS As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdDELETE_NS As New System.Data.SqlClient.SqlCommand("DELETE_NS", connDELETE_NS)
                ocmdDELETE_NS.Parameters.AddWithValue("ID", ID)
                connDELETE_NS.Open()
                ocmdDELETE_NS.CommandType = System.Data.CommandType.StoredProcedure
                ocmdDELETE_NS.ExecuteNonQuery()
                GridView4.DataBind()
                connDELETE_NS.Close()
                GridView4.Visible = True
                GridView4.DataBind()
                ShowToastr(Page, "One Page Deleted Successfully..", "Done", "success")
            Next


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unused:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try

    End Sub
End Class