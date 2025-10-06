<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ActivateThis.aspx.vb" Inherits="Domain2021.ActivateThis" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                            <div class="card-block card-dashboard" style="width:100%">
                                                <p class="card-text text-bold-900" style="font-size: 16px">Activate Domain</p>
                                            
    <asp:Label ID="lbl_Result" runat="server"  ForeColor="Red"></asp:Label><asp:Label
        ID="lbl_error" runat="server"  ForeColor="Red"></asp:Label><br />
    <asp:DataGrid ID="DataGrid1" ClientIDMode="Static" OnItemCommand="DataGrid1_ItemCommand" CssClass="table table-responsive" GridLines="None" runat="server" AutoGenerateColumns="False"  Width="100%"  Font-Names="Calibri" Font-Bold="true"  Font-Size="Small" Height="260px" >

        <Columns>
            <asp:BoundColumn DataField="DOMAIN_ID" HeaderText="DOMAIN_ID" SortExpression="DOMAIN_ID"
                Visible="False">
                <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                    Font-Strikeout="False" Font-Underline="False" />
                <HeaderStyle Width="5px" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ORG_NAME" HeaderText="Registrant" SortExpression="ORG_NAME" >
                <HeaderStyle  /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="Domain " SortExpression="DOMAIN_NAME">
                <HeaderStyle /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="1LD / 2LD" SortExpression="SECOND_DOMAIN" >
                <HeaderStyle/><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="P_SERVER_NAME" HeaderText="Primary NS" SortExpression="P_SERVER_NAME">
                <HeaderStyle  /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="P_SERVER_IP" HeaderText="IP Address" SortExpression="P_SERVER_IP" Visible="False">
                <HeaderStyle  /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="IMMEDIATE_FUTURE"  Visible="False">
                <HeaderStyle/><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="S_SERVER_NAME" HeaderText="Secondary NS" SortExpression="S_SERVER_NAME">
                <HeaderStyle /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="S_SERVER_IP" HeaderText="IP Address" SortExpression="S_SERVER_IP" Visible="False">
                <HeaderStyle /><ItemStyle HorizontalAlign=Center />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Action">
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="Ok">Ok</asp:ListItem>
                        <asp:ListItem Value="Cancel">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate></asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="is it Test">
                <ItemTemplate>
                    <asp:CheckBox ID="ck" runat="server" Text="Yes">
                    </asp:CheckBox>
                </ItemTemplate></asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Name servers">
                  <ItemTemplate>
                    <asp:Linkbutton ID="lk1" ClientIDMode="Static" runat="server"   CausesValidation="false" Text="all name servers" CommandName="more">
                     </asp:Linkbutton>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Status_ID" HeaderText="Status" SortExpression="Status_ID"
                Visible="False">
                <HeaderStyle />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Comment">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Comment" runat="server" TextMode="MultiLine" Height="97px" Width="85px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle  />
            </asp:TemplateColumn>
        </Columns>
   
    </asp:DataGrid><br />
    <br />
    <asp:Button ID="BTN_UPDATE" runat="server" Text="Update" Visible="False" CssClass="btn btn-info" /><asp:DataGrid CssClass="table table-responsive"
        ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="2"  Font-Size="X-Small" ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
        <Columns>
            <asp:BoundColumn DataField="DOMAIN_ID" HeaderText="DOMAIN_ID" SortExpression="DOMAIN_ID"
                Visible="False"></asp:BoundColumn>
            <asp:BoundColumn DataField="ORG_NAME" HeaderText="Registrant" SortExpression="ORG_NAME">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="IMMEDIATE_FUTURE" HeaderText="IMMEDIATE FUTURE" SortExpression="IMMEDIATE_FUTURE" Visible="False">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="DOMAIN NAME" SortExpression="DOMAIN_NAME">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="1LD / 2LD" SortExpression="SECOND_DOMAIN">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="P_SERVER_NAME" HeaderText="Primary NS" SortExpression="P_SERVER_NAME">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="P_SERVER_IP" HeaderText="IP Address" SortExpression="P_SERVER_IP">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="S_SERVER_NAME" HeaderText="Secondary NS" SortExpression="S_SERVER_NAME">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="S_SERVER_IP" HeaderText="IP Address" SortExpression="S_SERVER_IP">
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Ok">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="OK" />
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:BoundColumn DataField="Status_ID" HeaderText="Status_ID" SortExpression="Status_ID"
                Visible="False"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid><asp:Button ID="BTN_UPDATE_delete" runat="server" BackColor="ButtonShadow" CssClass="btn btn-info"
         ForeColor="#C00000" Text="Update Delete Item" Visible="False" />&nbsp;
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A" ShowMessageBox="true" />

                                                <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <div class="card-footer">
                                                    <div class="">
                                                        <asp:Button ID="Button1" runat="server" Text="update" CssClass=" form-group btn btn-green" Width="50%" ValidationGroup="A" Visible="false" OnClick="Button1_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        </section>

                        </div>
                    </div>
                </div>
                <div class="container">
                   
                </div>
            </div>
            <div class="modal fade" id="danger2"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-server"></i>all registered nameserver</h3>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content" id="Div2" style="width: 70%" runat="server" visible="true">
                                <div class="tab-pane active" id="tabs-1" role="tabpanel" width="70%" style="font-family: Calibri; font-weight: normal; font-size: small">

                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div3" runat="server">
                                            <div class="form-group">
                                                <label id="Label6" runat="server">
                                                    <asp:Label ID="Domain_nameL" runat="server" Text="Primary Server"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="p_name" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div4" runat="server">
                                            <div class="form-group">
                                                <label id="Label8" runat="server">
                                                    <asp:Label ID="Label9" runat="server" Text="Primary Server IP"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                            <div class="form-group">
                                                <label id="Label15" runat="server">
                                                    <asp:Label ID="Label19" runat="server" Text=" Secondary Name (1)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div6" runat="server">
                                            <div class="form-group">
                                                <label id="Label21" runat="server">
                                                    <asp:Label ID="Label29" runat="server" Text="Secondary IP (1)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div9" runat="server">
                                            <div class="form-group">
                                                <label id="Label30" runat="server">
                                                    <asp:Label ID="Label31" runat="server" Text="Secondary Name (2)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                            <div class="form-group">
                                                <label id="Label32" runat="server">
                                                    <asp:Label ID="Label33" runat="server" Text="Secondary IP (2)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                            <div class="form-group">
                                                <label id="Label37" runat="server">
                                                    <asp:Label ID="Label38" runat="server" Text="Secondary Name (3)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                            <div class="form-group">
                                                <label id="Label39" runat="server">
                                                    <asp:Label ID="Label40" runat="server" Text="Secondary IP (3)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div13" runat="server">
                                            <div class="form-group">
                                                <label id="Label41" runat="server">
                                                    <asp:Label ID="Label42" runat="server" Text="Secondary Name (4)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div14" runat="server">
                                            <div class="form-group">
                                                <label id="Label43" runat="server">
                                                    <asp:Label ID="Label44" runat="server" Text="Secondary IP (4)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div15" runat="server">
                                            <div class="form-group">
                                                <label id="Label45" runat="server">
                                                    <asp:Label ID="Label46" runat="server" Text="Secondary Name (5)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                            <div class="form-group">
                                                <label id="Label47" runat="server">
                                                    <asp:Label ID="Label48" runat="server" Text="Secondary IP (5)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                            <div class="form-group">
                                                <label id="Label49" runat="server">
                                                    <asp:Label ID="Label52" runat="server" Text="Secondary Name (6)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                            <div class="form-group">
                                                <label id="Label53" runat="server">
                                                    <asp:Label ID="Label54" runat="server" Text="Secondary IP (6)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div19" runat="server">
                                            <div class="form-group">
                                                <label id="Label56" runat="server">
                                                    <asp:Label ID="Label57" runat="server" Text="Secondary Name (7)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div20" runat="server">
                                            <div class="form-group">
                                                <label id="Label58" runat="server">
                                                    <asp:Label ID="Label59" runat="server" Text="Secondary IP (7)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div21" runat="server">
                                            <div class="form-group">
                                                <label id="Label60" runat="server">
                                                    <asp:Label ID="Label61" runat="server" Text="Secondary Name (8)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                            <div class="form-group">
                                                <label id="Label62" runat="server">
                                                    <asp:Label ID="Label63" runat="server" Text="Secondary IP (8)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                            <div class="form-group">
                                                <label id="Label64" runat="server">
                                                    <asp:Label ID="Label65" runat="server" Text="Secondary Name (9)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                            <div class="form-group">
                                                <label id="Label66" runat="server">
                                                    <asp:Label ID="Label67" runat="server" Text="Secondary IP (9)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div25" runat="server">
                                            <div class="form-group">
                                                <label id="Label68" runat="server">
                                                    <asp:Label ID="Label69" runat="server" Text="Secondary Name (10)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox20" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div26" runat="server">
                                            <div class="form-group">
                                                <label id="Label70" runat="server">
                                                    <asp:Label ID="Label71" runat="server" Text="Secondary IP (10)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="TextBox21" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                    </div>
                                </div>


                            </div>


                        </div>



                    </div>
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="DataGrid1" />
        </Triggers>
    </asp:UpdatePanel>
    
