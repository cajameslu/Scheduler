Public Class MonthView

    Private Const TITLE_HEIGHT As Single = 50
    Private Const MARGIN_SPACE As Single = 20

    Private _scheduler As Scheduler
    Private _dayBoxList As New List(Of DayBox)
    Private _monthLayoutGrid As New MonthLayoutGrid

    Private _month As Month

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

    Public Property Month As Month
        Get
            Return _month
        End Get
        Set(value As Month)
            _month = value

            If value IsNot Nothing AndAlso value.Valid Then
                PopulateDays()
            End If
        End Set
    End Property

    Private Sub PopulateDays()
        'If too many boxes, remove some
        While _dayBoxList.Count > _month.DaysInMonth
            Dim daybox As DayBox = _dayBoxList(_dayBoxList.Count - 1)
            _dayBoxList.RemoveAt(_dayBoxList.Count - 1)

            Me.Controls.Remove(daybox)
        End While

        'If not enough boxes, add some
        While _dayBoxList.Count < _month.DaysInMonth
            Dim daybox As New DayBox

            _dayBoxList.Add(daybox)
            Me.Controls.Add(daybox)
        End While

        'Connect daybox with schedulete Days
        Dim curDate As Date = _month.FirstDayOfMonth
        For i = 0 To _month.DaysInMonth - 1
            Dim curDay As Day = _scheduler.GetDayByDate(curDate)
            _dayBoxList(i).Day = curDay
            _dayBoxList(i).Scheduler = _scheduler

            curDate = curDate.AddDays(1)
        Next
    End Sub

    Public Sub UpdateDisplay()
        'Grid layout
        _monthLayoutGrid.Month = _month
        _monthLayoutGrid.Position = New PointF(MARGIN_SPACE, TITLE_HEIGHT)
        _monthLayoutGrid.Size = New Size(Me.Size.Width - 2 * MARGIN_SPACE, Me.Size.Height - TITLE_HEIGHT - MARGIN_SPACE)

        _monthLayoutGrid.CalulateLayout()

        For i As Integer = 0 To _dayBoxList.Count - 1
            Dim cellRec As RectangleF = _monthLayoutGrid.GetCellRectangle(i)
            _dayBoxList(i).SetBounds(cellRec.X, cellRec.Y, cellRec.Width, cellRec.Height)
        Next

        'Update
        For Each daybox As DayBox In _dayBoxList
            daybox.UpdateDisplay()
        Next
    End Sub

    Private Sub MonthView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Month IsNot Nothing Then
            UpdateDisplay()
        End If

        Label1.Text = "Size: " & Me.Size.Width & ", " & Me.Size.Height
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        Me.Month = cboMonth.SelectedItem
        UpdateDisplay()
        _scheduler.StatisticEndDate = Me.Month.LastDayInMonth
    End Sub
End Class
