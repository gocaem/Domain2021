Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        Session("page") = "Profile"
        SetLanguage()

        fill_db(Session("User_ID"))
    End Sub
    Private Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        Label1.InnerText = lang.Admin
        Label4.InnerText = lang.Email
        Label2.InnerText = lang.Username.Replace(":", "")
        Label3.InnerText = lang.Admin
        Label5.InnerText = lang.Phone
        c.Style.Add("Direction", lang.dir)
        c.Style.Add("font-family", lang.fonta)
        c.Style.Add("font-weight", "bold")
    End Sub
    Private Sub fill_db(ByVal admin_id As Integer)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim ocon2 As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd2 As New SqlClient.SqlCommand("select_AdminData", ocon2)
            Dim odr As SqlDataReader
            ocon2.Open()
            ocmd2.CommandType = CommandType.StoredProcedure
            ocmd2.Parameters.AddWithValue("DomainId", admin_id)
            odr = ocmd2.ExecuteReader()
            While odr.Read
                If Not odr("EMAIL") Is DBNull.Value Then
                    EmailL.Text = odr("EMAIL")
                End If
                If Not odr("company_user_name") Is DBNull.Value Then
                    Uname.Text = odr("company_user_name")
                End If
                If Not odr("admin_contact") Is DBNull.Value Then
                    adminName.Text = odr("admin_contact")
                End If
                If Not odr("phone") Is DBNull.Value Then
                    Phone.Text = odr("phone")
                End If

            End While
            odr.Close()
            ocon2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\Profile:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
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
End Class