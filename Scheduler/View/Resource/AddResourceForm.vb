Public Class AddResourceForm

	Private _scheduler As Scheduler
	Private _cancelled As Boolean = True

	Public Function AddResource(scheduler As Scheduler) As Boolean
		_scheduler = scheduler
        cboCategory.DataSource = scheduler.AllResourceCategory
        cboCategory.SelectedItem = scheduler.DefaultResourceCategory

        Me.ShowDialog()

		Return Not _cancelled
	End Function

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
		ElseIf cboCategory.SelectedItem Is Nothing Then
			MsgBox("Please choose a category.")
			Return
		End If

		Dim name As String = txtName.Text
		If _scheduler.ContainsResource(name) Then
			MsgBox("Resource named " & name & " already exists. Please enter different name.")
			Return
		End If

        Dim r As New Resource(_scheduler)
        r.Name = name
		r.StartDate = dtpStartDate.Value
		r.ResourceCategory = cboCategory.SelectedItem
		r.Notes = txtNotes.Text

		_scheduler.AddResource(r)
		_cancelled = False

		'MsgBox("Resource " & name & " is added.")

		Me.Dispose()
		Me.Close()
	End Sub

	Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
		Dim rc As ResourceCategory = cboCategory.SelectedItem
		txtName.ForeColor = rc.Color
		txtNotes.ForeColor = rc.Color
		'cboCategory.ForeColor = rc.Color
	End Sub

End Class