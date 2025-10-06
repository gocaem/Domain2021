Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class WhoisDetails
    Inherits System.Web.UI.Page
    Dim connstr As DAL = New DAL()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("page") = "DomDet"
        If Session("Domain_No") Is Nothing Then
            Response.Redirect("FirstPage.aspx")
        End If

        setLanguage()
        Try
            Dim conn15seldet As New SqlConnection(ReusableCode.Decrypt(connstr.Connection))
            Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("server_data_domain", conn15seldet)
            Dim reader As SqlClient.SqlDataReader
            ocmd15seldet.Parameters.AddWithValue("did", Session("Domain_No"))
            conn15seldet.Open()
            ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
            reader = ocmd15seldet.ExecuteReader()
            While reader.Read
                If Not reader("P_SERVER_NAME") Is DBNull.Value Then
                    Server1V.Text = reader("P_SERVER_NAME")
                End If
                If Not reader("S_SERVER_NAME5") Is DBNull.Value Then
                    Server6V.Text = reader("S_SERVER_NAME5")
                End If
                If Not reader("S_SERVER_NAME2") Is DBNull.Value Then
                    Server3V.Text = reader("S_SERVER_NAME2")
                End If

                If Not reader("S_SERVER_NAME3") Is DBNull.Value Then
                    Server4V.Text = reader("S_SERVER_NAME3")
                End If

                If Not reader("S_SERVER_NAME4") Is DBNull.Value Then
                    Server5V.Text = reader("S_SERVER_NAME4")
                End If

                If Not reader("S_SERVER_NAME") Is DBNull.Value Then
                    Server2V.Text = reader("S_SERVER_NAME")
                End If

                If Not reader("S_SERVER_NAME6") Is DBNull.Value Then
                    Server7V.Text = reader("S_SERVER_NAME6")
                End If

                If Not reader("S_SERVER_NAME7") Is DBNull.Value Then
                    Server8V.Text = reader("S_SERVER_NAME7")
                End If

                If Not reader("S_SERVER_NAME8") Is DBNull.Value Then
                    Server9V.Text = reader("S_SERVER_NAME8")
                End If

                If Not reader("S_SERVER_NAME9") Is DBNull.Value Then
                    Server10V.Text = reader("S_SERVER_NAME9")
                End If

                If Not reader("S_SERVER_NAME10") Is DBNull.Value Then
                    Server11V.Text = reader("S_SERVER_NAME10")
                End If


            End While
            fill_db(Session("DID"))
            reader.Close()
            conn15seldet.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Whoisdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_db(ByVal Dom_id As Integer)
        Try


            Dim lang As New Languages(Session("lang"))
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connstr.Connection))
            Dim ocmd2 As New SqlClient.SqlCommand("dom_det", ocon2)
            Dim odr As SqlDataReader
            ocon2.Open()
            ocmd2.CommandType = CommandType.StoredProcedure
            ocmd2.Parameters.AddWithValue("domain_id", Session("Domain_No"))
            odr = ocmd2.ExecuteReader()
            While odr.Read
                If Not odr("tech_code_id") Is DBNull.Value Then
                    Session("TECH_CONTACT_par") = " " & odr("tech_code_id")
                End If
                If Not odr("billing_code_id") Is DBNull.Value Then
                    Session("BILLING_CONTACT_par") = " " & odr("billing_code_id")
                End If
                If Not odr("admin1") Is DBNull.Value Then
                    Session("Admin_ID_par") = odr("admin1")
                End If
                If Not odr("DomainName") Is DBNull.Value Then
                    Domain_lbl.Text = " " & odr("DomainName")
                End If
                If Not odr("HideInfo") Is DBNull.Value Then
                    If odr("HideInfo") = True Then
                        If Not odr("tech_email") Is DBNull.Value Then
                            TechEmailV.Text = " " + lang.Hidden
                        End If
                        If Not odr("billing_email") Is DBNull.Value Then
                            BillEmailV.Text = " " + lang.Hidden
                        End If
                        If Not odr("tech_Mobile") Is DBNull.Value Then
                            TechMobileV.Text = " " + lang.Hidden
                        End If
                        If Not odr("billing_Mobile") Is DBNull.Value Then
                            BillMobileV.Text = " " + lang.Hidden
                        End If
                        If Not odr("mobile_admin") Is DBNull.Value Then
                            AdminMobileV.Text = " " + lang.Hidden
                        End If
                        If Not odr("admin_email") Is DBNull.Value Then
                            AdminEmailV.Text = " " + lang.Hidden
                        End If
                        If Not odr("org_phone") Is DBNull.Value Then
                            OwnerMobileV.Text = " " + lang.Hidden
                        End If
                        If Not odr("mobile_domains") Is DBNull.Value Then
                            OwnerMobileV.Text = " " + lang.Hidden
                        End If
                        If Not odr("org_email") Is DBNull.Value Then
                            OwnerEmailV.Text = " " + lang.Hidden
                        End If
                    Else
                        If Not odr("tech_email") Is DBNull.Value Then
                            TechEmailV.Text = " " + odr("tech_email")
                        End If
                        If Not odr("tech_Mobile") Is DBNull.Value Then
                            TechMobileV.Text = " " + odr("tech_Mobile")
                        End If
                        If Not odr("billing_Mobile") Is DBNull.Value Then
                            BillMobileV.Text = " " + odr("billing_Mobile")
                        End If
                        If Not odr("mobile_admin") Is DBNull.Value Then
                            AdminMobileV.Text = " " + odr("mobile_admin")
                        End If
                        If Not odr("admin_email") Is DBNull.Value Then
                            AdminEmailV.Text = " " + odr("mobile_admin")
                        End If
                        If Not odr("org_phone") Is DBNull.Value Then
                            OwnerMobileV.Text = " " + odr("org_phone")
                        End If
                        If Not odr("mobile_domains") Is DBNull.Value Then
                            OwnerMobileV.Text = " " + odr("mobile_domains")
                        End If
                        If Not odr("org_email") Is DBNull.Value Then
                            OwnerEmailV.Text = " " + odr("org_email")
                        End If
                    End If
                Else

                    If Not odr("tech_email") Is DBNull.Value Then
                        TechEmailV.Text = " " + odr("tech_email")
                    End If
                    If Not odr("billing_email") Is DBNull.Value Then
                        BillEmailV.Text = " " + odr("billing_email")
                    End If

                    If Not odr("tech_Mobile") Is DBNull.Value Then
                        TechMobileV.Text = " " + odr("tech_Mobile")
                    End If
                    If Not odr("billing_Mobile") Is DBNull.Value Then
                        BillMobileV.Text = " " + odr("billing_Mobile")
                    End If
                    If Not odr("mobile_admin") Is DBNull.Value Then
                        AdminMobileV.Text = " " + odr("mobile_admin")
                    End If
                    If Not odr("admin_email") Is DBNull.Value Then
                        AdminEmailV.Text = " " + odr("admin_email")
                    End If
                    If Not odr("org_phone") Is DBNull.Value Then
                        OwnerMobileV.Text = " " + odr("org_phone")
                    End If
                    If Not odr("mobile_domains") Is DBNull.Value Then
                        OwnerMobileV.Text = " " + odr("mobile_domains")
                    End If
                    If Not odr("org_email") Is DBNull.Value Then
                        OwnerEmailV.Text = " " + odr("org_email")
                    End If

                End If
                If Not odr("billing_contact") Is DBNull.Value Then
                    BillingDetailsV.Text = " " & odr("billing_contact")
                End If
                If Not odr("tech_contact") Is DBNull.Value Then
                    TechLabelV.Text = " " & odr("tech_contact")
                End If

                If Not odr("reg_date") Is DBNull.Value Then
                    Regdatev.Text = odr("reg_date")
                End If

                If Not odr("admin_contact") Is DBNull.Value Then
                    AdminDetailsV.Text = " " & odr("admin_contact")
                End If
                If Not odr("owner_name") Is DBNull.Value Then
                    OwnerNameV.Text = " " & odr("owner_name")
                End If

                If Not odr("org_name") Is DBNull.Value Then
                    eName.Text = " " & odr("org_name")
                End If

                If odr("name_server_id") = 0 Then
                    Server1V.Text = lang.parked
                    Server2V.Text = lang.parked
                Else

                End If
            End While
            odr.Close()
            ocon2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Whoisdetails:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") Is Nothing Then
            Session("lang") = "ar"
        End If
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "~/MasterPageAr.master"
        Else
            Me.MasterPageFile = "~/MasterPage_En.master"
        End If
    End Sub
    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        Server5L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "5" + " "
        Server6L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "6" + " "
        Server3L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "3" + " "
        Server4L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "4" + " "
        Server1L.Text = lang.Pname.Replace("اسم", "").Replace("name", "") + " "
        Server2L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + " "
        Server7L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "7" + " "
        Server8L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "8" + " "
        Server9L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "9" + " "
        Server10L.Text = lang.Sname.Replace("اسم", "").Replace("name", "") + "10" + " "
        Reg_dateL.Text = lang.RegDate
        card2.Style.Add("text-align", lang.right)
        card2.Style.Add("direction", lang.dir)
        BillingDetails.Text = lang.bill
        OwnerEmailL.Text = lang.Email
        OwnerMobileL.Text = lang.Mobile
        OwnerNameL.Text = lang.Oname
        entityname.Text = lang.OrgName
        TechLabel.Text = lang.Tech
        TechMobileLabel.Text = lang.Mobile
        TechEmailLabel.Text = lang.Email
        AdminDetailsLabel.Text = lang.Admin
        AdminMobileLabel.Text = lang.Mobile
        AdminEmailLabel.Text = lang.Email
        Domainname.Text = lang.DomainName
        BillMobileLabel.Text = lang.Mobile
        BillEmailLabel.Text = lang.Email
        sec.Style.Add("font-family", lang.fonta)
        sec.Style.Add("text-align", lang.right)
        card.Style.Add("text-align", lang.right)
        card.Style.Add("direction", lang.dir)
        general.InnerText = lang.domaininfo
        general.Style.Add("font-family", lang.fonta)
        serverdet.InnerText = lang.ServerDetails
        serverdet.Style.Add("font-family", lang.fonta)
    End Sub
End Class