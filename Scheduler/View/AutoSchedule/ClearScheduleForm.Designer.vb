<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClearScheduleForm
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
		Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.btnClearSchedule = New System.Windows.Forms.Button()
		Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'dtpEndDate
		'
		Me.dtpEndDate.Location = New System.Drawing.Point(80, 80)
		Me.dtpEndDate.Name = "dtpEndDate"
		Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpEndDate.TabIndex = 30
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(12, 84)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(55, 13)
		Me.Label6.TabIndex = 29
		Me.Label6.Text = "End Date:"
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(330, 60)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(100, 23)
		Me.btnClose.TabIndex = 28
		Me.btnClose.Text = "Cancel"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'btnClearSchedule
		'
		Me.btnClearSchedule.Location = New System.Drawing.Point(330, 20)
		Me.btnClearSchedule.Name = "btnClearSchedule"
		Me.btnClearSchedule.Size = New System.Drawing.Size(100, 23)
		Me.btnClearSchedule.TabIndex = 27
		Me.btnClearSchedule.Text = "Clear Schedule"
		Me.btnClearSchedule.UseVisualStyleBackColor = True
		'
		'dtpStartDate
		'
		Me.dtpStartDate.Location = New System.Drawing.Point(80, 50)
		Me.dtpStartDate.Name = "dtpStartDate"
		Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpStartDate.TabIndex = 26
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 54)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(58, 13)
		Me.Label3.TabIndex = 25
		Me.Label3.Text = "Start Date:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(10, 20)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(238, 13)
		Me.Label2.TabIndex = 24
		Me.Label2.Text = "Clear Schedule between following dates:"
		'
		'ClearScheduleForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(478, 141)
		Me.Controls.Add(Me.dtpEndDate)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.btnClearSchedule)
		Me.Controls.Add(Me.dtpStartDate)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ClearScheduleForm"
		Me.Text = "Clear Schedule"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents btnClearSchedule As System.Windows.Forms.Button
	Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
