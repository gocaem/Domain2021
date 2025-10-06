Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Threading

Public Class ApproveUpdate
    Inherits System.Web.UI.Page
    Dim i As Integer = 0
    Dim EEmail As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If

        dg.Columns("5").Visible = False
        Try

            Dim connectionstr As DAL = New DAL()
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd2 As New Data.SqlClient.SqlCommand
            ocmd2.CommandText = "AutoDelete"
            ocmd2.CommandType = Data.CommandType.StoredProcedure
            ocmd2.Connection = ocon2
            ocon2.Open()
            ocmd2.ExecuteNonQuery()
            ocon2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ApproveUpdates:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
        If Not Page.IsPostBack Then
            filladatagrid()
        End If

    End Sub


    Sub filladatagrid()
        Try

            Dim connectionstr As DAL = New DAL()
            Dim oconUpdates As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmdUpdates As New Data.SqlClient.SqlCommand
            Dim odrUpdates As Data.SqlClient.SqlDataReader
            ocmdUpdates.CommandText = "approve_adminUpdate"
            ocmdUpdates.CommandType = Data.CommandType.StoredProcedure
            ocmdUpdates.Connection = oconUpdates
            oconUpdates.Open()
            odrUpdates = ocmdUpdates.ExecuteReader
            Me.dg.DataSource = odrUpdates
            Me.dg.DataBind()
            oconUpdates.Close()
            odrUpdates.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ApproveUpdates:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub dg_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg.ItemCommand
        Dim redEmail As Data.SqlClient.SqlDataReader
        If e.CommandName = "NotApprove" Then
            If i = 0 Then
                i = i + 1

                DomainID.Text = e.Item.Cells(5).Text

                Dim connectionstr As DAL = New DAL()
                Dim connStatus As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim commStatus As New SqlCommand

                Try
                    ''-----------------Updating Status----------
                    connStatus.Open()
                    commStatus.Connection = connStatus
                    commStatus.CommandText = "update_statusCancel"
                    commStatus.Parameters.AddWithValue("st", 8)
                    commStatus.Parameters.AddWithValue("did", e.Item.Cells(5).Text)
                    commStatus.CommandType = Data.CommandType.StoredProcedure
                    commStatus.ExecuteNonQuery()
                    connStatus.Close()
                    result.Text = "Update Canceled successfully"
                    filladatagrid()
                    Dim LangFlag, recipant_email, mob, recipant_name, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, message_body As String
                    Dim connEmail2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commEmail2 As New SqlCommand
                    connEmail2.Open()
                    commEmail2.Connection = connEmail2
                    commEmail2.CommandText = "send_admin_EMail"
                    commEmail2.CommandType = Data.CommandType.StoredProcedure
                    commEmail2.Parameters.AddWithValue("domain_id", e.Item.Cells(5).Text)
                    Dim redEmail2 As Data.SqlClient.SqlDataReader
                    redEmail2 = commEmail2.ExecuteReader()
                    While redEmail2.Read
                        recipant_email = redEmail2.Item("EMAIL")
                        EEmail = recipant_email
                        recipant_name = redEmail2.Item("COMPANY_USER_NAME")
                        OWNER_NAME = redEmail2.Item("OWNER_NAME")
                        DOMAIN_NAME = redEmail2.Item("DOMAIN_NAME")
                        SECOND_DOMAIN = redEmail2.Item("SECOND_DOMAIN")
                        LangFlag = redEmail2.Item("LangFlag")
                        mob = redEmail2.Item("mobile")
                    End While
                    redEmail2.Close()
                    connEmail2.Close()

                    Dim connEmailText As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commEmailText As New SqlCommand
                    connEmailText.Open()
                    commEmailText.Connection = connEmailText
                    commEmailText.CommandText = "SelectEmailTextID"
                    If (LangFlag.Contains("en")) Then
                        commEmailText.Parameters.AddWithValue("id", 14)
                        Subject = "Update Request Rejected" & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
                    Else
                        commEmailText.Parameters.AddWithValue("id", 3)
                        Subject = "رفض التعديلات " & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"
                    End If
                    commEmailText.CommandType = Data.CommandType.StoredProcedure
                    redEmail = commEmailText.ExecuteReader()
                    redEmail.Read()
                    message_body = Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(redEmail("part1")))
                    message_body += Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(redEmail("footer")))

                    modee_email = "dns@modee.gov.jo"
                    ReusableCode.sndMail(EEmail, modee_email, Subject, message_body)
                    redEmail.Close()
                    connEmailText.Close()

                    Dim oconUpdates As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdUpdates As New Data.SqlClient.SqlCommand
                    Dim odrUpdates As Data.SqlClient.SqlDataReader
                    ocmdUpdates.CommandText = "approve_adminUpdate"
                    ocmdUpdates.CommandType = Data.CommandType.StoredProcedure
                    ocmdUpdates.Connection = oconUpdates
                    oconUpdates.Open()
                    odrUpdates = ocmdUpdates.ExecuteReader
                    Me.dg.DataSource = odrUpdates
                    Me.dg.DataBind()
                    oconUpdates.Close()
                    odrUpdates.Close()
                Catch ex As Exception
                    If Not (TypeOf ex Is ThreadAbortException) Then
                        File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ApproveUpdates:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                    End If
                End Try
            End If
        ElseIf e.CommandName = "Approve" Then

            If i = 0 Then
                i = i + 1
                Try
                    Dim connectionstr As DAL = New DAL()
                    Dim commApplyUpdate As New Data.SqlClient.SqlCommand
                    Dim connApplyUpdate As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    connApplyUpdate.Open()
                    commApplyUpdate.Connection = connApplyUpdate
                    commApplyUpdate.CommandText = "applyUpdates"
                    commApplyUpdate.Parameters.AddWithValue("did", e.Item.Cells(5).Text)
                    commApplyUpdate.CommandType = Data.CommandType.StoredProcedure
                    commApplyUpdate.ExecuteNonQuery()
                    connApplyUpdate.Close()
                    Dim commStatus As New Data.SqlClient.SqlCommand
                    Dim connStatus As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    connStatus.Open()
                    commStatus.Connection = connStatus
                    commStatus.CommandText = "update_statusapprove"
                    commStatus.Parameters.AddWithValue("did", e.Item.Cells(5).Text)
                    commStatus.CommandType = Data.CommandType.StoredProcedure
                    commStatus.ExecuteNonQuery()
                    connStatus.Close()
                    result.Text = "Update Confirmed successfully"
                    filladatagrid()
                    Dim connEmail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commEmail As New SqlCommand
                    Dim LangFlag, recipant_email, mob, recipant_name, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, message_body As String
                    connEmail.Open()
                    commEmail.Connection = connEmail
                    commEmail.CommandText = "send_admin_EMail"
                    commEmail.CommandType = Data.CommandType.StoredProcedure
                    commEmail.Parameters.AddWithValue("DOMAIN_ID ", e.Item.Cells(5).Text)

                    redEmail = commEmail.ExecuteReader()
                    While redEmail.Read
                        recipant_email = redEmail.Item("EMAIL")
                        EEmail = recipant_email
                        recipant_name = redEmail.Item("COMPANY_USER_NAME")
                        OWNER_NAME = redEmail.Item("OWNER_NAME")
                        DOMAIN_NAME = redEmail.Item("DOMAIN_NAME")
                        SECOND_DOMAIN = redEmail.Item("SECOND_DOMAIN")
                        LangFlag = redEmail.Item("LangFlag")
                        mob = redEmail.Item("mobile")
                    End While
                    connEmail.Close()
                    redEmail.Close()

                    Dim connEmailText As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commEmailText As New SqlCommand
                    connEmailText.Open()
                    commEmailText.Connection = connEmailText
                    commEmailText.CommandText = "SelectEmailTextID"
                    If (LangFlag.Contains("ar")) Then
                        commEmailText.Parameters.AddWithValue("id", 2)
                        Subject = "تطبيق التعديلات للنطاق" & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"

                    Else
                        commEmailText.Parameters.AddWithValue("id", 15)
                        Subject = "Update Request Applied " & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")"

                    End If
                    commEmailText.CommandType = Data.CommandType.StoredProcedure
                    redEmail = commEmailText.ExecuteReader()
                    redEmail.Read()
                    message_body = redEmail("part1")
                    message_body += redEmail("footer")
                    modee_email = "dns@modee.gov.jo"
                    ReusableCode.sndMail(EEmail, modee_email, Subject, message_body)
                    redEmail.Close()
                    connEmailText.Close()

                Catch ex As Exception
                    If Not (TypeOf ex Is ThreadAbortException) Then
                        File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\ApproveUpdates:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                    End If
                End Try
            End If
        ElseIf e.CommandName = "Compare" Then
            Session("DID") = e.Item.Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('domainsdetalesOriginal.aspx');", True)
        End If

    End Sub





End Class