<link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
<link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>
<link href="../assets/css/toastr.css" media="all"
    rel="stylesheet" />

<script src="../assets/js/toastr.js"
    type="text/javascript" defer async></script>

<script language="javascript" type="text/javascript">
    function Notify(msg, title, type, clear, pos, sticky) {



        if (clear == true) {
            toastr.clear();
        }
        if (sticky == true) {
            toastr.tapToDismiss = true;
            toastr.timeOut = 10000;
        }

        toastr.options.onclick = function () {
            //alert('You can perform some custom action after a toast goes away');
        }
        //"toast-top-left";
        toastr.options.positionClass = pos;
        if (type.toLowerCase() == 'info') {
            toastr.options.timeOut = 1000;
            toastr.tapToDismiss = true;
            toastr.info(msg, title);
        }
        if (type.toLowerCase() == 'success') {
            toastr.options.timeOut = 1500;
            toastr.success(msg, title);
        }
        if (type.toLowerCase() == 'warning') {
            toastr.options.timeOut = 3000;
            toastr.warning(msg, title);
        }
        if (type.toLowerCase() == 'error') {
            toastr.options.timeOut = 10000;
            toastr.error(msg, title);
        }
    }
</script>
      <script src="js/jquery-1.10.2.js" ></script>
<script src="js/jquery-ui.js" ></script>
<script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
 
          function openModal() {
              $('#danger').modal('show');

          }
       
      </script>

</asp:Content>