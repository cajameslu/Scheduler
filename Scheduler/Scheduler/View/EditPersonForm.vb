Public Class EditPersonForm

    Private _person As Resource

    Public WriteOnly Property Person As Resource
        Set(value As Resource)
            _person = value

            txtName.Text = _person.Name
            dtpStartDate.Value = _person.StartDate
        End Set
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtName.Text.Trim = "" Then
            MsgBox("Please enter a valid name.")
            Return
        ElseIf dtpStartDate.Value = Date.MinValue Then
            MsgBox("Please pick a start date.")
            Return
        End If

        _person.Name = txtName.Text.Trim
        _person.StartDate = dtpStartDate.Value

        _person.RaiseStatisticPropertiesChange()

        MsgBox("Person " & Name & " is modified.")

        Me.Dispose()
        Me.Close()
    End Sub

End Class