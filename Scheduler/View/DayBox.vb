Public Class DayBox

    Private _day As Day
    Private _scheduler As Scheduler

	Private _backColor As Color = Color.LightBlue

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

		Me.BackColor = _backColor
		lstResource.BackColor = _backColor
		btnAddSelected.BackColor = _backColor
		btnRemove.BackColor = _backColor

		'make sure listbox height not change due to border style changes
		lstResource.IntegralHeight = False

		Dim tooltip As New ToolTip
		tooltip.SetToolTip(btnAddSelected, "Add selected resource in Resource List to current day.")
		tooltip.SetToolTip(btnRemove, "Remove selected resource from current day.")
    End Sub

    Public Property Day As Day
        Get
            Return _day
        End Get
        Set(value As Day)
            _day = value

            SetupDay()
        End Set
    End Property

    Public WriteOnly Property Scheduler As Scheduler
        Set(value As Scheduler)
            _scheduler = value
        End Set
    End Property

	Private Sub SetupDay()
        lblDay.Text = _day.DateText
        lblDay.ForeColor = _day.GetForeColor

        lstResource.DataSource = _day.Resources
	End Sub

    Public Sub SetEditMode(editable As Boolean)
		btnAddSelected.Visible = editable
		btnRemove.Visible = editable

		If Not editable Then
			'So that no highlight on item
			lstResource.SelectedIndex = -1

			lstResource.BorderStyle = Windows.Forms.BorderStyle.None
		Else
			lstResource.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
		End If
	End Sub

	Public Sub HighlightResource(res As Resource)
		'no selection
		lstResource.SelectedIndex = -1

		Dim foundList As New List(Of Resource)

		'select specified resource if found
		For Each r As Resource In lstResource.Items
			If r Is res Then
				foundList.Add(r)
			End If
		Next

		For Each r As Resource In foundList
			lstResource.SelectedItems.Add(r)
		Next
	End Sub

    Private Sub btnAddSelected_Click(sender As Object, e As EventArgs) Handles btnAddSelected.Click
		If _scheduler.SelectedResource Is Nothing Then
			MsgBox("Please select a Resource in Resource List to add.")
			Return
		ElseIf Not _scheduler.SelectedResource.Active Then
			MsgBox("Selected Resource is not Active. Please select a active Resource.")
			Return
		ElseIf _day.ContainsResource(_scheduler.SelectedResource) Then
			MsgBox("Resource " & _scheduler.SelectedResource.Name & " is already scheduled.")
			Return
		End If

		If _day.SchedDate < Date.Now.Date Then
			If MsgBox("You're modifying schedule before today. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
				Return
			End If
		End If

		_day.AddResource(_scheduler.SelectedResource)
		_scheduler.CalResourceStatistics()
	End Sub

	Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
		Dim p As Resource = lstResource.SelectedItem

		If p Is Nothing Then
			Return
		End If

		If _day.SchedDate < Date.Now.Date Then
			If MsgBox("You're modifying schedule before today. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
				Return
			End If
		End If

		_day.RemvoeResource(p)
		_scheduler.CalResourceStatistics()
	End Sub

End Class
