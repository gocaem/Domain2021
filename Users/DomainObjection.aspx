<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="DomainObjection.aspx.vb" Inherits="Domain2021.DomainObjection" ViewStateEncryptionMode="Always" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .ajax__fileupload {
            border: #D3D3D3 1px solid;
            overflow: auto;
            padding: 4px;
        }

        .ajax__fileupload_selectFileContainer {
            display: inline-block;
            height: 24px;
            line-height: 24px;
            overflow: hidden;
            position: relative;
            width: 80px;
        }

        .ajax__fileupload_selectFileButton {
            background-color: rgb(127, 126, 126);
            color: aliceblue;
            cursor: pointer;
            display: block;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
            margin-right: 4px;
            text-align: center;
            width: 80px;
        }

            .ajax__fileupload_selectFileButton:hover {
                background-color: #000000;
                color: #ffffff;
            }

        .ajax__fileupload_topFileStatus {
            color: rgb(127, 126, 126);
            font-size: small;
            text-align: center;
        }

        .ajax__fileupload_ProgressBarHolder {
            margin-right: 70px;
        }

        .ajax__fileupload_uploadbutton {
            background-color: #28285e;
            color: white;
            cursor: pointer;
            font-weight: normal;
            text-align: center;
            width: 70px;
            border-radius: 3px;
            font-size: small;
        }

        .ajax_fileupload_cancelbutton {
            display: none;
        }

        .ajax__fileupload_dropzone {
            border-style: dotted;
            border-width: 1px;
            line-height: 50px;
            margin-bottom: 2px;
            text-align: center;
        }

        .ajax__fileupload_queueContainer {
            border: #A9A9A9 1px solid;
            border-width: 1px;
            clear: both;
            margin-top: 2px;
            padding: 4px;
        }

        .ajax__fileupload_progressBar {
            background-color: #CCFFCC;
            padding-left: 4px;
        }

        .ajax__fileupload_footer {
            height: 20px;
            line-height: 20px;
            margin-top: 2px;
        }

        .ajax__fileupload_fileItemInfo {
            height: 20px;
            line-height: 20px;
            margin-bottom: 2px;
            overflow: hidden;
            position: relative;
            z-index: 0;
            font-weight: normal;
            font-family: Calibri;
            font-size: small;
        }

            .ajax__fileupload_fileItemInfo .filename {
                font-weight: normal;
                font-family: Calibri;
                font-size: small;
            }

            .ajax__fileupload_fileItemInfo .uploadstatus {
                font-style: italic;
            }

            .ajax__fileupload_fileItemInfo .removeButton {
                background-color: #F44336;
                border: 1px solid #F44336;
                color: #ffffff;
                text-align: center;
                text-decoration: none;
                font-size: 10px;
            }

            .ajax__fileupload_fileItemInfo .uploadedState {
                background-color: #fff;
                color: #060;
            }

            .ajax__fileupload_fileItemInfo .uploadingState {
                background-color: #fff;
                color: #FF9900;
            }

            .ajax__fileupload_fileItemInfo .pendingState {
                background-color: #fff;
                color: #009;
            }

            .ajax__fileupload_fileItemInfo .errorState {
                background-color: #ff0000;
                color: #ffffff;
            }

            .ajax__fileupload_fileItemInfo .cancelledState {
                display: none;
            }

        .ajax__fileupload_selectFileContainer input {
            border: medium none;
            cursor: pointer;
            height: 40px;
            margin: 0;
            opacity: 0;
            position: absolute;
            right: 0;
            top: 0;
        }


        .ajax__fileupload_fileItemInfo div.removeButton {
            position: absolute;
            right: 0;
            top: 0;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="../Content/toastr.css" rel="stylesheet" media="all" />
    <br />
    <br />
    <br />
    <br />
    <center>
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
                <fieldset id="fs1" runat="server">

                    <div class="container mt-5" dir="rtl" id="container" runat="server">
                   
                        <div class="row">
                            <div class="col-md-12 ml-auto col-xl-12 mr-auto">
                                <br />

                                <center>
                                         <asp:Label ID="Result" CssClass="alert alert-info" runat="server" Visible="false"></asp:Label></center><br />
                                <br />
                                <br />
                                    <div class="card" id="tabs" runat="server">
                                        <div class="card-header">
                                            <ul class="nav nav-tabs justify-content-center" role="tablist" dir="rtl" id="nav" runat="server">
                                                <li class="nav-item home" enableviewstate="false">
                                                    <a data-toggle="tab" class="nav-link active" href="#DomainInfo" id="DomainInfotab" runat="server" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold">
                                                        <i class="fa fa-hand-stop-o" style="padding-left: 10px"></i>تقديم الإعتراض
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

                                                        <div class="col-lg-6 col-md-6" id="Div2" runat="server">
                                                            <div class="form-group">

                                                                <asp:Label ID="DomainLabel" runat="server" Font-Bold="True"></asp:Label></label>
                                                <asp:DropDownList AppendDataBoundItems="true" CssClass="form-control" ID="DomainName" Enabled="true" runat="server" Width="300px">
                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator InitialValue="0" ForeColor="Red" Font-Bold="false" ID="RequiredFieldValidator1" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="DomainName"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">

                                                        <div class="col-lg-6 col-md-6" id="Div4" runat="server">
                                                            <div class="form-group">
                                                                <asp:Label ID="ObjectionText" runat="server" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="Objection" runat="server" TextMode="MultiLine" AutoPostBack="true" CausesValidation="true" ValidationGroup="A"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="false" ID="RequiredFieldValidator2" SetFocusOnError="true" ValidationGroup="A" runat="server" ControlToValidate="Objection"></asp:RequiredFieldValidator>

                                                            </div>
                                                            <asp:GridView ID="GridView2" OnRowCommand="GridView2_RowCommand" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" Font-Bold="false">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label64" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="domainname" HeaderText="domainname" SortExpression="domainname"></asp:BoundField>
                                                                    <asp:BoundField DataField="Domain_id" HeaderText="Domain_id" SortExpression="Domain_id" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:BoundField DataField="admin_id" HeaderText="admin_id" SortExpression="admin_id" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="im" runat="server" ImageUrl="~/Admins/DNS/download.png" Width="20px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="im2" runat="server" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Admins/DNS/paper.png" Width="20px" CommandName="paper" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%# ReusableCode.Decrypt(ConfigurationManager.ConnectionStrings("NEWDNS").ConnectionString) %>' SelectCommand="SelectObjectionforUser" SelectCommandType="StoredProcedure">
                                                                <SelectParameters>
                                                                    <asp:SessionParameter SessionField="User_ID" Name="admin" Type="Int32"></asp:SessionParameter>
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>

                                                        </div>
                                                        <br />
                                                    </div>
                                                    <div class="row">
                                                        <center>

                                                            <asp:GridView runat="server" HeaderStyle-HorizontalAlign="Center" DataKeyNames="id" ID="docgrid" AutoGenerateColumns="False" DataSourceID="documents" CssClass="table table-responsive" Font-Bold="false">
                                                                <columns>
                                                                    <asp:TemplateField>
                                                                        <itemtemplate>
                                                                            <asp:HyperLink ID="files" Text='<%#Eval("SupportedDoc") %>' runat="server" NavigateUrl='<%# "../SupportDOC/" + Eval("SupportedDoc") %>' Target="_blank" style="font-weight: normal"></asp:HyperLink>
                                                                        </itemtemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="SupportedDoc" HeaderText="SupportedDoc" SortExpression="SupportedDoc" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="SupportedDoc" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>

                                                                </columns>
                                                            </asp:GridView>
                                                        </center>
                                                        <asp:SqlDataSource runat="server" ID="documents" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="selectObjection_SupportedDoc" SelectCommandType="StoredProcedure">
                                                            <SelectParameters>
                                                                <asp:SessionParameter SessionField="id" Name="id" Type="Int32"></asp:SessionParameter>
                                                            </SelectParameters>

                                                        </asp:SqlDataSource>
                                                    </div>


                                                    <asp:Button ID="NextStep1" OnClick="NextStep1_Click" runat="server" Text="Button" CssClass="btn btn-success" ValidationGroup="A" />
                                                </asp:Panel>
                                                <asp:Panel CssClass="tab-pane" ID="DocumentInfo" role="tabpanel" ClientIDMode="Static" runat="server">
                                                    <asp:Panel ID="DocumentPanel" runat="server">
                                                        <asp:UpdatePanel ID="up11" runat="server">
                                                            <ContentTemplate>
                                                                <div class="card-body">

                                                                    <div class="tab-content text-center">
                                                                        <asp:Panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="Panel3" role="tabpanel">
                                                                            <center>


                                                                                <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" Padding-Bottom="4"
                                                                                    Padding-Left="2" Padding-Right="1" Padding-Top="4" ThrobberID="myThrobber" OnUploadComplete="OnUploadComplete"
                                                                                    MaximumNumberOfFiles="10"
                                                                                    AllowedFileTypes="jpg,jpeg,png,bmp,gif,
                                                                                    
                                                                                    
                                                                                    "
                                                                                    MaxFileSize="1024" />

                                                                                <div id="uploadCompleteInfo"></div>
                                                                                <center>

                                                                                    <input type="hidden" name="hdnFolder" value="<%=IIf("../SupportDOC" = "", "", " for '" & "../SupportDOC" & "'")%>">
                                                                                    <div id="divStatus"></div>
                                                                                </center>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </div>
                                                                </div>
                            <p>
                                <asp:LinkButton ID="PrevLast" OnClick="PrevLast_Click" runat="server" CssClass="btn btn-dark"></asp:LinkButton>
                                <asp:LinkButton ID="FinishRegistration" OnClick="FinishRegistration_Click" runat="server" CssClass="btn btn-success" ValidationGroup="doc"></asp:LinkButton>
                                                            </ContentTemplate>

                                                        </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </asp:Panel>

                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </ContentTemplate>

        </asp:UpdatePanel>
    </center>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js" async defer></script>


    <script src="https://code.jquery.com/jquery.js" async defer></script>
    <script src="../jquery.js" async defer></script>
    <script src="../Assets/toastr.min.js" async defer></script>
    <script src="../Assets/script.js" async defer></script>
    <link href="../Assets/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script src="../Scripts/toastr.js" async defer></script>
    <script src="/js/respond.min.js" async defer></script>
    <script src="js/jaktutorial.js" async defer></script>
    <script src="js/html5shiv.js" async defer></script>
    <script src="js/bootstrap.js" async defer></script>
    <script src="js/jquery.js" async defer></script>
    <link href="CSS/bootstrap-theme.css" rel="stylesheet" media="all" />
    <link href="CSS/bootstrap.css" rel="stylesheet" media="all" />
    <link href="CSS/signin.css" rel="stylesheet" media="all" />

</asp:Content>
