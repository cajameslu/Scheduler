Public Class DayBox

    Private _day As Day
    Private _scheduler As Scheduler

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstResource.DrawMode = DrawMode.OwnerDrawFixed
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
        SetTitleColor()

        lstResource.DataSource = _day.Persons
    End Sub

    Private Sub SetTitleColor()
        If DateHelper.IsSaterday(_day.SchedDate) Then
            lblDay.ForeColor = Color.Green
        ElseIf DateHelper.IsSunday(_day.SchedDate) Then
            lblDay.ForeColor = Color.Red
        Else
            lblDay.ForeColor = Color.Black
        End If
    End Sub

    Public Sub UpdateDisplay()
        lblDay.Text = _day.DateText
    End Sub

    Private Sub btnAddSelected_Click(sender As Object, e As EventArgs) Handles btnAddSelected.Click
        If _scheduler.SelectedPerson Is Nothing Then
            MsgBox("Please select a person in person grid to add.")
            Return
        ElseIf _day.ContainsPerson(_scheduler.SelectedPerson) Then
            MsgBox("Person " & _scheduler.SelectedPerson.Name & " is already scheduled.")
            Return
        End If

        If _day.SchedDate < Date.Now.Date Then
            If MsgBox("You're modifying schedule before today. Do you want to continue?", vbYesNo) <> MsgBoxResult.Yes Then
                Return
            End If
        End If

        _day.AddPerson(_scheduler.SelectedPerson)
        _scheduler.CalPersonStatistics()
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

        _day.RemvoePerson(p)
        _scheduler.CalPersonStatistics()
    End Sub

    'Dim clrSelectedText As Color = Color.Red    'Our color for selected text 
    Private highlightColor As Color = Color.Yellow      'Our background for selected items

    Private Sub lstResource_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstResource.DrawItem
        Dim res As Resource = lstResource.Items(e.Index)
        Dim color As Color = Color.Red

        'If e.State = DrawItemState.Selected Then
        '    e.Graphics.FillRectangle(New SolidBrush(highlightColor), e.Bounds)
        '    e.Graphics.DrawString(res.ToString, e.Font, New SolidBrush(color), e.Bounds)
        'Else

        e.DrawBackground()
        e.Graphics.DrawString(res.ToString, e.Font, New SolidBrush(color), e.Bounds)

        'End If
        'Draws a focus rectangle around the item if it has focus
        e.DrawFocusRectangle()
    End Sub
End Class
