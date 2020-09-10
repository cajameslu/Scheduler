Public Class Form1
	Private _scheduler As New Scheduler

	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'TestData()

        dsScheduler.DataSource = _scheduler

        _scheduler.LoadData()
        'dtpStart.Value = _scheduler.StatisticStartDate
        'dtpEnd.Value = _scheduler.StatisticEndDate

        _scheduler.CalPersonStatistics()

        grdPerson.DataSource = _scheduler.AllPersons

        For Each row As DataGridViewRow In grdPerson.Rows
            Dim r As Resource = row.DataBoundItem
            row.DefaultCellStyle.BackColor = r.BackColor
            row.DefaultCellStyle.ForeColor = r.ForeColor
        Next

        For Each col As DataGridViewColumn In grdPerson.Columns
            col.SortMode = DataGridViewColumnSortMode.Automatic
        Next

        monthView1.Scheduler = _scheduler
        monthView1.Month = Month.CurrentMonth
        monthView1.UpdateDisplay()
    End Sub

	Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
		_scheduler.SaveData()
	End Sub

    'Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
    '    _scheduler.StatisticStartDate = dtpStart.Value
    'End Sub

    'Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
    '    _scheduler.StatisticEndDate = dtpEnd.Value
    'End Sub

    Private Sub btnAddPerson_Click(sender As Object, e As EventArgs) Handles btnAddPerson.Click
        Dim addForm As New AddPersonForm
        addForm.Scheduler = _scheduler
        addForm.ShowDialog()

    End Sub

    Private Sub grdPerson_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPerson.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim p As Resource = grdPerson.Rows(e.RowIndex).DataBoundItem
            Dim editForm As New EditPersonForm
            editForm.Person = p

            editForm.ShowDialog()
        End If
    End Sub

    Private Sub grdPerson_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdPerson.RowEnter
        _scheduler.SelectedPerson = grdPerson.Rows(e.RowIndex).DataBoundItem
    End Sub

    Private Sub grdPerson_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles grdPerson.CellValueChanged
        If grdPerson.Columns(e.ColumnIndex).DataPropertyName = "Active" Then
            Dim r As Resource = grdPerson.Rows(e.RowIndex).DataBoundItem
            grdPerson.Rows(e.RowIndex).DefaultCellStyle.BackColor = r.BackColor
        End If
    End Sub

    'Private Sub TestData()
    '	For i = 0 To 10
    '		Dim a As Char = "A"
    '		Dim n As Char = Chr(Asc(a) + i)
    '		Dim name As String = n & n & n

    '		Dim p As New Person
    '		p.Name = name
    '		p.StartDate = Date.Now

    '		_scheduler.AddPerson(p)

    '		Dim d As New Day
    '		d.SchedDate = Date.Now.Date.AddDays(i)
    '		d.AddPerson(p)

    '		_scheduler.AddDay(d)
    '	Next
    'End Sub

End Class
