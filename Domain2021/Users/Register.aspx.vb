Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Domain2021.Toastr
Imports RestSharp
Imports RestSharp.Serialization.Json
Imports Microsoft.Security.Application
Imports Newtonsoft.Json
Imports System.Threading

Public Class Register1
    Inherits System.Web.UI.Page
    Dim arrserver As New ArrayList
    Dim arrserverIP As New ArrayList
    Dim sFolder As String = "..\DOC"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Session("page") = "register"
        Dim lang As New Languages(Session("lang"))
        If Page.IsPostBack = False Then

            Disable()
            Fill_dropdownlists()
            SetLanguage()
            welcome_fun()
            If ViewState("Details") Is Nothing Then
                Dim dataTable As DataTable = New DataTable()
                dataTable.Columns.Add(lang.Sname1)
                dataTable.Columns.Add(lang.SecondIP1)
                ViewState("Details") = dataTable
            End If
        End If

        If Request.QueryString("folder") <> "" Then
            sFolder = "..\DOC"
        End If
        Me.Page.Form.Enctype = "multipart/form-data"
        Dim sFolderPath As String = Server.MapPath(sFolder)
        If System.IO.Directory.Exists(sFolderPath) = False Then
            Response.Write(lang.isExist & sFolderPath)
            Response.End()
        End If

    End Sub

    Shared Function validate_experssion(ByVal value As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "[\.]|[\-]|[0-9]|[Aa-Zz]")
    End Function
    Private Sub welcome_fun()
        Try


            Dim ODR As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm2 As New Data.SqlClient.SqlCommand("welcome", conn2)
            comm2.CommandType = CommandType.StoredProcedure
            comm2.Parameters.AddWithValue("user_id", Session("User_ID"))
            conn2.Open()
            ODR = comm2.ExecuteReader
            While ODR.Read
                If Not ODR("MOBILE") Is DBNull.Value Then
                    AdminMobileTextBox.Text = ODR("MOBILE")
                    AdminMobileTextBox.Enabled = False
                End If
                If Not ODR("Email") Is DBNull.Value Then
                    AdminEmailTextBox.Text = ODR("Email")
                    AdminEmailTextBox.Enabled = False
                End If
                If Not ODR("ADMIN_CONTACT") Is DBNull.Value Then
                    AdminTextBox.Text = ODR("ADMIN_CONTACT")
                    AdminTextBox.Enabled = False
                End If
            End While
            ODR.Close()
            conn2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.master"
        Else
            Me.MasterPageFile = "MasterPageEnn.master"
        End If
    End Sub

    Sub Fill_dropdownlists()
        Try

            Dim lang As New Languages(Session("lang"))
            Dim connectionstr As DAL = New DAL()
            Dim DNS_Class As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim Dns_classCmd As New SqlClient.SqlCommand("selectClassAREn", Dns_class)
            Dim Dns_classReader As SqlClient.SqlDataReader
            Dns_class.Open()
            Dns_classCmd.CommandType = CommandType.StoredProcedure
            Dns_classCmd.Parameters.AddWithValue("lang", Session("lang"))
            Dns_classReader = Dns_classCmd.ExecuteReader
            Classification.DataSource = Dns_classReader
            If Session("lang") = "ar" Then
                Classification.DataTextField = "ClassificationNameAr"
                Classification.DataValueField = "ClassificationID"
            Else
                Classification.DataTextField = "ClassificationNameEn"
                Classification.DataValueField = "ClassificationID"
            End If
            Classification.DataBind()
            Classification.Items.Insert(0, New ListItem("---" + lang.Classification + "---", "0"))
            Dns_classReader.Close()
            Dns_class.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        paper.InnerHtml = lang.UploadFiles2 + "<i class='fa fa-file' style='padding-left: 10px'></i>"
        fs.Attributes.Add("font-family", lang.fonta)
        fs.Attributes.Add("text-align", lang.right)
        fs.Attributes.Add("direction", lang.dir)
        DomainInfotab.Style.Add("font-family", lang.fonta)
        PrevLast.Text = lang.prev2
        ckboxvalidator.ErrorMessage = lang.clarify
        ckboxvalidator.Font.Bold = False
        Servertab.Style.Add("font-family", lang.fonta)
        CardRequired.Text = lang.RequiredField2
        CardLbl.Text = lang.CardNo
        ContactInfotab.Style.Add("font-family", lang.fonta)
        Documenttab.Style.Add("font-family", lang.fonta)
        DomainInfotab.Style.Add("Direction", lang.dir)
        Servertab.Style.Add("Direction", lang.dir)
        ContactInfotab.Style.Add("Direction", lang.dir)
        Documenttab.Style.Add("Direction", lang.dir)
        NationalNoRegValid.Text = lang.onlynumbers
        PreviousToStep2.Text = lang.prev2
        IPadd.Text = lang.validIP
        Prevto3.Text = lang.prev2
        NationalNoRegValid.Style.Add("font-family", lang.fonta)
        DomainInfotab.InnerHtml = "<i class='fa fa-info-circle' style='padding-left: 10px'></i>" + " " + lang.domaininfo
        Servertab.InnerHtml = "<i class='fa fa-server' style='padding-left: 10px'></i>" + " " + lang.Servers
        ContactInfotab.InnerHtml = "<i class='fa fa-info' style='padding-left: 10px'></i>" + " " + lang.ContactData
        Documenttab.InnerHtml = "<i class='fa fa-file' style='padding-left: 10px'></i>" + " " + lang.UploadFiles2
        reservedfuture.Text = lang.future
        reservedfuture.Font.Bold = True
        ContactPanel.Font.Bold = True
        DocumentPanel.Font.Bold = True
        PrimaryNameServerip.Text = lang.SecondIP1
        LinkButton1.Text = lang.addmore + "<i class='fa fa-plus'></i>"
        PrimaryNameServerip.Text = lang.SecondIP1
        NextToStep4.Text = lang.NextS
        NextToStep4.Font.Name = lang.fonta
        NextToStep4.Font.Bold = True
        Prevto3.Font.Name = lang.fonta
        Prevto3.Font.Bold = True
        Prevto3.ForeColor = Drawing.Color.White
        PreviousToStep2.Font.Name = lang.fonta
        PreviousToStep2.Font.Bold = True
        PrevLast.Font.Name = lang.fonta
        PrevLast.Font.Bold = True
        PrevLast.ForeColor = Drawing.Color.White
        LinkButton1.Style.Add("font-family", lang.fonta)
        paper.Style.Add("font-family", lang.fonta)
        paper.Style.Add("font-weight", "bold")
        container.Style.Add("Direction", lang.dir)
        container.Style.Add("font-family", lang.fonta)
        nav.Style.Add("Direction", lang.dir)
        nav.Style.Add("font-family", lang.fonta)
        Domain_nameL.Text = lang.DomainName
        OrgDetailL.Text = lang.RegistrantDetails
        SecondDomainLabel.Text = lang.SecondName
        ContactPanel.Font.Name = lang.fonta
        ContactPanel.Font.Bold = True
        RegularServer.Text = lang.validname
        ClassificationValidator.Text = lang.RequiredField2
        OrgDetailValidator.Text = lang.RequiredField2
        BMobileValidator.Text = lang.RequiredField2
        OwnerEmailValidator.Text = lang.RequiredField2
        Domain_nameValidator.Text = lang.RequiredField2
        TechValidator.Text = lang.RequiredField2
        TechMobileValidator.Text = lang.RequiredField2
        TechEmailTextBoxValidator.Text = lang.RequiredField2
        AdminTextBoxValidator.Text = lang.RequiredField2
        AdminEmailTextBoxValidator.Text = lang.RequiredField2
        AdminMobileTextBoxValidator.Text = lang.RequiredField2
        BillingValidator.Text = lang.RequiredField2
        BillEmailValidator.Text = lang.RequiredField2
        NationalNoValidator.Text = lang.RequiredField2
        OwnerNameRequiredFieldValidator.Text = lang.RequiredField2
        OwnerMobileValidator.Text = lang.RequiredField2
        pname1.Text = lang.RequiredField2
        TechEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        BillEmailExpressionValidator.Text = lang.InvalidEmail
        OwnerEmailExpressionValidator.Text = lang.InvalidEmail
        PrimaryNameServerRow.Style.Add("font-weight", "bold")
        ClassificationLabel.Text = lang.Classification
        NextStep1.Text = lang.NextS
        NextStep1.Font.Name = lang.fonta
        NextStep1.Font.Bold = True
        NextToStep3.Text = lang.NextS
        OwnerEmailLabel.Text = lang.Email
        OwnerMobileLabel.Text = lang.Mobile
        OwnerName.Text = lang.Oname
        TechLabel.Text = lang.Tech
        TechMobileLabel.Text = lang.Mobile
        TechEmailLabel.Text = lang.Email
        AdminDetailsLabel.Text = lang.Admin
        AdminMobileLabel.Text = lang.Mobile
        AdminEmailLabel.Text = lang.Email
        BillLabel.Text = lang.bill
        BillMobileLabel.Text = lang.Mobile
        BillEmailLabel.Text = lang.Email
        agree.Text = "  " + lang.Agree
        agree.Font.Name = lang.fonta
        agree.Font.Bold = True
        NextToStep3.Font.Name = lang.fonta
        NextToStep3.Font.Bold = True
        FinishRegistration.Text = lang.btnRegister
        FinishRegistration.Font.Name = lang.fonta
        FinishRegistration.Font.Bold = True
        PrimaryNameServerLabel.Text = lang.Sname1
        OwnerDetailsLabel.Text = lang.ownerd
        TechDetailsLabel.Text = lang.Tech
        BillingDetails.Text = lang.bill
        AdminDetails.Text = lang.Admin
    End Sub
    Public Sub Disable()
        all.Enabled = False
        ContactPanel.Enabled = False
        DocumentPanel.Enabled = False
        Classification.Enabled = False
    End Sub
    Public Sub DisableAll()
        all.Enabled = False
        NextStep1.Enabled = False
        ContactPanel.Enabled = False
        DocumentPanel.Enabled = False
        Classification.Enabled = False
        SecondDomain.Enabled = False
    End Sub
    Public Sub EnableFirst1()
        NextStep1.Enabled = True
        Classification.Enabled = True
        SecondDomain.Enabled = True
    End Sub
    Public Sub EnableFirst()
        all.Enabled = True
        NextStep1.Enabled = True
        ContactPanel.Enabled = False
        DocumentPanel.Enabled = False
        SecondDomain.Enabled = True
        Classification.Enabled = True
    End Sub
    Public Sub ShowServers()
        DomainInfo.Enabled = False
        If PrimaryNameServer.Visible = False Then
            PrimaryNameServerRow.Visible = True
            PrimaryNameServer.Visible = True
        End If
    End Sub
    Protected Sub Classification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try


            NationalNo.Text = ""
            OrgDetailTextBox.Text = ""
            TMlabel.Visible = False
            TMGridView.Visible = False
            TMGridView2.Visible = False
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
                        If Dns_classReader("Type").ToString.Trim() = "psd" Then
                            DivcardNo.Visible = False
                            CardNo.Text = ""
                            NationalNoL.Text = lang.NationalNoresd
                            DivNationalNo.Visible = True
                            OrgDetailDiv.Visible = False
                            Session("Type") = Dns_classReader("Type")
                        ElseIf Dns_classReader("Type").ToString.Trim() = "cspd" Then
                            DivcardNo.Visible = True
                            CardLbl.Visible = True
                            CardNo.Visible = True
                            CardRequired.Visible = True
                            RequiredCardNo.Visible = True
                            NationalNoL.Text = lang.NationalNo
                            DivNationalNo.Visible = True
                            OrgDetailDiv.Visible = False
                            Session("Type") = Dns_classReader("Type")
                        ElseIf Dns_classReader("Type").ToString.Trim() = "ccd" Or Dns_classReader("Type").ToString.Trim() = "free" Or Dns_classReader("Type").ToString.Trim() = "mit" Or Dns_classReader("Type").ToString.Trim() = "mosd" Or Dns_classReader("Type").ToString.Trim() = "jcc" Or Dns_classReader("Type").ToString.Trim() = "Gov" Then
                            DivcardNo.Visible = False
                            CardNo.Text = ""
                            CardLbl.Visible = False
                            CardNo.Visible = False
                            CardRequired.Visible = False
                            RequiredCardNo.Visible = False
                            NationalNoL.Text = lang.NationalNoinstitute
                            DivNationalNo.Visible = True
                            OrgDetailDiv.Visible = False
                            Session("Type") = Dns_classReader("Type")
                        End If
                    ElseIf Dns_classReader("Integration") = False And Dns_classReader("Type").ToString.Trim() = "NoNational" Then
                        DivcardNo.Visible = False
                        CardNo.Text = ""
                        CardLbl.Visible = False
                        CardNo.Visible = False
                        CardRequired.Visible = False
                        RequiredCardNo.Visible = False
                        NationalNoL.Text = lang.NationalNoNone
                        OrgDetailDiv.Visible = False
                        DivNationalNo.Visible = False
                        Session("Type") = "NoNational"
                    ElseIf Dns_classReader("Integration") = False And Dns_classReader("Type").ToString.Trim() = "none" Then
                        DivcardNo.Visible = False
                        CardNo.Text = ""
                        CardLbl.Visible = False
                        CardNo.Visible = False
                        CardRequired.Visible = False
                        RequiredCardNo.Visible = False
                        NationalNoL.Text = lang.NationalNoNone
                        OrgDetailDiv.Visible = False
                        DivNationalNo.Visible = True
                        Session("Type") = "none"
                    End If
                End If
            End While
            Dns_classReader.Close()
            Dns_class.Close()
            DomainInfo.CssClass = "tab-pane  active show"
            DomainInfotab.Attributes.Remove("class")
            DomainInfotab.Attributes.Add("class", "nav-link active")
            ServerP.CssClass = "tab-pane"
            Servertab.Attributes.Remove("class")
            Servertab.Attributes.Add("class", "nav-link")
            all.Enabled = False
            ContactPanel.Enabled = False
            DocumentPanel.Enabled = False
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Domain_name_TextChanged(sender As Object, e As EventArgs)
        Try


            Dim lang As New Languages(Session("lang"))
            Dim aa As String
            Dim bb() As String
            Dim ZipRegex As String
            If SecondDomain.SelectedValue <> 12 Then
                ZipRegex = "^[A-Za-z0-9\-]{1,63}$"
            Else
                ZipRegex = "^[ء-ي0-9\-]{1,63}$"
            End If

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

            Dim connban As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commban As New SqlClient.SqlCommand
            connban.Open()
            Dim red1ban As SqlClient.SqlDataReader
            commban.Connection = connban
            commban.CommandText = "isbanned"
            commban.Parameters.AddWithValue("domain_name", Server.HtmlEncode(Domain_name.Text))
            commban.Parameters.AddWithValue("admin_id", Session("User_ID"))
            commban.Parameters.AddWithValue("second", SecondDomain.SelectedValue)
            commban.CommandType = CommandType.StoredProcedure
            red1ban = commban.ExecuteReader()
            red1ban.Read()
            If Not Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")) = "" Then

                If Not ((Regex.IsMatch(Server.HtmlEncode(Domain_name.Text), ZipRegex))) Then
                    Toastr.ShowToast(Me, ToastType.Error, lang.validexp2, lang.EError, ToastPosition.TopCenter)
                    Disable()
                    'ElseIf Server.HtmlEncode(Domain_name.Text).ToArray.Length < 3 Then
                    '    Toastr.ShowToast(Me, ToastType.Error, lang.domainlenght, lang.EError, ToastPosition.TopCenter)
                    '    DisableAll()
                ElseIf Server.HtmlEncode(Domain_name.Text).ToArray.Length > 63 Then
                    Toastr.ShowToast(Me, ToastType.Error, lang.domainlenght2, lang.EError, ToastPosition.TopCenter)
                    DisableAll()
                ElseIf red1get.HasRows = True Then
                    Toastr.ShowToast(Me, ToastType.Error, lang.reserved, lang.EError, ToastPosition.TopCenter)
                    DisableAll()
                ElseIf red1ban.HasRows = True Then
                    Toastr.ShowToast(Me, ToastType.Error, lang.banned, lang.EError, ToastPosition.TopCenter)
                    DisableAll()
                ElseIf Not Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")) = "" Then
                    aa = Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", ""))
                    bb = aa.Split(".")
                    EnableFirst1()

                    If bb.Length = 1 Then
                        ' DomainLiteral1.Text = ""
                        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim comm As New Data.SqlClient.SqlCommand
                        Dim red1 As Data.SqlClient.SqlDataReader
                        Dim test As Boolean
                        Try
                            conn.Open()
                            comm.Connection = conn
                            comm.CommandText = "SELECT_OWN"
                            comm.Parameters.AddWithValue("DN", Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")))
                            comm.Parameters.AddWithValue("SD", SecondDomain.SelectedValue)
                            comm.CommandType = Data.CommandType.StoredProcedure
                            red1 = comm.ExecuteReader()
                            If red1.HasRows = False And Domain_name.Text <> "" Then
                            End If
                            While red1.Read
                                Disable()
                                DomainLiteral1.Text = lang.Reg
                                DomainLiteral1.Text += "<font color=red><b><i>" + red1.Item(0) + "</b></i></font>"
                                DomainLiteral1.Text += "<BR><BR>"

                                test = True
                                Exit While
                            End While
                            red1.Close()
                            conn.Close()
                            If test Then
                                Disable()
                            Else

                                Dim connRegex As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                                Dim commRegex As New SqlClient.SqlCommand
                                connRegex.Open()
                                Dim red1Regex As SqlClient.SqlDataReader
                                commRegex.Connection = connRegex
                                commRegex.CommandText = "MatchRegex"
                                commRegex.CommandType = CommandType.StoredProcedure
                                red1Regex = commRegex.ExecuteReader()
                                While red1Regex.Read
                                    If Regex.IsMatch(Server.HtmlEncode(Domain_name.Text), red1Regex("regex")) Then
                                        DomainLiteral1.Text = "<font color=red>" + lang.specialfees + "</font>"
                                        If SecondDomain.SelectedValue = 7 Then
                                            Session("specialid") = red1Regex("id")
                                        Else
                                            Session("specialid") = red1Regex("id") + 1
                                        End If

                                        Exit While
                                    Else
                                        DomainLiteral1.Text = ""
                                        Session("specialid") = 0
                                    End If

                                End While
                                red1Regex.Close()
                                Toastr.ShowToast(Me, ToastType.Info, lang.Available, lang.Available, ToastPosition.TopCenter)
                                EnableFirst1()
                            End If

                        Catch ex As Exception
                            conn.Close()
                        End Try

                    Else
                        Toastr.ShowToast(Me, ToastType.Error, lang.DDOT, lang.EError, ToastPosition.TopCenter)


                    End If
                End If

            End If
            connban.Close()
            connget.Close()
            red1ban.Close()
            red1get.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub addSecondServer_Click(sender As Object, e As EventArgs)
        DomainInfo.CssClass = "tab-pane"
        DomainInfotab.Attributes.Remove("class")
        DomainInfotab.Attributes.Add("class", "nav-link")
        ServerP.CssClass = "tab-pane active show"
        Servertab.Attributes.Remove("class")
        Servertab.Attributes.Add("class", "nav-link active")
        ShowServers()
    End Sub
    Protected Sub NationalNo_TextChanged(sender As Object, e As EventArgs)
        Try
            TMGridView.Visible = False
            Dim lang As New Languages(Session("lang"))
            If Session("Type").ToString.Trim = "mit" Then
                NationalNoL.Text = lang.NationalNoinstitute
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
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
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                    RS = client.getIndividualRegistry(Server.HtmlEncode(NationalNo.Text))

                    If RS.HasData = False Then
                        Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno, lang.EError, ToastPosition.TopCenter)
                        OrgDetailDiv.Visible = False
                        NextStep1.Enabled = False
                    ElseIf (RS.intRegistryStatusCode = 1 Or RS.intRegistryStatusCode = 3) Then
                        OrgDetailDiv.Visible = True
                        OrgDetailL.Text = lang.RegistrantDetails
                        If RS.strRegistryAddress = "_" Then
                            OrgDetailTextBox.Text = RS.strRegistryName
                        Else
                            OrgDetailTextBox.Text = RS.strRegistryAddress
                        End If
                        NextStep1.Enabled = True
                        TM = client.getTradeMark(RS.intIndv_ID, 6)
                        If Not TM.Length = 0 Then
                            If TM(0).decCompanyNO IsNot Nothing Then
                                Div3.Visible = True
                                TMlabel.Text = lang.TMs
                                TMlabel.Style.Add("Font-Family", lang.fonta)
                                TMGridView.Visible = True
                                TMGridView.DataSource = TM
                                TMGridView.Columns(0).HeaderText = lang.TM_AR
                                TMGridView.Columns(1).HeaderText = lang.TM_En
                                TMGridView.Style.Add("Font-family", lang.fonta)
                                TMGridView.DataBind()
                            Else
                                TMlabel.Visible = False
                                TMGridView.Visible = False
                                TMGridView2.Visible = False
                            End If
                        End If
                    Else
                        Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno2, lang.wrongnatno2, ToastPosition.TopCenter)
                        NextStep1.Enabled = False
                        OrgDetailDiv.Visible = False
                    End If
                End Using
            ElseIf Session("Type").ToString.Trim = "cspd" Then
                DivcardNo.Visible = True
                CardLbl.Visible = True
                CardNo.Visible = True
                CardRequired.Visible = True
                RequiredCardNo.Visible = True
                NationalNoL.Text = lang.NationalNo
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                TMlabel.Visible = False
                TMGridView.Visible = False
                TMGridView2.Visible = False
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
                    OrgDetailDiv.Visible = False
                    NextStep1.Enabled = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno, lang.EError, ToastPosition.TopCenter)
                ElseIf per.DEATH_C.ToString = "NotDead" Then
                    If per.CARD_NO = CardNo.Text Then
                        NextStep1.Enabled = True
                        OrgDetailDiv.Visible = True
                        OrgDetailL.Text = lang.RegistrantDetails
                        OrgDetailTextBox.Text = Server.HtmlEncode(Server.HtmlEncode(per.ANAME1 + " " + per.ANAME2 + " " + per.ANAME3 + " " + per.ANAME4))
                    Else
                        Toastr.ShowToast(Me, ToastType.Error, lang.WrongCardNo, lang.EError, ToastPosition.TopCenter)

                    End If
                ElseIf per.DEATH_C.ToString = "Dead" Then
                    OrgDetailDiv.Visible = False
                    NextStep1.Enabled = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.Dead, lang.EError, ToastPosition.TopCenter)

                End If
            ElseIf Session("Type").ToString.Trim = "ccd" Then
                NationalNoL.Text = lang.NationalNoinstitute
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                DivcardNo.Visible = False
                CardNo.Text = ""
                Dim client As ServiceReference2.CompanyClient = New ServiceReference2.CompanyClient()
                Dim comp As ServiceReference2.Company = New ServiceReference2.Company()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                    comp = client.getCompanyByNo(NationalNo.Text)
                End Using
                If comp.ID_NUMBER.ToString = "" Then
                    OrgDetailDiv.Visible = False
                    NextStep1.Enabled = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno, ToastPosition.TopCenter)
                ElseIf comp.COMPSTATUS = 1 Or comp.COMPSTATUS = 25 Then
                    OrgDetailDiv.Visible = True
                    OrgDetailL.Text = lang.RegistrantDetails
                    OrgDetailTextBox.Text = Server.HtmlEncode(comp.COMPANAME)
                    NextStep1.Enabled = True
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
                            TMlabel.Text = lang.TMs
                            TMlabel.Style.Add("Font-Family", lang.fonta)
                            TMGridView2.Visible = True
                            TMGridView2.DataSource = TM
                            TMGridView2.Columns(0).HeaderText = lang.TM_AR
                            TMGridView2.Columns(1).HeaderText = lang.TM_En
                            TMGridView2.Style.Add("Font-family", lang.fonta)
                            TMGridView2.DataBind()
                        End If
                    End Using
                Else
                    Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno2, lang.wrongnatno2, ToastPosition.TopCenter)
                    NextStep1.Enabled = False
                    TMlabel.Visible = False
                    TMGridView.Visible = False
                    TMGridView2.Visible = False
                End If
            ElseIf Session("Type").ToString.Trim = "mosd" Then
                DivcardNo.Visible = False
                CardNo.Text = ""
                NationalNoL.Text = lang.NationalNoinstitute
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                TMlabel.Visible = False
                TMGridView.Visible = False
                TMGridView2.Visible = False
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
                    If Obj(0).CLASS1 = "E" Then

                        OrgDetailDiv.Visible = True
                        NextStep1.Enabled = True
                        OrgDetailTextBox.Text = Server.HtmlEncode(Obj(0).ASSNAME1)
                    Else
                        NextStep1.Enabled = False
                        OrgDetailDiv.Visible = False
                        Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno2, lang.wrongnatno2, ToastPosition.TopCenter)

                    End If
                Else
                    NextStep1.Enabled = False
                    OrgDetailDiv.Visible = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno, ToastPosition.TopCenter)
                End If
            ElseIf Session("Type").ToString.Trim = "psd" Then
                DivcardNo.Visible = False
                CardNo.Text = ""
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                TMlabel.Visible = False
                TMGridView.Visible = False
                TMGridView2.Visible = False
                NationalNoL.Text = lang.NationalNoresd
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
                Dim deserial As JsonDeserializer = New JsonDeserializer()
                Dim response = client.Execute(request)
                If response.Content = Nothing Then
                    OrgDetailDiv.Visible = False
                    NextStep1.Enabled = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno3, ToastPosition.TopCenter)
                Else
                    Dim finalResult As RRoot.Root = New JsonDeserializer().Deserialize(Of RRoot.Root)(response)
                    If finalResult.status = True Then
                        Dim datenow As Date = Now().ToString("dd-MMM-yy", CultureInfo.CreateSpecificCulture("en-US"))
                        If finalResult.data(0).document(0).EXPIRY_DATE <> Nothing Then

                            Dim expdate As Date = finalResult.data(0).document(0).EXPIRY_DATE
                            If expdate < datenow Then
                                OrgDetailDiv.Visible = False
                                NextStep1.Enabled = False
                                Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.expiredID, ToastPosition.TopCenter)
                            Else
                                NextStep1.Enabled = True
                                OrgDetailTextBox.Text = finalResult.data(0).E_FULL_NAME
                                OrgDetailDiv.Visible = True
                                OrgDetailL.Text = lang.RegistrantDetails
                            End If

                        End If
                    Else
                        OrgDetailDiv.Visible = False
                        NextStep1.Enabled = False
                        Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno3, ToastPosition.TopCenter)
                    End If
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
                If response.Content = Nothing Then
                    OrgDetailDiv.Visible = False
                    NextStep1.Enabled = False
                    Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.wrongnatno3, ToastPosition.TopCenter)
                Else
                    OrgDetailDiv.Visible = True
                    NextStep1.Enabled = True
                    Dim myDeserializedClass As List(Of GoVresult) = JsonConvert.DeserializeObject(Of List(Of GoVresult))(response.Content)
                    OrgDetailTextBox.Text = myDeserializedClass(0).Name_Ar
                End If
            ElseIf Session("Type").ToString.Trim = "jcc" Then
                DivcardNo.Visible = False
                CardNo.Text = ""
                NationalNoL.Text = lang.NationalNoinstitute
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                TMlabel.Visible = False
                TMGridView.Visible = False
                TMGridView2.Visible = False
                Dim client As ServiceReference5.JCCSrvV1Client = New ServiceReference5.JCCSrvV1Client()
                client.ClientCredentials.UserName.UserName = lang.clientg2bUsername
                client.ClientCredentials.UserName.Password = lang.clientg2bPassword
                Using scope = New OperationContextScope(client.InnerChannel)
                    Dim requestMessage As HttpRequestMessageProperty = New HttpRequestMessageProperty()
                    requestMessage.Headers("X-IBM-Client-Id") = lang.g2gID
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    requestMessage.Headers("X-IBM-Client-Secret") = lang.g2gsecret
                    OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = requestMessage
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                    Dim Obj As ServiceReference5.Result()
                    Try
                        Obj = client.GetAssociationsData(NationalNo.Text)
                        If Not Obj Is Nothing Then
                            If Obj(0).AssocaiationStatus1 = 276 Then
                                OrgDetailTextBox.Text = Server.HtmlEncode(Obj(0).AssocationName1)
                                OrgDetailDiv.Visible = True
                                NextStep1.Enabled = True
                                OrgDetailTextBox.Visible = True
                                OrgDetailL.Visible = True
                            Else
                                OrgDetailDiv.Visible = False
                                OrgDetailTextBox.Visible = False
                                NextStep1.Enabled = False
                                OrgDetailL.Visible = False
                                Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno2, lang.EError, ToastPosition.TopCenter)

                            End If
                        Else
                            OrgDetailDiv.Visible = False
                            NextStep1.Enabled = False
                            Toastr.ShowToast(Me, ToastType.Error, lang.wrongnatno, lang.EError, ToastPosition.TopCenter)
                        End If
                    Catch ex As Exception
                        Toastr.ShowToast(Me, ToastType.Warning, lang.cannotret, lang.Note, ToastPosition.TopCenter)
                        OrgDetailDiv.Visible = True
                        OrgDetailL.Visible = True
                        OrgDetailL.Text = lang.RegistrantDetails
                    End Try



                End Using
            ElseIf Session("Type").ToString.Trim = "free" Then
                DivcardNo.Visible = False
                CardNo.Text = ""
                NationalNoL.Text = lang.NationalNoinstitute
                OrgDetailTextBox.Text = ""
                TMGridView2.Visible = False
                TMlabel.Visible = False
                TMGridView.Visible = False
                TMGridView2.Visible = False
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
                                    NextStep1.Enabled = True
                                    OrgDetailTextBox.Visible = True
                                    OrgDetailL.Visible = True
                                Next
                            Else
                                OrgDetailDiv.Visible = False
                                OrgDetailTextBox.Visible = False
                                NextStep1.Enabled = False
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

            Else
                OrgDetailDiv.Visible = True
                OrgDetailL.Text = lang.RegistrantDetails
                NextStep1.Enabled = True
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            Toastr.ShowToast(Me, ToastType.Warning, lang.cannotret, lang.Note, ToastPosition.TopCenter)
            OrgDetailDiv.Visible = True
            NextStep1.Enabled = True
            OrgDetailL.Text = lang.RegistrantDetails
        End Try
    End Sub
    Protected Sub NextStep1_Click(sender As Object, e As EventArgs)
        Try

            If Page.IsValid = True Then
                Dim lang As New Languages(Session("lang"))
                Dim aa As String
                Dim bb() As String
                Dim ZipRegex As String
                If SecondDomain.SelectedValue <> 12 Then
                    ZipRegex = "^[A-Za-z0-9\-]{1,63}$"
                Else
                    ZipRegex = "^[ء-ي0-9\-]{1,63}$"
                End If
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
                Dim connban As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim commban As New SqlClient.SqlCommand
                connban.Open()
                Dim red1ban As SqlClient.SqlDataReader
                commban.Connection = connban
                commban.CommandText = "isbanned"
                commban.Parameters.AddWithValue("domain_name", Server.HtmlEncode(Domain_name.Text))
                commban.Parameters.AddWithValue("admin_id", Session("User_ID"))
                commban.Parameters.AddWithValue("second", SecondDomain.SelectedValue)
                commban.CommandType = CommandType.StoredProcedure
                red1ban = commban.ExecuteReader()
                red1ban.Read()
                If Not Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")) = "" Then

                    If Not ((Regex.IsMatch(Server.HtmlEncode(Domain_name.Text), ZipRegex))) Then
                        Toastr.ShowToast(Me, ToastType.Error, lang.validexp2, lang.EError, ToastPosition.TopCenter)
                        Disable()
                        'ElseIf Server.HtmlEncode(Domain_name.Text).ToArray.Length < 3 Then
                        '    Toastr.ShowToast(Me, ToastType.Error, lang.domainlenght, lang.EError, ToastPosition.TopCenter)
                        '    DisableAll()
                    ElseIf Server.HtmlEncode(Domain_name.Text).ToArray.Length > 63 Then
                        Toastr.ShowToast(Me, ToastType.Error, lang.domainlenght2, lang.EError, ToastPosition.TopCenter)
                        DisableAll()
                    ElseIf red1get.HasRows = True Then
                        Toastr.ShowToast(Me, ToastType.Error, lang.reserved, lang.EError, ToastPosition.TopCenter)
                        DisableAll()
                    ElseIf red1ban.HasRows = True Then
                        Toastr.ShowToast(Me, ToastType.Error, lang.banned, lang.EError, ToastPosition.TopCenter)
                        DisableAll()
                    ElseIf Not Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")) = "" Then
                        aa = Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", ""))
                        bb = aa.Split(".")
                        EnableFirst1()

                        connban.Close()
                        connget.Close()
                        red1ban.Close()
                        red1get.Close()
                        DomainInfo.CssClass = "tab-pane"
                        DomainInfotab.Attributes.Remove("class")
                        DomainInfotab.Attributes.Add("class", "nav-link")
                        ServerP.CssClass = "tab-pane active show"
                        Servertab.Attributes.Remove("class")
                        Servertab.Attributes.Add("class", "nav-link active")
                        EnableFirst()
                        ServerP.Enabled = True
                        DomainInfo.Enabled = False
                    End If

                End If

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Sub
    Protected Sub PreviousToStep2_Click(sender As Object, e As EventArgs)
        If Page.IsValid = True Then
            ServerP.CssClass = "tab-pane"
            ServerP.Attributes.Remove("class")
            ServerP.Attributes.Add("class", "nav-link")
            DomainInfo.CssClass = "tab-pane active show"
            DomainInfotab.Attributes.Remove("class")
            Servertab.Attributes.Remove("class")
            Servertab.Attributes.Add("class", "nav-link")
            DomainInfotab.Attributes.Add("class", "nav-link active")
            ServerP.Enabled = False
            DomainInfo.Enabled = True

        End If
    End Sub
    Protected Sub NeXtToStep2_Click(sender As Object, e As EventArgs)

        Dim lang As New Languages(Session("lang"))
        If Request.QueryString("folder") <> "" Then
            sFolder = "..\DOC"
        End If
        Me.Page.Form.Enctype = "multipart/form-data"
        Dim sFolderPath As String = Server.MapPath(sFolder)
        If System.IO.Directory.Exists(sFolderPath) = False Then
            Response.Write(lang.isExist & sFolderPath)
            Response.End()
        End If
        If Request.HttpMethod = "POST" Then

            If Request.Form("btnDelete") <> "" Then
                'Delete files
                If (Not Request.Form.GetValues("chkDelete") Is Nothing) Then
                    For i As Integer = 0 To Request.Form.GetValues("chkDelete").Length - 1
                        Dim sFileName As String = Request.Form.GetValues("chkDelete")(i)

                        Try
                            System.IO.File.Delete(sFolderPath & "\" & sFileName)
                        Catch ex As Exception
                            'Ignore error
                        End Try
                    Next
                End If

            Else
                Dim rand As String = ""

                Dim fileCount As Integer = 0
                Dim filename As String = ""
                Dim filecoll = Request.Files

                Dim i As Integer
                For i = 0 To filecoll.Count - 1
                    If filecoll(i).ContentType = "image/gif" Or filecoll(i).ContentType = "image/pjpeg" Or filecoll(i).ContentType = "image/bmp" Or filecoll(i).ContentType = "image/x-png" Or filecoll(i).ContentType = "application/pdf" Or filecoll(i).ContentType = "image/png" Or filecoll(i).ContentType = "image/jpg" Or filecoll(i).ContentType = "image/jpeg" Then
                        rand = GetRandom(1, 9)
                        filename = rand & "_" & Session("DID") & filecoll(i).FileName
                        filecoll(i).SaveAs(Server.MapPath("~") + "\\DOC\\" + filename)

                    End If

                Next





            End If

        End If
        DomainInfo.CssClass = "tab-pane"
        DomainInfotab.Attributes.Remove("class")
        DomainInfotab.Attributes.Add("class", "nav-link")
        ServerP.CssClass = "tab-pane"
        Servertab.Attributes.Remove("class")
        Servertab.Attributes.Add("class", "nav-link")
        ContactInfo.CssClass = "tab-pane active show"
        ContactInfotab.Attributes.Remove("class")
        ContactInfotab.Attributes.Add("class", "nav-link active")
        ServerP.Enabled = False
        DomainInfo.Enabled = False
        ContactPanel.Enabled = True

    End Sub
    Protected Sub NeXtToStep4_Click(sender As Object, e As EventArgs)
        DomainInfo.CssClass = "tab-pane"
        DomainInfotab.Attributes.Remove("class")
        DomainInfotab.Attributes.Add("class", "nav-link")
        ServerP.CssClass = "tab-pane"
        Servertab.Attributes.Remove("class")
        Servertab.Attributes.Add("class", "nav-link")
        ContactInfo.CssClass = "tab-pane"
        ContactInfotab.Attributes.Remove("class")
        ContactInfotab.Attributes.Add("class", "nav-link")
        DocumentInfo.CssClass = "tab-pane active show"
        Documenttab.Attributes.Remove("class")
        Documenttab.Attributes.Add("class", "nav-link active")
        DocumentPanel.Enabled = True
        ContactPanel.Enabled = False
        ServerP.Enabled = False
        DomainInfo.Enabled = False
        Dim lang As New Languages(Session("lang"))
        Dim connectionstr As DAL = New DAL()
        '==========================insert_server_data=============
        If reservedfuture.Checked = False Then

            Try

                Dim connserver As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim commserver As New Data.SqlClient.SqlCommand

                connserver.Open()
                commserver.Connection = connserver
                commserver.CommandType = CommandType.StoredProcedure
                commserver.CommandText = "insert_server_data"
                commserver.Parameters.AddWithValue("p_n", GridView1.Rows(0).Cells(1).Text.Replace("&nbsp;", ""))
                commserver.Parameters.AddWithValue("p_ip", GridView1.Rows(0).Cells(2).Text.Replace("&nbsp;", ""))
                If GridView1.Rows.Count >= 2 Then
                    commserver.Parameters.AddWithValue("s_n", GridView1.Rows(1).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip", GridView1.Rows(1).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n", "")
                    commserver.Parameters.AddWithValue("s_ip", "")
                End If

                If GridView1.Rows.Count >= 3 Then
                    commserver.Parameters.AddWithValue("s_n3", GridView1.Rows(2).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip3", GridView1.Rows(2).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n3", "")
                    commserver.Parameters.AddWithValue("s_ip3", "")
                End If
                If GridView1.Rows.Count >= 4 Then
                    commserver.Parameters.AddWithValue("s_n4", GridView1.Rows(3).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip4", GridView1.Rows(3).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n4", "")
                    commserver.Parameters.AddWithValue("s_ip4", "")
                End If
                If GridView1.Rows.Count >= 5 Then
                    commserver.Parameters.AddWithValue("s_n5", GridView1.Rows(4).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip5", GridView1.Rows(4).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n5", "")
                    commserver.Parameters.AddWithValue("s_ip5", "")
                End If
                If GridView1.Rows.Count >= 6 Then
                    commserver.Parameters.AddWithValue("s_n6", GridView1.Rows(5).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip6", GridView1.Rows(5).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n6", "")
                    commserver.Parameters.AddWithValue("s_ip6", "")
                End If
                If GridView1.Rows.Count >= 7 Then
                    commserver.Parameters.AddWithValue("s_n7", GridView1.Rows(6).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip7", GridView1.Rows(6).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n7", "")
                    commserver.Parameters.AddWithValue("s_ip7", "")
                End If
                If GridView1.Rows.Count >= 8 Then
                    commserver.Parameters.AddWithValue("s_n8", GridView1.Rows(7).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip8", GridView1.Rows(7).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n8", "")
                    commserver.Parameters.AddWithValue("s_ip8", "")
                End If
                If GridView1.Rows.Count >= 9 Then
                    commserver.Parameters.AddWithValue("s_n9", GridView1.Rows(8).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip9", GridView1.Rows(8).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n9", "")
                    commserver.Parameters.AddWithValue("s_ip9", "")
                End If
                If GridView1.Rows.Count >= 10 Then
                    commserver.Parameters.AddWithValue("s_n10", GridView1.Rows(9).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip10", GridView1.Rows(9).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n10", "")
                    commserver.Parameters.AddWithValue("s_ip10", "")
                End If
                If GridView1.Rows.Count >= 11 Then
                    commserver.Parameters.AddWithValue("s_n1", GridView1.Rows(10).Cells(1).Text.Replace("&nbsp;", ""))
                    commserver.Parameters.AddWithValue("s_ip1", GridView1.Rows(10).Cells(2).Text.Replace("&nbsp;", ""))
                Else
                    commserver.Parameters.AddWithValue("s_n1", "")
                    commserver.Parameters.AddWithValue("s_ip1", "")
                End If
                commserver.Parameters.Add("id", SqlDbType.Int)
                commserver.Parameters("id").Direction = ParameterDirection.Output
                commserver.ExecuteNonQuery()
                Session("ServerID") = Convert.ToString(commserver.Parameters("id").Value)
                connserver.Close()
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
            End Try

        End If

        '============insertTech2============

        Dim ConnTech As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commTech As New Data.SqlClient.SqlCommand
        Try
            connTech.Open()
            commTech.Connection = connTech
            commTech.CommandType = CommandType.StoredProcedure
            commTech.CommandText = "insertTech2"
            commTech.Parameters.AddWithValue("em", Server.HtmlEncode(TechEmailTextBox.Text))
            commTech.Parameters.AddWithValue("mob", Server.HtmlEncode(TechMobileTextBox.Text))
            commTech.Parameters.AddWithValue("name", Server.HtmlEncode(TechTextBox.Text))
            commTech.Parameters.Add("id", SqlDbType.Int)
            commTech.Parameters("id").Direction = ParameterDirection.Output
            commTech.ExecuteNonQuery()
            Session("TechID") = Convert.ToString(commTech.Parameters("id").Value)
            connTech.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            connTech.Close()
        End Try
        '============insertBill2============
        Dim connBill As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commBill As New Data.SqlClient.SqlCommand
        Try
            connBill.Open()
            commBill.Connection = connBill
            commBill.CommandType = CommandType.StoredProcedure
            commBill.CommandText = "insertBill2"
            commBill.Parameters.AddWithValue("em", Server.HtmlEncode(BillEmail.Text))
            commBill.Parameters.AddWithValue("mob", Server.HtmlEncode(BillMobileText.Text))
            commBill.Parameters.AddWithValue("name", Server.HtmlEncode(BillTextBox.Text))
            commBill.Parameters.Add("id", SqlDbType.Int)
            commBill.Parameters("id").Direction = ParameterDirection.Output
            commBill.ExecuteNonQuery()
            Session("BillID") = Convert.ToString(commBill.Parameters("id").Value)
            connBill.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            connBill.Close()
        End Try
        '===================INSERT_DOMAINS========================
        Try
            Dim connget As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commget As New SqlClient.SqlCommand
            connget.Open()
            Dim red1get As SqlClient.SqlDataReader
            commget.Connection = connget
            commget.CommandText = "getReserved"
            commget.CommandType = CommandType.StoredProcedure
            commget.Parameters.AddWithValue("DN", Server.HtmlEncode(Domain_name.Text))
            red1get = commget.ExecuteReader()
            red1get.Read()
            If (red1get.HasRows = True) Then
                Response.Redirect("mydomains.aspx")
            End If
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim red1 As Data.SqlClient.SqlDataReader
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "SELECT_OWN"
            comm.Parameters.AddWithValue("DN", Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")))
            comm.Parameters.AddWithValue("SD", SecondDomain.SelectedValue)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            If red1.HasRows = True Then
                Response.Redirect("mydomains.aspx")
            End If

            Dim connDomain As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commDomain As New Data.SqlClient.SqlCommand
            commDomain.Connection = connDomain
            connDomain.Open()
            commDomain.CommandText = "INSERT_DOMAINS"
            commDomain.Parameters.AddWithValue("On", Server.HtmlEncode(OwnerNameTextBox.Text))
            commDomain.Parameters.AddWithValue("DN", Server.HtmlEncode(Domain_name.Text.ToLower))
            commDomain.Parameters.AddWithValue("SEC", Server.HtmlEncode(SecondDomain.SelectedValue))
            commDomain.Parameters.AddWithValue("O_NAME", Server.HtmlEncode(OwnerNameTextBox.Text))
            commDomain.Parameters.AddWithValue("EMAIL", Server.HtmlEncode(OwnerEmailTextBox.Text))
            commDomain.Parameters.AddWithValue("AD", Session("User_ID"))
            commDomain.Parameters.AddWithValue("NationalNo", Server.HtmlEncode(NationalNo.Text))
            commDomain.Parameters.AddWithValue("Description", Server.HtmlEncode(OrgDetailTextBox.Text))
            commDomain.Parameters.AddWithValue("ClassID", Classification.SelectedValue)
            commDomain.Parameters.AddWithValue("specialid", Session("specialid"))
            If reservedfuture.Checked = True Then
                commDomain.Parameters.AddWithValue("NS", 0)
            Else
                commDomain.Parameters.AddWithValue("NS", Session("ServerID"))
            End If
            commDomain.Parameters.AddWithValue("IMM", reservedfuture.Checked)
            commDomain.Parameters.AddWithValue("TECH", Session("TechID"))
            commDomain.Parameters.AddWithValue("BIL", Session("BillID"))
            commDomain.Parameters.AddWithValue("MOB", Server.HtmlEncode(OwnerMobileTextBox.Text))
            commDomain.Parameters.AddWithValue("Lang_Flag", Session("lang"))
            commDomain.CommandType = Data.CommandType.StoredProcedure
            commDomain.Parameters.Add("domainid", SqlDbType.Int)
            commDomain.Parameters("domainid").Direction = ParameterDirection.Output
            commDomain.ExecuteNonQuery()
            Session("domainid") = Convert.ToString(commDomain.Parameters("domainid").Value)
            connDomain.Close()
            Session("DID") = Session("domainid")
            add_domanes_Log(Session("domainid"), 1)
            send_regester_EMail(Session("domainid"))
            Toastr.ShowToast(Me, ToastType.Info, lang.thankyouMSg, lang.recieved, ToastPosition.TopCenter)
            Dim MobileNo As String = Server.HtmlEncode(AdminMobileTextBox.Text)
            Dim MobileNoTrimmed As String = ""
            MobileNoTrimmed = Trim(MobileNo)
            MobileNoTrimmed = MobileNoTrimmed.Replace(" ", "")
            MobileNoTrimmed = MobileNoTrimmed.Replace(".", "")
            MobileNoTrimmed = MobileNoTrimmed.Replace(".", "+")
            If MobileNoTrimmed.Length >= 9 Then
                MobileNoTrimmed = MobileNoTrimmed.Substring(MobileNoTrimmed.Length - 9, 9)
            End If
            If MobileNoTrimmed.Length >= 9 Then
                MobileNoTrimmed = "962" & MobileNoTrimmed
                Dim SMSstr As String = lang.thankyouMSg
                SMSstr &= "  " & lang.DomainName & "  "
                SMSstr &= lang.Reg2 & "  " & lang.proceed
                SMSstr &= "  " & lang.websiteTel
                Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & SMSstr & "&mobile_number=" & MobileNoTrimmed & "&from=" & "domain.jo" & "&tag=" & 1
                ReusableCode.VisitURL(Url1)
            End If
            Session("notfinished") = 1
            Response.Redirect("UploadDoc.aspx")
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

        Response.Redirect("UploadDoc.aspx")
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As String
        Dim randomInt32 As Integer = 0
        Dim rngCrypto As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        For i As Integer = 0 To 6 - 1
            Dim randomUnsignedInteger32Bytes As Byte() = New Byte(3) {}
            rngCrypto.GetBytes(randomUnsignedInteger32Bytes)
            randomInt32 = BitConverter.ToInt32(randomUnsignedInteger32Bytes, 0)
        Next
        Return Convert.ToString(randomInt32)
    End Function

    Protected Sub FinishRegistration_Click(sender As Object, e As EventArgs)
        Dim lang As New Languages(Session("lang"))
        Dim fileCount As Integer = 0

        If agree.Checked = False Then
            Toastr.ShowToast(Me, ToastType.Error, lang.clarify, lang.EError, ToastPosition.TopCenter)
        Else
            '=========================Upload Files=============================
            Dim rand As String = ""

            DomainInfo.Visible = False
            DocumentInfo.Visible = False
            ContactInfo.Visible = False
            ServerP.Visible = False
            ContactInfotab.Visible = False
            DomainInfotab.Visible = False
            Servertab.Visible = False
            Documenttab.Visible = False
            Label5.Text = lang.thankyouMSg2
            Label5.Visible = True

        End If
    End Sub

    Private Function add_domanes_Log(ByVal Max_domanes As Integer, ByVal status_id As Integer) As Boolean
        Dim lang As New Languages(Session("lang"))
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "insert_log4"
            comm.Parameters.AddWithValue("domain_id", Max_domanes)
            comm.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm.Parameters.AddWithValue("status", status_id)
            comm.Parameters.AddWithValue("date", Now)
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
            add_domanes_Log = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Me, ToastType.Error, lang.ERRORLOG, lang.EError, ToastPosition.TopCenter)
            conn.Close()
            add_domanes_Log = False
        End Try

    End Function
    Protected Sub NextToStep3_Click(sender As Object, e As EventArgs)
        Dim lang As New Languages(Session("lang"))
        If reservedfuture.Checked = False And GridView1.Rows.Count <= 0 Then
            Toastr.ShowToast(Me, ToastType.Warning, lang.nameserverisRequired, lang.Note, ToastPosition.TopCenter)
        Else

            If Request.QueryString("folder") <> "" Then
                sFolder = "..\DOC"
            End If
            Me.Page.Form.Enctype = "multipart/form-data"
            Dim sFolderPath As String = Server.MapPath(sFolder)
            If System.IO.Directory.Exists(sFolderPath) = False Then
                Response.Write(lang.isExist & sFolderPath)
                Response.End()
            End If

            DomainInfo.CssClass = "tab-pane"
            DomainInfotab.Attributes.Remove("class")
            DomainInfotab.Attributes.Add("class", "nav-link")
            ServerP.CssClass = "tab-pane"
            Servertab.Attributes.Remove("class")
            Servertab.Attributes.Add("class", "nav-link")
            ContactInfo.CssClass = "tab-pane active show"
            ContactInfotab.Attributes.Remove("class")
            ContactInfotab.Attributes.Add("class", "nav-link active")
            ContactPanel.CssClass = "tab-pane active show"
            Documenttab.Attributes.Remove("class")
            Documenttab.Attributes.Add("class", "nav-link")
            ContactPanel.Enabled = True
            ContactInfo.Enabled = True
            ServerP.Enabled = False
            DomainInfo.Enabled = False
        End If

    End Sub
    Protected Sub reservedfuture_CheckedChanged(sender As Object, e As EventArgs)
        If reservedfuture.Checked = True Then
            all.Visible = False
            reservedfuture.Visible = True
            NextToStep3.Visible = True
        Else
            all.Visible = True
            reservedfuture.Visible = True
            NextToStep3.Visible = True

        End If

    End Sub
    Protected Sub SecondDomain_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim ZipRegex As String
        If SecondDomain.SelectedValue <> 12 Then
            ZipRegex = "^[A-Za-z0-9\-]{1,63}$"
        Else
            ZipRegex = "^[ء-ي0-9\-]{1,63}$"
        End If
        Dim lang As New Languages(Session("lang"))

        If Not ((Regex.IsMatch(Domain_name.Text, ZipRegex))) Then
            Toastr.ShowToast(Me, ToastType.Error, lang.validexp2, lang.EError, ToastPosition.TopCenter)
            Disable()
        Else

            Try
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm As New Data.SqlClient.SqlCommand
                Dim red1 As Data.SqlClient.SqlDataReader
                Dim test As Boolean
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "SELECT_OWN"
                comm.Parameters.AddWithValue("DN", Trim((CStr(Server.HtmlEncode(Domain_name.Text)).ToLower).Replace(" ", "")))
                comm.Parameters.AddWithValue("SD", SecondDomain.SelectedValue)
                comm.CommandType = Data.CommandType.StoredProcedure
                red1 = comm.ExecuteReader()
                If red1.HasRows = False And Domain_name.Text <> "" Then
                    DomainLiteral1.Text = ""
                    Toastr.ShowToast(Me, ToastType.Info, lang.Available, lang.Available, ToastPosition.TopCenter)
                    EnableFirst1()
                    Toastr.ShowToast(Me, ToastType.Info, lang.Available, lang.Available, ToastPosition.TopCenter)

                End If
                While red1.Read
                    Disable()
                    DomainLiteral1.Text = lang.Reg
                    DomainLiteral1.Text += "<font color=red><b><i>" + red1.Item(0) + "</b></i></font>"
                    DomainLiteral1.Text += "<BR><BR>"

                    test = True
                    Exit While
                End While
                red1.Close()
                conn.Close()

                If test = False Then
                    Toastr.ShowToast(Me, ToastType.Info, lang.Available, lang.Available, ToastPosition.TopCenter)
                    Dim connRegex As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commRegex As New SqlClient.SqlCommand
                    connRegex.Open()
                    Dim red1Regex As SqlClient.SqlDataReader
                    commRegex.Connection = connRegex
                    commRegex.CommandText = "MatchRegex"
                    commRegex.CommandType = CommandType.StoredProcedure
                    red1Regex = commRegex.ExecuteReader()
                    While red1Regex.Read
                        If Regex.IsMatch(Server.HtmlEncode(Domain_name.Text), red1Regex("regex")) Then
                            DomainLiteral1.Text = "<font color=red>" + lang.specialfees + "</font>"
                            If SecondDomain.SelectedValue = 7 Then
                                Session("specialid") = red1Regex("id")
                            Else
                                Session("specialid") = red1Regex("id") + 1
                            End If
                            Exit While
                        Else
                            DomainLiteral1.Text = ""
                            Session("specialid") = 0
                        End If

                    End While
                    red1Regex.Close()
                End If

            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                Toastr.ShowToast(Me, ToastType.Error, lang.EError, lang.EError, ToastPosition.TopCenter)
            End Try
        End If
    End Sub
    Private Function isvalueExist(ByVal PassedValue As String) As Boolean

        Dim checkvalue As Boolean = False
        Dim count As Integer = GridView1.Rows.Count
        Dim i As Integer = 0
        For j As Integer = 0 To count - 1
            If GridView1.Rows(j).Cells(1).Text = PassedValue Then
                checkvalue = True
                Exit For
            End If
        Next
        Return checkvalue
    End Function
    Public dt As DataTable = Nothing
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        Try


            If Page.IsValid = True Then
                Dim lang As New Languages(Session("lang"))
                Dim isExist As Boolean
                Dim nameserver As String = Server.HtmlEncode(PrimaryNameServerTextBox.Text.Trim())
                Dim serverip As String = Server.HtmlEncode(PrimaryNameServeripTextBox.Text.Trim())
                dt = CType(ViewState("Details"), DataTable)

                isExist = isvalueExist(nameserver)

                If isExist = True Then
                    Toastr.ShowToast(Me, ToastType.Warning, lang.AddTwice, lang.Note, ToastPosition.TopCenter)
                Else
                    If GridView1.Rows.Count < 10 Then
                        dt.Rows.Add(nameserver, serverip)
                        GridView1.Visible = True
                        ViewState("Details") = dt
                        GridView1.DataSource = dt
                        GridView1.EmptyDataText = lang.Sname1
                        GridView1.EmptyDataText = lang.SecondIP1
                        GridView1.DataBind()
                        PrimaryNameServerTextBox.Text = ""
                        PrimaryNameServeripTextBox.Text = ""
                    Else
                        Toastr.ShowToast(Me, ToastType.Warning, lang.maximumnameserver, lang.Note, ToastPosition.TopCenter)
                    End If
                End If
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Function send_regester_EMail(ByVal domanes_id As Integer) As Boolean
        Dim lang As Languages = New Languages(Session("lang"))
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim comm2 As New SqlClient.SqlCommand
        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim recipant_email, Subject, DOMAIN_NAME, SECOND_DOMAINN, message_body, message_body1 As String
        recipant_email = ""
        Subject = ""
        DOMAIN_NAME = ""
        SECOND_DOMAINN = ""
        message_body1 = ""
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "domain_admin"
            comm.Parameters.AddWithValue("domain_id", domanes_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                If Not red1.Item("EMAIL") Is DBNull.Value Then
                    recipant_email = red1.Item("EMAIL")
                End If
                If Not red1.Item("DOMAIN_NAME") Is DBNull.Value Then
                    DOMAIN_NAME = red1.Item("DOMAIN_NAME").ToLower
                End If
                If Not red1.Item("SECOND_DOMAIN") Is DBNull.Value Then
                    SECOND_DOMAINN = red1.Item("SECOND_DOMAIN").ToLower
                End If

            End While
            red1.Close()
            conn.Close()
            conn2.Open()
            comm2.Connection = conn2
            comm2.CommandText = "SelectEmailTextID"
            If Session("lang") = "en" Then
                comm2.Parameters.AddWithValue("ID", 13)

            Else
                comm2.Parameters.AddWithValue("ID", 1)
            End If

            comm2.CommandType = Data.CommandType.StoredProcedure
            red1 = comm2.ExecuteReader()
            While red1.Read
                If Session("lang") = "en" Then
                    If red1("id") = 13 Then
                        Subject = lang.DomainReg
                        Subject &= "(" & DOMAIN_NAME & SECOND_DOMAINN & ")"
                        message_body1 = Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part1"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part2"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part3"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part4")) & Server.HtmlDecode(red1.Item("part5"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part6"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("footer")))
                    End If
                Else
                    If red1("id") = 1 Then
                        Subject = lang.DomainReg
                        Subject &= "(" & DOMAIN_NAME & SECOND_DOMAINN & ")"
                        message_body1 = Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part1"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part2"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part3"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part4")) & Server.HtmlDecode(red1.Item("part5"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("part6"))) & Server.HtmlDecode(System.Web.HttpUtility.HtmlDecode(red1.Item("footer")))

                    End If
                End If

            End While
            red1.Close()
            conn2.Close()



            message_body = message_body1

            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)

            send_regester_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Register:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            Toastr.ShowToast(Me, ToastType.Error, lang.errsendemail, lang.EError, ToastPosition.TopCenter)
            conn.Close()
        End Try
        conn.Close()
        Return send_regester_EMail
    End Function


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        dt = CType(ViewState("Details"), DataTable)
        ViewState("Details") = dt
        dt.Rows.RemoveAt(e.RowIndex)
        ViewState("Details") = dt
        If (GridView1.Rows.Count = 1) Then
            GridView1.Visible = False
        End If
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub

    Protected Sub Prevto3_Click(sender As Object, e As EventArgs)
        ServerP.CssClass = "tab-pane active show"
        ServerP.Attributes.Remove("class")
        ServerP.Attributes.Add("class", "nav-link active")
        ContactInfo.CssClass = "tab-pane"
        ContactInfotab.Attributes.Remove("class")
        Servertab.Attributes.Remove("class")
        Servertab.Attributes.Add("class", "nav-link active")
        ContactInfotab.Attributes.Add("class", "nav-link")
        ContactInfo.Enabled = False
        ServerP.Enabled = True
        DomainInfo.Enabled = False
    End Sub

    Protected Sub PrevLast_Click(sender As Object, e As EventArgs)
        DomainInfo.CssClass = "tab-pane"
        DomainInfotab.Attributes.Remove("class")
        DomainInfotab.Attributes.Add("class", "nav-link")
        ServerP.CssClass = "tab-pane"
        Servertab.Attributes.Remove("class")
        Servertab.Attributes.Add("class", "nav-link")
        DocumentInfo.CssClass = "tab-pane"
        Documenttab.Attributes.Remove("class")
        Documenttab.Attributes.Add("class", "nav-link")
        ContactPanel.CssClass = "tab-pane active show"
        ContactInfotab.Attributes.Remove("class")
        ContactInfotab.Attributes.Add("class", "nav-link active")
        ContactPanel.Enabled = True
        ContactPanel.Visible = True
        ContactInfo.CssClass = "tab-pane active show"
        ContactInfo.Enabled = True
        ServerP.Enabled = False
        DomainInfo.Enabled = False
    End Sub


End Class