<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageAr.Master" CodeBehind="reset_pwd.aspx.vb" Inherits="Domain2021.reset_pwd" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="style.css" media="all">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>

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
        
<div class="vertical-space-30">
   
</div>
<div class="container" style="width:50%;">
    <asp:Label ID="Label4"  ForeColor="red" runat="server" ></asp:Label>

<div class="vertical-space-60"></div>
<div class="job-post-box" id="login" runat="server">
    <div class="container table-bordered"><br />
   <div class="card-header rounded" style="font-size:large" id="head" runat="server">

  </div>

      
<div class="row">
  <asp:Label ID="Label3"  ForeColor="red" runat="server" ></asp:Label>
    <center><asp:Label ID="lbl_error"  ForeColor="red" runat="server" ></asp:Label></center>
<div class="col-lg-9 col-md-9" id="fg1" runat="server">
<div class="form-group" id="fg" runat="server"><br />
<label for="InputUsername" id="Inputfor" runat="server" ><asp:Label ID="usernameL" Font-Bold="True" runat="server" ></asp:Label></label>
<asp:Label type="label" ForeColor="red" Font-Bold="true"  id="EmailL" runat="server"  required  ></asp:Label>
</div></div>
</div>

<div class="row"><div class="col-lg-8 col-md-8" id="Div1" runat="server">
<label for="InputPassword" id="Loctio" runat="server"><asp:Label ID="PasswordL" runat="server" Font-Bold="True"></asp:Label></label>
<asp:TextBox AutoCompleteType="None"  runat="server" type="password" ClientIDMode="Static" id="password" TextMode="Password" CssClass="form-control first" placeholder="Password" autofocus></asp:TextBox>
    
    <div class="progress progress-striped active">
<div id="jak_pstrength" class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>

</div>  
          
    	 		
    </div><div class="col-lg-4 col-md-4">  </div> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="password"></asp:RequiredFieldValidator></div>
  <asp:RegularExpressionValidator ControlToValidate="password"  ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&_])[A-Za-z\d@$!%*#?&_]{10,}$" ></asp:RegularExpressionValidator>
      
<div class="row"><div class="col-lg-8 col-md-8" id="Div2" runat="server">
<div class="form-group">
<label for="InputPassword" id="Label1" runat="server"><asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label></label>
<asp:TextBox  type="password" cssclass="form-control" id="TextBox1" runat="server" TextMode="Password" placeholder="Password"  ></asp:TextBox></div>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="TextBox1" ></asp:RequiredFieldValidator>  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="password" ControlToCompare="TextBox1"  ForeColor="Red"></asp:CompareValidator>
</div>

  </div>

<div class="row">

<div class="form-group ">


 <div  class="g-recaptcha"  id="grrecaptcha" data-callback="onSuccess" data-action="action" data-sitekey="6Ldxr4sbAAAAABxr6vJVz3f_IHqeipXrOWgDbQiu" >


</div></div>
</div>
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="row"><div class="col-lg-8 col-md-8" id="Div3" runat="server">
    <asp:Button ID="Button1" runat="server"   type="submit" cssclass="btn btn-info" OnClick="Button1_Click"  />
    </div></div><br /></div>
              <div class="modal fade" id="danger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-edit"></i>Edit Domain Name</h3>
                        </div>
                        <div class="modal-body">
                        <asp:Label ID="lblupdate" Text="Are you sure you want to update?" runat="server"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:Button ID="Button4"  type="button" runat="server" CssClass="btn btn-success pull-left" Text="Yes"  ></asp:Button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
         <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=loadGrecaptcha&render=explicit"
        async defer>
    </script>
     <script src='/recaptcha/api.js' async defer nonce="p2hsmNkx8Q7+COM4SV8wKg" ></script>
 

</div></div>
        
            <script src="js/respond.min.js" async defer></script>
    <script src="js/jaktutorial.js" async defer></script>
    <script src="js/html5shiv.js" async defer></script>
    <script src="js/bootstrap.js" async defer></script>
    <script src="js/jquery.js" async defer></script>
    <link href="CSS/bootstrap-theme.css" rel="stylesheet" media="all"/>
    <link href="CSS/bootstrap.css" rel="stylesheet" media="all"/>
    <link href="CSS/signin.css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="style.css">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#password").keyup(function () {
                passwordStrength(jQuery(this).val());
            });
        });
    </script>
             <script type="text/javascript">
                 debugger
                 function openModal() {
                     $('#danger').modal('show');

                 }
                 function openModal2() {
                     $('#danger2').modal('show');

                 }
    </script> 
     <script src="Users/js/respond.min.js" async defer></script>
    <script src="Users/js/jaktutorial.js" async defer></script>
    <script src="Users/js/html5shiv.js" async defer></script>
    <script src="Users/js/bootstrap.js" async defer></script>
    <script src="Users/js/jquery.js" async defer></script>
    <link href="Users/CSS/bootstrap-theme.css" rel="stylesheet" media="all"/>
    <link href="Users/CSS/bootstrap.css" rel="stylesheet" media="all"/>
    <link href="Users/CSS/signin.css" rel="stylesheet" media="all"/>
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
</section>

</asp:Content>
