<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="Register.aspx.vb" Inherits="Domain2021.Register1" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <link rel="stylesheet" href="build/css/intlTelInput.css" media="all"/>

    <script src="../build/js/intlTelInput.min.js" ></script>
<link rel="stylesheet" href="../build/css/intITellnputRTL.css" media="all"/>




    <br />
    <br />
    <br />
    <br />

    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <style>
        .iti {
            position: relative;
            display: inline-block;
        }

        input[type=tel] {
            padding-right: 6px;
            padding-left: 52px;
            margin-left: 0;
            position: relative;
            z-index: 0;
            margin-top: 0 !important;
            margin-bottom: 0 !important;
            margin-right: 0;
            border: 1px solid #CCC;
            height: 35px;
            width: 350px;
            /* padding: 6px 12px; */
            border-radius: 2px;
            font-family: inherit;
            font-size: 100%;
            color: inherit;
        }

        button {
            color: #FFF;
            background-color: #428BCA;
            border: 1px solid #357EBD;
            height: 39px;
            margin: 0;
            padding: 6px 20px;
            border-radius: 2px;
            font-family: inherit;
            font-size: 100%;
        }

            button:hover {
                background-color: #3276B1;
                border-color: #285E8E;
                cursor: pointer;
            }

        /* Chrome, Safari, Edge, Opera */
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        /* Firefox */
        input[type=number] {
            -moz-appearance: textfield;
        }

        button,
        input {
            font-family: "Montserrat", "Helvetica Neue", Arial, sans-serif;
        }




        p {
            line-height: 1.61em;
            font-weight: 300;
            font-size: 1.2em;
        }

        .category {
            text-transform: capitalize;
            font-weight: 700;
        }



        .nav-item .nav-link,
        .nav-tabs .nav-link {
            -webkit-transition: all 300ms ease 0s;
            -moz-transition: all 300ms ease 0s;
            -o-transition: all 300ms ease 0s;
            -ms-transition: all 300ms ease 0s;
            transition: all 300ms ease 0s;
        }

        .card a {
            -webkit-transition: all 150ms ease 0s;
            -moz-transition: all 150ms ease 0s;
            -o-transition: all 150ms ease 0s;
            -ms-transition: all 150ms ease 0s;
            transition: all 150ms ease 0s;
        }

        [data-toggle="collapse"][data-parent="#accordion"] i {
            -webkit-transition: transform 150ms ease 0s;
            -moz-transition: transform 150ms ease 0s;
            -o-transition: transform 150ms ease 0s;
            -ms-transition: all 150ms ease 0s;
            transition: transform 150ms ease 0s;
        }

        [data-toggle="collapse"][data-parent="#accordion"][aria-expanded="true"] i {
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=2);
            -webkit-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
            transform: rotate(180deg);
        }


        .now-ui-icons {
            display: inline-block;
            font: normal normal normal 14px/1 'Nucleo Outline';
            font-size: inherit;
            speak: none;
            text-transform: none;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }

        @-webkit-keyframes nc-icon-spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @-moz-keyframes nc-icon-spin {
            0% {
                -moz-transform: rotate(0deg);
            }

            100% {
                -moz-transform: rotate(360deg);
            }
        }

        @keyframes nc-icon-spin {
            0% {
                -webkit-transform: rotate(0deg);
                -moz-transform: rotate(0deg);
                -ms-transform: rotate(0deg);
                -o-transform: rotate(0deg);
                transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
                -moz-transform: rotate(360deg);
                -ms-transform: rotate(360deg);
                -o-transform: rotate(360deg);
                transform: rotate(360deg);
            }
        }

        .now-ui-icons.objects_umbrella-13:before {
            content: "\ea5f";
        }

        .now-ui-icons.shopping_cart-simple:before {
            content: "\ea1d";
        }

        .now-ui-icons.shopping_shop:before {
            content: "\ea50";
        }

        .now-ui-icons.ui-2_settings-90:before {
            content: "\ea4b";
        }

        .nav-tabs {
            border: 0;
            padding: 15px 0.7rem;
        }

            .nav-tabs:not(.nav-tabs-neutral) > .nav-item > .nav-link.active {
                box-shadow: 0px 5px 35px 0px rgba(0, 0, 0, 0.3);
            }

        .card .nav-tabs {
            border-top-right-radius: 0.1875rem;
            border-top-left-radius: 0.1875rem;
        }

        .nav-tabs > .nav-item > .nav-link {
            margin: 0;
            margin-right: 5px;
            background-color: transparent;
            border: 1px solid transparent;
            border-radius: 30px;
            font-size: 14px;
            padding: 11px 23px;
            line-height: 1.5;
        }

            .nav-tabs > .nav-item > .nav-link:hover {
                background-color: transparent;
            }

            .nav-tabs > .nav-item > .nav-link.active {
                background-color: #444;
                border-radius: 30px;
                color: #FFFFFF;
            }

            .nav-tabs > .nav-item > .nav-link i.now-ui-icons {
                font-size: 14px;
                position: relative;
                top: 1px;
                margin-right: 3px;
            }

        .nav-tabs.nav-tabs-neutral > .nav-item > .nav-link {
            color: #FFFFFF;
        }

            .nav-tabs.nav-tabs-neutral > .nav-item > .nav-link.active {
                background-color: rgba(255, 255, 255, 0.2);
                color: #FFFFFF;
            }

        .card {
            border: 0;
            border-radius: 0.1875rem;
            display: inline-block;
            position: relative;
            width: 100%;
            margin-bottom: 30px;
            box-shadow: 0px 5px 25px 0px rgba(0, 0, 0, 0.2);
        }

            .card .card-header {
                background-color: transparent;
                border-bottom: 0;
                background-color: transparent;
                border-radius: 0;
                padding: 0;
            }

            .card[data-background-color="orange"] {
                background-color: #f96332;
            }

            .card[data-background-color="red"] {
                background-color: #FF3636;
            }

            .card[data-background-color="yellow"] {
                background-color: #FFB236;
            }

            .card[data-background-color="blue"] {
                background-color: #2CA8FF;
            }

            .card[data-background-color="green"] {
                background-color: #15b60d;
            }

        [data-background-color="orange"] {
            background-color: #e95e38;
        }

        [data-background-color="black"] {
            background-color: #2c2c2c;
        }

        [data-background-color]:not([data-background-color="gray"]) {
            color: #FFFFFF;
        }

            [data-background-color]:not([data-background-color="gray"]) p {
                color: #FFFFFF;
            }

            [data-background-color]:not([data-background-color="gray"]) a:not(.btn):not(.dropdown-item) {
                color: #FFFFFF;
            }

            [data-background-color]:not([data-background-color="gray"]) .nav-tabs > .nav-item > .nav-link i.now-ui-icons {
                color: #FFFFFF;
            }




        .now-ui-icons {
            display: inline-block;
            font: normal normal normal 14px/1 'Nucleo Outline';
            font-size: inherit;
            speak: none;
            text-transform: none;
            /* Better Font Rendering */
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }



        @media screen and (max-width: 768px) {

            .nav-tabs {
                display: inline-block;
                width: 100%;
                padding-left: 100px;
                padding-right: 100px;
                text-align: center;
            }

                .nav-tabs .nav-item > .nav-link {
                    margin-bottom: 5px;
                }
        }
    </style>
    

    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="panel1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Spinner.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="panel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="container mt-5" dir="rtl" id="container" runat="server">
                <div class="row">
                    <div class="col-md-12 ml-auto col-xl-12 mr-auto">
                        <br />
                        <div class="card">
                            <div class="card-header">
                                <ul class="nav nav-tabs justify-content-center" role="tablist" dir="rtl" id="nav" runat="server">
                                    <li class="nav-item home" enableviewstate="false">
                                        <a data-toggle="tab" class="nav-link active" href="#DomainInfo" onclick="" id="DomainInfotab" runat="server" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold">
                                            <i class="fa fa-info-circle" style="padding-left: 10px"></i>معلومات النطاق
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="tab" id="Servertab" runat="server" href="#ServerP" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold">
                                            <i class="fa fa-server" style="padding-left: 10px"></i>اسماء الخوادم
                                        </a>
                                    </li>

                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="tab" href="#ContactInfo" id="ContactInfotab" runat="server" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold">
                                            <i class="fa fa-info" style="padding-left: 10px"></i>معلومات الإتصال
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="tab" href="#DocumentInfo" role="tab" dir="rtl" id="Documenttab" runat="server" style="font-family: cairo; font-weight: bold">
                                            <i class="fa fa-file" style="padding-left: 10px"></i>رفع الوثائق
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <div class="card-body">

                                <div class="tab-content text-center">
                                    <asp:Panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="DomainInfo" role="tabpanel">

                                        <div class="row">

                                            <div class="col-lg-4 col-md-4" id="Div2" runat="server">
                                                <div class="form-group">

                                                    <asp:Label ID="Domain_nameL" runat="server" Font-Bold="True"></asp:Label><label id="Label1" runat="server" style="color: red; font-weight: bold">*</label>
                                                    <asp:TextBox CssClass="form-control" ID="Domain_name" runat="server" AutoPostBack="true" OnTextChanged="Domain_name_TextChanged" ValidationGroup="A"></asp:TextBox>
                                                    <asp:Literal ID="DomainLiteral1" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" ID="Domain_nameValidator" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="Domain_name"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4" id="Div4" runat="server">
                                                <label id="Label7" runat="server">
                                                    <asp:Label ID="SecondDomainLabel" runat="server" Font-Bold="True"></asp:Label></label>
                                                <asp:DropDownList Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="SecondDomain_SelectedIndexChanged" CssClass="form-control" ID="SecondDomain" Enabled="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            </div>

                                            <div class="col-lg-4 col-md-4" id="Div1" runat="server">
                                                <div class="form-group">

                                                    <asp:Label ID="ClassificationLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label3" runat="server" style="color: red; font-weight: bold">*</label>
                                                    <asp:DropDownList Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="Classification_SelectedIndexChanged" CssClass="form-control" ID="Classification" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" ValidationGroup="A" ID="ClassificationValidator" runat="server" SetFocusOnError="true" ControlToValidate="Classification" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4" id="DivNationalNo" runat="server" visible="false">

                                                <asp:Label ID="NationalNoL" runat="server" Font-Bold="True"></asp:Label><label id="Label8" runat="server" style="color: red; font-weight: bold">*</label>
                                                <asp:TextBox CssClass="form-control" ID="NationalNo" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="NationalNo_TextChanged" CausesValidation="true" ValidationGroup="A"></asp:TextBox>
                                                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="false" ID="NationalNoValidator" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="NationalNo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="false" ID="NationalNoRegValid" runat="server" ControlToValidate="NationalNo" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d+$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                               
                                            </div>
                                            <div class="col-lg-4 col-md-4" id="DivcardNo" runat="server" visible="false">
                                                     <asp:Label ID="CardLbl" Visible="false" runat="server" Font-Bold="True"></asp:Label><label id="RequiredCardNo" runat="server" style="color: red; font-weight: bold">*</label>
                                                <asp:TextBox CssClass="form-control" Visible="false"  ID="CardNo" runat="server"  AutoPostBack="true" OnTextChanged="NationalNo_TextChanged" CausesValidation="true" ValidationGroup="A"></asp:TextBox>
                                               <asp:RequiredFieldValidator Visible="false"  ForeColor="Red" Font-Bold="false" ID="CardRequired" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="CardNo"></asp:RequiredFieldValidator>
                                        
                                            </div>
                                            <div class="col-lg-4 col-md-4" id="OrgDetailDiv" runat="server" visible="false">
                                                <div class="form-group">
                                                    <asp:Label ID="OrgDetailL" runat="server" Font-Bold="True"></asp:Label><label id="Label9" runat="server" style="color: red; font-weight: bold">*</label>
                                                    <asp:TextBox CssClass="form-control" ID="OrgDetailTextBox" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="false" ID="OrgDetailValidator" ValidationGroup="A" runat="server" SetFocusOnError="true" ControlToValidate="OrgDetailTextBox"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-8 col-md-8" id="Div3" runat="server" visible="false">
                                                <div class="form-group">

                                                    <asp:Label ID="TMlabel" runat="server" Font-Bold="True"></asp:Label><label id="Label11" runat="server" style="color: red; font-weight: bold">*</label>
                                                    <asp:GridView ID="TMGridView" BorderColor="Black" ForeColor="Black" Font-Bold="true" GridLines="None" CssClass="table table-responsive" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="strTradeMarkArName" DataField="strTradeMarkArName"></asp:BoundField>
                                                            <asp:BoundField HeaderText="strTradeMarkEnName" DataField="strTradeMarkEnName"></asp:BoundField>

                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:GridView ID="TMGridView2" BorderColor="Black" ForeColor="Black" Font-Bold="true" GridLines="None" CssClass="table table-responsive" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Mark_name" DataField="Mark_name" SortExpression="Admin_id"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Mark_name_lang2" DataField="Mark_name_lang2" SortExpression="Admin_id"></asp:BoundField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>

                                        <asp:Button ID="NextStep1" runat="server" Text="Button" OnClick="NextStep1_Click" CssClass="btn btn-success" OnClientClick="return Validate()" ValidationGroup="A" />
                                    </asp:Panel>
                                    <asp:Panel CssClass="tab-pane" ID="ServerP" role="tabpanel" ClientIDMode="Static" runat="server">
                                        <asp:CheckBox ID="reservedfuture" AutoPostBack="true" OnCheckedChanged="reservedfuture_CheckedChanged" runat="server" type="CheckBox" /><br />

                                        <asp:Panel ID="all" runat="server" Font-Bold="true">
                                            <div class="row" id="PrimaryNameServerRow" runat="server" visible="true">
                                                <div class="col-lg-4 col-md-4" id="PrimaryNameServer" visible="true" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="PrimaryNameServerLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label10" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="PrimaryNameServerTextBox" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="pname1"  ForeColor="Red" runat="server" ValidationGroup="b" ControlToValidate="PrimaryNameServerTextBox"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularServer" ForeColor="red" ControlToValidate="PrimaryNameServerTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="(?=^.{1,254}$)(^(?:(?!\d+\.|-)[a-zA-Z0-9_\-]{1,63}(?<!-)\.?)+(?:[a-zA-Z]{2,})$)" ValidationGroup="b"></asp:RegularExpressionValidator>
                                             
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div5" visible="true" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="PrimaryNameServerip" runat="server" Font-Bold="True"></asp:Label><label id="Label12" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="PrimaryNameServeripTextBox" runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="IPadd" ForeColor="red" ControlToValidate="PrimaryNameServeripTextBox" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b" ValidationGroup="b"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <span>
                                                    <div visible="true" runat="server">
                                                        <div class="form-group" style="padding-top: 25px">
                                                            <label id="Label4" runat="server"></label>
                                                            <br />
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label>


                                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" OnClick="LinkButton1_Click" ForeColor="White" Text="add nameserver" ValidationGroup="b"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </span>
                                            </div>

                                            <div class="row" id="Nameserver2" runat="server" visible="true">

                                                <asp:GridView ID="GridView1" ShowFooter="true" OnRowDeleting="GridView1_RowCommand"  BorderColor="Black" ForeColor="Black" Font-Bold="true" GridLines="both" CssClass="table table-responsive" runat="server" AutoGenerateColumns="true">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="del" runat="server" CommandName="delete"><i class="fa fa-trash" style="color:red"></i> </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                            </div>

                                        </asp:Panel>

                                        <br />
                                        <asp:Button ID="PreviousToStep2" runat="server" Text="Previous Step" OnClick="PreviousToStep2_Click" CssClass="btn btn-dark" ValidationGroup="e" />

                                        <asp:LinkButton ID="NextToStep3" runat="server" CssClass="btn btn-success" OnClick="NextToStep3_Click" ValidationGroup="f"></asp:LinkButton>

                                    </asp:Panel>
                                    <asp:Panel CssClass="tab-pane" ID="ContactInfo" role="tabpanel" ClientIDMode="Static" runat="server">
                                        <asp:Panel ID="ContactPanel" runat="server">
                                            <asp:Label ID="AdminDetails" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Admin Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div22" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="AdminDetailsLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label2" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="AdminTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="AdminTextBoxValidator" runat="server" ControlToValidate="AdminTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div23" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="AdminMobileLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label13" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" AutoCompleteType="Cellular" ClientIDMode="Static" ID="AdminMobileTextBox" runat="server" required type="phone"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="AdminMobileTextBoxValidator" runat="server" ControlToValidate="AdminMobileTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                     
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div24" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="AdminEmailLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label14" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="AdminEmailTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="AdminEmailTextBoxValidator" runat="server" ControlToValidate="AdminEmailTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ForeColor="Red" ID="AdminEmailExpressionValidator" runat="server" ControlToValidate="AdminEmailTextBox" ValidationGroup="c" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </div>

                                                </div>
                                            </div>
                                            <hr />
                                            <asp:Label ID="OwnerDetailsLabel" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Owner Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div10" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="OwnerName" runat="server" Font-Bold="True"></asp:Label><label id="Label15" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="OwnerNameTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="OwnerNameRequiredFieldValidator" runat="server" ControlToValidate="OwnerNameTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div11" runat="server">
                                                    <div class="form-group iti">
                                                        <asp:Label ID="OwnerMobileLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label16" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="OwnerMobileTextBox" runat="server" required ClientIDMode="Static" type="tel" TextMode="Phone" name="phone"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="OwnerMobileValidator" runat="server" ControlToValidate="OwnerMobileTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="phonenumber" ControlToValidate="OwnerMobileTextBox" ValidationGroup="c" Font-Size="Small" Font-Bold="true" ForeColor="red"></asp:CustomValidator>
                                                        <span id="valid-msg" class="d-inline-block" style="color: green" tabindex="0" data-toggle="popover" data-content="" data-placement="right"></span>


                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div12" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="OwnerEmailLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label17" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="OwnerEmailTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="OwnerEmailValidator" runat="server" ControlToValidate="OwnerEmailTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ForeColor="Red" ID="OwnerEmailExpressionValidator" runat="server" ControlToValidate="OwnerEmailTextBox" ValidationGroup="c" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </div>

                                                </div>
                                            </div>


                                            <hr />
                                            <asp:Label ID="TechDetailsLabel" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Tech Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div16" runat="server">
                                                    <div class="form-group">

                                                        <asp:Label ID="TechLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label18" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="TechTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="TechValidator" runat="server" ControlToValidate="TechTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div17" runat="server">
                                                    <div class="form-group iti">
                                                        <asp:Label ID="TechMobileLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label19" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="TechMobileTextBox" runat="server" required ClientIDMode="Static" type="tel" TextMode="Phone" name="phone" ValidationGroup="c"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="TechMobileValidator" runat="server" ValidationGroup="c" ControlToValidate="TechMobileTextBox"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="phonenumber2" ControlToValidate="TechMobileTextBox" ValidationGroup="c" Font-Size="Small" Font-Bold="true" ForeColor="red"></asp:CustomValidator>

                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div18" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="TechEmailLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label20" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="TechEmailTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="TechEmailTextBoxValidator" ForeColor="Red" runat="server" ControlToValidate="TechEmailTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ForeColor="Red" ID="TechEmailExpressionValidator" runat="server" ControlToValidate="TechEmailTextBox" ValidationGroup="c" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>




                                            <hr />
                                            <asp:Label ID="BillingDetails" CssClass="alert alert-info" runat="server" Font-Bold="True" Text="Billing Info" Width="100%"></asp:Label>
                                            <div class="row">
                                                <div class="col-lg-4 col-md-4" id="Div28" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label21" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="BillTextBox" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="BillingValidator" runat="server" ControlToValidate="BillTextBox" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div29" runat="server">
                                                    <div class="form-group iti">
                                                        <asp:Label ID="BillMobileLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label22" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" TextMode="Phone" ID="BillMobileText" runat="server" required name="phone" type="tel" ClientIDMode="Static"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="BMobileValidator" runat="server" ControlToValidate="BillMobileText" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="phonenumber3" ControlToValidate="BillMobileText" ValidationGroup="c" Font-Size="Small" Font-Bold="true" ForeColor="red"></asp:CustomValidator>

                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-md-4" id="Div30" runat="server">
                                                    <div class="form-group">
                                                        <asp:Label ID="BillEmailLabel" runat="server" Font-Bold="True"></asp:Label><label id="Label23" runat="server" style="color: red; font-weight: bold">*</label>
                                                        <asp:TextBox CssClass="form-control" ID="BillEmail" runat="server" required></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ID="BillEmailValidator" runat="server" ControlToValidate="BillEmail" ValidationGroup="c"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ForeColor="Red" ID="BillEmailExpressionValidator" runat="server" ControlToValidate="BillEmail" ValidationGroup="c" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </div>

                                                </div>
                                            </div>


                                            <hr />
                                            <asp:LinkButton ID="Prevto3" runat="server" CssClass="btn btn-dark" OnClick="Prevto3_Click" ></asp:LinkButton>

                                            <asp:LinkButton ID="NextToStep4" runat="server" CssClass="btn btn-success" OnClick="NextToStep4_Click" ValidationGroup="c"></asp:LinkButton>

                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Panel CssClass="tab-pane" ID="DocumentInfo" role="tabpanel" ClientIDMode="Static" runat="server">
                                        <asp:Panel ID="DocumentPanel" runat="server">
                                            <asp:UpdatePanel ID="up11" runat="server">
                                                <ContentTemplate>
                                                    <div id="accordion">

                                                        <h5 class="mb-0">
                                                            <a data-toggle="collapse" id="paper" runat="server" data-parent="#accordion" href="~/papers.aspx" target="_blank">Papers
                                                            </a>
                                                        </h5>




                                                    </div>
                                                    <p>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                            <br />
                                            <div class="row" id="Div6" runat="server">

                                                <div class="col-lg-3 col-md-3" id="Div8" visible="true" runat="server"></div>


                                                <div class="col-lg-6 col-md-6" id="Div15" visible="true" runat="server">
                                                                       <div id="fs" runat="server">
                                                    
                                                </div>
                                                <div class="col-lg-1 col-md-1" id="Div14" visible="true" runat="server"></div>
                                                <div class="col-lg-2 col-md-2" id="Div7" visible="true" runat="server"></div>
                                            </div></div>
                                            <asp:CheckBox ID="agree" ClientIDMode="Static" runat="server" /><p></p>
                                            <asp:CustomValidator ID="ckboxvalidator" ValidationGroup="doc" ClientValidationFunction="checkAgreement" runat="server" EnableClientScript="true" ErrorMessage="CustomValidator"></asp:CustomValidator>

                                            <br />
                                            <asp:LinkButton ID="PrevLast" runat="server" CssClass="btn btn-dark" OnClick="PrevLast_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="FinishRegistration" runat="server" CssClass="btn btn-success" OnClick="FinishRegistration_Click" ValidationGroup="doc"></asp:LinkButton>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="Panel2" role="tabpanel">

                                        <div class="row">

                                            <asp:Label ID="Label5" CssClass="alert alert-info" runat="server" Visible="false"></asp:Label>


                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Classification" EventName="SelectedIndexChanged" />
            <asp:PostBackTrigger ControlID="SecondDomain" />
            <asp:PostBackTrigger ControlID="NextToStep3" />
            <asp:AsyncPostBackTrigger ControlID="Domain_name" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="NationalNo" EventName="TextChanged" />
            <asp:PostBackTrigger ControlID="FinishRegistration" />
            <asp:PostBackTrigger ControlID="GridView1" />
            <asp:PostBackTrigger ControlID="LinkButton1" />

        </Triggers>
    </asp:UpdatePanel>
    <script>

        var input = document.getElementById("<%=OwnerMobileTextBox.ClientID%>");
        //    errorMsg = document.querySelector("#error-msg"),
        validMsg = document.querySelector("#valid-msg");


        // here, the index maps to the error code returned from getValidationError - see readme
        var sessionValue = '<%= Session("lang") %>';
        if (sessionValue == "en") {
            var errorMap = ["Invalid number", "Invalid country code", "The entered number is shorter than allowed", "The number entered is longer than the tags", "Invalid number"];
        } else {
            var errorMap = ["رقم غير صحيح", "الرمز الدولي غير صحيح", "الرقم الذي تم إدخاله أقصر من المسموح به ", "الرقم الذي تم إدخاله أكبر  من المسموح به", "رقم غير صحيح"];
        }



        // initialise plugin
        var iti = window.intlTelInput(input, {
            utilsScript: "/Users/build/js/utils.js?1638200991544",

            nationalMode: false
        });

        var reset = function () {
            input.classList.remove("error");

            //   errorMsg.innerHTML = "";
            // $("#error-msg").popover("hide");

            $("#valid-msg").popover("hide");
        };
        debugger;
        function phonenumber(sender, args) {
            //reset();
            if (input.value.trim()) {
                if (iti.isValidNumber()) {
                    debugger
                    //$("#valid-msg").innerHTML = iti__selected - flag
                    //$("#valid-msg").popover("show");
                    args.IsValid = true;
                } else {
                    input.classList.add("error");
                    var errorCode = iti.getValidationError();

                    sender.innerHTML = errorMap[errorCode];
                    //$("#error-msg").attr("title", errorMap[errorCode]);
                    //$("#error-msg").popover({placement: 'right', content:  errorMap[errorCode] });
                    //console.log($("#error-msg").attr("title"));
                    args.IsValid = false;
                }
            }
        }
        function phonenumber2(sender, args) {
            //reset();
            if (input.value.trim()) {
                if (iti.isValidNumber()) {
                    debugger
                    //$("#valid-msg").innerHTML = iti__selected - flag
                    //$("#valid-msg").popover("show");
                    args.IsValid = true;
                } else {
                    input.classList.add("error");
                    var errorCode = iti.getValidationError();

                    sender.innerHTML = errorMap[errorCode];
                    //$("#error-msg").attr("title", errorMap[errorCode]);
                    //$("#error-msg").popover({placement: 'right', content:  errorMap[errorCode] });
                    //console.log($("#error-msg").attr("title"));
                    args.IsValid = false;
                }
            }
        }
        // on blur: validate
        input.addEventListener('blur', phonenumber);
        // on keyup / change flag: reset
        input.addEventListener('change', reset);
        input.addEventListener('keyup', reset);

    </script>
    <script>


        //    errorMsg = document.querySelector("#error-msg"),
        validMsg = document.querySelector("#valid-msg");
        var input = document.getElementById("<%=TechMobileTextBox.ClientID%>");


        // here, the index maps to the error code returned from getValidationError - see readme
        var sessionValue = '<%= Session("lang") %>';
        if (sessionValue == "en") {
            var errorMap = ["Invalid number", "Invalid country code", "The entered number is shorter than allowed", "The number entered is longer than the tags", "Invalid number"];
        } else {
            var errorMap = ["رقم غير صحيح", "الرمز الدولي غير صحيح", "الرقم الذي تم إدخاله أقصر من المسموح به ", "الرقم الذي تم إدخاله أكبر  من المسموح به", "رقم غير صحيح"];
        }



        // initialise plugin
        var iti = window.intlTelInput(input, {
            utilsScript: "/Users/build/js/utils.js?1638200991544",

            nationalMode: false
        });

        var reset = function () {
            input.classList.remove("error");
            input2.classList.remove("error");
            //   errorMsg.innerHTML = "";
            // $("#error-msg").popover("hide");

            $("#valid-msg").popover("hide");
        };
        debugger;
        function phonenumber2(sender, args) {
            //reset();
            if (input.value.trim()) {
                if (iti.isValidNumber()) {
                    debugger
                    //$("#valid-msg").innerHTML = iti__selected - flag
                    //$("#valid-msg").popover("show");
                    args.IsValid = true;
                } else {
                    input.classList.add("error");
                    var errorCode = iti.getValidationError();

                    sender.innerHTML = errorMap[errorCode];
                    //$("#error-msg").attr("title", errorMap[errorCode]);
                    //$("#error-msg").popover({placement: 'right', content:  errorMap[errorCode] });
                    //console.log($("#error-msg").attr("title"));
                    args.IsValid = false;
                }
            }
        }

        // on blur: validate
        input.addEventListener('blur', phonenumber);
        // on keyup / change flag: reset
        input.addEventListener('change', reset);
        input.addEventListener('keyup', reset);

    </script>
    <script>


        //    errorMsg = document.querySelector("#error-msg"),
        validMsg = document.querySelector("#valid-msg");
        var input = document.getElementById("<%=BillMobileText.ClientID%>");


        // here, the index maps to the error code returned from getValidationError - see readme
        var sessionValue = '<%= Session("lang") %>';
        if (sessionValue == "en") {
            var errorMap = ["Invalid number", "Invalid country code", "The entered number is shorter than allowed", "The number entered is longer than the tags", "Invalid number"];
        } else {
            var errorMap = ["رقم غير صحيح", "الرمز الدولي غير صحيح", "الرقم الذي تم إدخاله أقصر من المسموح به ", "الرقم الذي تم إدخاله أكبر  من المسموح به", "رقم غير صحيح"];
        }



        // initialise plugin
        var iti = window.intlTelInput(input, {
            utilsScript: "/Users/build/js/utils.js?1638200991544",

            nationalMode: false
        });

        var reset = function () {
            input.classList.remove("error");
            input2.classList.remove("error");
            //   errorMsg.innerHTML = "";
            // $("#error-msg").popover("hide");

            $("#valid-msg").popover("hide");
        };
        debugger;
        function phonenumber3(sender, args) {
            //reset();
            if (input.value.trim()) {
                if (iti.isValidNumber()) {
                    debugger
                    //$("#valid-msg").innerHTML = iti__selected - flag
                    //$("#valid-msg").popover("show");
                    args.IsValid = true;
                } else {
                    input.classList.add("error");
                    var errorCode = iti.getValidationError();

                    sender.innerHTML = errorMap[errorCode];
                    //$("#error-msg").attr("title", errorMap[errorCode]);
                    //$("#error-msg").popover({placement: 'right', content:  errorMap[errorCode] });
                    //console.log($("#error-msg").attr("title"));
                    args.IsValid = false;
                }
            }
        }

        // on blur: validate
        input.addEventListener('blur', phonenumber);
        // on keyup / change flag: reset
        input.addEventListener('change', reset);
        input.addEventListener('keyup', reset);

    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js" async defer></script>


        <script src="https://code.jquery.com/jquery.js" async defer></script>
    <script src="../jquery.js" async defer></script>
    <script src="../Assets/toastr.min.js" async defer></script>
    <script src="../Assets/script.js" async defer></script>
    <link href="../Assets/toastr.min.css" rel="stylesheet" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js" async defer></script>
        <script src="../Scripts/toastr.js" async defer></script>
           <script src="/js/respond.min.js" async defer></script>
    <script src="js/jaktutorial.js" async defer></script>
    <script src="js/html5shiv.js" async defer></script>
    <script src="js/bootstrap.js" async defer></script>
    <script src="js/jquery.js" async defer></script>
    <link href="CSS/bootstrap-theme.css" rel="stylesheet" media="all"/>
    <link href="CSS/bootstrap.css" rel="stylesheet" media="all"/>
    <link href="CSS/signin.css" rel="stylesheet" media="all"/>

    <script language="javascript" type="text/javascript">
        function checkAgreement(source, args) {
            var elem = document.getElementById("agree");
            if (elem.checked) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }

    </script>

</asp:Content>
