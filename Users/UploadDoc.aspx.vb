Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Threading
Imports AjaxControlToolkit
Imports Domain2021.Toastr

Public Class UploadDoc
    Inherits System.Web.UI.Page
    Dim sFolder As String = "..\DOC"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("page") = "upload"
        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If
        If Session("DID") Is Nothing Then
            Response.Redirect("mydomains.aspx")
        End If
        Session("notfinished") = setfinished(Session("DID"))

        If Session("notfinished") = True Then

            FinishRegistrationB.Visible = False
            agree.Visible = False
            ckboxvalidator.Visible = False
        Else
            ckboxvalidator.Visible = True
            FinishRegistrationB.Visible = True
        End If
        If Request.QueryString("folder") <> "" Then
            sFolder = "..\DOC"
        End If
        Dim lang As New Languages(Session("lang"))
        Dim sFolderPath As String = Server.MapPath(sFolder)
        If System.IO.Directory.Exists(sFolderPath) = False Then
            Response.Write(lang.isExist & sFolderPath)
            Response.End()
        End If

        ImageButton1.ToolTip = lang.refreshsupporteduploadeddoc
        Label2.Text = lang.refreshsupporteduploadeddoc
        setLanguage()


    End Sub
    Private Function setfinished(ByVal did As Integer) As Boolean
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand
        Dim isfinished As Boolean
        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "selectisFinished"
            comm.Parameters.AddWithValue("did", did)
            comm.CommandType = Data.CommandType.StoredProcedure
            isfinished = comm.ExecuteScalar()
            Return isfinished
            conn.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\UploadDoc:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
    End Function
    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        docgrid.Columns(0).HeaderText = lang.uploadedfiles
        fs.Attributes.Add("font-family", lang.fonta)
        docgrid.Attributes.Add("font-family", lang.fonta)
        fs.Attributes.Add("text-align", lang.right)
        fs.Style.Add("direction", lang.dir)
        fs1.Style.Add("font-family", lang.fonta)
        fs1.Style.Add("text-align", lang.right)
        fs1.Style.Add("direction", lang.dir)
        FinishRegistrationB.Font.Name = lang.fonta
        FinishRegistrationB.Text = lang.btnRegister
        agree.Text = lang.Agree
        ckboxvalidator.ErrorMessage = lang.clarify
        RegistrationPrompt.Text = lang.thankyouMSg2
        DomainInfotab.InnerHtml = "<i class='fa fa-info-circle' style='padding-left: 10px'></i>" + " " + lang.domaininfo
        Servertab.InnerHtml = "<i class='fa fa-server' style='padding-left: 10px'></i>" + " " + lang.Servers
        ContactInfotab.InnerHtml = "<i class='fa fa-info' style='padding-left: 10px'></i>" + " " + lang.ContactData
        Documenttab.InnerHtml = "<i class='fa fa-file' style='padding-left: 10px'></i>" + " " + lang.UploadFiles2
        divagree.Style.Add("font-family", lang.fonta)
        divagree.Style.Add("text-align", lang.right)
        divagree.Style.Add("direction", lang.dir)
        agree.Style.Add("font-family", lang.fonta)
        Label2.Attributes.Add("font-family", lang.fonta)
        docgrid.Style.Add("font-family", lang.fonta)
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


    Public Function getfilelist(ByVal did As String) As String()
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
            comm.CommandText = "selectdoc"
            comm.Parameters.AddWithValue("did", did)
            comm.CommandType = Data.CommandType.StoredProcedure
            odr = comm.ExecuteReader()

            While (odr.Read())
                filearrList.Add(odr(0))

            End While
            conn.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\UploadDoc:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try
        Dim filearr As String() = CType(filearrList.ToArray(GetType(String)), String())
        Return filearr
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




    Protected Sub OnUploadComplete(sender As Object, e As AjaxFileUploadEventArgs)

        Dim fileName As String = ""
        Dim rand As String = ""
        Dim fileCount As Integer = 0
        rand = GetRandom(1, 9)

        ' Dim fsSource As FileStream = New FileStream(Server.MapPath("..\DOC\" + fileName), FileMode.Open, FileAccess.Read)

        Dim lang As New Languages(Session("lang"))
        If GetRealContentType(e.GetStreamContents) = "image/png" Then
            fileName = rand & "_" & Session("DID") & Path.GetFileName(e.FileName)
            upload_doc(Session("DID"), fileName)
            docgrid.DataBind()
            AjaxFileUpload1.SaveAs(Server.MapPath("..\DOC\" + fileName))
        ElseIf GetRealContentType(e.GetStreamContents) = "image/jpeg" Then
            fileName = rand & "_" & Session("DID") & Path.GetFileName(e.FileName)
            upload_doc(Session("DID"), fileName)
            docgrid.DataBind()
            Dim MPath As String = Server.MapPath("..\DOC\" + fileName)
            AjaxFileUpload1.SaveAs(Server.MapPath("..\DOC\" + fileName))
        ElseIf GetRealContentType(e.GetStreamContents) = "image/bmp" Then
            fileName = rand & "_" & Session("DID") & Path.GetFileName(e.FileName)
            upload_doc(Session("DID"), fileName)
            docgrid.DataBind()
            AjaxFileUpload1.SaveAs(Server.MapPath("..\DOC\" + fileName))
        ElseIf GetRealContentType(e.GetStreamContents) = "image/gif" Then
            fileName = rand & "_" & Session("DID") & Path.GetFileName(e.FileName)
            upload_doc(Session("DID"), fileName)
            docgrid.DataBind()
            AjaxFileUpload1.SaveAs(Server.MapPath("..\DOC\" + fileName))
        ElseIf GetRealContentType(e.GetStreamContents) = "application/pdf" Then
            fileName = rand & "_" & Session("DID") & Path.GetFileName(e.FileName)
            upload_doc(Session("DID"), fileName)
            docgrid.DataBind()
            AjaxFileUpload1.SaveAs(Server.MapPath("..\DOC\" + fileName))

        Else
            Toastr.ShowToast(Me, ToastType.Error, lang.filext, lang.EError, ToastPosition.TopCenter)
        End If




    End Sub

    Private Function upload_doc(ByVal doman_id As Integer, ByVal STRFILE1 As String) As Boolean
        If STRFILE1 = "" Then
        Else
            Dim connectionstr As DAL = New DAL()
            Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim dd As DateTime = Now
            Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
            Dim comm As New SqlClient.SqlCommand
            Try
                conn.Open()
                comm.Connection = conn
                comm.CommandText = "upload_files_proc"
                comm.Parameters.AddWithValue("id", doman_id)
                comm.Parameters.AddWithValue("file", STRFILE1)
                comm.CommandType = Data.CommandType.StoredProcedure
                comm.ExecuteNonQuery()
                conn.Close()
                upload_doc = True
                docgrid.DataBind()
                conn.Close()
            Catch ex As Exception
                If Not (TypeOf ex Is ThreadAbortException) Then
                    File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\UploadDoc:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
                End If
                upload_doc = False
                conn.Close()
            End Try
        End If
        Return upload_doc
    End Function

    Protected Sub FinishRegistrationB_Click(sender As Object, e As EventArgs) Handles FinishRegistrationB.Click
        Session("value") = "register"
        Dim connectionstr As DAL = New DAL()
        Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
        Dim comm As New Data.SqlClient.SqlCommand

        Try
            conn.Open()
            comm.Connection = conn
            comm.CommandText = "Update_finished"
            comm.Parameters.AddWithValue("did", Session("DID"))
            comm.CommandType = Data.CommandType.StoredProcedure
            comm.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\UploadDoc:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            conn.Close()
        End Try

        Response.Redirect("popupU.aspx")

    End Sub
    Public Shared Function IsJpeg(buffer As Byte()) As Boolean
        If buffer Is Nothing OrElse buffer.Length < 8 Then
            Return False
        End If

        Return buffer(0) = &HFF AndAlso buffer(1) = &HD8 AndAlso _ ' JPEG start
           buffer(2) = &HFF AndAlso (buffer(3) = &HE0 OrElse buffer(3) = &HE1 OrElse buffer(3) = &HDB) AndAlso _ ' Segment markers
           buffer(6) = &H4A AndAlso buffer(7) = &H46
    End Function

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        docgrid.DataBind()
        docgrid.Visible = True
    End Sub
End Class