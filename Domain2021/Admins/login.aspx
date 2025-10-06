<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Domain2021.login" ViewStateEncryptionMode="Always" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <title>Login Page </title>
    <link rel="apple-touch-icon" sizes="60x60" href="app-assets/images/ico/apple-icon-60.png">
    <link rel="apple-touch-icon" sizes="76x76" href="app-assets/images/ico/apple-icon-76.png">
    <link rel="apple-touch-icon" sizes="120x120" href="app-assets/images/ico/apple-icon-120.png">
    <link rel="apple-touch-icon" sizes="152x152" href="app-assets/images/ico/apple-icon-152.png">
    <link rel="shortcut icon" type="image/x-icon" href="app-assets/images/ico/favicon.ico">
    <link rel="shortcut icon" type="image/png" href="app-assets/images/ico/favicon-32.png">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/bootstrap.css">
    <!-- font icons-->
    <link rel="stylesheet" type="text/css" href="app-assets/fonts/icomoon.css">
    <link rel="stylesheet" type="text/css" href="app-assets/fonts/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" type="text/css" href="app-assets/vendors/css/extensions/pace.css">
    <!-- END VENDOR CSS-->
    <!-- BEGIN ROBUST CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/bootstrap-extended.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/app.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/colors.css">
    <!-- END ROBUST CSS-->
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/core/menu/menu-types/vertical-menu.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/core/menu/menu-types/vertical-overlay-menu.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/pages/login-register.css">
    <!-- END Page Level CSS-->
    <!-- BEGIN Custom CSS-->
    <link rel="stylesheet" type="text/css" href="/assets/css/style.css">
    <!-- END Custom CSS-->
    <style type="text/css">
        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
            }

            table, table table td {
                border: 0px solid #ccc;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="app-content content container-fluid">
                <div class="content-wrapper">
                    <div class="content-header row">
                    </div>
                    <div class="content-body">
                        <section class="flexbox-container">
                            <div class="col-md-4 offset-md-4 col-xs-10 offset-xs-1  box-shadow-2 p-0">
                                <div class="card border-grey border-lighten-3 m-0">
                                    <div class="card-header no-border">
                                        <div class="card-title text-xs-center">
                                            <div class="p-1">
                                                <img src="app-assets/3MODEE-news-0.png" alt="branding logo"></div>
                                        </div>
                                        <%--                <h6 class="card-subtitle line-on-side text-muted text-xs-center font-small-3 pt-2"><span>Login with Robust</span></h6>
                                        --%>
                                    </div>
                                    <div class="card-body collapse in" id="divLogin" runat="server">
                                        <div class="card-block">
                                            <form class="form-horizontal form-simple">
                                                <fieldset class="form-group position-relative has-icon-left mb-0">
                                                    <asp:TextBox runat="server" type="text" class="form-control form-control-lg input-lg" ID="username" placeholder="Your Username" required></asp:TextBox>
                                                    <div class="form-control-position">
                                                        <i class="icon-head"></i>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="username" runat="server" ErrorMessage="Username Required"></asp:RequiredFieldValidator>

                                                    <asp:TextBox runat="server" type="password" class="form-control form-control-lg input-lg" ID="userpassword" placeholder="Enter Password" required></asp:TextBox>
                                                    <div class="form-control-position">
                                                        <i class="icon-key3"></i>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="userpassword" runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator>


                                                    <br />
                                                    <label id="Result" style="color: red" runat="server" visible="false" class=" text-red"></label>
                                                    <cc1:CaptchaControl ID="captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                                        CaptchaMaxTimeout="240" FontColor="#529E00" ErrorInputTooFast="Image text was typed too quickly. " ErrorInputTooSlow="Image text was typed too slowly." EnableViewState="False" />
                                                    <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCaptcha" runat="server" ErrorMessage="*Required" ForeColor="Red"
                                                        ControlToValidate="txtCaptcha" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                    <asp:Button runat="server" ID="btnSubmit" type="submit" Style="background-color: #808080; border-color: #808080" CssClass="btn btn-primary btn-lg btn-block" Text="Login" />

                                                </fieldset>
                                            </form>
                                        </div>
                                    </div>
                                    <div class="card-body collapse in" id="divOTP" runat="server" visible="false">
                                        <div class="card-block">

                                            <fieldset class="form-group position-relative has-icon-left mb-0">
                                                <asp:TextBox runat="server" type="text" TextMode="Number" class="form-control form-control-lg input-lg" ID="OTPCode" placeholder="Enter OTP sent to your Email" required MaxLength="6" ValidationGroup="OTP"></asp:TextBox>
                                                <div class="form-control-position">
                                                    <i class="icon-head"></i>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="OTP" ControlToValidate="OTPCode" runat="server" ErrorMessage="OTPCode Required" Style="color: red"></asp:RequiredFieldValidator><br />
                                            </fieldset>


                                            <label id="Label1" style="color: red" runat="server" visible="false" class=" text-red"></label>
                                            <br />

                                            <asp:Button ID="VerifyOtp" ValidationGroup="OTP" CssClass="btn btn-blue" OnClick="LinkButton1_Click1" runat="server" Text="Send OTP" />

                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <div class="">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>

                    </div>
                </div>
            </div>
    </form>

    <script src="https://www.google.com/recaptcha/api.js"></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=loadGrecaptcha&render=explicit"
        async defer>
    </script>
    <script src='/recaptcha/api.js' async defer nonce="p2hsmNkx8Q7+COM4SV8wKg"></script>

    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>

    <link href="js/toastr.css" rel="stylesheet" />

    <script src="js/toastr.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        function Notify(msg, title, type, clear, pos, sticky) {
            Debbuger
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
</body>

</html>
