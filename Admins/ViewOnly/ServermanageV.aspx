<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/ViewOnly/SiteOnly.Master" CodeBehind="ServermanageV.aspx.vb" Inherits="Domain2021.ServermanageV" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <script>
                     $(document).ready(function () {
                         var collapse = document.getElementById("manage")
                         collapse.className = "sidebar-submenu menu-open";
                         collapse.style.display = "block";

                     });
                 </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Manage Server's Data</p>
                                        <div class="table-responsive">
                                            <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                Domain Name:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                <asp:Button ID="Button3" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>

                                                <asp:GridView Visible="false" DataKeyNames="Domain_id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("Domain_id") %>' CommandName="view"><i class="fa fa-edit"></i> </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain" DataField="domain_name" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:BoundField HeaderText="1LD/2LD" DataField="Second_domain" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Domain_id"></asp:BoundField>
                                                        <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>


                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" GridLines="None"  OnRowCommand="GridView1_RowCommand"  DataKeyNames="ID">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="view" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="view"><i class="fa fa-edit"></i> </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:BoundField HeaderText="ID" DataField="id" SortExpression="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="P_SERVER_NAME" DataField="P_SERVER_NAME" SortExpression="ID"></asp:BoundField>
                                                        <asp:BoundField HeaderText="P_SERVER_IP" DataField="P_SERVER_IP" SortExpression="ID"></asp:BoundField>
                                                        <asp:BoundField HeaderText="S_SERVER_NAME" DataField="S_SERVER_NAME" SortExpression="ID"></asp:BoundField>
                                                        <asp:BoundField HeaderText="S_SERVER_IP" DataField="S_SERVER_IP" SortExpression="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>


                                                    </Columns>
                                                </asp:GridView>
                                                <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="SearchforServer" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="txt_admin_id" Name="domain_name" PropertyName="Text"
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
                                                                <asp:Label ID="Domain_nameL" runat="server" Text="Primary Server Name" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="p_name" runat="server" ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div3" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label2" runat="server">
                                                                    <asp:Label ID="Label4" runat="server" Text="Primary Server IP" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"  ></asp:TextBox>
                                                        

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div1" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label3" runat="server">
                                                                    <asp:Label ID="Label5" runat="server" Text=" Secondary Name (1)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"  ></asp:TextBox>
                                                           

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div4" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label6" runat="server">
                                                                 <asp:Label ID="Label07" runat="server" Text="Secondary IP (1)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label8" runat="server">
                                                                    <asp:Label ID="Label9" runat="server" Text="Secondary Name (2)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"  ></asp:TextBox>
                                                             

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div6" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label10" runat="server">
                                                                    <asp:Label ID="Label11" runat="server" Text="Secondary IP (2)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"  ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div7" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label12" runat="server">
                                                                    <asp:Label ID="Label13" runat="server" Text="Secondary Name (3)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div8" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label14" runat="server">
                                                                    <asp:Label ID="Label15" runat="server" Text="Secondary IP (3)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"  ></asp:TextBox>
                                                    

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div9" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label16" runat="server">
                                                                    <asp:Label ID="Label17" runat="server" Text="Secondary Name (4)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label18" runat="server">
                                                                    <asp:Label ID="Label19" runat="server" Text="Secondary IP (4)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server"  ></asp:TextBox>
                                                        

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label20" runat="server">
                                                                    <asp:Label ID="Label21" runat="server" Text="Secondary Name (5)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"  ></asp:TextBox>
                                                          

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label22" runat="server">
                                                                    <asp:Label ID="Label23" runat="server" Text="Secondary IP (5)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server"  ></asp:TextBox>
                                                            

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div13" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label24" runat="server">
                                                                    <asp:Label ID="Label28" runat="server" Text="Secondary Name (6)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server"  ></asp:TextBox>
                                                         

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div14" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label29" runat="server">
                                                                    <asp:Label ID="Label30" runat="server" Text="Secondary IP (6)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server"  ></asp:TextBox>
                                                      

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div15" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label31" runat="server">
                                                                    <asp:Label ID="Label32" runat="server" Text="Secondary Name (7)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server"  ></asp:TextBox>
                                                             

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label33" runat="server">
                                                                    <asp:Label ID="Label34" runat="server" Text="Secondary IP (7)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server"  ></asp:TextBox>
                                                       

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label35" runat="server">
                                                                    <asp:Label ID="Label36" runat="server" Text="Secondary Name (8)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server"  ></asp:TextBox>
                                                           

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label37" runat="server">
                                                                    <asp:Label ID="Label38" runat="server" Text="Secondary IP (8)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server"  ></asp:TextBox>
                                                             

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div19" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label39" runat="server">
                                                                    <asp:Label ID="Label40" runat="server" Text="Secondary Name (9)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server"  ></asp:TextBox>
                                                          

                                                            </div>
                                                        </div>
                                                       <div class="col-lg-4 col-md-4" id="Div20" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label41" runat="server">
                                                                    <asp:Label ID="Label42" runat="server" Text="Secondary IP (9)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server"  ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>

                                                      <div class="col-lg-4 col-md-4" id="Div21" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label43" runat="server">
                                                                    <asp:Label ID="Label44" runat="server" Text="Secondary Name (10)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox20" runat="server"  ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                                        </div>
                                                    <div class="row">

                                                        <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                                            <div class="form-group">
                                                                <label id="Label45" runat="server">
                                                                    <asp:Label ID="Label46" runat="server" Text="Secondary IP (10)" Font-Bold="True"></asp:Label></label>
                                                                <asp:TextBox CssClass="form-control" ID="TextBox21" runat="server"  ></asp:TextBox>
                                                              

                                                            </div>
                                                        </div>
                                              
                                                        </div>
                                                    </div>


                                                </div>


                                            </div>



                                        </div>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A" ShowMessageBox="true" />

                                        <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <div class="card-footer">
                                       
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
