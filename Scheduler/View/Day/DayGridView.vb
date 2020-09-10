Public Class ScheduledDayListView

	Private _scheduler As Scheduler
	Private _initializing As Boolean = True

	Public Sub ShowDays(sched As Scheduler, startDate As Date, endDate As Date, r As Resource, weekDayMather As WeekDayMatcher)
		_scheduler = sched

		dtpStart.Value = startDate
		dtpEnd.Value = endDate

		InitCboResource(sched, r)
		InitCboWeekDay(weekDayMather)

		_initializing = False

		grdDays.AllowUserToAddRows = False
		RefreshGrid()

		Me.ShowDialog()
	End Sub

	Private Sub InitCboResource(sched As Scheduler, res As Resource)
		Dim rmList As New List(Of ResourceMatcher)
		Dim selected As ResourceMatcher = Nothing

		For Each r As Resource In sched.AllResource
			Dim newRm As New ResourceMatcher(r)
			rmList.Add(newRm)

			If r Is res Then
				selected = newRm
			End If
		Next

		cboResource.DataSource = rmList
		cboResource.SelectedItem = selected
	End Sub

	Private Sub InitCboWeekDay(weekDayMather As WeekDayMatcher)
		For i = -1 To 6
			cboWeekDay.Items.Add(New WeekDayMatcher(i))
		Next

		cboWeekDay.SelectedItem = weekDayMather
	End Sub

	Private Sub RefreshGrid()
		If Not _initializing Then
            If cboResource.SelectedItem IsNot Nothing AndAlso cboWeekDay.SelectedItem IsNot Nothing Then
                grdDays.DataSource = _scheduler.GetScheduledDaysList(dtpStart.Value, dtpEnd.Value, cboResource.SelectedItem, cboWeekDay.SelectedItem)

                For Each col As DataGridViewColumn In grdDays.Columns
                    col.ReadOnly = True
                Next
            Else
                grdDays.DataSource = New List(Of Day)
            End If

            grdDays.Columns("IsDirty").Visible = False
            grdDays.Columns("IsNew").Visible = False
            grdDays.Columns("IsModified").Visible = False

            grdDays.Columns("DateText").Visible = False
            grdDays.Columns("WeekDay").HeaderText = "Day of Week"
        End If
	End Sub

	Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
		Me.Dispose()
		Me.Close()
	End Sub

	Private Sub cboResource_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboResource.SelectedIndexChanged
		txtResourceNotes.Text = ""

		If cboResource.SelectedItem IsNot Nothing Then
			Dim rm As ResourceMatcher = cboResource.SelectedItem

			If rm.SingleResource IsNot Nothing Then
				txtResourceNotes.Text = rm.SingleResource.Notes
			End If
		End If

		RefreshGrid()
	End Sub

	Private Sub cboWeekDay_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboWeekDay.SelectionChangeCommitted
		RefreshGrid()
	End Sub

	Private Sub dtpStart_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpStart.ValueChanged
		RefreshGrid()
	End Sub

	Private Sub dtpEnd_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpEnd.ValueChanged
		RefreshGrid()
	End Sub

End Class