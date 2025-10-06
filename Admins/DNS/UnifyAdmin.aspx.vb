Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Threading
Imports Domain2021.Toastr
Imports Microsoft.Security.Application
Public Class UnifyAdmin
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

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView2.DataBind()
        If GridView2.Rows.Count >= 1 Then
            Unifydiv.Visible = True
            GridView2.Visible = True
        Else
            Unifydiv.Visible = False
            GridView2.Visible = False
        End If

    End Sub

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try


            If e.CommandName = "show" Then

                Dim PASS As String
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim AdminID As Integer = Convert.ToInt32(e.CommandArgument)
                Dim connectionstr As DAL = New DAL()
                Dim oconPass As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdPASS As New SqlClient.SqlCommand()
                Dim ODRPASS As SqlClient.SqlDataReader
                ocmdPASS.Connection = oconPASS
                oconPASS.Open()
                ocmdPASS.CommandText = "PASS"
                ocmdPASS.CommandType = CommandType.StoredProcedure
                ocmdPASS.Parameters.AddWithValue("admin_id", AdminID)
                PASS = ocmdPASS.ExecuteScalar()
                TextBox9.Text = ReusableCode.Decrypt(PASS)
                oconPASS.Close()

                Dim oconAdminData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdAdminData As New SqlClient.SqlCommand()
                ocmdAdminData.Connection = oconAdminData
                oconAdminData.Open()
                ocmdAdminData.CommandText = "select_AdminData"
                ocmdAdminData.Parameters.AddWithValue("DomainId", AdminID)
                ocmdAdminData.CommandType = CommandType.StoredProcedure
                ODRPASS = ocmdAdminData.ExecuteReader
                If ODRPASS.HasRows = True Then

                    While ODRPASS.Read
                        If Not ODRPASS("COMPANY_USER_NAME") Is DBNull.Value Then
                            txt_user_name.Text = ODRPASS("COMPANY_USER_NAME")
                        End If
                        If Not ODRPASS("ADMIN_CONTACT") Is DBNull.Value Then
                            TextBox2.Text = ODRPASS("ADMIN_CONTACT")
                        End If
                        If Not ODRPASS("mobile") Is DBNull.Value Then
                            TextBox8.Text = ODRPASS("mobile")
                        End If
                        If Not ODRPASS("fax") Is DBNull.Value Then
                            TextBox4.Text = ODRPASS("fax")
                        End If
                        If Not ODRPASS("addresses") Is DBNull.Value Then
                            TextBox6.Text = ODRPASS("addresses")
                        End If
                        If Not ODRPASS("phone") Is DBNull.Value Then
                            TextBox3.Text = ODRPASS("phone")
                        End If
                        If Not ODRPASS("email") Is DBNull.Value Then
                            TextBox5.Text = ODRPASS("email")
                        End If
                    End While
                End If

                ODRPASS.Close()
                oconAdminData.Close()
                ttab1.Visible = True

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unifyADmin:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub






    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim i As Integer = 0
            Dim i_1 As Integer = 0
            Dim EmailAdmin As String = ""
            Dim arr As ArrayList = New ArrayList
            Dim arr2 As ArrayList = New ArrayList
            Dim arr3 As ArrayList = New ArrayList
            For Each row As GridViewRow In GridView2.Rows
                Dim ck As CheckBox = CType(row.Cells(0).FindControl("CheckBox1"), CheckBox)
                If ck.Checked Then
                    arr.Add(row.Cells(1).Text)
                    arr2.Add(row.Cells(5).Text)
                    i = i + 1
                End If
            Next
            If i <= 1 Then
                ShowToastr(Page, "You have to select two domains at least", "error", "error")

            Else
                While i_1 <= arr.Count - 1

                    Dim connectionstr As DAL = New DAL()
                    Dim oconAdminID As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commAdminID As New SqlClient.SqlCommand()
                    commAdminID.Connection = oconAdminID
                    oconAdminID.Open()
                    commAdminID.CommandText = "updateAdminID"
                    commAdminID.Parameters.AddWithValue("TextBox9", Server.HtmlEncode(TextBox1.Text))
                    commAdminID.Parameters.AddWithValue("domain", arr(i_1))
                    commAdminID.CommandType = CommandType.StoredProcedure
                    commAdminID.ExecuteNonQuery()
                    oconAdminID.Close()
                    Dim oconemail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdemail As New SqlClient.SqlCommand()
                    ocmdemail.Connection = oconemail
                    oconemail.Open()
                    ocmdemail.CommandText = "select_adminID_email"
                    ocmdemail.Parameters.AddWithValue("ADMIN_ID", arr2(i_1))
                    ocmdemail.CommandType = CommandType.StoredProcedure
                    arr3.Add(ocmdemail.ExecuteScalar())
                    oconemail.Close()
                    i_1 = i_1 + 1
                End While
                Dim i2 As Integer = 0
                While i2 <= arr3.Count - 1
                    Dim Pass As String = ""
                    Dim connectionstr As DAL = New DAL()
                    Dim Subject As String = "Your Administrator Information/معلومات المسؤول الإداري"
                    Dim oconPass As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdPASS As New SqlClient.SqlCommand()
                    Dim ODRPASS As SqlClient.SqlDataReader
                    ocmdPASS.Connection = oconPASS
                    oconPASS.Open()
                    ocmdPASS.CommandText = "PASS"
                    ocmdPASS.CommandType = CommandType.StoredProcedure
                    ocmdPASS.Parameters.AddWithValue("admin_id", "")
                    Pass = ocmdPASS.ExecuteScalar()
                    Pass = ReusableCode.Decrypt(Pass)
                    oconPASS.Close()
                    Dim oconAdminData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdAdminData As New SqlClient.SqlCommand()
                    ocmdAdminData.Connection = oconAdminData
                    Dim username As String = ""
                    Dim Admin As String = ""
                    Dim mobile As String = ""
                    Dim fax As String = ""
                    Dim addresses As String = ""
                    Dim phone As String = ""
                    Dim email As String = ""
                    oconAdminData.Open()
                    ocmdAdminData.CommandText = "select_AdminData"
                    ocmdAdminData.Parameters.AddWithValue("DomainId", "")
                    ocmdAdminData.CommandType = CommandType.StoredProcedure
                    ODRPASS = ocmdAdminData.ExecuteReader
                    While ODRPASS.Read
                        If Not ODRPASS("COMPANY_USER_NAME") Is DBNull.Value Then
                            username = ODRPASS("COMPANY_USER_NAME")
                        End If
                        If Not ODRPASS("ADMIN_CONTACT") Is DBNull.Value Then
                            Admin = ODRPASS("ADMIN_CONTACT")
                        End If
                        If Not ODRPASS("mobile") Is DBNull.Value Then
                            mobile = ODRPASS("mobile")
                        End If
                        If Not ODRPASS("fax") Is DBNull.Value Then
                            fax = ODRPASS("fax")
                        End If
                        If Not ODRPASS("addresses") Is DBNull.Value Then
                            addresses = ODRPASS("addresses")
                        End If
                        If Not ODRPASS("phone") Is DBNull.Value Then
                            phone = ODRPASS("phone")
                        End If
                        If Not ODRPASS("email") Is DBNull.Value Then
                            email = ODRPASS("email")
                        End If
                    End While
                    oconAdminData.Close()
                    ODRPASS.Close()
                    ShowToastr(Page, "Updated Successfully..", "success", "success")
                    Dim msg As String
                    msg = "<table style='BORDER-COLLAPSE: collapse' cellSpacing='0' cellPadding='0'  border = '1'><tr><td>"
                    msg += "Username:</td><td>" & username & "</td></tr>"
                    msg += "<tr><td>Admin Name:</td><td>" & Admin & "</td></tr>"
                    msg += "<tr><td>Password:</td><td>" & Pass & "</td></tr>"
                    msg += "<tr><td>mobile:</td><td>" & mobile & "</td></tr>"
                    msg += "<tr><td>E-mail Address:</td><td>" & email & "</td></tr>"
                    msg += "<tr><td>Phone:</td><td>" & phone & "</td></tr>"
                    msg += "<tr><td>Fax:</td><td>" & fax & "</td></tr>"
                    msg += "<tr><td>Address:</td><td>" & addresses & "</td></tr>"
                    msg += "</table>"
                    ReusableCode.sndMail(arr3(i2), "dns@modee.gov.jo", Subject, msg)
                    i2 = i2 + 1
                End While
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\unifiyadmin:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Wrong Admin Id", "error", "error")
        End Try
    End Sub

    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
End Class