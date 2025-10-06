Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Web.Services
Imports System.Configuration
Imports System.Drawing
Imports OfficeOpenXml
Imports System.Threading

Partial Class mydomains
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("logout.aspx")
        End If

        setLanguage()

        If Not Page.IsPostBack Then
            FILL_DATAGRED(Nothing)
            Me.SearchDomains()
            Dim i As Integer = 1
            For Each gridrow In dg.Rows
                CType(gridrow.Cells(0).FindControl("Seq"), Label).Text = i
                i = i + 1

            Next


        End If

    End Sub



    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        dg.Columns(0).HeaderText = "#"
        dg.Columns(1).HeaderText = lang.DomainName
        dg.Columns(2).HeaderText = lang.RegDate
        dg.Columns(3).HeaderText = lang.ExpDate
        dg.Columns(4).HeaderText = lang.details
        dg.Columns(6).HeaderText = lang.UploadFiles4
        dg.Columns(5).HeaderText = lang.details
        cardtext.InnerText = lang.excel
        cardtitle.InnerText = lang.Download
        cardtext.Style.Add("font-family", lang.fonta)
        cardtitle.Style.Add("font-family", lang.fonta)
        Label43.Text = lang.RefNOte & " " & ":" & " " & Session("User_ID")
        Label43.Font.Name = lang.fonta
        Label43.Font.Size = 12
        Label1.Text = lang.DomainName
        Label3.Text = lang.ExpDate + "  " + "(" + lang.fromDate + ")"
        Label4.Text = lang.ExpDate + "  " + "(" + lang.ToDate + ")"
        Label3.Style.Add("Font-family", lang.fonta)
        Label5.Text = lang.DomainName
        Label5.Style.Add("Font-family", lang.fonta)

        Label4.Style.Add("Font-family", lang.fonta)
        ttd.Style.Add("direction", lang.dir)
        Label13.Text = lang.DomainList
        Label13.Font.Name = lang.fonta
        Label13.Font.Size = 13
        dg.HeaderStyle.Font.Name = lang.fonta
        dg.Columns(0).HeaderText = "#"
        dg.Columns(1).HeaderText = lang.DomainName
        dg.Columns(2).HeaderText = lang.RegDate
        dg.Columns(3).HeaderText = lang.ExpDate
        dg.Columns(4).HeaderText = lang.status
        dg.Columns(7).HeaderText = lang.UploadFiles4
        dg.Columns(6).HeaderText = lang.HideInfo
        dg.Columns(5).HeaderText = lang.details
        dg.Columns(0).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(1).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(2).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(3).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(4).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(5).HeaderStyle.Font.Name = lang.fonta
        dg.Columns(0).ItemStyle.Font.Name = lang.fonta
        dg.Columns(1).ItemStyle.Font.Name = lang.fonta
        dg.Columns(2).ItemStyle.Font.Name = lang.fonta
        dg.Columns(3).ItemStyle.Font.Name = lang.fonta
        dg.Columns(4).ItemStyle.Font.Name = lang.fonta
        dg.Columns(5).ItemStyle.Font.Name = lang.fonta
        Label1.Text = lang.FilterDomain
        Label1.Style.Add("Font-family", lang.fonta)
        dg.Style.Add("Font-family", lang.fonta)
        dg.Font.Size = 10
        dg.Style.Add("direction", lang.dir)
        dg.HeaderStyle.Font.Name = lang.fonta
        hideall.Text = lang.HideInfoall
        hideall.Style.Add("Font-family", lang.fonta)
    End Sub
    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property
    Private Property SortExpression As String
        Get
            Return IIf(ViewState("SortExpression") IsNot Nothing, Convert.ToString(ViewState("SortExpression")), Nothing)
        End Get
        Set(value As String)
            ViewState("SortExpression") = value
        End Set
    End Property
    Protected Sub OnSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim lang As New Languages(Session("lang"))
        Session("Sortexpresssion") = e.SortExpression
        Me.FILL_DATAGRED(e.SortExpression)
        dg.HeaderStyle.CssClass = If(SortDirection = "", "headRowSortAsc", "headRowSortDesc")
        dg.HeaderStyle.CssClass = If(SortDirection = "ASC", "headRowSortAsc", "headRowSortDesc")
        dg.HeaderStyle.CssClass = If(SortDirection = "DESC", "headRowSortDesc", "headRowSortAsc")
        dg.Style.Add("font-family", lang.fonta)
        dg.HeaderStyle.Font.Name = lang.fonta
    End Sub
    Private Sub FILL_DATAGRED(Optional ByVal sortExpression As String = Nothing)

        Try
            Dim connectionstr As DAL = New DAL()
            Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim cmd As SqlCommand = New SqlCommand("FILL_USER")
            Dim sda As SqlDataAdapter = New SqlDataAdapter
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("ADMIN_ID", Session("User_ID"))
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
            If dt.Rows.Count >= 1 Then
                exportcard.Visible = True
            End If
            dg.DataBind()

            Dim lang As New Languages(Session("lang"))



            dg.Columns(0).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(1).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(2).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(3).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(4).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(6).HeaderStyle.Font.Name = lang.fonta

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\mydomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = lang.EError
        End Try
    End Sub






    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Session("page") = "mydomains"
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dt As DataTable, ByVal fileName As String)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Using pck As ExcelPackage = New ExcelPackage()
            Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.Add("Sheet1")
            ws.Cells("A1").LoadFromDataTable(dt, True)
            ws.Column(3).Style.Numberformat.Format = "yyyy-mm-dd"
            ws.Column(4).Style.Numberformat.Format = "yyyy-mm-dd"
            Using stream As MemoryStream = New MemoryStream()
                pck.SaveAs(stream)
                Dim content As Byte() = stream.ToArray()
                Response.Clear()
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", $"attachment; filename={fileName}")
                Response.BinaryWrite(content)
                Response.[End]()
            End Using
        End Using
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    Private Sub SearchDomains()
        Try

            Dim connectionstr As DAL = New DAL()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand()
                    Dim sql As String = "Search_Domain"
                    cmd.Parameters.AddWithValue("@admin_id", Session("User_ID"))
                    cmd.Parameters.AddWithValue("@domain_name", domainname.Text.Trim())
                    cmd.Parameters.AddWithValue("@end_date", enddate.Text)
                    cmd.Parameters.AddWithValue("@startdate", startdate.Text)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = sql
                    cmd.Connection = con
                    Using sda As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        dg.DataSource = dt
                        dg.DataBind()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\mydomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub



    Private Sub dg_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dg.RowDataBound
        Dim html As HtmlGenericControl = New HtmlGenericControl()
        html.InnerHtml = "<i class='fa fa-eye'></i>"
        Dim htmlclear As HtmlGenericControl = New HtmlGenericControl()
        htmlclear.InnerHtml = "<i class='fa fa-edit'></i>"
        Dim html2 As HtmlGenericControl = New HtmlGenericControl()
        html2.InnerHtml = "<i class='fa fa-upload blink'></i>"
        For Each gridrow In dg.Rows

            If gridrow.Cells(8).Text.Trim = "8" Then
                Dim linkBtn As LinkButton = CType(gridrow.Cells(5).FindControl("Lk"), LinkButton)
                linkBtn.CssClass = "fa fa-edit"
            Else
                Dim linkBtn As LinkButton = CType(gridrow.Cells(5).FindControl("Lk"), LinkButton)
                linkBtn.CssClass = "fa fa-info"

            End If
            If gridrow.Cells(8).Text.Trim = "1" Then
                Dim linkBtn2 As LinkButton = CType(gridrow.Cells(7).FindControl("Lk2"), LinkButton)
                linkBtn2.CssClass = "fa fa-upload blink"
            Else
                Dim linkBtn As LinkButton = CType(gridrow.Cells(7).FindControl("Lk2"), LinkButton)
                linkBtn.CssClass = ""
            End If
            If gridrow.Cells(9).Text.Trim = "True" Then
                Dim linkBtn2 As LinkButton = CType(gridrow.Cells(6).FindControl("Lk3"), LinkButton)
                linkBtn2.CssClass = "fa fa-eye-slash"
                linkBtn2.ForeColor = Drawing.Color.Red
            Else
                Dim linkBtn As LinkButton = CType(gridrow.Cells(6).FindControl("Lk3"), LinkButton)
                linkBtn.CssClass = "fa fa-eye"

            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Calculate the row number based on the page index and the page size
            Dim rowNumber As Integer = (dg.PageIndex * dg.PageSize) + e.Row.RowIndex + 1

            ' Find the Label control and set the value
            Dim lblRowNumber As Label = CType(e.Row.FindControl("Seq"), Label)
            If lblRowNumber IsNot Nothing Then
                lblRowNumber.Text = rowNumber.ToString()
            End If
        End If
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dg.PageIndexChanging
        dg.PageIndex = e.NewPageIndex
        FILL_DATAGRED(Session("Sortexpresssion"))

    End Sub
    Private Sub dg_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dg.RowCommand
        Try


            If e.CommandName = "det" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim did As Integer = Convert.ToInt32(e.CommandArgument)
                Session("DID") = did
                Session("domain") = row.Cells(1).Text
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('DomainDetails.aspx');", True)
            ElseIf e.CommandName = "Papers" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim did As Integer = Convert.ToInt32(e.CommandArgument)
                If row.Cells(8).Text = 1 Then
                    Session("DID") = did
                    Session("domain") = row.Cells(1).Text
                    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('UploadDoc.aspx');", True)
                End If
            ElseIf e.CommandName = "Hide" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim did As Integer = Convert.ToInt32(e.CommandArgument)
                Session("DID") = did
                Session("domain") = row.Cells(1).Text
                Dim linkBtn As LinkButton = CType(row.Cells(6).FindControl("Lk3"), LinkButton)
                linkBtn.CssClass = "fa fa-eye-slash"
                linkBtn.ForeColor = Drawing.Color.Red
                If row.Cells(9).Text = True Then
                    Session("hide") = False
                Else
                    Session("hide") = True
                End If
                Dim connectionstr As DAL = New DAL()
                Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                    Using cmd As New SqlCommand()
                        Dim sql As String = "Hide_info"
                        cmd.Parameters.AddWithValue("@did", Session("DID"))
                        cmd.Parameters.AddWithValue("@hide", Session("hide"))
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = sql
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()

                    End Using
                End Using
                FILL_DATAGRED(ViewState("SortExpression"))
            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\mydomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub



    Protected Sub Search(sender As Object, e As EventArgs)
        Me.SearchDomains()
    End Sub

    Protected Sub dg_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs)
        Session("Sortexpresssion") = ViewState("SortExpression")
        dg.PageIndex = e.NewSelectedIndex
        dg.DataBind()
        FILL_DATAGRED(Session("Sortexpresssion"))
    End Sub

    Protected Sub HideInfo_Click(sender As Object, e As EventArgs)
        Try


            Dim lang As New Languages(Session("lang"))
            'hideallinfo
            If Session("hideall") Is Nothing Or Session("hideall") = 0 Then
                Session("hideall") = 1
                HideInfo.Text = ""
                HideInfo.Text += "<i class='fa fa-eye-slash' style='color:red' ></i>"
                hideall.Text = lang.ShowInfo
            Else
                HideInfo.Text = ""
                HideInfo.Text += "<i class='fa fa-eye' style='color:darkblue'></i>"
                Session("hideall") = 0
                hideall.Text = lang.HideInfoall
            End If
            Dim connectionstr As DAL = New DAL()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand()
                    Dim sql As String = "hideallinfo"
                    cmd.Parameters.AddWithValue("@admin", Session("User_ID"))
                    cmd.Parameters.AddWithValue("@hide", Session("hideall"))
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = sql
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()

                End Using
            End Using
            FILL_DATAGRED(ViewState("SortExpression"))
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\mydomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)
        Dim dt As DataTable = New DataTable
        dt = GetDataFromGridView()
        ExportToExcel(dt, "DomainsList " + Now.ToString("dd-MM-yyyy") + ".xlsx")
    End Sub
    Private Function GetDataFromGridView() As DataTable
        Try

            Dim connectionstr As DAL = New DAL()
            Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim cmd As SqlCommand = New SqlCommand("exporttoexcel")
            Dim sda As SqlDataAdapter = New SqlDataAdapter
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("admin_id", Session("User_ID"))
            cmd.Parameters.AddWithValue("sess", Session("lang"))
            sda.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            sda.Fill(dt)
            Return dt
            con.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\mydomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function
End Class

