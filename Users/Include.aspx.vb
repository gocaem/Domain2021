Imports System.Data
Imports System
Imports System.Net.Mail
Imports Domain2021.Toastr
Imports Microsoft.Security.Application
Imports System.Threading
Imports System.IO

Public Class Include
    Inherits System.Web.UI.Page
    Protected Sub btn_U_update_Click(sender As Object, e As EventArgs) Handles Button11.Click
        lbl_error.Text = ""
        Dim lang As New Languages(Session("lang"))
        lbl_Result.Text = ""
        If DomainnamesText.Text = "" Then
            lbl_error.Text = lang.youhave

        ElseIf (Validation.validate_experssion(DomainnamesText.Text)) Then
            lbl_error.Text = lang.validexp
        Else
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim comm1 As New Data.SqlClient.SqlCommand
            Dim comm2 As New Data.SqlClient.SqlCommand
            Try
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "insert_others"
                comm.Parameters.AddWithValue("did", Session("User_ID"))
                comm.Parameters.AddWithValue("other", Server.HtmlEncode(DomainnamesText.Text))
                comm.Parameters.AddWithValue("req", Now)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.Add("Msg", SqlDbType.VarChar, 200)
                comm.Parameters("Msg").Direction = ParameterDirection.Output
                comm.ExecuteNonQuery()
                conn.Close()
                Session("result") = Convert.ToString(comm.Parameters("Msg").Value)
                send_account_4_approve(Session("User_ID"))
                Toastr.ShowToast(Me, ToastType.Success, lang.recieved, lang.recieved, ToastPosition.TopCenter)
                If Session("result") = "1" Then
                    lbl_Result.Text = lang.recieved
                Else
                    lbl_Result.Text = lang.DomainNotinDB
                End If


            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Include:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                conn.Close()
                lbl_error.Text = lang.EError
                Toastr.ShowToast(Me, ToastType.Error, lang.errsendemail, lang.EError, ToastPosition.TopCenter)

            End Try

        End If
    End Sub

    Private Function send_account_4_approve(ByVal user_id As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim recipant_email, recipant_name, nitc_m, Subject, USER_PASSWORD, message_body As String
        Dim DOMAIN_NAME(), OWNER_NAME(), SECOND_DOMAIN() As String

        Dim i As Integer
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "get_admin_domain_data"
            comm.Parameters.AddWithValue("admin", user_id)
            comm.CommandType = CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                recipant_name = red1.Item("COMPANY_USER_NAME")
                ReDim Preserve OWNER_NAME(i)
                ReDim Preserve DOMAIN_NAME(i)
                ReDim Preserve SECOND_DOMAIN(i)
                OWNER_NAME(i) = red1.Item("ORG_NAME")
                DOMAIN_NAME(i) = red1.Item("DOMAIN_NAME")
                SECOND_DOMAIN(i) = red1.Item("SECOND_DOMAIN")
                i += 1
            End While
            red1.Close()
            conn.Close()
            Dim lang As New Languages(Session("lang"))
            Subject = lang.adddomain
            message_body = "<p dir=" & lang.dir & ">"
            message_body += "<b> " & lang.ownerd & " </b>" & OWNER_NAME(0) & "<br>"
            message_body += "<b>" & lang.UserId & " </b>" & user_id & "<br>"
            message_body += "<b>" & lang.Username & " </b>" & recipant_name & "<br>"
            message_body += "<b>" & lang.Email & " </b>" & Server.HtmlEncode(EmailText.Text) & "<br>"
            message_body += "<br><br><br><u><b> " & lang.PleaseDomain & "</b></u><br>"
            message_body += "<i>'" & Server.HtmlEncode(DomainnamesText.Text) & "'</i><br></p>"


            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail("DNS@modee.GOV.JO", "dns@modee.gov.jo", Subject, message_body)
            send_account_4_approve = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Include:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            conn.Close()
            Toastr.ShowToast(Me, ToastType.Error, lang.errsendemail, lang.EError, ToastPosition.TopCenter)

        End Try

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Session("page") = "Include"
        Dim lang As New Languages(Session("lang"))
        post_job.Style.Add("text-align", lang.right)
        post_job.Style.Add("direction", lang.dir)
        post_job.Style.Add("Font-Family", lang.fonta)
        post_job.Style.Add("Font-size", "15px")
        post_job.Style.Add("font-weight", "bold")
        Button11.Text = lang.include2
        RequiredFieldValidator1.Text = lang.RequiredField2
        RequiredFieldValidator2.Text = lang.RequiredField2
        RegularExpressionValidator1.Text = lang.InvalidEmail
        HLabel1.InnerText = lang.include2
        DomainName.InnerText = lang.DomainName
        Email.Style.Add("text-align", lang.right)
        Email.Style.Add("direction", lang.dir)
        Email.Style.Add("Font-Family", lang.fonta)
        Email.Style.Add("Font-size", "15px")
        DomainName.Style.Add("text-align", lang.right)
        DomainName.Style.Add("direction", lang.dir)
        DomainName.Style.Add("Font-Family", lang.fonta)
        DomainName.Style.Add("Font-size", "15px")
        DomainName.Style.Add("font-weight", "bold")
        DomainName.Style.Add("font-weight", "bold")
        Email.InnerText = lang.Email

        If Page.IsPostBack = False Then
            welcome_fun()
        End If
    End Sub
    Private Sub welcome_fun()
        Try


            Dim lang As New Languages(Session("lang"))
            Dim ODR As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm2 As New Data.SqlClient.SqlCommand("welcome", conn2)
            comm2.CommandType = CommandType.StoredProcedure
            comm2.Parameters.AddWithValue("user_id", Session("User_ID"))
            conn2.Open()
            ODR = comm2.ExecuteReader()
            While ODR.Read
                If Not ODR("ADMIN_CONTACT") Is DBNull.Value Then
                    Session("ADMIN_CONTACT") = ODR("ADMIN_CONTACT")
                    Session("mob") = ODR("MOBILE")
                    Session("Email") = ODR("Email")
                End If
            End While
            ODR.Close()
            conn2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Include:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub


    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub


End Class