<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Extract_DN.aspx.vb" Inherits="Domain2021.Extract_DN" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <script>
           $(document).ready(function () {
               var collapse = document.getElementById("li2")
               collapse.className = "active";


           });
       </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label><asp:Label
                ID="lbl_Result" runat="server" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="g" Font-Size="Small" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="e" Font-Size="Small" />
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Extract Domain Name</p>
                                                <div class="table-responsive">
                                                    <p>
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label><asp:Label ID="Label4" runat="server" ForeColor="Blue"></asp:Label>
                                                    </p>


                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">

                                                        <asp:Label ID="Label1" runat="server">Domain Name</asp:Label>

                                                        <asp:TextBox ID="txt_domain_name" runat="server" ValidationGroup="e"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_domain_name"
                                                            EnableClientScript="False" ErrorMessage="enter domain name" ValidationGroup="e">*</asp:RequiredFieldValidator>

                                                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-info" ValidationGroup="e" />
                                                    </div>





                                                </div>


                                                <asp:DataGrid ID="DataGrid1" runat="server" GridLines="None" CssClass="table table-responsive" AutoGenerateColumns="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False">
                                                    <Columns>
                                                        <asp:BoundColumn DataField="DOMAIN_ID" HeaderText="ID" SortExpression="DOMAIN_ID"
                                                            Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="OWNER_NAME" HeaderText="Owner Name" SortExpression="OWNER_NAME"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="DOMAIN_NAME" HeaderText="Domain Name" SortExpression="DOMAIN_NAME"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SECOND_DOMAIN" HeaderText="Second Domain" SortExpression="SECOND_DOMAIN"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ORG_NAME" HeaderText="Organization Name" SortExpression="ORG_NAME"></asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Ok">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Ok" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="ADMIN_ID" HeaderText="Admin ID" SortExpression="ADMIN_ID"
                                                            Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL"></asp:BoundColumn>
                                                    </Columns>

                                                </asp:DataGrid></td>
     <div id="d2" runat="server" visible="false" style="font-weight: bold; font-family: Calibri">
         <asp:Label ID="Label2" runat="server">E-Mail</asp:Label></td>
          
                <asp:TextBox ID="txt_email" runat="server" ValidationGroup="g"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email"
             ErrorMessage="Enter E-Mail" ValidationGroup="g">*</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_email"
             ErrorMessage="Enter Valid E-Mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
             ValidationGroup="g">*</asp:RegularExpressionValidator></td>
     
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="send password"
                    ValidationGroup="g" />
     </div>
                                                <div class="card-footer">
                                                    <div class="">
                                                        <asp:Button ID="Button3" runat="server" Text="update" CssClass="btn btn-warning" Width="50%" ValidationGroup="A" Visible="false"></asp:Button>

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
   
</asp:Content>
