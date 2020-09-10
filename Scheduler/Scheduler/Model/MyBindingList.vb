Imports System.ComponentModel

Public Class MyBindingList(Of T)
    Inherits BindingList(Of T)


#Region "Sort"

    Private _sortDirection As ListSortDirection
    Private _sortProperty As PropertyDescriptor

    Protected Overrides Sub ApplySortCore(ByVal pdsc As PropertyDescriptor, ByVal Direction As ListSortDirection)
        _sortProperty = pdsc
        _sortDirection = Direction

        'user normal lis to sort
        Dim list As New List(Of T)
        list.AddRange(Me)

        Dim PCom As New PCompare(Of T)(pdsc, Direction)
        list.Sort(PCom)

        'clear out
        'and add back in order
        Me.Clear()
        For Each item As T In list
            Me.Add(item)
        Next
    End Sub

    Protected Overrides Sub RemoveSortCore()
        'do nothing
    End Sub

    Protected Overrides ReadOnly Property SupportsSortingCore() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property SortDirectionCore() As ListSortDirection
        Get
            Return _sortDirection
        End Get
    End Property

    Protected Overrides ReadOnly Property SortPropertyCore() As PropertyDescriptor
        Get
            Return _sortProperty
        End Get
    End Property

#End Region
End Class

#Region " Property comparer "
Class PCompare(Of T)
    Implements IComparer(Of T)

    Private Property propDes As PropertyDescriptor
    Private Property sortDir As ListSortDirection

    Friend Sub New(ByVal SortProperty As PropertyDescriptor, ByVal SortDirection As ListSortDirection)
        propDes = SortProperty
        sortDir = SortDirection
    End Sub
    Friend Function Compare(ByVal x As T, ByVal y As T) As Integer Implements IComparer(Of T).Compare
        Return IIf(sortDir = ListSortDirection.Ascending, Comparer.[Default].Compare(propDes.GetValue(x),
                propDes.GetValue(y)), Comparer.[Default].Compare(propDes.GetValue(y), propDes.GetValue(x)))
    End Function
End Class
#End Region