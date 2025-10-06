Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading
Imports Domain2021.Toastr

Public Class Objections
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("Admin_User_ID") Is Nothing Then
                Response.Redirect("../logout.aspx")
            ElseIf Session("entered") <> 1 Then
                Response.Redirect("../logout.aspx")
            ElseIf Session("User_Role") <> 3 Then
                Response.Redirect("../logout.aspx")
            End If
            fillDataGrid()
            dg.Columns(4).Visible = False
            dg.Columns(5).Visible = False
            dg.Columns(6).Visible = False
            dg.Columns(10).Visible = False
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Objection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            ShowToastr(Page, "Failed", "Error!", "error")
        End Try
    End Sub
    Sub fillDataGrid()
        Try
            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
            Dim odr As Data.SqlClient.SqlDataReader
            ocmd.CommandText = "selectpendingObjection"
            ocmd.CommandType = Data.CommandType.StoredProcedure
            ocmd.Connection = ocon
            ocon.Open()
            odr = ocmd.ExecuteReader
            Me.dg.DataSource = odr
            Me.dg.DataBind()
            ocon.Close()
            odr.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Objection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub
    Private Sub dg_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles dg.ItemCommand
        If e.CommandName = "view" Then
            Details.Visible = True
            docgrid.Visible = False
            Reasons.Visible = False
            Details.Text = e.Item.Cells(4).Text
            ar.Visible = False
            en.Visible = False
            headerlbl.Visible = False
        ElseIf e.CommandName = "paper" Then
            Session("id") = e.Item.Cells(5).Text
            docgrid.DataBind()
            docgrid.Visible = True
            Details.Visible = False
            Reasons.Visible = False
            ar.Visible = False
            en.Visible = False
            headerlbl.Visible = False
        ElseIf e.CommandName = "Approve" Then
            Session("id") = e.Item.Cells(5).Text
            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
            ocmd.CommandText = "approverejectObjections"
            ocmd.Parameters.AddWithValue("id", e.Item.Cells(5).Text)
            ocmd.Parameters.AddWithValue("status", 1)
            ocmd.CommandType = Data.CommandType.StoredProcedure
            ocmd.Connection = ocon
            ocon.Open()
            ocmd.ExecuteNonQuery()
            fillDataGrid()
            ocon.Close()
            docgrid.Visible = False
            Details.Visible = False
            Reasons.Visible = False
            ar.Visible = False
            en.Visible = False
            headerlbl.Visible = False
            ShowToastr(Page, "Approved", "Approved Sucessfully", "Approved")
            lbl_result.Text = "Objection Approved Sucessfully"
            add_domanes_Log(e.Item.Cells(10).Text, 25)
            ReusableCode.sndMail(Session("email"), "dns@modee.gov.jo", "تم قبول الإعتراض على/Your Objection Request Approved:" & Session("domain"), EmailapprovedText(Session("domain")))
            ReusableCode.sndMail(Session("email"), "dns@modee.gov.jo", "تم إلغاء تسجيلك للنطاق/Your registration for domain name have been cancelled" & Session("domain"), EmailapprovedTextForOwner(Session("domain")))
        ElseIf e.CommandName = "Reject" Then
            Session("id") = e.Item.Cells(5).Text
            Session("email") = e.Item.Cells(6).Text
            Session("domain") = e.Item.Cells(1).Text
            docgrid.Visible = False
            Details.Visible = False
            Reasons.Visible = True
            ar.Visible = True
            en.Visible = True
            headerlbl.Visible = True
            'Send Reject email
        End If
    End Sub
    Function Email_Rejected_ar(ByVal DomainName As String, ByVal Reasons As String) As String
        Dim msg As String = "<p style='text-align: center;'><img src='https://www.dns.jo/imags/logo2.png'/>
