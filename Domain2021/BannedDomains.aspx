<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="BannedDomains.aspx.vb" Inherits="Domain2021.BannedDomains" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        .GridHeader table th {
            text-align: center !important;
        }

        @-webkit-keyframes blink {
            to {
                visibility: hidden;
            }
        }
    </style>



                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>


                <br />
                <br />
                <br />

                <div class="row" id="row1" runat="server">
                   
                           <div class="col-lg-4 col-md-4"></div>
                    <div class="col-lg-8 col-md-8"> <br />
                         <asp:Label ID="headerLabel1" runat="server" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                       </div>
            
                </div>
                   
              <div class="row" id="row2" runat="server">
                   
                         <div class="col-lg-3 col-md-3"></div>
                    <div class="col-lg-8 col-md-8"> <br />
                         <asp:Label ID="headerLabel2" runat="server" Font-Size="Medium" Font-Bold="false"></asp:Label>
                                       </div>
               <div class="col-lg-1 col-md-1"></div>
                </div>

                <br />


                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
           
                <div class="row">
                    <div class="col-lg-4 col-md-4"></div>
                    <div class="col-lg-4 col-md-4">
                    <asp:TextBox class="form-control" AutoPostBack="true" runat="server" OnTextChanged="Search" ID="textID" type="text" placeholder="Search.."></asp:TextBox>
                    </div>
                    <div class="col-lg-4 col-md-4"></div>
                </div>
                <br>  <div class="row">
                        <div class="col-lg-2 col-md-2"></div>
                    <div class="col-lg-8 col-md-8">
                <div class="GridHeader">
                <asp:GridView ID="dg" Font-Bold="true"  ClientIDMode="Static" Width="100%" AllowPaging="True" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered table-strid" OnRowDataBound="dg_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="seq" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DomainName" HeaderText="DomainName" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>

                    </Columns>

                </asp:GridView> </div></div>
                    <div class="col-lg-2 col-md-2"></div>
                       </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dg" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="textID" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <p
                    style="text-align: center; font-weight: bold; font-size: medium; color: #993333; width: 50%;">

                    <asp:Label  Font-Size="Medium" ForeColor="Red" Font-Bold="true" ID="lbl_error" runat="server"></asp:Label>

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



</asp:Content>

