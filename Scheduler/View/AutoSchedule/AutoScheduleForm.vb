Public Class AutoScheduleForm

	Private _scheduler As Scheduler

    Private _cancelled As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstResourceCat.HighlightColor = SystemColors.Highlight
    End Sub

    Public Function AutoSchedule(scheduler As Scheduler, statisticStartDate As Date, month As Month) As Boolean
		_scheduler = scheduler

		dtpStatisticStartDate.Value = statisticStartDate

		'Default for current month
		dtpStartDate.Value = month.FirstDayOfMonth
		dtpEndDate.Value = month.LastDayInMonth

		InitResourceNoCombo()
		InitResourceCatList()
		InitWeekDayList()

		Me.ShowDialog()

		Return Not _cancelled
	End Function

	Private Sub InitResourceNoCombo()
		cboResourceNo.DropDownStyle = ComboBoxStyle.DropDownList

		For i = 1 To 10
			cboResourceNo.Items.Add(i)
		Next

		'Default select 1
		cboResourceNo.SelectedIndex = 0
	End Sub

	Private Sub InitResourceCatList()
		Dim resourceCatList As IList(Of ResourceCategory) = _scheduler.AllResourceCategory
        Dim defaultSelectedList As New List(Of Integer)

        For i As Integer = 0 To resourceCatList.Count - 1
            Dim rc As ResourceCategory = resourceCatList(i)
            lstResourceCat.Items.Add(New ResourceCategoryMatcher(rc))

            If Not rc Is _scheduler.DefaultResourceCategory Then
                'Default to exclude all category except default category
                defaultSelectedList.Add(i)
            End If
        Next

        lstResourceCat.SelectionMode = SelectionMode.MultiExtended

        For Each index As Integer In defaultSelectedList
            lstResourceCat.SetSelected(index, True)
        Next
    End Sub

	Private Sub InitWeekDayList()
		For i As Integer = 0 To 6
			lstDays.Items.Add(New WeekDayMatcher(i))
		Next

        lstDays.SelectionMode = SelectionMode.MultiExtended
        'Default to exclude Sun/Fri/Sat
        lstDays.SetSelected(0, True)
        lstDays.SetSelected(5, True)
        lstDays.SetSelected(6, True)
	End Sub

	Private Sub btnAutoSchedule_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoSchedule.Click
		If dtpEndDate.Value < dtpStartDate.Value Then
			MsgBox("Invalid Start/End dates. End date should be bigger than Start date.")
			Return
		ElseIf dtpStatisticStartDate.Value > dtpStartDate.Value Then
			MsgBox("Invalid Statistic Start date. Statistic Start date should be older than Start date")
			Return
		ElseIf dtpStartDate.Value < Date.Now.Date Then
			If MsgBox("Selected scheduling dates include dates before today. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
				Return
			End If
		End If

		'Resource Category matchers
		Dim rcCatMatcherList As New List(Of ResourceCategoryMatcher)
		For Each rcMatcher As ResourceCategoryMatcher In lstResourceCat.SelectedItems
			rcCatMatcherList.Add(rcMatcher)
		Next

		'Weekday Matchers
		Dim weekDayMatcherList As New List(Of WeekDayMatcher)
		For Each weekDayMatcher As WeekDayMatcher In lstDays.SelectedItems
			weekDayMatcherList.Add(weekDayMatcher)
		Next

		'This will cause recalculation of statistics
		_scheduler.StatisticStartDate = dtpStatisticStartDate.Value

		Dim autoSched As New AutoSchedule(_scheduler, dtpStartDate.Value, dtpEndDate.Value, cboResourceNo.SelectedItem, rcCatMatcherList, weekDayMatcherList)

		If autoSched.Schedule() Then
			_scheduler.CalResourceStatistics()
			_cancelled = False
		End If
	End Sub

	Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
		Me.Dispose()
		Me.Close()
	End Sub
End Class