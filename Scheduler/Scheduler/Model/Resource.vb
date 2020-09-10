Imports System.Xml
Imports System.DateTime
Imports System.ComponentModel

Public Class Resource
    Inherits BaseObject

    Private _scheduler As Scheduler

    Private _name As String
    Private _Active As Boolean = True
    Private _startDate As Date

    Public Sub New(sched As Scheduler)
        _scheduler = sched
    End Sub

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
            RaisePropertyChanged("Name")
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return _Active
        End Get
        Set(value As Boolean)
            _Active = value

            RaisePropertyChanged("Active")
            RaisePropertyChanged("BackColor")
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
            Return Color.Red
        End Get
    End Property

    Public Sub RaiseStatisticPropertiesChange()
        RaisePropertyChanged("ScheduledDays")
        RaisePropertyChanged("StatisticDays")
        RaisePropertyChanged("CalcualtedScheduleDays")
        RaisePropertyChanged("ScheduledFrequency")
    End Sub

    Public Property StartDate As Date
        Get
            Return _startDate
        End Get
        Set(value As Date)
            _startDate = value.Date
            RaisePropertyChanged("StartDate")
        End Set
    End Property

    Public Sub ClearStatistic()
        ScheduledDays = 0
    End Sub

    Private _scheduledDays As Integer
    Public Property ScheduledDays As Integer
        Get
            Return _scheduledDays
        End Get
        Set(value As Integer)
            _scheduledDays = value
            RaisePropertyChanged("ScheduledDays")
        End Set
    End Property

    Public ReadOnly Property StatisticDays As Integer
        Get
            Return CType(_scheduler.StatisticEndDate - _scheduler.StatisticStartDate, TimeSpan).Days + 1
        End Get
    End Property

    Public ReadOnly Property CalcualtedScheduleDays As Decimal
        Get
            Return ScheduledFrequency * StatisticDays
        End Get
    End Property

    Public ReadOnly Property ScheduledFrequency As Decimal
        Get
            Dim freq As Decimal = 0
            Dim sDate As Date

            If _startDate > _scheduler.StatisticStartDate Then
                sDate = _startDate
            Else
                sDate = _scheduler.StatisticStartDate
            End If

            Dim allDays As Decimal = CType(_scheduler.StatisticEndDate - sDate, TimeSpan).Days + 1

            If allDays = 0 Then
                Return 0
            Else
                Return _scheduledDays / allDays
            End If
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _name
    End Function


End Class
