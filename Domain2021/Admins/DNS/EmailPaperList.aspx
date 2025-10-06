<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="EmailPaperList.aspx.vb" Inherits="Domain2021.EmailPaperList" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
             <script>
                 $(document).ready(function () {
                     var collapse = document.getElementById("report")
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Free Domain Names</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                             Domain Name:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>

                                                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass=" form-group btn btn-cyan" Width="10%" ></asp:Button>
                                                        
                                                  
                                                        <asp:GridView DataKeyNames="DOMAIN_ID" Width="100%" AllowPaging="True" AllowSorting="True" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" >

                                                            <Columns>
                                                                <asp:BoundField HeaderText="DomainName" DataField="DomainName" SortExpression="DomainName" ReadOnly="True"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="DOMAIN_ID" DataField="DOMAIN_ID" SortExpression="DOMAIN_ID" InsertVisible="False" ReadOnly="True"></asp:BoundField>

                                                                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />

                                                            </Columns>
                                                        </asp:GridView>

                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="selectFree" SelectCommandType="StoredProcedure" FilterExpression="DomainName like '{0}%'">
                                                            <FilterParameters>
                                                                <asp:ControlParameter Name="DomainName"
                                                                    ControlID="txt_admin_id" PropertyName="Text" />
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

