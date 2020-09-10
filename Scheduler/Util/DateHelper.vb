Module DateHelper

    'Public Function IsSaterday(d As Date)
    '    Return GetDayIndexInWeek(d) = 6
    'End Function

    'Public Function IsSunday(d As Date)
    '    Return GetDayIndexInWeek(d) = 0
    'End Function

    'Public Function IsWeekday(d As Date)
    '    Dim index As Integer = GetDayIndexInWeek(d)

    '    Return index > 0 And index < 6
    'End Function

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
				Return -2
        End Select
	End Function


    Public Function GetDayNameByIndex(i As Integer) As String
        Select Case i
            Case 0
                Return "Sun"
            Case 1
                Return "Mon"
            Case 2
                Return "Tue"
            Case 3
                Return "Wed"
            Case 4
                Return "Thu"
            Case 5
                Return "Fri"
            Case 6
                Return "Sat"
            Case -1
                Return "All"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Public Function GetWeekDayColor(d As Date) As Color
        Return GetWeekDayColor(GetDayIndexInWeek(d))
    End Function

    Public Function GetWeekDayColor(weekDayIndex As Integer) As Color
        If weekDayIndex = 0 Then
            'Sunday
            Return Color.Red
        ElseIf weekDayIndex = 6 Then
            'Saterday
            Return Color.Green
        Else
            'All others
            Return Color.Black
        End If
    End Function

End Module
