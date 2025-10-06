Imports System.Configuration
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports Microsoft.Security.Application
Imports System.Threading
Imports System.IO

Public Class FirstPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("page") = "first"
        Session("lang") = "ar"
        Try


            Dim reader As SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn15seldet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("selectheaderfooter", conn15seldet)
            conn15seldet.Open()
            ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
            reader = ocmd15seldet.ExecuteReader()
            While reader.Read
                If reader("HeaderBannerMainTextAR") Is DBNull.Value = False Then
                    h2.InnerText = reader("HeaderBannerMainTextAR")
                End If
                If reader("HeaderBannerSubTextAR") Is DBNull.Value = False Then
                    p2.InnerText = reader("HeaderBannerSubTextAR")
                End If
                If reader("Email") Is DBNull.Value = False Then
                    Email.InnerText = reader("Email")
                End If
                If reader("Phone") Is DBNull.Value = False Then
                    PhoneNo.InnerText = reader("Phone")
                End If
                If reader("FooterAboutTitleAr") Is DBNull.Value = False Then
                    aboutus.InnerText = reader("FooterAboutTitleAr")
                End If
                If reader("FooterAboutDescAr") Is DBNull.Value = False Then
                    paragraphfooter.InnerText = reader("FooterAboutDescAr")
                End If
                If reader("footerSupportHeaderAr") Is DBNull.Value = False Then
                    support.InnerText = reader("footerSupportHeaderAr")
                End If
                If reader("footerSupportphone") Is DBNull.Value = False Then
                    divphone.InnerText = reader("footerSupportphone")
                End If

            End While
            reader.Close()
            conn15seldet.Close()
            WhoIs.Columns(0).Visible = False

        Catch ex As Exception

        End Try


    End Sub
    Shared Function validate_experssion(ByVal value As String) As Boolean


        Return System.Text.RegularExpressions.Regex.IsMatch(value, "[\']|[\;]|[\/*|\|]|[\*/|=]|[\+]|(--)|(___)|(%)|(%%)")


    End Function
    Dim a() = {"$", "%", "@", "*", "&", "^", "#", "/", "\", "|", "?"}
    Protected Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dim ZipRegex As String
        Dim lang As New Languages("ar")
        If ddl.SelectedValue <> 12 Then
            ZipRegex = "^[A-Za-z0-9\-]{1,63}$"
        Else
            ZipRegex = "^[ء-ي0-9\-]{1,63}$"
        End If

        If Not ((Regex.IsMatch(Server.HtmlEncode(TextBox1.Text), ZipRegex))) Then
            Result.ForeColor = System.Drawing.Color.Red
            Result.Visible = True
            Result.Text = lang.validexp2
        Else
            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("selectheaderfooter", ocon)

            Dim ocmd As New SqlClient.SqlCommand("fill_whois", ocon)
            Dim odr As SqlClient.SqlDataReader
            Try

                ocon.Open()
                ocmd.CommandType = CommandType.StoredProcedure
                ocmd.Parameters.AddWithValue("DOMAIN", Server.HtmlEncode(TextBox1.Text))
                ocmd.Parameters.AddWithValue("SECOND", ddl.SelectedValue)
                odr = ocmd.ExecuteReader
                Session("lang") = "ar"
                If odr.HasRows Then
                    Result.Text = ""
                    WhoIs.Visible = True
                    WhoIs.DataSource = odr
                    WhoIs.DataBind()
                Else
                    Result.ForeColor = System.Drawing.Color.Green
                    WhoIs.Visible = False
                    Result.Text = "النطاق متوفر للتسجيل، سارع بتسجيله عبر تسجيل حساب خاص بك"
                End If

                odr.Close()
                ocon.Close()




            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\firstpage:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                ocon.Close()
            End Try

            ocon.Close()
        End If
    End Sub
    Function MyInStr(myString, myArray)
        Dim bFound As Boolean
        bFound = False

        For Each elem In myArray
            If InStr(myString, elem) > 0 Then
                bFound = True
                Exit For
            End If
        Next

        MyInStr = bFound
    End Function

    Private Sub FirstPage_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("lang") Is Nothing Then
            Session("lang") = "ar"
        End If
    End Sub

    Private Sub WhoIs_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles WhoIs.RowCommand
        If e.CommandName = "det" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim did As Integer = Convert.ToInt32(e.CommandArgument)
            Session("Domain_No") = did
            Session("lang") = "en"
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('WhoisDetails.aspx');", True)
        End If
    End Sub
End Class