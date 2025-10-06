<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ManageEmail.aspx.vb" Inherits="Domain2021.ManageEmail" ViewStateEncryptionMode="Always" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
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
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="card-body collapse in">
                                            <div class="card-block card-dashboard">
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Email Text</p>
                                                 <asp:Label ID="Label1" runat="server"  ForeColor="Red"></asp:Label>
                                                     <asp:DataGrid ID="DataGrid1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"  GridLines="None" CssClass="table">
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="id" HeaderText="Email ID"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="title" HeaderText="Email Title"></asp:BoundColumn>
                                                                    <asp:TemplateColumn HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="E"> Edit</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                  
                                                                </Columns>
                                                            </asp:DataGrid>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="e_mail_textUpdate" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                
                                            </div>

                                              <ul class="nav nav-tabs" role="tablist" id="tablist" runat="server" visible="true">
                                                <li class="nav-item">
                                                    <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab">Part (1)</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#tabs-5" id="ttab5" runat="server" role="tab">Part (2)</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#tabs-2" role="tab">Part (3)</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#tabs-3" role="tab">Part (4)</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#tabs-4" role="tab">Part (5)</a>
                                                </li>

                                            </ul>
                                            <!-- Tab panes -->
                                            <div class="tab-content" id="ttab1" style="width: 70%; height: 100%" runat="server">
                                                <div class="tab-pane active" id="tabs-1" role="tabpanel" width="70%">
                                                  
                                                      <cc1:Editor ID="Editor1" runat="server" width="700px" height="700px"></cc1:Editor>
                                                </div>
                                                <div class="tab-pane" id="tabs-5" role="tabpanel" style="background-color: cornflowerblue; height:auto" >
                                       
                                                      <cc1:Editor ID="Editor5" runat="server" width="700px" height="700px"></cc1:Editor>

                                                </div>
                                                <div class="tab-pane" id="tabs-2" role="tabpanel" style="background-color: cornflowerblue">
                                                     <cc1:Editor ID="Editor2" runat="server" width="700px" height="700px"></cc1:Editor>
                                                </div>

                                                <div class="tab-pane" id="tabs-3" role="tabpanel" style="background-color: cornflowerblue;height:auto">
                                                    <cc1:Editor ID="Editor3" runat="server" width="700px" height="700px"></cc1:Editor>

                                                </div>
                                                <div class="tab-pane" id="tabs-4" role="tabpanel" style="background-color: cornflowerblue;height:auto">
                                                      <cc1:Editor ID="Editor4" runat="server" width="700px" height="700px"></cc1:Editor>

                                                </div>

                                            </div>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A" ShowMessageBox="true" />

                                            <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                            <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                            <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>
                                         <br /><br />  <br /><br />   <br /><br />      <div class="card-footer">
                                                <div class="">
                                                    <asp:Button ID="Update" runat="server" Text="update" CssClass=" form-group btn btn-green" Width="50%" ValidationGroup="A" Visible="True" OnClick="Update_Click1"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                          </ContentTemplate>
                               
                                </asp:UpdatePanel>
                            </div>
                    </section>
                    <div class="card-footer">
                        <div class="">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    

</asp:Content>
