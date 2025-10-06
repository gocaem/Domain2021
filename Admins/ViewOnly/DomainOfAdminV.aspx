<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/ViewOnly/SiteOnly.Master" CodeBehind="DomainOfAdminV.aspx.vb" Inherits="Domain2021.DomainOfAdminV" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               <script>
                   $(document).ready(function () {
                       var collapse = document.getElementById("report")
                       collapse.className = "sidebar-submenu menu-open";
                       collapse.style.display = "block";

                   });
               </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Admin info</p>
                                                <div class="table-responsive">
                                                    <p>
                                                        <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="lbl_Result" runat="server" ForeColor="Blue"></asp:Label>
                                                    </p>


                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Admin ID:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox><br />
                                                        Or
                                                         <br />
                                                        Admin name:<asp:TextBox ID="TextBox1" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                        <br />
                                                        Status:
                                                        <asp:DropDownList Font-Bold="true" AutoPostBack="true" DataSourceID="SqlDataSource1" Width="50%" CssClass="form-control form-control-lg input-lg" AppendDataBoundItems="true" ID="Status" Enabled="true" runat="server" DataTextField="Status" DataValueField="ID">
                                                            <asp:ListItem Value="0" Text="-----Select One-----"></asp:ListItem>

                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="StatusLookup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                        <br />
                                                        <asp:Button ID="Button3" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>

                                                        <asp:DataGrid ID="DataGrid1" OnItemCommand="DataGrid1_ItemCommand" runat="server" OnPageIndexChanged="DataGrid1_PageIndexChanged" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="table table-responsive" GridLines="None" AllowPaging="True">
                                                            <Columns>
                                                                <asp:BoundColumn DataField="Serial" HeaderText="No."></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Org_name" HeaderText="Entity Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Owner_name" HeaderText="Owner Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Domain_name" HeaderText="Domain Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk" runat="server" CommandName="view" Text='<%#Eval("Domain_id") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>

                                                            </Columns>
                                                        </asp:DataGrid>

                                                        <asp:DataGrid ID="DataGrid2" OnItemCommand="DataGrid2_ItemCommand" runat="server" OnPageIndexChanged="DataGrid2_PageIndexChanged" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" CssClass="table table-responsive" GridLines="None" AllowPaging="True">
                                                            <Columns>
                                                                <asp:BoundColumn DataField="Serial" HeaderText="No."></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Org_name" HeaderText="Org Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Owner_name" HeaderText="Owner Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Domain_name" HeaderText="Domain Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk2" runat="server" CommandName="view" Text='<%#Eval("Domain_id") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>

                                                            </Columns>
                                                        </asp:DataGrid>

                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                            SelectCommand="domains_per_AdminST" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" Name="admin_id" PropertyName="Text" Type="String" />
                                                            </SelectParameters>
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="status" Name="status" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                            SelectCommand="domains_per_Admin_userST" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="TextBox1" Name="COMPANY_USER_NAME" PropertyName="Text" Type="String" />
                                                            </SelectParameters>
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="status" Name="status" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>

                                                    </div>





                                                </div>

                                                <div class="card-footer">
                                                    <div class="">
                                                        <asp:Button ID="Button1" runat="server" Text="update" CssClass=" form-group btn btn-green" Width="50%" ValidationGroup="A" Visible="false"></asp:Button>

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

            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>

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

