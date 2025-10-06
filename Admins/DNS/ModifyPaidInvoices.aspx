<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ModifyPaidInvoices.aspx.vb" Inherits="Domain2021.ModifyPaidInvoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <script>
              $(document).ready(function () {
                  var collapse = document.getElementById("li2")
                  collapse.className = "active";


              });
          </script>
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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Prepare Invoice</p>
                                        <div class="table-responsive">


                                            <div class="form-body" style="padding-left: 20px">
                                                <h4 class="form-section"><i class="icon-search"></i>Search Reference ID</h4>
                                                <div class="row">

                                                    <label for="projectinput1">Reference ID</label>
                                                    <asp:TextBox runat="server" ID="projectinput1" CssClass="form-control" placeholder="Reference ID" name="fname" Width="50%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator1" runat="server" ControlToValidate="projectinput1" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="row">
                                                    <div class="form-group">

                                                        <asp:LinkButton ID="LK" CssClass="btn btn-success" runat="server" ValidationGroup="A" OnClick="LK_Click"><i class="icon-search"></i>Search </asp:LinkButton>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                            <asp:UpdateProgress ID="updProgress" DisplayAfter="1" AssociatedUpdatePanelID="up" runat="server">
                                            <ProgressTemplate>
                                                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                                                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Admins/app-assets/images/l.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 10%; left: 10%;" />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="up" runat="server">
                                            <ContentTemplate>

                                        <asp:Label ID="Label1" Visible="True" CssClass="label black" Font-Size="Medium" runat="server" Text="Paid Invoices for Admin"></asp:Label><br />
                                        <br />
                                          <asp:Label ID="Label3" Visible="True" Font-Size="Medium" runat="server" ForeColor="Red"></asp:Label><br />
                                    

                                        <asp:GridView RenderMode="Lightweight" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" ID="GridView1" HeaderStyle-Font-Bold="true"
                                            Width="40%"
                                            ShowFooter="True" AllowPaging="True" runat="server" CssClass="table table-bordered" PageSize="20" HeaderStyle-Font-Names="Calibri" Font-Bold="true">

                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label64" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField SortExpression="InvoiceSettings_ID" DataField="InvoiceSettings_ID" HeaderText="Invoice Id"
                                                    HeaderStyle-Font-Names="Calibri"
                                                    ItemStyle-Font-Names="cairo"></asp:BoundField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-Font-Names="Calibri">
                                                    <HeaderStyle Font-Names="cairo" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Lk" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="det" CausesValidation="false" Height="15px" Width="15px"><i class="icon-eye"></i></asp:LinkButton>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:BoundField DataField="InvoiceSettings_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                            </Columns>


                                        </asp:GridView>
                                            <asp:Label ID="Label2" Visible="True" Font-Size="Medium" runat="server" ForeColor="Red"></asp:Label><br />

                                        <asp:GridView RenderMode="Lightweight" Visible="false" DataSourceID="selectSettings" AutoGenerateColumns="false" ID="GridView3" OnRowCommand="GridView3_RowCommand" HeaderStyle-Font-Bold="true"
                                            Width="40%"
                                            ShowFooter="True" AllowPaging="True" runat="server" CssClass="table table-bordered" PageSize="20" HeaderStyle-Font-Names="Calibri" Font-Bold="true">

                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label65" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField SortExpression="Years" DataField="Years" HeaderText="Years"
                                                    HeaderStyle-Font-Names="Calibri"
                                                    ItemStyle-Font-Names="Calibri"></asp:BoundField>
                                                <asp:BoundField SortExpression="DomainName" DataField="DomainName" HeaderText="DomainName"
                                                    HeaderStyle-Font-Names="Calibri"
                                                    ItemStyle-Font-Names="Calibri"></asp:BoundField>
                                                <asp:BoundField DataField="domain_id" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                <asp:BoundField DataField="InvoiceSetting_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Lk2" runat="server" CommandArgument='<%# Eval("domain_id") %>' CommandName="delete" CausesValidation="false" Height="15px" Width="15px"><i class="icon-delete  red"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                            </Columns>


                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>" SelectCommand="efawatercomInvoices" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="projectinput1" PropertyName="Text" Name="Admin_ID" Type="Int32"></asp:ControlParameter>

                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2"  ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="domains_per_Admin" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="projectinput1" PropertyName="Text" Name="admin_ID" Type="String"></asp:ControlParameter>
                                            </SelectParameters>
                                                </asp:SqlDataSource>
                                               <asp:LinkButton ID="LK2" CssClass="btn btn-warning" runat="server" Visible="false" ValidationGroup="A" OnClick="LK2_Click"><i class="icon-edit"></i> Update Current invoice</asp:LinkButton>
                               <br />
                                    
<asp:Label ID="Label4" Visible="True" Font-Size="Medium" runat="server" ForeColor="Red" ></asp:Label>
                                        <asp:GridView EnableSortingAndPagingCallbacks="false" Visible="false" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="SqlDataSource2" runat="server">

                                            <Columns>


                                                <asp:TemplateField HeaderText="Select to add">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ck" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Years">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="DDl" CssClass="form-control" CausesValidation="false" Enabled="true" runat="server">
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                <asp:BoundField HeaderText="Domain" DataField="Domain_name" SortExpression="domain_name"></asp:BoundField>
    

                                            </Columns>
                                        </asp:GridView>
                                               <asp:LinkButton ID="adddomains" CssClass="btn btn-danger" runat="server" Visible="false" ValidationGroup="A" OnClick="adddomains_Click"><i class="icon-plus"></i> add to Current invoice</asp:LinkButton>
                             
                                                     </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </div>

                                    <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="selectSettingsdet" SelectCommandType="StoredProcedure"  DeleteCommand="delete_domainfromInvoice" DeleteCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter SessionField="invoiceid" DefaultValue="" Name="setting_id" Type="Int32"></asp:SessionParameter>
                                        </SelectParameters>
                                        <DeleteParameters>
                                            <asp:SessionParameter SessionField="DID" DefaultValue="" Name="domain_id" Type="Int32"></asp:SessionParameter>
                                       
                                        </DeleteParameters>
                                    </asp:SqlDataSource>
                                    <!--selectSettings-->

                                </div>


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
    </div>


</asp:Content>
