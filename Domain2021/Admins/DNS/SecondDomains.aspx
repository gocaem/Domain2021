<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="SecondDomains.aspx.vb" Inherits="Domain2021.SecondDomains" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
      
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div>
                          <script>
                              $(document).ready(function () {
                                  var collapse = document.getElementById("lookup")
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Second Names</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Second Name:<asp:TextBox ID="Second_name" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="Second_name" ID="Required" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpSecond_name" ControlToValidate="Second_name" runat="server" ValidationExpression="(.*\.){2}.{2}" ErrorMessage="Second domain name must contains two dots"></asp:RegularExpressionValidator>
                                                     <br />   Fees JD:<asp:TextBox ID="FeesJD" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="FeesJD" ID="RequiredFeesJD" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                         <br />   Fees USD:<asp:TextBox ID="FeesUSD" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="FeesUSD" ID="RequiredFeesUSD" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                          <br />
                                                        <asp:Button ID="Insert" runat="server" Text="Add" CssClass=" form-group btn btn-cyan" Width="10%" OnClick="Insert_Click"></asp:Button>
                                                        
                                                        <asp:GridView Width="100%" AllowPaging="true" DataKeyNames="sid" AllowSorting="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" OnRowCommand="GridView2_RowCommand" DataSourceID="selectSecond" runat="server" >

                                                            <Columns>
                                                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
                                                                <asp:BoundField DataField="sid"  HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                                <asp:BoundField DataField="ValueUSD" HeaderText="ValueUSD" SortExpression="ValueUSD"></asp:BoundField>
                                                                <asp:BoundField DataField="renewValue" HeaderText="renewValue" SortExpression="renewValue"></asp:BoundField>
                                                                <asp:BoundField HeaderText="SECOND_DOMAIN" DataField="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundField>
                                                                 <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("sid") %>' CommandName="delete1" ValidationGroup="NONE"><i class="fa fa-trash" ></i> </asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                        <asp:SqlDataSource runat="server" ID="selectSecond" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="select_feessecond" SelectCommandType="StoredProcedure" >
                                                     
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
            <asp:PostBackTrigger ControlID="Insert" />
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

