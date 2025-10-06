<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ManageUsers.aspx.vb" Inherits="Domain2021.ManageUsers" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div>       
           <script>
               $(document).ready(function () {
                   var collapse = document.getElementById("manage")
                   collapse.className = "sidebar-submenu menu-open";
                   collapse.style.display = "block";

               });
           </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                            <img src="../app-assets/3MODEE-news-0.png" alt="branding logo"></div>
                                    </div>
                                    <asp:LinkButton ID="lk1" type="button" OnClick="lk1_Click"  runat="server" CssClass="btn btn-cyan pull-left" >Add New User <li class="fa fa-plus" ></li></asp:LinkButton><br />

                                </div>
                                <div class="card-body collapse in">
                                    <div class="card-block card-dashboard">
                                        <p class="card-text text-bold-900" style="font-size: 16px">Manage Users available in the system</p>
                                        <div class="table-responsive">

                                            <asp:GridView  OnRowCommand="GridView1_RowCommand" AllowPaging="true" GridLines="None" Width="50%" HorizontalAlign="Center" AutoGenerateColumns="false" ID="GridView1" CssClass="table mb-0" DataSourceID="SqlDataSource1" runat="server">

                                                <Columns>
                                                    <asp:BoundField HeaderText="ID" DataField="Users_ID" SortExpression="Users_ID" ItemStyle-Width="30px"></asp:BoundField>
                                                    <asp:BoundField HeaderText="user_Email" DataField="user_Email" SortExpression="user_Email" ItemStyle-Width="30px"></asp:BoundField>
                                                    <asp:BoundField HeaderText="IsDisabled" DataField="USER_Disabled" SortExpression="USER_Disabled" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ItemStyle-Width="30px"></asp:BoundField>
                                                    <asp:BoundField HeaderText="USER Role" DataField="USER_Role" SortExpression="USER_Role" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" ItemStyle-Width="30px"></asp:BoundField>
                                                    <asp:BoundField HeaderText="user name" DataField="USER_NAMEs" SortExpression="USER_NAMEs" ItemStyle-Width="30px"></asp:BoundField>


                                                    <asp:TemplateField HeaderText="Edit/Add">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lk12" CommandArgument="<%# Container.DataItemIndex %>" CommandName="details" CausesValidation="false" Enabled="true" runat="server" Text="Edit" ItemStyle-Width="40"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>




                                        </div>




                                        <div class="card-footer">
                                            <div class="">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    </section>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="select_users" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                </div>
            </div>
        </div>
        <div class="container">

            <div class="modal fade" id="danger2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="glyphicon glyphicon-user"></i>Add New User</h3>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="result" runat="server" ForeColor="red" Text="Label" Visible="false"></asp:Label>
                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="TextBox2" Width="50%" runat="server" placeholder="Username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ValidationGroup="A" ControlToValidate="TextBox2" ForeColor="red"></asp:RequiredFieldValidator>
                            <asp:TextBox CssClass="form-control form-control-lg input-lg" ID="TextBox3" Width="50%" runat="server" placeholder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="A" ControlToValidate="TextBox3" ErrorMessage="Email Required" ForeColor="red"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="AdminEmailExpressionValidator" runat="server" ErrorMessage="invalid email" ControlToValidate="TextBox3" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:CheckBox runat="server" Text="Disabling User" CssClass="checkbox" ID="CheckBox1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="A" InitialValue="0" ControlToValidate="DropDownList1" ErrorMessage="Choose Role" ForeColor="red"></asp:RequiredFieldValidator>
                            <asp:DropDownList runat="server" class="form-control form-control-lg input-lg" ID="DropDownList1" placeholder="Type" Font-Size="Medium" Width="50%">
                                <asp:ListItem Value="0">---------- Choose User Role ----------</asp:ListItem>
                                <asp:ListItem Value="2">Accountant</asp:ListItem>
                                <asp:ListItem Value="3">DNS Team</asp:ListItem>
                                <asp:ListItem Value="1">View Only</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button1" OnClick="Button1_Click" type="button" runat="server"  CssClass="btn btn-danger pull-left" Text="Add User" ValidationGroup="A"></asp:Button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

            <div class="modal fade" id="danger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="glyphicon glyphicon-user"></i>Edit User</h3>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="Label2" runat="server" ForeColor="red" Text="Label" Visible="false"></asp:Label>
                            <br />
                            Username:
                            <asp:TextBox Enabled="false" CssClass="form-control form-control-lg input-lg" ID="TextBox1" Width="50%" runat="server"></asp:TextBox><br />
                           Email:<asp:TextBox CssClass="form-control form-control-lg input-lg" ID="TextBox4" Width="50%" runat="server"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="invalid email" ControlToValidate="TextBox4" ValidationGroup="B" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                              <br />
                            is Disabled:<asp:CheckBox runat="server" CssClass="checkbox" ID="CheckBox2" /><br />
                            Role:    
                            <asp:DropDownList runat="server" class="form-control form-control-lg input-lg" ID="DropDownList2" placeholder="Type" Font-Size="Medium" Width="50%" required>
                                <asp:ListItem Value="0">---------- Choose User Role ----------</asp:ListItem>
                                <asp:ListItem Value="2">Accountant</asp:ListItem>
                                <asp:ListItem Value="3">DNS Team</asp:ListItem>
                                <asp:ListItem Value="1">ViewOnly</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button2"  ValidationGroup="B" type="button" runat="server" CssClass="btn btn-success pull-left" Text="Edit User" OnClick="Button2_Click"></asp:Button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
            <!-- Modal -->
        </div></div>

 
           
   
          <script src="js/jquery-1.10.2.js" ></script>
<script src="js/jquery-ui.js" ></script>
<script src="js/bootstrap2.min.js"></script>

 

  <script type="text/javascript">
      debugger
      function openModal() {
          $('#danger').modal('show');

      }
      function openModal2() {
          $('#danger2').modal('show');

      }
  </script>
</asp:Content>