&nbsp;</p>
<p style='text-align: right;directio:rtl'>عمبلنا العزيز:</p>
<p style='text-align: right;directio:rtl'>نود اعلامك بأنه قد تمّ رفض طلبك المقدم الخاص باسم النطاق" & DomainName & "
وذلك للأسباب التالية:</p>
<p style='text-align: right;'>" & Reasons.Replace(vbLf, Environment.NewLine) & "</p>
<p class='auto-style3'>
<span style='font-size:11.0pt;
line-height:115%;font-family:&quot;sans-serif&quot;,serif'>فريق النطاقات الوطني</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
Tel</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>: 
962.6.5300222</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
E-Mail</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>:
</span><a href='mailto:dns@nitc.gov.jo'>
<span style='font-size:11.0pt;line-height:115%;
font-family:&quot;sans-serif&quot;,serif'>dns@modee.gov.jo</span></a><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:#C00000'>Register your Arabic Domain Name under </span>
<span dir='RTL' lang='AR-JO' style='font-size:
10.0pt;line-height:115%;font-family:&quot;Arial&quot;,sans-serif;mso-ascii-font-family:
Calibri;mso-ascii-theme-font:minor-latin;mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-bidi;color:#C00000;
mso-bidi-language:AR-JO'>.الاردن </span>
<span style='font-size:10.0pt;line-height:
115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-font-family:Arial;mso-bidi-theme-font:
minor-bidi;color:#C00000;mso-bidi-language:AR-JO'>(</span><span style='font-size:10.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:
minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'>.al-ordun). For more 
information, please visit our website </span><a href='http://www.idn.jo/'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>http://www.idn.jo/</span></a><span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'> 
or </span><a href='http://نطاقات-عربية.الاردن/'>
<span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin'>http://</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:
sans-serif;mso-hansi-font-family:sans-serif'>نطاقات</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>-</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;
line-height:115%;mso-ascii-font-family:sans-serif;mso-hansi-font-family:sans-serif'>عربية</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><span dir='RTL' lang='AR-SA'> </span>
<span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:sans-serif;
mso-hansi-font-family:sans-serif'>الاردن</span><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>/</span></a><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>Disclaimer</span></b><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>The message contained in this e-mail along with the 
attachments (if present) is meant for the use of the intended recipient only. If 
you are not the intended recipient, please notify the sender immediately. Any 
unauthorized disclosure, copying, distribution of or taking any action in 
reliance on the contents of the information contained herein is strictly 
prohibited.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-family:Webdings;mso-bidi-font-family:&quot;Times New Roman&quot;
color:green'>P</span><span style='font-size:9.0pt;font-family:&quot;Times New Roman&quot;,serif;
color:green'> </span>
<span style='font-size:8.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:green'>Please consider the environment - Do you really need to 
print this e-mail?</span><o:p></o:p></p>"
        Return msg
    End Function
    Function Email_Rejected_en(ByVal DomainName As String, ByVal Reasons As String) As String
        Dim msg As String = "<p class='auto-style1'>
