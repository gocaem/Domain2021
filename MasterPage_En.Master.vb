Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Web.Helpers

Public Class MasterPage_En
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("lang") = "en"
        Try


            Dim reader As SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim conn15seldet As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd15seldet As New System.Data.SqlClient.SqlCommand("selectheaderfooter", conn15seldet)
            conn15seldet.Open()
            ocmd15seldet.CommandType = System.Data.CommandType.StoredProcedure
            reader = ocmd15seldet.ExecuteReader()
            While reader.Read

                If reader("Email") Is DBNull.Value = False Then
                    email.InnerText = reader("Email")
                End If
                If reader("Phone") Is DBNull.Value = False Then
                    phoneno.InnerText = reader("Phone")
                End If
                If reader("footerSupportphone") Is DBNull.Value = False Then
                    divphone.InnerText = reader("footerSupportphone")
                End If
                If reader("FooterAboutTitleEn") Is DBNull.Value = False Then
                    aboutus.InnerText = reader("FooterAboutTitleEn")
                End If
                If reader("FooterAboutDescEn") Is DBNull.Value = False Then
                    paragraphfooter.InnerText = reader("FooterAboutDescEn")
                End If
                If reader("footerSupportHeaderEn") Is DBNull.Value = False Then
                    support.InnerText = reader("footerSupportHeaderEn")
                End If

            End While
            reader.Close()
            conn15seldet.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\masterpage_en:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub MasterPage_En1_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Session("lang") = "en"
    End Sub
End Class