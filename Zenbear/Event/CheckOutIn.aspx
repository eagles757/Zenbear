<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Employee.Master" CodeBehind="CheckOutIn.aspx.vb" Inherits="ZenBear.CheckOutIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%">
        <tr><td>
            <asp:RadioButtonList runat="server">
                <asp:ListItem>Check Out</asp:ListItem>
                <asp:ListItem>Check In</asp:ListItem>
            </asp:RadioButtonList>
            </td></tr>

        <tr><td>
            <asp:DropDownList runat="server"></asp:DropDownList>
            </td>
            <td>Qty: <asp:TextBox runat="server"></asp:TextBox></td>
            <td>
                <asp:Button runat="server" Text="Add to List" />
            </td>
        </tr>
        <tr><td colspan="3">
            <asp:GridView runat="server"></asp:GridView>
            </td></tr>

    </table>

    



</asp:Content>
