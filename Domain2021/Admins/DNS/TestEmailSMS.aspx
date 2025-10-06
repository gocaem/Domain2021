<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="TestEmailSMS.aspx.vb" Inherits="Domain2021.TestEmailSMS" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
                 <script>
                     $(document).ready(function () {
                         var collapse = document.getElementById("li2")
                         collapse.className = "active";


                     });
                 </script>

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
                                        <p class="card-text text-bold-900" style="font-size: 16px">Email SMS Test</p>
                                        <div class="table-responsive">
                                            <table class="table">
           
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button3" CssClass="btn btn-cyan pull-center" OnClick="Button3_Click" runat="server" Font-Bold="True" Text="Send Mail" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td> <asp:Button ID="Button1" CssClass="btn btn-cyan pull-center" OnClick="Button1_Click" runat="server" Font-Bold="True" Text="Send SMS" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" ForeColor="#990000" Style="font-weight: 700"></asp:Label>
                                                    </td>
                                                </tr>

                                            </table>
                                            <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
                                            <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

                                            <script src="https://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript" defer async></script>

                                            <link href="../assets/css/toastr.css"
                                                rel="stylesheet" media="all"/>

                                            <script src="../assets/js/toastr.js" defer async
                                                type="text/javascript"></script>

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
                                        </div></div></div></div></div></section></div></div></div></div>

               <script>
                   $(document).ready(function () {
                       var collapse = document.querySelectorAll('#sidebar> ul >li>#submenu-4 ');
                       $(collapse).collapse('toggle');

                   });
               </script>
</asp:Content>
