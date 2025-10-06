<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ApproveUpdate.aspx.vb" Inherits="Domain2021.ApproveUpdate" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>
       <script>
           $(document).ready(function () {
               var collapse = document.getElementById("Approve")
               collapse.className = "sidebar-submenu menu-open";
               collapse.style.display = "block";

           });
       </script>
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <asp:Label ID="result" ForeColor="red" runat="server" ></asp:Label>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Approve Domain's Update</p>
                                                <asp:DataGrid ID="dg" runat="server" Font-Names="Calibri" Width="100%" AutoGenerateColumns="False" CellPadding="0" GridLines="None" CssClass="table table-responsive" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" OnItemCommand="dg_ItemCommand">


                                                    <Columns>

                                                        <asp:TemplateColumn HeaderText="Domain Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl" runat="server" Text='<%# Eval("Domain_name") %>' Font-Names="Calibri"> </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="second_domain" HeaderText="TLD">

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="org_name" HeaderText="Owner Name"></asp:BoundColumn>

                                                        <asp:TemplateColumn HeaderText="Compare">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton21" runat="server" CommandName="Compare"> <i class="fa fa-copy" style="color:darkslateblue"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                        <asp:TemplateColumn HeaderText="Approve">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Approve"><i class="fa fa-check-circle" style="color:green"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="Domain_ID"></asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Reject">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="NotApprove"> <i class="fa fa-times" style="color:red"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                    </Columns>

                                                </asp:DataGrid></p>
                                                <asp:Label runat="server" Text="Label" ID="DomainID" Visible="false"></asp:Label>
                                                <asp:Label runat="server" Text="Label" ID="Email" Visible="false"></asp:Label>
                                                 <table align="center" cellpadding="0" class="auto-style1" id="tab1" runat="server" visible="false">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="Reason of Cancelation"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" runat="server" Height="135px" TextMode="MultiLine" Width="467px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                 
                                                </table>
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
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>


    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>


</asp:Content>
