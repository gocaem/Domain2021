<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Approve.aspx.vb" Inherits="Domain2021.Approve" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <script>
               $(document).ready(function () {
                   var collapse = document.getElementById("Approve")
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Approve Domain's Data</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        <asp:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                                            GridLines="None" Width="100%" Font-Bold="true" CssClass="table table-responsive" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False">
                                                          
                                                                    <Columns>
                                                                       <asp:TemplateColumn HeaderText="Domain Name">
                                                                            <ItemTemplate>
                                                                                <asp:linkbutton ID="lk" runat="server" CommandName="view" Text='<%# Eval("Domain_name") %>'></asp:linkbutton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="second_domain" HeaderText="TLD">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                                </asp:BoundColumn>     
                                                                    
                                           
                                                                <asp:BoundColumn DataField="org_name" HeaderText="Owner Name">
                                                                    <HeaderStyle HorizontalAlign="Center"  VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="NationalNo" HeaderText="National No">
                                                                    <HeaderStyle HorizontalAlign="Center"  VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Domain_id" HeaderText="Domain ID">
                                                                    <HeaderStyle HorizontalAlign="Center"  VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                  <asp:TemplateColumn HeaderText="Approve/Reject" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lk2" runat="server" CommandName="Approve" Text='<%# Eval("Domain_id") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                           
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


   
</asp:Content>
