Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading

Public Class TestEmailSMS
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

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        Try


            ReusableCode.sndMail("dns@modee.gov.jo", "dns@modee.gov.jo", "This E-mail Sent to you to confirm that E-mail Service Works Successfully", "")
            ShowToastr(Page, "Email Sent Successfully..", "Done", "success")


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\TestEmailSMS:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "open port required", "Error Email!", "error")
        End Try

    End Sub

    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim lang As Languages = New Languages("en")
            Dim Url1 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & "يتم تجربة الرسائل القصيرة" & "&mobile_number=" & "962797493702" & "&from=" & "domain.jo" & "&tag=" & 1 & "&Charset=" & "UTF-8" & "&unicode=" & 1
            Dim Url2 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & "يتم تجربة الرسائل القصيرة" & "&mobile_number=" & "962776722795" & "&from=" & "domain.jo" & "&tag=" & 1 & "&Charset=" & "UTF-8" & "&unicode=" & 1
            Dim Url3 As String = "http://bulksms.arabiacell.net/vas/http/send_sms_http?login_name=" & lang.SMSlogname & "&login_password=" & lang.SMSuser & "&msg=" & "يتم تجربة الرسائل القصيرة" & "&mobile_number=" & "962797509963" & "&from=" & "domain.jo" & "&tag=" & 1 & "&Charset=" & "UTF-8" & "&unicode=" & 1

            ReusableCode.VisitURL(Url1)
            ReusableCode.VisitURL(Url2)
            ReusableCode.VisitURL(Url3)
            ShowToastr(Page, "SMS Sent Successfully..", "Done", "info")

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "DNS\TestEmailSMS:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If

            ShowToastr(Page, "Failed", "open port required!", "error")
        End Try

    End Sub
End Class