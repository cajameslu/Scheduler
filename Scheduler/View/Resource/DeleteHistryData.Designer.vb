<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteHistryData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.dtpStart = New System.Windows.Forms.DateTimePicker()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnCountScheduledDays = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(17, 19)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(267, 13)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "Schedule data older than following date will be deleted:"
		'
		'dtpStart
		'
		Me.dtpStart.Location = New System.Drawing.Point(20, 50)
		Me.dtpStart.Name = "dtpStart"
		Me.dtpStart.Size = New System.Drawing.Size(155, 20)
		Me.dtpStart.TabIndex = 8
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(200, 100)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 23)
		Me.btnDelete.TabIndex = 12
		Me.btnDelete.Text = "Delete Data"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnCountScheduledDays
		'
		Me.btnCountScheduledDays.Location = New System.Drawing.Point(20, 100)
		Me.btnCountScheduledDays.Name = "btnCountScheduledDays"
		Me.btnCountScheduledDays.Size = New System.Drawing.Size(130, 23)
		Me.btnCountScheduledDays.TabIndex = 13
		Me.btnCountScheduledDays.Text = "Count Scheduled Days"
		Me.btnCountScheduledDays.UseVisualStyleBackColor = True
		'
		'DeleteHistryData
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(322, 143)
		Me.Controls.Add(Me.btnCountScheduledDays)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.dtpStart)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "DeleteHistryData"
		Me.Text = "Delete Histrical Data"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents btnCountScheduledDays As System.Windows.Forms.Button
End Class
