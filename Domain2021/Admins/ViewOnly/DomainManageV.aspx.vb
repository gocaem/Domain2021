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
Imports System.Threading

Public Class DomainManageV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
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
                        Domain_name.Text = reader("DOMAIN_NAME")
                        SecondDomain.SelectedValue = reader("SECOND_DOMAIN_ID")
                        If reader("ClassID") Is DBNull.Value = False Then
                            Classification.SelectedValue = reader("ClassID")
                        End If
                        If reader("Nationalno") Is DBNull.Value = False Then
                            NationalNo.Text = reader("Nationalno")
                        End If
                        If reader("Status_ID") Is DBNull.Value = False Then
                            Status.SelectedValue = reader("Status_ID")
                        End If
                        If reader("BILLING_CODE_ID") Is DBNull.Value = False Then
                            Label25.Text = reader("BILLING_CODE_ID")
                        End If
                        If reader("Description") Is DBNull.Value = False Then
                            OrgDetailTextBox.Text = reader("Description")
                        End If
                        If reader("ORG_EMAIL") Is DBNull.Value = False Then
                            DEmail.Text = reader("ORG_EMAIL")
                        End If
                        If reader("dom_mob") Is DBNull.Value = False Then
                            DMobileTextBox.Text = reader("dom_mob")
                        End If
                        If reader("NAME_SERVER_ID") = 0 Then
                            Label19.Text = "The Domain is Reserved"
                        Else
                            Label19.Text = "The Domain is Active"
                        End If
                        If reader("FREE") Is DBNull.Value = False Then
                            If reader("FREE") = "f" Then
                                CheckBoxFree.Checked = True
                            Else
                                CheckBoxFree.Checked = False
                            End If

                        End If

                        If reader("END_DATE") Is DBNull.Value = False Then
                            EndDate.Text = reader("END_DATE")
                        End If
                        If reader("Owner_Name") Is DBNull.Value = False Then
                            OwnerNameTextBox.Text = Server.HtmlDecode(reader("Owner_Name"))
                        End If
                        If reader("ORG_NAME") Is DBNull.Value = False Then
                            EntityTextBox.Text = reader("ORG_NAME")
                        End If
                        If reader("REG_DATE1") Is DBNull.Value = False Then
                            RadDateInput1.Text = reader("REG_DATE1")
                        End If
                        If reader("dom_mob") Is DBNull.Value = False Then
                            DMobileTextBox.Text = reader("dom_mob")
                        End If
                        If reader("ORG_EMAIL") Is DBNull.Value = False Then
                            DEmail.Text = reader("ORG_EMAIL")
                        End If
                        If reader("TECH_EMAIL") Is DBNull.Value = False Then
                            TechEmailTextBox.Text = reader("TECH_EMAIL").ToString.TrimEnd()
                        End If
                        If reader("tech_mob") Is DBNull.Value = False Then
                            TechMobileTextBox.Text = reader("tech_mob")
                        End If
                        If reader("TECH_CONTACTs_ID") Is DBNull.Value = False Then
                            Label27.Text = reader("TECH_CONTACTs_ID")
                        End If
                        If reader("TECH_CONTACT") Is DBNull.Value = False Then
                            TechTextBox.Text = reader("TECH_CONTACT")
                        End If
                        If reader("ADMIN_ID") Is DBNull.Value = False Then
                            Label26.Text = reader("ADMIN_ID")
                        End If
                        If reader("BILLING_EMAIL") Is DBNull.Value = False Then
                            BillEmail.Text = reader("BILLING_EMAIL").ToString.TrimEnd()
                        End If
                        If reader("billing_mob") Is DBNull.Value = False Then
                            BillMobileText.Text = reader("billing_mob")
                        End If
                        If reader("BILLING_CONTACT") Is DBNull.Value = False Then
                            BillTextBox.Text = reader("BILLING_CONTACT")
                        End If
                        If reader("TestDomain") Is DBNull.Value = False Then
                            TestDomain.Checked = reader("TestDomain")
                        End If
                        Try
                            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                            Dim ocmd2 As New SqlClient.SqlCommand()
                            Dim reader2 As SqlClient.SqlDataReader
                            ocmd2.Connection = ocon2
                            ocon2.Open()
                            ocmd2.CommandText = "PASS"
                            ocmd2.CommandType = CommandType.StoredProcedure
                            ocmd2.Parameters.AddWithValue("admin_id", reader("ADMIN_ID"))
                            reader2 = ocmd2.ExecuteReader()
                            If reader2.HasRows = True Then

                                While reader2.Read
                                    username.Text = reader2("Company_user_name")
                                    Mobile.Text = reader2("Mobile")
                                    Phone.Text = reader2("Phone")
                                    Fax.Text = reader2("Fax")
                                    Email.Text = reader2("Email")
                                    Name.Text = reader2("ADMIN_CONTACT")
                                    Address.Text = reader2("ADDRESSES")
                                End While

                            End If
                            reader2.Close()
                            ocon2.Close()

                        Catch ex As Exception

                        End Try
                    End While
                    contentconn.Close()
                    reader.Close()
                Catch ex As Exception
                    If Not (TypeOf ex Is ThreadAbortException) Then
                        File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
        Domain_name.Text = ""
        SecondDomain.ClearSelection()
        Status.ClearSelection()
        Label25.Text = ""
        OrgDetailTextBox.Text = ""
        DEmail.Text = ""
        DMobileTextBox.Text = ""
        Label19.Text = ""
        CheckBoxFree.Checked = False
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
            Dim Dns_Class As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Domain_name_TextChanged(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim connget As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commget As New SqlClient.SqlCommand
        connget.Open()
        Dim red1get As SqlClient.SqlDataReader
        commget.Connection = connget
        commget.CommandText = "getReserved"
        commget.Parameters.AddWithValue("DN", Server.HtmlEncode(Domain_name.Text))
        commget.CommandType = CommandType.StoredProcedure
        red1get = commget.ExecuteReader()
        red1get.Read()
        If red1get.HasRows = True Then
            ShowToastr(Page, "Failed the domain name reserved", "Error!", "warning")
        End If

        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Try

            conn.Open()
            comm.Connection = conn
            comm.CommandText = "SELECT_OWN"
            comm.Parameters.AddWithValue("DN", Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")))
            comm.Parameters.AddWithValue("SD", SecondDomain.SelectedValue)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            If red1.HasRows Then
                ShowToastr(Page, "Failed the domain name is already registered", "Error!", "warning")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Classification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            Dim lang As New Languages(Session("lang"))
            Dim connectionstr As DAL = New DAL()
            Dim Dns_Class As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
                    Domain_name.Text = reader("DOMAIN_NAME")
                    SecondDomain.SelectedValue = reader("SECOND_DOMAIN_ID")
                    If reader("ClassID") Is DBNull.Value = False Then
                        Classification.SelectedValue = reader("ClassID")
                    End If
                    If reader("Nationalno") Is DBNull.Value = False Then
                        NationalNo.Text = reader("Nationalno")
                    End If
                    If reader("Status_ID") Is DBNull.Value = False Then
                        Status.SelectedValue = reader("Status_ID")
                    End If
                    If reader("BILLING_CODE_ID") Is DBNull.Value = False Then
                        Label25.Text = reader("BILLING_CODE_ID")
                    End If
                    If reader("Description") Is DBNull.Value = False Then
                        OrgDetailTextBox.Text = reader("Description")
                    End If
                    If reader("ORG_EMAIL") Is DBNull.Value = False Then
                        DEmail.Text = reader("ORG_EMAIL")
                    End If
                    If reader("dom_mob") Is DBNull.Value = False Then
                        DMobileTextBox.Text = reader("dom_mob")
                    End If

                    If reader("Testdomain") Is DBNull.Value = False Then
                        If reader("Testdomain") = True Then
                            TestDomain.Checked = True
                        Else
                            TestDomain.Checked = False
                        End If

                    End If
                    If reader("FREE") Is DBNull.Value = False Then
                        If reader("FREE") = "f" Then
                            CheckBoxFree.Checked = True
                        Else
                            CheckBoxFree.Checked = False
                        End If

                    End If
                    If reader("Domain_name") Is DBNull.Value = False Then
                        Domain_name.Text = reader("Domain_name")
                    End If
                    If reader("Second_domain_id") Is DBNull.Value = False Then
                        SecondDomain.SelectedValue = reader("Second_domain_id")
                    End If
                    If reader("NAME_SERVER_ID") = 0 Then
                        Label19.Text = "The Domain is Reserved"
                    Else
                        Label19.Text = "The Domain is Active"
                    End If
                    If reader("END_DATE") Is DBNull.Value = False Then
                        EndDate.Text = Convert.ToDateTime(reader("END_DATE")).ToString("yyy-MM-dd")
                    End If
                    If reader("Owner_Name") Is DBNull.Value = False Then
                        OwnerNameTextBox.Text = reader("Owner_Name")
                    End If
                    If reader("ORG_NAME") Is DBNull.Value = False Then
                        EntityTextBox.Text = reader("ORG_NAME")
                    End If
                    If reader("REG_DATE1") Is DBNull.Value = False Then
                        RadDateInput1.Text = Convert.ToDateTime(reader("REG_DATE1")).ToString("yyy-MM-dd")
                    End If
                    If reader("dom_mob") Is DBNull.Value = False Then
                        DMobileTextBox.Text = reader("dom_mob")
                    End If
                    If reader("ORG_EMAIL") Is DBNull.Value = False Then
                        DEmail.Text = reader("ORG_EMAIL")
                    End If
                    If reader("TECH_EMAIL") Is DBNull.Value = False Then
                        TechEmailTextBox.Text = reader("TECH_EMAIL")
                    End If
                    If reader("tech_mob") Is DBNull.Value = False Then
                        TechMobileTextBox.Text = reader("tech_mob")
                    End If
                    If reader("TECH_CONTACTs_ID") Is DBNull.Value = False Then
                        Label27.Text = reader("TECH_CONTACTs_ID")
                    End If
                    If reader("TECH_CONTACT") Is DBNull.Value = False Then
                        TechTextBox.Text = reader("TECH_CONTACT")
                    End If
                    If reader("ADMIN_ID") Is DBNull.Value = False Then
                        Label26.Text = reader("ADMIN_ID")
                        Admin_id.Text = reader("ADMIN_ID")
                    End If
                    If reader("BILLING_EMAIL") Is DBNull.Value = False Then
                        BillEmail.Text = reader("BILLING_EMAIL")
                    End If
                    If reader("billing_mob") Is DBNull.Value = False Then
                        BillMobileText.Text = reader("billing_mob")
                    End If
                    If reader("BILLING_CONTACT") Is DBNull.Value = False Then
                        BillTextBox.Text = reader("BILLING_CONTACT")
                    End If


                    If reader("COMPANY_USER_NAME") Is DBNull.Value = False Then
                        username.Text = reader("COMPANY_USER_NAME")
                    End If
                    If reader("ad_mobile") Is DBNull.Value = False Then
                        Mobile.Text = reader("ad_mobile")
                    End If
                    If reader("PHONE") Is DBNull.Value = False Then
                        Phone.Text = reader("PHONE")
                    End If
                    If reader("FAX") Is DBNull.Value = False Then
                        Fax.Text = reader("FAX")
                    End If
                    If reader("EMAIL") Is DBNull.Value = False Then
                        Email.Text = reader("EMAIL")
                    End If
                    If reader("ADMIN_CONTACT") Is DBNull.Value = False Then
                        Name.Text = reader("ADMIN_CONTACT")
                    End If
                    If reader("addresses") Is DBNull.Value = False Then
                        Address.Text = reader("addresses")
                    End If
                End While


                reader.Close()
            End If
            Dim ocon_UploadedFiles As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView2.Visible = True
        ttab1.Visible = False
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
                client.ClientCredentials.UserName.UserName = lang.clientUsername
                client.ClientCredentials.UserName.Password = lang.clientPassword
                RS = client.getIndividualRegistry(NationalNo.Text)


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
                client.ClientCredentials.UserName.UserName = lang.clientUsername
                client.ClientCredentials.UserName.Password = lang.clientPassword
                per = client.gePersonal(NationalNo.Text)
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
                comp = client.getCompanyByNo(NationalNo.Text)
                If comp.ID_NUMBER.ToString = "" Then
                    ShowToastr(Page, "not a valid natno", "Error", "Error")
                Else
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Text = "Description"
                    OrgDetailTextBox.Text = Server.HtmlEncode(comp.COMPANAME)
                    Dim ccdname() As ServiceReference1.ccd_name
                    Dim TM() As ServiceReference1.Logo_mark
                    Dim client2 As ServiceReference1.MITServiceClient = New ServiceReference1.MITServiceClient()
                    client2.ClientCredentials.UserName.UserName = lang.clientUsername
                    client2.ClientCredentials.UserName.Password = lang.clientPassword
                    ccdname = client2.getccd_name(NationalNo.Text)
                    If Not ccdname Is Nothing Then
                        TM = client2.getccd_mark(ccdname(0).Regcn, 2)
                        Div3.Visible = True
                        Label12.Text = lang.TMs
                        Label12.Style.Add("Font-Family", lang.fonta)
                        GridView3.Visible = True
                        GridView3.DataSource = TM
                        GridView3.Columns(0).HeaderText = lang.TM_AR
                        GridView3.Columns(1).HeaderText = lang.TM_En
                        GridView3.Style.Add("Font-family", lang.fonta)
                        GridView3.DataBind()
                    End If

                End If
            ElseIf Session("Type").ToString.Trim = "mosd" Then
                Dim client As ServiceReference4.MOSDSrvV2Client = New ServiceReference4.MOSDSrvV2Client()
                client.ClientCredentials.UserName.UserName = lang.clientSTGUsername
                client.ClientCredentials.UserName.Password = lang.clientSTGPassword
                Dim Obj As ServiceReference4.Result()
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.clientSTGID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.clientSTGSecret
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
                                OrgDetailL.Text = lang.RegistrantDetails
                            End If

                        End If
                    Else
                        OrgDetailDiv.Visible = False

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
                    Dim propertyChild As System.Xml.XmlNode
                    For Each xNode As System.Xml.XmlNode In xml.GetElementsByTagName("estStatusCode")
                        For Each propertyChild In xNode.ChildNodes

                            If propertyChild.InnerText = "1" Then
                                For Each xNode2 As System.Xml.XmlNode In xml.GetElementsByTagName("estName")
                                    OrgDetailTextBox.Text = xNode2.InnerText
                                    OrgDetailDiv.Visible = True
                                    OrgDetailTextBox.Visible = True
                                    OrgDetailL.Visible = True
                                Next
                            Else
                                OrgDetailDiv.Visible = False
                                OrgDetailTextBox.Visible = False
                                OrgDetailL.Visible = False
                            End If
                        Next
                    Next

                Catch ex As Exception
                    Toastr.ShowToast(Me, ToastType.Warning, lang.cannotret, lang.Note, ToastPosition.TopCenter)
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Visible = True
                    OrgDetailL.Text = lang.RegistrantDetails
                End Try
            ElseIf Session("Type").ToString.Trim = "jcc" Then
                Dim client As ServiceReference5.JCCSrvV1Client = New ServiceReference5.JCCSrvV1Client()
                client.ClientCredentials.UserName.UserName = lang.clientSTGUsername
                client.ClientCredentials.UserName.Password = lang.clientSTGPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.clientSTGID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.clientSTGSecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    Dim Obj As ServiceReference5.Result()
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                    Try
                        Obj = client.GetAssociationsData(NationalNo.Text)

                        If Not Obj Is Nothing Then
                            If Obj(0).AssocaiationStatus1 = 276 Then
                                OrgDetailTextBox.Text = Server.HtmlEncode(Obj(0).AssocationName1)
                            Else
                                OrgDetailDiv.Visible = False
                                ShowToastr(Page, "Company is not active", "Error", "Error")

                            End If

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
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            ShowToastr(Page, "error", "Error", "Error")
            OrgDetailDiv.Visible = True
            OrgDetailL.Text = "Description"
        End Try
    End Sub

    Protected Sub SecondDomain_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Try

            conn.Open()
            comm.Connection = conn
            comm.CommandText = "SELECT_OWN"
            comm.Parameters.AddWithValue("DN", Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")))
            comm.Parameters.AddWithValue("SD", SecondDomain.SelectedValue)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            If red1.HasRows Then
                ShowToastr(Page, "Failed the domain name is already registered", "Error!", "warning")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\domainmanageV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class