Imports System.IO
Imports System.ComponentModel

Public Class MainForm
	Private _scheduler As Scheduler
	Private _schedulerFileName As String

	Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		'TestData()
		SplitContainer1.Enabled = False

		InitCboWeekDay()

		Dim lastSchedFileName As String = ""

		'Try to load previous opened/saved file if there's one
		Dim userProfileName As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Scheduler.ini"
		If File.Exists(userProfileName) Then
			Try
				Using sr As New StreamReader(userProfileName)
					lastSchedFileName = sr.ReadLine()
				End Using
			Catch ex As Exception
				MsgBox("Failed to read user profile: " & ex.Message)
			End Try
		End If

		If lastSchedFileName <> "" AndAlso File.Exists(lastSchedFileName) Then
			LoadSchedule(lastSchedFileName)
		End If
	End Sub

	Private Sub InitCboWeekDay()
		For i = -1 To 6
			cboWeekDay.Items.Add(New WeekDayMatcher(i))
		Next

		cboWeekDay.SelectedIndex = 0
	End Sub

	Private Sub CloseSchedule()
		_scheduler = Nothing
		_schedulerFileName = ""
		SplitContainer1.Enabled = False

		dsScheduler.DataSource = GetType(Scheduler)

		grdResource.DataSource = New List(Of Resource)

		monthView1.Scheduler = Nothing
		monthView1.SelectedMonth = Nothing
		monthView1.RefreshSchedule()

		SetFormTitle("")
	End Sub

	Private Sub NewSchedule()
		_schedulerFileName = ""
        _scheduler = Scheduler.CreateNewScheduler

        _scheduler.AutoCalculateStatistics = False
		_scheduler.StatisticStartDate = Month.CurrentMonth.FirstDayOfMonth
		_scheduler.StatisticEndDate = Month.CurrentMonth.LastDayInMonth

		DisplaySchedule()
		_scheduler.AutoCalculateStatistics = True

		SetFormTitle("New")
	End Sub

	Private Sub LoadSchedule(fileName As String)
		_schedulerFileName = ""
        _scheduler = Scheduler.LoadScheduler(fileName)

        _scheduler.AutoCalculateStatistics = False
        DisplaySchedule()
        _scheduler.AutoCalculateStatistics = True

		_schedulerFileName = fileName

		SetFormTitle(fileName)
		SaveUserProfile(fileName)
	End Sub

	Private Sub DisplaySchedule()
		SplitContainer1.Enabled = False
		dsScheduler.DataSource = _scheduler

		_scheduler.WeekDayFilter = cboWeekDay.SelectedItem

		grdResource.DataSource = _scheduler.AllResource

		SetupGrid()
		UpdateRowColor()

		monthView1.Scheduler = _scheduler
		monthView1.SelectedMonth = Month.CurrentMonth
		monthView1.RefreshSchedule()

		_scheduler.CalResourceStatistics()

		_oldSortColumn = Nothing

		SplitContainer1.Enabled = True
	End Sub

	Private Sub SetupGrid()
		'column setup
		grdResource.Columns("Name").DisplayIndex = 0
		grdResource.Columns("ScheduledDays").DisplayIndex = 1
		grdResource.Columns("CalculatedScheduleDays").DisplayIndex = 2
		grdResource.Columns("StatisticDays").DisplayIndex = 3
		grdResource.Columns("ScheduledFrequency").DisplayIndex = 4
		grdResource.Columns("Active").DisplayIndex = 5
		grdResource.Columns("ResourceCategory").DisplayIndex = 6

        grdResource.Columns("ForeColor").Visible = False
        grdResource.Columns("BackColor").Visible = False
        grdResource.Columns("IsNew").Visible = False
        grdResource.Columns("IsModified").Visible = False
        grdResource.Columns("IsDirty").Visible = False

        grdResource.Columns("Name").HeaderCell.ToolTipText = "Resource Name"
		grdResource.Columns("Name").ReadOnly = True

		grdResource.Columns("Active").HeaderCell.ToolTipText = "Resource Active?"

		grdResource.Columns("StartDate").HeaderText = "Start Date"
		grdResource.Columns("StartDate").HeaderCell.ToolTipText = "Resource Start Date"
		grdResource.Columns("StartDate").ReadOnly = True

		grdResource.Columns("ScheduledFrequency").HeaderText = "Scheduled Frequency"
		grdResource.Columns("ScheduledFrequency").HeaderCell.ToolTipText = "Scheduled Days / Resource Effective Days in Statistic Peroid"
		grdResource.Columns("ScheduledFrequency").DefaultCellStyle.Format = "N2"

		grdResource.Columns("CalculatedScheduleDays").HeaderText = "Calculated Scheduled Days"
		grdResource.Columns("CalculatedScheduleDays").HeaderCell.ToolTipText = "Scheduled Frequency * Statistic Days"
		grdResource.Columns("CalculatedScheduleDays").DefaultCellStyle.Format = "N1"

		grdResource.Columns("StatisticDays").HeaderText = "Statistic Days"
		grdResource.Columns("StatisticDays").HeaderCell.ToolTipText = "Days between Statistic Start date and Statistic end date"

		grdResource.Columns("ScheduledDays").HeaderText = "Scheduled Days"
		grdResource.Columns("ScheduledDays").HeaderCell.ToolTipText = "Resource Real Scheduled Days in Statistic Peroid"
		grdResource.Columns("ScheduledDays").ReadOnly = True

		grdResource.Columns("ResourceCategory").HeaderText = "Resource Category"
		grdResource.Columns("ResourceCategory").HeaderCell.ToolTipText = "Resource Category"
		grdResource.Columns("ResourceCategory").ReadOnly = True

		'auto sort columns
		For Each col As DataGridViewColumn In grdResource.Columns
			col.SortMode = DataGridViewColumnSortMode.Programmatic
		Next
	End Sub

	Private Sub UpdateRowColor()
		'row back color
		For Each row As DataGridViewRow In grdResource.Rows
			Dim r As Resource = row.DataBoundItem
			row.DefaultCellStyle.BackColor = r.BackColor
			row.DefaultCellStyle.ForeColor = r.ForeColor
		Next
	End Sub

	Private Sub SaveUserProfile(fileName As String)
		Try
			Dim userProfileName As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Scheduler.ini"

			Using sw As New StreamWriter(userProfileName)
				sw.WriteLine(fileName)
			End Using
		Catch ex As Exception
			MsgBox("Failed to write user profile: " & ex.Message)
		End Try
	End Sub

	Private Function CheckSave() As Boolean
		If _scheduler Is Nothing OrElse Not _scheduler.IsDirty Then
			Return True
		End If

		Dim ret As MsgBoxResult = MsgBox("Do you want to save current scheduler?", MsgBoxStyle.YesNoCancel)
		Dim proceed As Boolean = False

		If ret = MsgBoxResult.No Then
			proceed = True
		ElseIf ret = MsgBoxResult.Yes Then
			proceed = SaveSchedule()
		End If

		Return proceed
	End Function

	Private Function SaveSchedule() As Boolean
		If _schedulerFileName = "" Then
			Return SaveScheduleAs()
		Else
			Return SaveSchedule(_schedulerFileName)
		End If
	End Function

	Private Function SaveSchedule(fileName As String) As Boolean
		If _scheduler.SaveData(fileName) Then
			_schedulerFileName = fileName

			SetFormTitle(fileName)
			SaveUserProfile(fileName)

			Return True
		Else
			Return False
		End If
	End Function

	Private Function SaveScheduleAs() As Boolean
		Dim saveFileDialog1 As New SaveFileDialog()

		saveFileDialog1.Filter = "Schedule files (*.sch)|*.sch"
		saveFileDialog1.RestoreDirectory = True

		If saveFileDialog1.ShowDialog() = DialogResult.OK Then
			Return SaveSchedule(saveFileDialog1.FileName)
		Else
			Return False
		End If
	End Function

	Private Sub grdResource_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdResource.CellDoubleClick
		If e.RowIndex > -1 Then
			Dim view As New ScheduledDayListView
			view.ShowDays(_scheduler, dtpStart.Value, dtpEnd.Value, grdResource.Rows(e.RowIndex).DataBoundItem, cboWeekDay.SelectedItem)
		End If
	End Sub

	Private Sub grdResource_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdResource.RowEnter
		_scheduler.SelectedResource = grdResource.Rows(e.RowIndex).DataBoundItem
	End Sub

	Private Sub grdResource_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles grdResource.CellValueChanged
		If grdResource.Columns(e.ColumnIndex).DataPropertyName = "Active" Then
			Dim r As Resource = grdResource.Rows(e.RowIndex).DataBoundItem
			grdResource.Rows(e.RowIndex).DefaultCellStyle.BackColor = r.BackColor
		End If
	End Sub

	Private _oldSortColumn As DataGridViewColumn
	Private _oldSortOrder As SortOrder

	Private Sub grdResource_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdResource.ColumnHeaderMouseClick
		Dim newColumn As DataGridViewColumn = grdResource.Columns(e.ColumnIndex)

		Dim newSortOrder As SortOrder = SortOrder.Ascending

		If _oldSortColumn IsNot Nothing Then
			' Sort the same column again, change the SortOrder.
			If _oldSortColumn Is newColumn Then
				If _oldSortOrder = SortOrder.Ascending Then
					newSortOrder = SortOrder.Descending
				ElseIf _oldSortOrder = SortOrder.Descending Then
					newSortOrder = SortOrder.None
				Else
					newSortOrder = SortOrder.Ascending
				End If
			Else
				'Sort a new column
				newSortOrder = SortOrder.Ascending
				'Hide widget for old column
				_oldSortColumn.HeaderCell.SortGlyphDirection = SortOrder.None
			End If
		End If

		' Sort the selected column.
		Select Case newSortOrder
			Case SortOrder.Ascending
				grdResource.Sort(newColumn, ListSortDirection.Ascending)

			Case SortOrder.Descending
				grdResource.Sort(newColumn, ListSortDirection.Descending)

			Case SortOrder.None
				CType(grdResource.DataSource, MyBindingList(Of Resource)).RemoveSort()
				grdResource.Refresh()

		End Select

		newColumn.HeaderCell.SortGlyphDirection = newSortOrder

		_oldSortColumn = newColumn
		_oldSortOrder = newSortOrder

        UpdateRowColor()
    End Sub

	'Private Sub TestData()
	'	For i = 0 To 10
	'		Dim a As Char = "A"
	'		Dim n As Char = Chr(Asc(a) + i)
	'		Dim name As String = n & n & n

	'		Dim p As New Resource
	'		p.Name = name
	'		p.StartDate = Date.Now

	'		_scheduler.AddResource(p)

	'		Dim d As New Day
	'		d.SchedDate = Date.Now.Date.AddDays(i)
	'		d.AddResource(p)

	'		_scheduler.AddDay(d)
	'	Next
	'End Sub

	Private Sub miOpen_Click(sender As System.Object, e As System.EventArgs) Handles miOpen.Click
		If CheckSave() Then
			Dim openFileDialog1 As New OpenFileDialog()

			openFileDialog1.Filter = "Schedule files (*.sch)|*.sch"
			openFileDialog1.RestoreDirectory = True

			If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				LoadSchedule(openFileDialog1.FileName)
			End If
		End If
	End Sub

	Private Sub miSave_Click(sender As System.Object, e As System.EventArgs) Handles miSave.Click
		SaveSchedule()
	End Sub

	Private Sub miSaveAs_Click(sender As System.Object, e As System.EventArgs) Handles miSaveAs.Click
		SaveScheduleAs()
	End Sub

	Private Sub miNew_Click(sender As System.Object, e As System.EventArgs) Handles miNew.Click
		If CheckSave() Then
			NewSchedule()
		End If
	End Sub

	Private Sub miClose_Click(sender As System.Object, e As System.EventArgs) Handles miClose.Click
		If CheckSave() Then
			CloseSchedule()
		End If
	End Sub

	Private Sub miQuit_Click(sender As System.Object, e As System.EventArgs) Handles miQuit.Click
		If CheckSave() Then
			Me.Close()
		End If
	End Sub

	Private Sub SetFormTitle(fileName As String)
		If fileName = "" Then
			Me.Text = "Scheduler"
		Else
			Me.Text = "Scheduler (" & fileName & ")"
		End If
	End Sub

	Private Sub cboWeekDay_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboWeekDay.SelectionChangeCommitted
		_scheduler.WeekDayFilter = cboWeekDay.SelectedItem
	End Sub


	Private Sub btnAddResource_Click(sender As Object, e As EventArgs) Handles btnAddResource.Click
		Dim addForm As New AddResourceForm
		If addForm.AddResource(_scheduler) Then
			UpdateRowColor()
		End If
	End Sub

	Private Sub btnEditResource_Click(sender As System.Object, e As System.EventArgs) Handles btnEditResource.Click
		If grdResource.CurrentRow Is Nothing Then
			MsgBox("Please select a resource to edit.")
			Return
		End If

		Dim r As Resource = grdResource.CurrentRow.DataBoundItem
		Dim editForm As New EditResourceForm
		If editForm.ChangeResource(r, _scheduler) Then
			UpdateRowColor()
		End If
	End Sub

	Private Sub btnDeleteResource_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteResource.Click
		If grdResource.CurrentRow Is Nothing Then
			MsgBox("Please select a resource to delete.")
			Return
		End If

		Dim r As Resource = grdResource.CurrentRow.DataBoundItem
		If _scheduler.ResourceUsedInSchedule(r) Then
			MsgBox("Resource " & r.Name & " is used in schedule. Please delete from schedule first.")
			Return
		End If

		If MsgBox("Do you want to delete Resource " & r.Name & "?", vbYesNo) = MsgBoxResult.No Then
			Return
		End If

		_scheduler.DeleteResource(r)
	End Sub

	Private Sub btnHighlight_Click(sender As System.Object, e As System.EventArgs) Handles btnHighlight.Click
		If grdResource.CurrentRow Is Nothing Then
			MsgBox("Please select a resource to highlight.")
			Return
		End If

		Dim r As Resource = grdResource.CurrentRow.DataBoundItem
		monthView1.HighlightResource(r)
	End Sub

	Private Sub miDeleteHistoricalData_Click(sender As System.Object, e As System.EventArgs) Handles miDeleteHistoricalData.Click
		Dim deleteHisForm As New DeleteHistryData
		If deleteHisForm.DeleteHistry(_scheduler) Then
			_scheduler.CalResourceStatistics()
			monthView1.RefreshSchedule()
		End If
	End Sub

	Private Sub miManageResourceCategory_Click(sender As System.Object, e As System.EventArgs) Handles miManageResourceCategory.Click
		OpenResourceCategoryManager()
	End Sub

	Private Sub miScheduledDaysGridView_Click(sender As System.Object, e As System.EventArgs) Handles miScheduledDaysGridView.Click
		Dim view As New ScheduledDayListView

		view.ShowDays(_scheduler, dtpStart.Value, dtpEnd.Value, Nothing, cboWeekDay.SelectedItem)
	End Sub

	Private Sub btnResourceCategoryManager_Click(sender As System.Object, e As System.EventArgs) Handles btnResourceCategoryManager.Click
		OpenResourceCategoryManager()
	End Sub

	Private Sub OpenResourceCategoryManager()
		Dim resCatForm As New ResourceCatForm

		If resCatForm.ChangeResourceCat(_scheduler) Then
			UpdateRowColor()
		End If
	End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not CheckSave() Then
            e.Cancel = True
        End If
    End Sub
End Class
