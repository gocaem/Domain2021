<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="SendPaymentNotification.aspx.vb" Inherits="Domain2021.SendPaymentNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
            $(document).ready(function () {
                var collapse = document.getElementById("li2")
                collapse.className = "active";


            });
        </script>
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Domain's Data</p>
                                                <div class="table-responsive">
                                                    <asp:Label ID="lbl_error" runat="server" ForeColor="red"></asp:Label>
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Admin Id:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                        <asp:Button ID="Button3" ValidationGroup="c" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>
                                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                        <asp:GridView  HeaderStyle-BackColor="Silver" Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging" >

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox  ID="ck" runat="server" AutoPostBack="true" OnCheckedChanged="ck_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Serial" HeaderText="Serial" ReadOnly="True" SortExpression="Serial"></asp:BoundField>
                                                                <asp:BoundField DataField="admin_id" HeaderText="admin_id" ReadOnly="True" SortExpression="admin_id"></asp:BoundField>
                                                                <asp:BoundField DataField="domain_id" HeaderText="domain_id" ReadOnly="True" SortExpression="domain_id"></asp:BoundField>
                                                                <asp:BoundField DataField="SECOND_DOMAIN_ID" HeaderText="SECOND_DOMAIN_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="domain_name2" HeaderText="Domain Name" ReadOnly="True" SortExpression="domain_name2"></asp:BoundField>
                                                                <asp:TemplateField HeaderText="Renewal Year">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="years" runat="server" TextMode="Number" MaxLength="2" Width="45px" Text="1"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator1" ValidationGroup="B" ControlToValidate="years" runat="server" Type="Integer" MaximumValue="20" MinimumValue="1" ErrorMessage="Choose from 1-20" ForeColor="Red"></asp:RangeValidator>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="status_id" DataField="status" SortExpression="status" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ReadOnly="True"></asp:BoundField>
                                                                <asp:TemplateField HeaderText="RowIndex">
                                                                    <ItemTemplate>
                                                                        <%# Container.DisplayIndex  %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="DataItemIndex">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex  %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                            </Columns>
                                                        </asp:GridView>
                                                <asp:GridView ID="GridView1" Width="100%" OnRowDeleting="GridView1_RowCommand" ShowFooter="true"   BorderColor="Black" ForeColor="Black" Font-Bold="true" GridLines="both" CssClass="table table-responsive" runat="server" AutoGenerateColumns="true">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="del" runat="server" CommandName="delete"><i class="fa fa-trash" style="color:red"></i> </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>

                    </ContentTemplate></asp:UpdatePanel>
                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="domains_per_Admin2" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" Name="admin_ID" PropertyName="Text"
                                                                    Type="String" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </div>
                                                    Amount: <asp:TextBox ID="TextBox1" TextMode="Number" ValidationGroup="d" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="d" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox1" ></asp:RequiredFieldValidator>
                                                         <asp:Button ID="Button1" ValidationGroup="d" runat="server" Text="SendNotification" Visible="false" CssClass=" form-group btn btn-success" Width="50%" OnClick="Button1_Click"></asp:Button>
                                                    

                                                </div>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A" ShowMessageBox="true" />

                                                <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>

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
            <asp:PostBackTrigger ControlID="Button3" />
        </Triggers>
    </asp:UpdatePanel>

    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all" />
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all" />


    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all" />

    <script src="../../Scripts/toastr.min.js"
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
