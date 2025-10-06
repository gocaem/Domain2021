<%@ Page Title="Prepare Invoice" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="InvoiceSetting.aspx.vb" Inherits="Domain2021.InvoiceSetting" ViewStateEncryptionMode="Always" %>

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
                                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="btn btn-info" Visible="false">Update Or prepare new invoice<i class="icon-search"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="btn btn-danger" Visible="false">Delete Current invoice<i class="icon-alert"></i></asp:LinkButton><br />
                                                        <br />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                               <%--         <asp:UpdateProgress ID="updProgress" DisplayAfter="1" AssociatedUpdatePanelID="up" runat="server">
                                            <ProgressTemplate>
                                                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                                                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Admins/app-assets/images/l.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 10%; left: 10%;" />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="up" runat="server">
                                            <ContentTemplate>--%>

                                                <asp:Label ID="Label1" Visible="True" CssClass="label black" Font-Size="Medium" runat="server" Text="Currently Available invoice"></asp:Label><br />
                                                <br />
                                                <asp:GridView Visible="false"  DataKeyNames="Domain_id"  AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand" >

                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="delete" CssClass="btn btn-danger" runat="server" CommandArgument='<%# Eval("Domain_id") %>' CommandName="ddelete"><i class="icon-delete"></i> </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                        <HeaderStyle CssClass="hideGridColumn" />
                                                        <ItemStyle CssClass="hideGridColumn" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain" DataField="domain_name" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Years" DataField="Years" SortExpression="Years"></asp:BoundField>
                                                        <asp:BoundField HeaderText="ID" DataField="id" SortExpression="Years" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                        <HeaderStyle CssClass="hideGridColumn" />
                                                        <ItemStyle CssClass="hideGridColumn" />
                                                        </asp:BoundField>
                                                        

                                                    </Columns>
                                                   
                                                </asp:GridView><asp:Label ID="Label2" Visible="True"  Font-Size="Medium" runat="server"  ForeColor="Red"></asp:Label><br />
                                           
                                                <asp:GridView   AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView1" CssClass="table table-responsive" DataSourceID="SqlDataSource1" runat="server">

                                                    <Columns>


                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ck" type="button" data-toggle="modal" runat="server" CssClass="checkbox" AutoPostBack="true"></asp:CheckBox>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Years">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DDl" CssClass="form-control" CausesValidation="false" Enabled="true" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain" DataField="domain_name" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="End_date" DataField="End_date" SortExpression="End_date"></asp:BoundField>
                                                        <asp:BoundField HeaderText="status" DataField="status" SortExpression="status" ItemStyle-Wrap="true"></asp:BoundField>
                                                        <asp:BoundField HeaderText="owner name" DataField="owner_name" SortExpression="owner_name" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                     

                                                    </Columns>
                                                </asp:GridView>
                                                <asp:LinkButton ID="LK2" CssClass="btn btn-warning" runat="server" Visible="false" ValidationGroup="A" OnClick="LK2_Click"><i class="icon-edit"></i> Update Current invoice</asp:LinkButton>
                                       <%--     </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="PageIndexChanging" ControlID="GridView1" />
                                                <asp:PostBackTrigger  ControlID="GridView2" />
                           
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="domains_per_Admin2" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="projectinput1" PropertyName="Text" Name="admin_ID" Type="String"></asp:ControlParameter>

                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="selectSettings2" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="projectinput1" PropertyName="Text" Name="Admin_ID" Type="String"></asp:ControlParameter>
                                            <asp:Parameter Direction="Output" Name="msg" Size="100" DbType="String" />
                                        </SelectParameters>
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
