<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="ForgetPass.aspx.vb" Inherits="Domain2021.ForgetPass" ViewStateEncryptionMode="Always" %>
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
  

    <section id="post_job" >
        
<div class="vertical-space-101">
   
</div>
<div class="container" style="width:50%;">
  

<div class="vertical-space-60"></div>
<div class="job-post-box" id="login" runat="server">
    <div class="row"><label class="modal-header badge-info"  id="head" runat="server"  style="width:100%;font-weight:bold">Login Area</label></div>
<center><asp:Label ID="lbl_error" CssClass=" alert-danger" runat="server" Width="100%" ></asp:Label></center><br />

<br />
<div class="row">
<div class="col-lg-9 col-md-9">
<div class="form-group">
<label for="InputPassword"  id="Loctio" runat="server"><asp:Label ID="EmailLabelL" runat="server" Font-Bold="True"></asp:Label></label>
<asp:TextBox  type="text" cssclass="form-control" id="txt_email_id" runat="server"   ></asp:TextBox>
     <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" Font-Bold="true"  ControlToValidate="txt_email_id" runat="server" ErrorMessage="RequiredFieldValidator"  ValidationGroup="AC"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ForeColor="Red" ID="regexEmailValid" runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txt_email_id" Font-Bold="true"   ValidationGroup="AC"></asp:RegularExpressionValidator>
</div><br />
    <div class="form-group">
<label for="InputPassword"  id="Label1" runat="server"><asp:Label ID="RequesterL" runat="server" Font-Bold="True"></asp:Label></label>
<asp:TextBox  type="text"  cssclass="form-control" id="txt_requester_Name" runat="server"   ></asp:TextBox>
     <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" Font-Bold="true"  ControlToValidate="txt_requester_Name" runat="server" ErrorMessage="RequiredFieldValidator"  ValidationGroup="AC"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ForeColor="Red" ID="regexpReuesterName" Font-Bold="true" runat="server" 
                                    ControlToValidate="txt_requester_Name"     
                                    ValidationExpression="^[ء-يa-zA-Z.'\s]{1,50}$" 
                    ValidationGroup="A" />
</div>

</div>
</div><br />
<div class="row">

<div class="form-group ">


 <div  class="g-recaptcha"  id="grrecaptcha" data-callback="onSuccess" data-action="action" data-sitekey="6Ldxr4sbAAAAABxr6vJVz3f_IHqeipXrOWgDbQiu" >


</div></div>
</div><div class="row">
    <asp:button ID="loginbutton"  runat="server" type="submit" class="btn btn-info" Font-Bold="true"  OnClick="loginbutton_Click"  ValidationGroup="AC"></asp:button>
</div>


         <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=loadGrecaptcha&render=explicit"
        async defer>
    </script>
    <script src='/recaptcha/api.js' async defer nonce="p2hsmNkx8Q7+COM4SV8wKg"></script>
     <script src="js\jquery.js" async defer></script>
     <script src="Assets/toastr.min.js" async defer></script>
     <script src="Assets/script.js" async defer></script>
     <link href="Assets/toastr.min.css" rel="stylesheet" />
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
>
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
        ////////////**************** For Local ***************/////////
        //function loadGrecaptcha() {
        //    captchaContainer = grecaptcha.render('grrecaptcha', {
        //        sitekey: '6Le-N44bAAAAAHw_-_lLq1xDagxMqlp_-wpipDtd',
        //        callback: function (response) {
        //            console.log(response)
        //            setTimeout(function () {
        //                grecaptcha.reset(captchaContainer);

        //            }, 120000);
        //        }
        //    });
        //};


     </script>
    
  
      <script src="/Assets/toastr.min.js" async defer></script>
    <script src="/Assets/script.js" async defer></script>
    <link href="/Assets/toastr.min.css" rel="stylesheet" />
</div>
    </div>
</section>
</asp:Content>
