<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="BanAdmin.aspx.vb" Inherits="Domain2021.BanAdmin" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
          <script>
              $(document).ready(function () {
                  var collapse = document.getElementById("li2")
                  collapse.className = "active";


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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Ban Admin from register a domain</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                       Domain Name:<asp:TextBox ID="domain" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="A" ControlToValidate="domain" runat="server" ErrorMessage="Required" ></asp:RequiredFieldValidator>

                                                   
                                                        <br /> Admin ID:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="A" ControlToValidate="txt_admin_id" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"   ControlToValidate="txt_admin_id" ErrorMessage="NumberOnly"  ValidationExpression="^\d+$" ValidationGroup="A" Font-Bold="true"></asp:RegularExpressionValidator> 
                                          
                                                       <br />

                                                        <asp:Button ID="Button1" runat="server" Text="Ban" CssClass=" form-group btn btn-cyan" Width="10%" OnClick="Button1_Click" ValidationGroup="A"></asp:Button>
                                                        <asp:GridView DataKeyNames="ID" Width="100%" AllowPaging="true" AllowSorting="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="SqlDataSource2" runat="server"  OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                  <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="delete1"><i class="fa fa-trash"></i> </asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Admin_ID" DataField="Admin_ID" SortExpression="Admin_ID"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Domain_name" DataField="Domain_name" SortExpression="Domain_name"></asp:BoundField>
                                                                <asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField HeaderText="COMPANY_USER_NAME" DataField="COMPANY_USER_NAME" SortExpression="COMPANY_USER_NAME" ></asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="SelectAdminBan" SelectCommandType="StoredProcedure"> </asp:SqlDataSource>
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
