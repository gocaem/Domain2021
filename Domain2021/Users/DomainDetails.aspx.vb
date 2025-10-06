Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports Microsoft.Security.Application
Imports Domain2021.Toastr
Imports System.Net
Imports System.Threading

Public Class DomainDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If

        If Session("DID") Is Nothing Then
            Response.Redirect("mydomains.aspx")
        End If
        If Page.IsPostBack = False Then
            SetLanguage()
            fill_db(Session("DID"))
            saveold()
        End If
        Session("page") = "DomainDetails"


    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub
    Sub DisableAll()
        Nameserver1TextBox.Enabled = False
        PrimaryNameServeripTextBox.Enabled = False
        PrimaryNameServerTextBox.Enabled = False
        NameserverIP1TextBox.Enabled = False
        Nameserver1TextBox.Enabled = False
        Nameserver2TextBox.Enabled = False
        NameserverIP2TextBox.Enabled = False
        Nameserver3TextBox.Enabled = False
        Nameserverip3TextBox.Enabled = False
        Nameserver4TextBox.Enabled = False
        OwnerEmailTextBox.Enabled = False
        Nameserver6TextBox.Enabled = False
        Nameserver6ipTextBox.Enabled = False
        Nameserver7TextBox.Enabled = False
        Nameserver7ipTextBox.Enabled = False
        Nameserver8TextBox.Enabled = False
        Nameserver8ipTextBox.Enabled = False
        Nameserver9TextBox.Enabled = False
        Nameserver9ipTextBox.Enabled = False
        Nameserver10TextBox.Enabled = False
        Nameserver10ipTextBox.Enabled = False
        OwnerMobileTextBox.Enabled = False
        Nameserver9ipTextBox.Enabled = False
        Nameserver5ipTextBox.Enabled = False
        Nameserver4ipTextBox.Enabled = False
        Nameserver5TextBox.Enabled = False
        TechEmailTextBox.Enabled = False
        TechMobileTextBox.Enabled = False
        BillMobileText.Enabled = False
        BillEmail.Enabled = False
    End Sub

    Private Sub fill_db(ByVal Dom_id As Integer)
        Try

            Dim lang As New Languages(Session("lang"))
            Dim connectionstr As DAL = New DAL()
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd2 As New SqlClient.SqlCommand("dom_det", ocon2)
            Dim odr As SqlDataReader
            ocon2.Open()
            ocmd2.CommandType = CommandType.StoredProcedure
            ocmd2.Parameters.AddWithValue("domain_id", Dom_id)
            odr = ocmd2.ExecuteReader()
            While odr.Read
                If Not odr("status") Is DBNull.Value Then
                    LBL_STATUS.Text += " : "
                    LBL_STATUS.Text += "  " + odr("STATUS")
                    If (odr("STATUS")) <> "OnLine" Then
                        NextToStep4.Visible = False
                        DisableAll()
                    End If
                    LBL_STATUS.Text += "  " & " ||  " + lang.DomainName + " : " + Session("domain")
                End If
                If LBL_STATUS.Text.Contains("UpdateNeedApprove") Then
                    Cancel.Visible = True
                End If
                If Not odr("tech_code_id") Is DBNull.Value Then
                    Session("TECH_CONTACT_par") = odr("tech_code_id")
                End If
                If Not odr("billing_code_id") Is DBNull.Value Then
                    Session("BILLING_CONTACT_par") = odr("billing_code_id")
                End If
                If Not odr("admin1") Is DBNull.Value Then
                    Session("Admin_ID_par") = odr("admin1")
                End If

                If Not odr("P_SERVER_NAME") Is DBNull.Value Then
                    PrimaryNameServerTextBox.Text = odr("P_SERVER_NAME").ToString.ToLower
                End If
                If Not odr("P_SERVER_IP") Is DBNull.Value Then
                    PrimaryNameServeripTextBox.Text = odr("P_SERVER_IP").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME") Is DBNull.Value Then
                    Nameserver1TextBox.Text = odr("S_SERVER_NAME").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP") Is DBNull.Value Then
                    NameserverIP1TextBox.Text = odr("S_SERVER_IP").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME2") Is DBNull.Value Then
                    Nameserver2TextBox.Text = odr("S_SERVER_NAME2").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP2") Is DBNull.Value Then
                    NameserverIP2TextBox.Text = odr("S_SERVER_IP2").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME3") Is DBNull.Value Then
                    Nameserver3TextBox.Text = odr("S_SERVER_NAME3").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP3") Is DBNull.Value Then
                    Nameserverip3TextBox.Text = odr("S_SERVER_IP3").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME4") Is DBNull.Value Then
                    Nameserver4TextBox.Text = odr("S_SERVER_NAME4").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP4") Is DBNull.Value Then
                    Nameserver4ipTextBox.Text = odr("S_SERVER_IP4").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME5") Is DBNull.Value Then
                    Nameserver5TextBox.Text = odr("S_SERVER_NAME5").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP5") Is DBNull.Value Then
                    Nameserver5ipTextBox.Text = odr("S_SERVER_IP5").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME6") Is DBNull.Value Then
                    Nameserver6TextBox.Text = odr("S_SERVER_NAME6").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP6") Is DBNull.Value Then
                    Nameserver6ipTextBox.Text = odr("S_SERVER_IP6").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME7") Is DBNull.Value Then
                    Nameserver7TextBox.Text = odr("S_SERVER_NAME7").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP7") Is DBNull.Value Then
                    Nameserver7ipTextBox.Text = odr("S_SERVER_IP7").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME8") Is DBNull.Value Then
                    Nameserver8TextBox.Text = odr("S_SERVER_NAME8").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP8") Is DBNull.Value Then
                    Nameserver8ipTextBox.Text = odr("S_SERVER_IP8").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME9") Is DBNull.Value Then
                    Nameserver9TextBox.Text = odr("S_SERVER_NAME9").ToString.ToLower
                End If
                If Not odr("S_SERVER_IP9") Is DBNull.Value Then
                    Nameserver9ipTextBox.Text = odr("S_SERVER_IP9").ToString.ToLower
                End If
                If Not odr("S_SERVER_NAME10") Is DBNull.Value Then
                    Nameserver10TextBox.Text = odr("S_SERVER_NAME10").ToString.ToLower
                End If
                If Not odr("name_server_id") Is DBNull.Value Then
                    Session("nserver") = odr("name_server_id")
                End If
                If Not odr("S_SERVER_IP10") Is DBNull.Value Then
                    Nameserver10ipTextBox.Text = odr("S_SERVER_IP10").ToString.ToLower
                End If


                If Not odr("tech_email") Is DBNull.Value Then
                    TechEmailTextBox.Text = odr("tech_email")
                End If
                If Not odr("tech_contact") Is DBNull.Value Then
                    TechTextBox.Text = odr("tech_contact")
                End If
                If Not odr("tech_mobile") Is DBNull.Value Then
                    TechMobileTextBox.Text = odr("tech_mobile")
                End If
                If Not odr("billing_email") Is DBNull.Value Then
                    BillEmail.Text = odr("billing_email")
                End If
                If Not odr("billing_contact") Is DBNull.Value Then
                    BillTextBox.Text = odr("billing_contact")
                End If
                If Not odr("billing_mobile") Is DBNull.Value Then
                    BillMobileText.Text = odr("billing_mobile")
                End If
                If Not odr("admin_email") Is DBNull.Value Then
                    AdminEmailTextBox.Text = odr("admin_email")
                End If
                If Not odr("mobile_admin") Is DBNull.Value Then
                    AdminMobileTextBox.Text = odr("mobile_admin")
                End If
                If Not odr("admin_contact") Is DBNull.Value Then
                    AdminTextBox.Text = odr("admin_contact")
                End If
                If Not odr("owner_name") Is DBNull.Value Then
                    OwnerNameLbl.Text = odr("owner_name")
                End If
                If Not odr("org_name") Is DBNull.Value Then
                    lblentity.Text = odr("org_name")
                End If
                If Not odr("mobile_domains") Is DBNull.Value Then
                    OwnerMobileTextBox.Text = odr("mobile_domains")
                End If
                If Not odr("org_email") Is DBNull.Value Then
                    OwnerEmailTextBox.Text = odr("org_email")
                End If

                If odr("name_server_id") = 0 Then
                    PrimaryNameServerTextBox.Text = lang.parked
                End If
            End While
            odr.Close()
            ocon2.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub reservedfuture_CheckedChanged(sender As Object, e As EventArgs)
        If reservedfuture.Checked = True Then
            all.Visible = False
            reservedfuture.Visible = True

        Else
            all.Visible = True
            reservedfuture.Visible = True

        End If

    End Sub
    Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        LBL_STATUS.Text = lang.status
        reservedfuture.Text = lang.future
        Cancel.Text = lang.CancelUpdate
        reservedfuture.Font.Bold = True
        card1.Style.Add("font-weight", "bold")
        all.Style.Add("font-family", lang.fonta)
        PrimaryNameServerLabel.Text = lang.Pname
        PrimaryNameServerip.Text = lang.PRIMARYIP
        Nameserver10ipLabel.Text = lang.SecondIP + "10"
        Nameserver10Label.Text = lang.Sname + "10"
        Nameserver1Label.Text = lang.Sname + "1"
        NameserverIP1Label.Text = lang.SecondIP + "1"
        NameserverIP2Label.Text = lang.SecondIP + "2"
        Nameserver2Label.Text = lang.Sname + "2"
        Nameserverip3Label.Text = lang.SecondIP + "3"
        Nameserver3Label.Text = lang.Sname + "3"
        Nameserver4ipLabel.Text = lang.SecondIP + "4"
        Nameserver4Label.Text = lang.Sname + "4"
        Nameserver5ipLabel.Text = lang.SecondIP + "5"
        Nameserver5Label.Text = lang.Sname + "5"
        Nameserver6ipLabel.Text = lang.SecondIP + "6"
        Nameserver6Label.Text = lang.Sname + "6"
        Nameserver7ipLabel.Text = lang.SecondIP + "7"
        Nameserver7Label.Text = lang.Sname + "7"
        Nameserver8ipLabel.Text = lang.SecondIP + "8"
        Nameserver8Label.Text = lang.Sname + "8"
        Nameserver9ipLabel.Text = lang.SecondIP + "9"
        Nameserver9Label.Text = lang.Sname + "9"
        first.InnerText = lang.Upate + "  " + lang.Servers2
        Second1.InnerText = lang.Upate + "  " + lang.ContactData
        IPadd.Text = lang.validIP
        IPadd3.Text = lang.validIP
        IPadd4.Text = lang.validIP
        IPadd5.Text = lang.validIP
        IPadd6.Text = lang.validIP
        IPadd7.Text = lang.validIP
        IPadd8.Text = lang.validIP
        IPadd9.Text = lang.validIP
        IPadd10.Text = lang.validIP
        IPadd11.Text = lang.validIP
        IPadd2.Text = lang.validIP
        accordionExample.Style.Add("font-family", lang.fonta)
        accordionExample.Style.Add("Direction", lang.dir)
        first.Style.Add("font-family", lang.fonta)
        Second1.Style.Add("font-family", lang.fonta)
        card1.Style.Add("Direction", lang.dir)
        OwnerDetailsLabel.Text = lang.ownerd
        TechDetailsLabel.Text = lang.Tech
        BillingDetails.Text = lang.bill
        AdminDetails.Text = lang.Admin
        prev.Text = lang.prev2
        EntityName.Text = lang.EntityName + " : "
        prev.Style.Add("font-family", lang.fonta)
        Second1.Disabled = True
        OwnerEmailLabel.Text = lang.Email
        OwnerMobileLabel.Text = lang.Mobile
        OwnerName.Text = lang.Oname + " : "
        TechLabel.Text = lang.Tech
        TechMobileLabel.Text = lang.Mobile
        TechEmailLabel.Text = lang.Email
        AdminDetailsLabel.Text = lang.Admin
        AdminMobileLabel.Text = lang.Mobile
        AdminEmailLabel.Text = lang.Email
        BillLabel.Text = lang.bill
        BillMobileLabel.Text = lang.Mobile
        BillEmailLabel.Text = lang.Email
        OwnerEmailValidator.Text = lang.RequiredField2
        TechValidator.Text = lang.RequiredField2
        TechMobileValidator.Text = lang.RequiredField2
        TechEmailTextBoxValidator.Text = lang.RequiredField2
        AdminTextBoxValidator.Text = lang.RequiredField2
        AdminEmailTextBoxValidator.Text = lang.RequiredField2
        AdminMobileTextBoxValidator.Text = lang.RequiredField2
        BillingValidator.Text = lang.RequiredField2
        BillMobileValidator.Text = lang.RequiredField2
        BillEmailValidator.Text = lang.RequiredField2
        OwnerMobileValidator.Text = lang.RequiredField2
        TechEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        BillEmailExpressionValidator.Text = lang.InvalidEmail
        OwnerEmailExpressionValidator.Text = lang.InvalidEmail
        TechEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        BillEmailExpressionValidator.Text = lang.InvalidEmail
        OwnerEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailTextBox.Enabled = False
        AdminMobileTextBox.Enabled = False
        AdminTextBox.Enabled = False
        OwnerEmailValidator.ErrorMessage = lang.RequiredField2
        TechValidator.ErrorMessage = lang.RequiredField2
        TechMobileValidator.ErrorMessage = lang.RequiredField2
        TechEmailTextBoxValidator.ErrorMessage = lang.RequiredField2
        AdminTextBoxValidator.ErrorMessage = lang.RequiredField2
        AdminEmailTextBoxValidator.ErrorMessage = lang.RequiredField2
        AdminMobileTextBoxValidator.ErrorMessage = lang.RequiredField2
        BillingValidator.ErrorMessage = lang.RequiredField2
        BillMobileValidator.ErrorMessage = lang.RequiredField2
        BillEmailValidator.ErrorMessage = lang.RequiredField2
        OwnerMobileValidator.ErrorMessage = lang.RequiredField2
        TechEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        AdminEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        BillEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        OwnerEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        TechEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        AdminEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        BillEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        OwnerEmailExpressionValidator.ErrorMessage = lang.InvalidEmail
        NextToStep4.Text = lang.UpdateDomain
        NextToStep4.Font.Name = lang.fonta
        Cancel.Font.Name = lang.fonta
        NextToStep4.Font.Bold = True
        NextToStep2.Text = lang.NextS
        NextToStep2.Font.Name = lang.fonta
        NextToStep2.Font.Bold = True
        RequiredFieldValidator1.Text = lang.RequiredField2
        RequiredFieldValidator1.ErrorMessage = lang.RequiredField2
        ServerP.Style.Add("font-family", lang.fonta)
        ContactPanel.Style.Add("font-family", lang.fonta)
        first.Disabled = True
    End Sub
    Sub saveold()
        Session("OldMobile") = Server.HtmlEncode(OwnerMobileTextBox.Text)
        Session("OldEmail") = Server.HtmlEncode(OwnerEmailTextBox.Text)
        Session("Oldowner_name") = Server.HtmlEncode(OwnerNameLbl.Text)
    End Sub
    Protected Sub NextToStep4_Click(sender As Object, e As EventArgs)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim conninsert_Before As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comminsert_Before As New Data.SqlClient.SqlCommand
            conninsert_Before.Open()
            comminsert_Before.Connection = conninsert_Before
            comminsert_Before.CommandText = "insert_BeforeUpdateAfterLog"
            comminsert_Before.Parameters.AddWithValue("domain_id", Session("DID"))
            If PrimaryNameServerTextBox.Text = "Parked" Then
                comminsert_Before.Parameters.AddWithValue("OldServerID", 0)
            Else
                comminsert_Before.Parameters.AddWithValue("OldServerID", Session("nserver"))
            End If
            comminsert_Before.Parameters.AddWithValue("OldTechIID", Session("TECH_CONTACT_par"))
            comminsert_Before.Parameters.AddWithValue("OldBillingID", Session("BILLING_CONTACT_par"))
            comminsert_Before.Parameters.AddWithValue("NewTechIID", update_technical_contact())
            comminsert_Before.Parameters.AddWithValue("NewBillingID", update_billing_contact())
            comminsert_Before.Parameters.AddWithValue("NewServerID", update_names_server())
            comminsert_Before.Parameters.AddWithValue("NewPhone", Server.HtmlEncode(OwnerMobileTextBox.Text))
            comminsert_Before.Parameters.AddWithValue("NewEmail", Server.HtmlEncode(OwnerEmailTextBox.Text))
            comminsert_Before.Parameters.AddWithValue("OldPhone", Session("OldMobile").ToString())
            comminsert_Before.Parameters.AddWithValue("OldEmail", Session("OldEmail").ToString())
            comminsert_Before.Parameters.AddWithValue("Oldowner_name", OwnerNameLbl.Text)
            comminsert_Before.Parameters.AddWithValue("Newowner_name", OwnerNameLbl.Text)
            comminsert_Before.CommandType = Data.CommandType.StoredProcedure
            comminsert_Before.ExecuteNonQuery()
            conninsert_Before.Close()
            '-----------------------------------------------------
            Dim lang As New Languages(Session("lang"))
            If Not Session("User_ID") Is Nothing Then
                Dim conncheck As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim commcheck As New Data.SqlClient.SqlCommand
                Dim odrisAdmin As Data.SqlClient.SqlDataReader
                conncheck.Open()
                commcheck.Connection = conncheck
                commcheck.CommandText = "checkAdmin_domain"
                commcheck.Parameters.AddWithValue("did", Session("DID"))
                commcheck.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
                commcheck.CommandType = Data.CommandType.StoredProcedure
                odrisAdmin = commcheck.ExecuteReader
                If odrisAdmin.HasRows = False Then
                    Response.Redirect("../logout.aspx")
                Else

                    Dim connLog As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commLog As New Data.SqlClient.SqlCommand
                    Dim connStatus As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim commStatus As New Data.SqlClient.SqlCommand
                    connStatus.Open()
                    commStatus.Connection = connStatus
                    commStatus.CommandText = "update_st_update"
                    commStatus.Parameters.AddWithValue("st", 22)
                    commStatus.Parameters.AddWithValue("did", Session("DID"))
                    commStatus.CommandType = Data.CommandType.StoredProcedure
                    commStatus.ExecuteNonQuery()
                    connStatus.Close()
                    commLog.Connection = connLog
                    commLog.CommandText = "insert_log4"
                    commLog.CommandType = Data.CommandType.StoredProcedure
                    commLog.Parameters.AddWithValue("domain_id", Session("DID"))
                    commLog.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
                    commLog.Parameters.AddWithValue("status", 22)
                    commLog.Parameters.AddWithValue("date", Now)
                    connLog.Open()
                    commLog.ExecuteNonQuery()
                    lbl_result.Visible = True
                    Toastr.ShowToast(Me, ToastType.Info, lang.needapprove, lang.recieved, ToastPosition.TopCenter)
                    connLog.Close()
                    send_update_EMail(Session("DID"))
                    LBL_STATUS.Text = lang.status
                    LBL_STATUS.Text += "UpdateNeedApprove"
                    LBL_STATUS.Text += "  ||  " + lang.DomainName + " : " + Session("domain")
                    NextToStep4.Visible = False
                    lbl_result.Text = lang.Updated
                    lbl_result.ForeColor = System.Drawing.Color.Red
                    lbl_result.Font.Bold = True
                    If LBL_STATUS.Text.Contains("UpdateNeedApprove") Then
                        Cancel.Visible = True
                    End If
                End If
                conncheck.Close()
                odrisAdmin.Close()
            Else
                Response.Redirect("../logout.aspx")
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Next_Click(sender As Object, e As EventArgs)
        collapseTwo.Attributes.Remove("class")
        collapseTwo.Attributes.Add("class", "collapse show")
        collapseOne.Attributes.Remove("class")
        collapseOne.Attributes.Add("class", "collapse")
    End Sub
    Private Function update_names_server() As Integer
        Dim connectionstr As DAL = New DAL()
        Dim connserver As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commserver As New Data.SqlClient.SqlCommand
        Try
            connserver.Open()
            commserver.Connection = connserver
            commserver.CommandType = CommandType.StoredProcedure
            commserver.CommandText = "insert_server_data"
            commserver.Parameters.AddWithValue("p_n", Server.HtmlEncode(PrimaryNameServerTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n", Server.HtmlEncode(Nameserver1TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip", Server.HtmlEncode(NameserverIP1TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("p_ip", Server.HtmlEncode(PrimaryNameServeripTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n3", Server.HtmlEncode(Nameserver3TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip3", Server.HtmlEncode(Nameserverip3TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n4", Server.HtmlEncode(Nameserver4TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip4", Server.HtmlEncode(Nameserver4ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n5", Server.HtmlEncode(Nameserver5TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip5", Server.HtmlEncode(Nameserver5ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n6", Server.HtmlEncode(Nameserver6TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip6", Server.HtmlEncode(Nameserver6ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n7", Server.HtmlEncode(Nameserver7TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip7", Server.HtmlEncode(Nameserver7ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n8", Server.HtmlEncode(Nameserver8TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip8", Server.HtmlEncode(Nameserver8ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n9", Server.HtmlEncode(Nameserver9TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip9", Server.HtmlEncode(Nameserver9ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n10", Server.HtmlEncode(Nameserver10TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip10", Server.HtmlEncode(Nameserver10ipTextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_n1", Server.HtmlEncode(Nameserver2TextBox.Text.ToLower))
            commserver.Parameters.AddWithValue("s_ip1", Server.HtmlEncode(NameserverIP2TextBox.Text.ToLower))
            commserver.Parameters.Add("id", SqlDbType.Int)
            commserver.Parameters("id").Direction = ParameterDirection.Output
            commserver.ExecuteNonQuery()
            Session("ServerID") = Convert.ToString(commserver.Parameters("id").Value)
            connserver.Close()
            Return Session("ServerID")
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            connserver.Close()
        End Try
    End Function

    Private Function update_technical_contact() As Integer
        Dim connectionstr As DAL = New DAL()
        Dim connTech As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commTech As New Data.SqlClient.SqlCommand
        Dim conn4 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm4 As New Data.SqlClient.SqlCommand
        Try
            connTech.Open()
            commTech.Connection = connTech
            commTech.CommandType = CommandType.StoredProcedure
            commTech.CommandText = "insertTech2"
            commTech.Parameters.AddWithValue("em", TechEmailTextBox.Text)
            commTech.Parameters.AddWithValue("mob", TechMobileTextBox.Text)
            commTech.Parameters.AddWithValue("name", TechTextBox.Text)
            commTech.Parameters.Add("id", SqlDbType.Int)
            commTech.Parameters("id").Direction = ParameterDirection.Output
            commTech.ExecuteNonQuery()
            Session("TechID") = Convert.ToString(commTech.Parameters("id").Value)
            Return Session("TechID")
            connTech.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            connTech.Close()
        End Try


    End Function

    Private Function update_billing_contact() As Integer
        Dim connectionstr As DAL = New DAL()
        Dim connBill As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commBill As New Data.SqlClient.SqlCommand
        Dim billing_contact_id As Integer
        Try
            connBill.Open()
            commBill.Connection = connBill
            commBill.CommandType = CommandType.StoredProcedure
            commBill.CommandText = "insertBill2"
            commBill.Parameters.AddWithValue("em", BillEmail.Text)
            commBill.Parameters.AddWithValue("mob", BillMobileText.Text)
            commBill.Parameters.AddWithValue("name", BillTextBox.Text)
            commBill.Parameters.Add("id", SqlDbType.Int)
            commBill.Parameters("id").Direction = ParameterDirection.Output
            commBill.ExecuteNonQuery()
            Session("BillID") = Convert.ToString(commBill.Parameters("id").Value)
            commBill.CommandType = Data.CommandType.StoredProcedure
            commBill.ExecuteNonQuery()
            connBill.Close()
            billing_contact_id = Session("BillID")
            Return Session("BillID")
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Function
    Private Function send_update_EMail(ByVal domanes_id As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conngetdomain As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commgetdomain As New Data.SqlClient.SqlCommand
        Dim redgetdomain As Data.SqlClient.SqlDataReader
        Dim connMail As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commMail As New Data.SqlClient.SqlCommand
        Dim redMail As Data.SqlClient.SqlDataReader
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim recipant_email = "", recipant_name = "", nitc_m = "", Subject = "", DOMAIN_NAME = "", SECOND_DOMAIN = "", OWNER_NAME = "", USER_PASSWORD = "", message_body = "", message_body1 = "", message_body2 = "", message_body3 = "", message_body_4NITC = "", message_body4 = ""
        Try
            conngetdomain.Open()
            commgetdomain.Connection = conngetdomain
            commgetdomain.CommandText = "domain_admin"
            commgetdomain.Parameters.AddWithValue("domain_id", domanes_id)
            commgetdomain.CommandType = Data.CommandType.StoredProcedure
            redgetdomain = commgetdomain.ExecuteReader()
            While redgetdomain.Read
                recipant_email = redgetdomain.Item("EMAIL")
                recipant_name = redgetdomain.Item("COMPANY_USER_NAME")
                OWNER_NAME = redgetdomain.Item("ORG_NAME")
                DOMAIN_NAME = redgetdomain.Item("DOMAIN_NAME")
                SECOND_DOMAIN = redgetdomain.Item("SECOND_DOMAIN")
            End While
            redgetdomain.Close()
            conngetdomain.Close()
            connMail.Open()
            commMail.Connection = connMail
            commMail.CommandText = "ma_t"
            commMail.Parameters.AddWithValue("id", 58)
            commMail.CommandType = Data.CommandType.StoredProcedure
            redMail = commMail.ExecuteReader()
            While redMail.Read
                Subject = redMail.Item("title")
                message_body1 = redMail.Item("body_t") & "<br>"
            End While
            redMail.Close()
            connMail.Close()
            message_body4 = "<b>Domain Name: </b>" & DOMAIN_NAME & SECOND_DOMAIN & "<br>"
            message_body4 += "<b>Registrant: </b>" & OWNER_NAME & "<br>"
            message_body4 += "<b>E-mail Address: </b>" & recipant_email & "<br>"
            message_body = message_body1 & message_body3
            message_body_4NITC = message_body1 & "<br>" & message_body4
            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(nitc_m, "dns@modee.gov.jo", Subject, message_body_4NITC)
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            Toastr.ShowToast(Me, ToastType.Error, lang.erremail, lang.ErrorlblEmail, ToastPosition.TopCenter)
            conngetdomain.Close()
        End Try

    End Function

    Protected Sub prev_Click(sender As Object, e As EventArgs)
        collapseTwo.Attributes.Remove("class")
        collapseTwo.Attributes.Add("class", "collapse")
        collapseOne.Attributes.Remove("class")
        collapseOne.Attributes.Add("class", "collapse show")
    End Sub

    Protected Sub Cancel_Click(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim connStatus As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim commStatus As New SqlCommand
        Dim lang As New Languages(Session("lang"))
        Try
            ''-----------------Updating Status----------
            connStatus.Open()
            commStatus.Connection = connStatus
            commStatus.CommandText = "update_statusCancel"
            commStatus.Parameters.AddWithValue("st", 8)
            commStatus.Parameters.AddWithValue("did", Session("DID"))
            commStatus.CommandType = Data.CommandType.StoredProcedure
            commStatus.ExecuteNonQuery()
            connStatus.Close()
            lbl_result.ForeColor = System.Drawing.Color.Red
            lbl_result.Font.Bold = True
            lbl_result.Text = lang.CancelUpdatePrompt
            LBL_STATUS.Text = ""
            LBL_STATUS.Text += "  " + "OnLine"
            LBL_STATUS.Text += "  " & " ||  " + lang.DomainName + " : " + Session("domain")
            NextToStep4.Visible = True
            Cancel.Visible = False
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainDetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class