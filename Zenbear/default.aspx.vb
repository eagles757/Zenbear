Public Class _default
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsCallback And Not IsPostBack Then
            Session.Clear()

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim un = TextBox1.Text
        Dim pw = gl.GetHash(TextBox2.Text)


        Response.Write("PW: " & pw)
        Dim qry = "select  a.*,b.AAID,b.AA_3 from zenbear_Biz.Employee as a
left join zenbear_Biz.AA as b on b.aaid=a.EmployeeID   where a.un='" & un & "' and b.AA_3='" & pw & "'"

        Dim go = False
        Dim ds As DataSet = gl.MySql_run(qry, "connstr")
        Dim uid As String = ""
        For Each a As DataRow In ds.Tables(0).Rows
            go = True
            uid = a.Item(0)
        Next
        If go = False Then
            stat.Text = "Incorrect Username or Password. "

        Else
            Dim zbu As New UserClass
            zbu.getUser(uid)
            Session("ZBUser") = zbu
            Response.Redirect("landing.aspx")
        End If
    End Sub
End Class