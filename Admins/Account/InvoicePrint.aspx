<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoicePrint.aspx.vb" Inherits="Domain2021.InvoicePrint" ViewStateEncryptionMode="Always" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="apple-touch-icon" href="../images/apple-touch-icon.html"/>
    <link rel="shortcut icon" type="image/ico" href="../images/favicon.html" />

    <link rel="stylesheet" href="../css/bootstrap.min.css"/>

    <link href="../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <link href="../css/matrialize.css" rel="stylesheet" />

    <link href="../owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="../css/jquery-ui.min.css"/>

    <link rel="stylesheet" href="../css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="css\css2.css" rel="stylesheet" />
    <script src="js/4n2NXumNjtg5LPp6VXLlDicTUfA.js"></script>
    <link rel="apple-touch-icon" href="../images/apple-touch-icon.html" />
    <link rel="shortcut icon" type="image/ico" href="../images/favicon.html" />

    <link href='ccss\ss.css' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />

    <link href="font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="../css/matrialize.css" rel="stylesheet" />

    <link href="../owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width:100%;
            align-content:center;
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
           border-color:#cccccc;
        
        }
     
        .auto-style3 {
            text-align: center;
        }
        .auto-style5 {
            text-align: center;
        }
             
        .auto-style7 {
            font-weight: bold;
        }
        .auto-style8 {
            text-align: center;
            font-weight: bold;
        }
     
    </style>
</head>
<body  onload="window.print();">
    <form id="form1" runat="server"><br />
    <div id="div1" runat="server" style="font-family:cairo;text-align:center">
    
        <table align="center" cellpadding="0" class="auto-style1" id="tab1" runat="server">
            <tr>
                <td colspan="2" align="center">
                    <img alt=""  src="../../imags/logo-en.png" style="text-align: center;" /><hr style="color:#cccccc" /></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <b>
                    <asp:Label ID="ClientName" runat="server"></asp:Label>
                    <asp:Label ID="ClientName0" runat="server"></asp:Label>
                    </b>
                </td>
                <td class="auto-style5">
                    <b>
                    <asp:Label ID="date0" runat="server"></asp:Label>
                    <asp:Label ID="date1" runat="server"></asp:Label>
                    </b>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <b>
                    <br />
                                    </b>
                                    <div class="text-align-center">
                                    <asp:DataGrid ID="DataGrid2" CssClass="table table-bordered" GridLines="Both" runat="server" AutoGenerateColumns="False" BorderColor="#cccccc" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Overline="False"  Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" ShowFooter="false" DataSourceID="SqlDataSource2" Font-Names="cairo">
                                        <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                        <Columns>
                                             <asp:BoundColumn DataField="domainName"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="years"></asp:BoundColumn>
                                          
                                            
                                        </Columns>
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                    </asp:DataGrid>
                                    </div>
                                    <b>
                                    <br />
                    </b>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" >
                    <b>
                    <asp:Label ID="TotAm1" runat="server"></asp:Label>
                    <asp:Label ID="TotAm" runat="server"></asp:Label>
                    <asp:Label ID="TotAm0" runat="server" style="color: #CC0000"></asp:Label>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>" SelectCommand="efawatercomInvoicesdet" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="invoice_settingID" SessionField="pid" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    </td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2"><hr />
                    <strong style="font-family:cairo">وزارة الاقتصاد الرقمي والريادة :: :: Ministry of Digital Economy And Entrepreneurship<br />
                    Tel: 00962 6 53003622&nbsp; Fax: 00962 6 5300277<br />
                    </strong>
                    <a href="http://www.modee.gov.jo" target="_blank"><strong>www.modee.gov.jo</strong></a> </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

