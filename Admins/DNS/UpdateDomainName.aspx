<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="UpdateDomainName.aspx.vb" Inherits="Domain2021.UpdateDomainName" %>
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Manage Domain's Name</p>
                                                <div class="table-responsive"> <asp:Label ID="lbl_error" runat="server" ForeColor="red"></asp:Label>
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                        Domain Name:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_admin_id" runat="server" ErrorMessage="Required!" Text="Required!" ForeColor="Red" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    <br />
                                                        <asp:Button ID="Button3" ValidationGroup="c" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%" OnClick="Button3_Click" ></asp:Button>
                                                           <asp:GridView Visible="false" DataKeyNames="Domain_id" HeaderStyle-BackColor="Silver" Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView2" CssClass="table table-responsive" DataSourceID="selectSettings" runat="server" OnRowCommand="GridView2_RowCommand">

                                                            <Columns>
                                                                <asp:BoundField DataField="DOMAIN_NAME" HeaderText="Domain Name" ReadOnly="True" SortExpression="DOMAIN_NAME"></asp:BoundField>
                                                                <asp:BoundField DataField="SECOND_DOMAIN" HeaderText="TLD" SortExpression="SECOND_DOMAIN"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Status" DataField="STATUS" SortExpression="STATUS"></asp:BoundField>
                                                                <asp:BoundField HeaderText="DOMAIN_ID" DataField="DOMAIN_ID" SortExpression="DOMAIN_ID" InsertVisible="False" ReadOnly="True"  HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                                <asp:BoundField HeaderText="FREE" DataField="FREE" SortExpression="FREE"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Reg Date" DataField="reg_date" SortExpression="reg_date" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField HeaderText="End Date" DataField="end_date" SortExpression="end_date"  ReadOnly="True"></asp:BoundField>
                                                              <asp:TemplateField HeaderText="Details">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk" runat="server" CommandName="view" CommandArgument='<%# Eval("Domain_id") %>' ><i class="fa fa-info-circle green"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lked" runat="server" CommandName="Edit1" ><i class="fa fa-edit red"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                               </asp:TemplateField>
                                                                   <asp:BoundField HeaderText="second_domain_id" DataField="second_domain_id" SortExpression="second_domain_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ReadOnly="True"></asp:BoundField>
                                                                   <asp:BoundField HeaderText="domainName" DataField="domainName" SortExpression="domainName" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ReadOnly="True"></asp:BoundField>
                                        
                                                            </Columns>
                                                                              
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="selectSettings" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="Search_Domainname" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="txt_admin_id" Name="domain_name" PropertyName="Text"
                                                                    Type="String" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                    </div>
                                                     <div id="row">
                                                   <div class="col-md-12" id="div1" runat="server" visible="false">
                                                       Old Domain Name: <asp:Label ID="TextLbl" CssClass="label label-info" runat="server"  Font-Size="Medium"></asp:Label><br /><br /></div></div>
                                                        <div id="row">
                                                   <div class="col-md-12" id="div2" runat="server" visible="false">New Domain Name:
                                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Width="300px"></asp:TextBox>   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="Required domain name" SetFocusOnError="true" Text="Required domain name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <br />
                                                           Second New Domain Name:<br />
                                                        <asp:DropDownList ID="DropDownList2" AppendDataBoundItems="true" runat="server" Width="150px" DataSourceID="SqlDataSource2" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID" CssClass="form-control-lg">
                                                            <asp:ListItem Value="0">---</asp:ListItem>
                                                        </asp:DropDownList>          <br />          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DropDownList2" SetFocusOnError="true" InitialValue="0" runat="server" ErrorMessage="choose" Text="choose" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                             <br />
                                                                                                  </div></div>
                                                        <br /><br /> <asp:Button ID="Button1" ValidationGroup="a" runat="server" Visible="false" Text="Start Update" CssClass=" form-group btn btn-danger" Width="50%" OnClick="Button1_Click" ></asp:Button>
                                                          <br />  <br /><center><asp:Label ID="Label1" runat="server"  Visible="false"  Width="100%"  CssClass="alert alert-grey" Text="Show available domain names"> </asp:Label><br /><br /><br />                   
                                                       </center>  <asp:GridView Visible="false" DataKeyNames="Domain_id"   Width="100%" AllowPaging="true" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView1" CssClass="table" DataSourceID="SqlDataSource1" runat="server" OnRowCommand="GridView1_RowCommand" >

                                                            <Columns>
                                                                <asp:BoundField DataField="DOMAIN_NAME" HeaderText="DOMAIN_NAME" ReadOnly="True" SortExpression="DOMAIN_NAME"></asp:BoundField>
                                                                <asp:BoundField DataField="SECOND_DOMAIN" HeaderText="SECOND_DOMAIN" SortExpression="SECOND_DOMAIN"></asp:BoundField>
                                                                <asp:BoundField HeaderText="STATUS" DataField="STATUS" SortExpression="STATUS"></asp:BoundField>
                                                                <asp:BoundField HeaderText="DOMAIN_ID" DataField="DOMAIN_ID" SortExpression="DOMAIN_ID" InsertVisible="False" ReadOnly="True" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"></asp:BoundField>
                                                                <asp:BoundField HeaderText="FREE" DataField="FREE" SortExpression="FREE"></asp:BoundField>
                                                                <asp:BoundField HeaderText="reg_date" DataField="reg_date" SortExpression="reg_date" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField HeaderText="end_date" DataField="end_date" SortExpression="end_date" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ReadOnly="True"></asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lk" runat="server" CommandName="view" Text='<%#Eval("Domain_id") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="getalldomainnames" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="TextBox2" PropertyName="Text" Name="domainname" Type="String"></asp:ControlParameter>
                                                                <asp:ControlParameter ControlID="DropDownList2" PropertyName="SelectedValue" Name="second" Type="Int32"></asp:ControlParameter>
                                                            </SelectParameters>
                                                        </asp:SqlDataSource><br />
                                                        <asp:Button ID="Button2" Visible="false" ValidationGroup="a" runat="server" Text="Confirm Update" CssClass=" form-group btn btn-black" Width="50%" OnClick="Button2_Click" ></asp:Button>
                                   
                                                        </div>
                                                        </div>
                                                       <br /><br />
                                                          
                                     
                                                <asp:Label ID="Label27" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label26" runat="server" Visible="false" Text="Label"></asp:Label>
                                                <asp:Label ID="Label25" runat="server" Visible="false" Text="Label"></asp:Label>
                                           
                                            </div>
                                        </div>

                                        </section>

                        </div>
                    </div>
                </div>
                <div class="container">
                   
                </div>
            </div>
            <div class="modal fade" id="danger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-edit"></i>Edit Domain Name</h3>
                        </div>
                        <div class="modal-body">
                        <asp:Label ID="lblupdate" Text="Are you sure you want to update?" runat="server"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button4"  type="button" runat="server" CssClass="btn btn-success pull-left" Text="Yes" OnClick="Button4_Click" ></asp:Button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button2" />
            <asp:PostBackTrigger ControlID="Button4" />
        </Triggers>
    </asp:UpdatePanel>
    
<link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
<link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>
    
  <script type="text/javascript">
      debugger
      function openModal() {
          $('#danger').modal('show');

      }
      function openModal2() {
          $('#danger2').modal('show');

      }
  </script>

<link href="../assets/css/toastr.css"
    rel="stylesheet" media="all"/>

<script src="../../Scripts/toastr.min.js"
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

</asp:Content>