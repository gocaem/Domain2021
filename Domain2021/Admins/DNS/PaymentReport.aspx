<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="PaymentReport.aspx.vb" Inherits="Domain2021.PaymentReport" ViewStateEncryptionMode="Always" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

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
                                                            <img src="../app-assets/3MODEE-news-0.png" alt="branding logo"></div>
                                                    </div>
                                                </div>
                                                <div class="card-body collapse in">
                                                    <div class="card-block card-dashboard">
                                                        <p class="card-text text-bold-900" style="font-size: 16px">Manage Users available in the system</p>
                                                        <div class="table-responsive">

                                                            <table id="table4" class="table">
                                                                <tr>
                                                                    <td align="left" class="auto-style10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">
                                                                        <p>Domain Name: &nbsp;<asp:TextBox ID="txt_domain_name" Width="50%" CssClass="form-control" runat="server" Style="margin-bottom: 0px"></asp:TextBox></p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">

                                                                        <p style="width: 683px">
                                                                            From Date:
                                                                                            <asp:TextBox ID="RadDatePicker1" runat="server" TextMode="Date"></asp:TextBox>
                                             
                                                                        </p>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">

                                                                        <p style="width: 683px">
                                                                            To Date:
                                                                               <asp:TextBox ID="RadDatePicker2" runat="server" TextMode="Date"></asp:TextBox>
                                             
                                              
                                                                        </p>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="auto-style10">
                                                                        <asp:Button ID="ButtonID" runat="server" Text="Search" OnClick="ButtonID_Click" CssClass="btn btn-info"></asp:Button>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td>
                                                                        <asp:HyperLink ID="hl_printer" runat="server" ImageUrl="../images/print.jpg" Target="_blank"
                                                                            Visible="False"></asp:HyperLink></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_hedar" runat="server" Font-Bold="True"></asp:Label></td>
                                                                </tr>
                                                            </table>

                                                            <asp:DataGrid ID="DataGrid1" HeaderStyle-HorizontalAlign="Center" AutoGenerateColumns="false" CssClass="table" Width="100%" runat="server" Style="font-family: Calibri; font-weight: normal">
                                                                <AlternatingItemStyle />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="Number">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label63" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:BoundColumn DataField="ProcessDate" HeaderText="Transaction Date"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="SettingID"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Transaction No" HeaderText="Transaction No"></asp:BoundColumn>
                                                                     <asp:BoundColumn DataField="Client_ID" Visible="false" ></asp:BoundColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton6" runat="server" CommandName="det" Height="25px" ImageUrl="~/Admins/det.png" Width="25px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton7" runat="server" CommandName="print" ImageUrl="~/Admins/dribble-printer.jpg" Width="35px" ClientIDMode="Static" OnClientClick="javascript:return OpenBlank();" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <HeaderStyle BackColor="#4086A0" Width="100%" ForeColor="White" />
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                            </asp:DataGrid>


                                                            <asp:Label ID="Label64" runat="server" Visible="False"></asp:Label>
                                                            <asp:Panel ID="Panel1" runat="server" Visible="False" >
                                                                <table cellpadding="0" class="table" style="align-content:center" id="tab1" runat="server" dir="rtl">
                                                                    <tr>
                                                                        <td >
                                                                            <asp:Label ID="DDate" runat="server">  </asp:Label>
                                                                            
                                                                      
                                                                            <asp:Label ID="Label68" runat="server"  ></asp:Label>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <caption>
                                                                        <br />

                                                                        <tr>
                                                                            <td class="auto-style9" colspan="2">.<asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="69px" HorizontalAlign="Center" ShowFooter="True" Width="360px">
                                                                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="domainName" HeaderText="اسم النطاق"></asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="years" HeaderText="عدد السنوات"></asp:BoundColumn>
                                                                                </Columns>
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                            </asp:DataGrid>
                                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>" SelectCommand="efawatercomInvoicesdet" SelectCommandType="StoredProcedure">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="Label64" Name="invoice_settingID" PropertyName="Text" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td >
                                                                                <asp:Label ID="AAmount" runat="server" ></asp:Label>
                                                                          
                                                                                <asp:Label ID="Label65" runat="server" ForeColor="Red" ></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                   
                                                                    </caption>
                                                                </table>
                                                            </asp:Panel>




                                                        </div>




                                                        <div class="card-footer">
                                                            <div class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                    </section>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="select_users" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>

            <br />
            </div>




                                                <div class="card-footer">
                                                    <div class="">
                                                    </div>
                                                </div>
            </div>
                                        </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

 
    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>

    <script language="javascript" type="text/javascript">
        function OpenBlank() {
            debugger;
            this.Form.Target = "_blank";
            return true;
           
        }
        function Notify(msg, title, type, clear, pos, sticky) {



            if (clear == true) {
                toastr.clear();
            }
            if (sticky == true) {
                toastr.tapToDismiss = true;
                toastr.timeOut = 10000;
            }

            toastr.options.onclick = function () {
                //alert('You can perform some custom action after a toast goes away');
            }
            //"toast-top-left";
            toastr.options.positionClass = pos;
            if (type.toLowerCase() == 'info') {
                toastr.options.timeOut = 1000;
                toastr.tapToDismiss = true;
                toastr.info(msg, title);
            }
            if (type.toLowerCase() == 'success') {
                toastr.options.timeOut = 1500;
                toastr.success(msg, title);
            }
            if (type.toLowerCase() == 'warning') {
                toastr.options.timeOut = 3000;
                toastr.warning(msg, title);
            }
            if (type.toLowerCase() == 'error') {
                toastr.options.timeOut = 10000;
                toastr.error(msg, title);
            }
        }
    </script>
</asp:Content>
