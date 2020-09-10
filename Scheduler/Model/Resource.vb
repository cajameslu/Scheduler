Imports System.Xml
Imports System.DateTime
Imports System.ComponentModel

Public Class Resource
	Inherits BaseObject
	Implements IColorItem

	Private _name As String
    Private _Active As Boolean = True
	Private _startDate As Date
    Private _notes As String

    Private _scheduler As Scheduler
    Private _resourceCategory As ResourceCategory

    Public Sub New(sched As Scheduler)
        _isNew = True

        _scheduler = sched
        _resourceCategory = sched.DefaultResourceCategory
    End Sub

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
			_name = value

            _isModified = True
            RaisePropertyChanged("Name")
        End Set
	End Property

	Public Property Notes As String
		Get
			Return _notes
		End Get
		Set(value As String)
			_notes = value

            _isModified = True
            RaisePropertyChanged("Notes")
		End Set
	End Property

    Public Property Active As Boolean
        Get
            Return _Active
        End Get
        Set(value As Boolean)
            _Active = value

            _isModified = True
            RaisePropertyChanged("Active")
            RaisePropertyChanged("BackColor")
        End Set
	End Property

	Public Property ResourceCategory() As ResourceCategory
		Get
			Return _resourceCategory
		End Get
        Set(value As ResourceCategory)

            _isModified = True
            _resourceCategory = value
        End Set
    End Property

    Public ReadOnly Property BackColor As Color
        Get
            If _Active Then
                Return Color.White
            Else
                Return Color.LightGray
            End If
        End Get
    End Property

    Public ReadOnly Property ForeColor As Color
        Get
			Return _resourceCategory.Color
        End Get
	End Property

	Private Function GetForeColor() As Color Implements IColorItem.GetForeColor
		Return _resourceCategory.Color
	End Function

	Private Sub RaiseStatisticPropertiesChange()
		RaisePropertyChanged("StatisticDays")
		RaisePropertyChanged("CalculatedScheduleDays")
		RaisePropertyChanged("ScheduledFrequency")
	End Sub

    Public Property StartDate As Date
        Get
            Return _startDate
        End Get
        Set(value As Date)
			_startDate = value.Date

            _isModified = True
            RaisePropertyChanged("StartDate")
        End Set
    End Property

    Public Sub ClearStatistic()
		ScheduledDays = 0
		_tmpCalculatedScheduleDays = 0
		_tmpScheduledFrequency = 0
		_tmpStatisticDays = 0
    End Sub

	Private _tmpScheduledDays As Integer
	Public Property ScheduledDays As Integer
		Get
			Return _tmpScheduledDays
		End Get
		Set(value As Integer)
			_tmpScheduledDays = value
			RaisePropertyChanged("ScheduledDays")
		End Set
	End Property

	Private _tmpStatisticDays As Integer
	Public ReadOnly Property StatisticDays As Integer
		Get
			Return _tmpStatisticDays
		End Get
	End Property

	Private _tmpCalculatedScheduleDays As Decimal
	Public ReadOnly Property CalculatedScheduleDays As Decimal
		Get
			Return _tmpCalculatedScheduleDays
		End Get
	End Property

	Private _tmpScheduledFrequency As Decimal
	Public ReadOnly Property ScheduledFrequency As Decimal
		Get
			Return _tmpScheduledFrequency
		End Get
	End Property

	Public Sub CalculateStatistics(statisticStartDate As Date, statisticEndDate As Date)
		'Scheduled Frequency
		Dim sDate As Date

		If _startDate > statisticStartDate Then
			sDate = _startDate
		Else
			sDate = statisticStartDate
		End If

		Dim allDays As Decimal = CType(statisticEndDate - sDate, TimeSpan).Days + 1

		If allDays <= 0 Then
			_tmpScheduledFrequency = 0
		Else
			_tmpScheduledFrequency = Math.Round(_tmpScheduledDays / allDays, 2)
		End If

		'StatisticDays
		_tmpStatisticDays = CType(statisticEndDate - statisticStartDate, TimeSpan).Days + 1

		'CalculatedScheduleDays
		_tmpCalculatedScheduleDays = Math.Round(_tmpScheduledFrequency * _tmpStatisticDays, 2)

		RaiseStatisticPropertiesChange()
	End Sub

    Public Overrides Function ToString() As String
		Return _name
	End Function

End Class
