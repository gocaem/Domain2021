Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Partial Class statisticsV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 1 Then
            Response.Redirect("../logout.aspx")
        End If
        If Not Page.IsPostBack Then
            RadDatePicker1.Text = Now.Date
            RadDatePicker2.Text = Now.Date
        End If

    End Sub

    Private Function counter_status(ByVal start_date As String, ByVal end_date As String, ByVal status As Integer) As Integer

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader


        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "STATIS"
            comm.Parameters.AddWithValue("START", start_date)
            comm.Parameters.AddWithValue("END", end_date)
            comm.Parameters.AddWithValue("STATUS", status)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                counter_status = CInt(red1.Item(0))
            End While

            red1.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()

        End Try

        conn.Close()
    End Function
    Private Sub fill_new_reg(ByVal start_date As String, ByVal end_date As String)
        Try



            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 1)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_new_reg.DataSource = ds
            dg_new_reg.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_approved(ByVal start_date As String, ByVal end_date As String)
        Try



            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 2)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_approved.DataSource = ds
            dg_approved.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_online(ByVal start_date As String, ByVal end_date As String)
        Try



            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 8)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_online.DataSource = ds
            dg_online.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_ReNew(ByVal start_date As String, ByVal end_date As String)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 4)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_ReNew.DataSource = ds
            dg_ReNew.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_update(ByVal start_date As String, ByVal end_date As String)
        Try



            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 5)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_update.DataSource = ds
            dg_update.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_cancel(ByVal start_date As String, ByVal end_date As String)
        Try



            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 9)
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_Cancel.DataSource = ds
            dg_Cancel.DataBind()
            CONN.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub fill_Admin_Refuse(ByVal start_date As String, ByVal end_date As String)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim CONN As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim COMM As New Data.SqlClient.SqlCommand("STATIS_SQL1", CONN)
            COMM.CommandType = Data.CommandType.StoredProcedure
            CONN.Open()
            COMM.Parameters.AddWithValue("START", start_date)
            COMM.Parameters.AddWithValue("END", end_date)
            COMM.Parameters.AddWithValue("STATUS", 6)
            COMM.Connection = CONN
            Dim ds As DataSet = New DataSet
            Dim da As SqlDataAdapter = New SqlDataAdapter(COMM)
            da.Fill(ds)
            COMM.ExecuteNonQuery()
            dg_admin_refuse.DataSource = ds
            dg_admin_refuse.DataBind()
            CONN.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Private Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        LinkButton1.Visible = True
        LinkButton2.Visible = False
        dg_admin_refuse.Visible = False
        dg_approved.Visible = False
        dg_new_reg.Visible = False
        dg_online.Visible = False
        dg_update.Visible = False
        dg_ReNew.Visible = False
        dg_Cancel.Visible = False

    End Sub

    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        LinkButton1.Visible = False
        LinkButton2.Visible = True
        dg_admin_refuse.Visible = True
        dg_approved.Visible = True
        dg_new_reg.Visible = True
        dg_online.Visible = True
        dg_update.Visible = True
        dg_ReNew.Visible = True
        dg_Cancel.Visible = True
    End Sub

    Protected Sub hl_printer_Click(sender As Object, e As EventArgs)
        Session("StartDate") = RadDatePicker1.Text
        Session("EndDate") = RadDatePicker2.Text
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('statistics_pop.aspx');", True)

    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs)
        Try


            Dim start_date As String = RadDatePicker1.Text
            Dim end_date As String = RadDatePicker2.Text
            lbl_new_registration.Text = counter_status(start_date, end_date, 1)
            fill_new_reg(start_date, end_date)

            lbl_approved.Text = counter_status(start_date, end_date, 2)
            fill_approved(start_date, end_date)

            lbl_online1.Text = counter_status(start_date, end_date, 8)
            fill_online(start_date, end_date)
            '==========================================================
            lbl_ReNew.Text = counter_status(start_date, end_date, 4)
            fill_ReNew(start_date, end_date)

            lbl_update.Text = counter_status(start_date, end_date, 5)
            fill_update(start_date, end_date)

            lbl_Cancel.Text = counter_status(start_date, end_date, 9)
            fill_cancel(start_date, end_date)
            '==========================================================

            lbl_Admin_Refuse.Text = counter_status(start_date, end_date, 6)
            fill_Admin_Refuse(start_date, end_date)


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "viewonly\StatisticsV:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Private Sub dg_new_reg_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_new_reg.ItemCommand
        If e.CommandName = "view1" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub



    Private Sub dg_Cancel_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_Cancel.ItemCommand
        If e.CommandName = "view6" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub

    Private Sub dg_online_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_online.ItemCommand
        If e.CommandName = "view3" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub


    Private Sub dg_update_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_update.ItemCommand
        If e.CommandName = "view4" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub


    Private Sub dg_ReNew_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_ReNew.ItemCommand
        If e.CommandName = "view5" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub

    Private Sub dg_approved_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg_approved.ItemCommand
        If e.CommandName = "view2" Then
            Session(Session("dID")) = e.Item.Cells(7).Text
            Response.Redirect("Details.aspx")
        End If
    End Sub
    Private Sub dg_approved_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dg_approved.PageIndexChanged

    End Sub

    Protected Sub dg_new_reg_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_new_reg.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_new_reg(start_date, end_date)
    End Sub



    Protected Sub dg_online_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_online.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_online(start_date, end_date)
    End Sub

    Protected Sub dg_update_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_update.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_update(start_date, end_date)
    End Sub

    Protected Sub dg_ReNew_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_ReNew.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_ReNew(start_date, end_date)
    End Sub

    Protected Sub dg_Cancel_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_Cancel.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_cancel(start_date, end_date)
    End Sub



    Protected Sub dg_approved_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_approved.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_approved(start_date, end_date)
    End Sub

    Protected Sub dg_admin_refuse_PageIndexChanged1(source As Object, e As DataGridPageChangedEventArgs)
        dg_admin_refuse.CurrentPageIndex = e.NewPageIndex
        Dim start_date As String = RadDatePicker1.Text
        Dim end_date As String = RadDatePicker2.Text
        fill_Admin_Refuse(start_date, end_date)
    End Sub
End Class
