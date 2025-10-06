Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Web.Helpers

Public Class MasterPageAr
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Session("lang") = "ar"
            Dim reader As SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn15seldet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("selectheaderfooter", conn15seldet)
            conn15seldet.Open()
            ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
            reader = ocmd15seldet.ExecuteReader()
            While reader.Read

                If reader("Email") Is DBNull.Value = False Then
                    Email.InnerText = reader("Email")
                End If
                If reader("Phone") Is DBNull.Value = False Then
                    PhoneNo.InnerText = reader("Phone")
                End If
                If reader("footerSupportphone") Is DBNull.Value = False Then
                    divphone.InnerText = reader("footerSupportphone")
                End If
                If reader("FooterAboutTitleAr") Is DBNull.Value = False Then
                    AboutUs.InnerText = reader("FooterAboutTitleAr")
                End If
                If reader("FooterAboutDescAr") Is DBNull.Value = False Then
                    paragraphfooter.InnerText = reader("FooterAboutDescAr")
                End If
                If reader("footerSupportHeaderAr") Is DBNull.Value = False Then
                    support.InnerText = reader("footerSupportHeaderAr")
                End If


            End While
            reader.Close()
            conn15seldet.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\masterpagear:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub MasterPage_En1_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Session("lang") = "ar"
    End Sub
End Class