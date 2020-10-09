Public Class Admin
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main
    Dim ZBUser As UserClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsCallback And Not IsPostBack Then
            load_employees
        End If
        ZBUser = Session("ZBUser")
        Try
            If UCase(ZBUser.Admin) <> "Y" Then
                Response.Redirect("landing.aspx")
            End If

        Catch ex As Exception
            Response.Redirect("landing.aspx")
        End Try

    End Sub

    Sub load_employees()
        Dim qry = "SELECT employeeid,
un,firstname, lastname
 FROM zenbear_Biz.Employee order by un"
        Dim ds As DataSet = gl.MySql_run(qry, "connstr")
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("------------------")
        For Each a As DataRow In ds.Tables(0).Rows
            DropDownList1.Items.Add(New ListItem(a.Item(1) & " - " & a.Item(2) & " " & a.Item(3), a.Item(0)))
        Next
    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        CheckBox1.Checked = False
        If DropDownList1.SelectedIndex = 0 Then
            employeetb.Visible = False
            CheckBox1.Visible = False
            ADmstat.Visible = False
        Else
            Dim aa As New UserClass
            aa.getUser(DropDownList1.SelectedValue)
            TextBox1.Text = aa.EmployeeID
            TextBox2.Text = aa.FirstName
            TextBox3.Text = aa.LastName
            TextBox4.Text = aa.Address
            TextBox5.Text = aa.City
            TextBox6.Text = aa.State
            TextBox7.Text = aa.Zip
            TextBox8.Text = aa.PhoneNumber
            TextBox9.Text = aa.Email
            TextBox10.Text = aa.UN

            If aa.Admin = "Y" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If


            CheckBox1.Visible = True
            employeetb.Visible = True
            ADmstat.Visible = True
        End If


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Dim verb = "S"
        If TextBox1.Text <> "" Then
            verb = "U"
        End If
        Dim aa As New UserClass

        aa.EmployeeID = TextBox1.Text
        aa.FirstName = TextBox2.Text
        aa.LastName = TextBox3.Text
        aa.Address = TextBox4.Text
        aa.City = TextBox5.Text
        aa.State = TextBox6.Text
        aa.Zip = TextBox7.Text
        aa.PhoneNumber = TextBox8.Text
        aa.Email = TextBox9.Text
        aa.UN = TextBox10.Text

        Dim adm = "Y"
        If CheckBox1.Checked = False Then adm = "N"
        aa.Admin = adm



        Dim dd1 As String = aa.saveUser(verb)

        If dd1.IndexOf("ERROR") > -1 Then
            stat.Text = "ERROR: " & dd1
        Else
            stat.Text = "Save/Update successful."
        End If


        clearTB()

    End Sub
    Sub clearTB()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        ADmstat.Text = ""
        stat.Text = ""
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        DropDownList1.SelectedIndex = 0
        clearTB()
        'employeetb add employee
        employeetb.Visible = True
        TextBox1.Enabled = False
        CheckBox1.Visible = False
        ADmstat.Visible = False
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        Dim adm = "Y"
        If CheckBox1.Checked = False Then adm = "N"

        Dim qry = "update zenbear_Biz.AD set admin = '" & adm & "' where AAID='" & TextBox1.Text & "'"

        Dim dd As String = gl.mysql_update(qry, "connstr")

        If dd.IndexOf("ERROR") > -1 Then
            ADmstat.Text = "Error updating Admin stat"
        Else
            ADmstat.Text = "Admin status updated."
        End If



    End Sub
End Class