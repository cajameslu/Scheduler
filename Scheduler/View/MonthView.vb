Public Class MonthView

	Private Const TITLE_HEIGHT As Single = 80
    Private Const MARGIN_SPACE As Single = 20

    Private _scheduler As Scheduler
    Private _dayBoxList As New List(Of DayBox)
    Private _monthLayoutGrid As New MonthLayoutGrid

	Private _selectedMonth As Month

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
	End Sub

	Public Property Scheduler As Scheduler
		Get
			Return _scheduler
		End Get
		Set(value As Scheduler)
			_scheduler = value

			If value IsNot Nothing Then
				cboMonth.DataSource = value.GetMonthList
			End If
		End Set
	End Property

	Public Property SelectedMonth As Month
		Get
			Return _selectedMonth
		End Get
		Set(value As Month)
			If Not Object.Equals(value, _selectedMonth) Then
				_selectedMonth = value

				If Not Object.Equals(value, cboMonth.SelectedItem) Then
					cboMonth.SelectedItem = value
				End If
			End If
		End Set
	End Property

	Public Sub RefreshSchedule()
		PopulateDays()
		UpdateDisplay()
	End Sub

	Private Sub PopulateDays()
		If _selectedMonth Is Nothing Then
			Return
		End If

		'If too many boxes, remove some
		While _dayBoxList.Count > _selectedMonth.DaysInMonth
			Dim daybox As DayBox = _dayBoxList(_dayBoxList.Count - 1)
			_dayBoxList.RemoveAt(_dayBoxList.Count - 1)

			Me.Controls.Remove(daybox)
		End While

		'If not enough boxes, add some
		While _dayBoxList.Count < _selectedMonth.DaysInMonth
			Dim daybox As New DayBox

			_dayBoxList.Add(daybox)
			Me.Controls.Add(daybox)
		End While

		'Connect daybox with schedulete Days
		Dim curDate As Date = _selectedMonth.FirstDayOfMonth
		For i = 0 To _selectedMonth.DaysInMonth - 1
			Dim curDay As Day = _scheduler.GetDayByDate(curDate)
			_dayBoxList(i).Day = curDay
			_dayBoxList(i).Scheduler = _scheduler

			curDate = curDate.AddDays(1)
		Next
	End Sub

	Private Sub UpdateDisplay()
		If _selectedMonth Is Nothing Then
			For Each db In _dayBoxList
				db.Visible = False
			Next
			Return
		End If

		For Each db In _dayBoxList
			db.Visible = True
		Next

		'Grid layout
		_monthLayoutGrid.Month = _selectedMonth
		_monthLayoutGrid.Position = New PointF(MARGIN_SPACE, TITLE_HEIGHT)
		_monthLayoutGrid.Size = New Size(Me.Size.Width - 2 * MARGIN_SPACE, Me.Size.Height - TITLE_HEIGHT - MARGIN_SPACE)

		_monthLayoutGrid.CalulateLayout()

		For i As Integer = 0 To _dayBoxList.Count - 1
			Dim cellRec As RectangleF = _monthLayoutGrid.GetCellRectangle(i)
			_dayBoxList(i).SetBounds(cellRec.X, cellRec.Y, cellRec.Width, cellRec.Height)
		Next

		SetEditMode(rbEditMode.Checked)
	End Sub

	Private Sub MonthView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
		If _selectedMonth IsNot Nothing Then
			UpdateDisplay()
		End If
	End Sub

	Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        Me.SelectedMonth = cboMonth.SelectedItem

        If cboMonth.SelectedItem IsNot Nothing Then
            _scheduler.StatisticEndDate = Me.SelectedMonth.LastDayInMonth
        End If

        RefreshSchedule()
    End Sub

	Private Sub rbEditMode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEditMode.CheckedChanged
		SetEditMode(rbEditMode.Checked)
	End Sub

	Private Sub SetEditMode(editable As Boolean)
		For Each d As DayBox In _dayBoxList
			d.SetEditMode(editable)
		Next
	End Sub

	Public Sub HighlightResource(r As Resource)
		For Each dbox As DayBox In _dayBoxList
			dbox.HighlightResource(r)
		Next
	End Sub

	Private Sub btnAutoSchedule_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoSchedule.Click
		Dim autoSchedForm As New AutoScheduleForm

		 autoSchedForm.AutoSchedule(_scheduler, _scheduler.StatisticStartDate, _selectedMonth) 
	End Sub

	Private Sub btnPrevMonth_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevMonth.Click
		Dim curMonth As Month = Month.CurrentMonth

		If cboMonth.SelectedItem IsNot Nothing Then
			curMonth = cboMonth.SelectedItem
			ChooseMonth(curMonth.PrevMonth)
		End If
	End Sub

	Private Sub btnNextMonth_Click(sender As System.Object, e As System.EventArgs) Handles btnNextMonth.Click
		Dim curMonth As Month = Month.CurrentMonth

		If cboMonth.SelectedItem IsNot Nothing Then
			curMonth = cboMonth.SelectedItem
			ChooseMonth(curMonth.NextMonth)
		End If
	End Sub

	Private Sub ChooseMonth(month As Month)
		Dim monthList As MyBindingList(Of Month) = cboMonth.DataSource

		Dim found As Boolean = False
		Dim pos As Integer = 0

		For i As Integer = 0 To monthList.Count - 1
			Dim m As Month = monthList(i)
			Dim ret As Integer = m.CompareTo(month)

			If ret = 0 Then
				'equal, found
				found = True
				Exit For
			ElseIf ret < 0 Then
				pos = i + 1
			End If
		Next

		If Not found Then
			monthList.Insert(pos, month)
		End If

		cboMonth.SelectedItem = month
	End Sub

	Private Sub btnClearSchedule_Click(sender As System.Object, e As System.EventArgs) Handles btnClearSchedule.Click
		Dim clearForm As New ClearScheduleForm
		If clearForm.ClearSchedule(_scheduler, _selectedMonth.FirstDayOfMonth, _selectedMonth.LastDayInMonth) Then
			RefreshSchedule()
		End If
	End Sub
End Class
