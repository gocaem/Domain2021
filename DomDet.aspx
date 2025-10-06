<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="DomDet.aspx.vb" Inherits="Domain2021.DomDet" ViewStateEncryptionMode="Always"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <center> <table id="tabel1" runat="server" border="0" style="width: 60%;" align="center;">
        <tr>
            <td id="td1" align="center">
                <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server" >
        <ContentTemplate>

                <div class="accordion" id="accordionExample" runat="server" style="font-weight:bold">
                      <asp:Label id="lbl_result" runat="server" ></asp:Label><asp:Label id="lbl_error" runat="server"></asp:Label>
                    <div class="card" id="card1" runat="server"><asp:Label ID="LBL_STATUS" CssClass="alert alert-info" runat="server" Text="Label"></asp:Label>
                 
                                   <div class="card">                 <div class="card-header" id="headingTwo">
                         <h2 class="mb-0">
                                <button class="btn btn-link" type="button" id="Second1" runat="server" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" style="font-weight:bold">
                                    Collapsible Group Item #2
                                </button>
                            </h2>
                        </div>
                        <div id="collapseTwo" clientidmode="static"  runat="server" class="collapse show" aria-labelledby="headingTwo" data-parent="#accordionExample">
                            <div class="card-body">
                               <asp:Panel ID="ContactPanel" runat="server" style="font-weight:bold">
                                            <asp:Label ID="OwnerDetailsLabel" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Owner Info" Width="100%"></asp:Label>
                                            <div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="OwnerName" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox Enabled="false" Font-Bold="true" CssClass="form-control" ID="OwnerNameTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="OwnerNameRequiredFieldValidator" runat="server" ControlToValidate="OwnerNameTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                                    <div class="form-group">
                                                         <asp:Label ID="OwnerMobileLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" Enabled="false" CssClass="form-control" ID="OwnerMobileTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="OwnerMobileValidator" runat="server" ControlToValidate="OwnerMobileTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="OwnerEmailLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" Enabled="false" CssClass="form-control"  ID="OwnerEmailTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="OwnerEmailValidator" runat="server" ControlToValidate="OwnerEmailTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="OwnerEmailExpressionValidator" runat="server" ControlToValidate="OwnerEmailTextBox"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                    </div>
                                                </div>
                                         <div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-4 col-md-4" id="Div14" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="RegDateL" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox Enabled="false" Font-Bold="true" CssClass="form-control" ID="reg_date" runat="server" required></asp:TextBox>
                                                            </div>
                                                </div>
                                              </div>
                                            <asp:Label ID="TechDetailsLabel" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Tech Info" Width="100%"></asp:Label>
                                            <div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="TechLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" Enabled="false" CssClass="form-control"  ID="TechTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechValidator" runat="server" ControlToValidate="TechTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                                    <div class="form-group">
                                                           <asp:Label ID="TechMobileLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" Enabled="false" CssClass="form-control" ID="TechMobileTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechMobileValidator" runat="server" ControlToValidate="TechMobileTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="TechEmailLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="TechEmailTextBox" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechEmailTextBoxValidator" runat="server" ControlToValidate="TechEmailTextBox" Enabled="false" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="TechEmailExpressionValidator" runat="server" ControlToValidate="TechEmailTextBox"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                                </div>
                                            </div>
                                       
                                            <asp:Label ID="AdminDetails" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Admin Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminDetailsLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="AdminTextBox" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminTextBoxValidator" runat="server" ControlToValidate="AdminTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminMobileLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="AdminMobileTextBox" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminMobileTextBoxValidator" runat="server" ControlToValidate="AdminMobileTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminEmailLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control font-bold" ID="AdminEmailTextBox" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminEmailTextBoxValidator" runat="server" ControlToValidate="AdminEmailTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="AdminEmailExpressionValidator" runat="server" ControlToValidate="AdminEmailTextBox"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                        </div>
                                                </div>
                                         
                                            <asp:Label ID="BillingDetails" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Billing Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div28" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="BillTextBox" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillingValidator" runat="server" ControlToValidate="BillTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div29" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillMobileLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="BillMobileText" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillMobileValidator" runat="server" ControlToValidate="BillMobileText" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div30" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillEmailLabel" runat="server" Font-Bold="True"></asp:Label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="BillEmail" runat="server"  required Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillEmailValidator" runat="server" ControlToValidate="BillEmail" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                       <asp:RegularExpressionValidator ID="BillEmailExpressionValidator" runat="server" ControlToValidate="BillEmail"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                    </div>
                                                </div>
                                          
                                            
                                  
                                                              
                                        </asp:Panel>
                                </div>
                        </div>
                          </div>
                           <div class="card-header" id="headingOne">
                          <h2 class="mb-0">
                                <button class="btn btn-link" type="button" id="first" runat="server" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="font-weight:bold">
                                  Name Server Data
                                </button>
                            </h2>
                        </div><div id="collapseOne" clientidmode="static"  runat="server" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body">
                        <asp:Panel CssClass="tab-pane" Enabled="false" id="ServerP"  role="tabpanel" ClientIDMode="Static" runat="server" style="font-weight:bold">
                                           <asp:CheckBox Visible="false" ID="reservedfuture" AutoPostBack="true"  runat="server" type="CheckBox" /><br />
                                       
                                        <asp:Panel ID="all" runat="server">
                                             <div class="row" id="PrimaryNameServerRow" runat="server" visible="true">
                                                <div class="col-lg-4 col-md-4" id="PrimaryNameServer" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label81" runat="server">
                                                        <asp:Label ID="PrimaryNameServerLabel" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="PrimaryNameServerTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="PrimaryNameServerValidator" runat="server" ControlToValidate="PrimaryNameServerTextBox" ValidationGroup="b" ></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                   <div class="col-lg-1 col-md-1" id="Div42" runat="server">
                                                    <div class="form-group">
                                                        <br />    <label  id="Label23" runat="server"></label>
                                                        <label  id="Label85" runat="server">
                                                            <asp:Label ID="Label86" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                        
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div41" runat="server" >
                                                         <br />    <label  id="Label24" runat="server"></label>
                                                        <label  id="Label25" runat="server">
                                                            <asp:Label ID="Label26" runat="server" Font-Bold="True"></asp:Label></label>
                                                 
                                                </div>
                                               <div class="col-lg-3 col-md-3" id="Div13" runat="server">
                                                   
                                                </div>
                                            </div>
                                              <div class="row" id="SecondServer5row1" runat="server">
                                                <div class="col-lg-4 col-md-4" id="SecondServer5Div"   runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label11" runat="server">
                                                            <asp:Label ID="SecondServer5" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="SecondServer5TextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="SecondServer5Validator" runat="server" ControlToValidate="SecondServer5TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="SecondServer6DIV"  runat="server" >
                                                    <div class="form-group">
                                                        <label  id="Label13" runat="server">
                                                            <asp:Label ID="SecondServer6" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="SecondServer6TextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="SecondServer6Validator" runat="server" ControlToValidate="SecondServer6TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div9" runat="server">
                                                         <div class="form-group">
                                                        <br />    <label  id="Label115" runat="server"></label>
                                                        <label  id="Label16" runat="server">
                                                            <asp:Label ID="Label41" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                          
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="SecondServer3row2" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="SecondServer3Div"  runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label69" runat="server">
                                                            <asp:Label ID="SecondServer3" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="SecondServer3TextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="SecondServer3FieldValidator" runat="server" ControlToValidate="SecondServer3TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="SecondServer4Div"   runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label71" runat="server">
                                                            <asp:Label ID="SecondServer4" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="SecondServer4TextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="SecondServer4Validator" runat="server" ControlToValidate="SecondServer4TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div36" runat="server">
                                                     <div class="form-group">
                                                        <br />    <label  id="Label38" runat="server"></label>
                                                        <label  id="Label39" runat="server">
                                                            <asp:Label ID="Label40" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                            
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="Second_name1Row3" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Second_name1Div"  runat="server">
                                                    <div class="form-group">
                                                        <label id="Label75" runat="server">
                                                        <asp:Label ID="Second_name1Label" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="Second_nameTextBox1" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Second_name1Validator" runat="server" ControlToValidate="Second_nameTextBox1" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                      
                                                        </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Second_name2Div"  runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label77" runat="server">
                                                         <asp:Label ID="Second_name2Label" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="Second_name2TextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Second_name2Validator" runat="server" ControlToValidate="Second_name2TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div39" runat="server">
                                                      <div class="form-group">
                                                        <br /><label  id="Label27" runat="server"></label>
                                                        <label  id="Label28" runat="server">
                                                        <asp:Label ID="Label37" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                                     <div class="row" id="Div1" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div2"  runat="server">
                                                    <div class="form-group">
                                                        <label id="Label1" runat="server">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="TextBox1" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Second_nameTextBox1" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                      
                                                        </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div3"  runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label3" runat="server">
                                                         <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="TextBox2" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Second_name2TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div4" runat="server">
                                                      <div class="form-group">
                                                        <br /><label  id="Label5" runat="server"></label>
                                                        <label  id="Label6" runat="server">
                                                        <asp:Label ID="Label7" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="Div5" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div6"  runat="server">
                                                    <div class="form-group">
                                                        <label id="Label8" runat="server">
                                                        <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="TextBox3" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Second_nameTextBox1" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                      
                                                        </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div7"  runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label10" runat="server">
                                                         <asp:Label ID="Label12" runat="server" Font-Bold="True"></asp:Label></label>
                                                         <asp:TextBox  Font-Bold="true" CssClass="form-control" ID="TextBox4" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Second_name2TextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div8" runat="server">
                                                      <div class="form-group">
                                                        <br /><label  id="Label14" runat="server"></label>
                                                        <label  id="Label15" runat="server">
                                                        <asp:Label ID="Label17" runat="server" Text="" Font-Bold="True"></asp:Label></label>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel> 
                                    </asp:Panel>
                               
                            </div>
                        </div>
                </div>  
                        
                    </div>
           

        </ContentTemplate>

    </asp:UpdatePanel>
            </td>
        </tr>
    </table>                        </center>
    <br />
    <br />
</asp:Content>
