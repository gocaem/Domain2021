<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="DomainDetails.aspx.vb" Inherits="Domain2021.DomainDetails" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
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

                <div class="accordion" id="accordionExample" runat="server" >
                      <asp:Label id="lbl_result" runat="server" ></asp:Label><asp:Label id="lbl_error" runat="server"></asp:Label>
                    <div class="card" id="card1" runat="server"><asp:Label ID="LBL_STATUS" CssClass="alert alert-info" runat="server"></asp:Label>
                        <div class="card-header" id="headingOne">
                          <h2 class="mb-0">
                                <button class="btn btn-link"  type="button"  id="first"  runat="server" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne" >
                                  Name Server Data
                                </button>
                            </h2>
                        </div>

                        <div id="collapseOne"  runat="server" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body">
                        <asp:Panel CssClass="tab-pane" id="ServerP"  role="tabpanel" ClientIDMode="Static" runat="server" >
                                           <asp:CheckBox ID="reservedfuture" AutoPostBack="true" OnCheckedChanged="reservedfuture_CheckedChanged" runat="server" type="CheckBox" /><br />
                                       
                                        <asp:Panel ID="all" runat="server"  >
                                             <div class="row" id="PrimaryNameServerRow" runat="server" visible="true">
                                                <div class="col-lg-4 col-md-4" id="PrimaryNameServer" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label81" runat="server">
                                                        <asp:Label ID="PrimaryNameServerLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="PrimaryNameServerTextBox" runat="server"  required ></asp:TextBox>
                                                        <asp:RequiredFieldValidator SetFocusOnError="true" ForeColor="red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="PrimaryNameServerTextBox" ValidationGroup="a"></asp:RequiredFieldValidator>
                                
                                                        </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div5" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label2" runat="server">
                                                        <asp:Label ID="PrimaryNameServerip" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="PrimaryNameServeripTextBox"  runat="server"  required></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="IPadd" ForeColor="red" ControlToValidate="PrimaryNameServeripTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                    </div>
                                                </div>
                                              
                                            </div>
                                             <div class="row" id="Nameserver2" runat="server" visible="true">
                                                <div class="col-lg-4 col-md-4" id="Div7" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label4" runat="server">
                                                        <asp:Label ID="Nameserver1Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver1TextBox" runat="server"   required></asp:TextBox>
                                                        
                                                        </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="NameserverIP2" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label6" runat="server">
                                                        <asp:Label ID="NameserverIP1Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="NameserverIP1TextBox" runat="server"  required></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="IPadd2" ForeColor="red" ControlToValidate="NameserverIP1TextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                        </div>
                                                </div>
                                          
                                            </div>
                                          
                                                 
                                          <div class="row" id="d0" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div8" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label8" runat="server">
                                                        <asp:Label ID="Nameserver2Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver2TextBox"  runat="server"  required></asp:TextBox>
                                                     </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div9" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label11" runat="server">
                                                        <asp:Label ID="NameserverIP2Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="NameserverIP2TextBox"  runat="server"  required></asp:TextBox>
                                                           <asp:RegularExpressionValidator ID="IPadd3" ForeColor="red" ControlToValidate="NameserverIP2TextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                        </div>
                                                </div>
                                            
                                            </div>

                                             
                                              <div class="row" id="d1" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div20" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label16" runat="server">
                                                        <asp:Label ID="Nameserver3Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver3TextBox"  runat="server"  required></asp:TextBox>
                                                          </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div21" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label20" runat="server">
                                                        <asp:Label ID="Nameserverip3Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserverip3TextBox"  runat="server"  required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd4" ForeColor="red" ControlToValidate="Nameserverip3TextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b" ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                    </div>
                                                </div>
                                            
                                            </div>
                                             <div class="row" id="d2" runat="server">
                                                <div class="col-lg-4 col-md-4" id="Div32" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label36" runat="server">
                                                        <asp:Label ID="Nameserver4Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver4TextBox"  runat="server"  required></asp:TextBox>
                                                         </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div33" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label38" runat="server">
                                                        <asp:Label ID="Nameserver4ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver4ipTextBox"  runat="server"  required></asp:TextBox>
                                                          <asp:RegularExpressionValidator ID="IPadd5" ForeColor="red" ControlToValidate="Nameserver4ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                    </div>
                                                </div>
                                         
                                            </div>
                                             <div class="row" id="d3" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div38" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label49" runat="server">
                                                        <asp:Label ID="Nameserver5Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver5TextBox"  runat="server"  required></asp:TextBox>
                                                            </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div39" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label51" runat="server">
                                                        <asp:Label ID="Nameserver5ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver5ipTextBox"  runat="server"  required></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="IPadd6" ForeColor="red" ControlToValidate="Nameserver5ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                    </div>
                                                </div>
                                            
                                             
                                            </div>
                                             <div class="row" id="d4" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div46" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label62" runat="server">
                                                        <asp:Label ID="Nameserver6Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver6TextBox"  runat="server"  required></asp:TextBox>
                                                            </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div47" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label64" runat="server">
                                                        <asp:Label ID="Nameserver6ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver6ipTextBox"  runat="server"  required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd7" ForeColor="red" ControlToValidate="Nameserver6ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                        </div>
                                                </div>
                                        
                                            </div>
                                             <div class="row" id="d5" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div52" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label72" runat="server">
                                                        <asp:Label ID="Nameserver7Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver7TextBox"  runat="server"  required></asp:TextBox>
                                                         </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div53" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label74" runat="server">
                                                        <asp:Label ID="Nameserver7ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver7ipTextBox"  runat="server"  required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd8" ForeColor="red" ControlToValidate="Nameserver7ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                          
                                                    </div>
                                                </div>
                                   
                                            </div>
                                             <div class="row" id="d6" runat="server">
                                                <div class="col-lg-4 col-md-4" id="Div58" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label83" runat="server">
                                                        <asp:Label ID="Nameserver8Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver8TextBox"  runat="server"  required></asp:TextBox>
                                                         </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div59" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label87" runat="server">
                                                        <asp:Label ID="Nameserver8ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver8ipTextBox"  runat="server"  required></asp:TextBox>
                                                           <asp:RegularExpressionValidator ID="IPadd9" ForeColor="red" ControlToValidate="Nameserver8ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                           
                                                    </div>
                                                </div>
                                
                                            </div>
                                             <div class="row" id="d7" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div64" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label95" runat="server">
                                                        <asp:Label ID="Nameserver9Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver9TextBox"  runat="server"  required></asp:TextBox>
                                                       </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div65" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label97" runat="server">
                                                        <asp:Label ID="Nameserver9ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver9ipTextBox"  runat="server"  required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd10" ForeColor="red" ControlToValidate="Nameserver9ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                           
                                                        </div>
                                                </div>
                                        
                                            </div>
                                             <div class="row" id="d8" runat="server" >
                                                <div class="col-lg-4 col-md-4" id="Div70" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label106" runat="server">
                                                        <asp:Label ID="Nameserver10Label" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver10TextBox"  runat="server"  required></asp:TextBox>
                                                         </div>
                                                </div>
                                                        <div class="col-lg-4 col-md-4" id="Div71" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <label  id="Label108" runat="server">
                                                        <asp:Label ID="Nameserver10ipLabel" runat="server" ></asp:Label></label>
                                                        <asp:TextBox CssClass="form-control" ID="Nameserver10ipTextBox"  runat="server"  required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd11" ForeColor="red" ControlToValidate="Nameserver10ipTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"  ValidationGroup="a"></asp:RegularExpressionValidator>
                                           
                                                    </div>
                                                </div>
                               
                                            </div>


                                            
                                        
                                            
                                        </asp:Panel> 
                                    </asp:Panel>
                                  <asp:LinkButton ID="NextToStep2" runat="server" CssClass="btn btn-success" ValidationGroup="a" OnClick="Next_Click"></asp:LinkButton>

                            </div>
                        </div>
                    </div>
                    <div class="card">                 <div class="card-header" id="headingTwo">
                         <h2 class="mb-0">
                                <button class="btn btn-link" type="button" id="Second1" runat="server" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" >
                                    Collapsible Group Item #2
                                </button>
                            </h2>
                        </div>
                        <div id="collapseTwo" clientidmode="static"  runat="server" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                            <div class="card-body">
                               <asp:Panel ID="ContactPanel" runat="server"  >
                                            <asp:Label ID="OwnerDetailsLabel" CssClass="alert alert-info" runat="server"  Text="Owner Info" Width="100%"></asp:Label>
                                            <div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-6 col-md-6" id="Div10" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="OwnerName" runat="server" ></asp:Label>
                                                         <asp:Label    ID="OwnerNameLbl" ForeColor="red" runat="server" ></asp:Label>
                                                        </div>
                                                </div> <div class="col-lg-6 col-md-6" id="Div1" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="EntityName" runat="server" ></asp:Label>
                                                         <asp:Label  ID="lblentity" ForeColor="red" runat="server" ></asp:Label>
                                                        </div>
                                                </div></div><div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-6 col-md-6" id="Div11" runat="server">
                                                    <div class="form-group">
                                                         <asp:Label ID="OwnerMobileLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="OwnerMobileTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="OwnerMobileValidator" runat="server" ControlToValidate="OwnerMobileTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            
                                                <div class="col-lg-6 col-md-6" id="Div12" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="OwnerEmailLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control"  ID="OwnerEmailTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="OwnerEmailValidator" runat="server" ControlToValidate="OwnerEmailTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="OwnerEmailExpressionValidator" runat="server" ControlToValidate="OwnerEmailTextBox"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                    </div>
                                                </div>
                                         
                                            <asp:Label ID="TechDetailsLabel" CssClass="alert alert-info" runat="server"  Text="Tech Info" Width="100%"></asp:Label>
                                            <div class="row" style="height:auto;font-weight:bold">
                                                <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="TechLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control"  ID="TechTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechValidator" runat="server" ControlToValidate="TechTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                                    <div class="form-group">
                                                           <asp:Label ID="TechMobileLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="TechMobileTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechMobileValidator" runat="server" ControlToValidate="TechMobileTextBox" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="TechEmailLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="TechEmailTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechEmailTextBoxValidator" runat="server" ControlToValidate="TechEmailTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="TechEmailExpressionValidator" runat="server" ControlToValidate="TechEmailTextBox" SetFocusOnError="true"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                                </div>
                                            </div>
                                       
                                            <asp:Label ID="AdminDetails" CssClass="alert alert-info" runat="server"  Text="Admin Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminDetailsLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="AdminTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminTextBoxValidator" runat="server" ControlToValidate="AdminTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminMobileLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="AdminMobileTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminMobileTextBoxValidator" runat="server" ControlToValidate="AdminMobileTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminEmailLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control font-bold" ID="AdminEmailTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminEmailTextBoxValidator" runat="server" ControlToValidate="AdminEmailTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="AdminEmailExpressionValidator" runat="server" ControlToValidate="AdminEmailTextBox" SetFocusOnError="true"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                        </div>
                                                </div>
                                         
                                            <asp:Label ID="BillingDetails" CssClass="alert alert-info" runat="server"  Text="Billing Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div28" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="BillTextBox" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillingValidator" runat="server" ControlToValidate="BillTextBox" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div29" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillMobileLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="BillMobileText" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillMobileValidator" runat="server" ControlToValidate="BillMobileText" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div30" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillEmailLabel" runat="server" ></asp:Label>
                                                         <asp:TextBox   CssClass="form-control" ID="BillEmail" runat="server"  required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="BillEmailValidator" runat="server" ControlToValidate="BillEmail" SetFocusOnError="true" ValidationGroup="b"></asp:RequiredFieldValidator>
                                                       <asp:RegularExpressionValidator ID="BillEmailExpressionValidator" runat="server" ControlToValidate="BillEmail" SetFocusOnError="true"  ValidationGroup="b"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                     
                                                    </div>
                                                </div>
                                          
                                                         <asp:LinkButton ID="prev" runat="server"  CssClass="btn btn-dark" OnClick="prev_Click" Font-Bold="true"></asp:LinkButton>

                                                      <asp:LinkButton ID="NextToStep4" runat="server" ValidationGroup="b" CssClass="btn btn-success" OnClick="NextToStep4_Click"></asp:LinkButton>
                                                     
                                                      <asp:LinkButton ID="Cancel" runat="server" Visible="false" ForeColor="White" Font-Bold="true" CssClass="btn btn-warning" OnClick="Cancel_Click"></asp:LinkButton>
                                      
                                                              
                                        </asp:Panel>
                                </div>
                        </div><br />
                
                    </div>
                    
                </div>    

        </ContentTemplate>
 <Triggers>
     <asp:PostBackTrigger ControlID="prev"  />
     <asp:PostBackTrigger ControlID="NextToStep2"  />
     <asp:PostBackTrigger ControlID="NextToStep4"  />
     <asp:AsyncPostBackTrigger ControlID="reservedfuture" EventName="CheckedChanged" />
 </Triggers>
    </asp:UpdatePanel>   <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="b" ShowMessageBox="true"  Width="50%" DisplayMode="List" />
         
     <%--    <script src="https://code.jquery.com/jquery.js"></script>--%>
        <script src="../Assets/toastr.min.js" async defer></script>
        <script src="../Assets/script.js" async defer></script>
        <link href="../Assets/toastr.min.css" rel="stylesheet" media="all"/>      
            </td>
        </tr>
    </table>                        </center>
    <br />
    <br />
</asp:Content>