<img alt='' height='101' src='https://dns.jo/imags/enlogo.png' width='255' /></p>
<p class='auto-style2'>Dear Valued Customer:</p>
<p class='auto-style2'>Your Objection Application to claim ownership of (" & DomainName & ") have 
been rejected due to these reasons:</p>
<p class='auto-style2'>- " + Reasons.Replace(vbLf, Environment.NewLine) + "</p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;
line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>National Domain 
Names Division</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>
Tel</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>: 
962.6.5300222</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>
E-Mail</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>:
</span><a href='mailto:dns@nitc.gov.jo'>
<span style='font-size:11.0pt;line-height:115%;
font-family:&quot;'sans-serif'&quot;,serif'>dns@modee.gov.jo</span></a><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:#C00000'>Register your Arabic Domain Name under </span>
<span dir='RTL' lang='AR-JO' style='font-size:
10.0pt;line-height:115%;font-family:&quot;Arial&quot;,sans-serif;mso-ascii-font-family:
Calibri;mso-ascii-theme-font:minor-latin;mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-bidi;color:#C00000;
mso-bidi-language:AR-JO'>.الاردن </span>
<span style='font-size:10.0pt;line-height:
115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-font-family:Arial;mso-bidi-theme-font:
minor-bidi;color:#C00000;mso-bidi-language:AR-JO'>(</span><span style='font-size:10.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:
minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'>.al-ordun). For more 
information, please visit our website </span><a href='http://www.idn.jo/'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>http://www.idn.jo/</span></a><span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'> 
or </span><a href='http://نطاقات-عربية.الاردن/'>
<span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin'>http://</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:
'sans-serif';mso-hansi-font-family:'sans-serif''>نطاقات</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>-</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;
line-height:115%;mso-ascii-font-family:'sans-serif';mso-hansi-font-family:'sans-serif''>عربية</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><span dir='RTL' lang='AR-SA'> </span>
<span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:'sans-serif';
mso-hansi-font-family:'sans-serif''>الاردن</span><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>/</span></a><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;'sans-serif'&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>Disclaimer</span></b><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>The message contained in this e-mail along with the 
attachments (if present) is meant for the use of the intended recipient only. If 
you are not the intended recipient, please notify the sender immediately. Any 
unauthorized disclosure, copying, distribution of or taking any action in 
reliance on the contents of the information contained herein is strictly 
prohibited.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-family:Webdings;mso-bidi-font-family:&quot;Times New Roman&quot;;
color:green'>P</span><span style='font-size:9.0pt;font-family:&quot;Times New Roman'&quot;,serif;
color:green'> </span>
<span style='font-size:8.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:green'>Please consider the environment - Do you really need to 
print this e-mail?</span><o:p></o:p></p>"
        Return msg
    End Function
    Protected Sub ar_Click(sender As Object, e As EventArgs)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
            ocmd.CommandText = "approverejectObjections"
        ocmd.Parameters.AddWithValue("id", Session("id"))
        ocmd.Parameters.AddWithValue("status", 2)
        ocmd.CommandType = Data.CommandType.StoredProcedure
        ocmd.Connection = ocon
        ocon.Open()
        ocmd.ExecuteNonQuery()
        fillDataGrid()
        ocon.Close()
        ReusableCode.sndMail(Session("email"), "dns@modee.gov.jo", "تم رفض الإعتراض على:" & Session("domain"), Email_Rejected_ar(Session("domain"), Reasons.Text))
        Reasons.Visible = False
        ShowToastr(Page, "Rejected", "Objection Rejected", "Rejected")
            lbl_result.Text = "Objection Rejected"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Objection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub en_Click(sender As Object, e As EventArgs)
        Try

            Dim connectionstr As DAL = New DAL()
            Dim ocon As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim ocmd As New Data.SqlClient.SqlCommand
        ocmd.CommandText = "approverejectObjections"
        ocmd.Parameters.AddWithValue("id", Session("id"))
        ocmd.Parameters.AddWithValue("status", 2)
        ocmd.CommandType = Data.CommandType.StoredProcedure
        ocmd.Connection = ocon
        ocon.Open()
        ocmd.ExecuteNonQuery()
        fillDataGrid()
        ocon.Close()
        ReusableCode.sndMail(Session("email"), "dns@modee.gov.jo", "تم رفض الإعتراض على:" & Session("domain"), Email_Rejected_en(Session("domain"), Reasons.Text))
        Reasons.Visible = False
        ShowToastr(Page, "Rejected", "Objection Rejected", "Rejected")
            lbl_result.Text = "Objection Rejected"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Objection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Function add_domanes_Log(ByVal Max_domanes As Integer, ByVal status_id As Integer) As Boolean
        Dim lang As New Languages(Session("lang"))
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "insert_log4"
            comm.Parameters.AddWithValue("domain_id", Max_domanes)
            comm.Parameters.AddWithValue("ip", ReusableCode.GetIPAddress)
            comm.Parameters.AddWithValue("status", status_id)
            comm.Parameters.AddWithValue("date", Now)
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
            add_domanes_Log = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\Objection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Toastr.ShowToast(Me, ToastType.Error, lang.ERRORLOG, lang.EError, ToastPosition.TopCenter)
            conn.Close()
            add_domanes_Log = False
        End Try

    End Function
    Function EmailapprovedText(ByVal domainname As String)
        Dim msg = "<p style='text-align: center;'><img src='https://www.dns.jo/imags/logo2.png'/>
