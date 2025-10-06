Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading
Imports Microsoft.Security.Application
Public Class AdminManagement
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


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txt_admin_id.Text = "" Then
            lbl_error.Text = "Enter admin id"
        Else
            Try
                Dim connectionstr As DAL = New DAL()
                Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd2 As New SqlClient.SqlCommand()
                Dim reader As SqlClient.SqlDataReader
                ocmd2.Connection = ocon2
                ocon2.Open()
                ocmd2.CommandText = "PASS"
                ocmd2.CommandType = CommandType.StoredProcedure
                ocmd2.Parameters.AddWithValue("admin_id", Server.HtmlEncode(txt_admin_id.Text))
                reader = ocmd2.ExecuteReader()
                If reader.HasRows = True Then
                    Me.panel1.Visible = True
                    Button1.Visible = True
                    result.Text = ""
                    While reader.Read
                        username.Text = reader("Company_user_name")
                        Session("COMPANY_USER_NAME") = reader("Company_user_name")
                        Mobile.Text = reader("Mobile")
                        Session("ad_mobile") = reader("Mobile")
                        Email.Text = reader("Email")
                        Session("EMAIL") = reader("Email")
                        Name.Text = reader("ADMIN_CONTACT")
                        Session("ADMIN_CONTACT") = reader("ADMIN_CONTACT")

                    End While
                Else
                    Me.panel1.Visible = False
                    Button1.Visible = False
                End If

                ocon2.Close()

            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\AdminManagement:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
            End Try

        End If

    End Sub







    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim connectionstr As DAL = New DAL()
            Dim oconADMIN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmdADNIN As New SqlClient.SqlCommand()
            ocmdADNIN.Connection = oconADMIN
            oconADMIN.Open()
            ocmdADNIN.CommandText = "update_adminData_foradmin"
            ocmdADNIN.CommandType = CommandType.StoredProcedure
            ocmdADNIN.Parameters.AddWithValue("company_user_name", Server.HtmlEncode(username.Text))
            ocmdADNIN.Parameters.AddWithValue("Userid", Session("Users_ID"))
            ocmdADNIN.Parameters.AddWithValue("oldcompany_user_name", Server.HtmlEncode(Session("COMPANY_USER_NAME")))
            ocmdADNIN.Parameters.AddWithValue("admin_contact", Server.HtmlEncode(Session("ADMIN_CONTACT")))
            ocmdADNIN.Parameters.AddWithValue("newadmin_contact", Server.HtmlEncode(Name.Text))
            ocmdADNIN.Parameters.AddWithValue("IPaddress", ReusableCode.GetIPAddress)
            ocmdADNIN.Parameters.AddWithValue("mobile", Server.HtmlEncode(Session("ad_mobile")))
            ocmdADNIN.Parameters.AddWithValue("newmobile", Server.HtmlEncode(Mobile.Text))
            ocmdADNIN.Parameters.AddWithValue("email", Server.HtmlEncode(Session("EMAIL")))
            ocmdADNIN.Parameters.AddWithValue("newemail", Server.HtmlEncode(Email.Text))
            ocmdADNIN.Parameters.AddWithValue("admin_id", Server.HtmlEncode(txt_admin_id.Text))
            ocmdADNIN.ExecuteNonQuery()

            ShowToastr(Page, "Updated Successfully..", "Done", "success")
        Catch ex As Exception
            ShowToastr(Page, "error...", "error", "error")
        End Try


    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
End Class