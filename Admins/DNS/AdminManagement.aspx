<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="AdminManagement.aspx.vb" Inherits="Domain2021.AdminManagement" ViewStateEncryptionMode="Always" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                            <img src="../app-assets/3MODEE-news-0.png" alt="branding logo"></div>
                                    </div>
                                </div>
                                <div class="card-body collapse in">
                                    <div class="card-block card-dashboard">
                                        <p class="card-text text-bold-900" style="font-size: 16px">Manage Admin info</p>
                                        <div class="table-responsive">
                                            <p>
                                                <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="lbl_Result" runat="server" ForeColor="Blue"></asp:Label></p>


                                            <div class="modal-body" style="font-weight:bold;font-family:Calibri">
                                                Admin ID:<asp:TextBox ID="txt_admin_id" CssClass="form-control form-control-lg input-lg" runat="server" Width="50%"></asp:TextBox>
                                                <asp:Button ID="Button3" runat="server" Text="fill" CssClass=" form-group btn btn-cyan" Width="50%"></asp:Button>
                                                <br /><asp:panel ID="panel1" Visible="false" CssClass="panel panel-collapse" GroupingText="Details" ForeColor="CadetBlue" runat="server">
                                                <asp:Label ID="result" runat="server" ForeColor="red" Text="Label" Visible="false"></asp:Label>
                                                <br />Username:<asp:TextBox CssClass="form-control form-control-lg input-lg" ID="username" Width="50%" runat="server" placeholder="username"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="username Required" ValidationGroup="A" ControlToValidate="username" ForeColor="red"></asp:RequiredFieldValidator>
                                         

                                                          <br />Admin Name:<asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Name" Width="50%" runat="server" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="A" ControlToValidate="Name" ErrorMessage="Name Required" ForeColor="red"></asp:RequiredFieldValidator>
                                               <br />Mobile Number:<asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Mobile" Width="50%" runat="server" placeholder="Mobile"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="A" ControlToValidate="Mobile" ErrorMessage="Mobile Required" ForeColor="red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regex" runat="server" ValidationGroup="A" ControlToValidate="Mobile" ValidationExpression="(07)[7-9]{1}[0-9]{7}" ErrorMessage="Invalid Mobile No(Jordanian)" ForeColor="red"></asp:RegularExpressionValidator>

                                                         <br />Email:<asp:TextBox CssClass="form-control form-control-lg input-lg" ID="Email" Width="50%" runat="server" placeholder="Email"></asp:TextBox>
                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="A" ControlToValidate="Email" ErrorMessage="Email Required" ForeColor="red"></asp:RequiredFieldValidator>
                                            
                                                      </asp:panel>
                                            </div>





                                        </div>




                                        <div class="card-footer">
                                            <div class="">   <asp:Button ID="Button1" runat="server" Text="update" CssClass=" form-group btn btn-green" Width="50%" ValidationGroup="A" Visible="false"></asp:Button>
                                          
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

         </ContentTemplate>
        <Triggers>
          
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
       <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
<link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>


<link href="../assets/css/toastr.css"
    rel="stylesheet" media="all"/>

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
    
</asp:Content>

