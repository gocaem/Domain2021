Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading

Public Class MasterPageEnn
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            Session("lang") = "en"
            Dim lang As New Languages(Session("lang"))
            welcome_fun()
            lusername.InnerText = Session("COMPANY_USER_NAME")
            Label1.InnerText = lang.RefNOte + " : " + Convert.ToString(Session("User_ID"))
        Catch ex As Exception

        End Try
    End Sub
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
                    Session("mob") = ODR("MOBILE")
                    Session("Email") = ODR("Email")
                    Session("ADMIN_CONTACT") = ODR("ADMIN_CONTACT")
                    Session("COMPANY_USER_NAME") = ODR("COMPANY_USER_NAME")
                End If
            End While
            ODR.Close()
            conn2.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\MasterPageEnn:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Private Sub MasterPage_En_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Session("lang") = "en"
    End Sub

    Private Sub MasterPageEnn_Init(sender As Object, e As EventArgs) Handles Me.Init
        Session("lang") = "en"
    End Sub
End Class