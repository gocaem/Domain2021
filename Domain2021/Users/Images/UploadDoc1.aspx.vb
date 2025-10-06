Imports System.IO
Imports System.Security.Cryptography
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
        If Session("notfinished") = 1 Then
            ckboxvalidator.Visible = True
            FinishRegistrationB.Visible = True
        Else
            agree.Visible = False
            ckboxvalidator.Visible = False
        End If
        Dim lang As New Languages(Session("lang"))
        If Request.QueryString("folder") <> "" Then
            sFolder = "..\DOC"
        End If
        '  file1.AllowMultiple = True
        Dim sFolderPath As String = Server.MapPath(sFolder)
        If System.IO.Directory.Exists(sFolderPath) = False Then
            Response.Write(lang.isExist & sFolderPath)
            Response.End()
        End If
        If Request.HttpMethod = "POST" Then

            If Request.Form("btnDelete") <> "" Then
                'Delete files
                If (Not Request.Form.GetValues("chkDelete") Is Nothing) Then
                    For i As Integer = 0 To Request.Form.GetValues("chkDelete").Length - 1
                        Dim sFileName As String = Request.Form.GetValues("chkDelete")(i)

                        ' Try
                        System.IO.File.Delete(sFolderPath & "\" & sFileName)
                        'Catch ex As Exception
                        '    'Ignore error
                        'End Try
                    Next
                End If

            Else
                Dim rand As String = ""
                '  Dim lang As New Languages(Session("lang"))
                Dim fileCount As Integer = 0
                Dim filename As String = ""
                Dim filecoll = Request.Files

                Dim i As Integer
                For i = 0 To filecoll.Count - 1
                    If GetRealContentType(filecoll(i).InputStream) = "image/gif" Or "image/bmp" Or "image/png" Or "application/pdf" Or "application/jpeg" Then
                        rand = GetRandom(1, 9)
                        filename = rand & "_" & Session("DID") & filecoll(i).FileName
                        filecoll(i).SaveAs(Server.MapPath("~") + "\\DOC\\" + filename)
                        upload_doc(Session("DID"), filename)

                        ShowFiles(filename)
                    Else
                        Toastr.ShowToast(Me, ToastType.Error, lang.filext, lang.EError)
                    End If

                Next





            End If

        End If
        setLanguage()


    End Sub
    Private Sub setLanguage()
        Dim lang As New Languages(Session("lang"))
        docgrid.Columns(0).HeaderText = lang.uploadedfiles
        fs.Attributes.Add("font-family", lang.fonta)
        finish.Attributes.Add("text-align", lang.right)
        docgrid.Attributes.Add("font-family", lang.fonta)
        fs.Attributes.Add("text-align", lang.right)
        fs.Attributes.Add("direction", lang.dir)
        fs1.Attributes.Add("font-family", lang.fonta)
        fs1.Attributes.Add("text-align", lang.right)
        fs1.Attributes.Add("direction", lang.dir)
        FinishRegistrationB.Font.Name = lang.fonta
        FinishRegistrationB.Text = lang.btnRegister
        agree.Text = lang.Agree
        ckboxvalidator.ErrorMessage = lang.clarify
        RegistrationPrompt.Text = lang.thankyouMSg2
        DomainInfotab.InnerHtml = "<i class='fa fa-info-circle' style='padding-left: 10px'></i>" + " " + lang.domaininfo
        Servertab.InnerHtml = "<i class='fa fa-server' style='padding-left: 10px'></i>" + " " + lang.Servers
        ContactInfotab.InnerHtml = "<i class='fa fa-info' style='padding-left: 10px'></i>" + " " + lang.ContactData
        Documenttab.InnerHtml = "<i class='fa fa-file' style='padding-left: 10px'></i>" + " " + lang.UploadFiles2

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
        Dim conn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
        Dim comm As New Data.SqlClient.SqlCommand
        Dim dd As DateTime = Now
        Dim filearrList As ArrayList = New ArrayList()
        Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim odr As SqlClient.SqlDataReader
        '   Try
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

        ' Catch ex As Exception
        'conn.Close()
        '  End Try
        Dim filearr As String() = CType(filearrList.ToArray(GetType(String)), String())
        Return filearr
    End Function
    Public Sub ShowFiles(ByVal filename As String)
        Dim sFolderPath As String = Server.MapPath("..\DOC")
        Dim oFiles As String() = getfilelist(Session("DID")) 'System.IO.Directory.GetFiles(sFolderPath)
        Dim rand As String = ""
        Dim filearrList As ArrayList = New ArrayList()
        If Not oFiles.Length = 0 Then


            rand = GetRandom(1, 9)
            Response.Write("<br><table id='tbServer'  runat='server' class='table table-responsive'>")

            For i As Integer = 0 To oFiles.Length - 1
                Dim sFilePath As String = oFiles(i)
                Dim oFileInfo As New System.IO.FileInfo(sFilePath)
                Dim sFileName As String = filename
                Dim sSize As String = ""
                Dim LastModified As String = ""
                If System.IO.File.Exists(sFilePath) Then
                    sSize = FormatNumber((oFileInfo.Length / 1024), 0)
                    If sSize = "0" AndAlso oFileInfo.Length > 0 Then sSize = "1"
                    LastModified = oFileInfo.LastWriteTime.ToShortDateString() & " " & oFileInfo.LastWriteTime.ToShortTimeString()

                Else
                    sSize = "0"
                    LastModified = "N/A"
                    sFileName = ""
                End If
                If Not filename = "" Then
                    Response.Write("<tr>")
                    Response.Write("<td><a href=""" & "../DOC" & "/" & filename & """ target='_blank'>" & filename + "</a></td>")
                    Response.Write("<td>" & sSize & " KB</td>")
                    Response.Write("<td>" & LastModified & "</td>")
                    Response.Write("<td><input type=checkbox name=chkDelete value=""" & sFileName & """>")
                    Response.Write("</tr>")
                    filearrList.Add(oFiles(i))
                End If


            Next

            Response.Write("</table><br>")
            docgrid.DataBind()
        End If
    End Sub
    Private Function upload_doc(ByVal doman_id As Integer, ByVal STRFILE1 As String) As Boolean
        If STRFILE1 = "" Then
        Else
            Dim conn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("NewDNS").ConnectionString)
            Dim comm As New Data.SqlClient.SqlCommand
            Dim dd As DateTime = Now
            Dim DDT As String = dd.ToString("dd/MM/yyyy hh:mm:ss tt")

            ' Try
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
            ' Catch ex As Exception
            ' upload_doc = False
            'conn.Close()
            'End Try
        End If
        Return upload_doc
    End Function

    Protected Sub FinishRegistrationB_Click(sender As Object, e As EventArgs) Handles FinishRegistrationB.Click
        fs.Visible = False
        FinishRegistrationB.Visible = False
        agree.Visible = False
        RegistrationPrompt.Visible = True
    End Sub
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

    Public Shared Function IsJpeg(buffer As Byte()) As Boolean
        Return buffer(0) = &HFF AndAlso buffer(1) = &HD8 AndAlso buffer(2) = &HFF AndAlso buffer(3) = &HE0 AndAlso ' JPEG start
           buffer(6) = &H4A AndAlso buffer(7) = &H46 AndAlso buffer(8) = &H49 AndAlso buffer(9) = &H46 ' "JFIF"
    End Function

    Public Shared Function IsBmp(buffer As Byte()) As Boolean
        Return buffer(0) = &H42 AndAlso buffer(1) = &H4D ' BM (BMP signature)
    End Function
End Class