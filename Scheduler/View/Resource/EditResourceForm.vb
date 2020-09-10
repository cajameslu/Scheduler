Public Class EditResourceForm

	Private _resource As Resource
	Private _scheduler As Scheduler

	Private _cancelled As Boolean = True

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		cboCategory.DrawMode = DrawMode.OwnerDrawFixed
	End Sub

	Public Function ChangeResource(r As Resource, sched As Scheduler) As Boolean
		_resource = r
		_scheduler = sched

		txtName.Text = r.Name
		txtNotes.Text = r.Notes
		'txtName.ForeColor = r.ResourceCategory.Color
		'txtNotes.ForeColor = r.ResourceCategory.Color
		dtpStartDate.Value = _resource.StartDate

		cboCategory.DataSource = sched.AllResourceCategory
		cboCategory.SelectedItem = r.ResourceCategory
		'cboCategory.ForeColor = r.ResourceCategory.Color

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
		ElseIf Not _scheduler.ValidateResourceRename(_resource, newName) Then
			MsgBox("Name " & newName & " already exists, please enter a different name.")
			Return
		ElseIf dtpStartDate.Value = Date.MinValue Then
			MsgBox("Please pick a start date.")
			Return
		End If

		_resource.Name = newName
		_resource.Notes = txtNotes.Text
		_resource.StartDate = dtpStartDate.Value
		_resource.ResourceCategory = cboCategory.SelectedItem

		_cancelled = False

		'MsgBox("Resource " & _resource.Name & " is modified.")

		Me.Dispose()
		Me.Close()
	End Sub

	Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
		If cboCategory.SelectedItem IsNot Nothing Then
			Dim rc As ResourceCategory = cboCategory.SelectedItem
			txtName.ForeColor = rc.Color
			txtNotes.ForeColor = rc.Color
			'cboCategory.ForeColor = rc.Color
		End If
	End Sub
End Class