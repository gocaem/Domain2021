Imports System.IO
Imports System.Threading

Public Class Email
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        send_regester_EMail(85108)
    End Sub
    Private Function send_regester_EMail(ByVal domanes_id As Integer) As Boolean
        Dim conn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim conn2 As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
        Dim comm2 As New Data.SqlClient.SqlCommand
        Dim dd As DateTime = Now
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

        Dim recipant_email, recipant_name, nitc_m, Subject, DOMAIN_NAME, SECOND_DOMAINN, OWNER_NAME, USER_PASSWORD, message_body, message_body1, message_body_4NITC As String
        recipant_email = ""
        recipant_name = ""
        nitc_m = ""
        Subject = ""
        DOMAIN_NAME = ""
        SECOND_DOMAINN = ""
        OWNER_NAME = ""
        USER_PASSWORD = ""
        message_body = ""
        message_body1 = ""
        message_body_4NITC = ""
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "domain_admin"
            comm.Parameters.AddWithValue("domain_id", domanes_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                If Not red1.Item("EMAIL") Is DBNull.Value Then
                    recipant_email = red1.Item("EMAIL")
                End If
                If Not red1.Item("COMPANY_USER_NAME") Is DBNull.Value Then
                    recipant_name = red1.Item("COMPANY_USER_NAME")
                End If
                If Not red1.Item("USER_PASSWORD") Is DBNull.Value Then
                    USER_PASSWORD = ReusableCode.Decrypt(red1.Item("USER_PASSWORD"))
                End If
                If Not red1.Item("OWNER_NAME") Is DBNull.Value Then
                    OWNER_NAME = red1.Item("OWNER_NAME")
                End If
                If Not red1.Item("DOMAIN_NAME") Is DBNull.Value Then
                    DOMAIN_NAME = red1.Item("DOMAIN_NAME").ToLower
                End If
                If Not red1.Item("SECOND_DOMAIN") Is DBNull.Value Then
                    SECOND_DOMAINN = red1.Item("SECOND_DOMAIN").ToLower
                End If

            End While
            red1.Close()
            conn.Close()

            conn2.Open()
            comm2.Connection = conn2
            comm2.CommandText = "em_t"
            comm2.CommandType = Data.CommandType.StoredProcedure
            red1 = comm2.ExecuteReader()
            While red1.Read
                If Session("lang") = "en" Then
                    If red1("id") = 1 Then
                        Subject = red1.Item("title")
                        Subject &= "(" & DOMAIN_NAME & SECOND_DOMAINN & ")"
                        message_body1 = red1.Item("body_h") & red1.Item("body_h1") & red1.Item("body_h2") & red1.Item("body_h3")
                    End If
                Else
                    If red1("id") = 61 Then
                        Subject = red1.Item("title")
                        Subject &= "(" & DOMAIN_NAME & SECOND_DOMAINN & ")"
                        message_body1 = red1.Item("body_h") & red1.Item("body_t") & red1.Item("body_h1") & red1.Item("body_h2") & red1.Item("body_h3")

                    End If
                End If

            End While
            red1.Close()
            conn2.Close()



            message_body = message_body1
            message_body_4NITC = message_body1

            nitc_m = "dns@modee.gov.jo"
            ReusableCode.sndMail(recipant_email, "dns@modee.gov.jo", Subject, message_body)
            ReusableCode.sndMail("reef.amarin@modee.gov.jo", "dns@modee.gov.jo", Subject, message_body)
            send_regester_EMail = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Email:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
        conn.Close()
        Return send_regester_EMail
    End Function
End Class