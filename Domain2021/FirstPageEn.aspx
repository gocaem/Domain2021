<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FirstPageEn.aspx.vb" Inherits="Domain2021.FirstPageEn" ViewStateEncryptionMode="Always" %>
<!doctype html>
<html lang="en">


<head>

<meta charset="utf-8">
<meta name="author" content="John Doe">
<meta name="description" content="">
<meta name="keywords" content="HTML,CSS,XML,JavaScript">
<meta http-equiv="x-ua-compatible" content="ie=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>Domain Name Registration</title>
    <link rel="preconnect" href="https://fonts.gstatic.com">

 <link href="css\css2.css" rel="stylesheet" media="all">

<link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />

 <link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />
<link rel="stylesheet" href="css/bootstrap.min.css"  media="all" crossorigin="anonymous">
<link href="font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" media="all">
<link href="css/matrialize.css" rel="stylesheet" media="all">
<link href="owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" media="all">
<link rel="stylesheet" href="css/style.css" media="all">
<script id="menatracks-widget"
            baseurl="https://cmu.gov.jo/application_widget"
            widgetform="https://cmu.gov.jo/application_widget/Widget/WidgetSurveyViewer.aspx?Value=fEDloY/4mjBeEwKHoyJ9yTWNvfFGy/NTWZDEkOVDS7Y="
            src="https://cmu.gov.jo/application_widget/JS/WidgetJs/widget.js"></script>
<style type="text/css">
    .rgview table
    {
        border-collapse: collapse;
        background: #ebf1de;
    }
    .rgview th, .rgview td
    {   
        padding: 4px 8px;
    }
    .rgview th
    {            
        background-color: #8064a2;
        color: #fff;
        border: 1px solid #ccc;
    }
    .rgview th a
    {
        color: #fff;
        text-decoration: none;
    }
    .rgview tr:hover
    {   
        background: #d8e4bc;
    }
    .rgview td
    {
        border: 1px solid #ccc;            
    }
</style>
       

</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager runat="server"></asp:ScriptManager>
  
       <header class="header">

<div class="top_bar background-color-orange">
<div class="top_bar_container">
<div class="container">
<div class="row">
<div class="col">
<div class="top_bar_content d-flex flex-row align-items-center justify-content-start">
<ul class="top_bar_contact_list">
<li>
<i class="fa fa-phone coll" aria-hidden="true"></i>
<div class="contact-no" id="PhoneNo" runat="server">00962 6 5300225</div>
</li>
<li>
<i class="fa fa-envelope coll" aria-hidden="true"></i>
<div class="email">
<a href="mailto:dns@modee.gov.jo" style="color:white" id="email" runat="server">dns@modee.gov.jo</a></div>
</li>
</ul>
<div class=" ml-auto ">
<div></div>
<div class="hamburger menu_mm  search_button transparent search display"><i class="large material-icons font-color-white  search-icone  menu_mm ">menu</i></div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>

<div class="header_container background-color-orange-light">
<div class="container">
<div class="row">
<div class="col">
<div class="header_content d-flex flex-row align-items-center justify-content-start">
<div class="logo_container">
<a href="firstpageen.aspx">
<img src="imags/logo-en.png" class="logo-text" alt="">
</a>
</div>
<nav class="main_nav_contaner ml-auto" style="font-family:Calibri">
<ul class="main_nav">
 <li>
<a  href="FirstPage.aspx" style="font-family:Calibri; font-size:small"><span class="caret"></span>Home
</a>
 </li>   
<li><a href="AboutUs.aspx" style="font-family:Calibri;font-size:small">About Us</a></li>
<li><a href="Efawateercom.aspx" style="font-family:Calibri;font-size:small">eFAWATEERcom</a></li>
<li><a href="Policy.aspx" style="font-family:Calibri;font-size:small">Our Policy</a></li>
<li><a href="ContactUs.aspx" style="font-family:Calibri;font-size:small">Contact Us</a></li>
<li><a href="FirstPage.aspx" style="font-family:cairo;">عربي</a></li>
<li>
<a  href="LoginUser.aspx" style="font-family:Calibri;font-size:small">My Account
</a>
</li>
</ul>
<div class="Post-Jobs" >
<a href="registerdomain.aspx" class="" style="font-family:Calibri ;font-size:medium; font-weight:normal">
Register Domain</a>
</div>
<div class="hamburger menu_mm menu-vertical">
<i class="large material-icons font-color-white menu_mm menu-vertical">menu</i>
</div>
</nav>

