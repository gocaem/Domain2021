<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FirstPage.aspx.vb" Inherits="Domain2021.FirstPage" ViewStateEncryptionMode="Always" %>
<!doctype html>
<html lang="ar">


<head>

<meta charset="utf-8">
<meta name="author" content="Reef Amarin">
<meta name="description" content="">
<meta name="keywords" content="HTML,CSS,XML,JavaScript">
<meta http-equiv="x-ua-compatible" content="ie=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>موقع تسجيل النطاقات</title>
 <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="/css/css4.css" rel="stylesheet" media="all">
<link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />
<link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />
 <link rel="stylesheet" href="css/bootstrap.min.css"  crossorigin="anonymous">
<link href="font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" media="all">
<link href="css/matrialize.css" rel="stylesheet" media="all">
<link href="owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" media="all">
<link rel="stylesheet" href="css/style.css" media="all">
<style type="text/css">
    *,
*::before,
*::after {
  box-sizing: border-box;
}
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
    <script id="menatracks-widget"
            baseurl="https://cmu.gov.jo/application_widget"
            widgetform="https://cmu.gov.jo/application_widget/Widget/WidgetSurveyViewer.aspx?Value=fEDloY/4mjBeEwKHoyJ9yTWNvfFGy/NTWZDEkOVDS7Y="
            src="https://cmu.gov.jo/application_widget/JS/WidgetJs/widget.js"></script>
       <script type="text/javascript">
   
           function PostToNewWindow() {
               originalTarget = document.forms[0].target;
               document.forms[0].target = '_blank';
               window.setTimeout("document.forms[0].target=originalTarget;", 300);
               return true;
           }
       </script>

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
<a href="mailto:dns@modee.gov.jo" style="color:white"  id="Email" runat="server">dns@modee.gov.jo</a></div>
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
<a href="https://modee.gov.jo/" target="_blank">
<img src="imags/logo.png" class="logo-text" alt="">
</a>
</div>
<nav class="main_nav_contaner ml-auto" style="font-family:cairo">

<ul class="main_nav">
    <li>
<a  href="LoginUser.aspx" style="font-family:cairo">حسابي
</a>
</li>
    <li><a href="FirstPageen.aspx" style="font-family:cairo">English</a></li>
<li><a href="ContactUs.aspx" style="font-family:cairo">للاتصال بنا</a></li>

<li><a href="Efawateercom.aspx" style="font-family:cairo">إي فواتيركم</a></li>
<li><a href="Policy.aspx" style="font-family:cairo">سياسة التسجيل</a></li>

<li><a href="AboutUs.aspx" style="font-family:cairo">من نحن</a></li>
<li>
<a  href="FirstPage.aspx" style="font-family:cairo;"><span class="caret"></span>الرئيسية
</a>
 </li>
</ul>
<div class="Post-Jobs">
<a href="RegisterDomain.aspx" class="" style="font-family:cairo;font-size:medium">
تسجيل نطاق 
</a>
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
<div class="menu d-flex flex-column align-items-end justify-content-start text-right menu_mm trans_400">
<div class="menu_close_container">
<div class="menu_close">
<div></div>
<div></div>
</div>
</div>
<nav class="menu_nav">
<ul class="menu_mm">
<li  class="menu_mm" style="font-family:cairo">
<a  href="https//www.modee.gov.jo/" style="font-family:cairo" target="_blank">الرئيسية
<span class="caret"></span></a>
</li>
<li class="menu_mm"  style="font-family:cairo">
<a   href="AboutUs.aspx" style="font-family:cairo">من نحن
</a>
</li>

<li class="menu_mm"><a href="Policy.aspx" style="font-family:cairo">سياسة التسجيل</a></li>
<li class="menu_mm"><a href="FAQ.aspx" style="font-family:cairo">أسئلة متكررة</a></li>
<li class="menu_mm"><a href="EfawateerCom.aspx" style="font-family:cairo">إي فواتيركم</a></li>
<li class="menu_mm"><a href="ContactUs.aspx" style="font-family:cairo">للاتصال بنا</a></li>
<li class="menu_mm"><a href="FirstPageen.aspx" style="font-family:cairo">English</a></li>
<li class="menu_mm"><a href="LoginUser.aspx" style="font-family:cairo">حسابي</a></li>
</ul>
</nav>
</div>
</header>
<section id="intro">
<div class="carousel-item active">
<div class="carousel-background"><img src="imags/slider/slider1.jpg" alt=""></div>
<div class="carousel-container">
<div class="carousel-content">
 <h2 class="font-color-white" style="font-family:cairo" id="h2" runat="server">موقع تسجيل النطاقات الوطنية</h2>
