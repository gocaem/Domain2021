Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Domain2021.Toastr
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports RestSharp.Serialization.Json
Imports Microsoft.Security.Application
Imports Newtonsoft.Json
Imports System.Threading

Public Class DomainManage
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
            Fill_dropdownlists()
            If Not Session("Domain_ID") Is Nothing And txt_admin_id.Text <> "" Then
                Try
                    'view all domain details
                    ttab1.Visible = True
                    tablist.Visible = True
                    reset()
                    Dim reader As SqlDataReader
                    Dim connectionstr As DAL = New DAL()
                    Dim contentconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim contentcomm As New System.Data.SqlClient.SqlCommand("domain_detalesN", contentconn)
                    contentcomm.Parameters.AddWithValue("domain_id", Session("Domain_ID"))
                    contentconn.Open()
                    contentcomm.CommandType = System.Data.CommandType.StoredProcedure
                    reader = contentcomm.ExecuteReader()
                    While reader.Read
                        Button1.Visible = True
                        Domain_nameLabel.Text = reader("DOMAIN_NAME")
                        Session("DOMAIN_NAME") = reader("DOMAIN_NAME")
                        SecondDomain.SelectedValue = reader("SECOND_DOMAIN_ID")
                        Session("SECOND_DOMAIN_ID") = reader("SECOND_DOMAIN_ID")
                        If reader("ClassID") Is DBNull.Value = False Then
                            Classification.SelectedValue = reader("ClassID")
                            Session("ClassID") = reader("ClassID")
                        End If
                        If reader("Nationalno") Is DBNull.Value = False Then
                            NationalNo.Text = reader("Nationalno")
                            Session("Nationalno") = reader("Nationalno")
                        End If
                        If reader("Status_ID") Is DBNull.Value = False Then
                            Status.SelectedValue = reader("Status_ID")
                            Session("Status_ID") = reader("Status_ID")
                        End If
                        If reader("HideInfo") Is DBNull.Value = False Then
                            Session("HideInfo") = reader("HideInfo")
                            If reader("HideInfo") = True Then
                                CheckBox1.Checked = True
                            Else
                                CheckBox1.Checked = False
                            End If
                        Else
                            CheckBox1.Checked = False
                        End If
                        If reader("BILLING_CODE_ID") Is DBNull.Value = False Then
                            Label25.Text = reader("BILLING_CODE_ID")
                            Session("BILLING_CODE_ID") = reader("BILLING_CODE_ID")
                        End If
                        If reader("Description") Is DBNull.Value = False Then
                            OrgDetailTextBox.Text = reader("Description")
                            Session("OldDescription") = reader("Description")
                        End If
                        If reader("ORG_EMAIL") Is DBNull.Value = False Then
                            DEmail.Text = reader("ORG_EMAIL")
                            Session("ORG_EMAIL") = reader("ORG_EMAIL")
                        End If
                        If reader("dom_mob") Is DBNull.Value = False Then
                            DMobileTextBox.Text = reader("dom_mob")
                            Session("dom_mob") = reader("dom_mob")
                        End If

                        If reader("Testdomain") Is DBNull.Value = False Then
                            Session("Testdomain") = reader("Testdomain")
                            If reader("Testdomain") = True Then
                                TestDomain.Checked = True
                            Else
                                TestDomain.Checked = False
                            End If

                        End If
                        If reader("FREE") Is DBNull.Value = False Then
                            Session("FREE") = reader("FREE")
                            If reader("FREE") = "f" Then
                                CheckBoxFree.Checked = True
                            Else
                                CheckBoxFree.Checked = False
                            End If

                        End If
                        If reader("Domain_name") Is DBNull.Value = False Then
                            Session("Domain_name") = reader("Domain_name")
                            Domain_nameLabel.Text = reader("Domain_name")
                        End If
                        If reader("Second_domain_id") Is DBNull.Value = False Then
                            Session("Second_domain_id") = reader("Second_domain_id")
                            SecondDomain.SelectedValue = reader("Second_domain_id")
                        End If
                        If reader("NAME_SERVER_ID") = 0 Then

                            Label19.Text = "The Domain is Reserved"
                        Else
                            Label19.Text = "The Domain is Active"
                        End If
                        If reader("END_DATE") Is DBNull.Value = False Then
                            Session("END_DATE") = Convert.ToDateTime(reader("END_DATE")).ToString("yyy-MM-dd")
                            EndDate.Text = Convert.ToDateTime(reader("END_DATE")).ToString("yyy-MM-dd")
                        End If
                        If reader("Owner_Name") Is DBNull.Value = False Then
                            Session("Owner_Name") = reader("Owner_Name")
                            OwnerNameTextBox.Text = reader("Owner_Name")
                        End If
                        If reader("ORG_NAME") Is DBNull.Value = False Then
                            Session("ORG_NAME") = reader("ORG_NAME")
                            EntityTextBox.Text = reader("ORG_NAME")
                        End If
                        If reader("REG_DATE1") Is DBNull.Value = False Then
                            Session("REG_DATE1") = reader("REG_DATE1")
                            RadDateInput1.Text = Convert.ToDateTime(reader("REG_DATE1")).ToString("yyy-MM-dd")
                        End If
                        If reader("ORG_EMAIL") Is DBNull.Value = False Then
                            Session("ORG_EMAIL") = reader("ORG_EMAIL")
                            DEmail.Text = reader("ORG_EMAIL")
                        End If
                        If reader("TECH_EMAIL") Is DBNull.Value = False Then
                            Session("TECH_EMAIL") = reader("TECH_EMAIL")
                            TechEmailTextBox.Text = reader("TECH_EMAIL")
                        End If
                        If reader("tech_mob") Is DBNull.Value = False Then
                            Session("tech_mob") = reader("TECH_CONTACT")
                            TechMobileTextBox.Text = reader("tech_mob")
                        End If
                        If reader("TECH_CONTACTs_ID") Is DBNull.Value = False Then
                            Label27.Text = reader("TECH_CONTACTs_ID")
                        End If
                        If reader("TECH_CONTACT") Is DBNull.Value = False Then
                            Session("TECH_CONTACT") = reader("TECH_CONTACT")
                            TechTextBox.Text = reader("TECH_CONTACT")
                        End If
                        If reader("ADMIN_ID") Is DBNull.Value = False Then
                            Label26.Text = reader("ADMIN_ID")
                            Admin_id.Text = reader("ADMIN_ID")
                        End If
                        If reader("BILLING_EMAIL") Is DBNull.Value = False Then
                            Session("BILLING_EMAIL") = reader("BILLING_EMAIL")
                            BillEmail.Text = reader("BILLING_EMAIL")
                        End If
                        If reader("billing_mob") Is DBNull.Value = False Then
                            Session("billing_mob") = reader("billing_mob")
                            BillMobileText.Text = reader("billing_mob")
                        End If
                        If reader("BILLING_CONTACT") Is DBNull.Value = False Then
                            Session("BILLING_CONTACT") = reader("BILLING_CONTACT")
                            BillTextBox.Text = reader("BILLING_CONTACT")
                        End If


                        If reader("COMPANY_USER_NAME") Is DBNull.Value = False Then
                            Session("COMPANY_USER_NAME") = reader("COMPANY_USER_NAME")
                            username.Text = reader("COMPANY_USER_NAME")
                        End If
                        If reader("ad_mobile") Is DBNull.Value = False Then
                            Session("ad_mobile") = reader("ad_mobile")
                            Mobile.Text = reader("ad_mobile")
                        End If
                        If reader("ORG_PHONE") Is DBNull.Value = False Then
                            Session("ORG_PHONE") = reader("ORG_PHONE")
                            Phone.Text = reader("ORG_PHONE")
                        End If
                        If reader("ORG_FAX") Is DBNull.Value = False Then
                            Session("ORG_FAX") = reader("ORG_FAX")
                            Fax.Text = reader("ORG_FAX")
                        End If
                        If reader("EMAIL") Is DBNull.Value = False Then
                            Session("EMAIL") = reader("EMAIL")
                            Email.Text = reader("EMAIL")
                        End If
                        If reader("ADMIN_CONTACT") Is DBNull.Value = False Then
                            Session("ADMIN_CONTACT") = reader("ADMIN_CONTACT")
                            Name.Text = reader("ADMIN_CONTACT")
                        End If
                        If reader("addresses") Is DBNull.Value = False Then
                            Session("addresses") = reader("addresses")
                            Address.Text = reader("addresses")
                        End If
                    End While
                    contentconn.Close()
                    reader.Close()
                Catch ex As Exception
                    If Not (TypeOf ex Is ThreadAbortException) Then
                        File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                    End If
                End Try
            End If
        End If

    End Sub
    Sub reset()
        Admin_id.Text = ""
        Domain_id.Text = ""
        lbl_error.Text = ""
        Classification.ClearSelection()
        NationalNo.Text = ""
        Domain_nameLabel.Text = ""
        SecondDomain.ClearSelection()
        Status.ClearSelection()
        Label25.Text = ""
        OrgDetailTextBox.Text = ""
        DEmail.Text = ""
        DMobileTextBox.Text = ""
        Label19.Text = ""
        CheckBoxFree.Checked = False
        CheckBox1.Checked = False
        EndDate.Text = ""
        OwnerNameTextBox.Text = ""
        EntityTextBox.Text = ""
        RadDateInput1.Text = ""
        DMobileTextBox.Text = ""
        DEmail.Text = ""
        TechEmailTextBox.Text = ""
        TechMobileTextBox.Text = ""
        Label27.Text = ""
        TechTextBox.Text = ""
        Label26.Text = ""
        BillEmail.Text = ""
        BillMobileText.Text = ""
        BillTextBox.Text = ""
        TestDomain.Checked = False
        username.Text = ""
        Mobile.Text = ""
        Phone.Text = ""
        Fax.Text = ""
        Email.Text = ""
        Name.Text = ""
        Address.Text = ""
        Session("Domain_ID") = ""
        Session("Type") = ""
        Domain_id.Text = ""
        Admin_id.Text = ""



    End Sub

    Sub Fill_dropdownlists()
        Try


            Dim lang As String = "en"
            Dim connectionstr As DAL = New DAL()
            Dim Dns_class As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim Dns_classCmd As New SqlClient.SqlCommand("select_class_admin", Dns_class)
            Dim Dns_classReader As SqlClient.SqlDataReader
            Dns_class.Open()
            Dns_classCmd.CommandType = CommandType.StoredProcedure
            Dns_classReader = Dns_classCmd.ExecuteReader
            Classification.DataSource = Dns_classReader
            If lang = "ar" Then
                Classification.DataTextField = "ClassificationNameAr"
                Classification.DataValueField = "ClassificationID"
            Else
                Classification.DataTextField = "ClassificationNameEn"
                Classification.DataValueField = "ClassificationID"
            End If
            Classification.DataBind()
            Classification.Items.Insert(0, New ListItem("--" + "Classification" + "--", "0"))
            Dns_class.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub Classification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            Dim lang As New Languages(Session("lang"))
            Dim connectionstr As DAL = New DAL()
            Dim Dns_class As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim Dns_classCmd As New SqlClient.SqlCommand("select_classID", Dns_class)
            Dim Dns_classReader As SqlClient.SqlDataReader
            Dns_class.Open()
            Dns_classCmd.CommandType = CommandType.StoredProcedure
            Dns_classCmd.Parameters.AddWithValue("ClassificationID", Classification.SelectedItem.Value)
            Dns_classReader = Dns_classCmd.ExecuteReader
            While Dns_classReader.Read
                If Not Dns_classReader("Integration") Is DBNull.Value Then
                    If Dns_classReader("Integration") = True Then

                        DivNationalNo.Visible = True
                        Session("Type") = Dns_classReader("Type")
                    Else

                        DivNationalNo.Visible = True
                        Session("Type") = "None"
                    End If
                End If
            End While
            Dns_classReader.Close()
            Dns_class.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            Dim connectionstr As DAL = New DAL()
            If e.CommandName = "view" Then
                reset()
                'view all domain details
                ttab1.Visible = True
                tablist.Visible = True
                Dim reader As SqlDataReader
                Domain_id.Text = Session("Domain_ID")
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim DomainID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Domain_ID") = DomainID
                Domain_id.Text = DomainID

                Dim contentconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim contentcomm As New System.Data.SqlClient.SqlCommand("domain_detalesN", contentconn)
                contentcomm.Parameters.AddWithValue("domain_id", DomainID)
                contentconn.Open()
                contentcomm.CommandType = System.Data.CommandType.StoredProcedure
                reader = contentcomm.ExecuteReader()
                While reader.Read
                    Button1.Visible = True
                    Domain_nameLabel.Text = reader("DOMAIN_NAME")
                    Session("DOMAIN_NAME") = reader("DOMAIN_NAME")
                    SecondDomain.SelectedValue = reader("SECOND_DOMAIN_ID")
                    Session("SECOND_DOMAIN_ID") = reader("SECOND_DOMAIN_ID")
                    If reader("ClassID") Is DBNull.Value = False Then
                        Classification.SelectedValue = reader("ClassID")
                        Session("ClassID") = reader("ClassID")
                    End If
                    If reader("Nationalno") Is DBNull.Value = False Then
                        NationalNo.Text = reader("Nationalno")
                        Session("Nationalno") = reader("Nationalno")
                    End If
                    If reader("Status_ID") Is DBNull.Value = False Then
                        Status.SelectedValue = reader("Status_ID")
                        Session("Status_ID") = reader("Status_ID")
                    End If
                    If reader("HideInfo") Is DBNull.Value = False Then
                        Session("HideInfo") = reader("HideInfo")
                        If reader("HideInfo") = True Then
                            CheckBox1.Checked = True
                        Else
                            CheckBox1.Checked = False
                        End If
                    Else
                        CheckBox1.Checked = False
                    End If
                    If reader("BILLING_CODE_ID") Is DBNull.Value = False Then
                        Label25.Text = reader("BILLING_CODE_ID")
                        Session("BILLING_CODE_ID") = reader("BILLING_CODE_ID")
                    End If
                    If reader("Description") Is DBNull.Value = False Then
                        OrgDetailTextBox.Text = reader("Description")
                        Session("OldDescription") = reader("Description")
                    End If
                    If reader("ORG_EMAIL") Is DBNull.Value = False Then
                        DEmail.Text = reader("ORG_EMAIL")
                        Session("ORG_EMAIL") = reader("ORG_EMAIL")
                    End If
                    If reader("dom_mob") Is DBNull.Value = False Then
                        DMobileTextBox.Text = reader("dom_mob")
                        Session("dom_mob") = reader("dom_mob")
                    End If

                    If reader("Testdomain") Is DBNull.Value = False Then
                        Session("Testdomain") = reader("Testdomain")
                        If reader("Testdomain") = True Then
                            TestDomain.Checked = True
                        Else
                            TestDomain.Checked = False
                        End If

                    End If
                    If reader("FREE") Is DBNull.Value = False Then
                        Session("FREE") = reader("FREE")
                        If reader("FREE") = "f" Then
                            CheckBoxFree.Checked = True
                        Else
                            CheckBoxFree.Checked = False
                        End If

                    End If
                    If reader("Domain_name") Is DBNull.Value = False Then
                        Session("Domain_name") = reader("Domain_name")
                        Domain_nameLabel.Text = reader("Domain_name")
                    End If
                    If reader("Second_domain_id") Is DBNull.Value = False Then
                        Session("Second_domain_id") = reader("Second_domain_id")
                        SecondDomain.SelectedValue = reader("Second_domain_id")
                    End If
                    If reader("NAME_SERVER_ID") = 0 Then

                        Label19.Text = "The Domain is Reserved"
                    Else
                        Label19.Text = "The Domain is Active"
                    End If
                    If reader("END_DATE") Is DBNull.Value = False Then
                        Session("END_DATE") = Convert.ToDateTime(reader("END_DATE")).ToString("yyy-MM-dd")
                        EndDate.Text = Convert.ToDateTime(reader("END_DATE")).ToString("yyy-MM-dd")
                    End If
                    If reader("Owner_Name") Is DBNull.Value = False Then
                        Session("Owner_Name") = reader("Owner_Name")
                        OwnerNameTextBox.Text = reader("Owner_Name")
                    End If
                    If reader("ORG_NAME") Is DBNull.Value = False Then
                        Session("ORG_NAME") = reader("ORG_NAME")
                        EntityTextBox.Text = reader("ORG_NAME")
                    End If
                    If reader("REG_DATE1") Is DBNull.Value = False Then
                        Session("REG_DATE1") = reader("REG_DATE1")
                        RadDateInput1.Text = Convert.ToDateTime(reader("REG_DATE1")).ToString("yyy-MM-dd")
                    End If
                    If reader("ORG_EMAIL") Is DBNull.Value = False Then
                        Session("ORG_EMAIL") = reader("ORG_EMAIL")
                        DEmail.Text = reader("ORG_EMAIL")
                    End If
                    If reader("TECH_EMAIL") Is DBNull.Value = False Then
                        Session("TECH_EMAIL") = reader("TECH_EMAIL")
                        TechEmailTextBox.Text = reader("TECH_EMAIL")
                    End If
                    If reader("tech_mob") Is DBNull.Value = False Then
                        Session("tech_mob") = reader("TECH_CONTACT")
                        TechMobileTextBox.Text = reader("tech_mob")
                    End If
                    If reader("TECH_CONTACTs_ID") Is DBNull.Value = False Then
                        Label27.Text = reader("TECH_CONTACTs_ID")
                    End If
                    If reader("TECH_CONTACT") Is DBNull.Value = False Then
                        Session("TECH_CONTACT") = reader("TECH_CONTACT")
                        TechTextBox.Text = reader("TECH_CONTACT")
                    End If
                    If reader("ADMIN_ID") Is DBNull.Value = False Then
                        Label26.Text = reader("ADMIN_ID")
                        Admin_id.Text = reader("ADMIN_ID")
                    End If
                    If reader("BILLING_EMAIL") Is DBNull.Value = False Then
                        Session("BILLING_EMAIL") = reader("BILLING_EMAIL")
                        BillEmail.Text = reader("BILLING_EMAIL")
                    End If
                    If reader("billing_mob") Is DBNull.Value = False Then
                        Session("billing_mob") = reader("billing_mob")
                        BillMobileText.Text = reader("billing_mob")
                    End If
                    If reader("BILLING_CONTACT") Is DBNull.Value = False Then
                        Session("BILLING_CONTACT") = reader("BILLING_CONTACT")
                        BillTextBox.Text = reader("BILLING_CONTACT")
                    End If


                    If reader("COMPANY_USER_NAME") Is DBNull.Value = False Then
                        Session("COMPANY_USER_NAME") = reader("COMPANY_USER_NAME")
                        username.Text = reader("COMPANY_USER_NAME")
                    End If
                    If reader("ad_mobile") Is DBNull.Value = False Then
                        Session("ad_mobile") = reader("ad_mobile")
                        Mobile.Text = reader("ad_mobile")
                    End If
                    If reader("ORG_PHONE") Is DBNull.Value = False Then
                        Session("ORG_PHONE") = reader("ORG_PHONE")
                        Phone.Text = reader("ORG_PHONE")
                    End If
                    If reader("ORG_FAX") Is DBNull.Value = False Then
                        Session("ORG_FAX") = reader("ORG_FAX")
                        Fax.Text = reader("ORG_FAX")
                    End If
                    If reader("EMAIL") Is DBNull.Value = False Then
                        Session("EMAIL") = reader("EMAIL")
                        Email.Text = reader("EMAIL")
                    End If
                    If reader("ADMIN_CONTACT") Is DBNull.Value = False Then
                        Session("ADMIN_CONTACT") = reader("ADMIN_CONTACT")
                        Name.Text = reader("ADMIN_CONTACT")
                    End If
                    If reader("addresses") Is DBNull.Value = False Then
                        Session("addresses") = reader("addresses")
                        Address.Text = reader("addresses")
                    End If
                End While


                reader.Close()
            End If
            Dim ocon_uploadedFiles As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM_UploadedFiles As New Data.SqlClient.SqlCommand
            Dim odr_UploadedFiles As Data.SqlClient.SqlDataReader
            COMM_UploadedFiles.Connection = ocon_UploadedFiles
            ocon_UploadedFiles.Open()
            COMM_UploadedFiles.CommandText = "up_file"
            Dim Dom_id = Session("Domain_ID")
            COMM_UploadedFiles.Parameters.AddWithValue("did", Dom_id)
            COMM_UploadedFiles.CommandType = Data.CommandType.StoredProcedure
            odr_UploadedFiles = COMM_UploadedFiles.ExecuteReader
            Me.UploadedFiles.DataSource = odr_UploadedFiles
            UploadedFiles.DataBind()
            ocon_UploadedFiles.Close()
            odr_UploadedFiles.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        reset()
        GridView2.Visible = True
        ttab1.Visible = False
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        If Status.SelectedValue = "19" Or Status.SelectedValue = "18" Or Status.SelectedValue = "1" Or Status.SelectedValue = "2" Then
        Else
            If EndDate.Text Is Nothing Then
                lbl_error.Text = "End date is required!"
                ShowToastr(Page, "End date is required!..", "Required!", "warning")
                Exit Sub
            Else
                lbl_error.Text = ""
            End If

        End If
        Try
            'update billing
            If Page.IsValid Then
                Dim connectionstr As DAL = New DAL()
                Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmd2 As New SqlClient.SqlCommand()
                ocmd2.Connection = ocon2
                ocon2.Open()
                ocmd2.CommandText = "update_b"
                ocmd2.CommandType = CommandType.StoredProcedure
                ocmd2.Parameters.AddWithValue("b_c", Server.HtmlEncode(BillTextBox.Text))
                ocmd2.Parameters.AddWithValue("oldb_c", Session("BILLING_CONTACT"))
                ocmd2.Parameters.AddWithValue("oldemail", Session("BILLING_EMAIL"))
                ocmd2.Parameters.AddWithValue("oldmob", Session("billing_mob"))
                ocmd2.Parameters.AddWithValue("Userid", Session("Users_ID"))
                ocmd2.Parameters.AddWithValue("mob", Server.HtmlEncode(BillMobileText.Text))
                ocmd2.Parameters.AddWithValue("email", Server.HtmlEncode(BillEmail.Text))
                ocmd2.Parameters.AddWithValue("IPaddress", ReusableCode.GetIPAddress)
                ocmd2.Parameters.AddWithValue("ID", Label25.Text)
                ocmd2.ExecuteNonQuery()

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
                ocmdADNIN.Parameters.AddWithValue("admin_id", Label26.Text)
                ocmdADNIN.ExecuteNonQuery()
                'update Technical 
                Dim oconTech As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdTech As New SqlClient.SqlCommand()
                ocmdTech.Connection = oconTech
                oconTech.Open()
                ocmdTech.CommandText = "update_proc_tech"
                ocmdTech.CommandType = CommandType.StoredProcedure
                ocmdTech.Parameters.AddWithValue("con", Server.HtmlEncode(TechTextBox.Text))
                ocmdTech.Parameters.AddWithValue("mob", Server.HtmlEncode(TechMobileTextBox.Text))
                ocmdTech.Parameters.AddWithValue("email", Server.HtmlEncode(TechEmailTextBox.Text))
                ocmdTech.Parameters.AddWithValue("old_c", Session("TECH_CONTACT"))
                ocmdTech.Parameters.AddWithValue("oldemail", Session("TECH_EMAIL"))
                ocmdTech.Parameters.AddWithValue("oldmob", Session("tech_mob"))
                ocmdTech.Parameters.AddWithValue("IPadd", ReusableCode.GetIPAddress)
                ocmdTech.Parameters.AddWithValue("Userid", Session("Users_ID"))
                ocmdTech.Parameters.AddWithValue("ID", Label27.Text)
                ocmdTech.ExecuteNonQuery()
                'update main data
                If (Status.SelectedValue <> Session("Status_ID")) Then
                    'logstatus
                    Dim comm_log As New Data.SqlClient.SqlCommand
                    Dim ocon_log As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))

                    comm_log.Connection = conn_log
                    conn_log.Open()
                    comm_log.CommandText = "insert_log3"
                    comm_log.Parameters.AddWithValue("domain_id", Session("Domain_ID"))
                    comm_log.Parameters.AddWithValue("status", Status.SelectedValue)
                    comm_log.Parameters.AddWithValue("date", Now)
                    comm_log.Parameters.AddWithValue("comment", "update domain data")
                    comm_log.Parameters.AddWithValue("admin", Session("Users_ID"))
                    comm_log.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
                    comm_log.CommandType = Data.CommandType.StoredProcedure
                    comm_log.ExecuteNonQuery()
                    conn_log.Close()
                End If
                If Not EndDate.Text Is Nothing And Not EndDate.Text = "" Then
                    Dim oconDomain As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdDomain As New SqlClient.SqlCommand()
                    ocmdDomain.Connection = oconDomain
                    oconDomain.Open()
                    ocmdDomain.CommandText = "update_domain_MainData"
                    ocmdDomain.CommandType = CommandType.StoredProcedure
                    ocmdDomain.Parameters.AddWithValue("Domain_name", Server.HtmlEncode(Domain_nameLabel.Text).ToLower())
                    ocmdDomain.Parameters.AddWithValue("olddomain_name", Server.HtmlEncode(Session("DOMAIN_NAME")).ToLower())
                    ocmdDomain.Parameters.AddWithValue("Second_name", Server.HtmlEncode(SecondDomain.SelectedValue))
                    ocmdDomain.Parameters.AddWithValue("oldsecond_domain", Server.HtmlEncode(Session("SECOND_DOMAIN_ID")))
                    ocmdDomain.Parameters.AddWithValue("ClassID", Server.HtmlEncode(Classification.SelectedValue))
                    ocmdDomain.Parameters.AddWithValue("oldClassID", Server.HtmlEncode(Server.HtmlEncode(Session("ClassID"))))
                    ocmdDomain.Parameters.AddWithValue("address", Server.HtmlEncode(Address.Text))
                    ocmdDomain.Parameters.AddWithValue("oldaddress", Server.HtmlEncode(Server.HtmlEncode(Session("addresses"))))
                    ocmdDomain.Parameters.AddWithValue("Nationalno", Server.HtmlEncode(NationalNo.Text))
                    ocmdDomain.Parameters.AddWithValue("OldNationalno", Server.HtmlEncode(Session("Nationalno")))
                    ocmdDomain.Parameters.AddWithValue("Status_ID", Status.SelectedValue)
                    ocmdDomain.Parameters.AddWithValue("oldstatus_id", Session("Status_ID"))
                    ocmdDomain.Parameters.AddWithValue("Description", Server.HtmlEncode(OrgDetailTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("OldDescription", Server.HtmlEncode(Session("OldDescription")))
                    ocmdDomain.Parameters.AddWithValue("owner", Server.HtmlEncode(OwnerNameTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("Oldowner", Server.HtmlEncode(Session("Owner_Name")))
                    ocmdDomain.Parameters.AddWithValue("ORG_EMAIL", Server.HtmlEncode(DEmail.Text))
                    ocmdDomain.Parameters.AddWithValue("oldemail", Session("ORG_EMAIL"))
                    ocmdDomain.Parameters.AddWithValue("fax", Server.HtmlEncode(Fax.Text))
                    ocmdDomain.Parameters.AddWithValue("oldfax", IIf(Session("ORG_FAX") = Nothing, "", Session("ORG_FAX")))
                    ocmdDomain.Parameters.AddWithValue("MOBILE", Server.HtmlEncode(DMobileTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("oldmobile", Server.HtmlEncode(Session("dom_mob")))
                    ocmdDomain.Parameters.AddWithValue("hideinfo", CheckBox1.Checked)
                    If (CheckBoxFree.Checked) Then
                        ocmdDomain.Parameters.AddWithValue("FREE", "f")
                        ocmdDomain.Parameters.AddWithValue("oldFREE", Session("FREE"))
                    Else
                        ocmdDomain.Parameters.AddWithValue("FREE", "nf")
                        ocmdDomain.Parameters.AddWithValue("oldFREE", Session("FREE"))
                    End If
                    ocmdDomain.Parameters.AddWithValue("Testdomain", TestDomain.Checked)
                    ocmdDomain.Parameters.AddWithValue("oldTestdomain", Session("Testdomain"))
                    ocmdDomain.Parameters.AddWithValue("enddate", EndDate.Text)
                    ocmdDomain.Parameters.AddWithValue("oldenddate", Session("END_DATE"))
                    ocmdDomain.Parameters.AddWithValue("regdate", RadDateInput1.Text)
                    ocmdDomain.Parameters.AddWithValue("oldregdate", Session("REG_DATE1"))
                    ocmdDomain.Parameters.AddWithValue("org_name", EntityTextBox.Text)
                    ocmdDomain.Parameters.AddWithValue("Oldorgname", Session("ORG_NAME"))
                    ocmdDomain.Parameters.AddWithValue("did", Session("Domain_ID"))
                    ocmdDomain.Parameters.AddWithValue("Ipaddress", ReusableCode.GetIPAddress)
                    ocmdDomain.Parameters.AddWithValue("UserId", Session("Users_ID"))
                    ocmdDomain.ExecuteNonQuery()
                    ocon2.Close()
                    oconDomain.Close()
                    oconADMIN.Close()
                    oconTech.Close()
                    GridView2.DataBind()


                Else
                    Dim oconDomain As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdDomain As New SqlClient.SqlCommand()
                    ocmdDomain.Connection = oconDomain
                    oconDomain.Open()
                    ocmdDomain.CommandText = "update_domain_MainData2"
                    ocmdDomain.CommandType = CommandType.StoredProcedure
                    ocmdDomain.Parameters.AddWithValue("Domain_name", Server.HtmlEncode(Domain_nameLabel.Text).ToLower())
                    ocmdDomain.Parameters.AddWithValue("olddomain_name", Server.HtmlEncode(Session("DOMAIN_NAME")).ToLower())
                    ocmdDomain.Parameters.AddWithValue("Second_name", Server.HtmlEncode(SecondDomain.SelectedValue))
                    ocmdDomain.Parameters.AddWithValue("oldsecond_domain", Server.HtmlEncode(Session("SECOND_DOMAIN_ID")))
                    ocmdDomain.Parameters.AddWithValue("ClassID", Server.HtmlEncode(Classification.SelectedValue))
                    ocmdDomain.Parameters.AddWithValue("oldClassID", Server.HtmlEncode(Server.HtmlEncode(Session("ClassID"))))
                    ocmdDomain.Parameters.AddWithValue("address", Server.HtmlEncode(Address.Text))
                    ocmdDomain.Parameters.AddWithValue("oldaddress", Server.HtmlEncode(Server.HtmlEncode(Session("addresses"))))
                    ocmdDomain.Parameters.AddWithValue("Nationalno", Server.HtmlEncode(NationalNo.Text))
                    ocmdDomain.Parameters.AddWithValue("OldNationalno", Server.HtmlEncode(Session("Nationalno")))
                    ocmdDomain.Parameters.AddWithValue("Status_ID", Status.SelectedValue)
                    ocmdDomain.Parameters.AddWithValue("oldstatus_id", Session("Status_ID"))
                    ocmdDomain.Parameters.AddWithValue("Description", Server.HtmlEncode(OrgDetailTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("OldDescription", Server.HtmlEncode(Session("OldDescription")))
                    ocmdDomain.Parameters.AddWithValue("owner", Server.HtmlEncode(OwnerNameTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("Oldowner", Server.HtmlEncode(Session("Owner_Name")))
                    ocmdDomain.Parameters.AddWithValue("ORG_EMAIL", Server.HtmlEncode(DEmail.Text))
                    ocmdDomain.Parameters.AddWithValue("oldemail", Session("ORG_EMAIL"))
                    ocmdDomain.Parameters.AddWithValue("fax", Server.HtmlEncode(Fax.Text))
                    ocmdDomain.Parameters.AddWithValue("oldfax", If(Session("ORG_FAX") = Nothing, "", Session("ORG_FAX")))
                    ocmdDomain.Parameters.AddWithValue("MOBILE", Server.HtmlEncode(DMobileTextBox.Text))
                    ocmdDomain.Parameters.AddWithValue("hideinfo", CheckBox1.Checked)
                    ocmdDomain.Parameters.AddWithValue("oldmobile", Server.HtmlEncode(Session("dom_mob")))
                    If (CheckBoxFree.Checked) Then
                        ocmdDomain.Parameters.AddWithValue("FREE", "f")
                        ocmdDomain.Parameters.AddWithValue("oldFREE", Session("FREE"))
                    Else
                        ocmdDomain.Parameters.AddWithValue("FREE", "nf")
                        ocmdDomain.Parameters.AddWithValue("oldFREE", Session("FREE"))
                    End If
                    ocmdDomain.Parameters.AddWithValue("Testdomain", TestDomain.Checked)
                    ocmdDomain.Parameters.AddWithValue("oldTestdomain", Convert.ToBoolean(Session("Testdomain")))
                    ocmdDomain.Parameters.AddWithValue("regdate", RadDateInput1.Text)
                    ocmdDomain.Parameters.AddWithValue("oldregdate", Session("REG_DATE1"))
                    ocmdDomain.Parameters.AddWithValue("org_name", EntityTextBox.Text)
                    ocmdDomain.Parameters.AddWithValue("Oldorgname", Session("ORG_NAME"))
                    ocmdDomain.Parameters.AddWithValue("did", Session("Domain_ID"))
                    ocmdDomain.Parameters.AddWithValue("Ipaddress", ReusableCode.GetIPAddress)
                    ocmdDomain.Parameters.AddWithValue("UserId", Session("Users_ID"))
                    ocmdDomain.ExecuteNonQuery()
                    ocon2.Close()
                    oconDomain.Close()
                    oconADMIN.Close()
                    oconTech.Close()
                    GridView2.DataBind()
                End If

                ShowToastr(Page, "Updated Successfully..", "Done", "success")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try


    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Protected Sub NationalNo_TextChanged(sender As Object, e As EventArgs)
        Try
            GridView1.Visible = False
            GridView3.Visible = False
            Dim lang As New Languages(Session("lang"))
            If Session("Type").ToString.Trim = "mit" Then
                Dim RS As ServiceReference1.CentralRegistration = New ServiceReference1.CentralRegistration()
                Dim TM() As ServiceReference1.TradeMark
                Dim client As ServiceReference1.MITServiceClient = New ServiceReference1.MITServiceClient()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    RS = client.getIndividualRegistry(NationalNo.Text)
                End Using


                If RS.HasData = False Then
                    ShowToastr(Page, "Wrong NatNo..", "Error", "Error")
                Else
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Text = "Description"
                    If RS.strRegistryAddress = "_" Then
                        OrgDetailTextBox.Text = Server.HtmlEncode(RS.strRegistryName)
                    Else
                        OrgDetailTextBox.Text = Server.HtmlEncode(RS.strRegistryAddress)
                    End If

                    TM = client.getTradeMark(RS.decRegistryNo, 6)
                    If Not TM.Length = 0 Then
                        If TM(0).decCompanyNO IsNot Nothing Then
                            Div3.Visible = True

                            Label12.Text = lang.TMs
                            Label12.Style.Add("Font-Family", lang.fonta)
                            GridView1.Visible = True
                            GridView1.DataSource = TM
                            GridView1.Columns(0).HeaderText = lang.TM_AR
                            GridView1.Columns(1).HeaderText = lang.TM_En
                            GridView1.Style.Add("Font-family", lang.fonta)
                            GridView1.DataBind()
                        Else
                            Label12.Visible = False
                            GridView1.Visible = False
                        End If
                    End If
                End If
            ElseIf Session("Type").ToString.Trim = "cspd" Then
                Dim client As ServiceReference3.VitalEventsClient = New ServiceReference3.VitalEventsClient()
                Dim per As ServiceReference3.PERSONAL = New ServiceReference3.PERSONAL()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                    per = client.gePersonal(NationalNo.Text)
                End Using
                If per Is Nothing Then
                    ShowToastr(Page, "wrong nat no", "Error", "Error")
                Else
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Text = "Description"
                    OrgDetailTextBox.Text = Server.HtmlEncode(per.ANAME1 + " " + per.ANAME2 + " " + per.ANAME3 + " " + per.ANAME4)
                End If
            ElseIf Session("Type").ToString.Trim = "ccd" Then

                Dim client As ServiceReference2.CompanyClient = New ServiceReference2.CompanyClient()
                Dim comp As ServiceReference2.Company = New ServiceReference2.Company()
                client.ClientCredentials.UserName.UserName = lang.clientUsername
                client.ClientCredentials.UserName.Password = lang.clientPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    comp = client.getCompanyByNo(NationalNo.Text)
                End Using
                If comp.ID_NUMBER.ToString = "" Then
                    OrgDetailDiv.Visible = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno, ToastPosition.TopCenter)
                ElseIf comp.ID_NUMBER.ToString <> "" Then
                    OrgDetailDiv.Visible = True
                    OrgDetailTextBox.Text = Server.HtmlEncode(comp.COMPANAME)

                    Dim ccdname() As ServiceReference1.ccd_name
                    Dim TM() As ServiceReference1.Logo_mark
                    Dim client2 As ServiceReference1.MITServiceClient = New ServiceReference1.MITServiceClient()
                    client2.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                    client2.ClientCredentials.UserName.Password = lang.clientg2bPassword
                    Using scope = New OperationContextScope(client2.InnerChannel)
                        Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                        requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                        OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                        requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                        OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                        ccdname = client2.getccd_name(NationalNo.Text)

                        If Not ccdname Is Nothing Then
                            TM = client2.getccd_mark(ccdname(0).Regcn, 2)
                            Div3.Visible = True
                            OrgDetailL.Text = lang.TMs
                            OrgDetailL.Style.Add("Font-Family", lang.fonta)
                            GridView2.Visible = True
                            GridView2.DataSource = TM
                            GridView2.Columns(0).HeaderText = lang.TM_AR
                            GridView2.Columns(1).HeaderText = lang.TM_En
                            GridView2.Style.Add("Font-family", lang.fonta)
                            GridView2.DataBind()
                        End If
                    End Using
                Else
                    Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno2, lang.wrongnatno2, ToastPosition.TopCenter)
                    GridView2.Visible = False
                    GridView2.Visible = False
                End If
            ElseIf Session("Type").ToString.Trim = "Gov" Then
                Dim client = New RestClient("https://api-gateway.g2g.gsb.gov.jo:9443/porg-gsb/g2g-catalog/govAPI/GetEntityByNationalNumber")
                client.Timeout = -1
                Dim request = New RestRequest(Method.POST)
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(senderX, certificate, chain, sslPolicyErrors) True
                request.AddHeader("X-IBM-Client-Id", lang.g2gID)
                request.AddHeader("X-IBM-Client-Secret", lang.g2gsecret)
                request.AddHeader("Content-Type", "application/json")
                request.AddHeader("Cookie", "BIGipServer~GSB-MGMT~GSB-Stg-API-Gateway_9443-Pool=rd13o00000000000000000000ffff0a001a6do9443")
                Dim body = "{
                            " & vbLf & "  ""GovNationalNo"": """ & Server.HtmlEncode(NationalNo.Text) & """,
                            " & vbLf & "}"
                request.AddParameter("application/json", body, ParameterType.RequestBody)
                Dim response As IRestResponse = client.Execute(request)
                Dim myDeserializedClass As List(Of GoVresult) = JsonConvert.DeserializeObject(Of List(Of GoVresult))(response.Content)
                OrgDetailTextBox.Text = myDeserializedClass(0).Name_Ar
            ElseIf Session("Type").ToString.Trim = "mosd" Then
                Dim client As ServiceReference4.MOSDSrvV2Client = New ServiceReference4.MOSDSrvV2Client()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Dim Obj As ServiceReference4.Result()
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                    Obj = client.GetCSOSMIT(NationalNo.Text)
                End Using
                If Not Obj Is Nothing Then
                    OrgDetailTextBox.Text = Server.HtmlEncode(Obj(0).ASSNAME1)
                Else
                    ShowToastr(Page, "wrong nat no", "Error", "Error")
                End If
            ElseIf Session("Type").ToString.Trim = "psd" Then
                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim client = New RestClient("https://api-gateway.g2g.gsb.gov.jo:9443/porg-gsb/g2g-catalog/api")
                client.Timeout = -1
                Dim request = New RestRequest(Method.POST)
                request.AddHeader("X-IBM-Client-Secret", lang.g2gsecret)
                request.AddHeader("X-IBM-Client-Id", lang.g2gID)
                request.AddHeader("Authorization", lang.Auth)
                request.AddHeader("Content-Type", "application/json")
                Dim body = "{ " + "  ""nationalNo"": " & NationalNo.Text & "}"
                request.AddJsonBody(body)
                Dim response As IRestResponse = client.Execute(request)

                Dim deserial As JsonDeserializer = New JsonDeserializer()


                If response.Content = Nothing Then
                    ShowToastr(Page, "Wrong nat no", "Error", "Error")
                Else

                    Dim finalResult As RRoot.Root = New JsonDeserializer().Deserialize(Of RRoot.Root)(response)
                    If finalResult.status = True Then
                        Dim datenow As Date = Now().ToString("dd-MMM-yy", CultureInfo.CreateSpecificCulture("en-US"))
                        If finalResult.data(0).document(finalResult.data(0).document.Count - 1).EXPIRY_DATE <> Nothing Then

                            Dim expdate As Date = finalResult.data(0).document(finalResult.data(0).document.Count - 1).EXPIRY_DATE
                            If expdate < datenow Then
                                OrgDetailDiv.Visible = False

                                Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.expiredID, ToastPosition.TopCenter)
                            Else

                                OrgDetailTextBox.Text = finalResult.data(0).E_FULL_NAME
                                OrgDetailDiv.Visible = True
                            End If

                        End If
                    Else

                        Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno3, ToastPosition.TopCenter)
                    End If
                End If
            ElseIf Session("Type").ToString.Trim = "free" Then

                OrgDetailTextBox.Text = ""
                GridView3.Visible = False

                Try
                    Dim client = New RestClient("https://api-gateway.g2g.gsb.gov.jo:9443/porg-gsb/g2g-catalog/freezonesservice")
                    client.Timeout = -1
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    Dim request = New RestRequest(Method.POST)
                    request.AddHeader("X-IBM-Client-Id", lang.g2gID)
                    request.AddHeader("X-IBM-Client-Secret", lang.g2gsecret)
                    request.AddHeader("Content-Type", "application/xml")
                    Dim body = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
                     " & vbLf & " <soapenv:Header>
                     " & vbLf & "  <!-- The Security element should be removed if WS-Security is not enabled on the SOAP target-url -->
                     " & vbLf & "  <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                     " & vbLf & "   <wsse:UsernameToken>
                     " & vbLf & "    <wsse:Username>string</wsse:Username>
                     " & vbLf & "    <wsse:Password>string</wsse:Password>
                     " & vbLf & "    <wsse:Nonce EncodingType=""string"">string</wsse:Nonce>
                     " & vbLf & "    <wsu:Created>string</wsu:Created>
                     " & vbLf & "   </wsse:UsernameToken>
                     " & vbLf & "   <wsu:Timestamp wsu:Id=""string"">
                     " & vbLf & "    <wsu:Created>string</wsu:Created>
                     " & vbLf & "    <wsu:Expires>string</wsu:Expires>
                     " & vbLf & "   </wsu:Timestamp>
                     " & vbLf & "  </wsse:Security>
                     " & vbLf & " </soapenv:Header>
                     " & vbLf & " <soapenv:Body>
                     " & vbLf & "  <tns:getCommercialRecordRequest xmlns:tns=""http://tempuri.org/""><!-- mandatory -->
                     " & vbLf & "   <tns:estIdNo><!-- mandatory -->" & NationalNo.Text & "</tns:estIdNo>
                     " & vbLf & "  </tns:getCommercialRecordRequest>
                     " & vbLf & " </soapenv:Body>
                     " & vbLf & "</soapenv:Envelope>"
                    request.AddParameter("application/xml", body, ParameterType.RequestBody)
                    Dim response As IRestResponse = client.Execute(request)
                    Console.WriteLine(response.Content)
                    Dim xml As System.Xml.XmlDocument = New System.Xml.XmlDocument()
                    xml.LoadXml(response.Content)
                    Dim xmlnsManager As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(xml.NameTable)
                    xmlnsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
                    Dim xml_new As System.Xml.XmlDocument = New System.Xml.XmlDocument()

                    For Each xNode2 As System.Xml.XmlNode In xml.GetElementsByTagName("estName")
                        OrgDetailTextBox.Text = xNode2.InnerText
                        OrgDetailDiv.Visible = True
                        OrgDetailTextBox.Visible = True
                        OrgDetailL.Visible = True
                    Next


                Catch ex As Exception
                    Toastr.ShowToast(Me, ToastType.Warning, lang.cannotret, lang.Note, ToastPosition.TopCenter)
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Visible = True
                End Try
            ElseIf Session("Type").ToString.Trim = "jcc" Then
                Dim client As ServiceReference5.JCCSrvV1Client = New ServiceReference5.JCCSrvV1Client()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    Dim Obj As ServiceReference5.Result()
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                    Try
                        Obj = client.GetAssociationsData(NationalNo.Text)

                        If Not Obj Is Nothing Then
                            OrgDetailTextBox.Text = Server.HtmlEncode(Obj(0).AssocationName1)
                        Else
                            OrgDetailDiv.Visible = False
                            ShowToastr(Page, "wrong nat no", "Error", "Error")
                        End If
                    Catch ex As Exception
                        ShowToastr(Page, "error", "Error", "Error")
                        OrgDetailDiv.Visible = True
                        OrgDetailL.Text = "Description"
                    End Try

                End Using
                OrgDetailDiv.Visible = True
                OrgDetailL.Text = "Description"

            Else
                OrgDetailDiv.Visible = True
                OrgDetailL.Text = "Description"

            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            ShowToastr(Page, "error", "Error", "Error")
            OrgDetailDiv.Visible = True
            OrgDetailL.Text = "Description"
        End Try
    End Sub


    Protected Sub SendEmail_Click(sender As Object, e As EventArgs)
        Dim title As String = "اسم المستخدم الخاص بحسابك"
        Dim msg As String = "<table align='center' id='tdd' runat='server' style='width: 100%; margin-left: 0px;'>
                                <tbody>
                                    <tr>
                                        <td  <td Style='text-align: center;'></td>
                                        <td Style='text-align: center;'><img alt='' class='auto-style3' height='150' width='170' src='http://www.dns.jo/logo.png'><br>
                                            <br>
                                                <b>وزارة الاقتصاد الرقمي والريادة<br>
                                            Ministry of Digital Economy and Entrepreneurship</b></td>
                                
                                    </tr>
                                    <tr style='direction:rtl;text-align:right'>
                                        <td class='auto-style5'>&nbsp;</td>
                                        <td class='auto-style7'>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr> <tr style='direction:rtl;text-align:right'><td colspan=3 style='direction:rtl;text-align:right'>عميلنا العزيز,</td></tr></tr>"
        msg += "<tr style='direction:rtl;text-align:right'><td colspan=3 style='direction:rtl;text-align:right'> اسم المستخدم الخاص بحسابك هو:</td></tr>"
        msg += "<tr style='direction:rtl;text-align:right'><td colspan=3 style='direction:rtl;text-align:right'>" + username.Text + "</td></tr>"
        msg += "<tr style='direction:rtl;text-align:right'><td colspan=3 style='direction:rtl;text-align:right'>فريق النطاقات الأردني </td></tr><br><tbody></table> "
        ReusableCode.sndMail(Email.Text, "dns@modee.gov.jo", title, msg)
        ShowToastr(Page, "Sent Successfully..", "Done", "success")
    End Sub

    Protected Sub SendSMS_Click(sender As Object, e As EventArgs)
        Send_SMS(username.Text)
    End Sub
    Sub Send_SMS(ByVal username As String)
        Try


            Dim lang As New Languages(Session("en"))
        Dim str12 As String = Server.HtmlEncode(Mobile.Text)
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim int As Integer = 0
        Dim str4 As String = ""
        Dim str5 As String = ""
        str2 = Trim(str12)
        str3 = str2.Replace(" ", "")
        str3 = str3.Replace(".", "")
        str3 = str3.Replace(".", "+")
        If str3.Length >= 9 Then
            str4 = str3.Substring(str3.Length - 9, 9)
        End If
            If str4.Length >= 9 Then
                str5 = "962" & str4
                Dim str11 As String = "Dear Esteemed Client,your account username is:"
                str11 &= "  " & username & "  "
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & str11 & "&mobile_number=" & str5 & "&from=" & "domain.jo" & "&tag=" & 1
                ReusableCode.VisitURL(Url1)
                ShowToastr(Page, "Sent Successfully..", "Done", "success")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub SendEmailEn_Click(sender As Object, e As EventArgs)
        Try


            Dim title As String = "Your Account Username"
        Dim msg As String = "<table align='center' id='tdd' runat='server' style='width: 100%; margin-left: 0px;'>
                                <tbody>
                                    <tr>
                                        <td class='auto-style4'></td>
                                        <td class='auto-style6'><img alt='' class='auto-style3' height='150' width='170' src='http://www.dns.jo/logo.png'><br>
                                            <br>
                                                <b>وزارة الاقتصاد الرقمي والريادة<br>
                                            Ministry of Digital Economy and Entrepreneurship</b></td>
                                    <td></td>
                                    </tr>
                <tr style='direction:ltr;text-align:left'><td colspan=3>Dear Esteemed Client,</td></tr>"
        msg += "<tr style='direction:ltr;text-align:left'><td colspan=3>Your account username is:" + username.Text + "</td></tr>"
        msg += "<tr style='direction:ltr;text-align:left'><td colspan=3>DNS/.الاردن Division</td></tr><br><tbody></table> "
        ReusableCode.sndMail(Email.Text, "dns@modee.gov.jo", title, msg)
            ShowToastr(Page, "Sent Successfully..", "Done", "success")
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\DomainManage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class