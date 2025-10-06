Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography

Public Class ReusableCode
    Public Shared Function GenerateRandomNo() As Integer
        Const min As Integer = 100000
        Const max As Integer = 999999
        Const elemInRange As Integer = max - min + 1
        Dim randomData = New Byte(3) {}

        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()


        rng.GetBytes(randomData)
        Dim randomInt = BitConverter.ToUInt32(randomData, 0)
        Dim [mod] = randomInt Mod elemInRange
        Dim secureNumber = min + [mod]
        Return secureNumber
    End Function
    Public Shared Function Decrypt(ByVal toDecrypt As String) As String
        Dim lang As New Languages("en")
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding
        Dim inputByteArray() As Byte = utf8encoder.GetBytes(toDecrypt)
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim iv() As Byte = lang.iv
        Dim key() As Byte = lang.key

        ' As before we must provide the encryption/decryption key along with
        ' the init vector.
        toDecrypt = toDecrypt.Replace(" ", "+")
        inputByteArray = System.Convert.FromBase64String(toDecrypt)
        Dim ms As New MemoryStream
        Dim cs As New CryptoStream(ms, tdesProvider.CreateDecryptor(key, iv), CryptoStreamMode.Write)
        cs.Write(inputByteArray, 0, inputByteArray.Length)
        cs.FlushFinalBlock()
        Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8()
        cs.Close()
        cs = Nothing
        tdesProvider.Clear()
        tdesProvider = Nothing
        Dim arrX() As Byte = ms.ToArray
        ms.Close()
        ms = Nothing
        System.GC.Collect()
        Return encoding.GetString(arrX)
    End Function
    Public Shared Function sndMail(ByVal recip_m As String, ByVal recip_n As String, ByVal Subject As String, ByVal Message_body As String) As Boolean
        Try


            Dim msgObj As New MailMessage
            Dim client As New SmtpClient("relay.webmail.gov.jo")
            client.Host = "relay.webmail.gov.jo"
            client.Port = "25"
            client.UseDefaultCredentials = True
            'Specify from address and display name
            Dim from2 As New MailAddress(recip_n, "DNS .jo/.الاردن")
            Dim BCC_email As String = "dns@modee.gov.jo"
            Dim rec2 As New MailAddress(recip_m)
            msgObj.Subject = Subject
            msgObj.IsBodyHtml = True
            msgObj.Body = Message_body
            msgObj.To.Add(rec2)
            msgObj.Bcc.Add(New MailAddress(BCC_email))
            msgObj.From = from2
            msgObj.BodyEncoding = System.Text.UTF8Encoding.UTF8
            client.Send(msgObj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DES_ENC(ByVal PASSWORD As String, ByVal USER As String) As String
        Dim lang As New Languages("en")
        Dim TDESprov As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim key() As Byte = lang.key
        Dim iv() As Byte = lang.iv
        TDESprov.IV = iv
        TDESprov.Key = key
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(PASSWORD)
        Dim trans As ICryptoTransform = TDESprov.CreateEncryptor()
        Dim encryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, trans, CryptoStreamMode.Write)
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0
        Dim cipher() As Byte = encryptedStream.ToArray
        Dim cipherText As String = Convert.ToBase64String(cipher)
        Return cipherText
        cryptStream.Close()
    End Function
    Public Shared Function VisitURL(strurl As String) As String
        Try

            ' request to the url
            Dim mywebrequest As HttpWebRequest = DirectCast(WebRequest.Create(strurl), HttpWebRequest)
            mywebrequest.Credentials = CredentialCache.DefaultNetworkCredentials
            mywebrequest.ContentType = " text/html"
            ' get the respose
            Dim mywebresponse As HttpWebResponse = DirectCast(mywebrequest.GetResponse(), HttpWebResponse)
            'getting the response stream.
            Dim myWebSource As New StreamReader(mywebresponse.GetResponseStream())
            Dim myPageSource As String = myWebSource.ReadToEnd()
            mywebresponse.Close()
            mywebrequest.Timeout = 200000

            Return myPageSource
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim ipAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If Not String.IsNullOrEmpty(ipAddress) Then
            Dim addresses As String() = ipAddress.Split(","c)

            If addresses.Length <> 0 Then
                Return addresses(0)
            End If
        End If

        Return context.Request.ServerVariables("REMOTE_ADDR")
    End Function
    Public Shared Function DES_ENC(ByVal PASSWORD As String) As String
        Dim lang As New Languages("en")
        Dim TDESprov As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim key() As Byte = lang.key
        Dim iv() As Byte = lang.iv
        TDESprov.IV = iv
        TDESprov.Key = key
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(PASSWORD)
        Dim trans As ICryptoTransform = TDESprov.CreateEncryptor()
        Dim encryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, trans, CryptoStreamMode.Write)
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0
        Dim cipher() As Byte = encryptedStream.ToArray
        Dim cipherText As String = Convert.ToBase64String(cipher)
        Return cipherText
        cryptStream.Close()
    End Function

    Public Shared Function GetEnglishContent(ByVal PageName As String) As String
        Dim connectionstr As DAL = New DAL()
        Dim Dns_WebContentconn As New SqlClient.SqlConnection(Decrypt(connectionstr.Connection))
        Dim Dns_WebContentCmd As New SqlClient.SqlCommand("DNSWebsite_SelectPageContent", Dns_WebContentconn)
        Dim Dns_WebReader As SqlClient.SqlDataReader
        Dim Content As String = ""
        Dns_WebContentconn.Open()
        Dns_WebContentCmd.CommandType = CommandType.StoredProcedure
        Dns_WebContentCmd.CommandText = "DNSWebsite_SelectPageContent"
        Dns_WebContentCmd.Parameters.AddWithValue("PageName", PageName)
        Dns_WebReader = Dns_WebContentCmd.ExecuteReader()

        While Dns_WebReader.Read
            Content = System.Net.WebUtility.HtmlDecode(Dns_WebReader("EnglishContent"))
            Content = Content.Replace(ControlChars.Quote, "'")
        End While
        Dns_WebReader.Close()
        Dns_WebContentconn.Close()
        Return Content

    End Function
    Public Shared Function GetArabicContent(ByVal PageName As String) As String
        Dim connectionstr As DAL = New DAL()
        Dim Dns_WebContentconn As New SqlClient.SqlConnection(Decrypt(connectionstr.Connection))
        Dim Dns_WebContentCmd As New SqlClient.SqlCommand("DNSWebsite_SelectPageContent", Dns_WebContentconn)
        Dim Dns_WebReader As SqlClient.SqlDataReader
        Dim Content As String = ""
        Dns_WebContentconn.Open()
        Dns_WebContentCmd.CommandType = CommandType.StoredProcedure
        Dns_WebContentCmd.CommandText = "DNSWebsite_SelectPageContent"
        Dns_WebContentCmd.Parameters.AddWithValue("PageName", PageName)
        Dns_WebReader = Dns_WebContentCmd.ExecuteReader()

        While Dns_WebReader.Read
            Content = System.Net.WebUtility.HtmlDecode(Dns_WebReader("ArabicContent"))
            Content = Content.Replace(ControlChars.Quote, "'")
        End While
        Dns_WebReader.Close()
        Dns_WebContentconn.Close()
        Return Content

    End Function
    Public Shared Function sndMail_Notification(ByVal recip_m As String, ByVal recip_n As String, ByVal Subject As String, ByVal Message_body As String) As Boolean
        Try


            Dim msgObj As New MailMessage
            Dim client As New SmtpClient("relay.webmail.gov.jo")
            client.Host = "relay.webmail.gov.jo"
            client.Port = "25"
            client.UseDefaultCredentials = True
            'Specify from address and display name
            Dim from2 As New MailAddress(recip_n, "DNS .jo/.الاردن")
            Dim BCC_email As String = "dns@modee.gov.jo"
            Dim rec2 As New MailAddress(recip_m)
            msgObj.Subject = Subject
            msgObj.IsBodyHtml = True
            msgObj.Body = Message_body
            msgObj.To.Add(rec2)
            msgObj.CC.Add(New MailAddress(BCC_email))
            msgObj.Bcc.Add(New MailAddress("reef.amarin@modee.gov.jo"))
            msgObj.Bcc.Add(New MailAddress("Revenues@modee.gov.jo"))
            msgObj.From = from2
            msgObj.BodyEncoding = System.Text.UTF8Encoding.UTF8
            client.Send(msgObj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
