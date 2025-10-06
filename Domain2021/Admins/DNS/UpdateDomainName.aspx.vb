Imports System.IO
Imports System.Threading

Public Class UpdateDomainName
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
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "view" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Domain_ID") = DomainID
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('DomDetails.aspx');", True)
            ElseIf e.CommandName = "edit1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Session("Domain_ID") = row.Cells(3).Text
                div1.Visible = True
                div2.Visible = True
                TextLbl.Text = row.Cells(0).Text
                Session("Domain_name") = row.Cells(10).Text
                Session("Second_domain_id") = row.Cells(9).Text
                Button1.Visible = True
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\updatedomainname:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView2.DataBind()
        GridView2.Visible = True
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "view" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = row.Cells(3).Text
                Session("Domain_ID") = DomainID
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('DomDetails.aspx');", True)
            ElseIf e.CommandName = "edit1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Domain_ID") = DomainID
                div1.Visible = True
                div2.Visible = True
                TextLbl.Text = row.Cells(0).Text
                Button1.Visible = True
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\updatedomainname:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        GridView1.DataBind()
        GridView1.Visible = True
        Button2.Visible = True
        div2.Visible = True
        If GridView1.Rows.Count = 0 Then
            Label1.Visible = True
            Label1.Text = "No Domains matched with the new domain name"
        Else
            Label1.Visible = True
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Try
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\updatedomainname:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
            ocmd.CommandText = "update_DomainName"
            ocmd.Parameters.AddWithValue("@oldsec", Session("Second_domain_id"))
            ocmd.Parameters.AddWithValue("@sec", DropDownList2.SelectedValue)
            ocmd.Parameters.AddWithValue("@d_id", Session("Domain_ID"))
            ocmd.Parameters.AddWithValue("@domainName", TextBox2.Text)
            ocmd.Parameters.AddWithValue("@OldDomainName", Session("Domain_name"))
            ocmd.Parameters.AddWithValue("@IPadd", ReusableCode.GetIPAddress)
            ocmd.Parameters.AddWithValue("@UserId", Session("Users_ID"))
            ocmd.CommandType = Data.CommandType.StoredProcedure
            ocmd.Connection = ocon
            ocon.Open()
            ocmd.ExecuteNonQuery()
            ocon.Close()
            ShowToastr(Page, "Updated successfully", "Updated successfully", "success")
            lblupdate.Text = "Updated successfully"
            Button4.Visible = False
            GridView2.DataBind()
            lblupdate.ForeColor = Drawing.Color.Green
            lblupdate.Font.Bold = True
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\updatedomainname:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
End Class