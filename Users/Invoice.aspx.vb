Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports Microsoft.Security.Application
Partial Class Invoice
    Inherits System.Web.UI.Page
    Dim amount As Integer = 0
    Dim totalvalue As Integer = 0
    Public Const SELECTED_CUSTOMERS_INDEX As String = "SelectedCustomersIndex"

    Private Sub GridView1_ItemCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try


            If e.CommandName = "del" Then
                Dim lang As New Languages(Session("lang"))
                Dim griditem As GridViewRow
                For Each griditem In GridView1.Rows
                    If e.CommandName = "del" Then

                        Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Session("DID") = Convert.ToInt32(e.CommandArgument)
                        Dim connectionstr As DAL = New DAL()
                        Dim connOpenInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim odr As SqlClient.SqlDataReader
                        Dim ocmdOpenInvoice As New Data.SqlClient.SqlCommand("selectSettings", connOpenInvoice)
                        ocmdOpenInvoice.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
                        connOpenInvoice.Open()
                        ocmdOpenInvoice.CommandType = Data.CommandType.StoredProcedure
                        odr = ocmdOpenInvoice.ExecuteReader
                        odr.Read()
                        If odr.HasRows Then
                            Session("invoicesetting_id") = odr("invoicesettings_ID")
                        End If
                        odr.Close()
                        connOpenInvoice.Close()
                        Session("years") = griditem.Cells(2).Text
                        Dim oconDelete As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmdDelete As New SqlClient.SqlCommand("delete_domainfromInvoice", oconDelete)
                        Dim deleted As Integer
                        oconDelete.Open()
                        ocmdDelete.CommandType = CommandType.StoredProcedure
                        ocmdDelete.Parameters.AddWithValue("domain_id", Session("DID"))
                        ocmdDelete.Parameters.AddWithValue("invoicesetting_id", Session("invoicesetting_id"))
                        deleted = ocmdDelete.ExecuteNonQuery()
                        Label3.Text = lang.Deleted
                        oconDelete.Close()

                    End If

                Next
                Fill_DG()
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Dim invoicesettings As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If

        Try
            If Not Page.IsPostBack Then
                welcome_fun()
                SetLanguage()
                row2.Visible = True
                Dim lang As New Languages(Session("lang"))
                Dim connectionstr As DAL = New DAL()
                Dim connSettings As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim odr As SqlClient.SqlDataReader
                Dim ocmdSettings As New Data.SqlClient.SqlCommand("selectSettings", connSettings)
                ocmdSettings.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
                connSettings.Open()
                ocmdSettings.CommandType = Data.CommandType.StoredProcedure
                odr = ocmdSettings.ExecuteReader
                If odr.HasRows Then
                    While odr.Read
                        Session("invoicesetting_id") = odr("invoicesettings_ID")
                        Fill_DG()
                    End While
                Else

                End If
                odr.Close()
                connSettings.Close()

                Dim i As Integer = 1
                dg.AllowCustomPaging = False
                SearchDomains()
                For Each gridrow In dg.Rows
                    CType(gridrow.Cells(0).FindControl("Label64"), Label).Text = i
                    i = i + 1

                Next
                dg.AllowPaging = True

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub calculateamount()
        Try


            Dim griditem As GridViewRow
            Dim lang As New Languages(Session("lang"))
            GridView1.AllowCustomPaging = False
            For Each griditem In invisiblegrid.Rows

                Dim connectionstr As DAL = New DAL()
                Dim connUpdateInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim ocmdUpdateInvoice As New System.Data.SqlClient.SqlCommand("calculate_totalFirst", connUpdateInvoice)
                ocmdUpdateInvoice.Parameters.AddWithValue("domain_id", griditem.Cells(3).Text)
                ocmdUpdateInvoice.Parameters.AddWithValue("years", griditem.Cells(2).Text)
                connUpdateInvoice.Open()
                ocmdUpdateInvoice.CommandType = System.Data.CommandType.StoredProcedure
                Dim amountP = ocmdUpdateInvoice.Parameters.Add("amount", SqlDbType.Int)
                amountP.Direction = ParameterDirection.ReturnValue
                totalvalue = ocmdUpdateInvoice.ExecuteScalar()
                connUpdateInvoice.Close()
                amount += amountP.Value

            Next
            Label8.Text = amount
            Label6.Text = ""
            Label6.Text = lang.Amount & Label8.Text & lang.JD
            GridView1.AllowPaging = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Fill_DG()
    End Sub
    Private Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        Label1.Style.Add("font-family", lang.fonta)
        Me.dg.Columns(1).HeaderText = lang.DomainName
        Me.dg.Columns(2).HeaderText = lang.ExpDate
        Me.dg.Columns(3).HeaderText = lang.status
        Me.dg.Columns(7).HeaderText = lang.Years1To20
        Me.dg.Columns(4).HeaderText = lang.selectone
        Me.dg.Columns(1).HeaderStyle.Font.Name = lang.fonta
        Me.dg.Columns(2).HeaderStyle.Font.Name = lang.fonta
        Me.dg.Columns(3).HeaderStyle.Font.Name = lang.fonta
        Me.dg.Columns(7).HeaderStyle.Font.Name = lang.fonta
        Me.dg.Columns(4).HeaderStyle.Font.Name = lang.fonta
        Me.GridView1.Columns(1).HeaderText = lang.DomainName
        Me.GridView1.Columns(2).HeaderText = lang.years
        Me.GridView1.Columns(4).HeaderText = lang.Delete
        Me.GridView1.Columns(1).HeaderStyle.Font.Name = lang.fonta
        Me.GridView1.Columns(2).HeaderStyle.Font.Name = lang.fonta
        Label1.InnerText = lang.FilterDomain
        Label1.Style.Add("font-size", "14px")
        Label1.Style.Add("font-weight", "bold")
        dg.Style.Add("font-family", lang.fonta)
        dg.Style.Add("direction", lang.dir)
        current.InnerText = lang.currentInvoice
        current.Style.Add("font-family", lang.fonta)
        post_job.Style.Add("direction", lang.dir)
        HLabel1.InnerText = lang.prepareinvoice
        HLabel1.Style.Add("font-family", lang.fonta)
        HLabel1.Style.Add("font-weight", "bold")
        HLabel1.Style.Add("font-size", "16px")
        lkb.Text = lang.addtocurrentinvoive
        lkb.Style.Add("font-family", lang.fonta)
        lkDel.Text = lang.deletecurrentopeninvoice
        lkDel.Style.Add("font-family", lang.fonta)
        dg.HeaderStyle.Font.Name = lang.fonta
    End Sub
    Protected Sub Search(sender As Object, e As EventArgs)
        Me.SearchDomains()
    End Sub
    Private Sub dg_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dg.PageIndexChanging
        dg.PageIndex = e.NewPageIndex

        For Each row As GridViewRow In dg.Rows
            Dim chkBox As CheckBox = CType(row.FindControl("ck"), CheckBox)

            Dim container As IDataItemContainer = CType(chkBox.NamingContainer, IDataItemContainer)

            If chkBox.Checked Then

                PersistRowIndex(container.DataItemIndex)

            Else

                RemoveRowIndex(container.DataItemIndex)
            End If
        Next

        SearchDomains()
    End Sub
    Private Sub RemoveRowIndex(ByVal index As Integer)
        SelectedCustomersIndex.Remove(index)
    End Sub
    Private ReadOnly Property SelectedCustomersIndex As List(Of Int32)
        Get

            If ViewState(SELECTED_CUSTOMERS_INDEX) Is Nothing Then
                ViewState(SELECTED_CUSTOMERS_INDEX) = New List(Of Int32)()
            End If

            Return CType(ViewState(SELECTED_CUSTOMERS_INDEX), List(Of Int32))
        End Get
    End Property
    Private Sub RePopulateCheckBoxes()
        For Each row As GridViewRow In dg.Rows
            Dim chkBox = TryCast(row.FindControl("ck"), CheckBox)
            Dim container As IDataItemContainer = CType(chkBox.NamingContainer, IDataItemContainer)

            If SelectedCustomersIndex IsNot Nothing Then

                If SelectedCustomersIndex.Exists(Function(i) i = container.DataItemIndex) Then
                    chkBox.Checked = True
                End If
            End If
        Next
    End Sub

    Private Sub PersistRowIndex(ByVal index As Integer)
        If Not SelectedCustomersIndex.Exists(Function(i) i = index) Then
            SelectedCustomersIndex.Add(index)
        End If
    End Sub
    Private Sub SearchDomains()
        Try

            Dim connectionstr As DAL = New DAL()

            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand()
                    Dim sql As String = "Search_domains_per_Admin2"
                    cmd.Parameters.AddWithValue("@admin_id", Session("User_ID"))
                    cmd.Parameters.AddWithValue("@domain_name", textID.Text.Trim())
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = sql
                    cmd.Connection = con
                    Using sda As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        dg.DataSource = dt
                        dg.DataBind()
                        Dim i As Integer = 1
                        For Each gridrow In dg.Rows
                            CType(gridrow.Cells(0).FindControl("Label64"), Label).Text = i
                            i = i + 1

                        Next
                    End Using
                End Using
            End Using
            RePopulateCheckBoxes()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub


    Private Sub Fill_DG()
        Try


            Dim lang As New Languages(Session("lang"))

            Dim connectionstr As DAL = New DAL()

            Dim connOpenInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim odr As SqlClient.SqlDataReader
            Dim ocmdOpenInvoice As New Data.SqlClient.SqlCommand("selectSettings", connOpenInvoice)
            ocmdOpenInvoice.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
            connOpenInvoice.Open()
            ocmdOpenInvoice.CommandType = Data.CommandType.StoredProcedure
            odr = ocmdOpenInvoice.ExecuteReader
            odr.Read()
            If odr.HasRows Then
                Session("invoicesetting_id") = odr("invoicesettings_ID")
            End If
            odr.Close()
            connOpenInvoice.Close()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand("selectSettingsdet", con)
                    Using sda As New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("setting_id", Session("invoicesetting_id"))
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        invisiblegrid.DataSource = dt
                        invisiblegrid.DataBind()
                        GridView1.DataBind()
                        If dt.DefaultView.Count > 0 Then
                            lkDel.Visible = True
                        End If
                    End Using
                End Using
                con.Close()
            End Using

            GridView1.Visible = True
            Me.GridView1.Columns(1).HeaderText = lang.DomainName
            Me.GridView1.Columns(2).HeaderText = lang.ExpDate
            Me.GridView1.Columns(3).HeaderText = lang.ExpDate
            Dim i As Integer = 1
            For Each gridrow In GridView1.Rows
                CType(gridrow.Cells(0).FindControl("Label68"), Label).Text = i
                i = i + 1

            Next
            GridView1.AllowPaging = False
            calculateamount()
            GridView1.AllowPaging = True

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub


    Dim i As Integer = 0
    Private Sub welcome_fun()
        Try

            Dim lang As New Languages(Session("lang"))
            Dim ODR As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm2 As New Data.SqlClient.SqlCommand("welcome", conn2)
            comm2.CommandType = CommandType.StoredProcedure
            comm2.Parameters.AddWithValue("user_id", Session("User_ID"))
            conn2.Open()
            ODR = comm2.ExecuteReader
            While ODR.Read
                If Not ODR("ADMIN_CONTACT") Is DBNull.Value Then
                    Session("ADMIN_CONTACT") = ODR("ADMIN_CONTACT")
                    Session("mob") = ODR("MOBILE")
                    Session("Email") = ODR("Email")
                End If
            End While
            ODR.Close()
            conn2.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub


    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub


    Protected Sub lkb_Click(sender As Object, e As EventArgs) Handles lkb.Click
        Try


            Dim maxid As Integer = 0
            Dim connectionstr As DAL = New DAL()
            Dim maxidconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim maxidcomm As New Data.SqlClient.SqlCommand("selectmaxsettingID", maxidconn)
            maxidcomm.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
            maxidconn.Open()
            maxidcomm.CommandType = Data.CommandType.StoredProcedure
            If Not maxidcomm.ExecuteScalar() Is DBNull.Value Then
                maxid = maxidcomm.ExecuteScalar()
            End If
            maxidconn.Close()


            For Each drow In dg.Rows
                If CType(drow.Cells(4).FindControl("ck"), CheckBox).Checked Then
                    If maxid <> 0 Then

                        Dim conndet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmddet As New Data.SqlClient.SqlCommand("savedefault_det", conndet)
                        ocmddet.Parameters.AddWithValue("domain_id", drow.Cells(8).Text)
                        ocmddet.Parameters.AddWithValue("years", CType(drow.Cells(7).FindControl("years"), DropDownList).SelectedValue)
                        ocmddet.Parameters.AddWithValue("invoicesetting_id", maxid)
                        conndet.Open()
                        ocmddet.CommandType = Data.CommandType.StoredProcedure
                        ocmddet.ExecuteNonQuery()
                        conndet.Close()
                        Session("invoicesetting_id") = maxid


                    Else
                        Dim conn2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim comm2 As New Data.SqlClient.SqlCommand("savesettings", conn2)
                        comm2.CommandType = CommandType.StoredProcedure
                        conn2.Open()
                        comm2.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
                        comm2.ExecuteNonQuery()
                        conn2.Close()
                        Dim maxid1 As Integer
                        Dim maxidconn1 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim maxidcomm1 As New Data.SqlClient.SqlCommand("selectmaxsettingID", maxidconn1)
                        maxidcomm1.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
                        maxidconn1.Open()
                        maxidcomm1.CommandType = Data.CommandType.StoredProcedure
                        maxid1 = maxidcomm1.ExecuteScalar()
                        maxidconn1.Close()
                        Dim conndet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                        Dim ocmddet As New Data.SqlClient.SqlCommand("savedefault_det", conndet)
                        ocmddet.Parameters.AddWithValue("domain_id", drow.Cells(8).Text)
                        ocmddet.Parameters.AddWithValue("years", CType(drow.Cells(7).FindControl("years"), DropDownList).SelectedValue)
                        ocmddet.Parameters.AddWithValue("invoicesetting_id", maxid1)
                        conndet.Open()
                        ocmddet.CommandType = Data.CommandType.StoredProcedure
                        ocmddet.ExecuteNonQuery()
                        conndet.Close()

                        Session("invoicesetting_id") = maxid1
                    End If
                End If
            Next
            Fill_DG()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Dim MyCheckList As List(Of Integer) = New List(Of Integer)()
    Protected Sub ck_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub dg_Sorting(sender As Object, e As GridViewSortEventArgs)
        Me.BindGrid(e.SortExpression)
    End Sub
    Private Sub BindGrid(Optional ByVal sortExpression As String = Nothing)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim sql As String = "Search_domains_per_Admin2"
            Dim cmd As SqlCommand = New SqlCommand(sql)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@admin_ID", Session("User_ID"))
            cmd.Parameters.AddWithValue("@domain_name", textID.Text.Trim())
            Dim sda As SqlDataAdapter = New SqlDataAdapter
            cmd.Connection = con
            sda.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            sda.Fill(dt)
            If (Not (sortExpression) Is Nothing) Then
                Dim dv As DataView = dt.AsDataView
                Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                dv.Sort = sortExpression & " " & Me.SortDirection
                dg.DataSource = dv
            Else
                dg.DataSource = dt
            End If

            dg.DataBind()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub lkDel_Click(sender As Object, e As EventArgs)
        Try

            Dim maxid As Integer = 0
            Dim connectionstr As DAL = New DAL()
            Dim maxidconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim maxidcomm As New Data.SqlClient.SqlCommand("selectmaxsettingID", maxidconn)
            maxidcomm.Parameters.AddWithValue("Admin_ID", Session("User_ID"))
            maxidconn.Open()
            maxidcomm.CommandType = Data.CommandType.StoredProcedure
            If Not maxidcomm.ExecuteScalar() Is DBNull.Value Then
                maxid = maxidcomm.ExecuteScalar()
            End If
            maxidconn.Close()

            Session("invoicesetting_id") = maxid


            Dim lang As New Languages(Session("lang"))
            Dim deleted As Integer = 0
            Dim connOpenInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmdOpenInvoice As New Data.SqlClient.SqlCommand("DeleteSettingDet", connOpenInvoice)
            ocmdOpenInvoice.Parameters.AddWithValue("id", Session("invoicesetting_id"))
            connOpenInvoice.Open()
            ocmdOpenInvoice.CommandType = Data.CommandType.StoredProcedure
            deleted = ocmdOpenInvoice.ExecuteNonQuery()
            connOpenInvoice.Close()
            Label3.Text = lang.Deleted
            Fill_DG()
            lkDel.Visible = False
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
End Class