</div>
</div>
</div>
</div>
</div>
<div class="menu d-flex flex-column align-items-end justify-content-start text-left menu_mm trans_400">
<div class="menu_close_container">
<div class="menu_close">
<div></div>
<div></div>
</div>
</div>
<nav class="menu_nav">
<ul class="menu_mm">
<li  class="menu_mm" style="font-family:Calibri">
<a  href="https://modee.gov.jo/Default/En" target="_blank"  style="font-family:Calibri">Home
<span class="caret"></span></a>
</li>
<li class="menu_mm"  style="font-family:Calibri">
<a   href="AboutUs.aspx" style="font-family:Calibri">About Us
</a>
</li>
<li class="menu_mm"><a href="Policy.aspx" style="font-family:Calibri">Our Policy</a></li>
<li class="menu_mm"><a href="FAQ.aspx" style="font-family:Calibri">FAQ</a></li>
<li class="menu_mm"><a href="EfawateerCom.aspx" style="font-family:Calibri">eFAWATEERcom</a></li>
<li class="menu_mm"><a href="ContactUs.aspx" style="font-family:Calibri">Contact Us</a></li>
<li class="menu_mm" style="font-family:cairo"><a href="FirstPage.aspx" style="font-family:cairo">عربي</a></li>
<li class="menu_mm"><a href="LoginUser.aspx" style="font-family:Calibri">My account</a></li>
</ul>
</nav>
</div>
</header>
<section id="intro">
<div class="carousel-item active">
<div class="carousel-background"><img src="imags/slider/slider1.jpeg" alt=""></div>
<div class="carousel-container">
<div class="carousel-content">
 <h2 class="font-color-white" style="font-family:Calibri" id="h2" runat="server">Domain Name Registration</h2>
<p class="font-color-white" style="font-family:Calibri" dir="ltr" id="p2" runat="server">The Official Registrant portal for registering domains under (.jo/.Jordan)</p>

</div>
</div>
</div>
</section>
        


<div id="search-box" style="width:100%">
<div class="container search-box" style="width:50%">
         
                    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="ResultsUpdatePanel" runat="server">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; left: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="Spinner.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server" UpdateMode="Always">
                        <ContentTemplate>
<form action="#" id="search-box_search_form_3" class="search-box_search_form d-flex flex-lg-row flex-column align-items-center justify-content-between ">
<div class="d-flex flex-row align-items-center justify-content-start inline-block"  style="width:100%">
<span class="large material-icons search">search</span>
<asp:TextBox ID="TextBox1" runat="server"  CssClass="search-box_search_input" placeholder="Domain Name" required="required" type="search" style="font-family:Calibri;color:black"></asp:TextBox>
<asp:DropDownList CssClass="dropdown_item_select search-box_search_input" ID="ddl" runat="server" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID" DataSourceID="SqlDataSource1">
</asp:DropDownList> <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator1" style="text-align:left;font-family:Calibri" Font-Size="Small" Font-Bold="true"   runat="server" ErrorMessage="Required Field" ForeColor="red" ValidationGroup="A"></asp:RequiredFieldValidator>     
   
    <asp:Button Text="WhoIs" ID="b1" runat="server" Font-Names="Calibri"   CssClass="fa fa-search font-color-white search-box_search_button" ValidationGroup="A"></asp:Button>

</div>  <div class="d-flex flex-row align-items-center justify-content-start inline-block center"  style="width:100%;text-align:center">
   <br />   <asp:GridView ID="WhoIs" Font-Names="Calibri" AutoGenerateColumns="false" runat="server" CssClass="table table-responsive" Width="100%">
        <Columns>
            <asp:BoundField DataField="Domain_id"  />
            <asp:TemplateField HeaderText="Domain Name" ItemStyle-Width="490px">
                <ItemTemplate>
                    <asp:LinkButton id="link" runat="server" CommandName="det" Text='<%# Eval("DomainName") %>' CommandArgument='<%# Eval("Domain_ID") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="ORG_NAME" HeaderText="Organization Name" ItemStyle-Width="390px"/>
        

        </Columns>
    </asp:GridView>
    <asp:Label ID="Result" Font-Bold="true" Font-Names="Calibri" Font-Size="Medium" runat="server" Width="100%" ForeColor="Green" ></asp:Label>
</div>  
</div> 

</div>
</div><section id="Job-Category" style="text-align:center"><div class="auto-style1">

</div></section>
</form>  </ContentTemplate>
                    
                    </asp:UpdatePanel>
    <br /><br />
<section id="Job-Category">
<div class="auto-style1">
<h4 class="text-center" style="font-family:Calibri">Domain Name registration website</h4>
<div class="vertical-space-30"></div>
<p class="max-width" dir="ltr" style="font-family:Calibri;text-align:left;font-weight:bold; width: 868px;">
<span lang="en-us" style="font-family:Calibri;text-align:left;font-weight:normal" class="text-center" dir="ltr">
 A <a href='https://www.dns.jo/FirstPageen.aspx'>dns.jo</a> domain name registration platform is a service that offered by <a href='https://modee.gov.jo/Default/En' target="_blank" > Ministry Digital Economy And Entrepreneurship (MoDEE)</a> which is the exclusive registrar for domains under(.JO/.الاردن), allows individuals and organizations to register domain names under (.JO/.الاردن) for their websites.<br />Facilitating the reservation of domain names and ensuring they are unique and available for use on the internet. <br />Offering additional services like domain privacy protection, DNS management, and domain transfer options. it include a user-friendly interface, making it easy for users to search for available domain names, complete the registration process, and manage their domains. 
