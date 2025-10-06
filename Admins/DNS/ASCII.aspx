<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="ASCII.aspx.vb" Inherits="Domain2021.ASCII" ViewStateEncryptionMode="Always" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <script>
                $(document).ready(function () {
                    var collapse = document.getElementById("li2")
                    collapse.className = "active";


                });
            </script>
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <div>
      <div class="app-content content container-fluid">
      <div class="content-wrapper">
        <div class="content-header row">
        </div>
        <div class="content-body"><section class="flexbox-container">
    <div class="col-md-8 offset-md-2 col-xs-10 offset-xs-1  box-shadow-2 p-0">
        <div class="card border-grey border-lighten-10 m-0">
            <div class="card-header no-border">
                <div class="card-title text-xs-center">
                    <div class="p-1"><img src="../app-assets/3MODEE-news-0.png" alt="branding logo"></div>
                </div> 
          </div>     
            <div class="card-body collapse in">
                <div class="card-block card-dashboard">
                    <p class="card-text text-bold-900" style="font-size:16px">Ascii Converter</p>
                         <div class="table-responsive">
          <TABLE  class="table">
        <TR>
            <TD >&nbsp;</TD>
        </TR>
      
        <TR>
            <TD   class="card-text text-bold-900">&nbsp;Text to Convert :<asp:TextBox id="txt_admin_id" runat="server" Visible="true" CssClass="form-control"></asp:TextBox>
            </TD>
        </TR>
        <TR>
            <TD>
                <asp:Button ID="Button3" CssClass="btn btn-cyan pull-center"  OnClick="Button3_Click" runat="server" Font-Bold="True" Text="Convert String to ASCII" />
            </td>
        </TR>
        <TR>
            <TD >
                <asp:Label ID="Label1" runat="server" ForeColor="#990000" style="font-weight: 700"></asp:Label>
            </TD>
        </TR>
      
    </TABLE>
</div>




            <div class="card-footer">
                <div class="">
                             </div>
            </div>
        </div>
    </div>
</section>
          
</asp:Content>

