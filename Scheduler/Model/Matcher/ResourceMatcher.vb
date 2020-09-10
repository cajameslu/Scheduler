Public Class ResourceMatcher
	Implements IColorItem

	Private _resource As Resource

	Public Sub New(r As Resource)
		_resource = r
	End Sub

	Public Function Matches(r As Resource) As Boolean
		If _resource Is r Then
			Return True
		End If

		Return False
	End Function

	Public Function SingleResource() As Resource
		Return _resource
	End Function

	Public Overrides Function ToString() As String
		Return _resource.ToString
	End Function

	Private Function GetForeColor() As Color Implements IColorItem.GetForeColor
		Return _resource.ForeColor
	End Function
End Class
