Public Class AutoSchedule

	Private _scheduler As Scheduler

	Private _startDate As Date
	Private _endDate As Date

	Private _resourceNoPerDay As Integer
	Private _excludedResourceCatMatcherList As List(Of ResourceCategoryMatcher)
	Private _excludedWeekDayMatcherList As List(Of WeekDayMatcher)

	Public Sub New(scheduler As Scheduler, startDate As Date, endDate As Date, resourcNoPerDay As Integer,
 excludedResourceCategoryList As List(Of ResourceCategoryMatcher),
 excludedWeekDayMatcherList As List(Of WeekDayMatcher))

		_scheduler = scheduler

		_startDate = startDate
		_endDate = endDate

		_resourceNoPerDay = resourcNoPerDay

		_excludedResourceCatMatcherList = excludedResourceCategoryList
		_excludedWeekDayMatcherList = excludedWeekDayMatcherList
	End Sub

	Private _cntResourceDays As Integer

	Public Function Schedule() As Boolean
		Dim schedDayList As List(Of Day) = GetScheduleDaysList()
		Dim resourceMap As SortedDictionary(Of Decimal, List(Of Resource)) = BuildResourceMap()

		If schedDayList.Count = 0 Then
			MsgBox("Found 0 day to schedule.")
			Return False
		End If

		If resourceMap.Count = 0 Then
			MsgBox("No resource is available to schedule.")
			Return False
		End If

		_cntResourceDays = 0

		For Each d As Day In schedDayList
			ScheduleDay(d, resourceMap)
		Next

		MsgBox(schedDayList.Count & " days (" & _cntResourceDays & " resource*days) scheduled.")
		Return True
	End Function

	Private Sub ScheduleDay(d As Day, resourceMap As SortedDictionary(Of Decimal, List(Of Resource)))
		While d.Resources.Count < _resourceNoPerDay
			'get a resource and add to day
			Dim r As Resource = GetNextResource(resourceMap)
			d.AddResource(r)

			_cntResourceDays += 1
		End While
	End Sub

	Private Function GetNextResource(resourceMap As SortedDictionary(Of Decimal, List(Of Resource))) As Resource
		Dim kv As KeyValuePair(Of Decimal, List(Of Resource)) = resourceMap.First()
		Dim calulatedScheduledDays As Decimal = kv.Key
		Dim rList As List(Of Resource) = kv.Value

		'remove from map
		Dim r As Resource = rList(0)
		rList.RemoveAt(0)

		'Since it will be added to scheduled day
		r.ScheduledDays += 1
		r.CalculateStatistics(_scheduler.StatisticStartDate, _scheduler.StatisticEndDate)

		'add to map with days increased by 1 (since it is scheduled to a new day)
		AddResourceToMap(r.CalculatedScheduleDays, r, resourceMap)

		'check if lowest days has no resource
		If rList.Count = 0 Then
			resourceMap.Remove(calulatedScheduledDays)
		End If

		Return r
	End Function

	Private Sub AddResourceToMap(daysKey As Decimal, r As Resource, resourceMap As SortedDictionary(Of Decimal, List(Of Resource)))
		If Not resourceMap.ContainsKey(daysKey) Then
			resourceMap.Add(daysKey, New List(Of Resource))
		End If

		Dim rList As List(Of Resource) = resourceMap(daysKey)
		rList.Add(r)
	End Sub

	Private Function BuildResourceMap() As SortedDictionary(Of Decimal, List(Of Resource))
		Dim resourceList As List(Of Resource) = GetResourceList()
		Dim resourceMap As New SortedDictionary(Of Decimal, List(Of Resource))

		For Each r As Resource In resourceList
			'Use CalculatedScheduleDays as key
			AddResourceToMap(r.CalculatedScheduleDays, r, resourceMap)
		Next

		Return resourceMap
	End Function

	Private Function GetScheduleDaysList() As List(Of Day)
		Dim ret As New List(Of Day)

		Dim scheduleDaysList As List(Of Day) = _scheduler.GetDaysByDates(_startDate, _endDate)

		For Each d As Day In scheduleDaysList
			If d.Resources.Count < _resourceNoPerDay AndAlso (Not ExcludeDay(d)) Then
				ret.Add(d)
			End If
		Next

		Return ret
	End Function

	Private Function ExcludeDay(d As Day) As Boolean
		For Each wdExcludeMatcher As WeekDayMatcher In _excludedWeekDayMatcherList
			If wdExcludeMatcher.Matches(d) Then
				Return True
			End If
		Next

		Return False
	End Function

	Private Function GetResourceList() As List(Of Resource)
		Dim ret As New List(Of Resource)

		For Each r As Resource In _scheduler.AllResource
			If r.Active AndAlso (Not ExcludeResourceCat(r.ResourceCategory)) Then
				ret.Add(r)
			End If
		Next

		Return ret
	End Function

	Private Function ExcludeResourceCat(rc As ResourceCategory) As Boolean
		For Each rcExcludeMatch As ResourceCategoryMatcher In _excludedResourceCatMatcherList
			If rcExcludeMatch.Matches(rc) Then
				Return True
			End If
		Next

		Return False
	End Function
End Class
