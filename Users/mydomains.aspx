<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="mydomains.aspx.vb" Inherits="Domain2021.mydomains" ViewStateEncryptionMode="Always" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <style type="text/css">
        @import url('https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.css');

        .blink {
            animation: blink 2s steps(5, start) infinite;
            -webkit-animation: blink 1s steps(5, start) infinite;
        }

        @keyframes blink {
            to {
                visibility: hidden;
            }
        }

        @-webkit-keyframes blink {
            to {
                visibility: hidden;
            }
        }
           .GridHeader table th {
            text-align: center !important;
        }
       .GridHeader .headRowSortAsc  > th > a  {
    display: inline-block;
    padding-left: 35px;
    background: url('down-sort.png') no-repeat;
    background-size: 15px;
    background-size: contain;
    text-decoration: none;
    vertical-align: central;
}

.GridHeader .headRowSortDesc  > th > a  {
    display: inline-block;
    padding-left: 35px;
    background: url('up-sort.png') no-repeat;
    background-size: 15px;
    background-size: contain;
    text-decoration: none;
    vertical-align: central;
}
.GridHeader .headRowSortable > th > a {
        display: inline-block;
        padding-left: 35px;
        background: url('up-down.png') left center no-repeat;
        background-size: contain;
        text-decoration: none;
        vertical-align: central;
        font-weight:normal;
    }

    </style>


    <table id="tabel1" runat="server" border="0" style="width: 100%;" align="center;">
        <tr>

            <td id="td1" align="center">


                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>


                <br />
                <br />
                <br />

                <p
                    style="text-align: center; font-weight: bold; font-size: Large; width: 70%;">
                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>

                </p>
                <br />

                                   
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card" style="width:60%">
                        <div class="row" >
                            <div class="col-lg-4 col-md-4"></div>
                            <div class="col-lg-4 col-md-4"><br />
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" ></asp:Label><br /><br />
                                    <asp:Label ID="Label5" runat="server" Font-Bold="false" ></asp:Label>
                                <asp:TextBox class="form-control" AutoPostBack="true" runat="server"  OnTextChanged="Search"  id="domainname" type="text" placeholder="Search.."></asp:TextBox>
                            </div>
                            <div class="col-lg-4 col-md-4"></div>
                        </div>
                         <div class="row">
                            <div class="col-lg-4 col-md-4"></div>
                            <div class="col-lg-4 col-md-4">
                                <asp:Label ID="Label3" runat="server" Font-Bold="false" ></asp:Label>
                                <asp:TextBox class="form-control" AutoPostBack="true"  runat="server"  OnTextChanged="Search"  id="startdate" type="Date" placeholder="Search.."></asp:TextBox>
                            </div>
                            <div class="col-lg-4 col-md-4"></div>
                        </div>
                           <div class="row">
                            <div class="col-lg-4 col-md-4"></div>
                            <div class="col-lg-4 col-md-4">
                                <asp:Label ID="Label4" runat="server" Font-Bold="false" ></asp:Label>
                                <asp:TextBox class="form-control" AutoPostBack="true" runat="server"  OnTextChanged="Search"  id="enddate" type="Date" placeholder="Search.."></asp:TextBox>
                            </div>
                            <div class="col-lg-4 col-md-4"></div>
                        </div><br> <br></div>
                        <div class="GridHeader"> <br>
                              <asp:LinkButton ID="HideInfo" runat="server" OnClick="HideInfo_Click"><i class="fa fa-eye" ></i></asp:LinkButton> <asp:Label ID="hideall" runat="server"  Font-Bold="false"></asp:Label>
               
                        <asp:GridView id="dg" Font-Bold="true" ClientIDMode="Static" AllowSorting="true"   Width="80%" AllowPaging="True"  AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-strid" OnSorting="OnSorting"     HeaderStyle-CssClass ="headRowSortable" >

                            <Columns>
                                <asp:TemplateField>
                                    
                                    <ItemTemplate>
                                        <asp:Label ID="Seq" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="Domain_name" HeaderText="Domain_name" HeaderStyle-Font-Names="cairo" SortExpression="Domain_name">
                                    <HeaderStyle Font-Names="cairo" />
                                </asp:BoundField>
                                <asp:BoundField  DataField="Reg_date" HeaderText="Registration Date" HeaderStyle-Font-Names="cairo" SortExpression="Reg_date">
                                    <HeaderStyle Font-Names="cairo" />
                                </asp:BoundField>
                                <asp:BoundField DataField="end_date" HeaderText="Expiry Date" SortExpression="end_date"></asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lk" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="det" CausesValidation="false" Height="15px" Width="15px" CssClass="fa fa-upload blink"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                   <asp:TemplateField >
                                 <ItemTemplate>
                                        <asp:LinkButton ID="Lk3" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="hide" CausesValidation="false" Height="15px" Width="25px" CssClass="fa fa-eye"> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lk2" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="Papers" CausesValidation="false" Height="15px" Width="15px" CssClass="fa fa-upload blink"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>

                             
                                   <asp:BoundField DataField="Status_ID" HeaderText="Status"  ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                  <asp:BoundField DataField="HideInfo" HeaderText="HideInfo"  ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                    
                            </Columns>
                         
                        </asp:GridView></div>
                              <asp:GridView id="GridView1" Font-Bold="true" ClientIDMode="Static"  Width="80%"  Visible="false"  AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-strid" OnSorting="OnSorting"     HeaderStyle-CssClass ="headRowSortable" >

                            <Columns>
                                <asp:TemplateField>
                                    
                                    <ItemTemplate>
                                        <asp:Label ID="Label64" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="Domain_name" HeaderText="Domain_name" HeaderStyle-Font-Names="cairo">
                                    <HeaderStyle Font-Names="cairo" />
                                </asp:BoundField>
                                <asp:BoundField  DataField="Reg_date" HeaderText="Registration Date" HeaderStyle-Font-Names="cairo">
                                    <HeaderStyle Font-Names="cairo" />
                                </asp:BoundField>
                                <asp:BoundField DataField="end_date" HeaderText="Expiry Date" SortExpression="end_date"></asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status" ></asp:BoundField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lk" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="det" CausesValidation="false" Height="15px" Width="15px" CssClass="fa fa-upload blink"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                   <asp:TemplateField >
                                 <ItemTemplate>
                                        <asp:LinkButton ID="Lk3" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="hide" CausesValidation="false" Height="15px" Width="25px" CssClass="fa fa-eye"> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lk2" runat="server"  CommandArgument='<%# Eval("Domain_ID") %>'  CommandName="Papers" CausesValidation="false" Height="15px" Width="15px" CssClass="fa fa-upload blink"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>

                             
                                   <asp:BoundField DataField="Status_ID" HeaderText="Status"  ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                  <asp:BoundField DataField="HideInfo" HeaderText="HideInfo"  ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                    
                            </Columns>
                         
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dg" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="domainname" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="enddate" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="startdate" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="card w-50" id="exportcard" runat="server" visible="false">
  <div class="card-body" >
    <h5 class="card-title" id="cardtitle" runat="server" style="font-weight:bold">Card title</h5>
    <p class="card-text" id="cardtext" runat="server">With supporting text below as a natural lead-in to additional content.</p>
      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imags/excel.png" Width="50px" OnClick="ImageButton1_Click"  />
  </div>
</div>
                <p
                    style="text-align: center; font-weight: bold; font-size: medium; color: #993333; width: 50%;">

                    <asp:Label Font-Names="verdana" Font-Size="Medium" ForeColor="Red" Font-Bold="true" ID="lbl_error" runat="server"></asp:Label>

                </p>
                <table cellspacing="1" style="width: 50%">
                    <tr>
                        <td id="ttd1" runat="server">

                            <p
                                style="text-align: center; font-weight: bold; font-size: medium; color: #993333;">
                                <b style="font-size: medium">
                                    <br />
                                    <br />
                                    <asp:Label ForeColor="#009900" ID="Label2" runat="server" Font-Bold="False"></asp:Label>

                                </b>

                            </p>
                        </td>
                    </tr>
                    <p
                        style="text-align: center; font-weight: bold; font-size: medium; color: #993333; width: 815px;">
                        &nbsp;
                    </p>

                    <tr>
                        <td id="ttd" runat="server">
                            <asp:Label ID="Label43" runat="server" ForeColor="red" Font-Bold="true" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>



</asp:Content>
