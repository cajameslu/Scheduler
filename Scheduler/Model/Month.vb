Public Class Month
	Implements IComparable(Of Month)

	Private _firstDayOfMonth As Date
	Private _daysInMonth As Integer

	Public Sub New(firstDayOfMonth As Date)
		Me.FirstDayOfMonth = firstDayOfMonth
	End Sub

	Public Property FirstDayOfMonth As Date
		Get
			Return _firstDayOfMonth
		End Get
		Set(value As Date)
			_firstDayOfMonth = value

			If value <> Date.MinValue Then
				_daysInMonth = Date.DaysInMonth(value.Year, value.Month)
			Else
				_daysInMonth = 0
			End If
		End Set
	End Property

	Public ReadOnly Property DaysInMonth As Integer
		Get
			Return _daysInMonth
		End Get
	End Property

	Public ReadOnly Property LastDayInMonth As Date
		Get
			Return _firstDayOfMonth.AddDays(_daysInMonth - 1)
		End Get
	End Property

	Public Function Valid() As Boolean
		Return _firstDayOfMonth <> Date.MinValue
	End Function


	Public Overrides Function ToString() As String
		Return _firstDayOfMonth.ToString("yyyy MM")
	End Function

	Public Overrides Function Equals(obj As Object) As Boolean
		If obj Is Me Then
			Return True
		ElseIf obj Is Nothing Then
			Return False
		Else
			Return obj.GetType.Equals(Me.GetType) AndAlso (CType(obj, Month)._firstDayOfMonth = Me._firstDayOfMonth)
		End If
	End Function

	Public Function NextMonth() As Month
		Dim dt As Date = _firstDayOfMonth.AddMonths(1)
		Return New Month(dt)
	End Function

	Public Function PrevMonth() As Month
		Dim dt As Date = _firstDayOfMonth.AddMonths(-1)
		Return New Month(dt)
	End Function

	Public Shared Function CurrentMonth() As Month
		Dim dt As Date = Date.Now
		dt = New Date(dt.Year, dt.Month, 1)

		Return New Month(dt)
	End Function

	Public Function CompareTo(other As Month) As Integer Implements System.IComparable(Of Month).CompareTo
		Return Me._firstDayOfMonth.CompareTo(other._firstDayOfMonth)
	End Function
End Class
