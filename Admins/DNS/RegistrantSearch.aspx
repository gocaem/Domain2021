<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="RegistrantSearch.aspx.vb" Inherits="Domain2021.RegistrantSearch" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script>
                $(document).ready(function () {
                    var collapse = document.getElementById("report")
                    collapse.className = "sidebar-submenu menu-open";
                    collapse.style.display = "block";

                });
            </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label><asp:Label
                ID="lbl_Result" runat="server" ForeColor="Red"></asp:Label>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Admin info</p>
                                                <div class="table-responsive">
                                                    <p>
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="Label4" runat="server" ForeColor="Blue"></asp:Label>
                                                    </p>


                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">

                                                        <asp:Label ID="Label1" runat="server">Owner Name or part of it</asp:Label>

                                                        <asp:TextBox ID="txt_registrant_name" runat="server" ValidationGroup="e"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_registrant_name"
                                                            EnableClientScript="False" ErrorMessage="enter domain name" ValidationGroup="e">*</asp:RequiredFieldValidator>

                                                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-info" ValidationGroup="e" />
                                                    </div>


                                            <asp:DataGrid id=DataGrid1 runat="server" CssClass="table table-responsive" GridLines="None" AllowPaging="true" OnPageIndexChanged="DataGrid1_PageIndexChanged"  AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
											<Columns>
                                                <asp:BoundColumn DataField="Org_name" HeaderText="Entity Name">
                                                </asp:BoundColumn>
                                                   <asp:BoundColumn DataField="Owner_name" HeaderText="Registrant Name">
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Domain_name" HeaderText="Domain Name">
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="reg_date" HeaderText="Registration Date">
                                                </asp:BoundColumn>
                                                 <asp:BoundColumn DataField="status" HeaderText="Registration Date">
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="end_date" HeaderText="Expiration Date">
                                                </asp:BoundColumn>                                                
											</Columns>
										</asp:DataGrid>
										<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                            SelectCommand="RegistrantSearch" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="txt_registrant_name" Name="org_name" PropertyName="Text"
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>


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

        </ContentTemplate>
        <Triggers>

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


