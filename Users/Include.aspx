<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="Include.aspx.vb" Inherits="Domain2021.Include" ViewStateEncryptionMode="Always" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link href="../Content/toastr.css" rel="stylesheet" media="all"/>
    <br /><br /><br /><br /><center>
<section id="post_job" runat="server"  style="width:700px">
<div class="vertical-space-100"></div>
     <asp:Label ID="lbl_error" runat="server"  
            ForeColor="Red"></asp:Label> <asp:Label ID="lbl_Result" runat="server" 
                 ForeColor="Blue"></asp:Label>
<div class="container table-bordered"><br />
    
   <div class="card-header rounded" id="HLabel1" runat="server">

  </div>
       
<div class="job-post-box" >
    <div class="vertical-space-30"></div>
        
<div class="form-group">  
<label for="exampleInputJobtitle" id="DomainName" runat="server">Job title</label>
<asp:TextBox  type="text" class="form-control" id="DomainnamesText" runat="server" TextMode="MultiLine" required ></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DomainnamesText"></asp:RequiredFieldValidator>
</div>
<div class="row">
<div class="col-lg-6 col-md-6">
<div class="form-group">
<label for="exampleInputCompany" id="Email" runat="server">Company</label>
<asp:TextBox  type="text"  class="form-control" id="EmailText" runat="server"  required ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="EmailText"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"  ControlToValidate="EmailText" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
</div>
</div>
<div class="col-lg-6 col-md-6">

</div>
</div>


<asp:button type="submit" Font-Bold="true"  cssclass="btn btn-info" id="Button11" OnClick="btn_U_update_Click" runat="server"></asp:button>
    <br /><br />
</div>
</div><br /><br /><br />
</section></center>
        <script src="https://code.jquery.com/jquery.js" async defer></script>
        <script src="../Assets/toastr.min.js" async defer></script>
        <script src="../Assets/script.js" async defer></script>
        <link href="../Assets/toastr.min.css" rel="stylesheet" media="all"/>     
        <script src="../Scripts/toastr.js" async defer></script>

</asp:Content>
  