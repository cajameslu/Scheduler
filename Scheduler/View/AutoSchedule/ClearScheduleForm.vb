Public Class ClearScheduleForm

	Private _scheduler As Scheduler
	Private _cancelled As Boolean = True

	Public Function ClearSchedule(sched As Scheduler, startDate As Date, endDate As Date)
		_scheduler = sched

		dtpStartDate.Value = startDate
		dtpEndDate.Value = endDate

		Me.ShowDialog()

		Return Not _cancelled
	End Function

	Private Sub btnClearSchedule_Click(sender As System.Object, e As System.EventArgs) Handles btnClearSchedule.Click
		If dtpEndDate.Value < dtpStartDate.Value Then
			MsgBox("Invalid Start/End dates. End date should be bigger than Start date.")
			Return
		End If

		If dtpStartDate.Value < Date.Now.Date Then
			If MsgBox("Selected scheduling dates include dates before today. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
				Return
			End If
		End If

		If MsgBox("Scheduled resources in selected dates will deleted. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
			Return
		End If

		Dim cnt As Integer = _scheduler.DeleteScheduledDays(dtpStartDate.Value, dtpEndDate.Value, True)

		If cnt > 0 Then
			_scheduler.CalResourceStatistics()

			MsgBox(cnt & " scheduled days are deleted.")

			_cancelled = False

			Me.Dispose()
			Me.Close()
		Else
			MsgBox("No scheduled day found in specified dates.")
		End If
	End Sub

	Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
		Me.Dispose()
		Me.Close()
	End Sub
End Class