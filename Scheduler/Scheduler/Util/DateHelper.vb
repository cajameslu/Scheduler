Module DateHelper

    Public Function IsSaterday(d As Date)
        Return GetDayIndexInWeek(d) = 6
    End Function

    Public Function IsSunday(d As Date)
        Return GetDayIndexInWeek(d) = 0
    End Function

    Public Function IsWeekday(d As Date)
        Dim index As Integer = GetDayIndexInWeek(d)

        Return index > 0 And index < 6
    End Function

    Public Function GetDayIndexInWeek(d As Date)
        Select Case d.ToString("ddd")
            Case "Sun"
                Return 0
            Case "Mon"
                Return 1
            Case "Tue"
                Return 2
            Case "Wed"
                Return 3
            Case "Thu"
                Return 4
            Case "Fri"
                Return 5
            Case "Sat"
                Return 6
            Case Else
                Return 0
        End Select
    End Function
End Module
