Public Class ResourceCategory
    Inherits BaseObject
	Implements IColorItem, IComparable


	Private _name As String
	Private _color As Color

	Public Sub New()
		_isNew = True
	End Sub

	Public Property Name As String
		Get
			Return _name
		End Get
		Set(value As String)

			_isModified = True
			_name = value
		End Set
	End Property

	Public Property Color As Color
		Get
			Return _color
		End Get
		Set(value As Color)

			_isModified = True
			_color = value
		End Set
	End Property

	Private Function GetForeColor() As Color Implements IColorItem.GetForeColor
		Return _color
	End Function

	Public Overrides Function ToString() As String
		Return _name
	End Function

	Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
		Return String.Compare(ToString, obj.ToString)
	End Function
End Class
