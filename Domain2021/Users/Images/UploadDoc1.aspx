<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="UploadDoc.aspx.vb" Inherits="Domain2021.UploadDoc" ViewStateEncryptionMode="Always" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Upload.css" rel="stylesheet" type="text/css" media="all" />
    <script src="Upload.js"></script>
    <link href="../Content/toastr.css" rel="stylesheet" media="all" />
    <style>
        input[type="file"]::file-selector-button {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: 1px solid transparent;
            border-top-color: transparent;
            border-right-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            border-radius: .25rem;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }

        input[type="file"]::-ms-browse:hover {
            background-color: #81ecec;
            border: 2px solid #00cec9;
        }

        input[type="file"]::-webkit-file-upload-button:hover {
            background-color: #81ecec;
            border: 2px solid #00cec9;
        }

        input[type="file"]::file-selector-button:hover {
            background-color: #81ecec;
            border: 2px solid #00cec9;
        }
    </style>

    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div id="fs" runat="server">
        <form id="form1" action="UploadDoc.aspx?folder=<%= "..\DOC" %>" method="POST" enctype="application/x-www-form-urlencoded" >
               <center><asp:Label ID="RegistrationPrompt"  CssClass="alert alert-info" runat="server" Visible="false"></asp:Label>   <br /><br />  <br /><br />    </center>

            <fieldset id="fs1" runat="server">
                <% IIf((Session("lang") = "ar"), "فقط pdf JPG GIF bmp/تحميل الأوراق الثبوتية", "Upload Official documents\only pdf,jpg,gif,bmp") %>
                <center>
                    <legend style="color: #333; font-size: large"><%= IIf((Session("lang") = "ar"), "فقط pdf JPG GIF bmp/تحميل الأوراق الثبوتية", "Upload Official documents\only pdf,jpg,gif,bmp") %>  <%=IIf(Request.QueryString("folder") = "", "", " for '" & Request.QueryString("folder") & "'")%></legend>
                </center>


                <div class="row">
                    <div class="col-lg-2 col-md-2"></div>
                    <div class="col-lg-8 col-md-8">

                        <ul class="nav nav-tabs justify-content-center" role="tablist" dir="rtl" id="nav" runat="server">
                            <li class="nav-item home">
                                <a data-toggle="tab" class="nav-link" href="#DomainInfo" id="DomainInfotab" runat="server" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold; cursor: none; color: #a5a5a5">
                                    <i class="fa fa-info-circle" style="padding-left: 10px"></i>معلومات النطاق
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" id="Servertab" runat="server" href="#ServerP" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold; cursor: none; color: #a5a5a5">
                                    <i class="fa fa-server" style="padding-left: 10px"></i>اسماء الخوادم
                                </a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#ContactInfo" id="ContactInfotab" runat="server" role="tab" dir="rtl" style="font-family: cairo; font-weight: bold; cursor: none; color: #a5a5a5">
                                    <i class="fa fa-info" style="padding-left: 10px"></i>معلومات الإتصال
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#DocumentInfo" role="tab" dir="rtl" id="Documenttab" runat="server" style="font-family: cairo; font-weight: bold; color: #007bff">
                                    <i class="fa fa-file" style="padding-left: 10px"></i>رفع الوثائق
                                </a>
                            </li>
                        </ul>
                        <div class="card-body">

                            <div class="tab-content text-center">
                                <asp:panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="DocumentInfo" role="tabpanel">
                                    <center>
                                        <input type="file" id="file1"  name="file1" multiple="multiple" dir="<%= IIf((Session("lang") = "ar"), "rtl", "ltr") %>" value="<%= IIf((Session("lang") = "ar"), "فقط pdf JPG GIF bmp/تحميل الأوراق الثبوتية", "Upload Official documents\only pdf,jpg,gif,bmp") %>"  accept=".pdf,.png,.jpeg,.bmp" /><br />
                                   
                                        <center>
                                                    <asp:Button ID="finish" Visible="false" CssClass="btn btn-success" Text="FinishUpload" runat="server" />

                                        <div id="divStatus"></div>
                                    </center>
                                    <br />
                                    <center>
                                        <asp:GridView runat="server" HeaderStyle-HorizontalAlign="Center" DataKeyNames="id" ID="docgrid" AutoGenerateColumns="False" DataSourceID="documents" CssClass="table table-responsive">
                                            <columns>
                                                <asp:TemplateField>
                                                    <itemtemplate>
                                                        <asp:HyperLink ID="files" Text='<%#Eval("file_POST_name") %>' runat="server" NavigateUrl='<%# "../DOC/" + Eval("file_POST_name") %>' Target="_blank"></asp:HyperLink>
                                                    </itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="file_POST_name" HeaderText="file_POST_name" SortExpression="file_POST_name" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="file_POST_name" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-Width="0px" ItemStyle-BorderStyle="None"></asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
                                                        <asp:LinkButton ID="Del" CommandArgument='<%# Eval("id") %>' CommandName="Delete" runat="server"><i class="fa fa-trash" style="color: red"></i></asp:LinkButton>
                                                    </itemtemplate>
                                                </asp:TemplateField>
                                            </columns>
                                        </asp:GridView>
                                    </center>
                                    <asp:SqlDataSource runat="server" DeleteCommand="deletedoc" DeleteCommandType="StoredProcedure" ID="documents" ConnectionString='<%$ ConnectionStrings:NewDNS %>' SelectCommand="selectdoc" SelectCommandType="StoredProcedure">
                                        <selectparameters>
                                            <asp:SessionParameter SessionField="DID" Name="did" Type="Int32"></asp:SessionParameter>
                                        </selectparameters>
                                        <deleteparameters>
                                            <asp:Parameter Name="id" Type="Int32" />
                                        </deleteparameters>
                                    </asp:SqlDataSource>


                                    <%	If Request.Browser.IsBrowser("InternetExplorer") = False OrElse CInt(Request.Browser.Version) > 10 Then%>

                                    <div id="divDropHere" style="height: 200px">
                                        <br />
                                        <br />
                                        <br />
                                        or drop files here
                                    </div>

                                    <%	End If%>
                                </asp:panel>
                            </div>
                        </div>
                    </div>

                    <div id="btnUpload">
                        <button type="submit">Upload Files</button>
                    </div>
                    <div class="col-lg-2 col-md-2"></div>
                </div>
            </fieldset>


            <input type="hidden" name="hdnFolder" value="<%=IIf("../DOC" = "", "", " for '" & "../DOC" & "'")%>">
              </form>
       
    </div>

     <div id="divagree" runat="server">
                <br />
                <asp:CheckBox ID="agree" ClientIDMode="Static" runat="server" />
                <p></p>
                <asp:CustomValidator ID="ckboxvalidator" ForeColor="Red" SetFocusOnError="true" ValidationGroup="doc" Visible="true" ClientValidationFunction="checkAgreement" runat="server" EnableClientScript="true" ErrorMessage="CustomValidator"></asp:CustomValidator>

                <br />
                <center>
                    <asp:Button ID="FinishRegistrationB" runat="server" CssClass="btn btn-success" Visible="false" ValidationGroup="doc" ></asp:Button>
                    <br />
                </center>

            </div>
                 
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
