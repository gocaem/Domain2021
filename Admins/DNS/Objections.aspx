<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Objections.aspx.vb" Inherits="Domain2021.Objections" %>

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
                                            <div class="card-block card-dashboard">  <asp:Label ID="lbl_result" runat="server" ForeColor="Red"></asp:Label>
                                                <p class="card-text text-bold-900" style="font-size: 16px">Approve Objections </p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        <asp:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" CellPadding="0" HeaderStyle-Font-Bold="false"
                                                            GridLines="None" Width="100%" Font-Bold="true" CssClass="table table-responsive" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False">

                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="Details">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk" runat="server" CommandName="view"><i class="fa fa-info-circle" style="color:black"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="Domain_name" HeaderText="Domain_name">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                                </asp:BoundColumn>

                                                                <asp:BoundColumn DataField="REG_DATE" HeaderText="Registration Date">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>

                                                                <asp:BoundColumn DataField="ADMIN_CONTACT" HeaderText="Admin Contact">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>

                                                                <asp:BoundColumn DataField="Objection" HeaderText="Admin Contact">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                     <asp:BoundColumn DataField="id" HeaderText="Admin Contact">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                  <asp:BoundColumn DataField="Email" HeaderText="Email">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:TemplateColumn HeaderText="Approve">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk2" runat="server" CommandName="Approve"><i class="fa fa-check-circle" style="color:green"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Reject">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Reject"><i class="fa fa-delete-left" style="color:red"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Papers">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paper"><i class="fa fa-file" style="color:blue"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="Domain_id" HeaderText="Domain_id">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                         <div class="row"><asp:Label ID="headerlbl" runat="server" Text="Please fill the reason of rejection" Visible="false" ></asp:Label> <br />
                                                             <asp:TextBox ID="Reasons" CssClass="form-control" Visible="false" runat="server" TextMode="MultiLine" Rows="20" Columns="20"></asp:TextBox>
                                                             <asp:Button ID="ar" runat="server" Visible="false" Text="Reject and SendAREmail" CssClass="btn btn-green" OnClick="ar_Click"  ValidationGroup="a" />&nbsp;&nbsp;
                                                             <asp:Button ID="en" runat="server" Text="Reject and SendEnEmail" Visible="false" CssClass="btn btn-red" OnClick="en_Click" ValidationGroup="a"  />
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Reasons" runat="server" ErrorMessage="Reason Required" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator></div>
                                                        <div class="row">
                                                            <asp:TextBox ID="Details" CssClass="form-control" Visible="false" runat="server" TextMode="MultiLine" Rows="30" Columns="20"></asp:TextBox>

                                                         
                                                                <asp:GridView runat="server" HeaderStyle-HorizontalAlign="Center" DataKeyNames="id" ID="docgrid" AutoGenerateColumns="False" DataSourceID="documents" CssClass="table table-responsive" Font-Bold="False" BorderStyle="None">
                                                                    <columns>
                                                                        <asp:TemplateField>
                                                                            <itemtemplate>
                                                                                <asp:HyperLink ID="files" Text='<%#Eval("SupportedDoc") %>' runat="server" NavigateUrl='<%# "../../SupportDOC/" + Eval("SupportedDoc") %>' Target="_blank" style="font-weight: normal;width:100%"></asp:HyperLink>
                                                                            </itemtemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="SupportedDoc" HeaderText="SupportedDoc" SortExpression="SupportedDoc" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="SupportedDoc" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>

                                                                    </columns>
                                                                </asp:GridView>
                                                         
                                                            <asp:SqlDataSource runat="server" ID="documents" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="selectObjection_SupportedDoc" SelectCommandType="StoredProcedure">
                                                                <SelectParameters>
                                                                    <asp:SessionParameter SessionField="id" Name="id" Type="Int32"></asp:SessionParameter>
                                                                </SelectParameters>

                                                            </asp:SqlDataSource>
                                                        </div>
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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dg" EventName="ItemCommand"  />
        </Triggers>
    </asp:UpdatePanel>
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all" />
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all" />


    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all" />

    <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>

</asp:Content>

