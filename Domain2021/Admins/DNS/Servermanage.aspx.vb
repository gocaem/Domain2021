Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class Servermanage
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

        End If

    End Sub


    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "view" Then
                'view all domain details
                Dim reader As SqlDataReader
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Domain_ID") = DomainID
                Dim connectionstr As DAL = New DAL()
                Dim connServerDomainData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdServerDomainData As New System.Data.SqlClient.SqlCommand("server_data_domain", connServerDomainData)
                ocmdServerDomainData.Parameters.AddWithValue("did", DomainID)
                connServerDomainData.Open()
                ocmdServerDomainData.CommandType = System.Data.CommandType.StoredProcedure
                reader = ocmdServerDomainData.ExecuteReader()
                GridView1.DataSource = reader
                GridView1.DataBind()
                connServerDomainData.Close()
                GridView1.Visible = True
                ttab1.Visible = False
                Button1.Visible = False
                reset()
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ServerManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    '
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try

            If e.CommandName = "view" Then
                reset()
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim SID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("ID") = SID
                ttab1.Visible = True
                Button1.Visible = True
                Dim reader As SqlDataReader
                Dim connectionstr As DAL = New DAL()
                Dim connServerDomainData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdServerDomainData As New System.Data.SqlClient.SqlCommand("server_data_domain", connServerDomainData)
                ocmdServerDomainData.Parameters.AddWithValue("did", Session("Domain_ID"))
                connServerDomainData.Open()
                ocmdServerDomainData.CommandType = System.Data.CommandType.StoredProcedure
                reader = ocmdServerDomainData.ExecuteReader()
                While reader.Read
                    If Not reader("P_SERVER_NAME") Is DBNull.Value Then
                        p_name.Text = reader("P_SERVER_NAME").ToString.ToLower()
                    End If
                    If Not reader("P_SERVER_IP") Is DBNull.Value Then
                        TextBox1.Text = reader("P_SERVER_IP").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME") Is DBNull.Value Then
                        TextBox2.Text = reader("S_SERVER_NAME").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP") Is DBNull.Value Then
                        TextBox3.Text = reader("S_SERVER_IP").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME2") Is DBNull.Value Then
                        TextBox4.Text = reader("S_SERVER_NAME2").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP2") Is DBNull.Value Then
                        TextBox5.Text = reader("S_SERVER_IP2").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME3") Is DBNull.Value Then
                        TextBox6.Text = reader("S_SERVER_NAME3").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP3") Is DBNull.Value Then
                        TextBox7.Text = reader("S_SERVER_IP3").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME4") Is DBNull.Value Then
                        TextBox8.Text = reader("S_SERVER_NAME4").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP4") Is DBNull.Value Then
                        TextBox9.Text = reader("S_SERVER_IP4").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME5") Is DBNull.Value Then
                        TextBox10.Text = reader("S_SERVER_NAME5").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP5") Is DBNull.Value Then
                        TextBox11.Text = reader("S_SERVER_IP5").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME6") Is DBNull.Value Then
                        TextBox12.Text = reader("S_SERVER_NAME6").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP6") Is DBNull.Value Then
                        TextBox13.Text = reader("S_SERVER_IP6").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME7") Is DBNull.Value Then
                        TextBox14.Text = reader("S_SERVER_NAME7").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP7") Is DBNull.Value Then
                        TextBox15.Text = reader("S_SERVER_IP7").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                        TextBox16.Text = reader("S_SERVER_NAME8").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                        TextBox17.Text = reader("S_SERVER_IP8").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME9") Is DBNull.Value Then
                        TextBox18.Text = reader("S_SERVER_NAME9").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP9") Is DBNull.Value Then
                        TextBox19.Text = reader("S_SERVER_IP9").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_NAME10") Is DBNull.Value Then
                        TextBox20.Text = reader("S_SERVER_NAME10").ToString.ToLower()
                    End If
                    If Not reader("S_SERVER_IP10") Is DBNull.Value Then
                        TextBox21.Text = reader("S_SERVER_IP10").ToString.ToLower()
                    End If

                End While
                connServerDomainData.Close()
                reader.Close()
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ServerManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim connserver As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commserver As New Data.SqlClient.SqlCommand
        Try
            connserver.Open()
            commserver.Connection = connserver
            commserver.CommandType = CommandType.StoredProcedure
            commserver.CommandText = "checkserver"
            commserver.Parameters.AddWithValue("p_n", p_name.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n", TextBox2.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip", TextBox3.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("p_ip", TextBox1.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n3", TextBox6.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip3", TextBox7.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n4", TextBox8.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip4", TextBox9.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n5", TextBox10.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip5", TextBox11.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n6", TextBox12.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip6", TextBox13.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n7", TextBox14.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip7", TextBox15.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n8", TextBox16.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip8", TextBox17.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n9", TextBox18.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip9", TextBox19.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n10", TextBox20.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip10", TextBox21.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_n1", TextBox4.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("s_ip1", TextBox5.Text.ToString.ToLower)
            commserver.Parameters.AddWithValue("did", Session("Domain_ID"))
            commserver.Parameters.AddWithValue("current_id", Session("ID"))
            commserver.Parameters.Add("id", SqlDbType.Int)
            commserver.Parameters("id").Direction = ParameterDirection.Output
            commserver.ExecuteNonQuery()
            GridView1.DataBind()
            tablist.Visible = False
            ShowToastr(Page, "Updated Successfully..", "Done", "success")

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ServerManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
        connserver.Close()
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

    Sub reset()
        p_name.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView2.Visible = True
    End Sub


End Class