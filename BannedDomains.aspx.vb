Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class BannedDomains
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("page") = "Banned"
        setLanguage()
        If Not Page.IsPostBack Then
            FILL_DATAGRED()
            Dim i As Integer = 1
            For Each gridrow In dg.Rows
                CType(gridrow.Cells(0).FindControl("Seq"), Label).Text = i
                i = i + 1

            Next


        End If

    End Sub
    Protected Sub dg_RowDataBound(sender As Object, e As GridViewRowEventArgs)
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
        dg.Columns(0).HeaderText = "#"
        dg.Columns(1).HeaderText = lang.DomainName
        dg.Style.Add("Font-family", lang.fonta)
        dg.Style.Add("text-align", "center")
        dg.Font.Size = 10
        dg.Style.Add("direction", lang.dir)
        dg.HeaderStyle.Font.Name = lang.fonta
        dg.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        If Session("lang") = "ar" Then
            headerLabel1.Visible = True
            headerLabel2.Visible = False
            headerLabel1.Text = lang.BannedDomains
            headerLabel1.Style.Add("Font-family", lang.fonta)
        Else
            headerLabel2.Visible = True
            headerLabel1.Visible = False
            headerLabel2.Text = lang.BannedDomains
            headerLabel2.Style.Add("Font-family", lang.fonta)
        End If


    End Sub

    Private Sub FILL_DATAGRED()

        Try
            Dim lang As New Languages(Session("lang"))


            Dim connectionstr As DAL = New DAL()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand("getallReserved", con)
                    Using sda As New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        dg.DataSource = dt
                        dg.DataBind()
                    End Using
                End Using
                con.Close()
            End Using


            dg.Columns(0).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(1).HeaderStyle.Font.Name = lang.fonta
            dg.Columns(0).HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            dg.Columns(1).HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            setLanguage()


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\banneddomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = lang.EError
        End Try
    End Sub
    Private Sub SearchDomains()
        Try
            Dim connectionstr As DAL = New DAL()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand()
                    Dim sql As String = "Search_Banned"
                    cmd.Parameters.AddWithValue("@domain_name", textID.Text.Trim())
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
            Dim i As Integer = 1
            For Each gridrow In dg.Rows
                CType(gridrow.Cells(0).FindControl("Seq"), Label).Text = i
                i = i + 1

            Next
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\banneddomains:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Search(sender As Object, e As EventArgs)
        Me.SearchDomains()
    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dg.PageIndexChanging
        dg.PageIndex = e.NewPageIndex
        FILL_DATAGRED()


    End Sub
End Class