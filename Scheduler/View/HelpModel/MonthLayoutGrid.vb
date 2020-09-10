Public Class MonthLayoutGrid
    Inherits LayoutGrid

    Private _month As Month

    Public Sub New()
        MyBase.New(7)
    End Sub

    Public Property Month As Month
        Get
            Return _month
        End Get
        Set(value As Month)
            _month = value

            _cellsCount = _month.DaysInMonth
            _cellOffSet = GetOffSet(value.FirstDayOfMonth)
        End Set
    End Property

    Public Function IsSundayBox(i As Integer) As Boolean
        Dim index As Integer = _cellOffSet + i
        Dim colNo As Integer = index Mod _colsPerRow

        Return colNo = 0
    End Function

    Public Function IsSaterdayDayBox(i As Integer) As Boolean
        Dim index As Integer = _cellOffSet + i
        Dim colNo As Integer = index Mod _colsPerRow

        Return colNo = 6
    End Function


    Public Function IsWeekDayBox(i As Integer) As Boolean
        Dim index As Integer = _cellOffSet + i
        Dim colNo As Integer = index Mod _colsPerRow

        Return (colNo <> 6) And (colNo <> 0)
    End Function

    Private Function GetOffSet(d As Date)
        Return DateHelper.GetDayIndexInWeek(d)
    End Function

End Class
