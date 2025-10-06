<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="Invoice.aspx.vb" Inherits="Domain2021.Invoice" ViewStateEncryptionMode="Always" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="tabel1" runat="server" border="0" style="width: 100%; font-family: Calibri" align="center;">
        <tr>
            <td id="td1" align="center">


                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>




                <p style="text-align: center; font-weight: bold; font-size: Large; width: 70%;">
                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>

                </p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <section id="post_job" runat="server">
                            <div class="vertical-space-100"></div>

                            <asp:Label ID="Label4" runat="server"
                                ForeColor="Blue"></asp:Label>
                            <div class="container table-bordered">
                                <br />
                                <div class="card-header rounded" id="HLabel1" runat="server">
                                </div>

                                <div class="job-post-box">
                                    <div class="vertical-space-30"></div>

                                    <div class="row" id="row2" runat="server" style="border: solid; border-radius: 3px 4px; border-width: 1px; border-collapse: collapse; border-color: lightgray; padding-top: 15px">
                                        <div class="col-lg-7 col-md-7">
                                            <br />
                                            <label for="exampleInputCompany" id="Label1" runat="server">Domain Name</label>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        <div class="col-lg-4 col-md-4"></div>
                                                        <div class="col-lg-8 col-md-8">
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="true"></asp:Label>
                                                            <asp:TextBox class="form-control" AutoPostBack="true" runat="server" OnTextChanged="Search" ID="textID" type="text" placeholder="Search.."></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <br>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12" style="text-align: center">
                                                            <asp:GridView ID="dg" OnSorting="dg_Sorting" Width="100%" ClientIDMode="Static" AllowSorting="true"  AllowPaging="True" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-striped">

                                                                <Columns>
                                                                    <asp:TemplateField>

                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label64" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField SortExpression="Domain_name"  DataField="Domain_name" HeaderText="Domain_name" HeaderStyle-Font-Names="cairo">
                                                                        <HeaderStyle Font-Names="cairo" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="end_date" HeaderText="end_date" SortExpression="end_date"></asp:BoundField>
                                                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ck" runat="server" AutoPostBack="true" OnCheckedChanged="ck_CheckedChanged"  CausesValidation="false" Height="15px" Width="15px"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None">
                                                                        <FooterStyle CssClass="hidden" />
                                                                        <HeaderStyle CssClass="hidden" />
                                                                        <ItemStyle BorderStyle="None" CssClass="hidden" Width="0px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Status_ID" HeaderText="Status" SortExpression="Status_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:TemplateField>

                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="years" runat="server" Width="50px">
                                                                                <asp:ListItem Value="1"></asp:ListItem>
                                                                                <asp:ListItem Value="2"></asp:ListItem>
                                                                                <asp:ListItem Value="3"></asp:ListItem>
                                                                                <asp:ListItem Value="4"></asp:ListItem>
                                                                                <asp:ListItem Value="5"></asp:ListItem>
                                                                                <asp:ListItem Value="6"></asp:ListItem>
                                                                                <asp:ListItem Value="7"></asp:ListItem>
                                                                                <asp:ListItem Value="8"></asp:ListItem>
                                                                                <asp:ListItem Value="9"></asp:ListItem>
                                                                                <asp:ListItem Value="10"></asp:ListItem>
                                                                                <asp:ListItem Value="11"></asp:ListItem>
                                                                                <asp:ListItem Value="12"></asp:ListItem>
                                                                                <asp:ListItem Value="13"></asp:ListItem>
                                                                                <asp:ListItem Value="14"></asp:ListItem>
                                                                                <asp:ListItem Value="15"></asp:ListItem>
                                                                                <asp:ListItem Value="16"></asp:ListItem>
                                                                                <asp:ListItem Value="17"></asp:ListItem>
                                                                                <asp:ListItem Value="18"></asp:ListItem>
                                                                                <asp:ListItem Value="19"></asp:ListItem>
                                                                                <asp:ListItem Value="20"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Domain_ID" HeaderText="Domain_ID" SortExpression="Status_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>

                                                                </Columns>

                                                            </asp:GridView>
                                                            <asp:LinkButton ID="lkb" runat="server" class="btn btn-success" OnClick="lkb_Click">Insert to current invoice</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="card text-center">
                                                        <br />
                                                        <div class="card-header">
                                                            Current Available Invoice
                                                        </div>
                                                        <div class="card-body">
                                                            <h5 class="card-title"></h5>
                                                            <p class="card-text" id="current" runat="server">With supporting text below as a natural lead-in to additional content.</p>
                                                            <asp:Label ID="Label3" runat="server"
                                                                ForeColor="Red"></asp:Label>
                                                            <asp:GridView ID="invisiblegrid" DataKeyNames="Domain_ID" Width="100%" AllowPaging="false" Visible="false" ClientIDMode="Static" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-condensed">

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="#">

                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label68" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField SortExpression="Domain_name" DataField="DomainName" HeaderText="Domain_name" HeaderStyle-Font-Names="cairo">
                                                                        <HeaderStyle Font-Names="cairo" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Years" HeaderText="Years" SortExpression="Years"></asp:BoundField>
                                                                    <asp:BoundField DataField="Domain_ID" HeaderText="Domain_ID" SortExpression="Domain_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                                                    <asp:TemplateField>

                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="delete" CommandName="del" CommandArgument='<%#Eval("Domain_ID") %>' runat="server" ForeColor="Red"><i class="fa fa-trash"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="invoicesetting_id" HeaderText="invoicesetting_id" SortExpression="Domain_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                                                     <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>

                                                                </Columns>

                                                            </asp:GridView>
                                                                <br />   <asp:LinkButton ID="lkDel" Visible="false"  runat="server" class="btn btn-danger" OnClick="lkDel_Click">Delete current unpaid invoice</asp:LinkButton>
                                
                                                            <asp:GridView ID="GridView1" DataKeyNames="Domain_ID" Width="100%" AllowPaging="true" ClientIDMode="Static" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-condensed">

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="#">

                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label68" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField SortExpression="Domain_name" DataField="DomainName" HeaderText="Domain_name" HeaderStyle-Font-Names="cairo">
                                                                        <HeaderStyle Font-Names="cairo" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Years" HeaderText="Years" SortExpression="Years"></asp:BoundField>
                                                                    <asp:BoundField DataField="Domain_ID" HeaderText="Domain_ID" SortExpression="Domain_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                                                    <asp:TemplateField>

                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="delete" CommandName="del" CommandArgument='<%#Eval("Domain_ID") %>' runat="server" ForeColor="Red"><i class="fa fa-trash"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="invoicesetting_id" HeaderText="invoicesetting_id" SortExpression="Domain_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>

                                                                </Columns>

                                                            </asp:GridView>
                                                        </div>
                                                        <div class="card-footer text-muted">
                                                            <asp:Label Font-Names="Calibri" Font-Size="Medium" ForeColor="Red" Font-Bold="true" ID="Label6" runat="server"></asp:Label>

                                                        </div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                </ContentTemplate>

                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="dg" EventName="RowCommand" />
                                                    <asp:AsyncPostBackTrigger ControlID="textID" EventName="TextChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>





                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <asp:Label ID="Label8" Visible="false" runat="server" Text="Label"></asp:Label>
                                <br />
                        </section>
                        </center>
                    <p
                        style="text-align: center; font-weight: bold; font-size: medium; color: #993333; width: 50%;">
                    </p>
                    </ContentTemplate>

                </asp:UpdatePanel>


            </td>
        </tr>
    </table>

</asp:Content>
