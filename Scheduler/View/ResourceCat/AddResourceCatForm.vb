Public Class AddResourceCatForm

	Private _scheduler As Scheduler
	Private _cancelled As Boolean = True

	Public Function AddResourceCat(scheduler As Scheduler) As Boolean
		_scheduler = scheduler
		txtName.ForeColor = Color.Black

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
		End If

		Dim name As String = txtName.Text
		If _scheduler.ContainsResourceCategory(name) Then
			MsgBox("Resource category named " & name & " already exists. Please enter different name.")
			Return
		End If

		Dim rc As New ResourceCategory()
		rc.Name = name
		rc.Color = txtName.ForeColor

		_scheduler.AddResourceCategory(rc)

		_cancelled = False

		Me.Dispose()
		Me.Close()
	End Sub

	Private Sub btnPickColor_Click(sender As System.Object, e As System.EventArgs) Handles btnPickColor.Click
		Dim cDialog As New ColorDialog()
		cDialog.Color = txtName.ForeColor

		If (cDialog.ShowDialog() = DialogResult.OK) Then
			txtName.ForeColor = cDialog.Color
		End If
	End Sub
End Class