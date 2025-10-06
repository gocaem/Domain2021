Imports System.Data.SqlClient
Public Class DomDet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("page") = "DomDet"
        If Session("DID") Is Nothing Then
            Response.Redirect("FirstPage.aspx")
        End If

        fill_db(Session("DID"))
        setLanguage()

        Dim conn15seldet As New SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
        Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("server_data_domain", conn15seldet)
        Dim reader As SqlClient.SqlDataReader
        ocmd15seldet.Parameters.AddWithValue("did", Session("DID"))
        conn15seldet.Open()
        ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
        reader = ocmd15seldet.ExecuteReader()
        While reader.Read
            If Not reader("P_SERVER_NAME") Is DBNull.Value Then
                PrimaryNameServerTextBox.Text = reader("P_SERVER_NAME")
            End If
            If Not reader("S_SERVER_NAME5") Is DBNull.Value Then
                Second_nameTextBox1.Text = reader("S_SERVER_NAME5")
            End If
            If Not reader("S_SERVER_NAME2") Is DBNull.Value Then
                Second_name2TextBox.Text = reader("S_SERVER_NAME2")
            End If

            If Not reader("S_SERVER_NAME3") Is DBNull.Value Then
                SecondServer3TextBox.Text = reader("S_SERVER_NAME3")
            End If

            If Not reader("S_SERVER_NAME4") Is DBNull.Value Then
                SecondServer4TextBox.Text = reader("S_SERVER_NAME4")
            End If

            If Not reader("S_SERVER_NAME") Is DBNull.Value Then
                SecondServer5TextBox.Text = reader("S_SERVER_NAME")
            End If

            If Not reader("S_SERVER_NAME6") Is DBNull.Value Then
                SecondServer6TextBox.Text = reader("S_SERVER_NAME6")
            End If

            If Not reader("S_SERVER_NAME7") Is DBNull.Value Then
                TextBox1.Text = reader("S_SERVER_NAME7")
            End If

            If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                TextBox2.Text = reader("S_SERVER_NAME8")
            End If

            If Not reader("S_SERVER_NAME9") Is DBNull.Value Then
                TextBox3.Text = reader("S_SERVER_NAME9")
            End If

            If Not reader("S_SERVER_NAME10") Is DBNull.Value Then
                TextBox4.Text = reader("S_SERVER_NAME10")
            End If


        End While
        reader.Close()
        conn15seldet.Close()
    End Sub
    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        LBL_STATUS.Text = lang.status
        reservedfuture.Text = lang.future
        reservedfuture.Font.Bold = True
        card1.Style.Add("font-weight", "bold")
        PrimaryNameServerLabel.Text = lang.Pname
        Second_name1Label.Text = lang.Sname + "5"
        Second_name2Label.Text = lang.Sname + "6"
        SecondServer3.Text = lang.Sname + "3"
        SecondServer4.Text = lang.Sname + "4"
        SecondServer5.Text = lang.Sname + "1"
        SecondServer6.Text = lang.Sname + "2"
        Label2.Text = lang.Sname + "7"
        Label4.Text = lang.Sname + "8"
        Label9.Text = lang.Sname + "9"
        Label12.Text = lang.Sname + "10"
        first.InnerText = lang.Servers2
        Second1.InnerText = lang.ContactData
        RegDateL.Text = lang.RegDate
        accordionExample.Style.Add("font-family", lang.fonta)
        accordionExample.Style.Add("Direction", lang.dir)
        first.Style.Add("font-family", lang.fonta)
        Second1.Style.Add("font-family", lang.fonta)
        accordionExample.Style.Add("font-weight", "bold")
        card1.Style.Add("Direction", lang.dir)
        OwnerDetailsLabel.Text = lang.ownerd
        TechDetailsLabel.Text = lang.Tech
        BillingDetails.Text = lang.bill
        AdminDetails.Text = lang.Admin
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
        OwnerNameRequiredFieldValidator.Text = lang.RequiredField2
        OwnerMobileValidator.Text = lang.RequiredField2
        TechEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        BillEmailExpressionValidator.Text = lang.InvalidEmail
        OwnerEmailExpressionValidator.Text = lang.InvalidEmail
        TechEmailExpressionValidator.Text = lang.InvalidEmail
        AdminEmailExpressionValidator.Text = lang.InvalidEmail
        BillEmailExpressionValidator.Text = lang.InvalidEmail
        OwnerEmailExpressionValidator.Text = lang.InvalidEmail
        SecondServer3FieldValidator.Text = lang.RequiredField2
        SecondServer4Validator.Text = lang.RequiredField2
        Second_name2Validator.Text = lang.RequiredField2
        Second_name1Validator.Text = lang.RequiredField2
        SecondServer6Validator.Text = lang.RequiredField2
        SecondServer5Validator.Text = lang.RequiredField2
        PrimaryNameServerValidator.Text = lang.RequiredField2
    End Sub
    Private Sub fill_db(ByVal Dom_id As Integer)
        Try


            Dim lang As New Languages(Session("lang"))
            Dim ocon2 As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
            Dim ocmd2 As New SqlClient.SqlCommand("dom_det", ocon2)
            Dim odr As SqlDataReader
            ocon2.Open()
            ocmd2.CommandType = CommandType.StoredProcedure
            ocmd2.Parameters.AddWithValue("domain_id", Dom_id)
            odr = ocmd2.ExecuteReader()
            While odr.Read
                If Not odr("tech_code_id") Is DBNull.Value Then
                    Session("TECH_CONTACT_par") = odr("tech_code_id")
                End If
                If Not odr("billing_code_id") Is DBNull.Value Then
                    Session("BILLING_CONTACT_par") = odr("billing_code_id")
                End If
                If Not odr("admin1") Is DBNull.Value Then
                    Session("Admin_ID_par") = odr("admin1")
                End If
                If Not odr("status") Is DBNull.Value Then
                    LBL_STATUS.Text += " : "
                    LBL_STATUS.Text += odr("STATUS")

                End If
                If Not odr("p_server_name") Is DBNull.Value Then
                    PrimaryNameServerTextBox.Text = odr("p_server_name")
                End If
                If Not odr("s_server_name") Is DBNull.Value Then
                    SecondServer5TextBox.Text = odr("S_SERVER_NAME")
                End If
                If Not odr("tech_email") Is DBNull.Value Then
                    TechEmailTextBox.Text = odr("tech_email")
                End If
                If Not odr("tech_contact") Is DBNull.Value Then
                    TechTextBox.Text = odr("tech_contact")
                End If
                If Not odr("tech_Mobile") Is DBNull.Value Then
                    TechMobileTextBox.Text = odr("tech_Mobile")
                End If
                If Not odr("billing_email") Is DBNull.Value Then
                    BillEmail.Text = odr("billing_email")
                End If
                If Not odr("billing_contact") Is DBNull.Value Then
                    BillTextBox.Text = odr("billing_contact")
                End If
                If Not odr("billing_Mobile") Is DBNull.Value Then
                    BillMobileText.Text = odr("billing_Mobile")
                End If
                If Not odr("reg_date") Is DBNull.Value Then
                    reg_date.Text = odr("reg_date")
                End If
                If Not odr("mobile_admin") Is DBNull.Value Then
                    AdminMobileTextBox.Text = odr("mobile_admin")
                End If
                If Not odr("admin_email") Is DBNull.Value Then
                    AdminEmailTextBox.Text = odr("admin_email")
                End If
                If Not odr("admin_contact") Is DBNull.Value Then
                    AdminTextBox.Text = odr("admin_contact")
                End If
                If Not odr("owner_name") Is DBNull.Value Then
                    OwnerNameTextBox.Text = odr("owner_name")
                End If
                If Not odr("mobile_domains") Is DBNull.Value Then
                    OwnerMobileTextBox.Text = odr("mobile_domains")
                End If
                If Not odr("org_email") Is DBNull.Value Then
                    OwnerEmailTextBox.Text = odr("org_email")
                End If

                If odr("name_server_id") = 0 Then
                    PrimaryNameServerTextBox.Text = lang.parked
                    SecondServer6TextBox.Text = lang.parked
                    LBL_STATUS.Text += "/" + lang.parked
                Else

                End If
            End While
            odr.Close()
            ocon2.Close()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "~/MasterPageAr.master"
        Else
            Me.MasterPageFile = "~/MasterPage_En.master"
        End If
    End Sub
End Class