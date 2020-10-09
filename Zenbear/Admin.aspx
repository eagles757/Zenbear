<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Employee.Master" CodeBehind="Admin.aspx.vb" Inherits="ZenBear.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr><td colspan="2"><center><h3><b><i>Employee Management</i></b></h3></center></td></tr>
        <tr><td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td><td>
            <asp:Button ID="Button1" runat="server" Text="Add Employee" OnClick="Button1_Click" /></td></tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td>
            <table runat="server" id="employeetb" visible="false">
              <tr><td>EmployeeID</td><td><asp:TextBox ID="TextBox1" runat="server" Enabled="false" ></asp:TextBox></td></tr>
                  <tr><td>FirstName</td><td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
                  <tr><td>LastName</td><td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
                  <tr><td>Address</td><td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td></tr>
                  <tr><td>City</td><td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td></tr>
                  <tr><td>State</td><td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td></tr>
                  <tr><td>Zip</td><td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td></tr>
                  <tr><td>PhoneNumber</td><td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td></tr>
                  <tr><td>Email</td><td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td></tr>
                  <tr><td>UN</td><td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td></tr>
                  <tr><td>Admin</td><td><asp:CheckBox ID="CheckBox1" runat="server" Visible="false" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                      <asp:Label ID="ADmstat" runat="server" Text=""></asp:Label>

                                    </td></tr>
                  <tr><td colspan="2"><asp:Button ID="Button2" runat="server" Text="Save Changes" OnClick="Button2_Click" /></td></tr>
                <tr><td colspan="2">
                    <asp:Label ID="stat" runat="server" Text=""></asp:Label></td></tr>
            </table>
            </td></tr>
    </table>


</asp:Content>
