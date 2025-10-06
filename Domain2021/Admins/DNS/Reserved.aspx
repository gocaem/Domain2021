<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Reserved.aspx.vb" Inherits="Domain2021.Reserved" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
            <script>
                $(document).ready(function () {
                    var collapse = document.getElementById("lookup")
                    collapse.className = "sidebar-submenu menu-open";
                    collapse.style.display = "block";

                });
            </script>
    <asp:UpdatePanel ID="up" runat="server">
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Reserved Names</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Domain Name:<asp:TextBox ID="txt_DOMAIN_NAME" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>

                                                        <asp:Button ID="Button2" runat="server" Text="Search" CssClass=" form-group btn btn-success" Width="10%" OnClick="Button2_Click"></asp:Button>

                                                        <asp:Button ID="Button1" runat="server" Text="Add" CssClass=" form-group btn btn-cyan" Width="10%" OnClick="Button3_Click" ValidationGroup="A"></asp:Button><br />
                                                                    <asp:GridView Visible="true" DataKeyNames="DomainName" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" AllowSorting="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" runat="server" ValidationGroup="B" CommandArgument='<%# Eval("Domainname") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Domain Name" DataField="DomainName" SortExpression="DomainName"></asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>

                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="getallReserved" SelectCommandType="StoredProcedure" FilterExpression="DomainName like '{0}%'">
                                                            <FilterParameters>
                                                                <asp:ControlParameter Name="DomainName"
                                                                    ControlID="txt_DOMAIN_NAME" PropertyName="Text" />
                                                            </FilterParameters>
                                                        </asp:SqlDataSource>
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

