Public Class ResourceCatForm

    Private _scheduler As Scheduler
    Private _changed As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        grdResourceCat.AllowUserToAddRows = False
    End Sub

    Public Function ChangeResourceCat(scheduler As Scheduler) As Boolean
        _scheduler = scheduler
        grdResourceCat.DataSource = scheduler.AllResourceCategory

        grdResourceCat.Columns("Name").ReadOnly = True
        grdResourceCat.Columns("Color").ReadOnly = True
        grdResourceCat.Columns("IsNew").Visible = False
        grdResourceCat.Columns("IsModified").Visible = False
        grdResourceCat.Columns("IsDirty").Visible = False

        cboDefaultResourceCat.DataSource = New BindingSource(scheduler.AllResourceCategory, String.Empty)
        cboDefaultResourceCat.SelectedItem = scheduler.DefaultResourceCategory

        Me.ShowDialog()

        'Indicate if existing resource category changed
        'main form might need to refresh color
        Return _changed
    End Function

    Private Sub UpdateRowColor()
        'row forecolor
        For Each row As DataGridViewRow In grdResourceCat.Rows
            Dim rc As ResourceCategory = row.DataBoundItem
            row.DefaultCellStyle.ForeColor = rc.Color
        Next
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim addResCatForm As New AddResourceCatForm
        If addResCatForm.AddResourceCat(_scheduler) Then
            UpdateRowColor()
        End If
    End Sub

    Private Sub EditResourceCat()
        Dim rc As ResourceCategory = grdResourceCat.CurrentRow.DataBoundItem

        Dim editResCatForm As New EditResourceCatForm
        If editResCatForm.ChangeResourceCat(rc, _scheduler) Then
            UpdateRowColor()
            _changed = True
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If grdResourceCat.CurrentRow Is Nothing Then
            MsgBox("Please select a resource category to edit.")
            Return
        End If

        EditResourceCat()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If grdResourceCat.CurrentRow Is Nothing Then
            MsgBox("Please select a resource category to delete.")
            Return
        End If

        Dim rc As ResourceCategory = grdResourceCat.CurrentRow.DataBoundItem

        If _scheduler.DefaultResourceCategory Is rc Then
            MsgBox("Resource Category " & rc.Name & " is set to default. Default resource category is not allow to delete.")
            Return
        ElseIf _scheduler.ResourceCategoryInUse(rc) Then
            MsgBox("Resource Category " & rc.Name & " is in use. Please delete resources using this category first.")
            Return
        End If

        If MsgBox("Do you want to delete Resource Category " & rc.Name & "?", vbYesNo) = MsgBoxResult.No Then
            Return
        End If

        _scheduler.DeleteResourceCategory(rc)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ResourceCatForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        UpdateRowColor()
    End Sub

    Private Sub grdResourceCat_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdResourceCat.CellDoubleClick
        EditResourceCat()
    End Sub

    Private Sub btnSetToDefault_Click(sender As Object, e As EventArgs) Handles btnSetToDefault.Click
        If cboDefaultResourceCat.SelectedItem IsNot Nothing Then
            Dim rc As ResourceCategory = cboDefaultResourceCat.SelectedItem
            If MsgBox("Do you want to set " & rc.Name & " to default?", vbYesNo) = vbYes Then
                _scheduler.DefaultResourceCategory = rc
            End If
        End If
    End Sub

End Class