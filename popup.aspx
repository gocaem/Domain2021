<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popup.aspx.vb" Inherits="Domain2021.popup" ValidateRequest="false" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
     <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="css\css3.css" rel="stylesheet" media="all">
<link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />
 <link rel="apple-touch-icon" href="images/apple-touch-icon.html">
<link rel="shortcut icon" type="image/ico" href="images/favicon.html" />
  <link rel="stylesheet" href="css/bootstrap.min.css"  crossorigin="anonymous" media="all">
<link href="css/matrialize.css" rel="stylesheet" media="all">
<link href="owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" media="all">

<script src="build/js/intlTelInput.js" ></script>
<link rel="stylesheet" href="build/css/intITellnputRTL.css" media="all"/>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>
                 <script type="text/javascript">
                     debugger
                     function openModal() {
                         $('#danger').modal('show');

                     }
                     function openModal2() {
                         $('#danger2').modal('show');

                     }
                 </script> 


</head>
<body>

    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

              <div class="modal fade" id="danger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-danger">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="location.href='FirstPage.aspx'">×</button>
                            <h3 id="isregistered" runat="server"><i class="fa fa-edit"></i></h3>
                        </div>
                        <div class="modal-body">
                            <center><img src="imags/check.jpg" width="205px" /><br />
                        <asp:Label ID="lblupdate" Font-Bold="true" Text="Are you sure you want to update?" runat="server"></asp:Label>&nbsp;<asp:LinkButton ID="LinkButton1" OnClick="lk_Click" runat="server" Font-Bold="true"></asp:LinkButton></center>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnc" runat="server" class="btn btn-default pull-left" data-dismiss="modal" onclick="location.href='FirstPage.aspx'">Close</button>
                            <asp:Button ID="Button4"  type="button" runat="server" CssClass="btn btn-info pull-left" Text="Yes" OnClick="lk_Click"  ></asp:Button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
</form>
</body>
</html>