<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="statistics.aspx.vb" Inherits="Domain2021.statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="font-family: Calibri">
        <script>
            $(document).ready(function () {
                var collapse = document.getElementById("report")
                collapse.className = "sidebar-submenu menu-open";
                collapse.style.display = "block";

            });
        </script>
       
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Statistics</p>
                                        <div class="modal-body" style="font-family: Calibri">
                                            Start Date:   
                                             <asp:TextBox ID="RadDatePicker1" runat="server" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ErrorMessage="Required" ID="RequiredFieldValidator2" Font-Bold="true" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="RadDatePicker1"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                            End Date:
                                            <asp:TextBox ID="RadDatePicker2" runat="server" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ErrorMessage="Required" ID="RequiredFieldValidator1" Font-Bold="true" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="RadDatePicker2"></asp:RequiredFieldValidator>
                                            
                                            <hr />
                                            <br />
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Search" CssClass=" form-group btn btn-cyan" Width="50%"></asp:Button>

                                            <br />
                                         
       
                                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">ALL</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server">Summary</asp:LinkButton>
                                            <div class="card-body" id="div11" runat="server" visible="true">
                                                <hr />
                                                <div class="tab-content text-center">
                                                    <p class="card-text text-bold-900 alert alert-warning" style="font-size: 16px">Statistics Details</p>

                                                    <asp:Panel CssClass="tab-pane active" Visible="true" runat="server" ClientIDMode="Static" ID="DomainInfo" role="tabpanel">
                                                        
                                                           <asp:Label ID="Label1" runat="server" Font-Bold="True"
                                                ForeColor="#C00000">New Registration:</asp:Label>
                                                           <asp:Label ID="lbl_new_registration" runat="server" Font-Bold="True"
                                                ForeColor="#C00000"></asp:Label>
                                            <br />
                                                        <asp:DataGrid ID="dg_new_reg"   AllowPaging="true" OnPageIndexChanged="dg_new_reg_PageIndexChanged1" PagerStyle-Mode="NumericPages"   HeaderStyle-BackColor="#ff9900" runat="server" AutoGenerateColumns="False" CellPadding="0" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" CssClass="table table-responsive" GridLines="None">
                                                            <Columns> 
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk1" runat="server" CommandName="view1"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                                  <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                            </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:DataGrid>
                                                        <hr />
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000">Approved </asp:Label>

                                                        <asp:Label ID="lbl_approved" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"></asp:Label><br />


                                                        <asp:DataGrid ID="dg_approved" AllowPaging="true"  OnPageIndexChanged="dg_approved_PageIndexChanged1" PagerStyle-Mode="NumericPages" runat="server"  HeaderStyle-BackColor="#ff9900" AutoGenerateColumns="False" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk2" runat="server" CommandName="view2"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                                 <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                               
                                                            </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:DataGrid><hr>
                                                        <font>
                                                            <asp:Label ID="lbl_online" runat="server" Font-Bold="True"
                                                                ForeColor="Brown">Online</asp:Label></font>
                                                        <asp:Label ID="lbl_online1" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"></asp:Label>
                                                        <br />
                                                        <asp:DataGrid ID="dg_online" runat="server" AllowPaging="true" PagerStyle-Mode="NumericPages"  OnPageIndexChanged="dg_online_PageIndexChanged1" HeaderStyle-BackColor="#ff9900" AutoGenerateColumns="False" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                          <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk3" runat="server" CommandName="view3"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                               <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                            </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:DataGrid><hr>
                                                           <asp:Label ID="Label2" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000">UpDate:</asp:Label>
                                                            <asp:Label ID="lbl_update" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"></asp:Label><br>


                                                      <br />
                                                        <asp:DataGrid ID="dg_update" PagerStyle-Mode="NumericPages" AllowPaging="true" OnPageIndexChanged="dg_update_PageIndexChanged1" HeaderStyle-BackColor="#ff9900" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                              <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk4" runat="server" CommandName="view4"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                                     <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                                </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:DataGrid><hr>
                                                          <asp:Label ID="Label3" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000">Renew:</asp:Label>
                                                      <asp:Label ID="lbl_ReNew" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"></asp:Label>
                                                        <br />

                                                 
                                                        <asp:DataGrid ID="dg_ReNew" AllowPaging="true" PagerStyle-Mode="NumericPages" OnPageIndexChanged="dg_ReNew_PageIndexChanged1" runat="server" AutoGenerateColumns="False"  HeaderStyle-BackColor="#ff9900" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                                  <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk5" runat="server" CommandName="view5"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                                 <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                          
                                                            </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:DataGrid><hr>
                                                        <asp:Label ID="Label10" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"> Cancel</asp:Label>
                                                        <asp:Label ID="lbl_Cancel" runat="server" Font-Bold="True"
                                                            ForeColor="#C00000"></asp:Label><br />

                                                        <asp:DataGrid ID="dg_Cancel" runat="server" AllowPaging="true" PagerStyle-Mode="NumericPages"   OnPageIndexChanged="dg_Cancel_PageIndexChanged1" AutoGenerateColumns="False"  HeaderStyle-BackColor="#ff9900" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                                   <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk6" runat="server" CommandName="view6"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                                </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:DataGrid><hr>


                                                        <asp:Label ID="Label7" runat="server" Font-Bold="True"
                                                            ForeColor="Brown">Admin Refuse</asp:Label>

                                                        <asp:Label ID="lbl_Admin_Refuse" runat="server" Font-Bold="True"
                                                            ForeColor="Brown"></asp:Label><br />

                                                        <asp:DataGrid ID="dg_admin_refuse" runat="server" AllowPaging="true" PagerStyle-Mode="NumericPages" OnPageIndexChanged="dg_admin_refuse_PageIndexChanged1"  HeaderStyle-BackColor="#ff9900" AutoGenerateColumns="False" CssClass="table table-responsive" GridLines="None">
                                                            <Columns>
                                                                        <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk6" runat="server" CommandName="view7"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="OWNER_NAME" HeaderText="OWNER_NAME" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="req_date" HeaderText="req_date" SortExpression="req_date"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="USER_NAMEs" HeaderText="USER_NAMEs" SortExpression="USER_NAMEs"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="DOMAIN_ID" ></asp:BoundColumn>
                                                 
                                                            </Columns>
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                                Font-Strikeout="False" Font-Underline="False" />
                                                        </asp:DataGrid>
                                                    </asp:Panel>
                                                    <div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    </section>
                </div>
            </div>
        </div>
    </div></ContentTemplate></asp:UpdatePanel>

    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all" />
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all" />


    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all" />

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

    <script src="../../Assets/toastr.min.js" defer async></script>
    <script src="../../Assets/script.js" defer async></script>
    <link href="../../Assets/toastr.min.css" rel="stylesheet" media="all" />
</asp:Content>