<div class="row">
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-1.png" alt="">
</div>
<h6 style="font-family:Calibri">Premium Domain Fees (less than 3 characters)</h6>
<a href="Premuim.aspx" class="button job_post" data-hover="More" data-active="I'M ACTIVE" style="font-family:Calibri"><span>Details</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-2.png" alt="">
</div>
<h6 style="font-family:Calibri">Domain's Statistics</h6>
<a href="DomStat.aspx" class="button job_post" data-hover="More" data-active="I'M ACTIVE" style="font-family:Calibri"><span>Details</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-3.png" alt="">
</div>
<h6 style="font-family:Calibri">Fees and Payment</h6>
<a href="fees.aspx" class="button job_post" data-hover="More" data-active="I'M ACTIVE" style="font-family:Calibri"><span>Details</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50" style="left: 0px; top: 0px">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-4.png" alt="">
</div>
<h6 style="font-family:Calibri">(.JO) Family</h6>
<a href="JoFamily.aspx" class="button job_post" data-hover="More" data-active="I'M ACTIVE" style="font-family:Calibri"><span>Details</span></a>

</div>
</div>
	<br><br><br><br>
</section>


<footer id="footer" class="background-color-white" style="background-image:url('imags/download.jpg');background-size:100%">
<div class="container">
<div class="row">
<div class="col-lg-4 col-md-6 vertical-space-2">
<h5>&nbsp;</h5>
	<h5>&nbsp;</h5>
	<h5 style="font-family:Calibri; text-align:center" id="AboutUs" runat="server">About Us</h5>
<p class="paregraf" dir="ltr" style="font-family:Calibri;text-align:left; color:black;font-weight:normal" id="paragraphfooter" runat="server"> MoDEE  is the registry and registrar for domain names under .jo – both at the first level and second level. MoDEE was granted the registration privilege after a thorough registration and delegation process with ICANN; the Internet Names and Numbers policy development body. </p>

</div>
<div class="col-lg-2 col-md-6 vertical-space-2">
</div>

<div class="col-lg-2 col-md-6 vertical-space-2">
<h5>&nbsp;</h5>
<h5>&nbsp;</h5>
<h5 style="font-family:Calibri;text-align:left" dir="ltr" id="support" runat="server">Support</h5>
<div class="text"  style="font-family:Calibri;text-align:left; float: left;color:black;font-weight:bold" dir="ltr">
<p style="font-family:Calibri;text-align:left" id="divphone" runat="server">065300225</p>
<p style="font-family:Calibri;text-align:left"><a href="mailto:dns@modee.gov.jo" style="font-family:Calibri;text-align:left; float: left;color:black;font-weight:bold" dir="ltr">dns@modee.gov.jo</a></p>
</div>
</div>
<div class="col-lg-2 col-md-6 vertical-space-2">
</div>

<div class="col-lg-2 col-md-6 vertical-space-2">
<h5>&nbsp;</h5>
<h5>&nbsp;</h5>
<h5 style="font-family:Calibri;text-align:left" dir="ltr">eFAWATEERcom</h5>
    <div class="text"  style="font-family:Calibri;text-align:left; float: left;" dir="ltr">
<p style="font-family:Calibri;text-align:left"><a href="faq.aspx" style="font-family:Calibri;text-align:left;color:black;font-weight:normal" dir="ltr">FAQ</a></p>
<p style="font-family:Calibri;text-align:left"><a href="https://www.efawateercom.jo/Portal/Home" target="_blank" style="font-family:Calibri;text-align:left;color:black;font-weight:normal" dir="ltr">eFAWATEERcom portal</a></p>
<p style="font-family:Calibri;text-align:left"><a href="https://www.sanad.gov.jo/default/en" target="_blank" style="font-family:Calibri;text-align:left;color:black;font-weight:normal" dir="ltr">SANAD</a></p> 
</div>


</div>

</div>

</div>




<div class="vertical-space-60"></div>
</div></div>
<div class="container-fluid background-color-orange main-footer">
<div class="container text-center">
<div class="vertical-space-30"></div>
<p><a target="_blank" href="https://www.modee.gov.jo/" style="color:silver; font-family:Calibri"> All Rights are Reserved © Ministry of Digital Economy and Entrepreneurship   </a></p>
</div>
</div></footer>



		                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                        SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
    <script data-cfasync="false" src="js/email-decode.min.js" async defer></script><script src="js\jquery-3.6.0.min.js" async defer></script>
 <script src="js/bootstrap2.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous" async defer></script>

<script src="owlcarousel/owl.carousel.min.js" async defer></script>
<script src="js/jquery-ui.min.js" async defer></script>
    <link href="css\css.css" rel="stylesheet"> 
    <script src="js/custom.js" async defer></script>
<script>
    $(".search-icone").click(function () {
        // $(".menu").animate({height: "100vh"});
    });

</script>
    <script type="text/javascript">

        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return true;
        }
    </script>
    <script src="js/4n2NXumNjtg5LPp6VXLlDicTUfA.js" async defer></script>
</body>
</html>
