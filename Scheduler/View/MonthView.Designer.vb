<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
		Me.cboMonth = New System.Windows.Forms.ComboBox()
		Me.rbViewMode = New System.Windows.Forms.RadioButton()
		Me.rbEditMode = New System.Windows.Forms.RadioButton()
		Me.btnAutoSchedule = New System.Windows.Forms.Button()
		Me.btnNextMonth = New System.Windows.Forms.Button()
		Me.btnPrevMonth = New System.Windows.Forms.Button()
		Me.btnClearSchedule = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'cboMonth
		'
		Me.cboMonth.FormattingEnabled = True
		Me.cboMonth.Location = New System.Drawing.Point(80, 10)
		Me.cboMonth.Name = "cboMonth"
		Me.cboMonth.Size = New System.Drawing.Size(172, 21)
		Me.cboMonth.TabIndex = 1
		'
		'rbViewMode
		'
		Me.rbViewMode.AutoSize = True
		Me.rbViewMode.Checked = True
		Me.rbViewMode.Location = New System.Drawing.Point(80, 50)
		Me.rbViewMode.Name = "rbViewMode"
		Me.rbViewMode.Size = New System.Drawing.Size(78, 17)
		Me.rbViewMode.TabIndex = 2
		Me.rbViewMode.TabStop = True
		Me.rbViewMode.Text = "View Mode"
		Me.rbViewMode.UseVisualStyleBackColor = True
		'
		'rbEditMode
		'
		Me.rbEditMode.AutoSize = True
		Me.rbEditMode.Location = New System.Drawing.Point(180, 50)
		Me.rbEditMode.Name = "rbEditMode"
		Me.rbEditMode.Size = New System.Drawing.Size(73, 17)
		Me.rbEditMode.TabIndex = 3
		Me.rbEditMode.Text = "Edit Mode"
		Me.rbEditMode.UseVisualStyleBackColor = True
		'
		'btnAutoSchedule
		'
		Me.btnAutoSchedule.Location = New System.Drawing.Point(340, 10)
		Me.btnAutoSchedule.Name = "btnAutoSchedule"
		Me.btnAutoSchedule.Size = New System.Drawing.Size(90, 23)
		Me.btnAutoSchedule.TabIndex = 4
		Me.btnAutoSchedule.Text = "Auto Schedule"
		Me.btnAutoSchedule.UseVisualStyleBackColor = True
		'
		'btnNextMonth
		'
		Me.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnNextMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNextMonth.Location = New System.Drawing.Point(260, 10)
		Me.btnNextMonth.Name = "btnNextMonth"
		Me.btnNextMonth.Size = New System.Drawing.Size(50, 23)
		Me.btnNextMonth.TabIndex = 5
		Me.btnNextMonth.Text = ">"
		Me.btnNextMonth.UseVisualStyleBackColor = True
		'
		'btnPrevMonth
		'
		Me.btnPrevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnPrevMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPrevMonth.Location = New System.Drawing.Point(20, 10)
		Me.btnPrevMonth.Name = "btnPrevMonth"
		Me.btnPrevMonth.Size = New System.Drawing.Size(50, 23)
		Me.btnPrevMonth.TabIndex = 6
		Me.btnPrevMonth.Text = "<"
		Me.btnPrevMonth.UseVisualStyleBackColor = True
		'
		'btnClearSchedule
		'
		Me.btnClearSchedule.Location = New System.Drawing.Point(440, 10)
		Me.btnClearSchedule.Name = "btnClearSchedule"
		Me.btnClearSchedule.Size = New System.Drawing.Size(90, 23)
		Me.btnClearSchedule.TabIndex = 7
		Me.btnClearSchedule.Text = "Clear Schedule"
		Me.btnClearSchedule.UseVisualStyleBackColor = True
		'
		'MonthView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.btnClearSchedule)
		Me.Controls.Add(Me.btnPrevMonth)
		Me.Controls.Add(Me.btnNextMonth)
		Me.Controls.Add(Me.btnAutoSchedule)
		Me.Controls.Add(Me.rbEditMode)
		Me.Controls.Add(Me.rbViewMode)
		Me.Controls.Add(Me.cboMonth)
		Me.MinimumSize = New System.Drawing.Size(500, 500)
		Me.Name = "MonthView"
		Me.Size = New System.Drawing.Size(584, 514)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents cboMonth As ComboBox
	Friend WithEvents rbViewMode As System.Windows.Forms.RadioButton
	Friend WithEvents rbEditMode As System.Windows.Forms.RadioButton
	Friend WithEvents btnAutoSchedule As System.Windows.Forms.Button
	Friend WithEvents btnNextMonth As System.Windows.Forms.Button
	Friend WithEvents btnPrevMonth As System.Windows.Forms.Button
	Friend WithEvents btnClearSchedule As System.Windows.Forms.Button
End Class