<p class="font-color-white" style="font-family:cairo" dir="rtl" id="p2" runat="server">البوابة الرئيسية الوحيدة لتسجيل ودفع النطاقات تحت (.jo / .الأردن) وتفرعاتها</p>

</div>
</div>
</div>
</section>
        


<div id="search-box" style="width:100%">
<div class="container search-box" style="width:50%">
         
                    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="ResultsUpdatePanel" runat="server">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="Spinner.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server" UpdateMode="Always">
                        <ContentTemplate>
<form action="#" id="search-box_search_form_3" class="search-box_search_form d-flex flex-lg-row flex-column align-items-center justify-content-between ">
<div class="d-flex flex-row align-items-center justify-content-start inline-block"  style="width:100%">
<span class="large material-icons search">search</span>
<asp:TextBox ID="TextBox1" runat="server"  CssClass="search-box_search_input" placeholder="ادخل اسم النطاق" required="required" type="search" style="font-family:cairo;color:black"></asp:TextBox>
<asp:DropDownList CssClass="dropdown_item_select search-box_search_input" ID="ddl" runat="server" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID" DataSourceID="SqlDataSource1">
</asp:DropDownList>

<asp:Button Text="WhoIs" ID="b1" Font-Names="Calibri" runat="server"   CssClass="fa fa-search font-color-white search-box_search_button" ValidationGroup="A" ></asp:Button>
</div>    <div class="d-flex flex-row align-items-center justify-content-start inline-block center"  style="width:100%;text-align:center">
   <br />   <asp:GridView ID="WhoIs" Font-Names="cairo" Font-Bold="true" AutoGenerateColumns="false" runat="server" CssClass="table table-responsive" Width="100%">
        <Columns>
            <asp:BoundField DataField="Domain_id"  />
            <asp:TemplateField HeaderText="اسم النطاق" ItemStyle-Width="490px">
                <ItemTemplate>
                    <asp:LinkButton id="link" runat="server" CommandName="det" Text='<%# Eval("DomainName") %>' CommandArgument='<%# Eval("Domain_ID") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="ORG_NAME" HeaderText="الجهة المستخدمة" ItemStyle-Width="390px"/>
        </Columns>
    </asp:GridView><br />
    <asp:Label ID="Result" Font-Bold="true" Font-Names="cairo" Font-Size="Large" runat="server" Width="100%" ForeColor="Green" ></asp:Label>
</div>    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" style="text-align:right;font-family:cairo" Font-Size="Small" Font-Bold="true"  runat="server" ErrorMessage="حقل ضروري" ForeColor="red" ValidationGroup="A"></asp:RequiredFieldValidator>     


</div>
</div><section id="Job-Category" style="text-align:center"><div class="auto-style1">

   </div></section>
    
</form>  </ContentTemplate>
                  
                    </asp:UpdatePanel>
    <br /><br /><br />
<section id="Job-Category">
<div class="auto-style1">
<h3 class="text-center" style="font-family:cairo">موقع تسجيل النطاقات</h3>
<div class="vertical-space-30"></div>
<p class="max-width" dir="rtl" style="font-family:cairo;text-align:right;font-weight:bold; width: 868px;">
    منصة تسجيل أسماء النطاقات <a  href='https://dns.jo/firstpage.aspx' target="_blank">dns.jo</a> هي خدمة تقدمها <a href="https://www.modee.gov.jo/" target="_blank">وزارة الاقتصاد الرقمي والريادة (MoDEE)،</a> وهي المسجل الحصري للنطاقات تحت (.JO/.الاردن). </br>تتيح هذه المنصة للأفراد والمؤسسات تسجيل أسماء النطاقات تحت (.JO/.الاردن) لمواقعهم على الإنترنت. تسهل عملية حجز أسماء النطاقات وتضمن أنها فريدة ومتاحة للاستخدام على الإنترنت. <br />تقدم المنصة خدمات إضافية مثل حماية خصوصية النطاق، إدارة نظام أسماء النطاقات (DNS)، وخيارات نقل النطاقات. </br>تشمل واجهة سهلة الاستخدام، مما يجعل من السهل على المستخدمين البحث عن أسماء النطاقات المتاحة، وإتمام عملية التسجيل، وإدارة نطاقاتهم.
</p>
	<p class="max-width" dir="rtl" style="font-family:cairo;text-align:right;font-weight:bold; width: 868px;">
	&nbsp;</p>
