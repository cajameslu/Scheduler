Imports Scheduler

Public Class ResourceCategoryMatcher
    Implements IColorItem

    Private _resourceCat As ResourceCategory

    Public Sub New(rc As ResourceCategory)
        _resourceCat = rc
    End Sub

    Public Function Matches(rc As ResourceCategory) As Boolean
        If _resourceCat Is rc Then
            Return True
        End If

        Return False
    End Function

    Public Overrides Function ToString() As String
        Return _resourceCat.ToString
    End Function

    Public Function GetForeColor() As Color Implements IColorItem.GetForeColor
        If _resourceCat IsNot Nothing Then
            Return _resourceCat.Color
        Else
            Return Color.Black
        End If
    End Function
End Class
