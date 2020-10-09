Public Class ZB

End Class
Public Class UserClass
    Public EmployeeID, FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, UN, CurrentJob, Admin As String

    Public Sub getUser(ByVal employeeID1 As String)
        Dim gl As New JDLL.Main

        Dim qry = "SELECT a.*,c.JobName,d.admin FROM zenbear_Biz.Employee  a 
left join(select * from zenbear_Biz.JobEmployee where enddate > Now() or enddate is null )  b on b.EmployeeID = a.EmployeeID
left join(select * from zenbear_Biz.Job) c on c.JobId= b.JobId
left join(select * from zenbear_Biz.AD) d on d.AAID= a.employeeid
where a.EmployeeID = '" & employeeID1 & "'"

        Dim ds As DataSet = gl.MySql_run(qry, "connstr")

        For Each a As DataRow In ds.Tables(0).Rows

            EmployeeID = gl.ct(a.Item(0))
            FirstName = gl.ct(a.Item(1))
            LastName = gl.ct(a.Item(2))
            Address = gl.ct(a.Item(3))
            City = gl.ct(a.Item(4))
            State = gl.ct(a.Item(5))
            Zip = gl.ct(a.Item(6))
            PhoneNumber = gl.ct(a.Item(7))
            Email = gl.ct(a.Item(8))
            UN = gl.ct(a.Item(9))
            CurrentJob = gl.ct(a.Item(10))
            Admin = gl.ct(a.Item(11))
        Next
    End Sub
    Function saveUser(ByVal S_U As String)
        Dim rtn = ""
        Dim qry = ""
        Dim gl As New JDLL.Main

        If S_U = "S" Then
            'save new
            qry = "insert into zenbear_Biz.Employee (EmployeeID, FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, UN) values ('" &
                EmployeeID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "','" & UN & "');"
        Else
            'update old
            qry = "update zenbear_Biz.Employee set firstname = '" & FirstName & "',
lastname='" & LastName & "',address ='" & Address & "',city='" & City & "',state='" & State & "',zip='" & Zip & "',phonenumber='" & PhoneNumber & "',
email='" & Email & "',un='" & UN & "' where employeeid='" & EmployeeID & "'; "
        End If

        Dim dd As String = gl.sql_update(qry, "connstr")

        Return dd
    End Function
End Class
