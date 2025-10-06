Imports System.Security.Cryptography
Imports System.Web.Configuration
Imports System.Web.SessionState
Imports System.Web.SessionState.SessionIDManager
Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        'Dim sessionState As SessionStateSection = CType(ConfigurationManager.GetSection("system.web/sessionState"), SessionStateSection)
        'Dim sidCookieName As String = sessionState.CookieName
        'If Request.IsSecureConnection Then
        '    Response.Cookies("ASP.NET_SessionId").Secure = True
        'End If
        'If Request.Cookies(sidCookieName) IsNot Nothing Then
        '    Dim sidCookie As HttpCookie = Response.Cookies(sidCookieName)
        '    sidCookie.Value = Session.SessionID
        '    sidCookie.HttpOnly = True
        '    sidCookie.Secure = True
        '    sidCookie.Path = "/"
        'End If
    End Sub

    Sub Application_PreSendRequestHeaders()
        'Response.Headers.Remove("Server")
        'Response.Headers.Remove("X-AspNet-Version")
        'Response.Headers.Remove("X-AspNetMvc-Version")
    End Sub
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub
    Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class