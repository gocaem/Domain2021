Imports System
Imports System.Web.UI
Imports Microsoft.VisualBasic.CompilerServices


Public Partial Class PrintedReports
        Inherits Page
        Public Sub New()
            AddHandler Load, AddressOf Page_Load
        End Sub

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If MyBase.Session("Admin_User_ID") Is Nothing Then
                Response.Redirect("../logout.aspx")
            ElseIf Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(MyBase.Session("entered"), 1, False)) Then
                Response.Redirect("../logout.aspx")
            ElseIf Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(MyBase.Session("User_Role"), 3, False)) Then
                Response.Redirect("../logout.aspx")
            ElseIf MyBase.Session("PrintedDoc") Is Nothing Then
                Response.Redirect("../logout.aspx")
            End If
            Me.GridView1.DataSource = MyBase.Session("PrintedDoc")
            Me.GridView1.DataBind()
            Me.Amount.Text = MyBase.Session("Amount").ToString()
            Me.Label1.Text = "Print Date:" & Date.Now.ToString("dd/MM/yyyy")
        End Sub

    End Class

