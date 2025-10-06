<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/ViewOnly/SiteOnly.Master" CodeBehind="SearchclassV.aspx.vb" Inherits="Domain2021.SearchclassV" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <script>
            $(document).ready(function () {
                var collapse = document.getElementById("report")
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Search By Classification</p>
                                        <div class="modal-body" style="font-family: Calibri">
                                            Classification Name:
                                            <asp:DropDownList Font-Bold="true" AppendDataBoundItems="true" Width="50%" DataSourceID="SqlDataSource2" CssClass="form-control" Height="30px" ID="DropDownList1" runat="server" DataTextField="ClassificationNameEn" DataValueField="ClassificationID">
                                                <asp:ListItem Value="0" Text="Select Class"></asp:ListItem>

                                            </asp:DropDownList><asp:RequiredFieldValidator ErrorMessage="Required" InitialValue="0" ID="RequiredFieldValidator2" Font-Bold="true" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                                            <br />
                                            Status Name:
                                            <asp:DropDownList Font-Bold="True" AppendDataBoundItems="True" Width="50%" DataSourceID="SqlDataSource3" CssClass="form-control" Height="30px" ID="DropDownList2" runat="server" DataTextField="STATUS" DataValueField="ID">
                                                <asp:ListItem Value="0" Text="Select Status"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>" SelectCommand="StatusLookup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            <br />
                                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%"></asp:Button>

                                            <br />
                                            <div class="card-body" id="div11" runat="server" visible="false">
                                                <hr />
                                                <div class="tab-content text-center">
                                                    <p class="card-text text-bold-900 alert alert-info" style="font-size: 16px">Domains available</p>

                                                    <asp:Panel CssClass="tab-pane active" Visible="false" runat="server" ClientIDMode="Static" ID="DomainInfo" role="tabpanel">

                                                        <asp:GridView ID="GridView1" AllowPaging="true" GridLines="None" runat="server" AllowSorting="true" CssClass="table table-responsive" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="DOMAIN_ID">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("Domain_id") %>' CommandName="view"><i class="icon-eye"></i> </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DomainName" HeaderText="Domain Name" SortExpression="DomainName" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"></asp:BoundField>
                                                                <asp:BoundField DataField="DOMAIN_ID" HeaderText="Domain ID" SortExpression="DOMAIN_ID" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="Entity Name" HeaderText="Entity Name" SortExpression="Entity Name"></asp:BoundField>
                                                                   <asp:TemplateField ItemStyle-CssClass="Owner_Name">
                                                                      <ItemTemplate>
                                                                             <asp:Label runat="server" Text='<%# Server.HtmlDecode(Eval("Owner_Name")) %>' ID="lbl" />
                                                                      </ItemTemplate>
                                                                   </asp:TemplateField>
                                                                  <asp:BoundField DataField="NationalNo" HeaderText="National No" SortExpression="NationalNo"></asp:BoundField>
                                                                  <asp:BoundField DataField="Admin_id" HeaderText="Admin ID" SortExpression="Admin_id"></asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="select_class_admin" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="selectdomainclass" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="class" Type="Int32"></asp:ControlParameter>
                                                                <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="status" Type="Int32"></asp:ControlParameter>

                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </asp:Panel>
                                                                   <asp:Panel ID="Panel2" runat="server" Visible="False" Width="533px">
                                              <asp:GridView ID="GridView2" DataSourceID="SqlDataSource1" ClientIDMode="Static" runat="server" AutoGenerateColumns="true"   Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="69px" HorizontalAlign="Center" ShowFooter="True" Width="360px" CssClass="table table-responsive" GridLines="None" AllowPaging="false">
                                                                                      </asp:GridView>
                                                      </asp:Panel>

                                                    <asp:LinkButton ID="exportExcel" runat="server" CssClass="btn btn-success" OnClick="exportExcel_Click" ClientIDMode="Static">Excel<i class="fa fa-download"></i></asp:LinkButton>
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
    </div>

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
