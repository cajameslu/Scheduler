Imports System.ComponentModel

Public Class MyBindingList(Of T)
    Inherits BindingList(Of T)

	Private _lst As New List(Of T)

	Protected Overrides Sub InsertItem(index As Integer, item As T)
		If index = 0 And index < Me.Count Then
			'insert
			Dim curItemAtIndex As T = Me(index)
			Dim indexLst As Integer = _lst.IndexOf(curItemAtIndex)
			_lst.Insert(indexLst, item)
		Else
			'append
			_lst.Insert(index, item)
		End If

		MyBase.InsertItem(index, item)
	End Sub

	Protected Overrides Sub RemoveItem(index As Integer)
		If index < Me.Count And index >= 0 Then
			Dim item As T = Me(index)
			_lst.Remove(item)

			MyBase.RemoveItem(index)
		End If
	End Sub

	Public Sub RemoveSort()
		RemoveSortCore()
	End Sub

#Region "Sort"

    Private _sortDirection As ListSortDirection
    Private _sortProperty As PropertyDescriptor

    Protected Overrides Sub ApplySortCore(ByVal pdsc As PropertyDescriptor, ByVal Direction As ListSortDirection)
        _sortProperty = pdsc
        _sortDirection = Direction

        'user normal lis to sort
		Dim tmpList As New List(Of T)
		tmpList.AddRange(Me)

		Dim PCom As New PCompare(Of T)(pdsc, Direction)
		tmpList.Sort(PCom)

		Me.RaiseListChangedEvents = False
		'clear out
		'and add back in order
		MyBase.ClearItems()
		For i As Integer = 0 To tmpList.Count - 1
			MyBase.InsertItem(i, tmpList(i))
		Next

		Me.RaiseListChangedEvents = True

		'MyBase.ResetBindings()
		'OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, 0))
	End Sub

	Protected Overrides Sub RemoveSortCore()
		Me.RaiseListChangedEvents = False

		'clear out
		'and add back in original order
		MyBase.ClearItems()
		For i As Integer = 0 To _lst.Count - 1
			MyBase.InsertItem(i, _lst(i))
		Next

		Me.RaiseListChangedEvents = True
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
		If sortDir = ListSortDirection.Ascending Then
			Return Comparer.Default.Compare(propDes.GetValue(x), propDes.GetValue(y))
		Else
			Return Comparer.Default.Compare(propDes.GetValue(y), propDes.GetValue(x))
		End If
	End Function

End Class
#End Region