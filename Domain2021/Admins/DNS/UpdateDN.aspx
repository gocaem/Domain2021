<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="UpdateDN.aspx.vb" Inherits="Domain2021.UpdateDN" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
                       <script>
                           $(document).ready(function () {
                               var collapse = document.getElementById("manage")
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Update DN's Data</p>
                                        <div class="table-responsive">
                                            <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                Domain Name:<asp:TextBox ID="txt_domain_name" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                <asp:Button ID="Button3" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>

    <asp:DataGrid ID="DataGrid1" GridLines="Both" BorderStyle="None"  runat="server" CssClass="table table-responsive"  DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:EditCommandColumn CancelText="Cancel" EditText="Edit" UpdateText="Update"></asp:EditCommandColumn>
            <asp:BoundColumn DataField="admin_id" HeaderText="Admin Id"></asp:BoundColumn>
            <asp:BoundColumn DataField="domain_id" HeaderText="Domain Id"></asp:BoundColumn>
            <asp:BoundColumn DataField="domain_name" HeaderText="Domain Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="second_domain" HeaderText="TLDs"></asp:BoundColumn>
            <asp:BoundColumn DataField="org_name" HeaderText="Organization Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="owner_name" HeaderText="Owner Name"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
        SelectCommand="search_2" SelectCommandType="StoredProcedure" UpdateCommandType="StoredProcedure" UpdateCommand="updateDomainName">
        <SelectParameters>
            <asp:ControlParameter ControlID="txt_domain_name" Name="domain_name" PropertyName="Text"
                Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="d_id" Type="String" />
            <asp:Parameter Name="org" Type="String" />
            <asp:Parameter Name="domain" Type="String" />
            <asp:Parameter Name="owner" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
     <div class="card-footer">
                                            <div class="">
                                                <asp:Button ID="Button1" runat="server" Text="update" CssClass=" form-group btn btn-green" Width="50%" Visible="false" OnClick="Button1_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
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


