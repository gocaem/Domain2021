<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage_En.Master" CodeBehind="WhoisDetails.aspx.vb" Inherits="Domain2021.WhoisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @media (min-width: 1025px) {
            .h-custom {
                height: 100vh !important;
            }
        }

        .card-registration .select-input.form-control[readonly]:not([disabled]) {
            font-size: 1rem;
            line-height: 2.15;
            padding-left: .75em;
            padding-right: .75em;
        }

        .card-registration .select-arrow {
            top: 13px;
        }



        .bg-indigo {
            background-color: #488bc6;
        }

        @media (min-width: 992px) {
            .card-registration-2 .bg-indigo {
                border-top-right-radius: 15px;
                border-bottom-right-radius: 15px;
            }
        }

        @media (max-width: 991px) {
            .card-registration-2 .bg-indigo {
                border-bottom-left-radius: 15px;
                border-bottom-right-radius: 15px;
            }
        }
    </style>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <section id="sec" runat="server">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12">
                    <div class="card card-registration card-registration-2" style="border-radius: 15px;">
                        <div class="card-body p-0">
                            <div class="row g-0">
                                <div class="col-lg-6">
                                    <div class="p-5" id="card" runat="server">
                                        <h4 class="fw-normal mb-5" style="color: #488bc6;" id="general"  runat="server">General Infomation</h4>

                                         <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                            <asp:Label runat="server" ID="Domainname" Text="Domain Name:"></asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="Domain_lbl" Font-Bold="true"></asp:Label>
                                        </div>
                                                 <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">



                                                <asp:Label runat="server" ID="entityname" Text="Entity Name:"></asp:Label>
                                                <asp:Label runat="server" ID="eName" Font-Bold="true"></asp:Label>


                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="OwnerNameL" runat="server"></asp:Label><asp:Label ID="OwnerNameV" runat="server" Font-Bold="true"></asp:Label>
                                            </div>
                                            <hr />
                                            <div class="mb-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="OwnerEmailL" runat="server"></asp:Label><asp:Label ID="OwnerEmailV" runat="server" Font-Bold="true"></asp:Label>
                                            </div>
                                            <hr />
                                            <div class="mb-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="OwnerMobileL" runat="server"></asp:Label><asp:Label ID="OwnerMobileV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-4">
                                            </div>
                                        </div>
                                                <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">



                                                <asp:Label runat="server" ID="Reg_dateL" Text="Entity Name:"></asp:Label>
                                                <asp:Label runat="server" ID="Regdatev" Font-Bold="true"></asp:Label>


                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="AdminDetailsLabel" runat="server"></asp:Label><asp:Label ID="AdminDetailsV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="AdminEmailLabel" runat="server"></asp:Label><asp:Label ID="AdminEmailV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="AdminMobileLabel" runat="server"></asp:Label><asp:Label ID="AdminMobileV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">

                                                <asp:Label ID="TechLabel" runat="server"></asp:Label><asp:Label ID="TechLabelV" runat="server" Font-Bold="true"></asp:Label>
                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-108 mb-4 pb-2 mb-md-0 pb-md-0">
                                                &nbsp;  &nbsp;
                                                <asp:Label ID="TechEmailLabel" runat="server"></asp:Label><asp:Label ID="TechEmailV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="TechMobileLabel" runat="server"></asp:Label><asp:Label ID="TechMobileV" runat="server" Font-Bold="true"></asp:Label>

                                            </div>
                                            <hr />

                                            <div class="col-md-2">
                                            </div>
                                        </div>

                                        <hr />
                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">

                                                <asp:Label ID="BillingDetails" runat="server"></asp:Label><asp:Label ID="BillingDetailsV" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-10 mb-4 pb-2 mb-md-0 pb-md-0">

                                                <asp:Label ID="BillEmailLabel" runat="server"></asp:Label><asp:Label ID="BillEmailV" Font-Bold="true" runat="server"></asp:Label>

                                            </div>
                                            <hr />
                                            <div class="col-md-2">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8 mb-4 pb-2 mb-md-0 pb-md-0">
                                                <asp:Label ID="BillMobileLabel" runat="server"></asp:Label><asp:Label ID="BillMobileV" Font-Bold="true" runat="server"></asp:Label>

                                            </div>
                                            <hr />

                                            <div class="col-md-4">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6 bg-indigo text-white">
                                    <div class="p-5" id="card2" runat="server">
                                        <h4 class="fw-normal mb-5" id="serverdet" runat="server">Servers Details</h4>

                                        <div class="row">
                                            <div class="col-md-6 mb-4">

                                                <div>
                                                      <asp:Label ID="Server1L" runat="server"></asp:Label><asp:Label ID="Server1V" Font-Bold="true" runat="server"></asp:Label>

                                                </div>

                                            </div>
                                            <div class="col-md-6 mb-4">

                                                <div>
                                                   <asp:Label ID="Server2L" runat="server"></asp:Label><asp:Label ID="Server2V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                         <asp:Label ID="Server3L" runat="server"></asp:Label><asp:Label ID="Server3V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-md-7 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                       <asp:Label ID="Server4L" runat="server"></asp:Label><asp:Label ID="Server4V" Font-Bold="true" runat="server"></asp:Label>
                                                       
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                      <asp:Label ID="Server5L" runat="server"></asp:Label><asp:Label ID="Server5V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-md-7 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                      <asp:Label ID="Server6L" runat="server"></asp:Label><asp:Label ID="Server6V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                     <asp:Label ID="Server7L" runat="server"></asp:Label><asp:Label ID="Server7V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-md-7 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                     <asp:Label ID="Server8L" runat="server"></asp:Label><asp:Label ID="Server8V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                      <asp:Label ID="Server9L" runat="server"></asp:Label><asp:Label ID="Server9V" Font-Bold="true" runat="server"></asp:Label>     
                                                </div>

                                            </div>
                                            <div class="col-md-7 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                    <asp:Label ID="Server10L" runat="server"></asp:Label><asp:Label ID="Server10V" Font-Bold="true" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                          <div class="row">
                                            <div class="col-md-5 mb-4 pb-2">

                                                <div class="form-outline form-white">
                                                      <asp:Label ID="Server11L" runat="server"></asp:Label><asp:Label ID="Server11V" Font-Bold="true" runat="server"></asp:Label>     
                                                </div>

                                            </div>
                                            <div class="col-md-7 mb-4 pb-2">



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <br />
    <br />
    <br />
    <br />
       <br />
    <br />
    <br />
    <br />
        <br />
    <br />
    <br />
    <br />
       <br />
    <br />
    <br />
    <br />
</asp:Content>
