<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Employee.Master" CodeBehind="Inventory.aspx.vb" Inherits="ZenBear.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Add To Inventory" class="btn btn-primary" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Current Inventory" class="btn btn-primary" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <br /><br />
    <%--ADD--%>
    <table runat="server" id="addInv" style="width:100%;" visible="false">
        <tr><td>Select Category: <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td></tr>
        <tr><td>
            <table style="width:100%" id="invItemT" runat="server">
                <tr><td>Select the Item</td></tr>
                <tr><td>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </td></tr>
            </table>
            </td></tr>
        <tr><td> <asp:Button ID="Button3" runat="server" Text="Print Inventory" class="btn btn-primary"  OnClientClick="javascript:window.print();"/></td></tr>
    </table>





</asp:Content>
