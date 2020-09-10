Imports System.ComponentModel

Public Class BaseObject
    Implements INotifyPropertyChanged

    Protected _isModified As Boolean
    Protected _isNew As Boolean

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


    Public Sub RaisePropertyChanged(propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub


    Public Overridable ReadOnly Property IsDirty As Boolean
        Get
            Return _isModified Or _isNew
        End Get
    End Property

    Public Overridable ReadOnly Property IsNew As Boolean
        Get
            Return _isNew
        End Get
    End Property

    Public Overridable ReadOnly Property IsModified As Boolean
        Get
            Return _isModified
        End Get
    End Property

    Public Overridable Sub ClearStatus()
        _isNew = False
        _isModified = False
    End Sub

End Class