<div class="row">
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-1.png" alt="">
</div>
<h6 style="font-family:cairo">رسوم النطاقات المميزة (أقل من 3 أحرف)</h6>
<a href="Premuim.aspx" class="button job_post" data-hover="المزيد" data-active="I'M ACTIVE" style="font-family:cairo"><span>قراءة التفاصيل</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-2.png" alt="">
</div>
<h6 style="font-family:cairo">احصائيات النطاقات</h6>
<a href="DomStat.aspx" class="button job_post" data-hover="المزيد" data-active="I'M ACTIVE" style="font-family:cairo"><span>قراءة التفاصيل</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-3.png" alt="">
</div>
<h6 style="font-family:cairo">بدلات الرسوم وطريقة الدفع</h6>
<a href="fees.aspx" class="button job_post" data-hover="المزيد" data-active="I'M ACTIVE" style="font-family:cairo"><span>قراءة التفاصيل</span></a>
</div>
</div>
<div class="col-lg-3 col-md-6 max-width-50" style="left: 0px; top: 0px">
<div class="box background-color-white-light">
<div class="circle">
<img src="imags/icone/service-icone-4.png" alt="">
</div>
<h6 style="font-family:cairo">المستويات المتوفرة للتسجيل</h6>
<a href="JoFamily.aspx" class="button job_post" data-hover="المزيد" data-active="I'M ACTIVE" style="font-family:cairo"><span>قراءة التفاصيل</span></a>

</div>
</div>
	<br><br><br><br></div>
</section>


<footer id="footer" class="background-color-white" style="background-image:url('imags/download.jpg');background-size:100%">
<div class="container">
<div class="row">
<div class="col-lg-4 col-md-4 vertical-space-2">
<h5>&nbsp;</h5>
	<h5>&nbsp;</h5>
	<h5 style="font-family:cairo; text-align:center" id="aboutus" runat="server">من نحن</h5>
<p class="paregraf" dir="rtl" style="font-family:cairo;text-align:right;color:black;font-weight:bold" id="paragraphfooter" runat="server">تُعد وزارة الإقتصاد الرقمي والريادة المسؤول الإداري والمسجل الحصري لأسماء النطاقات المنتهية بالنطاق العلوي اللاتيني jo. على المستويين الأول والثاني والنطاق العلوي الأردني العربي (.الاردن).(ICANN) ؛ الجهة العالمية الواضعة لسياسات الأسماء والأرقام على شبكة الإنترنت. </p>
<br>
</div>


<div class="col-lg-4 col-md-4 vertical-space-2">
<h5>&nbsp;</h5>
<h5>&nbsp;</h5>
<h5 style="font-family:cairo;text-align:right" dir="rtl" id="support" runat="server">الدعم الفني</h5>
<div id="divphone" runat="server"  dir="ltr" style="font-family:cairo;text-align:right">
06 5 300263 <br />
 <a href="mailto:dns@modee.gov.jo" style="font-family:cairo;color:black;font-weight:bold" dir="rtl">dns@modee.gov.jo</a>
</div></div>


<div class="col-lg-4 col-md-4 vertical-space-2">
<h5>&nbsp;</h5>
<h5>&nbsp;</h5>
<h5 style="font-family:cairo;text-align:right" dir="rtl">روابط مهمة</h5>
<div class="text"  style="font-family:cairo;text-align:right; float: right;" dir="rtl">
<p style="font-family:cairo;text-align:right"><a href="faq.aspx" style="font-family:cairo;text-align:right;color:black;font-weight:bold" dir="rtl">أسئلة متكررة</a></p>
<p style="font-family:cairo;text-align:right"><a href="https://www.efawateercom.jo/Portal/Home" target="_blank" style="font-family:cairo;text-align:right;color:black;font-weight:bold" dir="rtl"> إي فواتيركم</a></p>
<p style="font-family:cairo;text-align:right"><a href="https://www.sanad.gov.jo/default/en" target="_blank" style="font-family:cairo;text-align:right;color:black;font-weight:bold" dir="rtl">سند</a></p> 

</div>

</div>

</div></div>

<div class="vertical-space-60"></div></footer>
</div>
<div class="container-fluid background-color-orange main-footer">
<div class="container text-center">
<div class="vertical-space-30"></div>
<p><a target="_blank" href="https://www.modee.gov.jo/" style="color:silver; font-family:cairo">جميع الحقوق محفوظة © وزارة الإقتصاد الرقمي والريادة  </a></p>
</div>
</div>




		                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                        SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
<script data-cfasync="false" src="js/email-decode.min.js" async defer></script><script src="js/jquery-3.6.3.min.js"></script>
<script src="js/bootstrap5.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<script src="js/4n2NXumNjtg5LPp6VXLlDicTUfA.js" defer async></script>
<script src="owlcarousel/owl.carousel.min.js" async defer></script>
<script src="js/jquery-ui.min.js" async defer></script>
    <link href="css\css7.css" rel="stylesheet"> 
    <script src="js/custom.js" async defer></script>
<script>
        $(".search-icone").click(function(){
     // $(".menu").animate({height: "100vh"});
});

</script>
</body>
</html>
