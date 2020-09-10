Imports System.ComponentModel

Public Class Scheduler
    Inherits BaseObject

    Private _allPersonMap As New Dictionary(Of String, Resource)
    Private _allPersonList As New MyBindingList(Of Resource)

    Private _allSchedDayMap As New Dictionary(Of String, Day)
    Private _allSchedDayList As New MyBindingList(Of Day)


    Private _statisticStartDate As Date
    Public Property StatisticStartDate As Date
        Get
            Return _statisticStartDate
        End Get
        Set(value As Date)
            _statisticStartDate = value

            CalPersonStatistics()

            RaisePropertyChanged("StatisticStartDate")
        End Set
    End Property

    Private _statisticEndDate As Date
    Public Property StatisticEndDate As Date
        Get
            Return _statisticEndDate
        End Get
        Set(value As Date)
            _statisticEndDate = value

            CalPersonStatistics()

            RaisePropertyChanged("StatisticEndDate")
        End Set
    End Property

    Public Sub CalPersonStatistics()
        For Each p As Resource In _allPersonMap.Values
            p.ClearStatistic()
        Next

        For Each d As Day In _allSchedDayMap.Values
            If d.SchedDate >= _statisticStartDate AndAlso d.SchedDate <= _statisticEndDate Then

                For Each p As Resource In d.Persons
                    p.ScheduledDays += 1
                Next
            End If
        Next

        For Each p As Resource In _allPersonMap.Values
            p.RaiseStatisticPropertiesChange()
        Next
    End Sub


    Public Function AllPersons() As MyBindingList(Of Resource)
        Return _allPersonList
    End Function

    Public Function AllDays() As MyBindingList(Of Day)
        Return _allSchedDayList
    End Function


    Public Sub AddPerson(p As Resource)
        _allPersonMap.Add(p.Name, p)
        _allPersonList.Add(p)
    End Sub

    Public Sub AddDay(d As Day)
        _allSchedDayMap.Add(d.SchedDate, d)
        _allSchedDayList.Add(d)
    End Sub

    Public Function ContainsPerson(name As String) As Boolean
        Return _allPersonMap.ContainsKey(name)
    End Function

    Public Function GetPersonByName(name As String) As Resource
        Return _allPersonMap(name)
    End Function


    Public Function ContainsDay(d As Date) As Boolean
        Return _allSchedDayMap.ContainsKey(d)
    End Function

    Public Function GetDayByDate(d As Date)
        If Not _allSchedDayMap.ContainsKey(d) Then
            Dim day As New Day()
            day.SchedDate = d
            AddDay(day)
        End If

        Return _allSchedDayMap(d)
    End Function

    Public Sub SaveData()
        Dim dataLoader As New DataLoader(Me)
        dataLoader.SaveData()
    End Sub

    Public Sub LoadData()
        Dim dataLoader As New DataLoader(Me)
        dataLoader.LoadData()

        StatisticStartDate = GetDefaultMinStaticDate()
        StatisticEndDate = GetDefaultMaxStaticDate()
    End Sub


    Public Function GetMonthList() As List(Of Month)
        Dim minDate As Date = GetMinDate()
        Dim maxDate As Date = Date.Now.AddYears(1)

        minDate = New Date(minDate.Year, minDate.Month, 1)
        maxDate = New Date(maxDate.Year, maxDate.Month, 1)

        Dim monthList As New List(Of Month)
        Dim dt As Date = minDate

        While dt <= maxDate
            monthList.Add(New Month(dt))
            dt = dt.AddMonths(1)
        End While

        Return monthList
    End Function

    Public Function GetMinDate() As Date
        Dim minDate As Date = Date.Now

        For Each day As Day In _allSchedDayMap.Values
            If day.SchedDate < minDate Then
                minDate = day.SchedDate
            End If
        Next

        Return minDate
    End Function

    Public Function GetDefaultMinStaticDate() As Date
        Dim minDate As Date = GetMinDate()

        Return New Date(minDate.Year, minDate.Month, 1)
    End Function

    Public Function GetDefaultMaxStaticDate() As Date
        'Default to end of current month
        Dim dt As Date = Date.Now
        dt = New Date(dt.Year, dt.Month, 1)

        Return dt.AddDays(Date.DaysInMonth(dt.Year, dt.Month) - 1)
    End Function

    Private _selectedPerson As Resource
    Public Property SelectedPerson As Resource
        Get
            Return _selectedPerson
        End Get
        Set(value As Resource)
            _selectedPerson = value

            RaisePropertyChanged("SelectedPerson")
        End Set
    End Property

End Class
