Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports Domain2021.Toastr
Imports Microsoft.Security.Application
Public Class ManageEmail
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
    Protected Sub EmailTextddl_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Protected Sub Update_Click1(sender As Object, e As EventArgs) Handles Update.Click
        Try

            Dim connectionstr As DAL = New DAL()
            Dim connEmailText As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commEmailText As New System.Data.SqlClient.SqlCommand("update_emailText", connEmailText)
            commEmailText.Parameters.AddWithValue("title", Session("text"))
            commEmailText.Parameters.AddWithValue("body_t", Editor5.Content)
            commEmailText.Parameters.AddWithValue("body_h", Editor1.Content)
            commEmailText.Parameters.AddWithValue("body_h1", Editor2.Content)
            commEmailText.Parameters.AddWithValue("body_h2", Editor3.Content)
            commEmailText.Parameters.AddWithValue("body_h3", Editor4.Content)
            commEmailText.Parameters.AddWithValue("id", Session("id"))
            connEmailText.Open()
            commEmailText.CommandType = System.Data.CommandType.StoredProcedure
            commEmailText.ExecuteNonQuery()
            Toastr.ShowToast(Me, ToastType.Success, "Updated Successfully", "Done", ToastPosition.TopCenter)
            Label1.Text = "Updated Successfully"
            connEmailText.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ManageEmail:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Public Sub fillcontent(ByVal id As Integer)
        Try
            Session("id") = ""
            Session("id") = id
            Dim connectionstr As DAL = New DAL()
            Dim conn_em_text As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm_em_text As New Data.SqlClient.SqlCommand
            Dim reader_em_text As Data.SqlClient.SqlDataReader
            conn_em_text.Open()
            comm_em_text.Connection = conn_em_text
            comm_em_text.CommandText = "em_text"
            comm_em_text.Parameters.AddWithValue("id", id)
            comm_em_text.CommandType = Data.CommandType.StoredProcedure
            reader_em_text = comm_em_text.ExecuteReader()
            If id = 1 Then
                While reader_em_text.Read
                    Editor1.Content = ""
                    Editor2.Content = ""
                    Editor3.Content = ""
                    Editor4.Content = ""
                    ttab5.Visible = False
                    Editor5.Visible = False
                    Editor1.Content = reader_em_text.Item("body_h")
                    Editor2.Content = reader_em_text.Item("body_h1")
                    Editor3.Content = reader_em_text.Item("body_h2")
                    Editor4.Content = reader_em_text.Item("body_h3")
                End While

            ElseIf id = 105 Or 104 Or 107 Then
                Editor1.Content = ""
                Editor2.Content = ""
                Editor3.Content = ""
                Editor4.Content = ""
                Editor5.Content = ""
                ttab5.Visible = True
                Editor5.Visible = True
                While reader_em_text.Read
                    Editor1.Content = reader_em_text.Item("body_h")
                    Editor2.Content = reader_em_text.Item("body_h1")
                    Editor5.Content = reader_em_text.Item("body_t")
                End While
            Else
                While reader_em_text.Read
                    Editor1.Content = ""
                    Editor2.Content = ""
                    Editor3.Content = ""
                    Editor4.Content = ""
                    Editor5.Content = ""
                    ttab5.Visible = True
                    Editor5.Visible = True
                    Editor1.Content = reader_em_text.Item("body_h")
                    Editor2.Content = reader_em_text.Item("body_h1")
                    Editor3.Content = reader_em_text.Item("body_h2")
                    Editor4.Content = reader_em_text.Item("body_h3")
                    Editor5.Content = reader_em_text.Item("body_t")
                End While
            End If
            reader_em_text.Close()
            conn_em_text.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ManageEmail:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        If e.CommandName = "E" Then
            Session("id") = Convert.ToInt32(e.Item.Cells(0).Text)
            Session("text") = e.Item.Cells(1).Text
            fillcontent(Convert.ToInt32(e.Item.Cells(0).Text))
        End If
    End Sub
End Class