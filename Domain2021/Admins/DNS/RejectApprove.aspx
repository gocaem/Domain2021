<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="RejectApprove.aspx.vb" Inherits="Domain2021.RejectApprove" ViewStateEncryptionMode="Always" %>

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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Approve Reject Report</p>
                                        <div class="table-responsive">

                                            <asp:Label ID="Label2" runat="server">Start Date</asp:Label>


                                            <asp:TextBox ID="txtStart" runat="server" TextMode="Date"></asp:TextBox>
                                             
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtstart" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                            <asp:Label ID="Label3" runat="server">End Date</asp:Label>

                                            <asp:TextBox ID="txt_end" runat="server" TextMode="Date"></asp:TextBox>
                                             
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_end" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                            <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-success" />

                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True"
                                                RepeatDirection="Horizontal" Width="200px">
                                                <asp:ListItem Value="1">Approved</asp:ListItem>
                                                <asp:ListItem Value="0">Rejected</asp:ListItem>
                                            </asp:RadioButtonList><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadioButtonList1" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-responsive" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="card-footer">
                                            <div class="">
                                                <asp:Button ID="Button3" runat="server" Text="update" CssClass="btn btn-warning" Width="50%" ValidationGroup="A" Visible="false"></asp:Button>

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

</asp:Content>

