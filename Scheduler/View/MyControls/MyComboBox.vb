Public Class MyComboBox
	Inherits ComboBox

	Public Sub New()
		MyBase.New()

		Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
	End Sub

	'Private highlightColor As Color = Color.Yellow

	Private Sub Me_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
		If e.Index > -1 And e.Index < Me.Items.Count Then
			Dim cItem As IColorItem = Me.Items(e.Index)
			Dim color As Color = cItem.GetForeColor

			'If e.State And DrawItemState.Selected Then
			'	e.Graphics.FillRectangle(New SolidBrush(highlightColor), e.Bounds)
			'	e.Graphics.DrawString(res.ToString, e.Font, New SolidBrush(color), e.Bounds)
			'Else
			e.DrawBackground()
			e.Graphics.DrawString(cItem.ToString, e.Font, New SolidBrush(color), e.Bounds)
			'End If

			'Draws a focus rectangle around the item if it has focus
			e.DrawFocusRectangle()
		Else
			e.DrawBackground()
		End If
	End Sub

	Private Sub Me_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Me.SelectedIndexChanged
		If Me.SelectedItem IsNot Nothing Then
			Dim cItem As IColorItem = Me.SelectedItem
			Me.ForeColor = cItem.GetForeColor
		End If
	End Sub

End Class
