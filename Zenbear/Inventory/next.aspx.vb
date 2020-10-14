Public Class _next
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("CID") = "" Then
            Response.Redirect("Start.aspx")
        End If
        loadCategory()
    End Sub
    Protected Sub loadCategory()

        Dim qry = "select * from zenbear_Biz.Items where itemtypeid='" & Request.QueryString("CID") & "' order by itemName"
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
            b.Text = a.Item(2)
            b.CssClass = "btn btn-primary ButtonD"
            b.ID = a.Item(1) & "_" & a.Item(2)
            AddHandler b.Click, AddressOf DoSomething

            td.Controls.Add(b)
            tr.Controls.Add(td)
            i += 1
        Next

    End Sub
    Protected Sub DoSomething(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As LinkButton = CType(sender, LinkButton)

        'Response.Redirect("next.aspx?CID=" & b.ID.Replace("CID_", ""))
        'Request.QueryString("CID")
        Dim ss As String() = b.ID.Split("_")
        TextBox1.Text = ss(0)
        TextBox2.Text = ss(1)
        r_s("ItemInfoModal")


    End Sub
    Sub r_s(ByVal modal As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "Pop", "openModal(" & modal & ");", True)

    End Sub



    Sub save()
        Dim dt As DataTable = Session("INVITems")

        Dim dr As DataRow = dt.NewRow
        dr(0) = TextBox1.Text
        dr(1) = TextBox2.Text
        dr(2) = TextBox3.Text

        dt.Rows.Add(dr)

        Session("INVITems") = dt

        'maybe write it to table... lets see how this goes

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        save()
    End Sub
End Class