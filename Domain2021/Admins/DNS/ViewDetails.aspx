<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ViewDetails.aspx.vb" Inherits="Domain2021.ViewDetails" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
                                        <div class="card-body collapse in">
                                            <div class="card-block card-dashboard">
                                                <p class="card-text text-bold-900" style="font-size: 16px">Domain info</p>
                                                <div class="table-responsive">
                                                    <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="Medium" Height="6px"></asp:Label><asp:Label ID="lbl_Result" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="Medium" Height="6px"></asp:Label></P>
							                        <p>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" Font-Names="Calibri" Font-Size="Medium" Height="47px" Width="161px"></asp:ValidationSummary>
                                                    </p>
                                                    <p>
                                                        <ul class="nav nav-tabs" role="tablist" id="tablist" runat="server" visible="true" style="height: auto">
                                                            <li class="nav-item">
                                                                <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab">Domain Info</a>
                                                            </li>

                                                            <li class="nav-item">
                                                                <a class="nav-link" data-toggle="tab" href="#tabs-3" role="tab">Tech. Info</a>
                                                            </li>
                                                            <li class="nav-item">
                                                                <a class="nav-link" data-toggle="tab" href="#tabs-4" role="tab">Billing Info</a>
                                                            </li>
                                                            <li class="nav-item">
                                                                <a class="nav-link" data-toggle="tab" href="#tabs-5" role="tab">Admin Info</a>
                                                            </li>
                                                            <li class="nav-item">
                                                                <a class="nav-link" data-toggle="tab" href="#tabs-6" role="tab">Contact Info</a>
                                                            </li>

                                                               <li class="nav-item">
                                                                   <a class="nav-link" data-toggle="tab" href="#tabs-7" role="tab" id="app2" runat="server">Approval</a>
                                                               </li>
                                                        </ul>

                                                        <div class="tab-content" id="ttab1" style="width: 70%" runat="server" visible="true">
                                                            <div class="tab-pane active" id="tabs-1" role="tabpanel">
                                                                <asp:Panel ID="Domain_Namepanel" runat="server">
                                                                                                                               
                                                                  
                                                                    <div class="row">


                                                                        <div class="col-lg-6 col-md-6" id="Div1" runat="server">
                                                                            <div class="form-group">
                                                                                <label id="Label3" runat="server" style="font-weight: normal; font-family: Calibri">
                                                                                    Domain Name   
                                                                                </label>
                                                                                <asp:TextBox ID="txt_DOMAIN_NAME" runat="server" Font-Names="Calibri" Enabled="false"></asp:TextBox>
                                                                             
                                                                            
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-6 col-md-6" id="Div8" runat="server">
                                                                            <div class="form-group">
                                                                                <label id="Label17" runat="server" style="font-weight: normal; font-family: Calibri">
                                                                                    Second level    
                                                                                </label>
                                                                                <asp:DropDownList ID="rbl_SECOND_DOMAIN" runat="server" DataValueField="SECOND_DOMAIN_ID" DataTextField="SECOND_DOMAIN" DataSourceID="SqlDataSource1">
                                                                                </asp:DropDownList>

                                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                                                    SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                           
                                                                                   
                                                                            </div>
                                                                        </div>

                                                                    </div>
                     
                                                                    </asp:Panel>          
                                                                <asp:Panel ID="Panel_newNameServer" runat="server">
                                                                        <div class="row">
                                                                            <div class="col-lg-4 col-md-4" id="Div7" runat="server">
                                                                                <div class="form-group">
                                                                                    <label id="Label16" runat="server">
                                                                                
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td nowrap>
                                                                                                        <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Bold="False" Font-Size="Medium">Primary nameserver:  &nbsp;</asp:Label>
                                                                                                           <td>
                                                                                                        <asp:TextBox ID="txt_PRIMARY_NAMESERVER" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td nowrap>
                                                                                                        <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Bold="False" Font-Size="Medium" Width="62px">IP address: &nbsp; </asp:Label>

                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txt_PRIMARY_IP_ADDRESS" runat="server"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td nowrap>
                                                                                                        <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Bold="False" Font-Size="Medium">Secondary nameserver:  &nbsp;</asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txt_SECONDARY_NAMESERVER" runat="server"></asp:TextBox></td>
                                                                                                    <td nowrap>
                                                                                                        <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Bold="False" Font-Size="Medium">IP address: &nbsp;</asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txt_SECONDARY_IP_ADDRESS" runat="server"></asp:TextBox></td>
                                                                                                </tr></table></label>
                                                                                </div>
                                                                                </table><br />
                                                                                <asp:LinkButton ID="lk1" type="button" href="#danger2" data-toggle="modal" runat="server" CssClass="btn btn-cyan pull-left">Show More<li class="fa fa-server" ></li></asp:LinkButton><br />
                                                                                </div></div>
                                               </asp:Panel>

                                                            </div>
                                            




                                            <div class="tab-pane" id="tabs-6" role="tabpanel">
                                                <asp:Panel ID="DomainMainDetailsP" runat="server">
                                                    <table id="Table2" cellspacing="1" cellpadding="1" style="width: 82%" class="table table-responsive">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium"> Company / Organization</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="TXT_ORG_NAME" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium"> Classification</asp:Label></td>
                                                            <td>
                                                                <asp:DropDownList ID="classify" runat="server" DataSourceID="SqlDataSource5" DataTextField="ClassificationNameEn" DataValueField="ClassificationID"></asp:DropDownList>
                                                                <asp:SqlDataSource runat="server" ID="SqlDataSource5" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="select_class_admin" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium"> National No</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="NationalNo" runat="server"></asp:TextBox>
                                                     
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium"> Description</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="Description" runat="server"></asp:TextBox>
                                                                               </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label72" runat="server" Font-Names="Calibri" Font-Size="Medium"> Available Trade Marks</asp:Label></td>
                                                            <td>
                                                                <asp:GridView ID="TradeMarkGrid" BorderColor="Black" ForeColor="Black" Font-Bold="true" GridLines="None" CssClass="table table-responsive" runat="server" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="strTradeMarkArName" DataField="strTradeMarkArName" SortExpression="Admin_id"></asp:BoundField>
                                                                        <asp:BoundField HeaderText="strTradeMarkEnName" DataField="strTradeMarkEnName" SortExpression="Admin_id"></asp:BoundField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><font face="Calibri">Mobile</font></td>
                                                            <td>
                                                                <asp:TextBox ID="txt_org_mobile" runat="server"></asp:TextBox>
                                                            </td>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="hl_mailto_org" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                <asp:TextBox ID="txt_ORG_EMAIL" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Medium" Visible="False">Authorized Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_AUTHORIZED_NAME" runat="server" Visible="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Font-Names="Calibri" Visible="True">Owner Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_OWNER_NAME" runat="server" Visible="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label35" runat="server" Font-Names="Calibri">Registration Date</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_reg_date" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2" nowrap>
                                                                <asp:RadioButtonList ID="rbl_IMMEDIATE_FUTURE" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="small" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="1">Registering for immediate Usage</asp:ListItem>
                                                                    <asp:ListItem Value="2">Reservation for future use</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>

                                            <div class="tab-pane" id="tabs-5" role="tabpanel">
                                                <asp:Panel ID="User_Panel" runat="server">
                                                    <table id="Table6" cellspacing="1" cellpadding="1" width="82%" class="table table-responsive">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Medium">User Name</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txt_COMPANY_USER_NAME" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium">Administrative Contact</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txt_ADMIN_CONTACT" runat="server"></asp:TextBox></td>
                                                        </tr>


                                                        <tr>
                                                            <td>Mobile</td>
                                                            <td>
                                                                <asp:TextBox ID="txt_admin_mobile" runat="server"></asp:TextBox></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label></td>
                                                            <td>
                                                                <asp:HyperLink ID="hl_mailto1" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                <asp:TextBox ID="txt_EMAIL" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>

                                            <div class="tab-pane" id="tabs-3" role="tabpanel">
                                                <asp:Panel ID="Tech_panel" runat="server">
                                                    <table id="Table3" cellspacing="1" cellpadding="1" width="82%" class="table table-responsive">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Medium">Tech Contact</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txt_TECH_CONTACT" runat="server"></asp:TextBox></td>
                                                        </tr>


                                                        <tr>
                                                            <td>Mobile</td>
                                                            <td>

                                                                <asp:TextBox ID="txt_tech_mobile" runat="server"></asp:TextBox></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label></td>
                                                            <td>
                                                                <asp:HyperLink ID="hl_mailto_tech_EMAIL" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                <asp:TextBox ID="txt_tech_EMAIL" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>

                                            <div class="tab-pane" id="tabs-4" role="tabpanel">
                                                <asp:Panel ID="Bill_Panel" runat="server">
                                                    <table id="Table5" cellspacing="1" cellpadding="1" width="82%" class="table table-responsive">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Medium">Billing Contact</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="txt_BILLING_CONTACT" runat="server"></asp:TextBox>
                                                                <asp:Button ID="Button6" runat="server" Font-Names="Calibri" ForeColor="Red" Visible="False"
                                                                    Text="This Domain is FREE"></asp:Button></td>
                                                        </tr>


                                                        <tr>
                                                            <td>Mobile</td>
                                                            <td>

                                                                <asp:TextBox ID="txt_billing_mobile" runat="server"></asp:TextBox></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label></td>
                                                            <td>
                                                                <asp:HyperLink ID="hl_mailto_billing_EMAIL" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                <asp:TextBox ID="txt_billing_EMAIL" runat="server"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="tab-pane" id="appp" role="tabpanel" runat="server" visible="false">
                                                <asp:Panel ID="Panel11" runat="server">
                                                    <table id="Table8" cellspacing="1" cellpadding="1" width="82%" class="table table-responsive">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Medium">Approved</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbl_Approved" runat="server" ForeColor="#C00000" RepeatDirection="Horizontal"
                                                                    Font-Size="Medium">
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                    <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label217" runat="server" Font-Names="Calibri" Font-Size="Medium">Financial Invoice Language</asp:Label></td>

                                                            <td>
                                                                <asp:RadioButtonList ID="rbl_LangFlag" runat="server" ForeColor="#C00000" RepeatDirection="Horizontal"
                                                                    Font-Size="Medium">
                                                                    <asp:ListItem Value="0">English</asp:ListItem>
                                                                    <asp:ListItem Value="1">Arabic</asp:ListItem>
                                                                    <asp:ListItem Value="2" Selected="True">Don't Send</asp:ListItem>
                                                                </asp:RadioButtonList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label50" runat="server" Font-Names="Calibri" Visible="true" Font-Size="Medium">Official documents</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbl_about_doc" runat="server" DataValueField="id" DataTextField="about_doc" Visible="False" DataSourceID="SqlDataSource2">
                                                                </asp:RadioButtonList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                                    SelectCommand="ab_doc" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                            <tr>
                                                            <td>
                                                                <asp:Label ID="Label73" runat="server" Font-Names="Calibri" Visible="true" Font-Size="Medium">Is it free</asp:Label></td>
                                                            <td>
                                                                <asp:CheckBox ID="freech" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Medium" Visible="false">On Hold</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbl_onhold" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="no" Selected="True">no</asp:ListItem>
                                                                    <asp:ListItem Value="yes">yes</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Visible="False" Font-Size="Medium">Comment</asp:Label></td>
                                                            <td>
                                                                <asp:TextBox ID="TXT_FIRST_COMMIT" runat="server" Visible="False" Width="100%" TextMode="MultiLine"
                                                                    Height="110px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <p>
                                                                    <asp:Label ID="Label51" runat="server" Font-Names="Calibri" Font-Size="Medium">Uploaded Files</asp:Label>
                                                                </p>
                                                                <p>
                                                                    <asp:DataList ID="UploadedFiles" runat="server" Font-Names="Calibri" Font-Size="Medium">
                                                                        <ItemTemplate>
                                                                            <table id="Table7" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "{0}") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "../../DOC/{0}") %>' Target="_blank">
                                                                                        </asp:HyperLink></td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Button ID="Approve" CssClass="btn btn-black" runat="server" Font-Names="Calibri" Visible="false" Text="Take an action"></asp:Button></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <p>
                                                    <asp:LinkButton ID="SendEmailbtn" runat="server" href="#danger3" type="button" data-toggle="modal" Font-Names="Calibri"> Send E-Mail</asp:LinkButton>

                                                </p>
                                                <p>
                                                    <asp:Label ID="lbl_E_Mail_LOG" runat="server" ForeColor="Green" Font-Size="X-Small"
                                                        Font-Names="Calibri"></asp:Label>
                                                </p>

                                            </div>

                                        </div>

                                    </div>


                                </div></section>
                        </div>
                    </div>
                </div>
            </div>
        
         
            <div class="modal fade" id="danger2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-server"></i>All registered nameserver</h3>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content" id="Div2" style="width: 70%" runat="server" visible="true">
                                <div class="tab-pane active" id="tabs-11" role="tabpanel" width="70%" style="font-family: Calibri; font-weight: normal; font-size: small">

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
                                                <asp:TextBox CssClass="form-control" ID="P_SERVER_IP" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                            <div class="form-group">
                                                <label id="Label15" runat="server">
                                                    <asp:Label ID="Label19" runat="server" Text=" Secondary Name (1)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div6" runat="server">
                                            <div class="form-group">
                                                <label id="Label21" runat="server">
                                                    <asp:Label ID="Label29" runat="server" Text="Secondary IP (1)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div9" runat="server">
                                            <div class="form-group">
                                                <label id="Label30" runat="server">
                                                    <asp:Label ID="Label31" runat="server" Text="Secondary Name (2)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME2" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                            <div class="form-group">
                                                <label id="Label32" runat="server">
                                                    <asp:Label ID="Label33" runat="server" Text="Secondary IP (2)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP2" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                            <div class="form-group">
                                                <label id="Label37" runat="server">
                                                    <asp:Label ID="Label38" runat="server" Text="Secondary Name (3)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME3" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                            <div class="form-group">
                                                <label id="Label39" runat="server">
                                                    <asp:Label ID="Label40" runat="server" Text="Secondary IP (3)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP3" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div13" runat="server">
                                            <div class="form-group">
                                                <label id="Label41" runat="server">
                                                    <asp:Label ID="Label42" runat="server" Text="Secondary Name (4)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME4" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div14" runat="server">
                                            <div class="form-group">
                                                <label id="Label43" runat="server">
                                                    <asp:Label ID="Label44" runat="server" Text="Secondary IP (4)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP4" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div15" runat="server">
                                            <div class="form-group">
                                                <label id="Label45" runat="server">
                                                    <asp:Label ID="Label46" runat="server" Text="Secondary Name (5)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME5" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                            <div class="form-group">
                                                <label id="Label47" runat="server">
                                                    <asp:Label ID="Label48" runat="server" Text="Secondary IP (5)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP5" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                            <div class="form-group">
                                                <label id="Label49" runat="server">
                                                    <asp:Label ID="Label52" runat="server" Text="Secondary Name (6)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME6" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                            <div class="form-group">
                                                <label id="Label53" runat="server">
                                                    <asp:Label ID="Label54" runat="server" Text="Secondary IP (6)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP6" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div19" runat="server">
                                            <div class="form-group">
                                                <label id="Label56" runat="server">
                                                    <asp:Label ID="Label57" runat="server" Text="Secondary Name (7)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME7" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div20" runat="server">
                                            <div class="form-group">
                                                <label id="Label58" runat="server">
                                                    <asp:Label ID="Label59" runat="server" Text="Secondary IP (7)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP7" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div21" runat="server">
                                            <div class="form-group">
                                                <label id="Label60" runat="server">
                                                    <asp:Label ID="Label61" runat="server" Text="Secondary Name (8)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME8" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                            <div class="form-group">
                                                <label id="Label62" runat="server">
                                                    <asp:Label ID="Label63" runat="server" Text="Secondary IP (8)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP8" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                            <div class="form-group">
                                                <label id="Label64" runat="server">
                                                    <asp:Label ID="Label65" runat="server" Text="Secondary Name (9)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME9" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                            <div class="form-group">
                                                <label id="Label66" runat="server">
                                                    <asp:Label ID="Label67" runat="server" Text="Secondary IP (9)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP9" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4" id="Div25" runat="server">
                                            <div class="form-group">
                                                <label id="Label68" runat="server">
                                                    <asp:Label ID="Label69" runat="server" Text="Secondary Name (10)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_NAME10" runat="server"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-4 col-md-4" id="Div26" runat="server">
                                            <div class="form-group">
                                                <label id="Label70" runat="server">
                                                    <asp:Label ID="Label71" runat="server" Text="Secondary IP (10)"></asp:Label></label>
                                                <asp:TextBox CssClass="form-control" ID="S_SERVER_IP10" runat="server"></asp:TextBox>


                                            </div>
                                        </div>

                                    </div>
                                </div>


                            </div>


                        </div>



                    </div>
                </div>

            </div>

            <div class="modal fade" id="danger3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-envelope"></i>All Emails</h3>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content" id="Div27" style="width: 70%" runat="server" visible="true">
                                <asp:Panel ID="Panel_send_email" runat="server" Visible="true">
                                    <table id="Table10" cellspacing="1" cellpadding="1" width="82%" class="table table-responsive">

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label55" runat="server" Font-Names="Calibri">E-Mail Category</asp:Label></td>
                                            <td>
                                                <asp:CheckBoxList ID="rbl_email_titel" runat="server" DataValueField="id" DataTextField="title" DataSourceID="SqlDataSource3">
                                                </asp:CheckBoxList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                    SelectCommand="email_more" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataValueField="id" DataTextField="title" DataSourceID="SqlDataSource4">
                                                </asp:CheckBoxList>
                                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                    SelectCommand="email_more_a" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="SendEmail" runat="server" Font-Names="Calibri" Text="Send E-Mail" ValidationGroup="aa"></asp:Button>
                                                <asp:Button ID="SendEmailAr" runat="server" Font-Names="Calibri" Text="Send arabic Email" ValidationGroup="aa" Visible="False"></asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                    </div>
                </div>
            </div>

    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

 
    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>
</asp:Content>
