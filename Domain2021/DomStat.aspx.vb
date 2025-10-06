Imports System
Imports System.Data
Imports System.IO
Imports System.Threading

Public Class DomStat
    Inherits System.Web.UI.Page
    Function ROUNDROPEN() As String
        Dim lang As New Languages(Session("lang"))

        Session("page") = "stat"
        lb.Text = lang.StatLabel

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader
        Dim Total As Integer


        With Response

            .Write("<br><br><br><br><br><br><center><TABLE id='' style='font-family:" & lang.fonta & "' class='table' cellSpacing='1' width=65% cellPadding='1' dir=" & lang.dir & " border='1' class='' align= center >")
            .Write("	<TR bgcolor='#012D48' >")
            .Write("	    <TD  align='center' ><font color='white'><B>" & lang.TLD & "</B></font></TD>")
            .Write("	    <TD  align='center'><font color='white'><b>" & lang.Number & "</B></font></TD>")
            .Write("	    <TD  align='center' ><font color='white'><b>" & lang.Percentage & "</B></font></TD>")
            .Write("	</TR>")
        End With


        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "second_domain_data"
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            Total = get_Total()

            While red1.Read
                With Response
                    .Write("   <TR  width='23%'>")
                    .Write("<TD style='background: #d9d9d9;' width='23%'><b>" & red1.Item("SECOND_DOMAIN") & "</b></TD>")
                    .Write("<TD align='center' width='23%'>" & get_number(red1.Item("SECOND_DOMAIN_ID")) & "</TD>")
                End With
                If (get_number(red1.Item("SECOND_DOMAIN_ID")) <> "0") Then
                    Response.Write("<TD align='center'>" & FormatNumber(((CInt(get_number(red1.Item("SECOND_DOMAIN_ID"))) / Total) * 100), 2) & "%" & "</TD>")
                Else
                    Response.Write("<TD align='center'>" & "0.00%" & "</TD>")

                End If
                Response.Write("</TR>")
            End While


            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Domstat:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
        conn.Close()
        Response.Write("<TR bgcolor='#012D48' ><TD  align='center' width='50%'><font color='white'><B>" & lang.Total & "</B></font></TD>")
        Response.Write("<TD  align='center'><font color='white'><B>" & Total & "</B></font></TD>")
        Response.Write("<TD  align='center'><font color='white'><B></B></font></TD>")
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
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Domstat:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
        Return get_number

    End Function

    Private Function get_Total() As Integer

        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim red1 As Data.SqlClient.SqlDataReader

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "TOTAL_ONLINE_DOMAIN_NAMES"
            comm.CommandType = Data.CommandType.StoredProcedure
            red1 = comm.ExecuteReader()
            While red1.Read
                get_Total = red1.Item("Total")
            End While
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "root\Domstat:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
        conn.Close()
        Return get_Total
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lang As New Languages(Session("lang"))
        lb.Text = lang.StatLabel
        lb.Font.Name = lang.fonta
        lb.Font.Size = 12
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
End Class