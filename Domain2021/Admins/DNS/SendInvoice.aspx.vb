Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports System.Threading

Public Class SendInvoice
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        If Page.IsPostBack = False Then
            AddYears(1955)
            Years.SelectedValue = Now.Year
        End If

    End Sub

    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub LK2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub AddYears(Optional startYear As Integer = 1955)

        Dim currentYear = Date.Now.Year + 200

        For i = startYear To currentYear
            Years.Items.Add(New ListItem(Convert.ToString(i)))
        Next
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        Try


            Dim row As GridViewRow

            For Each row In GridView2.Rows
                If CType(row.Cells.Item(3).FindControl("biling"), CheckBox).Checked = True Then
                    If (LangFlag.SelectedValue = 1) Then

                        ReusableCode.sndMail(CType(row.Cells.Item(3).FindControl("biling"), CheckBox).Text, "dns@modee.gov.jo", row.Cells.Item(6).Text & "مطالبة مالية للنطاق", text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))
                    Else
                        ReusableCode.sndMail(CType(row.Cells.Item(3).FindControl("biling"), CheckBox).Text, "dns@modee.gov.jo", "Financial Invoice for Domain Name  " & row.Cells.Item(6).Text, text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))

                    End If
                End If
                If CType(row.Cells.Item(4).FindControl("admin"), CheckBox).Checked = True Then
                    If (LangFlag.SelectedValue = 1) Then
                        ReusableCode.sndMail(CType(row.Cells.Item(4).FindControl("admin"), CheckBox).Text, "dns@modee.gov.jo", row.Cells.Item(6).Text & "مطالبة مالية للنطاق", text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))
                    Else
                        ReusableCode.sndMail(CType(row.Cells.Item(4).FindControl("admin"), CheckBox).Text, "dns@modee.gov.jo", "Financial Invoice for Domain Name  " & row.Cells.Item(6).Text, text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))
                    End If
                End If
                If CType(row.Cells.Item(5).FindControl("org"), CheckBox).Checked = True Then
                    If (LangFlag.SelectedValue = 1) Then
                        ReusableCode.sndMail(CType(row.Cells.Item(5).FindControl("org"), CheckBox).Text, "dns@modee.gov.jo", row.Cells.Item(6).Text & "مطالبة مالية للنطاق", text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))
                    Else
                        ReusableCode.sndMail(CType(row.Cells.Item(5).FindControl("org"), CheckBox).Text, "dns@modee.gov.jo", "Financial Invoice for Domain Name  " & row.Cells.Item(6).Text, text_msg(row.Cells.Item(7).Text, row.Cells.Item(8).Text, row.Cells.Item(6).Text, row.Cells.Item(9).Text, row.Cells.Item(10).Text))

                    End If
                End If
            Next
            GridView2.AllowPaging = True
            gridbind()
            ShowToastr(Page, "Updated Sucessfully", "Done!", "success")

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SendInvoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Sub gridbind()
        Try


            Dim connectionstr As DAL = New DAL()
            Dim connExpired As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commExpired As New System.Data.SqlClient.SqlCommand("send_financial_invoices", connExpired)
            commExpired.Parameters.AddWithValue("end_date", ddl2.SelectedValue)
            commExpired.Parameters.AddWithValue("date", Years.SelectedValue)
            connExpired.Open()
            commExpired.CommandType = System.Data.CommandType.StoredProcedure
            Dim da As SqlDataAdapter = New SqlDataAdapter(commExpired)
            Dim ds As New DataSet
            da.Fill(ds)
            commExpired.ExecuteNonQuery()
            GridView2.DataSource = ds
            GridView2.DataBind()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SendInvoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Protected Sub LK_Click(sender As Object, e As EventArgs)
        gridbind()
    End Sub
    Public Function text_msg(ByVal strEndDate As String, ByVal strRenewFees As String, ByVal strDomainName As String, ByVal strRenewFeesUSD As String, ByVal admin_id As String) As String
        Try


            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New SqlClient.SqlCommand
            Dim reader As SqlClient.SqlDataReader
            Dim messageBody As String = ""
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "SelectEmailTextID"
            comm.Parameters.Clear()
            If (LangFlag.SelectedValue = 1) Then
                comm.Parameters.AddWithValue("id", 34)
            Else
                comm.Parameters.AddWithValue("id", 33)
            End If
            comm.CommandType = CommandType.StoredProcedure
            reader = comm.ExecuteReader()
            While reader.Read
                If (LangFlag.SelectedValue = 1) Then
                    messageBody = reader.Item("part1") & " (" & strDomainName & " )" & reader.Item("part2") & "( " & strEndDate & " )" & reader.Item("part3") & "( " & strRenewFees & " )" & reader.Item("part4") & "( " & admin_id & " )" & reader.Item("part5") & reader.Item("part6") & reader.Item("footer")

                Else
                    messageBody = reader.Item("part1") & " (" & strDomainName & " )" & reader.Item("part2") & "( " & strEndDate & " )" & reader.Item("part3") & "( " & strRenewFees & " JD )" & " " & " (" & strRenewFeesUSD & "USD  ) " & reader.Item("part4") & "( " & admin_id & " )" & reader.Item("part5") & reader.Item("part6") & reader.Item("footer")

                End If
            End While
            strDomainName = ""
            strEndDate = ""
            reader.Close()
            conn.Close()

            Return messageBody
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SendInvoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Function
    Protected Sub Select_CheckedChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow

        For Each row In GridView2.Rows
            Dim chck As CheckBox = CType(row.Cells.Item(1).FindControl("Select1"), CheckBox)
            If chck.Checked Then
                CType(row.Cells.Item(2).FindControl("biling"), CheckBox).Checked = True
                CType(row.Cells.Item(3).FindControl("admin"), CheckBox).Checked = True
                CType(row.Cells.Item(4).FindControl("org"), CheckBox).Checked = True
            Else
                CType(row.Cells.Item(2).FindControl("biling"), CheckBox).Checked = False
                CType(row.Cells.Item(3).FindControl("admin"), CheckBox).Checked = False
                CType(row.Cells.Item(4).FindControl("org"), CheckBox).Checked = False
            End If
        Next

    End Sub

    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        gridbind()
    End Sub
End Class