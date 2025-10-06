Imports System.IO
Imports System.Threading

Public Class TLDReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub
    Function ROUNDROPEN() As String

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim tempNumber As Integer
        Dim tempRenewed As Integer

        With Response
            .Write("<TABLE id='Table5' cellSpacing='1' cellPadding='1' width='100%' border='1' class='aText'>")
            .Write("	<TR bgcolor='#012D48' class='aText'>")
            .Write("	    <TD  align='center' width='25%'><font color='white'>.jo TLD</font></TD>")
            .Write("	    <TD  align='center' width='25%'><font color='white'>TLD Count</font></TD>")
            .Write("	    <TD  align='center' width='25%'><font color='white'>Renewed Count</font></TD>")
            .Write("	    <TD  align='center' width='25%'><font color='white'>Renewed Percentage</font></TD>")
            .Write("	</TR>")
        End With


        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "second_domain_data"
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            tempNumber = 0
            tempRenewed = 0
            While red1.Read
                With Response
                    .Write("   <TR>")
                    .Write("<TD>" & red1.Item("SECOND_DOMAIN") & "</TD>")
                    .Write("<TD align='center'>" & get_number(red1.Item("SECOND_DOMAIN_ID")) & "</TD>")
                    tempNumber = tempNumber + CInt(get_number(red1.Item("SECOND_DOMAIN_ID")))
                    .Write("<TD align='center'>" & get_renewed(red1.Item("SECOND_DOMAIN_ID")) & "</TD>")
                    tempRenewed = tempRenewed + get_renewed(red1.Item("SECOND_DOMAIN_ID"))
                    If (get_number(red1.Item("SECOND_DOMAIN_ID")) <> "0") Then
                        .Write("<TD align='center'>" & FormatNumber(((CInt(get_renewed(red1.Item("SECOND_DOMAIN_ID"))) / CInt(get_number(red1.Item("SECOND_DOMAIN_ID")))) * 100), 2) & "%" & "</TD>")
                    Else
                        .Write("<TD align='center'>" & "0.00%" & "</TD>")

                    End If
                    .Write("</TR>")
                End With
            End While

            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\TLDReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try
        conn.Close()
        Response.Write("<TR bgcolor='#012D48' class='aText'><TD  align='center' width='25%'><font color='white'>Total</font></TD>")
        Response.Write("<TD  align='center'><font color='white'>" & tempNumber & "</font></TD>")
        Response.Write("<TD  align='center'><font color='white'>" & tempRenewed & "</font></TD>")
        Response.Write("<TD  align='center'><font color='white'>" & FormatNumber(((tempRenewed / tempNumber) * 100), 2) & "%" & "</font></TD>")
        Response.Write("</TR>")
        Response.Write("</TABLE>")
    End Function

    Private Function get_number(ByVal sd_id As Integer) As String

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "COUNT_DOMIAN_STATUS"
            comm.Parameters.AddWithValue("SEC", sd_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                get_number = CInt(red1.Item(0))
            End While
            red1.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\TLDReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try
        conn.Close()
    End Function

    Private Function get_renewed(ByVal s_d_id As Integer) As String

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "COUNT_RENEWED_DOMAINS"
            comm.Parameters.AddWithValue("SEC", s_d_id)
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                get_renewed = CInt(red1.Item(0))
            End While
            red1.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\TLDReport:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            conn.Close()
        End Try

        conn.Close()
    End Function

End Class