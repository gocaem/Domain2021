Public Class Logout1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("User_ID")
        Session.Abandon()
        Session.Clear()
        Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddDays(-30)
        Response.Cookies("ASP.NET_SessionId").HttpOnly = True
        Response.Cookies("ASP.NET_SessionId").Secure = True
        Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", Nothing))
        Response.Cookies("ASP.NET_SessionId").HttpOnly = True
        Response.Cookies("ASP.NET_SessionId").Secure = True
        Response.Cookies("ASP.NET_SessionId").Path = "/"
        Response.Redirect("../FirstPage.aspx")
    End Sub


End Class