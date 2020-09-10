Imports Scheduler

Public Class WeekDayMatcher
    Implements IColorItem

    Private _weekDayIndex As Integer

    Public Sub New(weekDayIndex As Integer)
        _weekDayIndex = weekDayIndex
    End Sub

    Public Function Matches(d As Day) As Boolean
        If _weekDayIndex = -1 Then
            '-1 matches any day
            Return True
        End If

        If DateHelper.GetDayIndexInWeek(d.SchedDate) = _weekDayIndex Then
            Return True
        End If

        Return False
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        ElseIf Me.GetType IsNot obj.GetType Then
            Return False
        End If

        Return _weekDayIndex = CType(obj, WeekDayMatcher)._weekDayIndex
    End Function

    Public Overrides Function ToString() As String
        Return DateHelper.GetDayNameByIndex(_weekDayIndex)
    End Function

    Public Function GetForeColor() As Color Implements IColorItem.GetForeColor
        Return DateHelper.GetWeekDayColor(_weekDayIndex)
    End Function
End Class
