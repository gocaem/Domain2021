<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="domainsdetalesOriginal.aspx.vb" Inherits="Domain2021.domainsdetalesOriginal" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                        <p>
                                                            <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="Medium" Height="6px"></asp:Label><asp:Label ID="lbl_Result" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="Medium" Height="6px"></asp:Label>
                                                        </p>
                                                        <p></p>
                                                        <asp:TextBox ID="TechTextID2" runat="server" Visible="false"></asp:TextBox>
                                                        <asp:TextBox ID="TechTextID" runat="server" Visible="false"></asp:TextBox>
                                                        <asp:TextBox ID="BILLING_CODE_ID" runat="server" Visible="false"></asp:TextBox>
                                                        <asp:TextBox ID="TID" runat="server" Visible="false"></asp:TextBox>
                                                        <p>
                                                            <ul class="nav nav-tabs" role="tablist" id="tablist" runat="server">
                                                                <li class="nav-item">
                                                                    <a class="nav-link active" data-toggle="tab" href="#Original" role="tab">Orignial</a>
                                                                </li>

                                                                <li class="nav-item">
                                                                    <a class="nav-link" data-toggle="tab" href="#Updated" role="tab">Updated</a>
                                                                </li>
                                                            </ul>
                                                            <p>
                                                            </p>
                                                            <div id="ttab1" runat="server" class="tab-content" style="width: 70%">
                                                                <div id="Original" class="tab-pane active" role="tabpanel" width="70%">
                                                                    <center>
                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel1" runat="server">
                                                                                        <table cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="4" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="Label56" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">DNS Data</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 214px; height: 52px;">
                                                                                                    <asp:Label ID="Label57" runat="server" Font-Names="Calibri" Font-Size="Medium">Domain Name</asp:Label>
                                                                                                </td>
                                                                                                <td colspan="3" style="height: 52px">
                                                                                                    <asp:Label ID="Label58" runat="server" Font-Names="Calibri" Font-Size="Medium">Second level domain</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 214px">
                                                                                                    <asp:TextBox ID="DomainNameT" runat="server" AutoPostBack="True" Font-Names="Calibri"></asp:TextBox>
                                                                                                    <td colspan="3" valign="middle">
                                                                                                        <asp:DropDownList ID="secondddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>" SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                                                    </td>
                                                                                                </td>
                                                                                            </tr>
                                                                                         
                                                                                            <tr>
                                                                                                <td style="width: 214px"></td>
                                                                                                <td colspan="3" valign="middle">
                                                                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Small" Height="31px" RepeatDirection="Horizontal" Visible="False">
                                                                                                        <asp:ListItem Value="Name Server">Name Server</asp:ListItem>
                                                                                                        <asp:ListItem Selected="True" Value="New Name Server">New Name Server</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4">
                                                                                                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label59" runat="server" Font-Names="Calibri">Name Server</asp:Label>
                                                                                                                </td>
                                                                                                                <td valign="middle">
                                                                                                                    <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="COMPANY_USER_NAME" DataValueField="ID" Font-Names="Calibri">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4">
                                                                                                    <asp:Panel ID="Panel4" runat="server">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="Label60" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">Primary nameserver</asp:Label>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="Primary" runat="server" Width="100px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                    <td nowrap>
                                                                                                                        <asp:Label ID="Label61" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" Width="62px">IP address</asp:Label>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="PrimaryIP" runat="server" Width="107px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="SecondaryL" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" Width="138px">Secondary nameserver</asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="Secondary" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="SecondaryIPL" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">IP address</asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="SecondaryIPT" runat="server" Width="107px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                    <br />
                                                                                    <asp:LinkButton ID="lk1" runat="server" data-toggle="modal" href="#danger2" type="button">Show More<li class="fa fa-server" ></li></asp:LinkButton>
                                                                                    <br />
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel13" runat="server">
                                                                                        <table cellpadding="1" cellspacing="1" style="width: 100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="ContactDataL" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Contact Data</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="ORG_NAMEL" runat="server" Font-Names="Calibri" Font-Size="Medium"> Company / Organization</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="ORG_NAMET" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="OrgMobileL" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="OrgMobileT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="OrgEmailL" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="OrgEmailLk" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="OrgEmailT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        
                                                                                            <tr>
                                                                                                <td align="center" colspan="2" nowrap>
                                                                                                    <asp:Label ID="Label76" runat="server" Font-Names="Calibri"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="2" nowrap>
                                                                                                    <asp:RadioButtonList ID="reservedradio" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="Medium" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Selected="True" Value="1">Registering for immediate Usage</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Reservation for future use</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel14" runat="server">
                                                                                        <table id="Table6" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="Label77" runat="server" Font-Bold="false" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Width="350px">Administrative Contact (Prefer Contact):</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Userl" runat="server" Font-Names="Calibri" Font-Size="Medium">User Name</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="UserT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 300px">
                                                                                                    <asp:Label ID="AdminL" runat="server" Font-Names="Calibri" Font-Size="Medium">Administrative Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="AdminT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label82" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="ad_mobileT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="AdminMailL" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="Ad_Emaillk" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="AdminMailT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel15" runat="server">
                                                                                        <table id="Table3" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td id="tech2" runat="server" colspan="2" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="Label85" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Technical Contact</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="TechL" runat="server" Font-Names="Calibri" Font-Size="Medium">Tech Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="TechT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="TechMobileL" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="TechMobileT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="techEMailL" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="techEMaillk" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="techEMailT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                    <asp:Panel ID="Panel16" runat="server">
                                                                                        <table cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td id="bill" runat="server" colspan="2" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="BILLING_CONTACTLabel" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Billing Contact</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="BILLING_CONTACTL" runat="server" Font-Names="Calibri" Font-Size="Medium">Billing Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="BILLING_CONTACTT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="bil_mobL" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="bil_mobT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label98" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="BillingEmailLK" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="BillingEmailT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel17" runat="server" Visible="false">
                                                                                        <table id="Table8" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #3071a9">
                                                                                                    <asp:Label ID="Label99" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Get Approval</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label100" runat="server" Font-Names="Calibri" Font-Size="Medium">Approved</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#C00000" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                                                                        <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label101" runat="server" Font-Names="Calibri" Font-Size="Medium">Financial Invoice Language</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#C00000" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Value="0">English</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">Arabic</asp:ListItem>
                                                                                                        <asp:ListItem Selected="True" Value="2">Don&#39;t Send</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label103" runat="server" Font-Names="Calibri" Font-Size="Medium" Visible="false">On Hold</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Selected="True" Value="no">no</asp:ListItem>
                                                                                                        <asp:ListItem Value="yes">yes</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label104" runat="server" Font-Names="Calibri" Font-Size="Medium" Visible="False">Comment</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="TextBox36" runat="server" Height="110px" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <p>
                                                                                                        <asp:Label ID="Label105" runat="server" Font-Names="Calibri" Font-Size="Medium">Uploaded Files</asp:Label>
                                                                                                    </p>
                                                                                                    <p>
                                                                                                        <asp:DataList ID="DataList1" runat="server" Font-Names="Calibri" Font-Size="Medium">
                                                                                                            <ItemTemplate>
                                                                                                                <table id="Table7" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "../../DOC/{0}") %>' Target="_blank" Text='<%# DataBinder.Eval(Container, "DataItem.file_post_name", "{0}") %>'>
                                                                                                                        </asp:HyperLink>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:DataList>
                                                                                                    </p>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="2">
                                                                                                    <asp:Button ID="Button10" runat="server" Font-Names="Calibri" Text="Approved" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <p>
                                                                                        &nbsp;</p>
                                                                                    <p>
                                                                                        <asp:LinkButton ID="Linkbutton1" runat="server" Font-Names="Calibri" Visible="false"> Send E-Mail</asp:LinkButton>
                                                                                    </p>
                                                                                    <p>
                                                                                        <asp:Label ID="Label121" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Small" ForeColor="Green"></asp:Label>
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                                    <div id="danger2" aria-hidden="true" aria-labelledby="myModalLabel" class="modal fade" role="dialog" tabindex="-1">
                                                                        <div class="modal-dialog">
                                                                            <div class="modal-content">
                                                                                <div class="modal-header modal-header-danger">
                                                                                    <button aria-hidden="true" class="close" data-dismiss="modal" type="button">
                                                                                        ×
                                                                                    </button>
                                                                                    <h3><i class="fa fa-server"></i>all registered nameserver</h3>
                                                                                </div>
                                                                                <div class="modal-body">
                                                                                    <div id="Div2" runat="server" class="tab-content" style="width: 70%" visible="true">
                                                                                        <div id="tabs-1" class="tab-pane active" role="tabpanel" style="font-family: Calibri; font-weight: normal; font-size: small" width="70%">
                                                                                            <div class="row">
                                                                                                <div runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label106" runat="server">
                                                                                                        <asp:Label ID="Domain_nameL" runat="server" Text="Primary Server"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="p_nameOriginal" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div4" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label107" runat="server">
                                                                                                        <asp:Label ID="PrimaryServerIPL" runat="server" Text="Primary Server IP"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="PrimaryServerIPTOriginal" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div5" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label109" runat="server">
                                                                                                        <asp:Label ID="Label110" runat="server" Text=" Secondary Name (1)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondOriginal1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div6" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label111" runat="server">
                                                                                                        <asp:Label ID="Label112" runat="server" Text="Secondary IP (1)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondOriginalIP1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div9" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label113" runat="server">
                                                                                                        <asp:Label ID="SecondaryNameLabel2" runat="server" Text="Secondary Name (2)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryNameText2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div10" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label115" runat="server">
                                                                                                        <asp:Label ID="SecondaryNameIPL2" runat="server" Text="Secondary IP (2)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryNameIP2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div11" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label117" runat="server">
                                                                                                        <asp:Label ID="SecondaryNameL3" runat="server" Text="Secondary Name (3)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryName3" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div12" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label119" runat="server">
                                                                                                        <asp:Label ID="SecondaryNameIPL3" runat="server" Text="Secondary IP (3)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryNameIP3" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div13" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label124" runat="server">
                                                                                                        <asp:Label ID="SERVER_NAME4L" runat="server" Text="Secondary Name (4)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SSERVER_NAME4T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div14" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label126" runat="server">
                                                                                                        <asp:Label ID="SecondaryIPL4" runat="server" Text="Secondary IP (4)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryIPT4" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div15" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label128" runat="server">
                                                                                                        <asp:Label ID="S_SERVER_NAME5L" runat="server" Text="Secondary Name (5)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="S_SERVER_NAME5T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div16" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label130" runat="server">
                                                                                                        <asp:Label ID="S_SERVER_NAME5IPL" runat="server" Text="Secondary IP (5)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="S_SERVER_NAME5IP" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div17" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label132" runat="server">
                                                                                                        <asp:Label ID="S_SERVER_NAME6L" runat="server" Text="Secondary Name (6)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="S_SERVER_NAME6" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div18" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label134" runat="server">
                                                                                                        <asp:Label ID="Secondary6IPLabel" runat="server" Text="Secondary IP (6)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary6IPTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div19" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label136" runat="server">
                                                                                                        <asp:Label ID="Secondary7L" runat="server" Text="Secondary Name (7)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary7T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div20" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label138" runat="server">
                                                                                                        <asp:Label ID="Secondary7IPL" runat="server" Text="Secondary IP (7)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary7IP" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div21" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label140" runat="server">
                                                                                                        <asp:Label ID="Secondary8L" runat="server" Text="Secondary Name (8)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary8T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div id="Div22" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label142" runat="server">
                                                                                                        <asp:Label ID="Secondary8IPL" runat="server" Text="Secondary IP (8)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary8IPT" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div23" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label144" runat="server">
                                                                                                        <asp:Label ID="Secondary9L" runat="server" Text="Secondary Name (9)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary9T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label146" runat="server">
                                                                                                        <asp:Label ID="Secondary9IPL" runat="server" Text="Secondary IP (9)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary9IP" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label148" runat="server">
                                                                                                        <asp:Label ID="Secondary10L" runat="server" Text="Secondary Name (10)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="Secondary10T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div id="Div26" runat="server" class="col-lg-4 col-md-4">
                                                                                                    <div class="form-group">
                                                                                                        <label id="Label150" runat="server">
                                                                                                        <asp:Label ID="Secondary10IPL" runat="server" Text="Secondary IP (10)"></asp:Label>
                                                                                                        </label>
                                                                                                        <asp:TextBox ID="SecondaryIP10" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="Updated" class="tab-pane" role="tabpanel" width="70%">
                                                                    <center>
                                                                        <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel5" runat="server">
                                                                                        <table id="Table4" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #003366">
                                                                                                    <asp:Label ID="Label38" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">DNS Data</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Medium">Domain Name</asp:Label>
                                                                                                </td>
                                                                                                <td colspan="3" style="height: 52px">
                                                                                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium">Second level domain</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_DOMAIN_NAME" runat="server" AutoPostBack="True" Font-Names="Calibri"></asp:TextBox>
                                                                                                    <td colspan="3" valign="middle">
                                                                                                        <asp:DropDownList ID="rbl_SECOND_DOMAIN" runat="server" DataSourceID="SqlDataSource1" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>" SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                                                                    </td>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="3" valign="middle">
                                                                                                    <asp:RadioButtonList ID="rbl_nameNewNAmeserver" runat="server" AutoPostBack="True" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Small" Height="31px" RepeatDirection="Horizontal" Visible="False">
                                                                                                        <asp:ListItem Value="Name Server">Name Server</asp:ListItem>
                                                                                                        <asp:ListItem Selected="True" Value="New Name Server">New Name Server</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4">
                                                                                                    <asp:Panel ID="Panel_nameserver" runat="server" Visible="False">
                                                                                                        <table width="100%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri">Name Server</asp:Label>
                                                                                                                </td>
                                                                                                                <td valign="middle">
                                                                                                                    <asp:DropDownList ID="ddl_NAME_SERVER" runat="server" DataTextField="COMPANY_USER_NAME" DataValueField="ID" Font-Names="Calibri">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4">
                                                                                                    <asp:Panel ID="Panel_newNameServer" runat="server">
                                                                                                        <table class="table table-responsive" width="100%">
                                                                                                            <tr>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="PrimaryL" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">Primary nameserver</asp:Label>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txt_PRIMARY_NAMESERVER" runat="server" Width="100px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                    <td nowrap>
                                                                                                                        <asp:Label ID="PRIMARY_IPL" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" Width="62px">IP address</asp:Label>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txt_PRIMARY_IP_ADDRESS" runat="server" Width="107px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="SECONDARY_NAMESERVERL" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" Width="138px">Secondary nameserver</asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_SECONDARY_NAMESERVER" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td nowrap>
                                                                                                                    <asp:Label ID="SECONDARY_NAMESERVERIP" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">IP address</asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_SECONDARY_IP_ADDRESS" runat="server" Width="107px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" data-toggle="modal" href="#danger3" type="button">Show More<li class="fa fa-server" ></li></asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel6" runat="server">
                                                                                        <table id="Table2" cellpadding="1" cellspacing="1" style="width: 100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #003366">
                                                                                                    <asp:Label ID="Label39" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Contact Data</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium"> Company / Organization</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="TXT_ORG_NAME" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label218" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_org_mobile" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="hl_mailto_org" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="txt_ORG_EMAIL" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        
                                                                                            <tr>
                                                                                                <td align="center" colspan="2" nowrap>
                                                                                                    <asp:Label ID="rbl_visibleFlag" runat="server" Font-Names="Calibri"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="2" nowrap>
                                                                                                    <asp:RadioButtonList ID="rbl_IMMEDIATE_FUTURE" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="Medium" RepeatDirection="Horizontal">
                                                                                                        <asp:ListItem Selected="True" Value="1">Registering for immediate Usage</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Reservation for future use</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel7" runat="server">
                                                                                        <table id="Table6" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="2" style="background-color: #003366">
                                                                                                    <asp:Label ID="Label37" runat="server" Font-Bold="false" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Width="350px">Administrative Contact (Prefer Contact):</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label25" runat="server" Font-Names="Calibri" Font-Size="Medium">User Name</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_COMPANY_USER_NAME" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium">Administrative Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_ADMIN_CONTACT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label219" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_admin_mobile" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="hl_mailto1" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="txt_EMAIL" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Panel ID="Panel8" runat="server">
                                                                                        <table id="Table3" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td id="tech1" runat="server" colspan="2" style="background-color: #003366">
                                                                                                    <asp:Label ID="Label40" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Technical Contact</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" Font-Size="Medium">Tech Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_TECH_CONTACT" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label220" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_tech_mobile" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                                <tr>
                                                                                                    <td style="width: 200px">
                                                                                                        <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:HyperLink ID="hl_mailto_tech_EMAIL" runat="server" Font-Names="Calibri">MailTo</asp:HyperLink>
                                                                                                        <asp:TextBox ID="txt_tech_EMAIL" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                    <asp:Panel ID="Panel9" runat="server">
                                                                                        <table id="Table5" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td id="bill1" runat="server" colspan="2" style="background-color: #003366">
                                                                                                    <asp:Label ID="Label41" runat="server" Font-Bold="false" Font-Names="Calibri" ForeColor="white">Billing Contact</asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="Medium">Billing Contact</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_BILLING_CONTACT" runat="server"></asp:TextBox>
                                                                                                    <asp:Button ID="Button6" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red" Text="This Domain is FREE" Visible="False" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label221" runat="server" Font-Names="Calibri" Font-Size="Medium">Mobile</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_billing_mobile" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 200px">
                                                                                                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium">E-Mail</asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:HyperLink ID="hl_mailto_billing_EMAIL" runat="server" Font-Names="Calibri" Font-Size="Medium">MailTo</asp:HyperLink>
                                                                                                    <asp:TextBox ID="txt_billing_EMAIL" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <div id="danger3" aria-hidden="true" aria-labelledby="myModalLabel" class="modal fade" role="dialog" tabindex="-1">
                                                                            <div class="modal-dialog">
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header modal-header-danger">
                                                                                        <button aria-hidden="true" class="close" data-dismiss="modal" type="button">
                                                                                            ×
                                                                                        </button>
                                                                                        <h3><i class="fa fa-server"></i>all registered nameserver</h3>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                        <div id="allservers" runat="server" class="tab-content" style="width: 70%" visible="true">
                                                                                            <div class="tab-pane active" role="tabpanel" style="font-family: Calibri; font-weight: normal; font-size: small" width="70%">
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label152" runat="server">
                                                                                                            <asp:Label ID="Primary_ServerL" runat="server" Text="Primary Server"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Primary_Server" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label154" runat="server">
                                                                                                            <asp:Label ID="Primary_ServerIPL" runat="server" Text="Primary Server IP"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Primary_ServerIP" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label156" runat="server">
                                                                                                            <asp:Label ID="SecondaryNameL1" runat="server" Text=" Secondary Name (1)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryNameT1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label158" runat="server">
                                                                                                            <asp:Label ID="Secondary_IP1L" runat="server" Text="Secondary IP (1)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_IP1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label160" runat="server">
                                                                                                            <asp:Label ID="SecondaryNameL2" runat="server" Text="Secondary Name (2)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryNameT2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label162" runat="server">
                                                                                                            <asp:Label ID="SecondaryIPL2" runat="server" Text="Secondary IP (2)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryIPT2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label164" runat="server">
                                                                                                            <asp:Label ID="Secondary_NameL3" runat="server" Text="Secondary Name (3)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_Name3" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label166" runat="server">
                                                                                                            <asp:Label ID="SecondaryIPL3" runat="server" Text="Secondary IP (3)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryIP3" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="Div33" runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label168" runat="server">
                                                                                                            <asp:Label ID="Secondary4Label" runat="server" Text="Secondary Name (4)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryTextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div id="Div34" runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label170" runat="server">
                                                                                                            <asp:Label ID="SecondaryIP4L" runat="server" Text="Secondary IP (4)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryIPText4" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div id="Div35" runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label172" runat="server">
                                                                                                            <asp:Label ID="SecondaryNameL5" runat="server" Text="Secondary Name (5)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryNameT5" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label174" runat="server">
                                                                                                            <asp:Label ID="Secondary_IP5L" runat="server" Text="Secondary IP (5)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_IP5T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label176" runat="server">
                                                                                                            <asp:Label ID="Secondary_NameL6" runat="server" Text="Secondary Name (6)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_NameT6" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label178" runat="server">
                                                                                                            <asp:Label ID="Label179" runat="server" Text="Secondary IP (6)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryTIP6" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label180" runat="server">
                                                                                                            <asp:Label ID="Label181" runat="server" Text="Secondary Name (7)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryTName7" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label182" runat="server">
                                                                                                            <asp:Label ID="Secondary_IPL7" runat="server" Text="Secondary IP (7)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_IPT7" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label184" runat="server">
                                                                                                            <asp:Label ID="SecondaryName8L" runat="server" Text="Secondary Name (8)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryName8T" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label186" runat="server">
                                                                                                            <asp:Label ID="SecondaryIPL8" runat="server" Text="Secondary IP (8)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryIPT8" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label188" runat="server">
                                                                                                            <asp:Label ID="SecondaryNameL9" runat="server" Text="Secondary Name (9)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryNameT9" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label190" runat="server">
                                                                                                            <asp:Label ID="Secondary_L9" runat="server" Text="Secondary IP (9)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_IPT9" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label192" runat="server">
                                                                                                            <asp:Label ID="SecondaryNameL10" runat="server" Text="Secondary Name (10)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="SecondaryNameT10" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div runat="server" class="col-lg-4 col-md-4">
                                                                                                        <div class="form-group">
                                                                                                            <label id="Label194" runat="server">
                                                                                                            <asp:Label ID="Secondary_LT10" runat="server" Text="Secondary IP (10)"></asp:Label>
                                                                                                            </label>
                                                                                                            <asp:TextBox ID="Secondary_IPT10" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </center>
                                                                </div>
                                                            </div>
                                                        </p>


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
    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>


    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js"
        type="text/javascript" defer async></script>
</asp:Content>
