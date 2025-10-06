<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admins/DNS/Site3.Master" CodeBehind="Profile.aspx.vb" Inherits="Domain2021.Profile1" ViewStateEncryptionMode="Always" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                                <p class="card-text text-bold-900" style="font-size: 16px">Profile</p>
                                                <div class="table-responsive">
                                                    <div class="modal-body" style="font-weight: bold; font-family: Calibri">
                                                                      <div class="card-footer">
                                                                            <div class="card">
            <div class="col-xs-12 col-sm-9">
							<h4 class="blue">
								<span class="middle">
									<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>

								<span class="label label-purple arrowed-in-right">
									<i class="ace-icon fa fa-circle smaller-80 align-middle"></i>
									online
								</span>
							</h4>

							<div class="profile-user-info">
								<div class="profile-info-row">
									<div class="profile-info-name"> Username </div>

									<div class="profile-info-value">
										<span>	<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></span>
									</div>
								</div>
								<br />
								<div class="profile-info-row">
									<div class="profile-info-name"> User Type </div>

									<div class="profile-info-value">
										<i class="fa fa-users light-orange bigger-110"></i>
										<span>	<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></span>
										
									</div>
								</div>
								<br />
								<div class="profile-info-row">
									<div class="profile-info-name"> User Mobile </div>

									<div class="profile-info-value">
										<span>	<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></span>
									</div>
								</div>
								<br />
							

								
							</div>

							<div class="hr hr-8 dotted"></div>

							
						</div>
        </div>

    </div>
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
</asp:Content>
