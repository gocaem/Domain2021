<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Unused.aspx.vb" Inherits="Domain2021.Unused" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div>
                          <script>
                              $(document).ready(function () {
                                  var collapse = document.getElementById("manage")
                                  collapse.className = "sidebar-submenu menu-open";
                                  collapse.style.display = "block";

                              });
                          </script>
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
                                                
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri"><p class="card-text" style="font-size: 22px"><b>Unused Admin</b> </p>
                                                        <asp:Button ID="Button0" runat="server" Text="delete all admins" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button0_Click"></asp:Button>

                                                        <asp:GridView Visible="true" DataKeyNames="Admin_id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("Admin_id") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Admin_id" DataField="Admin_id" SortExpression="Admin_id"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Company_user_name" DataField="COMPANY_USER_NAME" SortExpression="Admin_id"></asp:BoundField>
                                                                <asp:BoundField HeaderText="ADMIN_CONTACT" DataField="ADMIN_CONTACT" SortExpression="Admin_id"></asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="unused_admins" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                        <br />
                                                        <p class="card-text" style="font-size: 22px"><b>Unused Billing</b> </p>
                                                        <div class="table-responsive">
                                                            <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                <asp:Button ID="Button1" runat="server" Text="delete all Billing" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button1_Click"></asp:Button>

                                                                <asp:GridView Visible="true" DataKeyNames="id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView1" CssClass="table table-responsive" DataSourceID="SqlDataSource1" runat="server" OnRowCommand="GridView1_RowCommand">

                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="id" DataField="id" SortExpression="id"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" SortExpression="id"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="BILLING_CONTACT" DataField="BILLING_CONTACT" SortExpression="id"></asp:BoundField>

                                                                    </Columns>
                                                                </asp:GridView>

                                                                <p class="card-text" style="font-size: 22px"><b>Unused Technical</b> </p>
                                                                <div class="table-responsive">
                                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                        <asp:Button ID="Button2" runat="server" Text="delete all Technical" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button2_Click"></asp:Button>

                                                                        <asp:GridView Visible="true" DataKeyNames="id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView3" CssClass="table table-responsive" DataSourceID="SqlDataSource2" runat="server" OnRowCommand="GridView3_RowCommand">

                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="id" DataField="id" SortExpression="id"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" SortExpression="id"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="Tech_CONTACT" DataField="Tech_CONTACT" SortExpression="id"></asp:BoundField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="unused_billing" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="unused_tech" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                        <div class="card-footer">
                                                                            <div class="">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <p class="card-text" style="font-size: 22px"><b>Unused name servers</b> </p>
                                                                <div class="table-responsive">
                                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                        <asp:Button ID="Button4" runat="server" Text="delete all servers" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button4_Click"></asp:Button>

                                                                        <asp:GridView Visible="true" DataKeyNames="id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView4" CssClass="table table-responsive" DataSourceID="SqlDataSource3" runat="server" OnRowCommand="GridView4_RowCommand">

                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="id" DataField="id" SortExpression="id"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="P_SERVER_NAME" DataField="P_SERVER_NAME" SortExpression="id"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="S_SERVER_NAME" DataField="S_SERVER_NAME" SortExpression="id"></asp:BoundField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="unused_NAME_SERVER_ID" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                                        <div class="card-footer">
                                                                            <div class="">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <p class="card-text" style="font-size:22px">Open  invoices </p>
                                                                <div class="table-responsive">
                                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                        <asp:Button ID="Button5" runat="server" Text="delete all open invoices" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button5_Click"></asp:Button>

                                                                        <asp:GridView Visible="true" DataKeyNames="InvoiceSettings_ID" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView5" CssClass="table table-responsive" DataSourceID="SqlDataSource4" runat="server" OnRowCommand="GridView5_RowCommand">

                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="id" DataField="InvoiceSettings_ID" SortExpression="InvoiceSettings_ID"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="Date" DataField="Date" SortExpression="InvoiceSettings_ID"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="Admin_ID" DataField="Admin_ID" SortExpression="InvoiceSettings_ID"></asp:BoundField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="open_invoices" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

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
                <div class="container">
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView2" />
            <asp:PostBackTrigger ControlID="GridView3" />
            <asp:PostBackTrigger ControlID="GridView4" />
            <asp:PostBackTrigger ControlID="GridView5" />
            <asp:PostBackTrigger ControlID="GridView1" />
            <asp:PostBackTrigger ControlID="Button2" />
            <asp:PostBackTrigger ControlID="Button1" />
            <asp:PostBackTrigger ControlID="Button0" />
            <asp:PostBackTrigger ControlID="Button5" />
            <asp:PostBackTrigger ControlID="Button4" />
        </Triggers>
    </asp:UpdatePanel>

    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js" defer async
        type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
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
