Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports OfficeOpenXml
Imports System.Diagnostics
Imports Spire.Pdf.Exporting.XPS.Schema
Imports FileFormat = Spire.Presentation.FileFormat
Imports RestSharp
Imports RestSharp.Serialization.Json
Imports Spire.Pdf
Imports Spire.Presentation.Drawing
Imports Spire.Presentation
Imports QRCoder
Imports System.Net
Imports Newtonsoft.Json
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Public Class report_invoice
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("User_ID") Is Nothing Then
            Response.Redirect("logout.aspx")
        End If
        If Session("entered") = "0" Then
            Response.Redirect("../LoginUser.aspx")
        End If

        FILL_DATAGRED(Nothing)
        Me.SearchInvoices()
        SetLanguage()
        Dim i As Integer = 1

        GridView1.DataBind()

        For Each dg In GridView1.Rows
            CType(dg.FindControl("Seq"), Label).Text = i
            i = i + 1
        Next

    End Sub
    Private Sub FILL_DATAGRED(Optional ByVal sortExpression As String = Nothing)

        Try
            Dim connectionstr As DAL = New DAL()
            Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim cmd As SqlCommand = New SqlCommand("efawatercomInvoices")
            Dim sda As SqlDataAdapter = New SqlDataAdapter
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("ADMIN_ID", Session("User_ID"))
            sda.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            sda.Fill(dt)
            If dt.Rows.Count >= 1 Then
                exportcard.Visible = True
            End If
            GridView1.DataSource = dt
            GridView1.DataBind()

            Dim lang As New Languages(Session("lang"))


        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
            Dim lang As New Languages(Session("lang"))
            lbl_error.Text = lang.EError
        End Try
    End Sub
    Protected Sub Search(sender As Object, e As EventArgs)
        Me.SearchInvoices()
    End Sub
    Private Sub SearchInvoices()
        Try

            Dim connectionstr As DAL = New DAL()
            Using con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand()
                    Dim sql As String = "Search_Invoices"
                    cmd.Parameters.AddWithValue("@admin_id", Session("User_ID"))
                    cmd.Parameters.AddWithValue("@domain_name", domainname.Text.Trim())
                    cmd.Parameters.AddWithValue("@end_date", enddate.Text)
                    cmd.Parameters.AddWithValue("@startdate", startdate.Text)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = sql
                    cmd.Connection = con
                    Using sda As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Private Sub ExportToExcel(ByVal dt As DataTable, ByVal fileName As String)
        Try
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial

            Using pck As ExcelPackage = New ExcelPackage()
                Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.Add("Sheet1")
                ws.Cells("A1").LoadFromDataTable(dt, True)
                ws.Column(2).Style.Numberformat.Format = "yyyy-mm-dd"

                Using stream As MemoryStream = New MemoryStream()
                    pck.SaveAs(stream)
                    Dim content As Byte() = stream.ToArray()
                    Response.Clear()
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    Response.AddHeader("content-disposition", $"attachment; filename={fileName}")
                    Response.BinaryWrite(content)
                    Response.[End]()
                End Using
            End Using
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    Private Function GetDataFromGridView() As DataTable
        Try
            Dim connectionstr As DAL = New DAL()
            Dim con As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim cmd As SqlCommand = New SqlCommand("ExportSearch_Invoices")
            Dim sda As SqlDataAdapter = New SqlDataAdapter
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("admin_id", Session("User_ID"))
            cmd.Parameters.AddWithValue("sess", Session("lang"))
            cmd.Parameters.AddWithValue("domain_name", domainname.Text)
            cmd.Parameters.AddWithValue("end_date", enddate.Text)
            cmd.Parameters.AddWithValue("startdate", startdate.Text)
            sda.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            sda.Fill(dt)
            Return dt
            con.Close()

        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)
        Dim dt As DataTable = New DataTable
        dt = GetDataFromGridView()
        If dt.Rows.Count >= 1 Then
            ExportToExcel(dt, "PaymentList " + Now.ToString("dd-MM-yyyy") + ".xlsx")
        End If

    End Sub
    Function GetRowsCount(ByVal pid As String) As Integer
        Try
            Dim ccount As Integer = 0
            Dim Countreader As SqlClient.SqlDataReader
            Dim connectionstr As DAL = New DAL()
            Dim connCount As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim commCount As New Data.SqlClient.SqlCommand("efawatercomInvoicesdet", connCount)
            commCount.CommandType = CommandType.StoredProcedure
            commCount.Parameters.AddWithValue("invoice_settingID", Session("pid"))
            connCount.Open()
            Countreader = commCount.ExecuteReader
            While Countreader.Read
                ccount = ccount + 1
            End While
            Return ccount
            connCount.Close()
            Countreader.Close()
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Function
    Private Sub SetLanguage()
        Dim lang As New Languages(Session("lang"))
        Label1.Text = lang.searchInvoices
        Label1.Style.Add("Font-family", lang.fonta)
        Label3.Text = lang.TransDate + "  " + "(" + lang.fromDate + ")"
        Label4.Text = lang.TransDate + "  " + "(" + lang.ToDate + ")"
        btnc.InnerText = lang.close
        btnc.Style.Add("font-family", lang.fonta)
        Label3.Style.Add("Font-family", lang.fonta)
        Label4.Style.Add("Font-family", lang.fonta)
        lblupdate.Text = lang.cannotqr
        lblupdate.Style.Add("Font-family", lang.fonta)
        Label5.Text = lang.DomainName
        Label5.Style.Add("Font-family", lang.fonta)
        cardtext.InnerText = lang.excel
        cardtitle.InnerText = lang.Download
        cardtext.Style.Add("font-family", lang.fonta)
        cardtitle.Style.Add("font-family", lang.fonta)
        GridView1.Columns(0).HeaderText = "#"
        GridView1.Columns(1).HeaderText = lang.InvoiceNO
        GridView1.Columns(2).HeaderText = lang.DDate
        GridView1.Columns(3).HeaderText = lang.totalAmm.Replace(":", "")
        GridView1.Columns(4).HeaderText = lang.print
        GridView1.Columns(6).HeaderText = lang.details
        GridView1.Columns(7).HeaderText = lang.downloadPDF
        GridView1.Style.Add("Font-family", lang.fonta)
        GridView1.Font.Size = 10
        GridView1.Style.Add("direction", lang.dir)
        GridView1.Columns(0).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(1).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(2).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(3).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(4).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(5).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(6).HeaderStyle.Font.Name = lang.fonta
        GridView1.Columns(7).HeaderStyle.Font.Name = lang.fonta
        GridView1.HeaderStyle.Font.Name = lang.fonta
        Label13.Text = lang.AllInvoices
        Label13.Font.Name = lang.fonta
        Label13.Font.Size = 13
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Session("page") = "report_invoice"
        If Session("lang") = "ar" Then
            Me.MasterPageFile = "MasterPage_Ar.master"
        Else
            Me.MasterPageFile = "MasterPageEnn.master"
        End If
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Calculate the row number based on the page index and the page size
            Dim rowNumber As Integer = (GridView1.PageIndex * GridView1.PageSize) + e.Row.RowIndex + 1

            ' Find the Label control and set the value
            Dim lblRowNumber As Label = CType(e.Row.FindControl("Seq"), Label)
            If lblRowNumber IsNot Nothing Then
                lblRowNumber.Text = rowNumber.ToString()
            End If
        End If
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim ccount As Integer = 0
            Dim lang As New Languages(Session("lang"))
            If e.CommandName = "det" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim PID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("dueamt") = row.Cells(3).Text
                Session("pid") = PID
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('Print_invoice.aspx');", True)
            ElseIf e.CommandName = "det2" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim PID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("pid") = PID
                ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('invoicedet.aspx');", True)
            ElseIf e.CommandName = "det3" Then
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim PID As Integer = Convert.ToInt32(e.CommandArgument)
                Session("pid") = PID
                ccount = GetRowsCount(PID)
                Dim Years(ccount) As String
                Dim Domains(ccount) As String
                Dim DomainsID(ccount) As Integer
                Dim i As Integer = 0
                Dim reader As SqlClient.SqlDataReader
                Dim connectionstr As DAL = New DAL()
                Dim conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Dim comm As New Data.SqlClient.SqlCommand("efawatercomInvoicesdet", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.AddWithValue("invoice_settingID", Session("pid"))
                conn.Open()
                reader = comm.ExecuteReader
                While reader.Read
                    If Not reader("DueAmt") Is DBNull.Value Then
                        Session("PaidAmt") = reader("DueAmt")
                        Session("ddate") = reader("DDate")
                        Session("Admin_id") = reader("Admin_id")
                        Years(i) = reader("years").ToString()
                        Domains(i) = reader("domainName").ToString()
                        DomainsID(i) = reader("Domain_id").ToString()
                        Session("clientname") = reader("ADMIN_CONTACT").ToString()
                        i = i + 1
                    End If
                End While
                Dim logoMoOEE As String = ""
                logoMoOEE = Server.MapPath("~/modeelogoen.png")
                Dim logoMoDEEar As String = ""
                logoMoDEEar = Server.MapPath("~/MoDEE.png")

                Dim QRData As String = ""
                Dim QRToSend As String = ""

                If Session("lang") = "en" Then
                    If File.Exists(Server.MapPath("~\invoices\" & "Invoice_" & Session("pid") & ".pdf")) Then
                        Dim filetoOpen As String = "..\\invoices\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    Else
                        Session("InvoiceLine") = GetInvoiceLines(Years, Domains, i, DomainsID)
                        QRData = GenerateUBLInvoiceXml()

                        QRToSend = GenerateQR(QRData)
                        If QRToSend = "" Then
                            ScriptManager.RegisterStartupScript(Page, Me.GetType(), Guid.NewGuid().ToString(), "openModal();", True)
                        Else
                            ExtractInvoiceAsPDF(Session("Admin_id"), logoMoDEE, Session("PaidAmt"), Server.MapPath("~\invoices\" & "Invoice_" & Session("pid") & ".pdf"), QRToSend, Years, Domains, Session("pid"), Session("clientname"))

                        End If

                    End If
                Else
                    If File.Exists(Server.MapPath("~\invoicesAr\" & "Invoice_" & Session("pid") & ".pdf")) Then
                        Dim filetoOpen As String = "..\\invoicesAr\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    Else
                        Session("InvoiceLine") = GetInvoiceLines(Years, Domains, i, DomainsID)
                        QRData = GenerateUBLInvoiceXml()
                        QRToSend = GenerateQR(QRData)
                        If QRToSend = "" Then
                            ScriptManager.RegisterStartupScript(Page, Me.GetType, Guid.NewGuid().ToString(), "openModal();", True)
                        Else
                            ExtractInvoiceAsPDF(Session("Admin_id"), logoMoOEEar, Session("PaidAmt"), Server.MapPath("~\invoicesAr\" & "Invoice_" & Session("pid") & ".pdf"), QRToSend, Years, Domains, Session("pid"), Session("clientname"))

                        End If

                    End If
                End If

                reader.Close()
                conn.Close()

            End If
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Sub

    Public Function CalculateFees(ByVal domain_id As Integer) As Integer
        Try
            Dim connectionstr As DAL = New DAL()
            Dim conammount As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
            Dim cmdammount = New SqlCommand()
            Dim ammount As Integer = 0
            conammount.Open()
            cmdammount.Connection = conammount
            cmdammount.CommandText = "calculate_Fees"
            cmdammount.CommandType = CommandType.StoredProcedure
            cmdammount.Parameters.AddWithValue("domain_id", domain_id)
            Dim amountP = cmdammount.Parameters.Add("amount", SqlDbType.Int)
            amountP.Direction = ParameterDirection.ReturnValue
            totalvalue = Convert.ToInt32(cmdammount.ExecuteScalar())
            ammount += Convert.ToInt32(amountP.Value)
            conammount.Close()
            Return ammount
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Function
    Public Function GetInvoiceLines(ByVal Years As String(), ByVal Domains As String(), ByVal CCount As Integer, ByVal DomainsID As Integer()) As String
        Dim InvoiceLine As String = "" 'ROUND ((quantity * unitPrice - discount) + TaxAmount; 9)
        Dim totroundamm As Integer = 0
        Dim totalLine As Integer = 0
        For i = 0 To CCount - 1
            totalLine = totalLine + Math.Round(CalculateFees(DomainsID(i)) - 0, 9)
            totroundamm = totroundamm + Math.Round(Years(i) * CalculateFees(DomainsID(i)), 9)
            InvoiceLine = InvoiceLine & "<cac:InvoiceLine>
											<cbc:ID>" & i & "</cbc:ID>
											<cbc:InvoicedQuantity unitCode='PCE'>" & Years(i) & "</cbc:InvoicedQuantity>
											<cbc:LineExtensionAmount currencyID='JO'>" & Math.Round(CalculateFees(DomainsID(i)) - 0, 9) & "</cbc:LineExtensionAmount>
											<cac:TaxTotal>
												<cbc:TaxAmount currencyID='JO'>0.00</cbc:TaxAmount>
												<cbc:RoundingAmount currencyID='JO'>" & Math.Round(Years(i) * CalculateFees(DomainsID(i)), 9) & "</cbc:RoundingAmount>
												<cac:TaxSubtotal>
													<cbc:TaxAmount currencyID='JO'>0.00</cbc:TaxAmount>
													<cac:TaxCategory>
														<cbc:ID schemeAgencyID='6' schemeID='UN/ECE 5305'>O</cbc:ID>
														<cbc:Percent>0</cbc:Percent>
														<cac:TaxScheme>
															<cbc:ID schemeAgencyID='6' schemeID='UN/ECE 5153'>VAT</cbc:ID>
														</cac:TaxScheme>
													</cac:TaxCategory>
												</cac:TaxSubtotal>
											</cac:TaxTotal>
											<cac:Item>
												<cbc:Name>" & Domains(i) & "</cbc:Name>
											</cac:Item>
											<cac:Price>
												<cbc:PriceAmount currencyID='JO'>" & CalculateFees(DomainsID(i)) & "</cbc:PriceAmount>
												<cac:AllowanceCharge>
													<cbc:ChargeIndicator>false</cbc:ChargeIndicator>
													<cbc:AllowanceChargeReason>DISCOUNT</cbc:AllowanceChargeReason>
													<cbc:Amount currencyID='JO'>0</cbc:Amount>
												</cac:AllowanceCharge>
											</cac:Price>
										</cac:InvoiceLine>"
        Next
        Session("LineExtensionAmount") = totalLine
        Session("RoundingAmount") = totroundamm
        Return InvoiceLine
    End Function
    Public Function GenerateUBLInvoiceXml() As String
        Try
            Dim guid As Guid = Guid.NewGuid()
            Dim uniqueId As Integer = guid.GetHashCode()
            Dim issueDate As String = CDate(Session("ddate")).ToString("yyyy-MM-dd")
            Dim XML As String = "<?xml version='1.0' encoding='UTF-8'?><Invoice xmlns='urn:oasis:names:specification:ubl:schema:xsd:Invoice-2' xmlns:cac='urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2'	xmlns:cbc = 'urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2'	xmlns:ext='urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2'>
	<cbc:ProfileID>reporting:1.0</cbc:ProfileID>
	<cbc:ID>" & uniqueId & "</cbc:ID>
	<cbc:UUID>" & "DomainName" & Session("pid") & "</cbc:UUID>
	<cbc:IssueDate>" & issueDate & "</cbc:IssueDate>
	<cbc:InvoiceTypeCode name='022'>388</cbc:InvoiceTypeCode>
	<cbc:Note>DNS Payment Invocie</cbc:Note>
	<cbc:DocumentCurrencyCode>JOD</cbc:DocumentCurrencyCode>
	<cbc:TaxCurrencyCode>JOD</cbc:TaxCurrencyCode>
	<cac:AdditionalDocumentReference>
		<cbc:ID>ICV</cbc:ID>
		<cbc:UUID>1</cbc:UUID>
	</cac:AdditionalDocumentReference>
	<cac:AccountingSupplierParty>
		<cac:Party>
			<cac:PostalAddress>
				<cac:Country>
					<cbc:IdentificationCode>JO</cbc:IdentificationCode>
				</cac:Country>
			</cac:PostalAddress>
			<cac:PartyTaxScheme>
				<cbc:CompanyID>17027748</cbc:CompanyID>
				<cac:TaxScheme>
					<cbc:ID>VAT</cbc:ID>
				</cac:TaxScheme>
			</cac:PartyTaxScheme>
			<cac:PartyLegalEntity>
				<cbc:RegistrationName>وزارة الإقتصاد الرقمي والريادة</cbc:RegistrationName>
			</cac:PartyLegalEntity>
		</cac:Party>
	</cac:AccountingSupplierParty>
	<cac:AccountingCustomerParty>
		<cac:Party>
			<cac:PartyIdentification>
				<cbc:ID schemeID='TN'></cbc:ID>
			</cac:PartyIdentification>
			<cac:PostalAddress>
				<cbc:PostalZone></cbc:PostalZone>
				<cbc:CountrySubentityCode></cbc:CountrySubentityCode>
				<cac:Country>
					<cbc:IdentificationCode>JO</cbc:IdentificationCode>
				</cac:Country>
			</cac:PostalAddress>
			<cac:PartyTaxScheme>
				<cbc:CompanyID></cbc:CompanyID>
				<cac:TaxScheme>
					<cbc:ID>VAT</cbc:ID>
				</cac:TaxScheme>
			</cac:PartyTaxScheme>
			<cac:PartyLegalEntity>
				<cbc:RegistrationName>" & Session("COMPANY_USER_NAME") & "</cbc:RegistrationName>
			</cac:PartyLegalEntity>
		</cac:Party>
		<cac:AccountingContact>
			<cbc:Telephone></cbc:Telephone>
		</cac:AccountingContact>
	</cac:AccountingCustomerParty>
	<cac:SellerSupplierParty>
		<cac:Party>
			<cac:PartyIdentification>
				<cbc:ID>1385941</cbc:ID>
			</cac:PartyIdentification>
		</cac:Party>
	</cac:SellerSupplierParty>
	<cac:AllowanceCharge>
		<cbc:ChargeIndicator>false</cbc:ChargeIndicator>
		<cbc:AllowanceChargeReason>discount</cbc:AllowanceChargeReason>
		<cbc:Amount currencyID='JO'>0</cbc:Amount>
	</cac:AllowanceCharge>
	<cac:TaxTotal>
		<cbc:TaxAmount currencyID='JO'>0</cbc:TaxAmount>
	</cac:TaxTotal>
	<cac:LegalMonetaryTotal>
		<cbc:TaxExclusiveAmount currencyID='JO'>" & Session("LineExtensionAmount") & "</cbc:TaxExclusiveAmount>
		<cbc:TaxInclusiveAmount currencyID='JO'>" & Session("RoundingAmount") & "</cbc:TaxInclusiveAmount>
		<cbc:AllowanceTotalAmount currencyID='JO'>0.00</cbc:AllowanceTotalAmount>
		<cbc:PayableAmount currencyID='JO'>" & Session("RoundingAmount") & "</cbc:PayableAmount>
	</cac:LegalMonetaryTotal>" & Session("InvoiceLine") & "</Invoice>"
            Dim ByteValue As Byte() = System.Text.Encoding.UTF8.GetBytes(XML)
            Dim Base64String As String = Convert.ToBase64String(ByteValue)
            Return Base64String
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Function

    Function GenerateQR(ByVal QRText As String) As String
        Try
            Dim lang As New Languages("en")
            Dim client = New RestSharp.RestClient("https://backend.jofotara.gov.jo/core/invoices/")
            Dim request As New RestSharp.RestRequest(Method.POST)
            request.AddHeader("Client-Id", lang.invoiceClientID)
            request.AddHeader("Secret-Key", lang.invoiceSecretKey)
            request.AddHeader("Content-Type", "application/json")
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

            ' Add JSON body correctly
            request.AddJsonBody(New With {.invoice = QRText})

            ' Send request
            Dim response As IRestResponse = client.Execute(request)
            Dim root As Root = JsonConvert.DeserializeObject(Of Root)(response.Content)
            If root IsNot Nothing AndAlso root.EINV_STATUS = "SUBMITTED" Then
                Return root.EINV_QR
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function

    Public Function ExtractInvoiceAsPDF(ByVal Client_Number As Integer, ByVal logoMoOEE As String, ByVal ampaid As String, ByVal FilePath As String, ByVal QRData As String, ByVal Years() As String, ByVal Domains() As String, ByVal pid As String, ByVal clientname As String) As String
        Try
            Dim lang As New Languages(Session("lang"))
            Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(QRData, QRCodeGenerator.ECCLevel.Q)
            Dim qrCodeValue As QRCoder.QRCode = New QRCoder.QRCode(qrCodeData)
            If Session("lang") = "en" Then
                logoMoOEE = Server.MapPath("~/modeelogoen.png")
            Else
                logoMoOEE = Server.MapPath("~/MoDEE.png")
            End If
            Using qrCodeImage As Bitmap = qrCodeValue.GetGraphic(2)

                Using ms As MemoryStream = New MemoryStream()
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim byteImage As Byte() = ms.ToArray()
                    Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                    img.Save(Server.MapPath("Images/") & "QRest_" & Client_Number & Session("pid") & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                    'Image1.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
                End Using
            End Using

            Dim msg As String = ""
            Dim ppt As Presentation = New Presentation()
            Dim pptSlide As ISlide = ppt.Slides(0)
            Dim rect As RectangleF = New RectangleF(0, 0, ppt.SlideSize.Size.Width, ppt.SlideSize.Size.Height)
            ' Desired image size
            Dim imageWidth As Single = 139
            Dim imageHeight As Single = 100

            ' Calculate centered X position
            Dim centerX As Single = (ppt.SlideSize.Size.Width - imageWidth) / 2
            Dim posY As Single = 40 ' Y position from top

            ' Add image centered horizontally
            Dim imageShapeLogo1 As IEmbedImage = pptSlide.Shapes.AppendEmbedImage(ShapeType.Rectangle, logoMoOEE, New RectangleF(centerX, posY, imageWidth, imageHeight))

            ' Remove border line
            imageShapeLogo1.Line.FillFormat.FillType = FillFormatType.None


            imageShapeLogo1.Width = 150 ' New width
            imageShapeLogo1.Height = 80 ' New height
            Dim imageWidth1 As Single = 139
            Dim imageHeight2 As Single = 100
            ' ===== Page 2 (Slide 2) =====


            ' Set left X position
            Dim leftX As Single = 40
            Dim posY2 As Single = 40 '
            'Y position from top

            ' Add image aligned to left
            Dim QR As IEmbedImage = pptSlide.Shapes.AppendEmbedImage(ShapeType.Rectangle, Server.MapPath("Images/") & "QRest_" & Client_Number & Session("pid") & ".bmp", New RectangleF(leftX, posY2, imageWidth1, imageHeight2))
            Dim imageWidth_1 As Single = 400
            Dim imageHeight_1 As Single
            Dim rrowcount As Integer = GetRowsCount(pid)
            If Session("lang") = "en" Then
                If (rrowcount = 1) Then
                    imageHeight_1 = 70
                ElseIf (rrowcount <= 4) Then
                    imageHeight_1 = 100
                ElseIf (rrowcount > 20) Then
                    imageHeight_1 = 500
                ElseIf (rrowcount > 10) Then
                    imageHeight_1 = 200
                ElseIf (rrowcount > 4) Then
                    imageHeight_1 = 300
                End If
            Else
                If (rrowcount = 1) Then
                    imageHeight_1 = 70
                ElseIf (rrowcount <= 4) Then
                    imageHeight_1 = 100
                ElseIf (rrowcount > 20) Then
                    imageHeight_1 = 500
                ElseIf (rrowcount > 10) Then
                    imageHeight_1 = 200
                ElseIf (rrowcount > 4) Then
                    imageHeight_1 = 300
                End If
            End If
            Dim centerX1 As Single
            Dim posY1 As Single
            If rrowcount > 4 Then

                Dim slide2 As ISlide = ppt.Slides.Append()
                ' Add image aligned to left
                centerX1 = (ppt.SlideSize.Size.Width - imageWidth) / 2
                posY1 = 40 ' Y position from top
                Dim grid As IEmbedImage = slide2.Shapes.AppendEmbedImage(ShapeType.Rectangle, FillDomains(Convert.ToInt32(pid)), New RectangleF(centerX1, posY1, imageWidth_1, imageHeight_1))
            Else
                Dim leftX1 As Single = 300
                Dim posY21 As Single = 400

                Dim grid As IEmbedImage = pptSlide.Shapes.AppendEmbedImage(ShapeType.Rectangle, FillDomains(Convert.ToInt32(pid)), New RectangleF(leftX1, posY21, imageWidth_1, imageHeight_1))


            End If
            ' Set left X position

            ' Remove border line
            QR.Line.FillFormat.FillType = FillFormatType.None
            Dim rect2 As RectangleF = New RectangleF(40, 159, ppt.SlideSize.Size.Width - 80, 380)
            Dim shapePanel As IAutoShape = pptSlide.Shapes.AppendRoundRectangle(40, 139, ppt.SlideSize.Size.Width - 80, 380, 12)
            shapePanel.Fill.FillType = FillFormatType.Solid
            shapePanel.Fill.SolidColor.Color = Color.Transparent
            shapePanel.Line.FillType = FillFormatType.None
            Dim widths As Double() = {
        (2 * shapePanel.Width - 80) / 5,  ' Column 1 width
        (3 * shapePanel.Width - 120) / 5  ' Column 2 width
    }

            ' Define 10 rows with equal height (30 units each)
            Dim heights As Double() = {
        30, 30, 30, 30, 30,  ' First 5 rows
        30   ' Last 5 rows
    }

            ' Create the table on the slide
            Dim table As ITable = pptSlide.Shapes.AppendTable(
        shapePanel.Left + 20,  ' X position
        shapePanel.Top + 20,   ' Y position
        widths,               ' Column widths
        heights               ' Row heights
    )
            table.SetTableBorder(TableBorderType.None, 0, Color.White)
            table.StylePreset = TableStylePreset.None
            Dim dataStr As String(,)
            If Session("lang") = "ar" Then
                Dim tableFont As TextFont = New TextFont("Arial")
                dataStr = New String(,) {
        {Client_Number & "  :", lang.ClientNO.Replace(":", "")},
        {clientname & "  :", lang.Client_Name},
        {pid & "  :", lang.InvoiceNO},
        {"   " & "دينار اردني   " & "   " & ampaid & "   " & "  :", "  " & lang.totalAmm.Replace(":", "") & "  "}}


                For i As Integer = 0 To 4 - 1
                    For j As Integer = 0 To 2 - 1
                        table(j, i).TextFrame.Text = dataStr(i, j)
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).LatinFont = tableFont
                        table(j, i).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Right
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).FontHeight = 13
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).Fill.SolidColor.Color = Color.FromArgb(1, 99, 99, 99)
                        table(j, i).TextFrame.Paragraphs(0).RightToLeft = True
                        table(1, j).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Right
                        table(0, i).TextFrame.Paragraphs(0).TextRanges(0).IsBold = TriState.[True]
                        table(0, i).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Right
                    Next
                Next

            Else
                dataStr = New String(,) {
    {lang.ClientNO.Replace(":", "") & ":", Client_Number},
    {lang.Client_Name & ":", clientname},
    {lang.InvoiceNO & ":", pid},
    {lang.totalAmm.Replace(":", "") & ":", ampaid + "  JD"}}

                Dim tableFont As TextFont = New TextFont("Calibri")
                For i As Integer = 0 To dataStr.GetLength(0) - 1
                    For j As Integer = 0 To 2 - 1
                        table(j, i).TextFrame.Text = dataStr(i, j)
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).LatinFont = tableFont
                        table(j, i).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Left
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).FontHeight = 16
                        table(j, i).TextFrame.Paragraphs(0).TextRanges(0).Fill.SolidColor.Color = Color.FromArgb(1, 99, 99, 99)
                        table(j, i).TextFrame.Paragraphs(0).RightToLeft = False
                        table(1, j).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Left
                        table(0, i).TextFrame.Paragraphs(0).TextRanges(0).IsBold = TriState.[True]
                        table(0, j).TextFrame.Paragraphs(0).Alignment = TextAlignmentType.Left
                    Next
                Next




            End If




            Dim charsToTrim As Char() = {":"c, " "c, "/"c}
            Dim now As String = DateTime.Now.ToString().Trim()
            Dim nowDate As String = now.Replace(":", "").Replace("/", "").Replace(" ", "")

            Try
                If Not File.Exists(FilePath) Then
                    ppt.SaveToFile(FilePath, FileFormat.PDF)
                    If Session("lang") = "en" Then
                        Dim filetoOpen As String = "..\\invoices\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    Else
                        Dim filetoOpen As String = "..\\invoicesAr\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    End If


                Else
                    If Session("lang") = "en" Then
                        Dim filetoOpen As String = "..\\invoices\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    Else
                        Dim filetoOpen As String = "..\\invoicesAr\\" & "Invoice_" & Session("pid") & ".pdf"
                        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" & filetoOpen & "');", True)
                    End If

                End If
            Catch ex As Exception
                Return ex.Message
            End Try

            Return msg
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
                File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
            End If
        End Try
    End Function


    Public Function FillDomains(ByVal pid As Integer) As String
        Try
            Dim lang As Languages = New Languages(Session("lang"))
            Dim connectionstr As DAL = New DAL()
            Dim query As String = "efawatercomInvoicesdetForarray"
            Dim invoiceNumber As String = pid
            Dim dt As New DataTable()

            Using conn As New SqlClient.SqlConnection(ReusableCode.Decrypt(connectionstr.Connection))
                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@invoice_settingID", invoiceNumber)
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dt.Columns(0).ColumnName = lang.DomainName
            dt.Columns(1).ColumnName = lang.years

            Dim bmp As Bitmap = New Bitmap(500, 700)
            bmp = DataTableToImage(dt)

            bmp.Save(Server.MapPath("Images/") & "grid_" & pid & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)


            Return Server.MapPath("Images/") & "grid_" & pid & ".bmp"
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Function
    Public Function DataTableToImage(ByVal table As DataTable) As Bitmap
        Try

            Dim font As Font = New Font("Arial", 14, FontStyle.Bold)
            Dim padding As Integer = 10
            Dim rowHeight As Integer = CInt((font.Height * 1.5))
            Dim colCount As Integer = table.Columns.Count
            Dim rowCount As Integer = table.Rows.Count + 1
            Dim colWidths As Integer() = New Integer(colCount - 1) {}

            Using g As Graphics = Graphics.FromImage(New Bitmap(1, 1))

                For i As Integer = 0 To colCount - 1
                    Dim maxWidth As Integer = 300
                    Dim width1 As Integer = 0
                    For Each row As DataRow In table.Rows
                        width1 = CInt(g.MeasureString(row(i).ToString(), font).Width)
                        If width1 > maxWidth Then maxWidth = width1
                    Next

                    colWidths(i) = maxWidth + padding * 2
                Next
            End Using

            Dim width As Integer = 0

            For Each w As Integer In colWidths
                width += w
            Next

            Dim height As Integer = rowHeight * rowCount
            Dim bmp As Bitmap = New Bitmap(width, height)

            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
                Dim pen As Pen = New Pen(Color.Black)
                Dim y As Integer = 0
                Dim x As Integer = 0

                For i As Integer = 0 To colCount - 1
                    g.FillRectangle(Brushes.LightGray, x, y, colWidths(i), rowHeight)
                    g.DrawRectangle(pen, x, y, colWidths(i), rowHeight)
                    g.DrawString(table.Columns(i).ColumnName, font, Brushes.Black, x + padding, y + padding / 2)
                    x += colWidths(i)
                Next

                y += rowHeight

                For Each row As DataRow In table.Rows
                    x = 0

                    For i As Integer = 0 To colCount - 1
                        g.DrawRectangle(pen, x, y, colWidths(i), rowHeight)
                        g.DrawString(row(i).ToString(), font, Brushes.Black, x + padding, y + padding / 2)
                        x += colWidths(i)
                    Next

                    y += rowHeight
                Next
            End Using

            Return bmp
        Catch ex As Exception
            If Not (TypeOf ex Is ThreadAbortException) Then
            File.AppendAllText(Server.MapPath("ErrorLog\ErrorLog.txt"), Environment.NewLine & "Users\report_invoice:" + ex.Message + ex.StackTrace & " " + DateTime.Now)
        End If
        End Try
    End Function


End Class