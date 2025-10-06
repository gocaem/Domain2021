<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="UnifyAdmin.aspx.vb" Inherits="Domain2021.UnifyAdmin" ViewStateEncryptionMode="Always" %>
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Unify Admin</p>
                                        <div class="table-responsive">
                                            <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                Organization Name:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                <asp:Button ID="Button3" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>

                                                <asp:GridView Visible="false" DataKeyNames="Domain_id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" runat="server" OnRowCommand="GridView2_RowCommand" DataSourceID="selectSettings">

                                                    <Columns>
                                                  
                                                        <asp:BoundField HeaderText="Admin ID" DataField="Admin_id" SortExpression="Domain_id" ></asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain" DataField="domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain" DataField="domain_name" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:BoundField HeaderText="1LD/2LD" DataField="Second_domain" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Organization Name" DataField="ORG_NAME" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("Admin_ID") %>' CommandName="show"><i class="fa fa-eye"></i> </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                   <asp:CheckBox ID="CheckBox1" runat="server"  />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                                
                                                <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="SelectAdminFromOrg" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="txt_admin_id" Name="TextBox" PropertyName="Text"
                                                            Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>

                                            <ul class="nav nav-tabs" role="tablist" id="tablist" runat="server" visible="false">
                                                <li class="nav-item">
                                                    <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab">Server Info</a>
                                                </li>

                                            </ul>
                                            <!-- Tab panes -->
                                            <div class="tab-content" id="ttab1" style="width: 70%" runat="server" visible="false">
                                                <div class="tab-pane active" id="tabs-1" role="tabpanel" width="70%">

                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div2" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label1" runat="server">
                                                                <asp:Label ID="txt_user_nameL" runat="server" Text="Company User Name" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="txt_user_name" runat="server" ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                         
                                                      <div class="col-lg-4 col-md-4" id="Div1" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label3" runat="server">
                                                                    <asp:Label ID="Label5" runat="server" Text="Admin Name" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" Width="500"  ></asp:TextBox>
                                                           

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div4" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label6" runat="server">
                                                                 <asp:Label ID="Label07" runat="server" Text="Phone" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label8" runat="server">
                                                                    <asp:Label ID="Label9" runat="server" Text="Fax" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"  ></asp:TextBox>
                                                             

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div6" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label10" runat="server">
                                                                    <asp:Label ID="Label11" runat="server" Text="Email" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" Width="300" ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div7" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label12" runat="server">
                                                                    <asp:Label ID="Label13" runat="server" Text="Address" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server"  Width="500" ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                   
                                                        </div>
                                                         <div class="row">
                                                      <div class="col-lg-4 col-md-4" id="Div9" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label16" runat="server">
                                                                    <asp:Label ID="Label17" runat="server" Text="Mobile" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label18" runat="server">
                                                                    <asp:Label ID="Label19" runat="server" Text="Password" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server"  ></asp:TextBox>
                                                        

                                                            </div>
                                                        </div>
                                                
                                                        </div>

                                                    </div>


                                                </div>


                                            </div><hr />
                                             <div style="font-weight: bold; font-family: Calibri; border:thin;" visible="false" id="Unifydiv"  runat="server">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="b" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter the new id"></asp:RequiredFieldValidator>
                                                 <h5>New Admin id:</h5><asp:TextBox ID="TextBox1" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%" ValidationGroup="b"></asp:TextBox>
                                                <asp:Button ID="Button2" runat="server" Text="Unify Admin" CssClass=" form-group btn btn-success" ValidationGroup="b" Width="50%" OnClick="Button1_Click"></asp:Button>



                                        </div>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A" ShowMessageBox="true" />

                                        <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>
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

