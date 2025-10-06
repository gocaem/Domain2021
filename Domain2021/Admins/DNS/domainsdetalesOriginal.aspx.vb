Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.Threading

Partial Class domainsdetalesOriginal
    Inherits System.Web.UI.Page
    Dim Dom_id As Integer
    Dim CC_BillingEmail As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session("Admin_User_ID") = "" Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        If Session("DID") = "" Then
            Response.Redirect("ApproveUpdate.aspx")
        End If
        If Not Page.IsPostBack Then
            rbl_SECOND_DOMAIN.DataBind()
            ddl_NAME_SERVER.DataBind()
            ddl_NAME_SERVER.Items.Insert(0, "Select One")
            ddl_NAME_SERVER.Items.Insert(1, "-----------")

        End If
        If Not Page.IsPostBack Then
            fill_db(Session("DID"))
            fill_dbOrginal(Session("DID"))
            MarkUpdates()
        End If
    End Sub
    Private Sub MarkUpdates()
        If TechT.Text <> txt_TECH_CONTACT.Text Then
            txt_TECH_CONTACT.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If txt_tech_mobile.Text <> TechMobileT.Text Then
            txt_tech_mobile.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If techEMailT.Text <> txt_tech_EMAIL.Text Then
            txt_tech_EMAIL.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Primary.Text <> txt_PRIMARY_NAMESERVER.Text Then
            txt_PRIMARY_NAMESERVER.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If PrimaryIP.Text <> txt_PRIMARY_IP_ADDRESS.Text Then
            txt_PRIMARY_IP_ADDRESS.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary.Text <> txt_SECONDARY_NAMESERVER.Text Then
            txt_SECONDARY_NAMESERVER.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryIPT.Text <> txt_SECONDARY_IP_ADDRESS.Text Then
            txt_SECONDARY_IP_ADDRESS.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If TXT_ORG_NAME.Text <> ORG_NAMET.Text Then
            TXT_ORG_NAME.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If txt_org_mobile.Text <> OrgMobileT.Text Then
            txt_org_mobile.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If OrgEmailT.Text <> txt_ORG_EMAIL.Text Then
            txt_ORG_EMAIL.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If BILLING_CONTACTT.Text <> txt_BILLING_CONTACT.Text Then
            txt_BILLING_CONTACT.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If txt_billing_mobile.Text <> bil_mobT.Text Then
            txt_billing_mobile.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If txt_billing_EMAIL.Text <> BillingEmailT.Text Then
            txt_billing_EMAIL.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Primary_Server.Text <> p_nameOriginal.Text Then
            Primary_Server.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If PrimaryServerIPTOriginal.Text <> Primary_ServerIP.Text Then
            Primary_ServerIP.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondOriginal1.Text <> SecondaryNameT1.Text Then
            SecondaryNameT1.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondOriginalIP1.Text <> Secondary_IP1.Text Then
            Secondary_IP1.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryNameText2.Text <> SecondaryNameT2.Text Then
            SecondaryNameT2.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryIPT2.Text <> SecondaryNameIP2.Text Then
            SecondaryIPT2.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryName3.Text <> Secondary_Name3.Text Then
            SecondaryName3.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryNameIP3.Text <> SecondaryIP3.Text Then
            SecondaryIP3.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryTextBox4.Text <> SSERVER_NAME4T.Text Then
            SecondaryTextBox4.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryIPT4.Text <> SecondaryIPText4.Text Then
            SecondaryIPText4.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If S_SERVER_NAME5T.Text <> SecondaryNameT5.Text Then
            S_SERVER_NAME5T.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary_IP5T.Text <> S_SERVER_NAME5IP.Text Then
            Secondary_IP5T.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If S_SERVER_NAME6.Text <> Secondary_NameT6.Text Then
            Secondary_NameT6.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary6IPTextBox.Text <> SecondaryTIP6.Text Then
            SecondaryTIP6.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryTName7.Text <> Secondary7T.Text Then
            SecondaryTName7.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary_IPT7.Text <> Secondary7IP.Text Then
            Secondary_IPT7.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary8T.Text <> SecondaryName8T.Text Then
            SecondaryName8T.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryIPT8.Text <> Secondary8IPT.Text Then
            SecondaryIPT8.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary9T.Text <> SecondaryNameT9.Text Then
            SecondaryNameT9.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary9IP.Text <> Secondary_IPT9.Text Then
            Secondary_IPT9.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If Secondary10T.Text <> SecondaryNameT10.Text Then
            SecondaryNameT10.Style.Add("BACKGROUND-COLOR", "red")
        End If
        If SecondaryIP10.Text <> Secondary_IPT10.Text Then
            Secondary_IPT10.Style.Add("BACKGROUND-COLOR", "red")
        End If
    End Sub
    Private Sub fill_db(ByVal Dom_id As Integer)
        Try
            Dim connectionstr As DAL = New DAL()
            Dim serverdet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim serverdetCommand As New System.Data.SqlClient.SqlCommand("select_updated", serverdet)
            Dim readerserver As SqlClient.SqlDataReader
            serverdetCommand.Parameters.AddWithValue("Domain_id", Dom_id)
            serverdet.Open()
            serverdetCommand.CommandType = System.Data.CommandType.StoredProcedure
            readerserver = serverdetCommand.ExecuteReader()
            While readerserver.Read
                If Not readerserver("P_SERVER_NAME") Is DBNull.Value Then
                    Primary_Server.Text = readerserver("P_SERVER_NAME")
                    txt_PRIMARY_NAMESERVER.Text = readerserver("P_SERVER_NAME")
                End If
                If Not readerserver("P_SERVER_IP") Is DBNull.Value Then
                    Primary_ServerIP.Text = readerserver("P_SERVER_IP")
                    txt_PRIMARY_IP_ADDRESS.Text = readerserver("P_SERVER_IP")
                End If
                If Not readerserver("S_SERVER_NAME") Is DBNull.Value Then
                    SecondaryNameT1.Text = readerserver("S_SERVER_NAME")
                    txt_SECONDARY_NAMESERVER.Text = readerserver("S_SERVER_NAME")
                End If
                If Not readerserver("S_SERVER_IP") Is DBNull.Value Then
                    Secondary_IP1.Text = readerserver("S_SERVER_IP")
                    txt_SECONDARY_IP_ADDRESS.Text = readerserver("S_SERVER_IP")
                End If
                If Not readerserver("S_SERVER_NAME2") Is DBNull.Value Then
                    SecondaryNameT2.Text = readerserver("S_SERVER_NAME2")
                End If
                If Not readerserver("S_SERVER_IP2") Is DBNull.Value Then
                    SecondaryIPT2.Text = readerserver("S_SERVER_IP2")
                End If
                If Not readerserver("S_SERVER_NAME3") Is DBNull.Value Then
                    Secondary_Name3.Text = readerserver("S_SERVER_NAME3")
                End If
                If Not readerserver("S_SERVER_IP3") Is DBNull.Value Then
                    SecondaryIP3.Text = readerserver("S_SERVER_IP3")
                End If
                If Not readerserver("S_SERVER_NAME4") Is DBNull.Value Then
                    SecondaryTextBox4.Text = readerserver("S_SERVER_NAME4")
                End If
                If Not readerserver("S_SERVER_IP4") Is DBNull.Value Then
                    SecondaryIPText4.Text = readerserver("S_SERVER_IP4")
                End If
                If Not readerserver("S_SERVER_NAME5") Is DBNull.Value Then
                    SecondaryNameT5.Text = readerserver("S_SERVER_NAME5")
                End If
                If Not readerserver("S_SERVER_IP5") Is DBNull.Value Then
                    SecondaryNameT5.Text = readerserver("S_SERVER_IP5")
                End If
                If Not readerserver("S_SERVER_NAME6") Is DBNull.Value Then
                    Secondary_NameT6.Text = readerserver("S_SERVER_NAME6")
                End If
                If Not readerserver("S_SERVER_IP6") Is DBNull.Value Then
                    SecondaryTIP6.Text = readerserver("S_SERVER_IP6")
                End If
                If Not readerserver("S_SERVER_NAME7") Is DBNull.Value Then
                    SecondaryTName7.Text = readerserver("S_SERVER_NAME7")
                End If
                If Not readerserver("S_SERVER_IP7") Is DBNull.Value Then
                    Secondary_IPT7.Text = readerserver("S_SERVER_IP7")
                End If
                If Not readerserver("S_SERVER_NAME8") Is DBNull.Value Then
                    SecondaryName8T.Text = readerserver("S_SERVER_NAME8")
                End If
                If Not readerserver("S_SERVER_IP8") Is DBNull.Value Then
                    SecondaryIPT8.Text = readerserver("S_SERVER_IP8")
                End If
                If Not readerserver("S_SERVER_NAME9") Is DBNull.Value Then
                    SecondaryNameT9.Text = readerserver("S_SERVER_NAME9")
                End If
                If Not readerserver("S_SERVER_IP9") Is DBNull.Value Then
                    Secondary_IPT9.Text = readerserver("S_SERVER_IP9")
                End If
                If Not readerserver("S_SERVER_NAME10") Is DBNull.Value Then
                    SecondaryNameT10.Text = readerserver("S_SERVER_NAME10")
                End If
                If Not readerserver("S_SERVER_IP10") Is DBNull.Value Then
                    Secondary_IPT10.Text = readerserver("S_SERVER_IP10")
                End If

                If Not readerserver("NewBillingID") Is DBNull.Value Then
                    BILLING_CODE_ID.Text = readerserver("NewBillingID")
                End If
                If Not readerserver("ADMIN_CONTACT") Is DBNull.Value Then
                    txt_ADMIN_CONTACT.Text = readerserver("ADMIN_CONTACT")
                End If
                If Not readerserver("COMPANY_USER_NAME") Is DBNull.Value Then
                    txt_COMPANY_USER_NAME.Text = readerserver("COMPANY_USER_NAME")
                End If
                If Not readerserver("EMAIL") Is DBNull.Value Then
                    txt_EMAIL.Text = readerserver("EMAIL")
                End If
                If Not readerserver("EMAIL") Is DBNull.Value Then
                    hl_mailto1.NavigateUrl = "Mailto:" + readerserver("EMAIL")
                End If
                If Not readerserver("admin_mobile") Is DBNull.Value Then
                    txt_admin_mobile.Text = readerserver("admin_mobile")
                End If

                If Not readerserver("DOMAIN_NAME") Is DBNull.Value Then
                    txt_DOMAIN_NAME.Text = readerserver("DOMAIN_NAME")
                End If
                If Not readerserver("SECOND_DOMAIN_ID") Is DBNull.Value Then
                    rbl_SECOND_DOMAIN.SelectedValue = CInt(readerserver("SECOND_DOMAIN_ID"))
                End If

                If Not readerserver("ORG_NAME") Is DBNull.Value Then
                    TXT_ORG_NAME.Text = readerserver("ORG_NAME")
                End If

                If Not readerserver("NewEmail") Is DBNull.Value Then
                    txt_ORG_EMAIL.Text = readerserver("NewEmail")
                End If
                If Not readerserver("NewEmail") Is DBNull.Value Then
                    hl_mailto_org.NavigateUrl = "mailto:" + readerserver("NewEmail")
                End If
                If Not readerserver("NewPhone") Is DBNull.Value Then
                    txt_org_mobile.Text = readerserver("NewPhone")
                End If

                If Not readerserver("NewTechIID") Is DBNull.Value Then
                    TechTextID2.Text = readerserver("NewTechIID")
                End If
                If Not readerserver("TECH_CONTACT") Is DBNull.Value Then
                    txt_TECH_CONTACT.Text = readerserver("TECH_CONTACT")
                End If

                If Not readerserver("tech_EMAIL") Is DBNull.Value Then
                    txt_tech_EMAIL.Text = readerserver("tech_EMAIL")
                End If
                If Not readerserver("tech_EMAIL") Is DBNull.Value Then
                    hl_mailto_tech_EMAIL.NavigateUrl = "mailto:" + readerserver("tech_EMAIL")
                End If
                If Not readerserver("tech_mob") Is DBNull.Value Then
                    txt_tech_mobile.Text = readerserver("tech_mob")
                End If
                If Not readerserver("BILLING_CONTACT") Is DBNull.Value Then
                    txt_BILLING_CONTACT.Text = readerserver("BILLING_CONTACT")
                End If
                If Not readerserver("bill_email") Is DBNull.Value Then
                    txt_billing_EMAIL.Text = readerserver("bill_email")
                End If
                If Not readerserver("bill_email") Is DBNull.Value Then
                    hl_mailto_billing_EMAIL.NavigateUrl = "mailto:" + readerserver("bill_email")
                End If
                If Not readerserver("bill_mobile") Is DBNull.Value Then
                    txt_billing_mobile.Text = readerserver("bill_mobile")
                End If

                If Not readerserver("Newowner_name") Is DBNull.Value Then
                    TXT_ORG_NAME.Text = readerserver("Newowner_name")
                End If



            End While
            serverdet.Close()
            readerserver.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\domaindetaleaoriginal:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try



    End Sub
    Private Sub fill_dbOrginal(ByVal Dom_id As Integer)
        Try

            Dim ocmddetales As New Data.SqlClient.SqlCommand
            Dim connectionstr As DAL = New DAL()
            Dim conndetales As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim odrdetales As Data.SqlClient.SqlDataReader
            ocmddetales.Connection = conndetales
            ocmddetales.CommandText = "domain_detalesOriginal"
            ocmddetales.Parameters.AddWithValue("domain_id", Dom_id)
            ocmddetales.CommandType = Data.CommandType.StoredProcedure
            conndetales.Open()
            odrdetales = ocmddetales.ExecuteReader
            While odrdetales.Read

                If Not odrdetales("ADMIN_CONTACT") Is DBNull.Value Then
                    AdminT.Text = odrdetales("ADMIN_CONTACT")
                End If
                If Not odrdetales("ad_mobile") Is DBNull.Value Then
                    ad_mobileT.Text = odrdetales("ad_mobile")
                End If
                If Not odrdetales("COMPANY_USER_NAME") Is DBNull.Value Then
                    UserT.Text = odrdetales("COMPANY_USER_NAME")
                End If
                If Not odrdetales("BILLING_CODE_ID") Is DBNull.Value Then
                    TID.Text = odrdetales("BILLING_CODE_ID")
                End If
                If Not odrdetales("TECH_CONTACTs_ID") Is DBNull.Value Then
                    TechTextID.Text = odrdetales("TECH_CONTACTs_ID")
                End If
                If Not odrdetales("EMAIL") Is DBNull.Value Then
                    AdminMailT.Text = odrdetales("EMAIL")
                End If
                If Not odrdetales("EMAIL") Is DBNull.Value Then
                    Ad_Emaillk.NavigateUrl = "Mailto:" + odrdetales("EMAIL")
                End If

                If Not odrdetales("DOMAIN_NAME") Is DBNull.Value Then
                    DomainNameT.Text = odrdetales("DOMAIN_NAME")
                End If
                If Not odrdetales("SECOND_DOMAIN_ID") Is DBNull.Value Then
                    secondddl.SelectedValue = CInt(odrdetales("SECOND_DOMAIN_ID"))
                End If

                If Not odrdetales("ORG_EMAIL") Is DBNull.Value Then
                    OrgEmailLk.NavigateUrl = "mailto:" + odrdetales("ORG_EMAIL")
                End If
                If Not odrdetales("ORG_EMAIL") Is DBNull.Value Then
                    OrgEmailT.Text = odrdetales("ORG_EMAIL")
                End If
                If Not odrdetales("ORG_PHONE") Is DBNull.Value Then
                    OrgMobileT.Text = odrdetales("ORG_PHONE")
                End If

                If Not odrdetales("TECH_CONTACT") Is DBNull.Value Then
                    TechT.Text = odrdetales("TECH_CONTACT")
                End If
                If Not odrdetales("tech_EMAIL") Is DBNull.Value Then
                    techEMailT.Text = odrdetales("tech_EMAIL")
                End If
                If Not odrdetales("tech_EMAIL") Is DBNull.Value Then
                    techEMaillk.NavigateUrl = "mailto:" + odrdetales("tech_EMAIL")
                End If
                If Not odrdetales("tech_mob") Is DBNull.Value Then
                    TechMobileT.Text = odrdetales("tech_mob")
                End If
                If Not odrdetales("BILLING_CONTACT") Is DBNull.Value Then
                    BILLING_CONTACTT.Text = odrdetales("BILLING_CONTACT")
                End If
                If Not odrdetales("BILLING_EMAIL") Is DBNull.Value Then
                    BillingEmailT.Text = odrdetales("BILLING_EMAIL")
                End If
                If Not odrdetales("BILLING_EMAIL") Is DBNull.Value Then
                    BillingEmailLK.NavigateUrl = "mailto:" + odrdetales("BILLING_EMAIL")
                End If
                If Not odrdetales("bil_mob") Is DBNull.Value Then
                    bil_mobT.Text = odrdetales("bil_mob")
                End If
                If Not odrdetales("Oldowner_name") Is DBNull.Value Then
                    ORG_NAMET.Text = odrdetales("Oldowner_name")
                End If
                If odrdetales("name_server_id") = 0 Then
                    Primary.Text = "Parked"
                    PrimaryIP.Text = "Parked"
                    Secondary.Text = "Parked"
                    SecondaryIPT.Text = "Parked"
                Else
                    Dim COMMdom_det As New Data.SqlClient.SqlCommand
                    Dim CONNdom_det As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ODRdom_det As Data.SqlClient.SqlDataReader
                    COMMdom_det.CommandText = "server_data_domain"
                    COMMdom_det.Connection = CONNdom_det
                    CONNdom_det.Open()
                    COMMdom_det.Parameters.AddWithValue("did", Session("DID"))
                    COMMdom_det.CommandType = Data.CommandType.StoredProcedure
                    ODRdom_det = COMMdom_det.ExecuteReader
                    While ODRdom_det.Read
                        If Not ODRdom_det("P_SERVER_NAME") Is DBNull.Value Then
                            Primary.Text = ODRdom_det("P_SERVER_NAME")
                            p_nameOriginal.Text = ODRdom_det("P_SERVER_NAME")
                        End If
                        If Not ODRdom_det("P_SERVER_IP") Is DBNull.Value Then
                            PrimaryIP.Text = ODRdom_det("P_SERVER_IP")
                            PrimaryServerIPTOriginal.Text = ODRdom_det("P_SERVER_IP")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME") Is DBNull.Value Then
                            Secondary.Text = ODRdom_det("S_SERVER_NAME")
                            SecondOriginal1.Text = ODRdom_det("S_SERVER_NAME")
                        End If
                        If Not ODRdom_det("S_SERVER_IP") Is DBNull.Value Then
                            SecondaryIPT.Text = ODRdom_det("S_SERVER_IP")
                            SecondOriginalIP1.Text = ODRdom_det("S_SERVER_IP")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME2") Is DBNull.Value Then
                            SecondaryNameText2.Text = ODRdom_det("S_SERVER_NAME2")
                        End If
                        If Not ODRdom_det("S_SERVER_IP2") Is DBNull.Value Then
                            SecondaryNameIP2.Text = ODRdom_det("S_SERVER_IP2")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME3") Is DBNull.Value Then
                            SecondaryName3.Text = ODRdom_det("S_SERVER_NAME3")
                        End If
                        If Not ODRdom_det("S_SERVER_IP3") Is DBNull.Value Then
                            SecondaryNameIP3.Text = ODRdom_det("S_SERVER_IP3")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME4") Is DBNull.Value Then
                            SSERVER_NAME4T.Text = ODRdom_det("S_SERVER_NAME4")
                        End If
                        If Not ODRdom_det("S_SERVER_IP4") Is DBNull.Value Then
                            SecondaryIPT4.Text = ODRdom_det("S_SERVER_IP4")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME5") Is DBNull.Value Then
                            S_SERVER_NAME5T.Text = ODRdom_det("S_SERVER_NAME5")
                        End If
                        If Not ODRdom_det("S_SERVER_IP5") Is DBNull.Value Then
                            S_SERVER_NAME5IP.Text = ODRdom_det("S_SERVER_IP5")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME6") Is DBNull.Value Then
                            S_SERVER_NAME6.Text = ODRdom_det("S_SERVER_NAME6")
                        End If
                        If Not ODRdom_det("S_SERVER_IP6") Is DBNull.Value Then
                            Secondary6IPTextBox.Text = ODRdom_det("S_SERVER_IP6")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME7") Is DBNull.Value Then
                            Secondary7T.Text = ODRdom_det("S_SERVER_NAME7")
                        End If
                        If Not ODRdom_det("S_SERVER_IP7") Is DBNull.Value Then
                            Secondary7IP.Text = ODRdom_det("S_SERVER_IP7")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME8") Is DBNull.Value Then
                            Secondary8T.Text = ODRdom_det("S_SERVER_NAME8")
                        End If
                        If Not ODRdom_det("S_SERVER_IP8") Is DBNull.Value Then
                            Secondary8IPT.Text = ODRdom_det("S_SERVER_IP8")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME9") Is DBNull.Value Then
                            Secondary9T.Text = ODRdom_det("S_SERVER_NAME9")
                        End If
                        If Not ODRdom_det("S_SERVER_IP9") Is DBNull.Value Then
                            Secondary9IP.Text = ODRdom_det("S_SERVER_IP9")
                        End If
                        If Not ODRdom_det("S_SERVER_NAME10") Is DBNull.Value Then
                            Secondary10T.Text = ODRdom_det("S_SERVER_NAME10")
                        End If
                        If Not ODRdom_det("S_SERVER_IP10") Is DBNull.Value Then
                            SecondaryIP10.Text = ODRdom_det("S_SERVER_IP10")
                        End If
                        If Not ODRdom_det("p_server_name") Is DBNull.Value Then
                            Primary.Text = ODRdom_det("p_server_name")
                        End If
                        If Not ODRdom_det("p_server_ip") Is DBNull.Value Then
                            PrimaryIP.Text = ODRdom_det("p_server_ip")
                        End If
                        If Not ODRdom_det("s_server_name") Is DBNull.Value Then

                            Secondary.Text = ODRdom_det("s_server_name")
                        End If
                        If Not ODRdom_det("s_server_ip") Is DBNull.Value Then
                            SecondaryIPT.Text = ODRdom_det("s_server_ip")
                        End If
                    End While
                    ODRdom_det.Close()
                    CONNdom_det.Close()

                    Primary.Enabled = False
                    PrimaryIP.Enabled = False
                    Secondary.Enabled = False
                    SecondaryIPT.Enabled = False
                    RadioButtonList1.Enabled = False
                    OrgMobileT.Enabled = False
                    UserT.Enabled = False
                    AdminT.Enabled = False
                    ad_mobileT.Enabled = False
                    secondddl.Enabled = False
                    DropDownList2.Enabled = False
                    bil_mobT.Enabled = False
                End If
            End While
            odrdetales.Close()
            conndetales.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\domaindetaleaoriginal:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try



    End Sub
    Private Sub rbl_nameNewNAmeserver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbl_nameNewNAmeserver.SelectedIndexChanged
        If rbl_nameNewNAmeserver.SelectedIndex = 0 Then
            Panel_nameserver.Visible = True
            Panel_newNameServer.Visible = False
        Else
            Panel_nameserver.Visible = False
            Panel_newNameServer.Visible = True
        End If
    End Sub
    Private Function send_not_approv_EMail_update_data(ByVal domanes_id As Integer) As Boolean
        Dim commemail As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim connemail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red1email As Data.SqlClient.SqlDataReader

        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Dim recipant_email, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4NITC, message_body4, GM__Commint As String
        Try
            connemail.Open()
            commemail.Connection = connemail
            commemail.CommandText = "domain_log_1 "
            commemail.Parameters.AddWithValue("did", domanes_id)
            commemail.CommandType = Data.CommandType.StoredProcedure
            red1email = commemail.ExecuteReader()
            While red1email.Read
                recipant_email = red1email.Item("EMAIL")
                recipant_name = red1email.Item("COMPANY_USER_NAME")
                USER_PASSWORD = red1email.Item("USER_PASSWORD")
                OWNER_NAME = red1email.Item("OWNER_NAME")
                DOMAIN_NAME = red1email.Item("DOMAIN_NAME")
                SECOND_DOMAIN = red1email.Item("SECOND_DOMAIN")
                GM__Commint = red1email.Item("Commint")
            End While
            red1email.Close()
            connemail.Close()

            Subject = "Update Data"
            message_body = "<table align=center border='0' width='44%'><tr><td height='59'><p align='center'><img border='0' src='https://www.dns.jo/img.png' width='90' height='88'></p><p align='center'><font color='#003366'><b>???? ????????? ????????? ??????</b></font></td></tr><tr><td><p align='center'><p align='center'><b>?<font color='#003366'>?</font></b><font color='#003366'><b> ??? ???? ?????? ???? ????? (<span lang='en-us'>jo.)</span> ???? ??????<a href='http://www.dns.jo/registration_policy_a.aspx'>????? ???????</a></b><p align='center'><font style='font-size: 10pt' face='Verdana'><b>National Information Technology Center</b></p><p align='left' dir='ltr'><span style='font-size: 10.0pt'>Sorry, but your application regarding the domain name registration under (.JO) has been rejected.<span lang='en-us'>see<a href='http://www.dns.jo/registration_policy.aspx'>Registration Policy.</a></span></span></font></tr></table>"
            message_body += DOMAIN_NAME & SECOND_DOMAIN
            message_body_4NITC = GM__Commint & "<br>"
            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
            send_not_approv_EMail_update_data = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\domaindetaleaoriginal:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            lbl_error.Text = ex.ToString
            connemail.Close()
        End Try
        connemail.Close()
    End Function
    Private Function send_not_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim commSend As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim connSend As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red1Send As Data.SqlClient.SqlDataReader
        Dim commEmailDet As New Data.SqlClient.SqlCommand
        Dim connEmailDet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim redEmailDet As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim recipant_email, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAIN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body2, message_body3, message_body_4NITC, message_body4, GM__Commint As String
        Dim LangFlag As String
        Dim intLoopIndex As Integer
        Try
            connSend.Open()
            commSend.Connection = connSend
            commSend.CommandText = "domain_log_1"
            commSend.Parameters.AddWithValue("did", domanes_id)
            commSend.CommandType = Data.CommandType.StoredProcedure
            red1Send = commSend.ExecuteReader()
            While red1Send.Read
                recipant_email = red1Send.Item("EMAIL")
                LangFlag = red1Send.Item("LangFlag")
                If (LangFlag.Contains("en")) Then
                    connEmailDet.Open()
                    commEmailDet.Connection = connEmailDet
                    commEmailDet.CommandText = "ma_t"
                    commEmailDet.Parameters.AddWithValue("id", 60)
                    commEmailDet.CommandType = Data.CommandType.StoredProcedure
                    redEmailDet = commEmailDet.ExecuteReader()
                    While redEmailDet.Read
                        Subject = redEmailDet.Item("title")
                        message_body1 = redEmailDet.Item("body_h") & redEmailDet.Item("body_h1") & redEmailDet.Item("body_h2") & redEmailDet.Item("body_h3")
                    End While
                    redEmailDet.Close()
                    connEmailDet.Close()
                ElseIf (LangFlag.Contains("ar")) Then
                    For intLoopIndex = 70 To 72
                        connEmailDet.Open()
                        commEmailDet.Connection = connEmailDet
                        commEmailDet.CommandText = "ma_t"
                        commEmailDet.Parameters.Clear()
                        commEmailDet.Parameters.AddWithValue("id", intLoopIndex)
                        commEmailDet.CommandType = Data.CommandType.StoredProcedure
                        redEmailDet = commEmailDet.ExecuteReader()
                        While redEmailDet.Read
                            Subject = redEmailDet.Item("title")
                            message_body1 += redEmailDet.Item("body_h") & redEmailDet.Item("body_t") & redEmailDet.Item("body_h1") & redEmailDet.Item("body_h2") & redEmailDet.Item("body_h3")
                        End While
                        redEmailDet.Close()
                        connEmailDet.Close()
                    Next intLoopIndex
                End If
                message_body = message_body1
                nitc_m = "dns@modee.gov.jo"
                ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
                Dim AllMobileStr As String = txt_admin_mobile.Text
                AllMobileStr = Trim(AllMobileStr)
                AllMobileStr = AllMobileStr.Replace(" ", "")
                AllMobileStr = AllMobileStr.Substring(AllMobileStr.Length - 9, 9)
                AllMobileStr = "962" & AllMobileStr
                Dim msgtext As String = "Sorry to inform you that your Domain Name "
                msgtext &= txt_DOMAIN_NAME.Text & Me.rbl_SECOND_DOMAIN.SelectedItem.ToString
                msgtext &= "  has been Rejected Please Contact 962.6.5300225 "
                msgtext &= ""
                Dim lang As Languages = New Languages("en")
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & msgtext & "&mobile_number=" & AllMobileStr & "&from=" & "domain.jo" & "&tag=" & 1
                ReusableCode.VisitURL(Url1)

            End While
            red1Send.Close()
            connSend.Close()
            connEmailDet.Close()
            send_not_approv_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\domaindetaleaoriginal:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            lbl_error.Text = ex.ToString
            connSend.Close()
        End Try

    End Function
    Private Function send_approv_EMail(ByVal domanes_id As Integer) As Boolean
        Dim comm As New Data.SqlClient.SqlCommand
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim red2 As Data.SqlClient.SqlDataReader

        Dim dd As DateTime = Now 'CDate(txt_DateOfEnter.Text)
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Dim recipant_email, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAIN As String
        Dim OWNER_NAME, USER_PASSWORD, message_body, message_body1 As String
        Dim message_body_4NITC, message_body4, GM__Commint As String
        Dim LangFlag As String
        Dim intLoopIndex As Integer

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "domain_email_send"
            comm.Parameters.AddWithValue("did", domanes_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                recipant_email = red1.Item("EMAIL")
                CC_BillingEmail = red1.Item("BillingEmail")
                DOMAIN_NAME = red1.Item("DOMAIN_NAME")
                SECOND_DOMAIN = red1.Item("SECOND_DOMAIN")
                LangFlag = red1.Item("LangFlag")
                If (LangFlag.Contains("en")) Then
                    conn2.Open()
                    comm2.Connection = conn2
                    comm2.CommandText = "ma_t"
                    comm2.Parameters.AddWithValue("id", 2)
                    comm2.CommandType = Data.CommandType.StoredProcedure
                    red2 = comm2.ExecuteReader()
                    While red2.Read
                        Subject = (red2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ") '"Domain Name Auditing Approval"
                        message_body1 = red2.Item("body_h") & red2.Item("body_h1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font>") & red2.Item("body_t") & red2.Item("body_h2") & red2.Item("body_h3")
                    End While
                    red2.Close()
                    conn2.Close()
                ElseIf (LangFlag.Contains("ar")) Then
                    For intLoopIndex = 64 To 66
                        conn2.Open()
                        comm2.Connection = conn2
                        comm2.CommandText = "ma_t"
                        comm2.Parameters.Clear()
                        comm2.Parameters.AddWithValue("id", intLoopIndex)
                        comm2.CommandType = Data.CommandType.StoredProcedure
                        red2 = comm2.ExecuteReader()
                        While red2.Read
                            Subject = (red2.Item("title") & " (" & DOMAIN_NAME & SECOND_DOMAIN & ") ")
                            If intLoopIndex = 64 Then
                                message_body1 += red2.Item("body_h") & red2.Item("body_h1") & ("<font color='red'> (" & DOMAIN_NAME & SECOND_DOMAIN & ") </font></span>") & red2.Item("body_h2") & red2.Item("body_h3")
                            Else
                                message_body1 += red2.Item("body_h") & red2.Item("body_h1") & red2.Item("body_h2") & red2.Item("body_h3")
                            End If
                        End While
                        red2.Close()
                        conn2.Close()
                    Next intLoopIndex
                End If
                message_body = message_body1
                nitc_m = "dns@modee.gov.jo"
                ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
                send_approv_EMail = True
                Dim str20 As String = txt_admin_mobile.Text
                Dim str2 As String = ""
                Dim str3 As String = ""
                Dim str4 As String = ""
                Dim str5 As String = ""
                str2 = Trim(str20)
                str3 = str2.Replace(" ", "")
                str4 = str3.Substring(str3.Length - 9, 9)
                str5 = "962" & str4
                Dim str11 As String = "Congratulations! Your application regarding the domain name registration under (.JO) has been approved."
                str11 &= " "
                str11 &= txt_DOMAIN_NAME.Text & Me.rbl_SECOND_DOMAIN.SelectedItem.ToString
                str11 &= "  www.dns.jo Tel:5300225"

                Dim lang As Languages = New Languages("en")
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & str11 & "&mobile_number=" & str5 & "&from=" & "domain.jo" & "&tag=" & 1

                ReusableCode.VisitURL(Url1)



            End While
            red1.Close()
            conn.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\domaindetaleaoriginal:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            lbl_error.Text = ex.ToString
            conn.Close()
        End Try


    End Function



End Class
