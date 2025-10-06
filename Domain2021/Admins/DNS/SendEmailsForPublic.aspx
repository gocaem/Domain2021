<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="SendEmailsForPublic.aspx.vb" Inherits="Domain2021.SendEmailsForPublic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>


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
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div>
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
                                                    <img src="../app-assets/3MODEE-news-0.png" alt="branding logo">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body collapse in">
                                            <div class="card-block card-dashboard">
                                                <p class="card-text text-bold-900" style="font-size: 16px">Approve Domain's Data</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                 
    

    Subject of Email:<asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox><br />
                                                        
    <cc1:Editor runat="server" id="Editor1" height="700px"></cc1:Editor>

      
    <asp:Button ID="Button1" OnClick="Button1_Click" Text="Send Email" CssClass="btn btn-success" runat="server" />
                            </section>
                        </div>
                    </div>
                </div>
            </div>

            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
