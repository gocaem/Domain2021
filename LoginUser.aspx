<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="LoginUser.aspx.vb" Inherits="Domain2021.LoginUser" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <style>
@media only screen and (max-width:400px) {
.g-recaptcha {
transform:scale(0.77);
transform-origin:0 0;
}
}
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
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
        //////**************** For Local ***************/////////
        ////function loadGrecaptcha() {
        ////    captchaContainer = grecaptcha.render('grrecaptcha', {
        ////        sitekey: '6Le-N44bAAAAAHw_-_lLq1xDagxMqlp_-wpipDtd',
        ////        callback: function (response) {
        ////            console.log(response)
        ////            setTimeout(function () {
        ////                grecaptcha.reset(captchaContainer);

        ////            }, 120000);
        ////        }
        ////    });
        //};
    
     
    </script>

    <section id="post_job" >
        
<div class="vertical-space-101">
   
</div>
<div class="container" style="width:50%;">
  

<div class="vertical-space-60"></div>
<div class="job-post-box" id="login" runat="server">
    <div class="row"><label class="modal-header badge-info"  id="head" runat="server"  style="width:100%;font-weight:bold">Login Area</label></div>

<div class="row">
  
    <center><asp:Label ID="lbl_error" CssClass=" alert-danger" runat="server" ></asp:Label></center>
<div class="col-lg-9 col-md-9" id="fg1" runat="server">
<div class="form-group" id="fg" runat="server">
<label for="InputUsername" id="Inputfor" runat="server" ><asp:Label ID="usernameL" Font-Bold="True" runat="server" ></asp:Label></label>
<asp:TextBox type="text"  cssclass="form-control" id="InputUsername" runat="server" placeholder="Usename" required   ValidationGroup="a" ></asp:TextBox>
<asp:RequiredFieldValidator ForeColor="red" ID="RequiredFieldValidator1" ControlToValidate="InputUsername" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
</div></div>
</div>
<div class="row">
<div class="col-lg-9 col-md-9">
<div class="form-group">
<label for="InputPassword"  id="Loctio" runat="server"><asp:Label ID="Password" runat="server" Font-Bold="True"></asp:Label></label>
<asp:TextBox  autocomplete="off" TextMode="Password" AutoCompleteType="Disabled" cssclass="form-control" id="InputPassword"  runat="server" placeholder="Password" required  ValidationGroup="a" ></asp:TextBox>
<asp:RequiredFieldValidator ForeColor="red" ID="RequiredFieldValidator2"  ControlToValidate="InputPassword" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

</div>
</div>
</div>
<div class="row">

<div class="form-group ">


 <div  class="g-recaptcha"   id="grrecaptcha" data-callback="onSuccess" data-action="action" data-sitekey="6Ldxr4sbAAAAABxr6vJVz3f_IHqeipXrOWgDbQiu" >


</div></div>
</div>
<div class="row">
    <asp:button ID="loginbutton" runat="server" type="submit" class="btn btn-info" ValidationGroup="a" ></asp:button>

</div>
<br /><div class="row"><br /><asp:LinkButton ID="ForgetLinkButton" runat="server" OnClick="ForgetLinkButton_Click" ValidationGroup="NA"  CausesValidation="false"></asp:LinkButton>

      </div>
    </div><br />
<div class="job-post-box" id="Div1" runat="server">
    <div class="row"><label class="modal-header badge-info"  id="Label1" runat="server"  style="width:100%;font-weight:bold">Login Area</label></div>

<div class="row">
  
    <center><asp:Label ID="Label2" CssClass=" alert-danger" runat="server" ></asp:Label></center>
<div class="col-lg-9 col-md-9" id="Div2" runat="server">
<div class="form-group" id="Div3" runat="server">
<label for="InputUsername" id="Label3" runat="server" ><asp:Label ID="OTPCodeLB" Font-Bold="True" runat="server" ></asp:Label></label>
<asp:TextBox type="text" TextMode="Number" MaxLength="6"  cssclass="form-control" id="OTPTextBox" runat="server" placeholder="OTP Code" required    ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="OTPTextBox" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
     <center><asp:Label ID="MobileLabel"  runat="server"  ForeColor="#999999"></asp:Label></center>
       <center><asp:Label ID="OTPLabel"  runat="server"  ForeColor="#999999"></asp:Label></center>
         <center><asp:Label ID="errorOtp"  runat="server"  ForeColor="Red"></asp:Label></center>

</div></div>
</div>

<div class="row">
    <asp:button ID="Button1" runat="server" type="submit" class="btn btn-info" OnClick="Button1_Click" ></asp:button>
       <span id="time" runat="server" visible="false"></span>
</div></div><br /> 

         <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=loadGrecaptcha&render=explicit"
        async defer>
    </script>
    <script src='/recaptcha/api.js' async defer nonce="p2hsmNkx8Q7+COM4SV8wKg"></script>
     <script src="js/jquery2.js"></script>
     <script src="Assets/toastr.min.js" async defer></script>
     <script src="Assets/script.js" async defer></script>
     <link href="Assets/toastr.min.css" rel="stylesheet" />
</div>

</section>
</asp:Content>
