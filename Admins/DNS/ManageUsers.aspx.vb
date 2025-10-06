Imports System.Net
Imports Newtonsoft.Json
Imports System.Configuration.ConfigurationManager
Imports Microsoft.Security.Application
Imports System.Security.Cryptography
Imports System.IO
Imports System.Threading

Public Class ManageUsers
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
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "details" Then

            Dim selectedRow As GridViewRow = CType(((CType(e.CommandSource, Control)).NamingContainer), GridViewRow)

            'Fetch values from BoundField columns.
            Label2.Visible = False
            Label2.Text = selectedRow.Cells(0).Text
            TextBox1.Text = selectedRow.Cells(4).Text
            CheckBox2.Checked = Convert.ToBoolean(selectedRow.Cells(2).Text)
            DropDownList2.SelectedValue = selectedRow.Cells(3).Text
            TextBox4.Text = selectedRow.Cells(1).Text
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try

            Dim value As Boolean
            If (CheckBox1.Checked = True) Then
                value = 1
            Else
                value = 0
            End If
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand("Register", conn)
            conn.Open()
            ocmd.CommandType = CommandType.StoredProcedure
            ocmd.Parameters.AddWithValue("USER_Type", Server.HtmlEncode(TextBox2.Text))
            ocmd.Parameters.AddWithValue("USER_Email", Server.HtmlEncode(TextBox3.Text))
            ocmd.Parameters.AddWithValue("USER_names", Server.HtmlEncode(TextBox2.Text))
            ocmd.Parameters.AddWithValue("USER_Disabled", value)
            ocmd.Parameters.AddWithValue("USER_Role", DropDownList1.SelectedValue)
            ocmd.Parameters.Add("Message", SqlDbType.VarChar, 200)
            ocmd.Parameters("Message").Direction = ParameterDirection.Output
            ocmd.ExecuteNonQuery()
            conn.Close()
            result.Visible = True
            result.Text = Convert.ToString(ocmd.Parameters("Message").Value)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ManageUser:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            result.Visible = True
            result.Text = "Exception Found"
        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Try

            Dim value As Boolean
            If (CheckBox2.Checked = True) Then
                value = 1
            Else
                value = 0
            End If
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand("update_user", conn)
            conn.Open()
            ocmd.CommandType = CommandType.StoredProcedure
            ocmd.Parameters.AddWithValue("User_id", Label2.Text)
            ocmd.Parameters.AddWithValue("USER_Email", Server.HtmlEncode(TextBox4.Text))
            ocmd.Parameters.AddWithValue("USER_Disabled", value)
            ocmd.Parameters.AddWithValue("USER_Role", DropDownList2.SelectedValue)
            ocmd.Parameters.Add("Message", SqlDbType.VarChar, 200)
            ocmd.Parameters("Message").Direction = ParameterDirection.Output
            ocmd.ExecuteNonQuery()
            conn.Close()
            GridView1.DataBind()
            Label2.Visible = True
            Label2.Text = Convert.ToString(ocmd.Parameters("Message").Value)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ManageUser:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            Label2.Visible = True
            Label2.Text = "Exception Found"
        End Try

    End Sub

    Protected Sub lk1_Click(sender As Object, e As EventArgs) Handles lk1.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid().ToString(), "openModal2();", True)

    End Sub
End Class