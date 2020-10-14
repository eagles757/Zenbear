<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Employee.Master" CodeBehind="next.aspx.vb" Inherits="ZenBear._next" %>

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
<h1>Please Select Item</h1><br />
    <table runat="server" id="tb1" style="width:100%">

        
    </table>



    
<!-- Modal -->
<div class="modal fade" id="ItemInfoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Employee Info</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <table style="width:100%;" border="1" borderColor="blue">
           <tr><td style="text-align:right;padding-right:5px;">ItemID:</td><td><asp:TextBox ID="TextBox1" runat="server" Text="" Enabled="false"></asp:TextBox></td></tr>
           <tr><td style="text-align:right;padding-right:5px;">Item Name:</td><td><asp:TextBox ID="TextBox2" runat="server" Text="" Enabled="false"></asp:TextBox></td></tr>
           <tr><td style="text-align:right;padding-right:5px;">Count:</td><td><asp:TextBox ID="TextBox3" runat="server" Text="" TextMode="Number" ></asp:TextBox></td></tr>
           <tr><td colspan="2"><asp:Button ID="Button1" runat="server" Text="Add Count to List" OnClick="Button1_Click" /></td></tr>
           </table>
      </div>
    </div>
  </div>
</div>


</asp:Content>
