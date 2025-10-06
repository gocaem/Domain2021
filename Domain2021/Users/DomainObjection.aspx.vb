Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading
Imports AjaxControlToolkit
Imports Domain2021.Toastr

Public Class DomainObjection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Session("User_ID") Is Nothing Then
                Response.Redirect("logout.aspx")
            End If
            If Session("entered") = "0" Then
                Response.Redirect("logout.aspx")
            End If
            Session("page") = "Objection"
            If Page.IsPostBack = False Then
                Dim lang As New Languages(Session("lang"))
                Dim connectionstr As DAL = New DAL()
                Dim Dns_obj As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim Dns_objCmd As New SqlClient.SqlCommand("SelectLatestApprovedDomains", Dns_obj)
                Dns_objCmd.Parameters.AddWithValue("admin_id", Session("User_ID"))
                Dim Dns_objReader As SqlClient.SqlDataReader
                Dns_obj.Open()
                Dns_objCmd.CommandType = CommandType.StoredProcedure
                Dns_objReader = Dns_objCmd.ExecuteReader
                DomainName.DataSource = Dns_objReader
                DomainName.DataTextField = "Domain_name"
                DomainName.DataValueField = "Domain_id"
                DomainName.DataBind()
                DomainName.Items.Insert(0, New ListItem("---" + lang.selectone + "---", "0"))
                Dns_objReader.Close()
                Dns_obj.Close()

                SetLanguage()


            End If

            Dim i As Integer = 1
            For Each gridrow In GridView2.Rows
                CType(gridrow.Cells(0).FindControl("Label64"), Label).Text = i
                i = i + 1

            Next

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainObjection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.Master"
        Else
            Me.MasterPageFile = "MasterPageEnn.Master"
        End If
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As String
        Dim randomInt32 As Integer = 0
        Dim rngCrypto As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        For i As Integer = 0 To 6 - 1
            Dim randomUnsignedInteger32Bytes As Byte() = New Byte(3) {}
            rngCrypto.GetBytes(randomUnsignedInteger32Bytes)
            randomInt32 = BitConverter.ToInt32(randomUnsignedInteger32Bytes, 0)
        Next
        Return Convert.ToString(randomInt32)
    End Function

    Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        nav.Style.Add("text-align", lang.right)
        nav.Style.Add("direction", lang.dir)
        container.Style.Add("text-align", lang.right)
        container.Style.Add("direction", lang.dir)
        container.Style.Add("Font-Family", lang.fonta)
        container.Style.Add("Font-size", "15px")
        container.Style.Add("font-weight", "bold")
        NextStep1.Text = lang.NextS
        NextStep1.Style.Add("Font-Family", lang.fonta)
        DomainLabel.Text = lang.DomainName
        Div2.Style.Add("text-align", lang.right)
        ObjectionText.Style.Add("Font-size", "13px")
        Div2.Style.Add("direction", lang.dir)
        Div2.Style.Add("Font-Family", lang.fonta)
        Div4.Style.Add("text-align", lang.right)
        Div4.Style.Add("Font-Family", lang.fonta)
        Div4.Style.Add("direction", lang.dir)
        DomainLabel.Style.Add("Font-size", "13px")
        GridView2.Columns(0).HeaderText = "#"
        docgrid.Columns(0).HeaderText = lang.filename
        GridView2.Columns(1).HeaderText = lang.DomainName
        GridView2.Columns(6).HeaderText = lang.waiting
        GridView2.Columns(7).HeaderText = lang.supporteduploadeddoc
        RequiredFieldValidator1.ErrorMessage = lang.RequiredField2
        RequiredFieldValidator2.ErrorMessage = lang.RequiredField2
        ObjectionText.Text = lang.ObjectionText
        DomainInfotab.InnerHtml = "<i class='fa fa-hand-stop-o' style='padding-left: 10px'></i>" + " " + lang.SubmitObj
        Documenttab.InnerHtml = "<i class='fa fa-file' style='padding-left: 10px'></i>" + " " + lang.UploadFiles2
        DomainInfotab.Style.Add("Font-Family", lang.fonta)
        Documenttab.Style.Add("Font-Family", lang.fonta)
        FinishRegistration.Text = lang.send
        PrevLast.Text = lang.prev
        FinishRegistration.Style.Add("Font-Family", lang.fonta)
        PrevLast.Style.Add("Font-Family", lang.fonta)
    End Sub
    Public Function getfilelist(ByVal ObjectionID As String) As String()
        Try


            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim dd As DateTime = Now
            Dim filearrList As ArrayList = New ArrayList()
            Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
            Dim odr As SqlClient.SqlDataReader
            Try
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "selectObjectDoc"
                comm.Parameters.AddWithValue("did", ObjectionID)
                comm.CommandType = Data.CommandType.StoredProcedure
                odr = comm.ExecuteReader()

                While (odr.Read())
                    filearrList.Add(odr(0))

                End While
                conn.Close()

            Catch ex As Exception
                conn.Close()
            End Try
            Dim filearr As String() = CType(filearrList.ToArray(GetType(String)), String())
            Return filearr
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainObjection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function


    Private Function GetRealContentType(ByVal fileStream As Stream) As String
        Dim buffer As Byte() = New Byte(7) {}
        fileStream.Read(buffer, 0, 8)

        If IsPdf(buffer) Then
            Return "application/pdf"
        ElseIf IsPng(buffer) Then
            Return "image/png"
        ElseIf IsJpeg(buffer) Then
            Return "image/jpeg"
        ElseIf IsBmp(buffer) Then
            Return "image/bmp"
        ElseIf IsGif(buffer) Then
            Return "image/gif"
        End If

        Return "unknown"
    End Function
    Public Shared Function IsPdf(buffer As Byte()) As Boolean
        Return buffer(0) = &H25 AndAlso buffer(1) = &H50 AndAlso buffer(2) = &H44 AndAlso buffer(3) = &H46 ' %PDF
    End Function

    Public Shared Function IsPng(buffer As Byte()) As Boolean
        Return buffer(0) = &H89 AndAlso buffer(1) = &H50 AndAlso buffer(2) = &H4E AndAlso buffer(3) = &H47 AndAlso
           buffer(4) = &HD AndAlso buffer(5) = &HA AndAlso buffer(6) = &H1A AndAlso buffer(7) = &HA ' PNG signature
    End Function



    Public Shared Function IsBmp(buffer As Byte()) As Boolean
        Return buffer(0) = &H42 AndAlso buffer(1) = &H4D ' BM (BMP signature)
    End Function
    Public Shared Function IsGif(buffer As Byte()) As Boolean
        ' Check for GIF signature: "GIF"
        Return buffer.Length >= 3 AndAlso
           buffer(0) = &H47 AndAlso ' G
           buffer(1) = &H49 AndAlso ' I
           buffer(2) = &H46 ' F
    End Function

    Public Shared Function IsJpeg(buffer As Byte()) As Boolean
        If buffer Is Nothing OrElse buffer.Length < 8 Then
            Return False
        End If

        Return buffer(0) = &HFF AndAlso buffer(1) = &HD8 AndAlso _ ' JPEG start
           buffer(2) = &HFF AndAlso (buffer(3) = &HE0 OrElse buffer(3) = &HE1 OrElse buffer(3) = &HDB) AndAlso _ ' Segment markers
           buffer(6) = &H4A AndAlso buffer(7) = &H46
    End Function


    Protected Sub OnUploadComplete(sender As Object, e As AjaxFileUploadEventArgs)
        Try


            Dim fileName As String = ""
            Dim rand As String = ""
            Dim fileCount As Integer = 0
            rand = GetRandom(1, 9)
            Dim lang As New Languages(Session("lang"))
            If GetRealContentType(e.GetStreamContents) = "image/png" Then
                fileName = rand & "_" & Session("ObjectionID") & Path.GetFileName(e.FileName)
                upload_doc(Session("ObjectionID"), fileName)
                docgrid.DataBind()
                AjaxFileUpload1.SaveAs(Server.MapPath("..\SupportDOC\" + fileName))
            ElseIf GetRealContentType(e.GetStreamContents) = "image/jpeg" Then
                fileName = rand & "_" & Session("ObjectionID") & Path.GetFileName(e.FileName)
                upload_doc(Session("ObjectionID"), fileName)
                docgrid.DataBind()
                Dim MPath As String = Server.MapPath("..\SupportDOC\" + fileName)
                AjaxFileUpload1.SaveAs(Server.MapPath("..\SupportDOC\" + fileName))
            ElseIf GetRealContentType(e.GetStreamContents) = "image/bmp" Then
                fileName = rand & "_" & Session("ObjectionID") & Path.GetFileName(e.FileName)
                upload_doc(Session("ObjectionID"), fileName)
                docgrid.DataBind()
                AjaxFileUpload1.SaveAs(Server.MapPath("..\SupportDOC\" + fileName))
            ElseIf GetRealContentType(e.GetStreamContents) = "image/gif" Then
                fileName = rand & "_" & Session("ObjectionID") & Path.GetFileName(e.FileName)
                upload_doc(Session("ObjectionID"), fileName)
                docgrid.DataBind()
                AjaxFileUpload1.SaveAs(Server.MapPath("..\SupportDOC\" + fileName))
            ElseIf GetRealContentType(e.GetStreamContents) = "application/pdf" Then
                fileName = rand & "_" & Session("ObjectionID") & Path.GetFileName(e.FileName)
                upload_doc(Session("ObjectionID"), fileName)
                docgrid.DataBind()
                AjaxFileUpload1.SaveAs(Server.MapPath("..\SupportDOC\" + fileName))

            Else
                Toastr.ShowToast(Me, ToastType.Error, lang.filext, lang.EError, ToastPosition.TopCenter)
            End If

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainObjection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try


    End Sub

    Private Function upload_doc(ByVal ObjectionID As Integer, ByVal STRFILE1 As String) As Boolean
        If STRFILE1 = "" Then
        Else
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim comm As New Data.SqlClient.SqlCommand
            Dim dd As DateTime = Now
            Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

            Try
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "insertObjDOC"
                comm.Parameters.AddWithValue("ObjectionID", ObjectionID)
                comm.Parameters.AddWithValue("SupportedDoc", STRFILE1)
                comm.CommandType = Data.CommandType.StoredProcedure
                comm.ExecuteNonQuery()
                conn.Close()
                upload_doc = True
                docgrid.DataBind()
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainObjection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                upload_doc = False
                conn.Close()
            End Try
        End If
        Return upload_doc
    End Function
    Protected Sub AjaxFileUpload1_UploadComplete(ByVal sender As Object, ByVal e As AjaxFileUploadEventArgs)

    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub NextStep1_Click(sender As Object, e As EventArgs)
        Try


            Dim connectionstr As DAL = New DAL()
            Dim Dns_Objectconn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim Dns_ObjectCmd As New SqlClient.SqlCommand("insertobj", Dns_Objectconn)
            Dns_Objectconn.Open()
            Dim ObjectionID As Integer = 0
            Dns_ObjectCmd.CommandType = CommandType.StoredProcedure
            Dns_ObjectCmd.Parameters.AddWithValue("Objection", Objection.Text)
            Dns_ObjectCmd.Parameters.AddWithValue("Domain_id", DomainName.SelectedValue)
            Dns_ObjectCmd.Parameters.AddWithValue("admin_id", Session("User_ID"))
            Dns_ObjectCmd.Parameters.AddWithValue("Status", 0)
            ObjectionID = Dns_ObjectCmd.ExecuteScalar()
            Session("ObjectionID") = ObjectionID

            Dns_Objectconn.Close()
            DomainInfo.CssClass = "tab-pane"
            DomainInfotab.Attributes.Remove("class")
            DomainInfotab.Attributes.Add("class", "nav-link")
            DocumentInfo.CssClass = "tab-pane active show"
            DocumentInfo.Attributes.Remove("class")
            DocumentInfo.Attributes.Add("class", "nav-link active")
            DocumentPanel.Enabled = True
            DomainInfo.Enabled = False
            DomainInfo.CssClass = "tab-pane"
            Documenttab.Attributes.Remove("class")
            Documenttab.Attributes.Add("class", "nav-link active")
            DocumentPanel.Visible = True
            DocumentPanel.Enabled = True
            DomainInfo.Enabled = False
            DocumentInfo.Visible = True
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\DomainObjection:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub

    Protected Sub PrevLast_Click(sender As Object, e As EventArgs)
        DomainInfo.CssClass = "tab-pane"
        DomainInfotab.Attributes.Remove("class")
        DomainInfotab.Attributes.Add("class", "nav-link active")
        DocumentInfo.CssClass = "tab-pane"
        DocumentInfo.Attributes.Remove("class")
        DocumentInfo.Attributes.Add("class", "nav-link")
        DocumentPanel.Enabled = False
        DomainInfo.Enabled = True
        DomainInfo.CssClass = "tab-pane  active show"
        Documenttab.Attributes.Remove("class")
        Documenttab.Attributes.Add("class", "nav-link")
        DocumentPanel.Visible = False
        DocumentPanel.Enabled = False
        DomainInfo.Enabled = True
        DocumentInfo.Visible = False
    End Sub

    Protected Sub FinishRegistration_Click(sender As Object, e As EventArgs)
        tabs.Visible = False
        Dim lang As New Languages(Session("lang"))
        Result.Text = lang.SendObjection
        Result.Visible = True
    End Sub

    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "paper" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim did As Integer = Convert.ToInt32(e.CommandArgument)
            Session("id") = did
            docgrid.DataBind()
        End If
    End Sub
End Class