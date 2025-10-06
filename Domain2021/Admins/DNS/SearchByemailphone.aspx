<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="SearchByemailphone.aspx.vb" Inherits="Domain2021.SearchByemailphone" ViewStateEncryptionMode="Always" %>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Search By Email and phone</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Email Or Mobile:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button1_Click"></asp:Button>
                                                       <br /> <asp:Label ID="Label1" runat="server" Text="Administrative Contacts"  CssClass="alert-info"></asp:Label>
                                                        <asp:GridView Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:BoundField DataField="ADMIN_CONTACT" HeaderText="ADMIN_CONTACT" SortExpression="ADMIN_CONTACT"></asp:BoundField>
                                                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL"></asp:BoundField>
                                                                <asp:BoundField DataField="COMPANY_USER_NAME" HeaderText="Username" SortExpression="COMPANY_USER_NAME"></asp:BoundField>
                                                                <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" SortExpression="MOBILE"></asp:BoundField>
                                                            </Columns>

                                                        </asp:GridView><br />
                                                            <asp:Label ID="Label2" runat="server" Text="Billing Contacts"  CssClass="alert-info"></asp:Label>
                                                   
                                                     <asp:GridView Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView1" CssClass="table table-responsive" DataSourceID="SqlDataSource1" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:BoundField DataField="BILLING_CONTACT" HeaderText="BILLING_CONTACT" SortExpression="BILLING_CONTACT"></asp:BoundField>
                                                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL"></asp:BoundField>
                                                                <asp:BoundField DataField="ADDRESSES" HeaderText="ADDRESS" SortExpression="ADDRESSES"></asp:BoundField>
                                                                <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" SortExpression="MOBILE"></asp:BoundField>
                                                            </Columns>

                                                        </asp:GridView><br />
                                                            <asp:Label ID="Label3" runat="server" Text="Owner Contacts"  CssClass="alert-info"></asp:Label>
                                                   
                                                      <asp:GridView Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView3" CssClass="table table-responsive" DataSourceID="SqlDataSource2" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:BoundField DataField="ORG_NAME" HeaderText="ORG_NAME" SortExpression="ORG_NAME"></asp:BoundField>
                                                                <asp:BoundField DataField="Domain Name" HeaderText="Domain Name" SortExpression="Domain Name" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" SortExpression="MOBILE"></asp:BoundField>
                                                                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS"></asp:BoundField>
                                                            </Columns>

                                                        </asp:GridView><br />
                                                            <asp:Label ID="Label4" runat="server" Text="Technical Contacts"  CssClass="alert-info"></asp:Label>
                                                   
                                                          <asp:GridView Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView4" CssClass="table table-responsive" DataSourceID="SqlDataSource3" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:BoundField DataField="Tech_contact" HeaderText="Domain Name" SortExpression="Domain Name"></asp:BoundField>
                                                                <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL"></asp:BoundField>
                                                                <asp:BoundField DataField="ADDRESSES" HeaderText="Address" SortExpression="Address"></asp:BoundField>
                                                                <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" SortExpression="MOBILE"></asp:BoundField>
                                                            </Columns>

                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="Admin_byEmail" SelectCommandType="StoredProcedure">

                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" PropertyName="Text" Name="email" Type="String"></asp:ControlParameter>
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>

                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="billing_byEmail" SelectCommandType="StoredProcedure">

                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" PropertyName="Text" Name="email" Type="String"></asp:ControlParameter>
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                         <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="TECH_byEmail" SelectCommandType="StoredProcedure">

                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" PropertyName="Text" Name="email" Type="String"></asp:ControlParameter>
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="owner_byEmail" SelectCommandType="StoredProcedure">

                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" PropertyName="Text" Name="email" Type="String"></asp:ControlParameter>
                                                            </SelectParameters>
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
