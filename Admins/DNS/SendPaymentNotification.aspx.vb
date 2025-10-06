Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading
Imports Domain2021.Toastr
Public Class SendPaymentNotification
    Inherits System.Web.UI.Page

    Public dt As DataTable = Nothing
    Public Const SELECTED_DOMAINS_INDEX As String = "SelectedDomainsIndex"
    Protected Sub ck_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim row As GridViewRow
            Dim amount As Integer = 0
            For Each row In GridView2.Rows
                Dim YEAR As String = CType(row.Cells.Item(6).FindControl("years"), TextBox).Text
                If CType(row.Cells.Item(0).FindControl("ck"), CheckBox).Checked Then
                    'ADMINS2
                    Button1.Visible = True
                    Dim isExist As Boolean
                    Dim domainname As String = row.Cells.Item(5).Text

                    Session("did") = row.Cells.Item(3).Text
                    dt = CType(ViewState("Details"), DataTable)

                    isExist = isvalueExist(domainname)
                    GridView1.AllowCustomPaging = False

                    Dim connUpdateInvoice As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Dim ocmdUpdateInvoice As New System.Data.SqlClient.SqlCommand("calculate_total", connUpdateInvoice)
                    ocmdUpdateInvoice.Parameters.AddWithValue("domain_id", Session("did"))
                    ocmdUpdateInvoice.Parameters.AddWithValue("years", YEAR)
                    connUpdateInvoice.Open()
                    ocmdUpdateInvoice.CommandType = System.Data.CommandType.StoredProcedure
                    Dim amountP = ocmdUpdateInvoice.Parameters.Add("amount", SqlDbType.Int)
                    amountP.Direction = ParameterDirection.ReturnValue
                    totalvalue = ocmdUpdateInvoice.ExecuteScalar()
                    connUpdateInvoice.Close()
                    amount += amountP.Value
                    TextBox1.Text = amount
                    GridView1.AllowPaging = True
                    If isExist = True Then
                        Toastr.ShowToast(Me, ToastType.Warning, "ADDED", "NOTE", ToastPosition.TopCenter)
                    Else

                        dt.Rows.Add(domainname, YEAR)
                        GridView1.Visible = True
                        ViewState("Details") = dt
                        GridView1.DataSource = dt
                        GridView1.DataBind()


                    End If
                Else

                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    GridView1.AllowCustomPaging = False

                End If




            Next
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim red1 As Data.SqlClient.SqlDataReader
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "ADMINS2"
            comm.Parameters.AddWithValue("ADMIN_ID", txt_admin_id.Text)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            red1.Read()
            Session("email") = red1("Email")
            red1.Close()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SendPaymentNotification:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

        End Try
    End Sub
    Private Function isvalueExist(ByVal PassedValue As String) As Boolean
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.BindGrid()
        End If
        If ViewState("Details") Is Nothing Then
            Dim dataTable As DataTable = New DataTable()
            dataTable.Columns.Add("Domain Name")
            dataTable.Columns.Add("Years")
            ViewState("Details") = dataTable
        End If
    End Sub

    Private Sub BindGrid()
        GridView2.DataBind()
        RePopulateCheckBoxes()

    End Sub
    Private ReadOnly Property SelectedCustomersIndex As List(Of Int32)
        Get

            If ViewState(SELECTED_DOMAINS_INDEX) Is Nothing Then
                ViewState(SELECTED_DOMAINS_INDEX) = New List(Of Int32)()
            End If

            Return CType(ViewState(SELECTED_DOMAINS_INDEX), List(Of Int32))
        End Get
    End Property
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

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        For Each row As GridViewRow In GridView2.Rows
            Dim chkBox = TryCast(row.FindControl("ck"), CheckBox)
            Dim container As IDataItemContainer = CType(chkBox.NamingContainer, IDataItemContainer)

            If chkBox.Checked Then
                PersistRowIndex(container.DataItemIndex)
            Else
                RemoveRowIndex(container.DataItemIndex)
            End If
        Next
        GridView2.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
    Private ReadOnly Property SelectedDomainsIndex As List(Of Int32)
        Get

            If ViewState(SELECTED_DOMAINS_INDEX) Is Nothing Then
                ViewState(SELECTED_DOMAINS_INDEX) = New List(Of Int32)()
            End If

            Return CType(ViewState(SELECTED_DOMAINS_INDEX), List(Of Int32))
        End Get
    End Property
    Private Sub RemoveRowIndex(ByVal index As Integer)
        SelectedDomainsIndex.Remove(index)
    End Sub
    Private Sub PersistRowIndex(ByVal index As Integer)
        If Not SelectedDomainsIndex.Exists(Function(i) i = index) Then
            SelectedDomainsIndex.Add(index)
        End If
    End Sub
    Private Sub SaveCheckedValues()
        Dim domainchecked As ArrayList = New ArrayList()
        Dim index As Integer = -1

        For Each gvrow As GridViewRow In GridView2.Rows
            index = CInt(GridView2.DataKeys(gvrow.RowIndex).Value)
            Dim result As Boolean = (CType(gvrow.FindControl("ck"), CheckBox)).Checked
            If Session("CHECKED_ITEMS") IsNot Nothing Then domainchecked = CType(Session("CHECKED_ITEMS"), ArrayList)

            If result Then
                If Not domainchecked.Contains(index) Then domainchecked.Add(index)
            Else
                domainchecked.Remove(index)
            End If
        Next

        If domainchecked IsNot Nothing AndAlso domainchecked.Count > 0 Then Session("CHECKED_ITEMS") = domainchecked
    End Sub
    Private Sub PopulateCheckedValues()
        Dim domainchecked As ArrayList = CType(Session("CHECKED_ITEMS"), ArrayList)

        If domainchecked IsNot Nothing AndAlso domainchecked.Count > 0 Then

            For Each gvrow As GridViewRow In GridView2.Rows
                Dim index As Integer = CInt(GridView2.DataKeys(gvrow.RowIndex).Value)

                If domainchecked.Contains(index) Then
                    Dim myCheckBox As CheckBox = CType(gvrow.FindControl("ck"), CheckBox)
                    myCheckBox.Checked = True
                End If
            Next
        End If
    End Sub
    Private Sub RePopulateCheckBoxes()
        For Each row As GridViewRow In GridView2.Rows
            Dim chkBox = TryCast(row.FindControl("ck"), CheckBox)
            Dim container As IDataItemContainer = CType(chkBox.NamingContainer, IDataItemContainer)

            If SelectedDomainsIndex IsNot Nothing Then

                If SelectedDomainsIndex.Exists(Function(i) i = container.DataItemIndex) Then
                    chkBox.Checked = True
                End If
            End If
        Next
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        GridView2.DataBind()
        GridView2.Visible = True
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim Msg As String
        Msg = "<table align='center' id='tdd' runat='server' style='width: 100%; margin-left: 0px;'><tr>"
        Msg += "<td class='auto-style4'>Client NO: " & txt_admin_id.Text & "</td><td class='auto-style6'><img alt='' class='auto-style3'  height='150' width='170' src='https://www.dns.jo/logo.png'/><br /><br /><b>"
        Msg += "وزارة الاقتصاد الرقمي والريادة<br />"
        Msg += "Ministry of Digital Economy and Entrepreneurship"
        Msg += "</td>"
        Msg += "<td class=auto-style2>"
        Msg += "Date:" & Now().ToString("dd/MM/yyyy")
        Msg += "</td>"
        Msg += "</tr>"
        Msg += "<tr><td class='auto-style5'>&nbsp;</td><td class='auto-style7'>&nbsp;</td><td>&nbsp;</td></tr>"
        Msg += "<tr><td class='auto-style5' colspan='3'><br /><b>The following domains were renewed</td></tr>"
        Msg += "<br><br><tr style='border:thin solid #000000'><td style='border:thin solid #000000'>Domain Name</td><td style='border:thin solid #000000'>Years</td></tr>"
        For Each gvrow As GridViewRow In GridView1.Rows
            Msg += "<tr style='border:thin solid #000000'><td style='border:thin solid #000000'>" & gvrow.Cells.Item(1).Text & "</td><td style='border:thin solid #000000'> " & gvrow.Cells.Item(2).Text & "</td></tr>"
        Next
        Msg += "<tr colspan=2 style='color:red;border:thin solid #000000'><td style='border:thin solid #000000' colspan=2>Amount:" & TextBox1.Text & "JD" & "</td></tr>"
        ReusableCode.sndMail_Notification(Session("email").ToString(), "dns@modee.gov.jo", "New payment/eFAWATEERcom", Msg)
    End Sub


End Class