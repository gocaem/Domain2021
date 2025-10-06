<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="invoicedet.aspx.vb" Inherits="Domain2021.invoicedet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" runat="server" style="font-family:cairo;text-align:center">
    <center>
        <table align="center" cellpadding="0" class="auto-style1" id="tab1" runat="server">
            <tr>
                <td colspan="2" align="center">
                    <img alt=""  src="../imags/logo2.png" style="text-align: center;" /><hr style="color:#cccccc" /></td>
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
    
        </table></center>
    
    </div>
</asp:Content>
