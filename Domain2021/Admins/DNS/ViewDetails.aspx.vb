Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Threading
Imports Microsoft.Security.Application
Public Class ViewDetails
    Inherits System.Web.UI.Page
    Dim Dom_id As Integer
    Dim CC_BillingEmail As String
    Dim strRenewFees, strRenewFeesUSD As String
    Dim strDomainName As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("dID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If

        rbl_onhold.Visible = False

        If Not Page.IsPostBack Then
            rbl_SECOND_DOMAIN.DataBind()
            rbl_about_doc.DataBind()
            rbl_about_doc.SelectedIndex = 1
            rbl_email_titel.DataBind()

            fill_db(Session("dID"))

        End If

        Try
            Dim connectionstr As DAL = New DAL()
            Dim ocon_UploadedFiles As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM_UploadedFiles As New Data.SqlClient.SqlCommand
            Dim odr_UploadedFiles As Data.SqlClient.SqlDataReader
            COMM_UploadedFiles.Connection = ocon_UploadedFiles
            ocon_UploadedFiles.Open()
            COMM_UploadedFiles.CommandText = "up_file"
            Dom_id = Session("dID")
            COMM_UploadedFiles.Parameters.AddWithValue("did", Dom_id)
            COMM_UploadedFiles.CommandType = Data.CommandType.StoredProcedure
            odr_UploadedFiles = COMM_UploadedFiles.ExecuteReader
            Me.UploadedFiles.DataSource = odr_UploadedFiles
            UploadedFiles.DataBind()
            ocon_UploadedFiles.Close()
            odr_UploadedFiles.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
        End Try




    End Sub
    Private Sub enabled_acc()
        txt_DOMAIN_NAME.Enabled = False
        rbl_SECOND_DOMAIN.Enabled = False
        txt_PRIMARY_NAMESERVER.Enabled = False
        txt_PRIMARY_IP_ADDRESS.Enabled = False
        txt_SECONDARY_NAMESERVER.Enabled = False
        txt_SECONDARY_IP_ADDRESS.Enabled = False
        TXT_ORG_NAME.Enabled = False
        txt_org_mobile.Enabled = False
        txt_ORG_EMAIL.Enabled = False
        txt_AUTHORIZED_NAME.Enabled = False
        txt_OWNER_NAME.Enabled = False
        txt_reg_date.Enabled = False
        rbl_IMMEDIATE_FUTURE.Enabled = False
        txt_COMPANY_USER_NAME.Enabled = False
        txt_ADMIN_CONTACT.Enabled = False
        txt_EMAIL.Enabled = False
        txt_TECH_CONTACT.Enabled = False
        txt_tech_mobile.Enabled = False
        txt_tech_EMAIL.Enabled = False
        txt_BILLING_CONTACT.Enabled = False
        txt_billing_mobile.Enabled = False
        txt_billing_EMAIL.Enabled = False
        rbl_Approved.Enabled = True
        rbl_about_doc.Enabled = True
        rbl_onhold.Enabled = True
        TXT_FIRST_COMMIT.Enabled = True

    End Sub
    Private Sub fill_db(ByVal Dom_id As Integer)
        Try

            Dim ocmd_det As New Data.SqlClient.SqlCommand
            Dim connectionstr As DAL = New DAL()
            Dim conn_det As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim odr_det As Data.SqlClient.SqlDataReader
            ocmd_det.Connection = conn_det
            ocmd_det.CommandText = "domain_detales"
            ocmd_det.Parameters.AddWithValue("domain_id", Dom_id)
            ocmd_det.CommandType = Data.CommandType.StoredProcedure
            conn_det.Open()
            odr_det = ocmd_det.ExecuteReader
            While odr_det.Read
                If Not odr_det("company_user_name") Is DBNull.Value Then
                    txt_COMPANY_USER_NAME.Text = odr_det("COMPANY_USER_NAME")
                End If
                If Not odr_det("ADMIN_CONTACT") Is DBNull.Value Then
                    txt_ADMIN_CONTACT.Text = odr_det("ADMIN_CONTACT")
                End If
                If Not odr_det("EMAIL") Is DBNull.Value Then
                    txt_EMAIL.Text = odr_det("EMAIL")
                End If
                If Not odr_det("EMAIL") Is DBNull.Value Then
                    hl_mailto1.NavigateUrl = "Mailto:" + odr_det("EMAIL")
                End If
                If Not odr_det("ad_mobile") Is DBNull.Value Then
                    txt_admin_mobile.Text = odr_det("ad_mobile")
                End If

                If Not odr_det("DOMAIN_NAME") Is DBNull.Value Then
                    txt_DOMAIN_NAME.Text = odr_det("DOMAIN_NAME")
                End If
                If Not odr_det("SECOND_DOMAIN_ID") Is DBNull.Value Then
                    rbl_SECOND_DOMAIN.SelectedValue = CInt(odr_det("SECOND_DOMAIN_ID"))
                End If
                If Not odr_det("SECOND_DOMAIN_ID") Is DBNull.Value Then
                    rbl_SECOND_DOMAIN.SelectedValue = CInt(odr_det("SECOND_DOMAIN_ID"))
                End If
                If Not odr_det("classid") Is DBNull.Value Then
                    classify.SelectedValue = odr_det("classid")
                End If
                If Not odr_det("ORG_EMAIL") Is DBNull.Value Then
                    txt_ORG_EMAIL.Text = odr_det("ORG_EMAIL")
                End If
                If Not odr_det("Description") Is DBNull.Value Then
                    Description.Text = odr_det("Description")
                End If
                Dim lang As New Languages("en")
                If Not odr_det("Nationalno") Is DBNull.Value Then
                    NationalNo.Text = odr_det("Nationalno")
                    Try

                        Dim RS As ServiceReference1.CentralRegistration = New ServiceReference1.CentralRegistration()
                        Dim TM() As ServiceReference1.TradeMark
                        Dim client As ServiceReference1.MITServiceClient = New ServiceReference1.MITServiceClient()
                        client.ClientCredentials.UserName.UserName = lang.clientUsername
                        client.ClientCredentials.UserName.Password = lang.clientPassword
                        RS = client.getIndividualRegistry(NationalNo.Text)
                        TM = client.getTradeMark(RS.decRegistryNo, 6)
                        If Not TM Is Nothing Then

                            If Not TM.Length = 0 Then
                                If TM(0).decCompanyNO IsNot Nothing Then
                                    Div3.Visible = True
                                    Label72.Text = "TradeMarks for it"
                                    TradeMarkGrid.DataSource = TM
                                    TradeMarkGrid.Columns(0).HeaderText = lang.TM_AR
                                    TradeMarkGrid.Columns(1).HeaderText = lang.TM_En
                                    TradeMarkGrid.Style.Add("Font-family", lang.fonta)
                                    TradeMarkGrid.DataBind()
                                End If
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                End If
                If Not odr_det("ORG_EMAIL") Is DBNull.Value Then
                    hl_mailto_org.NavigateUrl = "mailto:" + odr_det("ORG_EMAIL")
                End If
                If Not odr_det("dom_mob") Is DBNull.Value Then
                    txt_org_mobile.Text = odr_det("dom_mob")
                End If
                If Not odr_det("AUTHORIZED_NAME") Is DBNull.Value Then
                    txt_AUTHORIZED_NAME.Text = odr_det("AUTHORIZED_NAME")
                End If
                If Not odr_det("OWNER_NAME") Is DBNull.Value Then
                    txt_OWNER_NAME.Text = odr_det("OWNER_NAME")
                End If
                If Not odr_det("REG_DATE") Is DBNull.Value Then
                    txt_reg_date.Text = odr_det("REG_DATE")
                End If
                If Not odr_det("IMMEDIATE_FUTURE") Is DBNull.Value Then
                    rbl_IMMEDIATE_FUTURE.SelectedIndex = CInt(odr_det("IMMEDIATE_FUTURE"))
                End If
                If Not odr_det("TECH_CONTACT") Is DBNull.Value Then
                    txt_TECH_CONTACT.Text = odr_det("TECH_CONTACT")
                End If
                If Not odr_det("tech_EMAIL") Is DBNull.Value Then
                    txt_tech_EMAIL.Text = odr_det("tech_EMAIL")
                End If
                If Not odr_det("tech_EMAIL") Is DBNull.Value Then
                    hl_mailto_tech_EMAIL.NavigateUrl = "mailto:" + odr_det("tech_EMAIL")
                End If
                If Not odr_det("tech_mob") Is DBNull.Value Then
                    txt_tech_mobile.Text = odr_det("tech_mob")
                End If
                If Not odr_det("BILLING_CONTACT") Is DBNull.Value Then
                    txt_BILLING_CONTACT.Text = odr_det("BILLING_CONTACT")
                End If
                If Not odr_det("BILLING_EMAIL") Is DBNull.Value Then
                    txt_billing_EMAIL.Text = odr_det("BILLING_EMAIL")
                End If
                If Not odr_det("BILLING_EMAIL") Is DBNull.Value Then
                    hl_mailto_billing_EMAIL.NavigateUrl = "mailto:" + odr_det("BILLING_EMAIL")
                End If

                If Not odr_det("bil_mob") Is DBNull.Value Then
                    txt_billing_mobile.Text = odr_det("bil_mob")
                End If

                If Not odr_det("Commint") Is DBNull.Value Then
                    TXT_FIRST_COMMIT.Text = odr_det("Commint")
                End If
                If Not odr_det("free") Is DBNull.Value Then
                    If odr_det("free") = "f" Then
                        freech.Checked = True
                    Else
                        freech.Checked = False
                    End If

                End If
                If odr_det("name_server_id") = 0 Then
                    txt_PRIMARY_NAMESERVER.Text = "Parked"
                    txt_PRIMARY_IP_ADDRESS.Text = "Parked"
                    txt_SECONDARY_IP_ADDRESS.Text = "Parked"
                    txt_SECONDARY_IP_ADDRESS.Text = "Parked"
                Else
                    Dim COMM_det2 As New Data.SqlClient.SqlCommand
                    Dim CONN_det2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ODR_det2 As Data.SqlClient.SqlDataReader
                    COMM_det2.CommandText = "dom_det"
                    COMM_det2.Connection = CONN_det2
                    CONN_det2.Open()
                    COMM_det2.Parameters.AddWithValue("domain_id", Dom_id)
                    COMM_det2.CommandType = Data.CommandType.StoredProcedure
                    ODR_det2 = COMM_det2.ExecuteReader
                    While ODR_det2.Read

                        If Not ODR_det2("p_server_name") Is DBNull.Value Then

                            txt_PRIMARY_NAMESERVER.Text = ODR_det2("p_server_name")
                        End If
                        If Not ODR_det2("p_server_ip") Is DBNull.Value Then

                            txt_PRIMARY_IP_ADDRESS.Text = ODR_det2("p_server_ip")
                        End If
                        If Not ODR_det2("s_server_name") Is DBNull.Value Then

                            txt_SECONDARY_NAMESERVER.Text = ODR_det2("s_server_name")
                        End If
                        If Not ODR_det2("s_server_ip") Is DBNull.Value Then

                            txt_SECONDARY_IP_ADDRESS.Text = ODR_det2("s_server_ip")
                        End If
                    End While
                    ODR_det2.Close()
                    CONN_det2.Close()
                    Dim conn_server_data As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmd_server_data As New System.Data.SqlClient.SqlCommand("server_data_domain", conn_server_data)
                    Dim reader_server_data As SqlClient.SqlDataReader
                    ocmd_server_data.Parameters.AddWithValue("did", Dom_id)
                    conn_server_data.Open()
                    ocmd_server_data.CommandType = System.Data.CommandType.StoredProcedure
                    reader_server_data = ocmd_server_data.ExecuteReader()
                    While reader_server_data.Read
                        If Not reader_server_data("P_SERVER_NAME") Is DBNull.Value Then
                            p_name.Text = reader_server_data("P_SERVER_NAME")
                        End If
                        If Not reader_server_data("P_SERVER_IP") Is DBNull.Value Then
                            P_SERVER_IP.Text = reader_server_data("P_SERVER_IP")
                        End If
                        If Not reader_server_data("S_SERVER_NAME") Is DBNull.Value Then
                            S_SERVER_NAME.Text = reader_server_data("S_SERVER_NAME")
                        End If
                        If Not reader_server_data("S_SERVER_IP") Is DBNull.Value Then
                            S_SERVER_IP.Text = reader_server_data("S_SERVER_IP")
                        End If
                        If Not reader_server_data("S_SERVER_NAME2") Is DBNull.Value Then
                            S_SERVER_NAME2.Text = reader_server_data("S_SERVER_NAME2")
                        End If
                        If Not reader_server_data("S_SERVER_IP2") Is DBNull.Value Then
                            S_SERVER_IP2.Text = reader_server_data("S_SERVER_IP2")
                        End If
                        If Not reader_server_data("S_SERVER_NAME3") Is DBNull.Value Then
                            S_SERVER_NAME3.Text = reader_server_data("S_SERVER_NAME3")
                        End If
                        If Not reader_server_data("S_SERVER_IP3") Is DBNull.Value Then
                            S_SERVER_IP3.Text = reader_server_data("S_SERVER_IP3")
                        End If
                        If Not reader_server_data("S_SERVER_NAME4") Is DBNull.Value Then
                            S_SERVER_NAME4.Text = reader_server_data("S_SERVER_NAME4")
                        End If
                        If Not reader_server_data("S_SERVER_IP4") Is DBNull.Value Then
                            S_SERVER_IP4.Text = reader_server_data("S_SERVER_IP4")
                        End If
                        If Not reader_server_data("S_SERVER_NAME5") Is DBNull.Value Then
                            S_SERVER_NAME5.Text = reader_server_data("S_SERVER_NAME5")
                        End If
                        If Not reader_server_data("S_SERVER_IP5") Is DBNull.Value Then
                            S_SERVER_IP5.Text = reader_server_data("S_SERVER_IP5")
                        End If
                        If Not reader_server_data("S_SERVER_NAME6") Is DBNull.Value Then
                            S_SERVER_NAME6.Text = reader_server_data("S_SERVER_NAME6")
                        End If
                        If Not reader_server_data("S_SERVER_IP6") Is DBNull.Value Then
                            S_SERVER_IP6.Text = reader_server_data("S_SERVER_IP6")
                        End If
                        If Not reader_server_data("S_SERVER_NAME7") Is DBNull.Value Then
                            S_SERVER_NAME7.Text = reader_server_data("S_SERVER_NAME7")
                        End If
                        If Not reader_server_data("S_SERVER_IP7") Is DBNull.Value Then
                            S_SERVER_IP7.Text = reader_server_data("S_SERVER_IP7")
                        End If
                        If Not reader_server_data("S_SERVER_NAME8") Is DBNull.Value Then
                            S_SERVER_NAME8.Text = reader_server_data("S_SERVER_NAME8")
                        End If
                        If Not reader_server_data("S_SERVER_IP8") Is DBNull.Value Then
                            S_SERVER_IP8.Text = reader_server_data("S_SERVER_IP8")
                        End If
                        If Not reader_server_data("S_SERVER_NAME9") Is DBNull.Value Then
                            S_SERVER_NAME9.Text = reader_server_data("S_SERVER_NAME9")
                        End If
                        If Not reader_server_data("S_SERVER_IP9") Is DBNull.Value Then
                            S_SERVER_IP9.Text = reader_server_data("S_SERVER_IP9")
                        End If
                        If Not reader_server_data("S_SERVER_NAME10") Is DBNull.Value Then
                            S_SERVER_NAME10.Text = reader_server_data("S_SERVER_NAME10")
                        End If
                        If Not reader_server_data("S_SERVER_IP10") Is DBNull.Value Then
                            S_SERVER_IP10.Text = reader_server_data("S_SERVER_IP10")
                        End If

                    End While
                    conn_server_data.Close()
                    reader_server_data.Close()
                    txt_DOMAIN_NAME.Enabled = False
                    rbl_SECOND_DOMAIN.Enabled = False
                    txt_PRIMARY_NAMESERVER.Enabled = False
                    txt_PRIMARY_IP_ADDRESS.Enabled = False
                    txt_SECONDARY_NAMESERVER.Enabled = False
                    txt_SECONDARY_IP_ADDRESS.Enabled = False
                    TXT_ORG_NAME.Enabled = False
                    txt_org_mobile.Enabled = False
                    txt_ORG_EMAIL.Enabled = False
                    txt_AUTHORIZED_NAME.Enabled = False
                    txt_OWNER_NAME.Enabled = False
                    txt_reg_date.Enabled = False
                    rbl_IMMEDIATE_FUTURE.Enabled = False
                    txt_COMPANY_USER_NAME.Enabled = False
                    txt_ADMIN_CONTACT.Enabled = False
                    txt_admin_mobile.Enabled = False
                    txt_EMAIL.Enabled = False
                    txt_TECH_CONTACT.Enabled = False
                    txt_tech_mobile.Enabled = False
                    txt_tech_EMAIL.Enabled = False
                    txt_BILLING_CONTACT.Enabled = False
                    txt_billing_mobile.Enabled = False
                    txt_billing_EMAIL.Enabled = False
                End If


                If rbl_SECOND_DOMAIN.SelectedValue = 1 Or rbl_SECOND_DOMAIN.SelectedValue = 3 Or rbl_SECOND_DOMAIN.SelectedValue = 4 Or rbl_SECOND_DOMAIN.SelectedValue = 5 Or rbl_SECOND_DOMAIN.SelectedValue = 6 Or rbl_SECOND_DOMAIN.SelectedValue = 7 Then
                End If
                If rbl_SECOND_DOMAIN.SelectedValue = 2 Then
                End If
                If rbl_SECOND_DOMAIN.SelectedValue = 8 Then
                End If
                If fill_E_Mail_LOG(Dom_id) Then
                End If
                If Not odr_det("about_doc") Is DBNull.Value Then
                    rbl_about_doc.SelectedValue = CInt(odr_det("about_doc"))
                End If

            End While
            odr_det.Close()
            conn_det.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try



    End Sub
    Private Function fill_E_Mail_LOG(ByVal dom_id As Integer) As Boolean
        Dim comm_log As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red1_log As Data.SqlClient.SqlDataReader
        Try
            conn_log.Open()
            comm_log.Connection = conn_log
            comm_log.CommandText = "email_log"
            comm_log.Parameters.AddWithValue("did", dom_id)
            comm_log.CommandType = Data.CommandType.StoredProcedure
            red1_log = comm_log.ExecuteReader()
            While red1_log.Read
                lbl_E_Mail_LOG.Text += "->>>" & red1_log.Item("title") & "<br>"
            End While
            red1_log.Close()
            conn_log.Close()
            fill_E_Mail_LOG = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn_log.Close()
            fill_E_Mail_LOG = False
        End Try


    End Function
    Private Sub Approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approve.Click
        lbl_error.Text = ""
        lbl_Result.Text = ""
        Dim comm_Online As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conn_Online As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Try
            conn_Online.Open()
            comm_Online.Connection = conn_Online
            If rbl_onhold.SelectedIndex = 0 Then
                comm_Online.CommandText = "update_on"
            Else
                comm_Online.CommandText = "on_hold2"
            End If

            If rbl_Approved.SelectedIndex = 1 Then
                comm_Online.Parameters.AddWithValue("st", 2)
            Else
                comm_Online.Parameters.AddWithValue("st", 6)
            End If
            If freech.Checked Then
                comm_Online.Parameters.AddWithValue("free", "f")
            Else
                comm_Online.Parameters.AddWithValue("free", "nf")
            End If
            comm_Online.Parameters.AddWithValue("did", Dom_id)
            comm_Online.Parameters.AddWithValue("doc", rbl_about_doc.SelectedValue)
            comm_Online.CommandType = Data.CommandType.StoredProcedure
            comm_Online.ExecuteNonQuery()
            conn_Online.Close()
            Dim comm_log As New Data.SqlClient.SqlCommand
            Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            comm_log.Connection = conn_log
            conn_log.Open()
            comm_log.CommandText = "insert_log3"
            comm_log.Parameters.AddWithValue("domain_id", Dom_id)
            If rbl_Approved.SelectedIndex = 1 Then
                comm_log.Parameters.AddWithValue("status", 2)
            Else
                comm_log.Parameters.AddWithValue("status", 6)
            End If
            comm_log.Parameters.AddWithValue("date", Now)
            comm_log.Parameters.AddWithValue("comment", Server.HtmlEncode(TXT_FIRST_COMMIT.Text))
            comm_log.Parameters.AddWithValue("admin", Session("Users_ID"))
            comm_log.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm_log.CommandType = Data.CommandType.StoredProcedure
            comm_log.ExecuteNonQuery()
            conn_log.Close()
            lbl_Result.Visible = True

            If rbl_Approved.SelectedIndex = 1 Then
                Dim conn_adminData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd_adminData As New Data.SqlClient.SqlCommand("selectAdminData", conn_adminData)
                Dim odradmin As Data.SqlClient.SqlDataReader
                ocmd_adminData.Parameters.AddWithValue("DomainId", Dom_id)
                conn_adminData.Open()
                ocmd_adminData.CommandType = Data.CommandType.StoredProcedure
                odradmin = ocmd_adminData.ExecuteReader
                odradmin.Read()
                If freech.Checked = False Then
                    Dim conn_Settings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmd_settings As New Data.SqlClient.SqlCommand("selectInvoiceSettings", conn_Settings)
                    Dim settid As Integer
                    ocmd_settings.Parameters.AddWithValue("Admin_ID", odradmin("ADMIN_ID"))
                    ocmd_settings.CommandType = Data.CommandType.StoredProcedure
                    conn_settings.Open()
                    ocmd_settings.CommandType = Data.CommandType.StoredProcedure
                    settid = ocmd_settings.ExecuteScalar
                    conn_settings.Close()
                    If settid <> 0 Then
                        'add domain to settings [savedefault_det]
                        Dim com_SaveSettings As New Data.SqlClient.SqlCommand
                        Dim con_SaveSettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        com_SaveSettings.Connection = con_SaveSettings
                        con_SaveSettings.Open()
                        com_SaveSettings.CommandText = "savedefault_det"
                        com_SaveSettings.CommandType = Data.CommandType.StoredProcedure
                        com_SaveSettings.Parameters.AddWithValue("domain_id", Dom_id)
                        com_SaveSettings.Parameters.AddWithValue("Years", 1)
                        com_SaveSettings.Parameters.AddWithValue("invoicesetting_id", settid)
                        com_SaveSettings.ExecuteNonQuery()
                        con_SaveSettings.Close()
                    Else
                        Dim com_SaveSettings As New Data.SqlClient.SqlCommand
                        Dim con_SaveSettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        com_SaveSettings.Connection = con_SaveSettings
                        con_SaveSettings.Open()
                        com_SaveSettings.CommandText = "savesettings"
                        com_SaveSettings.CommandType = Data.CommandType.StoredProcedure
                        com_SaveSettings.Parameters.AddWithValue("Admin_id", odradmin("ADMIN_ID"))
                        com_SaveSettings.ExecuteNonQuery()
                        con_SaveSettings.Close()
                        '[selectSettingsMax]
                        Dim connMaxInvoiceSettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmdMaxInvoicesettings As New Data.SqlClient.SqlCommand("selectSettingsMax", connMaxInvoicesettings)
                        Dim settmid As Integer
                        ocmdMaxInvoicesettings.CommandType = Data.CommandType.StoredProcedure
                        connMaxInvoicesettings.Open()
                        settmid = ocmdMaxInvoicesettings.ExecuteScalar
                        connMaxInvoicesettings.Close()
                        Dim com_DefaultInvoice As New Data.SqlClient.SqlCommand
                        Dim conn102 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        com_DefaultInvoice.Connection = conn102
                        conn102.Open()
                        com_DefaultInvoice.CommandText = "savedefault_det"
                        com_DefaultInvoice.CommandType = Data.CommandType.StoredProcedure
                        com_DefaultInvoice.Parameters.AddWithValue("domain_id", Dom_id)
                        com_DefaultInvoice.Parameters.AddWithValue("Years", 1)
                        com_DefaultInvoice.Parameters.AddWithValue("invoicesetting_id", settmid)
                        com_DefaultInvoice.ExecuteNonQuery()
                        conn102.Close()
                    End If

                End If
                lbl_Result.Text = "Updated Successfully"
                send_approv_EMail(Dom_id)
                send_Invoice()
            Else
                send_not_approv_EMail(Dom_id)
                Dim conn_adminData As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd_adminData As New Data.SqlClient.SqlCommand("selectAdminData", conn_adminData)
                Dim odradmin As Data.SqlClient.SqlDataReader
                ocmd_adminData.Parameters.AddWithValue("DomainId", Dom_id)
                conn_adminData.Open()
                ocmd_adminData.CommandType = Data.CommandType.StoredProcedure
                odradmin = ocmd_adminData.ExecuteReader
                odradmin.Read()
                'BanAdmin
                Dim Dns_WebContentconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim Dns_WebContentCmd As New SqlClient.SqlCommand("DNSWebsite_SelectPageContent", Dns_WebContentconn)
                Dns_WebContentconn.Open()
                Dns_WebContentCmd.CommandType = CommandType.StoredProcedure
                Dns_WebContentCmd.CommandText = "insertAdminBan"
                Dns_WebContentCmd.Parameters.AddWithValue("admin_id", odradmin("Admin_id"))
                Dns_WebContentCmd.Parameters.AddWithValue("domain", odradmin("domain_name"))
                Dns_WebContentCmd.Parameters.Add("Message", SqlDbType.NVarChar, 200)
                Dns_WebContentCmd.Parameters("Message").Direction = ParameterDirection.Output
                Dns_WebContentCmd.ExecuteNonQuery()
                Session("Message") = Convert.ToString(Dns_WebContentCmd.Parameters("Message").Value)
                Dns_WebContentconn.Close()
                odradmin.Close()
                conn_adminData.Close()
            End If



        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_Online.Close()
        End Try
        conn_Online.Close()
    End Sub


    Private Function send_not_approv_EMail_update_data(ByVal domanes_id As Integer) As Boolean
        Dim comm_Notapprove As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conn_Notapprove As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red1_Notapprove As Data.SqlClient.SqlDataReader

        Dim dd As DateTime = Now 'CDate(txt_DateOfEnter.Text)
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Dim recipant_email, recipant_name, modee_m, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4modee, message_body4, GM__Commint As String
        Subject = ""
        DOMAIN_NAME = ""
        SECOND_DOMAIN = ""
        recipant_email = ""
        GM__Commint = ""
        Try
            conn_Notapprove.Open()
            comm_Notapprove.Connection = conn_Notapprove
            comm_Notapprove.CommandText = "domain_log_1 "
            comm_Notapprove.Parameters.AddWithValue("did", domanes_id)
            comm_Notapprove.CommandType = Data.CommandType.StoredProcedure
            red1_Notapprove = comm_Notapprove.ExecuteReader()
            While red1_Notapprove.Read
                recipant_email = red1_Notapprove.Item("EMAIL")
                recipant_name = red1_Notapprove.Item("COMPANY_USER_NAME")

                USER_PASSWORD = red1_Notapprove.Item("USER_PASSWORD")
                OWNER_NAME = red1_Notapprove.Item("OWNER_NAME")
                DOMAIN_NAME = red1_Notapprove.Item("DOMAIN_NAME")
                SECOND_DOMAIN = red1_Notapprove.Item("SECOND_DOMAIN")
                GM__Commint = red1_Notapprove.Item("Commint")
            End While
            red1_Notapprove.Close()
            conn_Notapprove.Close()

            Subject = "Update Data"
            message_body = "<table align=center border='0' width='44%'><tr><td height='59'><p align='center'><img border='0' src='https://www.dns.jo/img.png' width='90' height='88'></p><p align='center'><font color='#003366'><b>???? ????????? ????????? ??????</b></font></td></tr><tr><td><p align='center'><p align='center'><b>?<font color='#003366'>?</font></b><font color='#003366'><b> ??? ???? ?????? ???? ????? (<span lang='en-us'>jo.)</span> ???? ??????<a href='http://www.dns.jo/registration_policy_a.aspx'>????? ???????</a></b><p align='center'><font style='font-size: 10pt' face='Verdana'><b>National Information Technology Center</b></p>	<p  align='left' dir='ltr'><span style='font-size: 10.0pt'>Sorry, but your application regarding the domain name registration under (.JO) has been rejected.<span lang='en-us'>see<a href='http://www.dns.jo/registration_policy.aspx'>Registration Policy.</a></span></span></font></tr></table>"
            message_body += DOMAIN_NAME & SECOND_DOMAIN
            message_body_4modee = GM__Commint & "<br>"
            modee_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
            send_not_approv_EMail_update_data = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conn_Notapprove.Close()
            Return False
        End Try
        conn_Notapprove.Close()
        Return True
    End Function
    Private Function send_not_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_log As New Data.SqlClient.SqlCommand
        Dim red_log As Data.SqlClient.SqlDataReader
        Dim comm_mail As New Data.SqlClient.SqlCommand
        Dim red_mail As Data.SqlClient.SqlDataReader
        Dim recipant_email, modee_m, Subject, message_body, message_body1 As String
        Dim LangFlag As String
        Subject = ""
        message_body1 = ""
        Dim intLoopIndex As Integer
        Try
            conn_log.Open()
            comm_log.Connection = conn_log
            comm_log.CommandText = "domain_log_1"
            comm_log.Parameters.AddWithValue("did", domanes_id)
            comm_log.CommandType = Data.CommandType.StoredProcedure
            red_log = comm_log.ExecuteReader()
            While red_log.Read
                recipant_email = red_log.Item("EMAIL")
                LangFlag = red_log.Item("LangFlag")
                If (LangFlag.Contains("en")) Then
                    conn_mail.Open()
                    comm_mail.Connection = conn_mail
                    comm_mail.CommandText = "ma_t"
                    comm_mail.Parameters.AddWithValue("id", 60)
                    comm_mail.CommandType = Data.CommandType.StoredProcedure
                    red_mail = comm_mail.ExecuteReader()
                    While red_mail.Read
                        Subject = red_mail.Item("title")
                        message_body1 = red_mail.Item("body_h") & red_mail.Item("body_h1") & red_mail.Item("body_h2") & red_mail.Item("body_h3")
                    End While
                    red_mail.Close()
                    conn_mail.Close()
                ElseIf (LangFlag.Contains("ar")) Then
                    For intLoopIndex = 70 To 72
                        conn_mail.Open()
                        comm_mail.Connection = conn_mail
                        comm_mail.CommandText = "ma_t"
                        comm_mail.Parameters.Clear()
                        comm_mail.Parameters.AddWithValue("id", intLoopIndex)
                        comm_mail.CommandType = Data.CommandType.StoredProcedure
                        red_mail = comm_mail.ExecuteReader()
                        While red_mail.Read
                            Subject = red_mail.Item("title")
                            message_body1 += red_mail.Item("body_h") & red_mail.Item("body_t") & red_mail.Item("body_h1") & red_mail.Item("body_h2") & red_mail.Item("body_h3")
                        End While
                        red_mail.Close()
                        conn_mail.Close()
                    Next intLoopIndex
                End If
                message_body = message_body1
                modee_m = "dns@modee.gov.jo"
                ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
                Dim str_Mobile As String = txt_admin_mobile.Text
                Dim str_Trim As String = ""
                Dim str_ReplaceSpace As String = ""
                Dim int As Integer = 0
                Dim str_Substring As String = ""
                Dim FinalMobile As String = ""
                str_Trim = Trim(str_Mobile)
                str_ReplaceSpace = str_Trim.Replace(" ", "")
                str_Substring = str_ReplaceSpace.Substring(str_ReplaceSpace.Length - 9, 9)
                FinalMobile = "962" & str_Substring
                Dim msg As String = "Sorry to inform you that your Domain Name "
                msg &= txt_DOMAIN_NAME.Text & Me.rbl_SECOND_DOMAIN.SelectedItem.ToString
                msg &= "  has been Rejected Please Contact 962.6.5300225 "
                msg &= ""
                Dim lang As Languages = New Languages("en")
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & msg & "&mobile_number=" & FinalMobile & "&from=" & "domain.jo" & "&tag=" & 1
                ReusableCode.VisitURL(Url1)
            End While
            red_log.Close()
            conn_log.Close()


            send_not_approv_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conn_log.Close()
        End Try

    End Function
    Private Function send_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim commdomain_email As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conndomain_email As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn_email2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim reddomain_email As Data.SqlClient.SqlDataReader
        Dim comm_email2 As New Data.SqlClient.SqlCommand
        Dim red_email2 As Data.SqlClient.SqlDataReader
        Dim recipant_email, modee_m, Subject, DOMAIN_NAME, SECOND_DOMAIN As String
        Subject = ""
        Dim message_body, message_body1 As String
        Dim LangFlag As String
        Dim intLoopIndex As Integer
        message_body1 = ""
        Try
            conndomain_email.Open()
            commdomain_email.Connection = conndomain_email
            commdomain_email.CommandText = "domain_email_send"
            commdomain_email.Parameters.AddWithValue("did", domanes_id)
            commdomain_email.CommandType = Data.CommandType.StoredProcedure
            reddomain_email = commdomain_email.ExecuteReader()
            While reddomain_email.Read
                recipant_email = reddomain_email.Item("EMAIL")
                CC_BillingEmail = reddomain_email.Item("BillingEmail")
                DOMAIN_NAME = reddomain_email.Item("DOMAIN_NAME")
                SECOND_DOMAIN = reddomain_email.Item("SECOND_DOMAIN")
                LangFlag = reddomain_email.Item("LangFlag")
                If (LangFlag.Contains("en")) Then
                    conn_email2.Open()
                    comm_email2.Connection = conn_email2
                    comm_email2.CommandText = "ma_t"
                    comm_email2.Parameters.AddWithValue("id", 2)
                    comm_email2.CommandType = Data.CommandType.StoredProcedure
                    red_email2 = comm_email2.ExecuteReader()
                    While red_email2.Read
                        Subject = (red_email2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                        message_body1 = red_email2.Item("body_h") & red_email2.Item("body_h1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>") & red_email2.Item("body_t") & red_email2.Item("body_h2") & red_email2.Item("body_h3")
                    End While
                    red_email2.Close()
                    conn_email2.Close()
                ElseIf (LangFlag.Contains("ar")) Then
                    For intLoopIndex = 64 To 66
                        conn_email2.Open()
                        comm_email2.Connection = conn_email2
                        comm_email2.CommandText = "ma_t"
                        comm_email2.Parameters.Clear()
                        comm_email2.Parameters.AddWithValue("id", intLoopIndex)
                        comm_email2.CommandType = Data.CommandType.StoredProcedure
                        red_email2 = comm_email2.ExecuteReader()
                        While red_email2.Read
                            Subject = (red_email2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                            If intLoopIndex = 64 Then
                                message_body1 += red_email2.Item("body_h") & red_email2.Item("body_h1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font></span>") & red_email2.Item("body_h2") & red_email2.Item("body_h3")
                            Else
                                message_body1 += red_email2.Item("body_h") & red_email2.Item("body_h1") & red_email2.Item("body_h2") & red_email2.Item("body_h3")
                            End If
                        End While
                        red_email2.Close()
                        conn_email2.Close()
                    Next intLoopIndex
                End If
                message_body = message_body1
                modee_m = "dns@modee.gov.jo"
                ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
                send_approv_EMail = True
                Dim str_Mobile As String = txt_admin_mobile.Text
                Dim str_Trim As String = ""
                Dim str_ReplaceSpace As String = ""
                Dim int As Integer = 0
                Dim str_Substring As String = ""
                Dim FinalMobile As String = ""
                str_Trim = Trim(str_Mobile)
                str_ReplaceSpace = str_Trim.Replace(" ", "")
                str_Substring = str_ReplaceSpace.Substring(str_ReplaceSpace.Length - 9, 9)
                FinalMobile = "962" & str_Substring
                Dim msg As String = "Congratulations! Your application regarding the domain name registration under (.JO) has been approved."
                msg &= " "
                msg &= txt_DOMAIN_NAME.Text & Me.rbl_SECOND_DOMAIN.SelectedItem.ToString
                msg &= "  www.dns.jo Tel:5300263"

                Dim lang As Languages = New Languages("en")
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & "modee_dns" & "&login_password=" & lang.SMSuser & "&msg=" & msg & "&mobile_number=" & FinalMobile & "&from=" & "modee" & "&tag=" & 1

                ReusableCode.VisitURL(Url1)



            End While
            reddomain_email.Close()
            conndomain_email.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conndomain_email.Close()
            Return False
        End Try
        conndomain_email.Close()
        Return True
    End Function
    Protected Sub SendEmailbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SendEmailbtn.Click
        Domain_Namepanel.Visible = False
        User_Panel.Visible = False
        Tech_panel.Visible = False
        If Panel_send_email.Visible = True Then
            Panel_send_email.Visible = False
        Else
            Panel_send_email.Visible = True
        End If
        SendEmailbtn.Visible = False

    End Sub
    Protected Sub SendEmailAr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SendEmailAr.Click
        If CheckBoxList1.SelectedIndex = -1 Then
            lbl_error.Text = "You have to select one title"
        Else
            Dim connectionstr As DAL = New DAL()
            Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm_log As New SqlCommand
            Dim red1_log As SqlDataReader
            Dim recipant_email, recipant_name, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, GM__Commint As String
            recipant_email = ""
            recipant_name = ""
            DOMAIN_NAME = ""
            SECOND_DOMAIN = ""
            OWNER_NAME = ""
            GM__Commint = ""
            Try
                conn_log.Open()
                comm_log.CommandText = "domain_log_1"
                comm_log.Parameters.AddWithValue("did", Dom_id)
                comm_log.CommandType = Data.CommandType.StoredProcedure
                comm_log.Connection = conn_log
                red1_log = comm_log.ExecuteReader()

                While red1_log.Read
                    recipant_email = red1_log.Item("EMAIL")
                    recipant_name = red1_log.Item("COMPANY_USER_NAME")
                    OWNER_NAME = red1_log.Item("OWNER_NAME")
                    DOMAIN_NAME = red1_log.Item("DOMAIN_NAME")
                    SECOND_DOMAIN = red1_log.Item("SECOND_DOMAIN")
                End While
                red1_log.Close()
                conn_log.Close()

                Dim em_id() As Integer
                Dim i As Integer
                Dim li As ListItem
                For Each li In CheckBoxList1.Items
                    If li.Selected Then
                        insert_log_e_mail(li.Value)
                        ReDim Preserve em_id(i)
                        em_id(i) = li.Value
                        i += 1
                    End If
                Next
                sendarabic_e_mail(em_id, DOMAIN_NAME, SECOND_DOMAIN, GM__Commint, recipant_email, recipant_name)
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
                conn_log.Close()
            End Try

        End If


    End Sub
    Private Sub sendarabic_e_mail(ByVal em_id() As Integer, ByVal DOMAIN_NAME As String, ByVal SECOND_DOMAIN As String, ByVal GM__Commint As String, ByVal recipant_email As String, ByVal recipant_name As String)
        Dim connectionstr As DAL = New DAL()
        Dim conne_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comme_mail As New SqlCommand
        Dim red1e_mail As SqlDataReader
        Dim conn2e_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm2e_mail As New SqlCommand
        Dim red2e_mail As SqlDataReader
        Dim i, intLoopIndex As Integer
        Dim message_body, Subject As String
        message_body = ""
        Subject = ""
        Try
            For intLoopIndex = 74 To 76
                conn2e_mail.Open()
                comm2e_mail.Connection = conn2e_mail
                comm2e_mail.CommandText = "ma_t"
                comm2e_mail.Parameters.Clear()
                comm2e_mail.Parameters.AddWithValue("id", intLoopIndex)
                comm2e_mail.CommandType = Data.CommandType.StoredProcedure
                red2e_mail = comm2e_mail.ExecuteReader()
                While red2e_mail.Read
                    Subject = (red2e_mail.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                    If (intLoopIndex = 74) Then
                        message_body += red2e_mail.Item("body_h") & red2e_mail.Item("body_t") & red2e_mail.Item("body_h1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>: <o:p></o:p></span></p>") & "<ul dir='rtl' style='margin: 3pt 0.5in 0pt 0in;'>"
                        Dim p As New SqlParameter
                        p.DbType = System.Data.DbType.Int32
                        p.Direction = System.Data.ParameterDirection.Input
                        p.ParameterName = "id"
                        comme_mail.Parameters.Add(p)
                        For i = 0 To em_id.Length - 1
                            conne_mail.Open()
                            comme_mail.Connection = conne_mail
                            comme_mail.CommandText = "ma_t"
                            comme_mail.CommandType = Data.CommandType.StoredProcedure
                            p.Value = em_id(i)
                            red1e_mail = comme_mail.ExecuteReader()
                            While red1e_mail.Read
                                message_body += "<li><b>" & red1e_mail.Item("body_h") & "</b></li>"
                            End While
                            red1e_mail.Close()
                            conne_mail.Close()
                        Next
                        message_body += "</ul>"
                    Else
                        message_body += red2e_mail.Item("body_h") & red2e_mail.Item("body_t") & red2e_mail.Item("body_h1") & red2e_mail.Item("body_h2") & red2e_mail.Item("body_h3")
                    End If
                End While
                red2e_mail.Close()
                conn2e_mail.Close()
            Next intLoopIndex
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
            lbl_Result.Text = "E-Mail Send Success"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conne_mail.Close()
        End Try
        conne_mail.Close()
    End Sub
    Private Sub insert_log_e_mail(ByVal email_titel_id As Integer)
        Dim connectionstr As DAL = New DAL()
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_log As New SqlCommand
        Try
            conn_log.Open() 'insert in e_Mail_LOG
            comm_log.Connection = conn_log
            comm_log.CommandText = "insert_log_email"
            comm_log.Parameters.AddWithValue("id", Dom_id)
            comm_log.Parameters.AddWithValue("em", email_titel_id)
            comm_log.CommandType = Data.CommandType.StoredProcedure
            comm_log.ExecuteNonQuery()
            conn_log.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_log.Close()
        End Try
        conn_log.Close()
    End Sub
    Protected Sub SendEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SendEmail.Click
        If CheckBoxList1.SelectedIndex <> -1 Then
            Me.SendEmailAr_Click(sender, e)
        End If
        If rbl_email_titel.SelectedIndex <> -1 Then
            Dim connectionstr As DAL = New DAL()
            Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm_log As New SqlCommand
            Dim red1_log As SqlDataReader
            Dim recipant_email, recipant_name, modee_m, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body3, message_body_4modee, message_body4, GM__Commint As String
            modee_m = ""
            DOMAIN_NAME = ""
            SECOND_DOMAIN = ""
            GM__Commint = ""
            recipant_email = ""
            recipant_email = ""
            recipant_name = ""
            Try
                conn_log.Open()
                comm_log.Connection = conn_log
                comm_log.CommandText = "domain_log_1"
                comm_log.Parameters.AddWithValue("did", Dom_id)
                comm_log.CommandType = Data.CommandType.StoredProcedure
                red1_log = comm_log.ExecuteReader()
                While red1_log.Read
                    recipant_email = red1_log.Item("EMAIL")
                    recipant_name = red1_log.Item("COMPANY_USER_NAME")
                    OWNER_NAME = red1_log.Item("OWNER_NAME")
                    DOMAIN_NAME = red1_log.Item("DOMAIN_NAME")
                    SECOND_DOMAIN = red1_log.Item("SECOND_DOMAIN")
                End While
                red1_log.Close()
                conn_log.Close()

                Dim em_id() As Integer
                Dim i As Integer
                Dim li As ListItem
                For Each li In rbl_email_titel.Items
                    If li.Selected Then
                        insert_log_e_mail(li.Value)
                        ReDim Preserve em_id(i)
                        em_id(i) = li.Value
                        i += 1
                    End If
                Next
                send_e_mail(em_id, DOMAIN_NAME, SECOND_DOMAIN, GM__Commint, recipant_email, recipant_name)
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
                conn_log.Close()
            End Try
            conn_log.Close()
        End If


    End Sub
    Private Sub send_e_mail(ByVal em_id() As Integer, ByVal DOMAIN_NAME As String, ByVal SECOND_DOMAIN As String, ByVal GM__Commint As String, ByVal recipant_email As String, ByVal recipant_name As String)
        Dim connectionstr As DAL = New DAL()
        Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_mail As New SqlCommand
        Dim red1_mail As SqlDataReader
        Dim conn_mail2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_mail2 As New SqlCommand
        Dim red_mail2 As SqlDataReader
        Dim i As Integer
        Dim message_body, message_body1, message_body2, Subject As String
        Subject = ""
        message_body2 = ""
        message_body1 = ""
        message_body = ""
        Try
            conn_mail2.Open()
            comm_mail2.Connection = conn_mail2
            comm_mail2.CommandText = "ma_t"
            comm_mail2.Parameters.AddWithValue("id", 73)
            comm_mail2.CommandType = Data.CommandType.StoredProcedure
            red_mail2 = comm_mail2.ExecuteReader()
            While red_mail2.Read
                Subject = (red_mail2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                message_body1 += red_mail2.Item("body_h") & red_mail2.Item("body_t") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>: </span></p>") & "<ul>"
                Dim p As New SqlParameter
                p.DbType = System.Data.DbType.Int32
                p.Direction = System.Data.ParameterDirection.Input
                p.ParameterName = "id"
                comm_mail.Parameters.Add(p)
                For i = 0 To em_id.Length - 1
                    conn_mail.Open()
                    comm_mail.Connection = conn_mail
                    comm_mail.CommandText = "ma_t"
                    comm_mail.CommandType = Data.CommandType.StoredProcedure
                    p.Value = em_id(i)
                    red1_mail = comm_mail.ExecuteReader()
                    While red1_mail.Read
                        message_body1 += "<li><b>" & red1_mail.Item("body_h") & "</b></li>"
                    End While

                    red1_mail.Close()
                    conn_mail.Close()
                Next

                message_body1 += "</ul>" & red_mail2.Item("body_h1") & red_mail2.Item("body_h2") & red_mail2.Item("body_h3")

            End While

            red_mail2.Close()
            conn_mail2.Close()

            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body1)
            lbl_Result.Text = "E-Mail Send Success"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_mail.Close()

        End Try

    End Sub
    Private Function send_account_EMail(ByVal domanes_id As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim connemail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commemail As New SqlCommand
        Dim redemail1 As SqlDataReader
        Dim connemail2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commemail2 As New SqlCommand
        Dim redemail2 As SqlDataReader
        Dim recipant_email, recipant_name, modee_m, modee_m1, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4modee, message_body4 As String
        Dim LangFlag As String = ""
        Subject = ""
        recipant_email = ""
        Dim intLoopIndex As Integer = 0
        message_body1 = ""
        modee_m = ""
        Try
            connemail.Open()
            commemail.Connection = connemail
            commemail.CommandText = "domain_email_send"
            commemail.Parameters.AddWithValue("did", domanes_id)
            commemail.CommandType = Data.CommandType.StoredProcedure
            redemail1 = commemail.ExecuteReader()
            While redemail1.Read
                recipant_email = redemail1.Item("EMAIL")
                recipant_name = redemail1.Item("COMPANY_USER_NAME")
                USER_PASSWORD = redemail1.Item("USER_PASSWORD")
                OWNER_NAME = redemail1.Item("OWNER_NAME")
                DOMAIN_NAME = redemail1.Item("DOMAIN_NAME")
                SECOND_DOMAIN = redemail1.Item("SECOND_DOMAIN")
                LangFlag = redemail1.Item("LangFlag")
            End While
            redemail1.Close()
            connemail.Close()

            If (LangFlag.Contains("en")) Then
                connemail2.Open()
                commemail2.Connection = connemail2
                commemail2.CommandText = "ma_t"
                commemail2.Parameters.AddWithValue("id", 3)
                commemail2.CommandType = Data.CommandType.StoredProcedure
                redemail2 = commemail2.ExecuteReader()
                While redemail2.Read
                    Subject = redemail2.Item("title")
                    message_body1 += redemail2.Item("body_h") & redemail2.Item("body_t")
                    message_body1 += redemail2.Item("body_h1") & redemail2.Item("body_h2") & redemail2.Item("body_h3")
                End While
                redemail2.Close()
                connemail2.Close()
            ElseIf (LangFlag.Contains("ar")) Then
                For intLoopIndex = 67 To 69
                    connemail2.Open()
                    commemail2.Connection = connemail2
                    commemail2.CommandText = "ma_t"
                    commemail2.Parameters.Clear()
                    commemail2.Parameters.AddWithValue("id", intLoopIndex)
                    commemail2.CommandType = Data.CommandType.StoredProcedure
                    redemail2 = commemail2.ExecuteReader()
                    While redemail2.Read
                        Subject = redemail2.Item("title")
                        message_body1 += redemail2.Item("body_h") & redemail2.Item("body_t") & redemail2.Item("body_h1") & redemail2.Item("body_h2")
                        message_body1 += redemail2.Item("body_h3")
                    End While
                    redemail2.Close()
                    connemail2.Close()
                Next intLoopIndex
            End If

            message_body = message_body1
            modee_m1 = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
            send_account_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            connemail.Close()
        End Try
        connemail.Close()
    End Function




    Public Sub send_Invoice()
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn_Fees As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim strRecipient, emailSubject As String
            strDomainName = txt_DOMAIN_NAME.Text & rbl_SECOND_DOMAIN.SelectedItem.Text
            Dim ocmd_Fees As New Data.SqlClient.SqlCommand
            Dim odr_Fees As Data.SqlClient.SqlDataReader
            ocmd_Fees.Connection = conn_Fees
            ocmd_Fees.CommandText = "SelectFees"
            ocmd_Fees.Parameters.AddWithValue("sid", rbl_SECOND_DOMAIN.SelectedValue)
            ocmd_Fees.CommandType = Data.CommandType.StoredProcedure
            conn_Fees.Open()
            odr_Fees = ocmd_Fees.ExecuteReader
            While odr_Fees.Read
                strRenewFees = odr_Fees("renewValue")
                strRenewFeesUSD = odr_Fees("ValueUSD")
            End While
            conn_Fees.Close()

            strRecipient = txt_EMAIL.Text
            If (rbl_LangFlag.SelectedValue = 1) Then
                emailSubject = strDomainName & "مطالبة مالية للنطاق  "
                ReusableCode.sndMail(strRecipient, "dns@modee.gov.jo", emailSubject, text_msg())
            ElseIf (rbl_LangFlag.SelectedValue = 0) Then
                emailSubject = "Domain Name Invoice (" & strDomainName & ")"
                ReusableCode.sndMail(strRecipient, "dns@modee.gov.jo", emailSubject, text_msg())
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Public Function text_msg() As String
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim conn_mail2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm_mail As New Data.SqlClient.SqlCommand
            Dim reader_mail As Data.SqlClient.SqlDataReader
            Dim comm_mail2 As New Data.SqlClient.SqlCommand
            Dim reader_mail2 As Data.SqlClient.SqlDataReader
            Dim messageBody As String = ""

            If (rbl_LangFlag.SelectedValue = 1) Then
                conn_mail.Open()
                comm_mail.Connection = conn_mail
                comm_mail.CommandText = "ma_t"
                comm_mail.Parameters.AddWithValue("id", 77)
                comm_mail.CommandType = Data.CommandType.StoredProcedure
                reader_mail = comm_mail.ExecuteReader()
                While reader_mail.Read
                    messageBody = reader_mail.Item("body_h") & strDomainName & reader_mail.Item("body_t") & strRenewFees & reader_mail.Item("body_h1") & reader_mail.Item("body_h2") & reader_mail.Item("body_h3")
                End While
                strDomainName = ""
                reader_mail.Close()
                conn_mail.Close()
                strRenewFees = ""
            ElseIf (rbl_LangFlag.SelectedValue = 0) Then
                conn_mail2.Open()
                comm_mail2.Connection = conn_mail2
                comm_mail2.CommandText = "ma_t"
                comm_mail2.Parameters.AddWithValue("id", 78)
                comm_mail2.CommandType = Data.CommandType.StoredProcedure
                reader_mail2 = comm_mail2.ExecuteReader()
                While reader_mail2.Read
                    messageBody = reader_mail2.Item("body_h") & strDomainName & reader_mail2.Item("body_t") & strRenewFees & reader_mail2.Item("body_h1") & strRenewFeesUSD & reader_mail2.Item("body_h2") & reader_mail2.Item("body_h3")
                End While
                strDomainName = ""
                reader_mail2.Close()
                conn_mail2.Close()
                strRenewFees = ""
                strRenewFeesUSD = ""
            End If
            Return messageBody

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\viewdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Return ""
        End Try
    End Function

End Class