&nbsp;</p>
<p style='text-align: right;direction:rtl'>عمبلنا العزيز:</p>
<p style='text-align: right;direction:rtl'>نود اعلامك بأنه قد تمّ قبول طلبك المقدم الخاص باسم النطاق " & domainname & " 
وأصبح الآن متاح للتسجيل.</p>
<p class='direction:ltr'>Dear Valued customer:</p>
<p class='direction:ltr'>This Email is to inform you that your request to claim 
the ownership of&nbsp;" & domainname & "domain name have been approvedو and the domain is 
available now for registration.</p>
<span style='font-size:11.0pt;
line-height:115%;font-family:&quot;sans-serif&quot;,serif'>فريق النطاقات الوطني</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
Tel</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>: 
962.6.5300222</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
E-Mail</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>:
</span><a href='mailto:dns@nitc.gov.jo'>
<span style='font-size:11.0pt;line-height:115%;
font-family:&quot;sans-serif&quot;,serif'>dns@modee.gov.jo</span></a><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:#C00000'>Register your Arabic Domain Name under </span>
<span dir='RTL' lang='AR-JO' style='font-size:
10.0pt;line-height:115%;font-family:&quot;Arial&quot;,sans-serif;mso-ascii-font-family:
Calibri;mso-ascii-theme-font:minor-latin;mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-bidi;color:#C00000;
mso-bidi-language:AR-JO'>.الاردن </span>
<span style='font-size:10.0pt;line-height:
115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-font-family:Arial;mso-bidi-theme-font:
minor-bidi;color:#C00000;mso-bidi-language:AR-JO'>(</span><span style='font-size:10.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:
minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'>.al-ordun). For more 
information, please visit our website </span><a href='http://www.idn.jo/'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>http://www.idn.jo/</span></a><span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'> 
or </span><a href='http://نطاقات-عربية.الاردن/'>
<span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin'>http://</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:
sans-serif;mso-hansi-font-family:sans-serif'>نطاقات</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>-</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;
line-height:115%;mso-ascii-font-family:sans-serif;mso-hansi-font-family:sans-serif'>عربية</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><span dir='RTL' lang='AR-SA'> </span>
<span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:sans-serif;
mso-hansi-font-family:sans-serif'>الاردن</span><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>/</span></a><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>Disclaimer</span></b><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>The message contained in this e-mail along with the 
attachments (if present) is meant for the use of the intended recipient only. If 
you are not the intended recipient, please notify the sender immediately. Any 
unauthorized disclosure, copying, distribution of or taking any action in 
reliance on the contents of the information contained herein is strictly 
prohibited.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-family:Webdings;mso-bidi-font-family:&quot;Times New Roman&quot;;
color:green'>P</span><span style='font-size:9.0pt;font-family:&quot;Times New Roman&quot;,serif;
color:green'> </span>
<span style='font-size:8.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:green'>Please consider the environment - Do you really need to 
print this e-mail?</span><o:p></o:p></p>
<p style='text-align: right;'>&nbsp;</p>
<p style='text-align: right;'>&nbsp;</p>"

        Return msg
    End Function
    Function EmailapprovedTextForOwner(ByVal domainname As String)
        Dim msg = "<p style='text-align: center;'><img src='https://www.dns.jo/imags/logo2.png'/>
