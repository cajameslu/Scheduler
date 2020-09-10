Public Class DeleteHistryData

	Private _scheduler As Scheduler
	Private _cancelled As Boolean = True

	Public Function DeleteHistry(scheduler As Scheduler) As Boolean
		_scheduler = scheduler

		'default to first date of last month
		dtpStart.Value = Month.CurrentMonth.FirstDayOfMonth.AddMonths(-1)

		Me.ShowDialog()

		Return Not _cancelled
	End Function


	Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
		Dim endDate As Date = dtpStart.Value.Date

		If MsgBox("Do you want to delete schedule data before " & endDate.ToString("MMM dd yyyy") & "?", vbYesNo) <> MsgBoxResult.Yes Then
			Return
		End If

		Dim cnt As Integer = _scheduler.DeleteScheduledDays(Date.MinValue, endDate, False)

		If cnt > 0 Then
			MsgBox(cnt & " scheduled days deleted.")

			_cancelled = False

			Me.Dispose()
			Me.Close()
		Else
			MsgBox("No scheduled day found in specified dates.")
		End If
	End Sub

	Private Sub btnCountScheduledDays_Click(sender As System.Object, e As System.EventArgs) Handles btnCountScheduledDays.Click
		Dim endDate As Date = dtpStart.Value.Date
		Dim cnt As Integer = _scheduler.CountScheduledDays(Date.MinValue, endDate, False)

		MsgBox(cnt & " scheduled days found in specified dates.")
	End Sub
End Class