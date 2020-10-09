<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="ZenBear._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><td style="background-color:#002649;color:white;text-align:center" colspan="2">Login</td></tr>
            <tr><td style="text-align:right">Username</td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            <tr><td style="text-align:right">Password</td><td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ></asp:TextBox></td></tr>
            <tr><td colspan="2"><center><asp:Button ID="Button1" runat="server" Text="Login" width="200" Height="100" BackColor="Black" ForeColor="white" OnClick="Button1_Click"></asp:Button>
              <br />  <asp:Label ID="stat" runat="server" Text=""></asp:Label>
                                </center> </td></tr>

        </table>
    </form>
</body>
</html>
