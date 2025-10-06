<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ExpiredDomains.aspx.vb" Inherits="Domain2021.ExpiredDomains" ViewStateEncryptionMode="Always" %>

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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Expired Domains</p>
                                        <div>

                                            <hr />
                                            <div class="form-body table" style="padding-left: 20px">
                                                <h4 class="form-section"><i class="icon-search"></i>Search to send</h4>
                                                <hr />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <label for="projectinput1">Month of the Year</label>
                                                        <asp:DropDownList ID="ddl" runat="server" CssClass="form-control" Width="100" Height="30">
                                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                           <div class="form-group">
                                                        <label for="projectinput1"> Year</label>
                                                             <asp:DropDownList ID="Years" runat="server" CssClass="form-control" Width="100" Height="30">
                                                           
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <hr />
                                                <div class="row">
                                                    <div class="form-group">

                                                        <asp:LinkButton ID="LK" CssClass="btn btn-info" runat="server" ValidationGroup="A" OnClick="LK_Click"><i class="icon-search"></i>Search </asp:LinkButton>

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

                                                <asp:Label ID="Label1" Visible="false" CssClass="label black" Font-Size="Medium" runat="server" Text="Currently Available invoice"></asp:Label><br />
                                                <br />
                                                <asp:GridView DataKeyNames="Domain_id"  AllowPaging="True" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" ID="GridView2" CssClass="table table-responsive"  OnPageIndexChanging="GridView2_PageIndexChanging" runat="server" >

                                                    <Columns>
                                           
                                                        <asp:BoundField HeaderText="ID" DataField="Domain_id" SortExpression="Domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="ID" DataField="Serial" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Billing Email" DataField="BillingEmail" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Admin Email" DataField="AdminEmail" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Org Email" DataField="org_email" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Domain Name" DataField="domain_name" SortExpression="domain_name"></asp:BoundField>
                                                        <asp:BoundField HeaderText="End Date" DataField="end_date1" SortExpression="end_date"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Renew Value" DataField="renewvalue" SortExpression="end_date" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="USD Value" DataField="ValueUSD" SortExpression="end_date" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                        <asp:BoundField HeaderText="USD Value" DataField="Admin_id" SortExpression="Admin_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>


                                                    </Columns>
                                                </asp:GridView>

                                                <asp:LinkButton ID="LK2" CssClass="btn btn-warning" runat="server" Visible="false" ValidationGroup="A" OnClick="LK2_Click"><i class="icon-edit"></i> Update Current invoice</asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="PageIndexChanging" ControlID="GridView2" />

                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                            

                             

                                </div>


                                <div class="card-footer">
                                    <div class="row">
                                        <div class="form-group" style="padding-left:20px">

                                            <label for="projectinput1">Email Language</label>
                                            <asp:RadioButtonList ID="LangFlag" RepeatDirection="Horizontal" runat="server" Width="300">
                                                <asp:ListItem Value="1" Text="Arabic"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="English" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left:20px">

                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" ValidationGroup="A" OnClick="LinkButton1_Click"><i class="icon-envelop"></i>Send Invoices </asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                  </section></div>
              
            </div>
        </div>
    </div>
  
</asp:Content>
