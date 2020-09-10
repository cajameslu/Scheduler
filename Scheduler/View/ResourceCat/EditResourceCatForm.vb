Public Class EditResourceCatForm

	Private _resourceCat As ResourceCategory
	Private _scheduler As Scheduler
	Private _cancelled As Boolean = True

	Public Function ChangeResourceCat(rc As ResourceCategory, scheduler As Scheduler)
		_resourceCat = rc
		_scheduler = scheduler

		txtName.Text = rc.Name
		txtName.ForeColor = rc.Color

		Me.ShowDialog()

		Return Not _cancelled
	End Function

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		Me.Dispose()
		Me.Close()
	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		Dim newName As String = txtName.Text.Trim

		If newName = "" Then
			MsgBox("Please enter a valid name.")
			Return
		ElseIf Not _scheduler.ValidateResourceCatRename(_resourceCat, newName) Then
			MsgBox("Name " & newName & " already exists, please enter a different name.")
			Return
		End If

		_resourceCat.Name = newName
		_resourceCat.Color = txtName.ForeColor

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