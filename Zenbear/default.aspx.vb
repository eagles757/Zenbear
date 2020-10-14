
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
        Dim reset = "N"

        'Response.Write("PW: " & pw)
        Dim qry = "select  a.*,b.AAID,b.AA_3,b.reset from zenbear_Biz.Employee as a
left join zenbear_Biz.AA as b on b.aaid=a.EmployeeID   where a.un='" & un & "' and b.AA_3='" & pw & "'"

        Dim go = False
        Dim ds As DataSet = gl.MySql_run(qry, "connstr")
        Dim uid As String = ""
        For Each a As DataRow In ds.Tables(0).Rows
            go = True
            uid = a.Item(0)
            reset = UCase(gl.ct(a.Item(12)))
            uidL.Text = uid
        Next
        If go = False Then
            stat.Text = "Incorrect Username or Password. "
        ElseIf reset = "Y" Then
            t1.Visible = False
            tb1.Visible = True
        Else
            Dim zbu As New UserClass
            zbu.getUser(uid)
            Session("ZBUser") = zbu
            Response.Redirect("landing.aspx")
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        If TextBox3.Text <> TextBox4.Text Then
            cPWstat.Text = "Password do not match!"
        Else
            Dim pwhash = gl.GetHash(TextBox4.Text)

            'check the old password
            Dim qry = "select * from zenbear_Biz.AA where AAID='" & uidL.Text & "' and AA_3='" & pwhash & "' and (EndDate is null or EndDate < '1-1-2000')"
            'write the new
            Dim found = False
            Dim ds As DataSet = gl.MySql_run(qry, "connstr")
            For Each a As DataRow In ds.Tables(0).Rows
                found = True
            Next

            If found = True Then
                cPWstat.Text = "Please use a different password."
            Else

                qry = "update zenbear_Biz.AA set  AA_3='" & pwhash & "',Reset='N' where AAID='" & uidL.Text & "'"

                Dim dd As String = gl.mysql_update(qry, "connstr")

                If dd.IndexOf("ERROR") > -1 Then
                    cPWstat.Text = "Error: " & dd
                Else
                    cPWstat.Text = "Password updated! Redirecting in 5 seconds."
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "redirectJS", "setTimeout(function() { window.location.replace('default.aspx') }, 5000);", True)
                End If
            End If

        End If






    End Sub
End Class