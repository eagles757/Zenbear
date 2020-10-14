Public Class Final
    Inherits System.Web.UI.Page
    Dim gl As New JDLL.Main
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If CType(Session("ZBUser"), UserClass).FirstName = "" Then
        '    Response.Redirect("../default.aspx")
        'End If

        If Not IsPostBack And Not IsCallback Then
            GVBind()
        End If
    End Sub
    Sub GVBind()
        Try
            Dim dt As DataTable = Session("INVITems")
            GridView1.DataSource = dt
            GridView1.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim dr = GridView1.SelectedRow

        Dim dt As DataTable = Session("INVITems")
        Dim i = 0
        Dim rr = -1
        For Each a As DataRow In dt.Rows
            If a.Item(0) = e.Values(0) Then
                rr = i
                Exit For
            End If
            i += 1
        Next

        If rr > -1 Then
            dt.Rows(rr).Delete()
        End If

        Session("INVITems") = dt
        GVBind()




    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim dt As DataTable = Session("INVITems")
        Dim i = 0
        Dim rr = -1
        Dim RTN As String = ""
        For Each a As DataRow In dt.Rows
            Dim qry = "insert into zenbear_Biz.Recieved_Made values ('0','" & a.Item(0) & "','" & a.Item(2) & "','" & CType(Session("ZBUser"), UserClass).UN & "','" & DateTime.Now & "')"


            Dim dd As String = gl.mysql_update(qry, "connstr")
            If dd.IndexOf("ERROR") > -1 Then
                RTN = RTN & "ID: " & a.Item(0) & " - ERROR: " & dd
            Else
                RTN = RTN & "ID: " & a.Item(0) & " - Save OK"
            End If

        Next

        If RTN.IndexOf("ERROR") > -1 Then
            SaveStat.Text = ("ERROR: " & RTN)
        Else
            SaveStat.Text = ("SAVE Successful.")
            Session("INVITems") = Nothing
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            Button1.Visible = False
            GridView1.Visible = False

        End If




    End Sub
End Class