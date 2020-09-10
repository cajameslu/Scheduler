Public Class AddPersonForm

    Private _scheduler As Scheduler

    Public WriteOnly Property Scheduler As Scheduler
        Set(value As Scheduler)
            _scheduler = value
        End Set
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtName.Text.Trim = "" Then
            MsgBox("Please enter a name.")
            Return
        ElseIf dtpStartDate.Value = Date.MinValue Then
            MsgBox("Please pick a start date.")
            Return
        End If

        Dim name As String = txtName.Text
        If _scheduler.ContainsPerson(name) Then
            MsgBox("Person named " & name & " already exists. Please enter different name.")
            Return
        End If

        Dim p As New Resource(_scheduler)
        p.Name = name
        p.StartDate = dtpStartDate.Value

        _scheduler.AddPerson(p)

        MsgBox("Person " & name & " is added.")
    End Sub
End Class