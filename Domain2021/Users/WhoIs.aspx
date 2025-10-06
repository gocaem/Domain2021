<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Users/MasterPage_Ar.Master" CodeBehind="WhoIs.aspx.vb" Inherits="Domain2021.WhoIs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />    <br /><br /><br />    <br /><br /><br />
     <table id="tabel1" runat="server" border="0" style="width: 100%; font-family: Calibri;font-weight:bold" align="center;">
        <tr>
            <td id="td1" align="center">
<div class="card border-warning mb-3" style="max-width: 70rem;">
  <div class="card-header">WhoIs</div>
  <div class="card-body">
    <h5 class="card-title" id="DomainName" runat="Server" style="font-weight:bold"></h5><br />
    <p class="card-text"><div id="search-box" style="width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="container search-box" style="width:70%">
         
                    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="ResultsUpdatePanel" runat="server">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../Spinner.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server" UpdateMode="Always">
                        <ContentTemplate>
<form action="#" id="search-box_search_form_3" class="search-box_search_form d-flex flex-lg-row flex-column align-items-center justify-content-between ">
<div class="d-flex flex-row align-items-center justify-content-start inline-block"  style="width:100%">
<span class="large material-icons search">search</span>
<asp:TextBox ID="DomainNameText" runat="server"  CssClass="search-box_search_input" required="required" type="search" style="font-family:cairo;color:black"></asp:TextBox>
 
<asp:DropDownList CssClass="dropdown_item_select search-box_search_input" ID="ddl" runat="server" DataTextField="SECOND_DOMAIN" DataValueField="SECOND_DOMAIN_ID" DataSourceID="SqlDataSource1">
</asp:DropDownList>

<asp:Button Text="WhoIs" ID="b1" Font-Names="Calibri" runat="server"   CssClass="fa fa-search font-color-white search-box_search_button" ValidationGroup="A" ></asp:Button>
</div>    <div class="d-flex flex-row align-items-center justify-content-start inline-block center"  style="width:100%;text-align:center">
   <asp:GridView ID="WhoIs" Font-Names="cairo"  AutoGenerateColumns="false" runat="server" CssClass="table table-responsive" Width="100%">
        <Columns>
            <asp:BoundField DataField="Domain_id"  />
            <asp:TemplateField HeaderText="اسم النطاق" ItemStyle-Width="490px">
                <ItemTemplate>
                    <asp:LinkButton id="link" runat="server" CommandName="det" Text='<%# Eval("DomainName") %>' CommandArgument='<%# Eval("Domain_ID") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="ORG_NAME" HeaderText="الجهة المستخدمة" ItemStyle-Width="390px"/>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Result" Font-Bold="true" Font-Names="cairo" Font-Size="Medium" runat="server" Width="100%" ForeColor="Green" ></asp:Label>
</div>    
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NewDNS %>"
                                                        SelectCommand="second_domain_data" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="DomainNameText" style="text-align:right;font-family:cairo" Font-Size="Small" Font-Bold="true"  runat="server" ErrorMessage="حقل ضروري" ForeColor="red" ValidationGroup="A"></asp:RequiredFieldValidator>     

</div>
</div>  <section id="Job-Category" style="text-align:center"><div class="auto-style1">

   </div></section>
    
</form>  </ContentTemplate>
                  
                    </asp:UpdatePanel>
    <br /><br /><br />



</div></div></p>
  </div>
</div>
    
                </td></tr></table>
</asp:Content>
