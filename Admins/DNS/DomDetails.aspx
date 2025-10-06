<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="DomDetails.aspx.vb" Inherits="Domain2021.DomDetails" ViewStateEncryptionMode="Always" %>



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
                                                <div class="table-responsive"> <asp:Label ID="lbl_error" runat="server" ForeColor="red"></asp:Label>
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Domain Name:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                        <asp:Button ID="Button3" ValidationGroup="c" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click"></asp:Button>

                                                        <asp:GridView Visible="false" DataKeyNames="Domain_id" HeaderStyle-BackColor="Silver" Width="100%" EnableSortingAndPagingCallbacks="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="view" ValidationGroup="aa" runat="server" CommandArgument='<%# Eval("Domain_id") %>' CommandName="view"><i class="fa fa-edit"></i> </asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Domain" DataField="domain_name" SortExpression="Domain_id"></asp:BoundField>
                                                                <asp:BoundField HeaderText="1LD/2LD" DataField="Second_domain" SortExpression="Domain_id"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Domain_id"></asp:BoundField>
                                                                <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>


                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="search" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" Name="domain_name" PropertyName="Text"
                                                                    Type="String" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </div>

                                                    <ul class="nav nav-tabs" role="tablist" id="tablist" runat="server" visible="false">
                                                        <li class="nav-item">
                                                            <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab">Domain Info</a>
                                                        </li>

                                                        <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#tabs-3" role="tab">Tech. Info</a>
                                                        </li>
                                                        <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#tabs-4" role="tab">Billing Info</a>
                                                        </li>
                                                        <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#tabs-5" role="tab">Admin Info</a>
                                                        </li>
                                                           <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#papers" role="tab">Papers</a>
                                                        </li>
                                                    </ul>
                                                    <!-- Tab panes -->
                                                    <div class="tab-content" id="ttab1" style="width: 70%" runat="server" visible="false">
                                                        <div class="tab-pane active" id="tabs-1" role="tabpanel" width="70%">

                                                            <div class="row">

                                                                <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label13" runat="server">
                                                                            <asp:Label ID="Label21" runat="server" Text="Admin_idL" Font-Bold="True"></asp:Label></label>
                                                                        <asp:Label CssClass="form-control" ID="Admin_id" runat="server"  ></asp:Label>
                                                                       

                                                                    </div>
                                                                </div>
                                                                     <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label45" runat="server">
                                                                            <asp:Label ID="Label46" runat="server" Text="domain_idL" Font-Bold="True"></asp:Label></label>
                                                                        <asp:Label CssClass="form-control" ID="Domain_id" runat="server"  ></asp:Label>
                                                                       

                                                                    </div>
                                                                </div>
                                                                    <div class="col-lg-4 col-md-4" id="Div26" runat="server">
                                                                     <asp:CheckBox ID="CheckBox1" runat="server" Text="Hide Domain Contact Info" />
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-lg-4 col-md-4" id="Div2" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label1" runat="server">
                                                                            <asp:Label ID="Domain_nameL" runat="server" Text="Domain Name" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="Domain_name" runat="server" AutoPostBack="true" OnTextChanged="Domain_name_TextChanged" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="Domain_nameValidator" Font-Bold="true" ErrorMessage="Domain Name is Required" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="Domain_name" Text="Domain Name is Required"></asp:RequiredFieldValidator>


                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div4" runat="server">
                                                                    <label id="Label7" runat="server">
                                                                        <asp:Label ID="SecondDomainLabel" Text="Second Domain" runat="server" Font-Bold="True"></asp:Label></label>
                                                                    <asp:DropDownList Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="SecondDomain_SelectedIndexChanged" CssClass="form-control" ID="SecondDomain" runat="server" DataSourceID="SqlDataSource1" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID">
                                                                    </asp:DropDownList>
                                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                </div>

                                                                <div class="col-lg-4 col-md-4" id="Div1" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label3" runat="server">
                                                                            <asp:Label ID="ClassificationLabel" Text="Classification" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="Classification_SelectedIndexChanged" CssClass="form-control" ID="Classification" runat="server" Width="100%">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ValidationGroup="A" ID="ClassificationValidator" ErrorMessage="Classification Required" runat="server" Font-Bold="true" SetFocusOnError="true" ControlToValidate="Classification" InitialValue="0" Text="Classification Required"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-lg-4 col-md-4" id="Div3" runat="server">

                                                                    <div class="form-group">
                                                                        <label id="Label2" runat="server">
                                                                            <asp:Label ID="Label4" runat="server" Text="End Date" Font-Bold="True"></asp:Label></label>
                                                                         <asp:TextBox ID="EndDate" runat="server" TextMode="Date"></asp:TextBox>
                                                                           </div>

                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="DivNationalNo" runat="server" visible="True">
                                                                    <label id="Label105" runat="server">

                                                                        <asp:Label ID="NationalNoL" Text="National Number" runat="server" Font-Bold="True"></asp:Label></label>
                                                                    <asp:TextBox CssClass="form-control" ID="NationalNo" runat="server" AutoPostBack="true" OnTextChanged="NationalNo_TextChanged"></asp:TextBox>
                                                                   
                                                                </div>

                                                                <div class="col-lg-4 col-md-4" id="OrgDetailDiv" runat="server" visible="True">
                                                                    <div class="form-group">
                                                                        <label id="Label9" runat="server">
                                                                            <asp:Label ID="OrgDetailL" runat="server" Text="Details of National No " Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="OrgDetailTextBox" runat="server" ></asp:TextBox>
                                                                       <asp:GridView Visible="true" ID="GridView1" runat="server" AutoGenerateColumns="false"  >
                                                                             <Columns>
                                                                                <asp:BoundField HeaderText="strTradeMarkArName" DataField="strTradeMarkArName"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="strTradeMarkEnName" DataField="strTradeMarkEnName"></asp:BoundField>

                                                                                </Columns>
                                                                       </asp:GridView>
                                                                      <asp:GridView ID="GridView3" runat="server" Visible="true"  AutoGenerateColumns="false">
                                                                           <Columns>
                                                                                 <asp:BoundField HeaderText="Mark_name" DataField="Mark_name" SortExpression="Admin_id"></asp:BoundField>
                                                                                <asp:BoundField HeaderText="Mark_name_lang2" DataField="Mark_name_lang2" SortExpression="Admin_id"></asp:BoundField>

                                                                                </Columns>
                                                                      </asp:GridView>
                                                                        </div>
                                                                
                                                                </div>


                                                            </div>
                                                            <div class="row">

                                                                <div class="col-lg-4 col-md-4" id="Div20" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label28" runat="server">
                                                                            <asp:Label ID="Label29" runat="server" Text="Entity Name" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="EntityTextBox" runat="server" AutoPostBack="true" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Font-Bold="true" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="EntityTextBox" Text="Entity name Required!" ErrorMessage="Entity name Required!"></asp:RequiredFieldValidator>


                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div21" runat="server">
                                                                    <label id="Label30" runat="server">
                                                                        <asp:Label ID="Label32" Text="Status" runat="server" Font-Bold="True"></asp:Label></label>
                                                                    <asp:DropDownList Font-Bold="true" CssClass="form-control" ID="Status" runat="server" DataSourceID="SqlStatus" DataTextField="Status" DataValueField="ID">
                                                                    </asp:DropDownList><asp:Label ID="Label19" runat="server" ForeColor="Red" Font-Bold="true" Text="Label"></asp:Label>
                                                                    <asp:SqlDataSource runat="server" ID="SqlStatus" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="StatusLookup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                </div>

                                                                <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label34" runat="server">
                                                                            <asp:Label ID="Label36" Text="E-mail" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="DEmail" runat="server" AutoPostBack="true" ></asp:TextBox>

                                                                        <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator11" runat="server" Font-Bold="true" SetFocusOnError="true" ControlToValidate="DEmail" InitialValue="0" ErrorMessage="Org E-mail Required!" Text="Org E-mail Required!"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                        <div >
                                                                        
                                                                                  </div>
                                                                </div>
                                                                  
                                                            </div>
                                                                         <div class="row">

                                                                <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label38" runat="server">
                                                                                 <asp:Label ID="Label37" runat="server" Text="Is it Test Domain" ></asp:Label></label>
                                                                            <asp:CheckBox  ID="TestDomain" runat="server" ></asp:CheckBox>
                                                                 

                                                                    </div>
                                                                </div></div>
                                                            <div class="row">
                                                                <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label43" runat="server">
                                                                            <asp:Label ID="Label44" Text="Mobile" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="DMobileTextBox" runat="server" ></asp:TextBox>

                                                                        <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator15" runat="server" Font-Bold="true" SetFocusOnError="true" ControlToValidate="DMobileTextBox" InitialValue="0" Text="Org Mobile is Required!" ErrorMessage="Org Mobile is Required!"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div24" runat="server" visible="True">
                                                                    <div class="form-group">
                                                                        <label id="Label39" runat="server">
                                                                            <asp:Label ID="Label40" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:CheckBox CssClass="checkbox" ID="CheckBoxFree" Text="Is Free" runat="server"></asp:CheckBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-lg-4 col-md-4" id="Div25" runat="server" visible="True">
                                                                    <div class="form-group">
                                                                        <label id="Label41" runat="server">
                                                                            <asp:Label ID="Label42" runat="server" Text="Registration Date" Font-Bold="True"></asp:Label></label>
                                                                         <asp:TextBox ID="RadDateInput1" runat="server" TextMode="Date"></asp:TextBox>
                                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="A" runat="server" Font-Bold="true" SetFocusOnError="true" ControlToValidate="RadDateInput1" Text="Reg Date Required!" ErrorMessage="Reg Date Required!"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                                 <div class="row">
                                                                    <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label17" runat="server">
                                                                                <asp:Label ID="OwnerName" runat="server" Font-Bold="True" Text="Owner Name"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control" ID="OwnerNameTextBox" runat="server" ></asp:TextBox>
                                                                            </div>
                                                                    </div>
                                                                  
                                                                </div>
                                                        </div>

                                                        <div class="tab-pane" id="tabs-3" role="tabpanel">
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label31" runat="server">
                                                                            <asp:Label ID="TechLabel" Text="Tech Contact" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="TechTextBox" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="TechValidator" runat="server" ControlToValidate="TechTextBox" ValidationGroup="A" Text="Tech Name Required!" ErrorMessage="Tech Name Required!"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label33" runat="server">
                                                                            <asp:Label ID="TechMobileLabel" Text="Mobile" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="TechMobileTextBox" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="TechMobileValidator" runat="server" ControlToValidate="TechMobileTextBox" ValidationGroup="A" Text="Tech Mobile Required!" ErrorMessage="Tech Mobile Required!"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label35" runat="server">
                                                                            <asp:Label ID="TechEmailLabel" Text="Email" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="TechEmailTextBox" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="TechEmailTextBoxValidator" runat="server" ControlToValidate="TechEmailTextBox" ValidationGroup="A" Text="TechEmail Required!"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="TechEmailExpressionValidator" runat="server" ControlToValidate="TechEmailTextBox" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="Invalid E-mail" ErrorMessage="Invalid Tech. E-mail"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane" id="tabs-4" role="tabpanel">
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-4 col-md-4" id="Div28" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label57" runat="server">
                                                                            <asp:Label ID="BillLabel" runat="server" Text="Billing Name" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="BillTextBox" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="BillingValidator" runat="server" ControlToValidate="BillTextBox" ValidationGroup="A" Text="Required!" ErrorMessage="Billing Email is Required"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div29" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label59" runat="server">
                                                                            <asp:Label ID="BillMobileLabel" Text="Mobile" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="BillMobileText" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="BillMobileValidator" runat="server" ControlToValidate="BillMobileText" ValidationGroup="A" Text="Billing Mobile Required!" ErrorMessage="Billing Mobile Required!"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4" id="Div30" runat="server">
                                                                    <div class="form-group">
                                                                        <label id="Label61" runat="server">
                                                                            <asp:Label ID="BillEmailLabel" Text="Email" runat="server" Font-Bold="True"></asp:Label></label>
                                                                        <asp:TextBox CssClass="form-control" ID="BillEmail" runat="server" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="BillEmailValidator" SetFocusOnError="true" runat="server" ControlToValidate="BillEmail" ValidationGroup="A" Text="Billing Email Required!" ErrorMessage="Billing Email Required!"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="BillEmailExpressionValidator" SetFocusOnError="true" runat="server" ControlToValidate="BillEmail" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="Invalid E-mail"></asp:RegularExpressionValidator>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane" id="tabs-5" role="tabpanel">
                                                            <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                <div class="row">
                                                                    <div class="col-lg-6 col-md-6" id="Div8" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label11" runat="server">
                                                                                <asp:Label ID="Label12" Text="Username" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox Enabled="false" CssClass="form-control form-control-lg input-lg" ID="username" runat="server" placeholder="username"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="username Required" ValidationGroup="A" ControlToValidate="username" ForeColor="red" Text="username Required!"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6" id="Div6" runat="server">
                                                                        <div class="form-group">
                                                                        
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-6 col-md-6" id="Div7" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label14" runat="server">
                                                                                <asp:Label ID="Label5" Text="Admin Name" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Name" runat="server" placeholder="Name"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="A" ControlToValidate="Name" ErrorMessage="Name Required" ForeColor="red" Text="Name Required!"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6" id="Div9" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label15" runat="server">
                                                                                <asp:Label ID="Label6" Text="Mobile Number" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Mobile" runat="server" placeholder="Mobile"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="A" ControlToValidate="Mobile" ErrorMessage="Mobile Required" ForeColor="red"></asp:RequiredFieldValidator>
                                                                          
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-6 col-md-6" id="Div13" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label16" runat="server">
                                                                                <asp:Label ID="Label8" Text="Phone Number" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Phone" runat="server" placeholder="Phone"></asp:TextBox>
       
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6" id="Div14" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label18" runat="server">
                                                                                <asp:Label ID="Label10" Text="Fax Number" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Fax" runat="server" placeholder="Fax"></asp:TextBox>
                                                                          </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-6 col-md-6" id="Div15" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label20" runat="server">
                                                                                <asp:Label ID="Label22" Text="Email" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Email" runat="server" placeholder="Email"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="A" ControlToValidate="Email" ErrorMessage="Owner Email Required" ForeColor="red" Text="Invalid. admin E-mail"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6 col-md-6" id="Div19" runat="server">
                                                                        <div class="form-group">
                                                                            <label id="Label23" runat="server">
                                                                                <asp:Label ID="Label24" Text="Address" runat="server" Font-Bold="True"></asp:Label></label>
                                                                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Address" runat="server" placeholder="Address"></asp:TextBox>
                                                                          </div>
                                                                    </div>
                                                                </div>
                                                           

                                                            </div>

                                                        </div>
                                                        <div class="tab-pane" id="papers" role="tabpanel">
                                                              <p>
                                                                    <asp:Label ID="Label51" runat="server" Font-Names="Calibri" Font-Size="Medium">Uploaded Files</asp:Label>
                                                                </p>
                                                                <p>
                                                                    <asp:DataList ID="UploadedFiles" runat="server" Font-Names="Calibri" Font-Size="Medium">
                                                                        <ItemTemplate>
                                                                            <table id="Table7" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "{0}") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "../../DOC/{0}") %>' Target="_blank">
                                                                                        </asp:HyperLink></td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </p>

                                                        </div>

                                                             <div class="card-footer">
                                                    <div class="">
                                                        <asp:Button ID="Button1" runat="server" Text="update"   CssClass=" form-group btn btn-green" Width="50%" ValidationGroup="A" Visible="false" OnClick="Button1_Click"></asp:Button>
                                                    </div>
                                                </div>
                                                    </div>



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
            <asp:AsyncPostBackTrigger ControlID="Classification" EventName="SelectedIndexChanged" />
            <asp:PostBackTrigger ControlID="Button1" />
           <asp:PostBackTrigger ControlID="NationalNo" />
      
        </Triggers>
    </asp:UpdatePanel>
    
<link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
<link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>


<link href="../assets/css/toastr.css"
    rel="stylesheet" media="all"/>

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
