<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Employee.Master" CodeBehind="Final.aspx.vb" Inherits="ZenBear.Final" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table style="width:100%;" class="jay ">
            <tr><td style="background-color:White" colspan="2"><center><h2>Inventory</h2></center></td></tr>
        <tr>
            <td><a href ="Start.aspx">Department Page</a></td>
            <td><a href ="Final.aspx">Check-In Page</a></td>
        </tr>
    </table>
        </center>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField HeaderText="Item ID" DataField="ItemNumber" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemDesc"  />
            <asp:BoundField HeaderText="Count" DataField="Count"  />
        </Columns>


    </asp:GridView>
    <center><asp:Button ID="Button1" runat="server" Text="Save Inventory" width="400px" Height="200px" OnClick="Button1_Click" /></center>

    <center><asp:Label ID="SaveStat" runat="server" Text="" Font-Size="Larger" Font-Bold="true" ></asp:Label></center>
</asp:Content>
