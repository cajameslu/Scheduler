Imports System.ComponentModel

Public Class Scheduler
    Inherits BaseObject

	Private _resourceList As New MyBindingList(Of Resource)
    Private _schedDayList As New MyBindingList(Of Day)

    Private _defaultResourceCategory As ResourceCategory
    Private _resourceCategoryList As New MyBindingList(Of ResourceCategory)

    Private _autoCalculateStatistic As Boolean = False

    Private Sub New()
        _isNew = True

        'Default Dates
        StatisticStartDate = Month.CurrentMonth.FirstDayOfMonth
        StatisticEndDate = Month.CurrentMonth.LastDayInMonth
    End Sub

    'Brand new Scheduler
    Public Shared Function CreateNewScheduler() As Scheduler
        Dim sched As New Scheduler
        sched.CheckDefaultResourceCategory()

        sched._autoCalculateStatistic = True
        sched.ClearStatus()

        'Still want to mark it new
        sched._isNew = True

        Return sched
    End Function

    Public Shared Function LoadScheduler(fileName As String)
        Dim sched As New Scheduler

        sched.LoadData(fileName)
        sched._autoCalculateStatistic = True

        Return sched
    End Function


    Private _statisticStartDate As Date
	Public Property StatisticStartDate As Date
		Get
			Return _statisticStartDate
		End Get
		Set(value As Date)
			_statisticStartDate = value

			If _autoCalculateStatistic Then
				CalResourceStatistics()
			End If

            _isModified = True
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

			If _autoCalculateStatistic Then
				CalResourceStatistics()
			End If

			RaisePropertyChanged("StatisticEndDate")
		End Set
	End Property

	Public Sub CalResourceStatistics()
		For Each p As Resource In _resourceList
			p.ClearStatistic()
		Next

		For Each d As Day In _schedDayList
			If d.SchedDate >= _statisticStartDate AndAlso d.SchedDate <= _statisticEndDate Then
				For Each p As Resource In d.Resources
					If _weekDayFilter.Matches(d) Then
						p.ScheduledDays += 1
					End If
				Next
			End If
		Next

		For Each p As Resource In _resourceList
			p.CalculateStatistics(_statisticStartDate, _statisticEndDate)
		Next
	End Sub

	Public Property AutoCalculateStatistics() As Boolean
		Get
			Return _autoCalculateStatistic
		End Get
		Set(value As Boolean)
			_autoCalculateStatistic = value
		End Set
	End Property

	Public Function AllResourceCategory() As MyBindingList(Of ResourceCategory)
		Return _resourceCategoryList
	End Function

	Public Function AllResource() As MyBindingList(Of Resource)
		Return _resourceList
	End Function

	Public Function AllDays() As MyBindingList(Of Day)
		Return _schedDayList
	End Function

    Public Sub AddResourceCategory(rc As ResourceCategory)
        If ContainsResourceCategory(rc.Name) Or _resourceCategoryList.Contains(rc) Then
            Return
        End If

        _resourceCategoryList.Add(rc)
    End Sub

    Public Sub DeleteResourceCategory(rc As ResourceCategory)
        If rc Is _defaultResourceCategory OrElse ResourceCategoryInUse(rc) Then
            Return
        End If

        _resourceCategoryList.Remove(rc)
        If Not rc.IsNew Then
            _isModified = True
        End If
    End Sub

    Public Property DefaultResourceCategory As ResourceCategory
        Get
            CheckDefaultResourceCategory()

            Return _defaultResourceCategory
        End Get
        Set(value As ResourceCategory)
            If _resourceCategoryList.Contains(value) Then

                _isModified = True
                _defaultResourceCategory = value
            End If
        End Set
    End Property

    Private Sub CheckDefaultResourceCategory()
        If _defaultResourceCategory Is Nothing Then
            'Try to find one named Default
            For Each rc As ResourceCategory In _resourceCategoryList
                If rc.Name = "Default" Then
                    'Found
                    _defaultResourceCategory = rc
                    Return
                End If
            Next

            'If still not found
            _defaultResourceCategory = New ResourceCategory()
            _defaultResourceCategory.Name = "Default"
            _defaultResourceCategory.Color = Color.Black
            AddResourceCategory(_defaultResourceCategory)
        End If
    End Sub

    Public Function ContainsResourceCategory(resCateName As String)
		For Each rc As ResourceCategory In _resourceCategoryList
			If rc.Name = resCateName Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function GetResourceCategoryByName(resCateName As String)
		For Each rc As ResourceCategory In _resourceCategoryList
			If rc.Name = resCateName Then
				Return rc
			End If
		Next

		'Not found, use default
		Return Nothing
	End Function

	Public Sub AddResource(r As Resource)
		If ContainsResource(r.Name) Or _resourceList.Contains(r) Then
			Return
		End If

		_resourceList.Add(r)
	End Sub

	Public Sub DeleteResource(r As Resource)
        If ResourceUsedInSchedule(r) Then
            Return
        End If

        _resourceList.Remove(r)
        If Not r.IsNew Then
            _isModified = True
        End If
    End Sub

	Public Sub AddDay(d As Day)
		If ContainsDay(d.SchedDate) Or _schedDayList.Contains(d) Then
			Return
		End If

		_schedDayList.Add(d)
	End Sub

	Public Sub DeleteDay(d As Day)
        _schedDayList.Remove(d)

        If Not d.IsNew Then
            _isModified = True
        End If
    End Sub

	Public Function ContainsResource(name As String) As Boolean
		For Each r As Resource In _resourceList
			If r.Name = name Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function GetResourceByName(name As String) As Resource
		For Each r As Resource In _resourceList
			If r.Name = name Then
				Return r
			End If
		Next

		Return Nothing
	End Function


	Public Function ContainsDay(dt As Date) As Boolean
		For Each d As Day In _schedDayList
			If d.SchedDate = dt Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function GetDayByDate(dt As Date)
		For Each d As Day In _schedDayList
			If d.SchedDate = dt Then
				Return d
			End If
		Next

		'Not found
		Dim day As New Day()
		day.SchedDate = dt
		AddDay(day)

		Return day
	End Function

	Public Function GetDaysByDates(startDate As Date, endDate As Date) As List(Of Day)
		Dim ret As New List(Of Day)

		If endDate < startDate Then
			Return ret
		End If

		Dim dayMap As New Dictionary(Of Date, Day)
		For Each d As Day In _schedDayList
			dayMap.Add(d.SchedDate, d)
		Next

		Dim curDate As Date = startDate

		While curDate <= endDate
			If dayMap.ContainsKey(curDate) Then
				ret.Add(dayMap(curDate))
			Else
				Dim d As New Day
				d.SchedDate = curDate
				AddDay(d)
				ret.Add(d)
			End If

			curDate = curDate.AddDays(1)
		End While

		Return ret
	End Function

	Public Function SaveData(fileName As String) As Boolean
		Dim dataLoader As New DataLoader(Me)

		If dataLoader.SaveData(fileName) Then
			ClearStatus()
			Return True
		Else
			Return False
		End If
	End Function

    Private Function LoadData(fileName As String) As Boolean
        Dim dataLoader As New DataLoader(Me)

        If dataLoader.LoadData(fileName) Then
            CheckDefaultResourceCategory()

            ClearStatus()
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetMonthList() As MyBindingList(Of Month)
		Dim minDate As Date = GetMinDate()
		Dim maxDate As Date = Date.Now.AddYears(1)

		minDate = New Date(minDate.Year, minDate.Month, 1)
		maxDate = New Date(maxDate.Year, maxDate.Month, 1)

		Dim monthList As New MyBindingList(Of Month)
		Dim dt As Date = minDate

		While dt <= maxDate
			monthList.Add(New Month(dt))
			dt = dt.AddMonths(1)
		End While

		Return monthList
	End Function

	Public Function GetMinDate() As Date
		Dim minDate As Date = Date.Now

		For Each day As Day In _schedDayList
			If day.SchedDate < minDate Then
				minDate = day.SchedDate
			End If
		Next

		Return minDate
	End Function

	Private _selectedResource As Resource
	Public Property SelectedResource As Resource
		Get
			Return _selectedResource
		End Get
		Set(value As Resource)
			_selectedResource = value

			RaisePropertyChanged("SelectedResource")
		End Set
	End Property

    Public Overrides Sub ClearStatus()
        _isNew = False
        _isModified = False

        ClearChildDataStatus()
    End Sub

    Private Sub ClearChildDataStatus()
		For Each r As Resource In _resourceList
			r.ClearStatus()
		Next

        For Each rc As ResourceCategory In _resourceCategoryList
            rc.ClearStatus()
        Next

        For Each d As Day In _schedDayList
			If d.IsDirty Then
				d.ClearStatus()
			End If
		Next
	End Sub

    Public Overrides ReadOnly Property IsDirty As Boolean
        Get
            If _isNew And Not IsChildDataDirty() Then
                Return False
            End If

            Return _isModified OrElse _isNew OrElse IsChildDataDirty()
        End Get
    End Property

    Private Function IsChildDataDirty() As Boolean
        For Each r As ResourceCategory In _resourceCategoryList
            If r.IsDirty Then
                Return True
            End If
        Next

        For Each r As Resource In _resourceList
            If r.IsDirty Then
                Return True
            End If
        Next

        For Each d As Day In _schedDayList
			If d.IsDirty Then
				Return True
			End If
		Next

		Return False
	End Function

	Private _weekDayFilter As WeekDayMatcher = New WeekDayMatcher(-1)
	Public Property WeekDayFilter As WeekDayMatcher
		Get
			Return _weekDayFilter
		End Get
		Set(value As WeekDayMatcher)
			_weekDayFilter = value

			If _autoCalculateStatistic Then
				CalResourceStatistics()
			End If
		End Set
	End Property

	Public Function ValidateResourceRename(res As Resource, newName As String)
		For Each r As Resource In _resourceList
			If r IsNot res AndAlso r.Name = newName Then
				'Name used by others
				Return False
			End If
		Next

		Return True
	End Function

	Public Function ValidateResourceCatRename(res As ResourceCategory, newName As String)
		For Each rc As ResourceCategory In _resourceCategoryList
			If rc IsNot res AndAlso rc.Name = newName Then
				'Name used by others
				Return False
			End If
		Next

		Return True
	End Function

	Public Function ResourceCategoryInUse(rc As ResourceCategory)
		For Each r As Resource In _resourceList
			If r.ResourceCategory Is rc Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function ResourceUsedInSchedule(r As Resource)
		For Each d As Day In _schedDayList
			If d.Resources.Contains(r) Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function CountScheduledDays(startDate As Date, endDate As Date, inclusive As Boolean) As Integer
		Dim cnt As Integer = 0

		For Each d As Day In _schedDayList
			If d.Resources.Count > 0 Then
				If d.SchedDate > startDate AndAlso d.SchedDate < endDate Then
					cnt += 1
				End If

				If inclusive Then
					If d.SchedDate = startDate Or d.SchedDate = endDate Then
						cnt += 1
					End If
				End If
			End If
		Next

		Return cnt
	End Function

	Public Function DeleteScheduledDays(startDate As Date, endDate As Date, inclusive As Boolean) As Integer
		Dim toDelete As New List(Of Day)

		For Each d As Day In _schedDayList
			If d.Resources.Count > 0 Then
				If d.SchedDate > startDate AndAlso d.SchedDate < endDate Then
					toDelete.Add(d)
				End If

				If inclusive Then
					If d.SchedDate = startDate Or d.SchedDate = endDate Then
						toDelete.Add(d)
					End If
				End If
			End If
		Next

		For Each d As Day In toDelete
			DeleteDay(d)
		Next

		Return toDelete.Count
	End Function

	Public Function GetScheduledDaysList(startDate As Date, endDate As Date, rm As ResourceMatcher, weekdayMatcher As WeekDayMatcher) As BindingList(Of Day)
		Dim ret As New BindingList(Of Day)

		For Each d As Day In _schedDayList
			If d.SchedDate > startDate AndAlso d.SchedDate < endDate AndAlso d.Resources.Count > 0 AndAlso weekdayMatcher.Matches(d) Then
				For Each r As Resource In d.Resources
					If rm.Matches(r) Then
						ret.Add(d)
						Exit For
					End If
				Next
			End If
		Next

		Return ret
	End Function
End Class