&nbsp;</p>
<p style='text-align: right;direction:rtl'>عمبلنا العزيز:</p>
<p style='text-align: right;direction:rtl'>نود اعلامك بأنه قد تمّ إلغاء تسجيلك الخاص باسم النطاق " & domainname & " 
وأصبح الآن غير متاح في حسابك، يمكنك تسجيل نطاق بديلاً عنه.</p>
<p class='direction:ltr'>Dear Valued customer:</p>
<p class='direction:ltr'>This Email is to inform you that your registration for 
the  Domain name &nbsp;" & domainname & " have been Canceled and the domain is 
 now not available in your account, you register a domain instead of the cancelled domain.</p>
<span style='font-size:11.0pt;
line-height:115%;font-family:&quot;sans-serif&quot;,serif'>فريق النطاقات الوطني</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
Tel</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>: 
962.6.5300222</span><o:p></o:p></p>
<p class='auto-style3'><b>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
E-Mail</span></b><span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>:
</span><a href='mailto:dns@nitc.gov.jo'>
<span style='font-size:11.0pt;line-height:115%;
font-family:&quot;sans-serif&quot;,serif'>dns@modee.gov.jo</span></a><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:#C00000'>Register your Arabic Domain Name under </span>
<span dir='RTL' lang='AR-JO' style='font-size:
10.0pt;line-height:115%;font-family:&quot;Arial&quot;,sans-serif;mso-ascii-font-family:
Calibri;mso-ascii-theme-font:minor-latin;mso-hansi-font-family:Calibri;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-bidi;color:#C00000;
mso-bidi-language:AR-JO'>.الاردن </span>
<span style='font-size:10.0pt;line-height:
115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-font-family:Arial;mso-bidi-theme-font:
minor-bidi;color:#C00000;mso-bidi-language:AR-JO'>(</span><span style='font-size:10.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:
minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'>.al-ordun). For more 
information, please visit our website </span><a href='http://www.idn.jo/'>
<span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>http://www.idn.jo/</span></a><span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin;color:#C00000'> 
or </span><a href='http://نطاقات-عربية.الاردن/'>
<span style='font-size:10.0pt;
line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;
mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:minor-latin'>http://</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:
sans-serif;mso-hansi-font-family:sans-serif'>نطاقات</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>-</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;
line-height:115%;mso-ascii-font-family:sans-serif;mso-hansi-font-family:sans-serif'>عربية</span><span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><span dir='RTL' lang='AR-SA'> </span>
<span dir='RTL' lang='AR-SA' style='font-size:10.0pt;line-height:115%;mso-ascii-font-family:sans-serif;
mso-hansi-font-family:sans-serif'>الاردن</span><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>/</span></a><span style='font-size:10.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin'>.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:11.0pt;line-height:115%;font-family:&quot;sans-serif&quot;,serif'>
&nbsp;</span><o:p></o:p></p>
<p class='MsoNormal'><b>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>Disclaimer</span></b><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-size:8.0pt;line-height:115%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:black'>The message contained in this e-mail along with the 
attachments (if present) is meant for the use of the intended recipient only. If 
you are not the intended recipient, please notify the sender immediately. Any 
unauthorized disclosure, copying, distribution of or taking any action in 
reliance on the contents of the information contained herein is strictly 
prohibited.</span><o:p></o:p></p>
<p class='MsoNormal'>
<span style='font-family:Webdings;mso-bidi-font-family:&quot;Times New Roman&quot;;
color:green'>P</span><span style='font-size:9.0pt;font-family:&quot;Times New Roman&quot;,serif;
color:green'> </span>
<span style='font-size:8.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-theme-font:
minor-latin;color:green'>Please consider the environment - Do you really need to 
print this e-mail?</span><o:p></o:p></p>
<p style='text-align: right;'>&nbsp;</p>
<p style='text-align: right;'>&nbsp;</p>"

        Return msg
    End Function
End Class