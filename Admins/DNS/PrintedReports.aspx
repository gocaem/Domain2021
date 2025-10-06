<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintedReports.aspx.vb" Inherits="Domain2021.PrintedReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Of Transactions</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server"><div>
       <table align="center" cellpadding="0" class="auto-style1">
            <tr>
                <td colspan="2" align="center">
                    <img alt=""  src="../app-assets/3MODEE-news-0.jpg" style="text-align: center;" /><hr style="color:#cccccc" /><asp:Label ID="Label1" runat="server" Text='<%# Now.ToString("dd/MM/yyyy") %>'></asp:Label></td>
              </tr><tr><asp:Label ID="Amount" ForeColor="Red" Font-Bold="true" runat="server" ></asp:Label>
                  
           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </tr>
           </table>
        </div>
    </form>
</body>
</html>
