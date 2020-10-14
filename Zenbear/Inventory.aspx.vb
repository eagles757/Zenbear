Public Class Inventory
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim b As Button = CType(sender, Button)
        Select Case b.ID
            Case "Button1"
                Response.Redirect("inventory/start.aspx")

            Case "Button2"
                addInv.Visible = False
                Dim iv As New CurrentInventory
                GridView1.DataSource = iv.ds.Tables(0)
                GridView1.DataBind()
                addInv.Visible = True

        End Select

    End Sub
    Sub load_itemTypeList()
        Dim qry = "select * from zenbear_Biz.ItemType order by itemtypeName"
        Dim ds As DataSet = gl.MySql_run(qry, "connstr")

        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("-----------------")
        For Each a As DataRow In ds.Tables(0).Rows
            DropDownList1.Items.Add(New ListItem(a.Item(1), a.Item(0)))
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
End Class