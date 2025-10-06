Imports System.IO
Imports System.Threading

Public Class UnblockV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
            Response.Redirect("../logout.aspx")
        End If
        If Me.IsPostBack = False Then
            Try


                Dim connectionstr As DAL = New DAL()
                Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New System.Data.SqlClient.SqlCommand("select_blocked")
                Dim odr As System.Data.SqlClient.SqlDataReader
                ocmd.CommandType = Data.CommandType.StoredProcedure
                ocmd.Connection = ocon
                ocon.Open()
                odr = ocmd.ExecuteReader
                Me.DataGrid1.DataSource = odr
                Me.DataGrid1.DataBind()
                odr.Close()
                ocon.Close()

            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\UnblockV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
            End Try
        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        btn_unblock()
        Try



            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New System.Data.SqlClient.SqlCommand("select_blocked")
            Dim odr As System.Data.SqlClient.SqlDataReader
            ocmd.CommandType = Data.CommandType.StoredProcedure
            ocmd.Connection = ocon
            ocon.Open()
            odr = ocmd.ExecuteReader
            Me.DataGrid1.DataSource = odr
            Me.DataGrid1.DataBind()
            odr.Close()
            ocon.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\UnblockV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Sub btn_unblock()
        Try

            Dim gridrow As DataGridItem
            Dim ccheck As Boolean

            For Each gridrow In DataGrid1.Items
                ccheck = CType(gridrow.Cells(0).FindControl("CheckBox1"), CheckBox).Checked
                If ccheck Then

                    Dim connectionstr As DAL = New DAL()
                    Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmd As New System.Data.SqlClient.SqlCommand("unblock")
                    ocmd.Parameters.AddWithValue("a", gridrow.Cells(1).Text)
                    ocmd.CommandType = Data.CommandType.StoredProcedure
                    ocmd.Connection = ocon
                    ocon.Open()
                    ocmd.ExecuteNonQuery()
                    ocon.Close()
                    ShowToastr(Page, "Updated Successfully..", "Done", "success")
                End If
            Next

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\UnblockV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
End Class