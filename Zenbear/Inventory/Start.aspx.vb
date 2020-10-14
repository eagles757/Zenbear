Public Class Start
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If CType(Session("ZBUser"), UserClass).FirstName = "" Then
        '    Response.Redirect("../default.aspx")
        'End If
        Try
            If Session("INVITems") = Nothing Then
                Dim dt As New DataTable
                dt.Columns.Add("ItemNumber")
                dt.Columns.Add("ItemDesc")
                dt.Columns.Add("Count")

                Session("INVITems") = dt

            End If
        Catch ex As Exception
        End Try


        loadCategory()


    End Sub
    Protected Sub loadCategory()

        Dim qry = "select * from zenbear_Biz.ItemType order by itemtypeName"
        Dim ds As DataSet = gl.MySql_run(qry, "connstr")

        Dim tr As New HtmlTableRow
        Dim td As New HtmlTableCell
        Dim i = 0

        For Each a As DataRow In ds.Tables(0).Rows
            If i = 3 Then
                tb1.Controls.Add(tr)
                tr = New HtmlTableRow
                i = 0
            End If
            td = New HtmlTableCell

            Dim b As New LinkButton
            b.Text = a.Item(1)
            b.CssClass = "btn btn-primary ButtonC"
            b.ID = "CID_" & a.Item(0)
            AddHandler b.Click, AddressOf DoSomething

            td.Controls.Add(b)
            tr.Controls.Add(td)
            i += 1
        Next

    End Sub
    Protected Sub DoSomething(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As LinkButton = CType(sender, LinkButton)

        Response.Redirect("next.aspx?CID=" & b.ID.Replace("CID_", ""))

    End Sub
End Class