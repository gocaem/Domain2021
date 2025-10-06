<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="Profile.aspx.vb" Inherits="Domain2021.Profile" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <center>
 
        <div class="p-6 max-w-sm bg-white rounded-lg border border-gray-200 shadow-md dark:bg-gray-800 dark:border-gray-700" style="width:800px;border-radius:5px" id="c" runat="server">
  	<br /><div class="row" >
                                                    <div class="col-lg-12 col-md-12" >
                                                        <label for="FirstNameServer" enabled="false" id="Label1" runat="server" style="width: 100%" class="alert alert-info">Administartor Info</label>
                                                    </div>
                                                </div>

		        <div class="row">
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="form-group">
                                                            <label for="Username" id="Label2" runat="server">Company User name</label>
                                                            <asp:Label runat="server" Font-Bold="true" ForeColor="InfoText" Enabled="false" class="form-text" ID="Uname" placeholder="User Name" required></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="form-group">
                                                            <label for="Name" id="Label3" runat="server">Administrative Name</label>
                                                            <asp:Label class="form-text" Font-Bold="true" ForeColor="InfoText" Enabled="false" ID="adminName" runat="server" placeholder="Name" required></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="form-group">
                                                            <label for="AEmail" id="Label4" runat="server">Email</label>
                                                            <asp:Label runat="server" Font-Bold="true" ForeColor="InfoText" Enabled="false" class="form-text" ID="EmailL" placeholder="Email" required></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="form-group">
                                                             <label for="AEmail" id="Label5" runat="server">Phone</label>
                                                            <asp:Label runat="server" Font-Bold="true" ForeColor="InfoText" Enabled="false" class="form-text" ID="Phone" placeholder="Email" required></asp:Label>
                                                    
                                                        </div>
                                                    </div>
                                                </div>
</div>
	</center>
    <br />

</asp:Content>
