Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Threading
Imports Microsoft.Security.Application
Public Class Details
    Inherits System.Web.UI.Page
    Dim Dom_id As Integer
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
            GridView1.DataBind()

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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
        End Try




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
                        If Not (TypeOf ex Is ThreadAbortException) Then
                            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                        End If
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
                    Dim CoNN_det2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
            Dim coon_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                odradmin = ocmd_adminData.ExecuteReader()
                While odradmin.Read
                    If freech.Checked = False Then
                        Session("RefNo") = odradmin("ADMIN_ID")
                        Dim conn_settings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmd_settings As New Data.SqlClient.SqlCommand("selectInvoiceSettings", conn_settings)
                        Dim settid As Integer
                        ocmd_settings.Parameters.AddWithValue("Admin_ID", odradmin("ADMIN_ID"))
                        ocmd_settings.CommandType = Data.CommandType.StoredProcedure
                        conn_settings.Open()
                        settid = ocmd_settings.ExecuteScalar
                        conn_settings.Close()
                        If settid <> 0 Then
                            'add domain to settings [savedefault_det]
                            Dim com_SaveSettings As New Data.SqlClient.SqlCommand
                            Dim con_Savesettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                            Dim con_Savesettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                            com_SaveSettings.Connection = con_SaveSettings
                            con_SaveSettings.Open()
                            com_SaveSettings.CommandText = "savesettings"
                            com_SaveSettings.CommandType = Data.CommandType.StoredProcedure
                            com_SaveSettings.Parameters.AddWithValue("Admin_id", odradmin("ADMIN_ID"))
                            com_SaveSettings.ExecuteNonQuery()
                            con_SaveSettings.Close()
                            '[selectSettingsMax]
                            Dim connMaxInvoicesettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                End While

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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_Online.Close()
        End Try
        conn_Online.Close()
    End Sub
    Private Function send_not_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim lang As Languages = New Languages("en")
        Dim comm_log As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red_log As Data.SqlClient.SqlDataReader
        Dim comm_mail As New Data.SqlClient.SqlCommand
        Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red_mail As Data.SqlClient.SqlDataReader
        Dim recipant_email, modee_m, Subject, message_body, message_body1 As String
        Dim LangFlag As String
        Subject = ""
        message_body1 = ""
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
                conn_mail.Open()
                comm_mail.Connection = conn_mail
                comm_mail.CommandText = "SelectEmailTextID"
                If LangFlag.Contains("en") Then
                    comm_mail.Parameters.AddWithValue("id", 20)
                Else
                    comm_mail.Parameters.AddWithValue("id", 23)
                End If
                comm_mail.CommandType = Data.CommandType.StoredProcedure
                red_mail = comm_mail.ExecuteReader()
                While red_mail.Read
                    If (LangFlag.Contains("en")) Then
                        Subject = "Domain Name Rejected" & "(" & red_log.Item("DOMAIN_NAME") & red_log.Item("SECOND_DOMAIN") & ")"
                    Else
                        Subject = "رفض التسجيل للنطاق" & "( " & red_log.Item("DOMAIN_NAME") & red_log.Item("SECOND_DOMAIN") & " )"
                    End If
                    message_body1 = red_mail.Item("part1") & "  (" & red_log.Item("DOMAIN_NAME") & red_log.Item("SECOND_DOMAIN") & ") " & red_mail.Item("part2") & red_mail.Item("footer")
                End While
                red_mail.Close()
                conn_mail.Close()

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
                Dim msg As String = "Sorry To inform you that your Domain Name "
                msg &= txt_DOMAIN_NAME.Text & Me.rbl_SECOND_DOMAIN.SelectedItem.ToString
                msg &= "  has been Rejected Please Contact 962.6.5300263 "
                msg &= ""

                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & msg & "&mobile_number=" & FinalMobile & "&from=" & "domain.jo" & "&tag=" & 1
                ReusableCode.VisitURL(Url1)
            End While
            red_log.Close()
            conn_log.Close()


            send_not_approv_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conn_log.Close()
        End Try

    End Function
    Private Function send_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim commdomain_email As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conndomain_email As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim reddomain_email As Data.SqlClient.SqlDataReader
        Dim comm_email2 As New Data.SqlClient.SqlCommand
        Dim conn_email2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red_email2 As Data.SqlClient.SqlDataReader
        Dim recipant_email, modee_m, Subject, DOMAIN_NAME, SECOND_DOMAIN As String
        Subject = ""
        Dim message_body, message_body1 As String
        Dim LangFlag As String
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

                conn_email2.Open()
                comm_email2.Connection = conn_email2
                comm_email2.CommandText = "SelectEmailTextID"
                If rbl_LangFlag.SelectedValue = 0 Then
                    comm_email2.Parameters.AddWithValue("id", 18)
                Else
                    comm_email2.Parameters.AddWithValue("id", 19)
                End If
                comm_email2.CommandType = Data.CommandType.StoredProcedure
                red_email2 = comm_email2.ExecuteReader()
                While red_email2.Read
                    If (LangFlag.Contains("en")) Then
                        Subject = ("Auditing Approval" & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                    Else
                        Subject = ("الموافقة المبدئية" & " (" & DOMAIN_NAME & SECOND_DOMAIN & ")  ")
                    End If

                    message_body1 = red_email2.Item("part1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>") & red_email2.Item("part2") & red_email2.Item("footer")
                End While
                red_email2.Close()
                conn_email2.Close()

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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conndomain_email.Close()
            Return False
        End Try
        conndomain_email.Close()
        Return True
    End Function


    Public Function emailpapersen() As ArrayList
        Dim Arr As ArrayList = New ArrayList()

        For count As Integer = 0 To GridView1.Rows.Count - 1
            Dim itemlistitem As ListItem = New ListItem()
            If (CType(GridView1.Rows(count).FindControl("check"), CheckBox)).Checked Then

                itemlistitem.Value = GridView1.Rows(count).Cells(5).Text
                itemlistitem.Text = GridView1.Rows(count).Cells(4).Text
                Arr.Add(itemlistitem)
            End If

        Next
        Return Arr
    End Function
    Public Function emailpapersar() As ArrayList
        Dim Arr As ArrayList = New ArrayList()

        For count As Integer = 0 To GridView1.Rows.Count - 1
            Dim itemlistitem As ListItem = New ListItem()
            If (CType(GridView1.Rows(count).FindControl("check"), CheckBox)).Checked Then

                itemlistitem.Value = GridView1.Rows(count).Cells(2).Text
                itemlistitem.Text = GridView1.Rows(count).Cells(3).Text
                Arr.Add(itemlistitem)
            End If

        Next
        Return Arr
    End Function

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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_log.Close()
        End Try
        conn_log.Close()
    End Sub

    Private Sub send_e_mailAR(ByVal DOMAIN_NAME As String, ByVal SECOND_DOMAIN As String, ByVal recipant_email As String, ByVal recipant_name As String)
        Dim connectionstr As DAL = New DAL()
        Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_mail As New SqlCommand
        Dim red_mail As SqlDataReader
        Dim i As Integer
        Dim message_body1, Subject As String
        message_body1 = ""

        Try
            conn_mail.Open()
            comm_mail.Connection = conn_mail
            comm_mail.CommandText = "SelectEmailTextID"
            comm_mail.Parameters.AddWithValue("ID", 28)
            comm_mail.CommandType = Data.CommandType.StoredProcedure
            red_mail = comm_mail.ExecuteReader()
            While red_mail.Read()
                Subject = ("الوثائق الثوبتية المطلوبة" & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                message_body1 += red_mail.Item("part1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>: </span></p>") & "<ul style='direction:rtl;font-family:calibri'>"

                Dim Arr As ArrayList = New ArrayList()
                Arr = emailpapersar()
                Dim itemlistarr As ListItem
                If Arr.Count <= 0 Then
                    SelectedEmaillbl.Text = "You have to select one email at least"
                    Toastr.ShowToast(Page, Toastr.ToastType.Error, SelectedEmaillbl.Text)
                Else
                    For i = 0 To Arr.Count - 1
                        itemlistarr = Arr(i)
                        message_body1 += "<li><b>" & itemlistarr.Text & "</b></li>"

                    Next
                    message_body1 += "</ul>" & red_mail.Item("part2") & red_mail.Item("footer")
                    ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body1)
                    lbl_Result.Text = "E-Mail Sent Sucessfully"
                End If

            End While


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_mail.Close()

        End Try

    End Sub
    Public Sub send_Invoice()
        Try


            Dim strRecipient, emailSubject As String
            strDomainName = txt_DOMAIN_NAME.Text & rbl_SECOND_DOMAIN.SelectedItem.Text
            Dim ocmd_Fees As New Data.SqlClient.SqlCommand
            Dim connectionstr As DAL = New DAL()
            Dim conn_Fees As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim odr_Fees As Data.SqlClient.SqlDataReader
            ocmd_Fees.Connection = conn_Fees
            ocmd_Fees.CommandText = "SelectFeesSpecial"
            ocmd_Fees.Parameters.AddWithValue("TLD", rbl_SECOND_DOMAIN.SelectedValue)
            ocmd_Fees.Parameters.AddWithValue("domain_id", Session("diD"))
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub


    Private Sub send_e_mailEn(ByVal DOMAIN_NAME As String, ByVal SECOND_DOMAIN As String, ByVal recipant_email As String, ByVal recipant_name As String)
        Dim connectionstr As DAL = New DAL()
        Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_mail As New SqlCommand
        Dim red_mail As SqlDataReader
        Dim i As Integer
        Dim message_body1, Subject As String
        message_body1 = ""

        Try
            conn_mail.Open()
            comm_mail.Connection = conn_mail
            comm_mail.CommandText = "SelectEmailTextID"
            comm_mail.Parameters.AddWithValue("id", 29)
            comm_mail.CommandType = Data.CommandType.StoredProcedure
            red_mail = comm_mail.ExecuteReader()
            While red_mail.Read()
                Subject = ("Required Documents " & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                message_body1 += red_mail.Item("part1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>: </span></p>") & "<ul style='direction:ltr;font-family:Calibri'>"
                Dim itemlistarr As ListItem
                Dim Arr As ArrayList = New ArrayList()
                Arr = emailpapersen()
                If Arr.Count <= 0 Then
                    SelectedEmaillbl.Text = "You have to select one email at least"
                    Toastr.ShowToast(Page, Toastr.ToastType.Error, SelectedEmaillbl.Text)
                Else

                    For i = 0 To Arr.Count - 1
                        itemlistarr = Arr(i)
                        message_body1 += "<li><b>" & itemlistarr.Text & "</b></li>"

                    Next
                    message_body1 += "</ul>" & red_mail.Item("part2") & red_mail.Item("footer")
                    ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body1)
                    lbl_Result.Text = "E-Mail Sent Successfully"
                End If




            End While



        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn_mail.Close()

        End Try

    End Sub

    Protected Sub SendEmailPaperen_Click(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_log As New SqlCommand
        Dim red1_log As SqlDataReader
        Dim recipant_email, recipant_name, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME As String
        DOMAIN_NAME = ""
        SECOND_DOMAIN = ""
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

            send_e_mailEn(DOMAIN_NAME, SECOND_DOMAIN, recipant_email, recipant_name)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conn_log.Close()
        End Try
        conn_log.Close()
        '   End If


    End Sub

    Protected Sub SendEmailPaperar_Click(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim conn_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm_log As New SqlCommand
        Dim red1_log As SqlDataReader
        Dim recipant_email, recipant_name, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME As String
        DOMAIN_NAME = ""
        SECOND_DOMAIN = ""
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

            send_e_mailAR(DOMAIN_NAME, SECOND_DOMAIN, recipant_email, recipant_name)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error!")
            conn_log.Close()
        End Try
        conn_log.Close()


    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "delete1" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim ID As String = Convert.ToString(e.CommandArgument)
                Session("ID") = ID
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd As New Data.SqlClient.SqlCommand("delete_emailpaper", conn)
                conn.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("ID", Session("ID").ToString.Trim)
                ocmd.ExecuteNonQuery()
                GridView1.DataBind()

                Toastr.ShowToast(Page, Toastr.ToastType.Success, "Deleted Successfully")
                conn.Close()
                conn.Close()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SecondDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error")
        End Try



    End Sub
    Protected Sub add_Click(sender As Object, e As EventArgs)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand("insert_emailpaper", conn)
            conn.Open()
            ocmd.CommandType = CommandType.StoredProcedure
            ocmd.Parameters.AddWithValue("ar", emailartext.Text.Trim)
            ocmd.Parameters.AddWithValue("en", emailentext.Text.Trim)
            ocmd.ExecuteNonQuery()
            GridView1.DataBind()
            Toastr.ShowToast(Page, Toastr.ToastType.Success, "Inserted Successfully")
            conn.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SecondDomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            Toastr.ShowToast(Page, Toastr.ToastType.Error, "Error")
        End Try
    End Sub



    Public Function text_msg() As String
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conn_mail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm_mail As New Data.SqlClient.SqlCommand
            Dim reader_mail As Data.SqlClient.SqlDataReader
            Dim messageBody As String = ""
            conn_mail.Open()
            comm_mail.Connection = conn_mail
            comm_mail.CommandText = "SelectEmailTextID"
            If (rbl_LangFlag.SelectedValue = 1) Then
                comm_mail.Parameters.AddWithValue("id", 26)
            Else
                comm_mail.Parameters.AddWithValue("id", 27)
            End If
            comm_mail.CommandType = Data.CommandType.StoredProcedure
            reader_mail = comm_mail.ExecuteReader()

            While reader_mail.Read
                If (rbl_LangFlag.SelectedValue = 1) Then
                    messageBody = reader_mail.Item("part1") & " (" & strDomainName & "  ) " & " " & reader_mail.Item("part2") & "  " & " (" & strRenewFees & "  ) " & reader_mail.Item("part3") & reader_mail.Item("part4") & " (" & Session("RefNo") & "  ) " & reader_mail.Item("part5") & reader_mail.Item("footer")
                Else
                    messageBody = reader_mail.Item("part1") & " (" & strDomainName & " )" & " " & reader_mail.Item("part2") & " " & " (" & strRenewFees & "JD" & "  ) " & " (" & strRenewFeesUSD & " USD " & " )" & reader_mail.Item("part3") & reader_mail.Item("part4") & " (" & Session("RefNo") & "  ) " & reader_mail.Item("part5") & reader_mail.Item("footer")
                End If

            End While
            strDomainName = ""
            reader_mail.Close()
            conn_mail.Close()
            strRenewFees = ""
            strRenewFeesUSD = ""

            Return messageBody

        Catch ex As Exception
            Return ""
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\details:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function

End Class