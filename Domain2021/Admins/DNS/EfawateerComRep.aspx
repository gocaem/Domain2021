<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="EfawateerComRep.aspx.vb" Inherits="Domain2021.EfawateerComRep" ViewStateEncryptionMode="Always" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script>
           $(document).ready(function () {
                var collapse = document.getElementById("report")
                collapse.className = "sidebar-submenu menu-open";
                collapse.style.display = "block";

            });
 </script>
    <script>
        $(function () { $("#RadDatePicker2").datepicker({ dateFormat: "dd-MM-yyyy" }); });
    </script>
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div>
                <div class="app-content content container-fluid">
                    <div class="content-wrapper">
                        <div class="content-header row">
                        </div>
                        <div class="content-body">
                            <section class="flexbox-container">
                                <div class="col-md-8 offset-md-2 col-xs-10 offset-xs-1  box-shadow-2 p-0">
                                    <div class="card border-grey border-lighten-10 m-0">
                                        <div class="card-header no-border">
                                            <div class="card-title text-xs-center">
                                                <div class="p-1">
                                                    <img src="../app-assets/3MODEE-news-0.png" alt="branding logo">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body collapse in">
                                            <div class="card-block card-dashboard">
                                                <p class="card-text text-bold-900" style="font-size: 16px">eFAWATEERcom Report</p>
                                                <div class="table-responsive">
                                                    <table id="table4" class="table">

                                                        <tr>
                                                            <td>
                                                                <p>Domain Name: &nbsp;<asp:TextBox ID="txt_domain_name" runat="server" Style="margin-bottom: 0px"></asp:TextBox></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style10">

                                                                <p style="width: 683px">
                                                                    From Date:
                                                                     <asp:TextBox ID="RadDatePicker1" runat="server" TextMode="Date" ></asp:TextBox>
                                                                 
                                                                                  </p>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>

                                                                <p style="width: 683px">
                                                                    To Date:
                                                                     <asp:TextBox ID="RadDatePicker2" runat="server" TextMode="Date" ClientIDMode="Static" ></asp:TextBox>
                                                                 
                                                           
                                                                </p>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">   <asp:LinkButton ID="exportExcel" runat="server" CssClass="btn btn-success" OnClick="exportExcel_Click" ClientIDMode="Static">Excel<i class="fa fa-download"></i></asp:LinkButton>
                                                            
                                                                <asp:LinkButton ID="LButtonID" runat="server" CssClass="btn btn-info" OnClick="LButtonID_Click" ><i class="fa fa-search-minus"></i> Search</asp:LinkButton>
                                                                <asp:LinkButton ID="Printit" runat="server" CssClass="btn btn-warning" OnClick="Printit_Click" ><i class="fa fa-print"></i> Print Report</asp:LinkButton>
                                                               
                                                                  <br /> <br /> <br /><asp:Label ID="amountL" runat="server" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                         
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="auto-style10">
                                                                <asp:HyperLink ID="hl_printer" runat="server" ImageUrl="~/Admins/dribble-printer.jpg" Target="_blank"
                                                                    Visible="False"></asp:HyperLink></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style10">
                                                                <asp:Label ID="lbl_hedar" runat="server" Font-Bold="True"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style10">
                                                                <asp:GridView ClientIDMode ="Static" ID="GridView1" DataKeyNames="SettingID" CssClass="table table-responsive" GridLines="None" runat="server" ShowFooter="True"  Font-Bold="False"
                                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Names="Calibri" AllowPaging="true"  OnPageIndexChanging="OnPageIndexChanging"
                                                                    Font-Underline="False" HorizontalAlign="Center" AutoGenerateColumns="False">
                                                                        <Columns>
                                                                        <asp:TemplateField HeaderText="Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label63" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="ProcessDate" HeaderText="Transaction Date"></asp:BoundField>
                                                                        <asp:BoundField DataField="SettingID"></asp:BoundField>
                                                                         <asp:BoundField DataField="Transaction No" HeaderText="Transaction No"></asp:BoundField>
                                                                         <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>
                                                                         <asp:BoundField DataField="admin_contact" HeaderText="Admin Contact"></asp:BoundField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:Linkbutton ID="ImageButton6" runat="server" CommandArgument='<%# Eval("SettingID") %>' CommandName="det" Height="25px" Width="25px"><i class="fa fa-eye"></i></asp:Linkbutton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="ImageButton7" runat="server" CommandName="print"   CommandArgument='<%# Eval("SettingID") %>'  Width="35px"><i class="fa fa-print"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                             </asp:GridView>
                                                            </td>
                                                            <td>         </td>
                                                            </tr>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>" SelectCommand="efawatercomInvoicesdet" SelectCommandType="StoredProcedure">
                                                                                        <SelectParameters>
                                                                                            <asp:ControlParameter ControlID="Label64" Name="invoice_settingID" PropertyName="Text" Type="Int32" />
                                                                                        </SelectParameters>
                                                                                    </asp:SqlDataSource>
                                                     
                                                        <tr>   
                                                            <td align="center" class="auto-style10">
                                                                <asp:Label ID="Label64" runat="server" Visible="False"></asp:Label>
                                                                <asp:Panel ID="Panel1" runat="server" Visible="False" Width="533px">
                                                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="true" AutoGenerateColumns="False" CssClass="table table-responsive" DataSourceID="SqlDataSource2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="None" Height="69px" HorizontalAlign="Center" ShowFooter="True" Width="360px">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="domainName" HeaderText="اسم النطاق" />
                                                                            <asp:BoundField DataField="years" HeaderText="عدد السنوات" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <table id="tab1" runat="server" cellpadding="0" class="auto-style2" dir="rtl">
                                                                        <tr>
                                                                            <td class="auto-style9">
                                                                                <asp:Label ID="DDate" runat="server" Style="font-weight: 700" Width="110px"></asp:Label>
                                                                                <br />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label68" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <tr>
                                                                                <td class="auto-style9">
                                                                                    <asp:Label ID="AAmount" runat="server" Style="font-weight: 700" Width="120px"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Label65" runat="server" ForeColor="Red" Style="font-weight: 700"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style9">&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style9">&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                        </caption>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                          </tr>  
                                                                        
                                                                 </table></div></section>
                                    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="533px">
                                              <asp:GridView ID="GridView3" ClientIDMode="Static" runat="server" AutoGenerateColumns="true"   Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="69px" HorizontalAlign="Center" ShowFooter="True" Width="360px" CssClass="table table-responsive" GridLines="None" AllowPaging="false">
                                                                                      </asp:GridView>
                                                      </asp:Panel>
        </ContentTemplate>
        <Triggers>
         <asp:PostBackTrigger ControlID="GridView1"  />
         <asp:PostBackTrigger ControlID="GridView2" />
            <asp:PostBackTrigger ControlID="exportExcel" />
            </Triggers>
    </asp:UpdatePanel>


                                <div class="card-footer">
                                    <div class="">
                                    </div>
                                </div>

</asp:Content>