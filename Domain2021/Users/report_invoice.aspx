<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="report_invoice.aspx.vb" Inherits="Domain2021.report_invoice" ViewStateEncryptionMode="Always" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <table id="tabel1" runat="server" border="0" style="width: 100%;" align="center;">
        <tr>
            <td id="td1" align="center">


                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager><br /><br /><br /><br />
                           
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
                <br />


                <br />

                <p
                    style="text-align: center; font-weight: bold; font-size: Large; width: 70%;">
                    <asp:Label ID="Label13" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>

                </p>
         

    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Spinner.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>

                        <asp:gridView RenderMode="Lightweight"    AutoGenerateColumns="false" ID="GridView1" HeaderStyle-Font-Bold="true"
                            Width="40%"  
                            ShowFooter="True" AllowPaging="True" runat="server" CssClass="table table-bordered" PageSize="10"  HeaderStyle-Font-Names="cairo" Font-Bold="true" >
                 
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Seq" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField  SortExpression="InvoiceSettings_ID" DataField="InvoiceSettings_ID" HeaderText="ShipName"
                                         HeaderStyle-Font-Names="cairo"
                                       ItemStyle-Font-Names="cairo">
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="Date" HeaderText="Date" HeaderStyle-Font-Names="cairo">
                                        <HeaderStyle Font-Names="cairo" />
                                    </asp:BoundField>
                                        <asp:BoundField  DataField="DueAmt" HeaderText="Date" HeaderStyle-Font-Names="cairo">
                                        <HeaderStyle Font-Names="cairo" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Lk" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="det" CausesValidation="false" Height="15px" Width="15px" OnClientClick="return NewWindow();" ><i class="fa fa-print"></i></asp:LinkButton>
                                    </ItemTemplate>
                                 
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="InvoiceSettings_ID" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"  ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                  
                                          <asp:TemplateField>
                                        <ItemTemplate>  
                                               <asp:LinkButton ID="Lk2" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="det2" CausesValidation="false" Height="15px" Width="15px" OnClientClick="return NewWindow();" ><i class="fa fa-info-circle"></i></asp:LinkButton>

                                            </ItemTemplate>
                                 
                                    </asp:TemplateField>
                                           
               <asp:TemplateField>
             <ItemTemplate> 
        <%--                <asp:LinkButton ID="Lk3" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="det5" CausesValidation="false" Height="15px" Width="25px" Visible="false" OnClientClick="return NewWindow();" CssClass="fa fa-receipt" ><i class="fa fa-send"></i></asp:LinkButton>
                --%>       
                 <asp:LinkButton ID="Lk4" runat="server" CommandArgument='<%# Eval("InvoiceSettings_ID") %>' CommandName="det3" CausesValidation="false" Height="15px" Width="25px" OnClientClick="return NewWindow();" CssClass="fa fa-qrcode"  ClientIDMode="Static" ><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
         </ItemTemplate>
      
         </asp:TemplateField>
                                </Columns>
                        

                        </asp:gridView>
                    
                        </div>
                    </ContentTemplate>
                 <Triggers>
                   
                   <asp:PostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
                              <div class="modal fade" id="danger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-target=".bd-example-modal-sm">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-danger">
              <h3 id="isregistered" runat="server" style="color:red"><i class="fa fa-qrcode"></i><i class="fa fa-file-pdf-o"></i></h3>
            </div>
            <div class="modal-body">
              <i class="fa fa-file-pdf"></i>
            <asp:Label ID="lblupdate" Font-Bold="true" Text="Are you sure you want to update?"  runat="server"></asp:Label></center>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnc" runat="server" class="btn btn-default pull-left btn btn-dark" data-dismiss="modal" onclick="location.href='report_invoice.aspx'">Close</button>
                <asp:Button ID="Button4"  type="button" runat="server" CssClass="btn btn-info pull-left" Text="Yes" Visible="false"  ></asp:Button>

            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>      
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
                            <asp:Label ID="Label43" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
      
    </table>
    <script type="text/javascript">
        function openModal() {
            $('#danger').modal('show');

        }
        function openModal2() {
            $('#danger2').modal('show');

        }
        //// Optional: use add_load ONLY if needed for plugin rebinds
        //Sys.Application.add_load(function () {
        //    // Do nothing here unless you really need to rebind plugins
        //});
    </script>
    <script type="text/javascript">



        var onSuccess = function (response) {
            var errorDivs = document.getElementsByClassName("recaptcha-error");
            if (errorDivs.length) {
                errorDivs[0].className = "";
            }
            var errorMsgs = document.getElementsByClassName("recaptcha-error-message");
            if (errorMsgs.length) {
                errorMsgs[0].parentNode.removeChild(errorMsgs[0]);
            }
        };


        function loadGrecaptcha() {
            captchaContainer = grecaptcha.render('grrecaptcha', {
                sitekey: '6Le-N44bAAAAAHw_-_lLq1xDagxMqlp_-wpipDtd',
                callback: function (response) {
                    console.log(response)
                    setTimeout(function () {
                        grecaptcha.reset(captchaContainer);

                    }, 120000);
                }
            });
        };

    </script>

</asp:Content>
