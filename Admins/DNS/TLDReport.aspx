<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="TLDReport.aspx.vb" Inherits="Domain2021.TLDReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
        <ContentTemplate>
    <div>
                          <script>
                              $(document).ready(function () {
                                  var collapse = document.getElementById("report")
                                  collapse.className = "sidebar-submenu menu-open";
                                  collapse.style.display = "block";

                              });
                          </script>
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
                                                
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri"><p class="card-text" style="font-size: 22px"><b>TLD Repots</b> </p>
                                                 
                                                         <table id="table4" class="aText" width="80%">
        <tr>
            <td align="left" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
      
        <tr>
            <td class="aText">
                &nbsp;</td>
            <td class="aText">
                &nbsp;
            </td>
        </tr>
     
            <td class="aText">
            </td>
           	<TD colSpan="2" class="aText" ></TD>
								</TR><asp:panel id="Panel1" runat="server" Width="200px" class="aText"><% ROUNDROPEN %></asp:panel>
								<TR>
									<TD colSpan="2"></TD>
        </tr>
        <tr>
            <td colspan="2" class="aText">
            </td>
            
        </tr>
    </table>


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
                <div class="container">
                </div>
            </div>

        </ContentTemplate>
  
    </asp:UpdatePanel>

    <link href="./Media/css/Grey/ListBox.Grey.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="./Media/css/WebTrack.css" rel="stylesheet" type="text/css" media="all"/>

    <link href="../assets/css/toastr.css"
        rel="stylesheet" media="all"/>

    <script src="../assets/js/toastr.js" defer async
        type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function Notify(msg, title, type, clear, pos, sticky) {



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
      
</asp:Content>
