<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="RegisterDomain.aspx.vb" Inherits="Domain2021.RegisterDomain" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />

    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
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
                sitekey: '6Ldxr4sbAAAAABxr6vJVz3f_IHqeipXrOWgDbQiu',
                callback: function (response) {
                    console.log(response)
                    setTimeout(function () {
                        grecaptcha.reset(captchaContainer);

                    }, 120000);
                }
            });
        };



    </script>
    <style>
        button,
        input {
            font-family: "Montserrat", "Helvetica Neue", Arial, sans-serif;
        }

    


        p {
            line-height: 1.61em;
            font-weight: 300;
            font-size: 1.2em;
        }

        .category {
            text-transform: capitalize;
            font-weight: 700;
        }



        .nav-item .nav-link,
        .nav-tabs .nav-link {
            -webkit-transition: all 300ms ease 0s;
            -moz-transition: all 300ms ease 0s;
            -o-transition: all 300ms ease 0s;
            -ms-transition: all 300ms ease 0s;
            transition: all 300ms ease 0s;
        }

        .card a {
            -webkit-transition: all 150ms ease 0s;
            -moz-transition: all 150ms ease 0s;
            -o-transition: all 150ms ease 0s;
            -ms-transition: all 150ms ease 0s;
            transition: all 150ms ease 0s;
        }

        [data-toggle="collapse"][data-parent="#accordion"] i {
            -webkit-transition: transform 150ms ease 0s;
            -moz-transition: transform 150ms ease 0s;
            -o-transition: transform 150ms ease 0s;
            -ms-transition: all 150ms ease 0s;
            transition: transform 150ms ease 0s;
        }

        [data-toggle="collapse"][data-parent="#accordion"][aria-expanded="true"] i {
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=2);
            -webkit-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            transform: rotate(180deg);
        }


        .now-ui-icons {
            display: inline-block;
            font: normal normal normal 14px/1 'Nucleo Outline';
            font-size: inherit;
            speak: none;
            text-transform: none;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }

        @-webkit-keyframes nc-icon-spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @-moz-keyframes nc-icon-spin {
            0% {
                -moz-transform: rotate(0deg);
            }

            100% {
                -moz-transform: rotate(360deg);
            }
        }

        @keyframes nc-icon-spin {
            0% {
                -webkit-transform: rotate(0deg);
                -moz-transform: rotate(0deg);
                -ms-transform: rotate(0deg);
                -o-transform: rotate(0deg);
                transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
                -moz-transform: rotate(360deg);
                -ms-transform: rotate(360deg);
                -o-transform: rotate(360deg);
                transform: rotate(360deg);
            }
        }

        .now-ui-icons.objects_umbrella-13:before {
            content: "\ea5f";
        }

        .now-ui-icons.shopping_cart-simple:before {
            content: "\ea1d";
        }

        .now-ui-icons.shopping_shop:before {
            content: "\ea50";
        }

        .now-ui-icons.ui-2_settings-90:before {
            content: "\ea4b";
        }

        .nav-tabs {
            border: 0;
            padding: 15px 0.7rem;
        }

            .nav-tabs:not(.nav-tabs-neutral) > .nav-item > .nav-link.active {
                box-shadow: 0px 5px 35px 0px rgba(0, 0, 0, 0.3);
            }

        .card .nav-tabs {
            border-top-right-radius: 0.1875rem;
            border-top-left-radius: 0.1875rem;
        }

        .nav-tabs > .nav-item > .nav-link {
            margin: 0;
            margin-right: 5px;
            background-color: transparent;
            border: 1px solid transparent;
            border-radius: 30px;
            font-size: 14px;
            padding: 11px 23px;
            line-height: 1.5;
        }

            .nav-tabs > .nav-item > .nav-link:hover {
                background-color: transparent;
            }

            .nav-tabs > .nav-item > .nav-link.active {
                background-color: #444;
                border-radius: 30px;
                color: #FFFFFF;
            }

            .nav-tabs > .nav-item > .nav-link i.now-ui-icons {
                font-size: 14px;
                position: relative;
                top: 1px;
                margin-right: 3px;
            }

        .nav-tabs.nav-tabs-neutral > .nav-item > .nav-link {
            color: #FFFFFF;
        }

            .nav-tabs.nav-tabs-neutral > .nav-item > .nav-link.active {
                background-color: rgba(255, 255, 255, 0.2);
                color: #FFFFFF;
            }

        .card {
            border: 0;
            border-radius: 0.1875rem;
            display: inline-block;
            position: relative;
            width: 100%;
            margin-bottom: 30px;
            box-shadow: 0px 5px 25px 0px rgba(0, 0, 0, 0.2);
        }
        .g-recaptcha {
transform:scale(0.77);
transform-origin:0 0;
}
            .card .card-header {
                background-color: transparent;
                border-bottom: 0;
                background-color: transparent;
                border-radius: 0;
                padding: 0;
            }

            .card[data-background-color="orange"] {
                background-color: #f96332;
            }

            .card[data-background-color="red"] {
                background-color: #FF3636;
            }

            .card[data-background-color="yellow"] {
                background-color: #FFB236;
            }

            .card[data-background-color="blue"] {
                background-color: #2CA8FF;
            }

            .card[data-background-color="green"] {
                background-color: #15b60d;
            }

        [data-background-color="orange"] {
            background-color: #e95e38;
        }

        [data-background-color="black"] {
            background-color: #2c2c2c;
        }

        [data-background-color]:not([data-background-color="gray"]) {
            color: #FFFFFF;
        }

            [data-background-color]:not([data-background-color="gray"]) p {
                color: #FFFFFF;
            }

            [data-background-color]:not([data-background-color="gray"]) a:not(.btn):not(.dropdown-item) {
                color: #FFFFFF;
            }

            [data-background-color]:not([data-background-color="gray"]) .nav-tabs > .nav-item > .nav-link i.now-ui-icons {
                color: #FFFFFF;
            }




        .now-ui-icons {
            display: inline-block;
            font: normal normal normal 14px/1 'Nucleo Outline';
            font-size: inherit;
            speak: none;
            text-transform: none;
            /* Better Font Rendering */
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }



        @media screen and (max-width: 768px) {

            .nav-tabs {
                display: inline-block;
                width: 100%;
                padding-left: 100px;
                padding-right: 100px;
                text-align: center;
            }

                .nav-tabs .nav-item > .nav-link {
                    margin-bottom: 5px;
                }
        }
    </style>

    <asp:UpdatePanel ID="panel1" runat="server">
        <ContentTemplate>
            <div class="container mt-5" dir="rtl" id="container" runat="server">
                <div class="row">
                    <div class="col-md-12 ml-auto col-xl-12 mr-auto">
                        <br />
                        <center>
                            <asp:Label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                
                                <asp:Label ID="Note" runat="server" CssClass="alert alert-info" ></asp:Label><br /><br />        </center>
                           
                        <div class="card">
                            <div class="card-header">
                                <ul class="nav nav-tabs justify-content-center" role="tablist" dir="rtl" id="nav" runat="server">
                                    <li class="nav-item home">
                                        <a class="nav-link active" data-toggle="tab" href="#AccountInfo" role="tab" dir="rtl" id="AccountInfotab" runat="server" style="font-family: cairo; font-weight: bold">
                                            <i class="fa fa-user" style="padding-left: 10px"></i>انشاء حساب خاص
                                        </a>
                                    </li>

                                </ul>
                            </div>

                            <div class="card-body">

                                <div class="tab-content text-center">
                                    <asp:Panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="AccountInfo" role="tabpanel">
                                             <div class="row">

                                            <div class="col-lg-4 col-md-4" id="Div5" runat="server">
                                                <div class="form-group">
                                                    
                                                        <asp:Label ID="UsernameL" runat="server" Font-Bold="True"></asp:Label><label id="Label2" runat="server" style="color:red; font-weight:bold">*</label>
                                                    <asp:TextBox CssClass="form-control" ID="Username" runat="server"  required  ClientIDMode="Static" AutoPostBack="true" OnTextChanged="Username_TextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UsernamerequiredValidator" Font-Bold="true" SetFocusOnError="true" ValidationGroup="AC" runat="server" ControlToValidate="Username"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lbl_user_name_error" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:RegularExpressionValidator ID="UserValidchar" runat="server"  ControlToValidate="Username" ErrorMessage="RegularExpressionValidator"  ValidationExpression="^\S*$" ValidationGroup="AC"></asp:RegularExpressionValidator> 
                                  
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4" id="Div6" runat="server">
                                                <div class="form-group">
                                                    
                                                        <asp:Label ID="PasswordL" runat="server" Font-Bold="True"></asp:Label><label id="Label5" runat="server" style="color:red; font-weight:bold">*</label>
                                                    <asp:TextBox CssClass="form-control" ID="PasswordT" runat="server" required TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PassValidator" Font-Bold="true" SetFocusOnError="true" ValidationGroup="AC" runat="server" ControlToValidate="PasswordT"></asp:RequiredFieldValidator>

                                                    <div class="progress progress-striped active">
                                                        <div id="jak_pstrength" class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>

                                                    </div>
                                                    <asp:RegularExpressionValidator ControlToValidate="PasswordT" ID="RegularExpressionValidator1" runat="server" ValidationGroup="AC" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&_])[A-Za-z\d@$!%*#?_]{10,}$"></asp:RegularExpressionValidator>


                                                </div>

                                            </div>
                                            <div class="col-lg-4 col-md-4" id="Div7" runat="server">
                                                <div class="form-group">
                                                  
                                                        <asp:Label ID="ConfirmPasswordL" runat="server" Font-Bold="True"></asp:Label><label id="Label014" runat="server" style="color:red; font-weight:bold">*</label>
                                                    <asp:TextBox CssClass="form-control" ID="ConfirmPassword" runat="server" required TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="Confirmpassvalidator" Font-Bold="true" SetFocusOnError="true" ValidationGroup="AC" runat="server" ControlToValidate="ConfirmPassword"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ForeColor="red" ID="CompareValidator1" Font-Bold="true" SetFocusOnError="true" ValidationGroup="AC" runat="server" ControlToValidate="ConfirmPassword" ControlToCompare="PasswordT"></asp:CompareValidator>

                                                </div>
                                            </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div22" runat="server" style="font-weight: bold">
                                                    <div class="form-group">
                                                    
                                                            <asp:Label ID="AdminDetailsLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label3" runat="server" style="color:red">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="AdminTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AdminTextBoxValidator" runat="server" ControlToValidate="AdminTextBox" ForeColor="Red" ValidationGroup="AC"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div23" runat="server" style="font-weight: bold">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminMobileLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label4" runat="server" style="color:red">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="AdminMobileTextBox" runat="server" required  type="tel" name="phone" ClientIDMode="Static"  TextMode="Phone" ValidationGroup="AC"></asp:TextBox>
                                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="AdminMobileTextBox" ValidationExpression="^[+](9627)[7-9]{1}[0-9]{7}$"></asp:RegularExpressionValidator>
                                                             <asp:RequiredFieldValidator ID="AdminMobileTextBoxValidator" runat="server" ControlToValidate="AdminMobileTextBox" ValidationGroup="AC"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator  ID="CustomValidator1" runat="server" ClientValidationFunction="phonenumber" ControlToValidate="AdminMobileTextBox" ValidationGroup="AC" Font-Size="Small" Font-Bold="true" ForeColor="red"></asp:CustomValidator>
                                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                                    <div class="form-group" style="font-weight: bold">
                                                         <asp:Label ID="AdminEmailLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label6" runat="server" style="color:red">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="AdminEmailTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="AdminEmailExpressionValidator" runat="server" ControlToValidate="AdminEmailTextBox" ValidationGroup="AC" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="AdminEmailTextBoxValidator" runat="server" ControlToValidate="AdminEmailTextBox" ValidationGroup="AC"></asp:RequiredFieldValidator>
                                                                                </div>

                                                </div>
                                            </div>
                               
                                    <div  class="g-recaptcha"  id="grrecaptcha" data-callback="onSuccess" data-action="action" data-sitekey="6Ldxr4sbAAAAABxr6vJVz3f_IHqeipXrOWgDbQiu"></div>
             
                                        <asp:LinkButton ID="CreateAccountbtn" runat="server" CssClass="btn btn-success" OnClick="NextStep1_Click" ValidationGroup="AC"></asp:LinkButton>
                                         <asp:Label ID="Label1" runat="server" ></asp:Label> 
                                          </asp:Panel>
                                                               </div>




                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            <br /><br />
          <div style="text-align:center">
              <br /> <asp:Label ID="Alert" runat="server" CssClass="alert alert-success" Font-Bold="true" Visible="false"></asp:Label><asp:LinkButton ID="LinkButton1" CssClass="alert alert-success" OnClick="LinkButton1_Click" runat="server" Visible="false"></asp:LinkButton>
          </div>
             
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="CreateAccountbtn" />
             <asp:PostBackTrigger ControlID="username" />
            <asp:PostBackTrigger ControlID="PasswordT" />
        </Triggers>
    </asp:UpdatePanel>
          <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=loadGrecaptcha&render=explicit"
        async defer>
    </script>
    <script src='/recaptcha/api.js' async defer nonce="p2hsmNkx8Q7+COM4SV8wKg"></script>
    <script src="js/jquery2.js" async defer></script>

    <script>


        //    errorMsg = document.querySelector("#error-msg"),
        validMsg = document.querySelector("#valid-msg");
        var input = document.getElementById("<%=AdminMobileTextBox.ClientID%>");


        // here, the index maps to the error code returned from getValidationError - see readme
        var sessionValue = '<%= Session("lang") %>';
        if (sessionValue == "en") {
            var errorMap = ["Invalid number", "Invalid country code", "The entered number is shorter than allowed", "The number entered is longer than the tags", "Invalid number"];
        } else {
            var errorMap = ["رقم غير صحيح", "الرمز الدولي غير صحيح", "الرقم الذي تم إدخاله أقصر من المسموح به ", "الرقم الذي تم إدخاله أكبر  من المسموح به", "رقم غير صحيح"];
        }



        // initialise plugin
        var iti = window.intlTelInput(input, {
            utilsScript: "/build/js2/utils.js?1638200991544",

            nationalMode: false
        });

        var reset = function () {
            input.classList.remove("error");
            input2.classList.remove("error");
            //   errorMsg.innerHTML = "";
            // $("#error-msg").popover("hide");

            $("#valid-msg").popover("hide");
        };
        debugger;
        function phonenumber(sender, args) {
            //reset();
            debugger;
            if (input.value.trim()) {
                if (iti.isValidNumber()) {
                    debugger
                    //$("#valid-msg").innerHTML = iti__selected - flag
                    //$("#valid-msg").popover("show");
                    args.IsValid = true;
                } else {
                    input.classList.add("error");
                    var errorCode = iti.getValidationError();

                    sender.innerHTML = errorMap[errorCode];
                    //$("#error-msg").attr("title", errorMap[errorCode]);
                    //$("#error-msg").popover({placement: 'right', content:  errorMap[errorCode] });
                    //console.log($("#error-msg").attr("title"));
                    args.IsValid = false;
                }
            }
        }

        // on blur: validate
        input.addEventListener('blur', phonenumber);
        // on keyup / change flag: reset
        input.addEventListener('change', reset);
        input.addEventListener('keyup', reset);

    </script>
    <script src="/Assets/toastr.min.js" async defer></script>
    <script src="/Assets/script.js" async defer></script>
    <link href="/Assets/toastr.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="style.css">
            <script src="js/jquery3.min.js" async defer></script>
        <script src="/Scripts/toastr.js" async defer></script>
           <script src="Users/js/respond.min.js" async defer></script>
    <script src="Users/js/jaktutorial.js" async defer></script>
    <script src="Users/js/html5shiv.js" async defer></script>
    <script src="Users/js/bootstrap.js" async defer></script>
    <script src="Users/js/jquery.js" async defer></script>
    <link href="Users/CSS/bootstrap1.css" rel="stylesheet" media="all"/>
    <link href="Users/CSS/bootstrap-theme.css" rel="stylesheet" media="all"/>
    <link href="Users/CSS/signin.css" rel="stylesheet" media="all"/>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#PasswordT").keyup(function () {
                passwordStrength(jQuery(this).val());
            });
        });
    </script>
</asp:Content>
