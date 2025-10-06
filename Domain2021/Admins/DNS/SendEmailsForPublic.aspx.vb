Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Threading
Imports AjaxControlToolkit.HtmlEditor

Public Class SendEmailsForPublic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Admin_User_ID") Is Nothing Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("entered") <> 1 Then
            Response.Redirect("../logout.aspx")
        ElseIf Session("User_Role") <> 3 Then
            Response.Redirect("../logout.aspx")
        End If
        If Page.IsPostBack = False Then
            Dim Msg As String
            Msg = "<table align='center' id='tdd' runat='server' style='width: 100%; margin-left: 0px;'><tr style='text-align:center'>"
            Msg += "<center><img alt='' class='auto-style3'  height='150' width='170' src='https://www.dns.jo/logo.png'/><br /><br /><b>"
            Msg += "وزارة الاقتصاد الرقمي والريادة<br />"
            Msg += "Ministry of Digital Economy and Entrepreneurship</center>"
            Msg += "</tr></b>"
            Msg += "<tr><td class='auto-style5'>&nbsp;</td><td class='auto-style7'>&nbsp;</td><td>&nbsp;</td></tr>"
            Msg += "<tr dir=rtl><td class='auto-style5' colspan='3' style='text-align:right;font-family:calibri'><br /><b>عميلنا العزيز، </b><br>يُرجى العلم بأننا سنقوم بعملية صيانة للموقع الحالي الخاص بتسجيل النطاقات ابتداءً من مساء يوم الخميس الموافق 10-8 ولغاية مساء يوم الجمعة الموافق 11-08 وقد يحدث نتيجة لذلك فصل مؤقت على خدمة تسجيل النطاقات" + "</td></tr><br>"
            Msg += "<tr dir=ltr><td class='auto-style5' colspan='3' style='text-align:left;font-family:calibri'><br /><b>Dear Esteemed Client,</b><br>"
            Msg += "We would like to point your attention that we will carry out a maintenance process for the current website for domain name registration, <br> "
            Msg += "starting from the evening of Thursday 10-8 till evening of Friday 11-08,and as a result there may be a temporary disconnection of the service" + "</td></tr>"
            Msg += "<tr><td style='font-family:calibri'><p  dir=rtl style=margin: 0in 0in 0pt; direction: rtl; line-height: 150%;         unicode-bidi: embed; text-align: justify><b><span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo> قسم النطاقات الوطنية</span><span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo>/Domain"
            Msg += "Name Division</span></b><br />"
            Msg += "<span dir=ltr style=font-size: 14pt; line-height: 150%>             .jo</span><span lang=AR-JO style=font-size: 14pt; line-height: 150%; ; mso-bidi-language: ar-jo> / .الاردن</span><span dir=ltr style=font-size: 14pt;                         line-height: 150%; ><o:p /></span></p>"
            Msg += "<p class=auto-style1 dir=rtl style=margin: 0in 0in 0pt; line-height: 150%;         unicode-bidi: embed; >"
            Msg += "<span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo>"
            Msg += "<span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo>"
            Msg += "962.6.5300263</span></span><span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo><span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo></span></span><span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo><span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo><span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo></span></span> </span><span dir=ltr style=font-size: 14pt;                 line-height: 150%; ><o:p /></span>"
            Msg += "<span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo> &nbsp;</span></p>"
            Msg += "<p  dir=rtl style=margin: 0in 0in 0pt; direction: rtl; line-height: 150%;         unicode-bidi: embed; text-align: justify>         <span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo> </span><span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo></span><span lang=AR-SA style=font-size: 14pt;                 line-height: 150%; ><a href=mailto:dns@modee.gov.jo><span dir=ltr lang=EN-US>dns@modee.gov.jo</span></a></span><span style=font-size: 14pt;                 line-height: 150%; > </span>"
            Msg += "<span style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo>"
            Msg += "<span style=font-size: 14pt;                 line-height: 150%; >"
            Msg += "</span><span lang=AR-JO style=font-size: 14pt; line-height: 150%;            mso-bidi-language: ar-jo><span lang=AR-SA style=font-size: 14pt;                 line-height: 150%; >"
            Msg += "</span></span><span lang=AR-SA style=font-size: 14pt;                 line-height: 150%; ></span> </span>         <span dir=ltr style=font-size: 14pt; line-height: 150%; >             <o:p>         </o:p></span>     </p>"
            Msg += "<p  dir=rtl style=margin: 0in 0in 0pt; direction: rtl; line-height: 150%;         unicode-bidi: embed; text-align: justify>         <span dir=ltr style=font-size: 9pt; line-height: 150%; font-family: arial>             <o:p>&nbsp;</o:p>             &nbsp; &nbsp;         </span>     </p></td></tr>    "
            Editor1.Content = Msg

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim connectionstr As DAL = New DAL()
        Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        Dim x As SqlDataReader
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SelectAdminEmails"
        x = cmd.ExecuteReader()



        While x.Read
            Try
                ReusableCode.sndMail("dns@modee.gov.jo", "dns@modee.gov.jo", TextBox1.Text, Editor1.Content)
                ShowToastr(Page, "Sent Successfully..", "Done", "success")

            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\SendEmailsForPublic:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If

            End Try
        End While

    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

End Class