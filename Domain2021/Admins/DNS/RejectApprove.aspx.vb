Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Public Class RejectApprove
    Inherits System.Web.UI.Page


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connectionstr As DAL = New DAL()
        Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim odr As Data.SqlClient.SqlDataReader
        Try

            If Me.RadioButtonList1.SelectedIndex = 0 Then

                comm.Connection = ocon
                ocon.Open()
                comm.CommandText = "Report_Approve"
                comm.Parameters.AddWithValue("start", Server.HtmlEncode(Me.txtStart.Text))
                comm.Parameters.AddWithValue("end", Server.HtmlEncode(Me.txt_end.Text))
                comm.CommandType = Data.CommandType.StoredProcedure
                odr = comm.ExecuteReader
                If odr.HasRows = False Then

                Else
                    Me.GridView1.DataSource = odr
                    Me.GridView1.DataBind()
                End If
                odr.Close()
                ocon.Close()
            ElseIf Me.RadioButtonList1.SelectedIndex = 1 Then

                comm.Connection = ocon
                ocon.Open()
                comm.CommandText = "Report_Reject"
                comm.Parameters.AddWithValue("start", Server.HtmlEncode(Me.txtStart.Text))
                comm.Parameters.AddWithValue("end", Server.HtmlEncode(Me.txt_end.Text))
                comm.CommandType = Data.CommandType.StoredProcedure
                odr = comm.ExecuteReader
                If odr.HasRows = False Then

                Else
                    Me.GridView1.DataSource = odr
                    Me.GridView1.DataBind()
                End If
                odr.Close()
                ocon.Close()
            Else

                comm.Connection = ocon
                ocon.Open()
                comm.CommandText = "Report_two"
                comm.Parameters.AddWithValue("start", Server.HtmlEncode(Me.txtStart.Text))
                comm.Parameters.AddWithValue("end", Server.HtmlEncode(Me.txt_end.Text))
                comm.CommandType = Data.CommandType.StoredProcedure
                odr = comm.ExecuteReader
                If odr.HasRows = False Then

                Else
                    Me.GridView1.DataSource = odr
                    Me.GridView1.DataBind()
                End If
                odr.Close()
                ocon.Close()
            End If


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\RejectApproveReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") = "" Then
            Response.Redirect("..\logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If

    End Sub

End Class