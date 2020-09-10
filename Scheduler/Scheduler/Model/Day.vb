Imports System.ComponentModel

Public Class Day
    Inherits BaseObject

    Private _schedDate As Date
    Private _personList As New MyBindingList(Of Resource)

    Public ReadOnly Property Persons() As MyBindingList(Of Resource)
        Get
            Return _personList
        End Get
    End Property

    Public Property SchedDate As Date
        Get
            Return _schedDate
        End Get
        Set(value As Date)
            _schedDate = value.Date

            RaisePropertyChanged("SchedDate")
            RaisePropertyChanged("DateText")
        End Set
    End Property

    Public ReadOnly Property DateText As String
        Get
            Return _schedDate.ToString("ddd " & vbNewLine & " dd")
        End Get
    End Property

    Public Sub AddPerson(p As Resource)
        _personList.Add(p)
    End Sub

    Public Sub RemvoePerson(p As Resource)
        If _personList.Contains(p) Then
            _personList.Remove(p)
        End If
    End Sub

    Public Function ContainsPerson(p As Resource) As Boolean
        Return _personList.Contains(p)
    End Function
End Class
