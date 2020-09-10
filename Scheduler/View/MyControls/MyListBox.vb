Public Class MyListBox
	Inherits ListBox

    Private _highlightColor As Color = SystemColors.Highlight

    Public Sub New()
		DrawMode = DrawMode.OwnerDrawVariable
	End Sub

	Property HighlightColor As Color
		Get
			Return _highlightColor
		End Get
		Set(value As Color)
			_highlightColor = value
		End Set
	End Property

	Private Sub Me_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
		If e.Index > -1 And e.Index < Me.Items.Count Then
			Dim cItem As IColorItem = Me.Items(e.Index)
			Dim color As Color = cItem.GetForeColor

			If e.State And DrawItemState.Selected Then
				e.Graphics.FillRectangle(New SolidBrush(_highlightColor), e.Bounds)
				e.Graphics.DrawString(cItem.ToString, e.Font, New SolidBrush(color), e.Bounds)
			Else
				e.DrawBackground()
				e.Graphics.DrawString(cItem.ToString, e.Font, New SolidBrush(color), e.Bounds)
			End If

			'Draws a focus rectangle around the item if it has focus
			e.DrawFocusRectangle()
		Else
			e.DrawBackground()
		End If
	End Sub

	Private Sub MyListBox_MeasureItem(sender As Object, e As System.Windows.Forms.MeasureItemEventArgs) Handles Me.MeasureItem
		e.ItemHeight = Me.Font.Height
	End Sub
End Class
