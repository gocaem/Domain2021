<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="UploadDoc.aspx.vb" Inherits="Domain2021.UploadDoc" ViewStateEncryptionMode="Always" %>

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
    color:aliceblue;
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
    font-size:small;
    text-align:center;
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
    border-radius:3px;
    font-size:small;
}

.ajax_fileupload_cancelbutton {
  display:none;
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
    font-family:Calibri;
    font-size:small;
}

.ajax__fileupload_fileItemInfo .filename {
    font-weight: normal;
    font-family:Calibri;
    font-size:small;
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
  display:none;
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
                            <asp:Panel CssClass="tab-pane active" runat="server" ClientIDMode="Static" ID="DocumentInfo" role="tabpanel">
                                <center>

                                   <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" Padding-Bottom="4"
        Padding-Left="2" Padding-Right="1" Padding-Top="4" ThrobberID="myThrobber" OnUploadComplete="OnUploadComplete"
      MaximumNumberOfFiles="10"
                                   
        AllowedFileTypes="jpg,jpeg,png,bmp,gif,pdf" 
        MaxFileSize="20480"/>

    <div id="uploadCompleteInfo"></div>       <center>
        
                                      
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
                               <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imags/refresh.png" Width="50px"   />
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                </div>


                <div class="col-lg-2 col-md-2">
                  </div>
            </div>
           
        </fieldset>


        <input type="hidden" name="hdnFolder" value="<%=IIf("../DOC" = "", "", " for '" & "../DOC" & "'")%>"> 
        
        <div id="divagree" runat="server">
        <br />
        &nbsp; &nbsp;  &nbsp; <asp:CheckBox ID="agree" ClientIDMode="Static" runat="server" />
        <p></p>
         &nbsp; &nbsp;  &nbsp;  <asp:CustomValidator ID="ckboxvalidator" ForeColor="Red" SetFocusOnError="true" ValidationGroup="doc" Visible="true" ClientValidationFunction="checkAgreement" runat="server" EnableClientScript="true" ErrorMessage="CustomValidator"></asp:CustomValidator>

        <br />
        <center>
           <asp:Button ID="FinishRegistrationB" runat="server" CssClass="btn btn-success" Visible="false" ValidationGroup="doc"></asp:Button>
            <br />
        </center>

    </div>
    </div>

    
    <center>
        <asp:Label ID="RegistrationPrompt" CssClass="alert alert-info" runat="server" Visible="false"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    </center>
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
