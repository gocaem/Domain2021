Public Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("Admin_User_ID")
        Session.Abandon()
        Session.Clear()
        Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddDays(-30)
        Response.Cookies("ASP.NET_SessionId").HttpOnly = True
        Response.Cookies("ASP.NET_SessionId").Secure = True
        Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", Nothing))
        Response.Cookies("ASP.NET_SessionId").HttpOnly = True
        Response.Cookies("ASP.NET_SessionId").Secure = True
        Response.Redirect("login.aspx")
    End Sub

End Class