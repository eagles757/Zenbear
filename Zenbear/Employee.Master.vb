Public Class Employee
    Inherits System.Web.UI.MasterPage
    Dim ZBUser As UserClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                If Session("ZBUser") = Nothing Then
                    Response.Redirect("Default.aspx")
                End If
            Catch ex As Exception
                Try
                    If Session("ZBUser").UN = "" Then Response.Redirect("Default.aspx")
                Catch ex2 As Exception
                    Response.Redirect("Default.aspx")
                End Try


            End Try

            ZBUser = Session("ZBUser")
            Label1.Text = ZBUser.EmployeeID
            Label2.Text = ZBUser.FirstName
            Label3.Text = ZBUser.LastName
            Label4.Text = ZBUser.Address
            Label5.Text = ZBUser.City
            Label6.Text = ZBUser.State
            Label7.Text = ZBUser.Zip
            Label8.Text = ZBUser.PhoneNumber
            Label9.Text = ZBUser.Email
            Label10.Text = ZBUser.UN
            Label11.Text = ZBUser.CurrentJob
            If ZBUser.Admin = "Y" Then
                Button1.Visible = True
            Else
                Button1.Visible = False
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Response.Redirect("admin.aspx")
    End Sub
End Class