Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports Microsoft.Security.Application
Imports System.Threading
Imports System.IO

Public Class WhoIs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Session("page") = "WhoIS"
        WhoIs.Columns(0).Visible = False
        setLanguage()
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Session("page") = "WhoIS"
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub

    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        WhoIs.Columns(1).HeaderText = lang.DomainName
        WhoIs.Columns(2).HeaderText = lang.OrgName
        WhoIs.Style.Add("font-family", lang.fonta)
        Result.Style.Add("font-family", lang.fonta)
        DomainName.InnerText = lang.searchDomain
        RequiredFieldValidator1.ErrorMessage = lang.DomainNameFill
        DomainNameText.Attributes("placeholder") = lang.DomainName
        DomainNameText.Attributes.Add("font-family", lang.fonta)
        tabel1.Style.Add("font-family", lang.fonta)
    End Sub
    Protected Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dim ZipRegex As String
        Dim lang As New Languages(Session("lang"))
        If ddl.SelectedValue <> 12 Then
            ZipRegex = "^[A-Za-z0-9\-]{1,63}$"
        Else
            ZipRegex = "^[ء-ي0-9\-]{1,63}$"
        End If

        If Not ((Regex.IsMatch(Server.HtmlEncode(DomainNameText.Text), ZipRegex))) Then
            Result.ForeColor = System.Drawing.Color.Red
            Result.Visible = True
            Result.Text = lang.validexp2
        Else
            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New SqlClient.SqlCommand("fill_whois", ocon)
            Dim odr As SqlClient.SqlDataReader
            Try

                ocon.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("DOMAIN", Server.HtmlEncode(DomainNameText.Text))
                ocmd.Parameters.AddWithValue("SECOND", ddl.SelectedValue)
                odr = ocmd.ExecuteReader
                If odr.HasRows Then
                    Result.Text = ""
                    WhoIs.Visible = True
                    WhoIs.DataSource = odr
                    WhoIs.DataBind()
                Else
                    WhoIs.Visible = False
                    Result.ForeColor = System.Drawing.Color.Green
                    Result.Text = lang.Whoisresult
                End If

                odr.Close()
                ocon.Close()




            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\WhoIs:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                ocon.Close()
            End Try

            ocon.Close()
        End If
    End Sub
    Private Sub WhoIs_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles WhoIs.RowCommand
        If e.CommandName = "det" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim did As Integer = Convert.ToInt32(e.CommandArgument)
            Session("Domain_No") = did
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('../WhoisDetails.aspx');", True)
        End If
    End Sub
End Class