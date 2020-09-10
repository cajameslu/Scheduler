Imports System.ComponentModel
Imports Scheduler

Public Class Day
    Inherits BaseObject
    Implements IComparable(Of Day), IColorItem

    Private _schedDate As Date
    Private _ResourceList As New MyBindingList(Of Resource)

    Public Sub New()

        _isNew = True
    End Sub

    Public ReadOnly Property Resources() As MyBindingList(Of Resource)
        Get
            Return _ResourceList
        End Get
    End Property

    Public Property SchedDate As Date
        Get
            Return _schedDate
        End Get
        Set(value As Date)
            _schedDate = value.Date

            _isModified = True
            RaisePropertyChanged("SchedDate")
            RaisePropertyChanged("DateText")
        End Set
    End Property

    Public ReadOnly Property DateText As String
        Get
            Return _schedDate.ToString("ddd " & vbNewLine & "MMM " & " dd")
        End Get
    End Property

    Public ReadOnly Property WeekDay As String
        Get
            Return _schedDate.ToString("ddd")
        End Get
    End Property

    Public Sub AddResource(p As Resource)
        _ResourceList.Add(p)

        _isModified = True
    End Sub

    Public Sub RemvoeResource(p As Resource)
        If _ResourceList.Contains(p) Then
            _ResourceList.Remove(p)

            _isModified = True
        End If
    End Sub

    Public Function ContainsResource(p As Resource) As Boolean
        Return _ResourceList.Contains(p)
    End Function

    Public Overrides ReadOnly Property IsDirty As Boolean
        Get
            If _isNew And _ResourceList.Count = 0 Then
                'It's newly created, and no resource scheduled, then no need to save it
                Return False
            End If

            Return _isModified OrElse _isNew
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _schedDate.ToString("MMM dd")
    End Function


    Public Function CompareTo(other As Day) As Integer Implements System.IComparable(Of Day).CompareTo
        Return _schedDate.CompareTo(other._schedDate)
    End Function

    Public Function GetForeColor() As Color Implements IColorItem.GetForeColor
        Return DateHelper.GetWeekDayColor(_schedDate)
    End Function
End Class
