<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduledDayListView
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
        Me.grdDays = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboResource = New MyComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.cboWeekDay = New MyComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtResourceNotes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.grdDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDays
        '
        Me.grdDays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDays.Location = New System.Drawing.Point(10, 80)
        Me.grdDays.Name = "grdDays"
        Me.grdDays.Size = New System.Drawing.Size(445, 298)
        Me.grdDays.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(210, 388)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboResource
        '
        Me.cboResource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboResource.FormattingEnabled = True
        Me.cboResource.Location = New System.Drawing.Point(70, 10)
        Me.cboResource.Name = "cboResource"
        Me.cboResource.Size = New System.Drawing.Size(155, 21)
        Me.cboResource.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Resource:"
        '
        'dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(300, 40)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(155, 20)
        Me.dtpEnd.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "End Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Start Date:"
        '
        'dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(70, 40)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(155, 20)
        Me.dtpStart.TabIndex = 9
        '
        'cboWeekDay
        '
        Me.cboWeekDay.FormattingEnabled = True
        Me.cboWeekDay.Location = New System.Drawing.Point(300, 10)
        Me.cboWeekDay.Name = "cboWeekDay"
        Me.cboWeekDay.Size = New System.Drawing.Size(155, 21)
        Me.cboWeekDay.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(240, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Day:"
        '
        'txtResourceNotes
        '
        Me.txtResourceNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResourceNotes.Location = New System.Drawing.Point(475, 80)
        Me.txtResourceNotes.Multiline = True
        Me.txtResourceNotes.Name = "txtResourceNotes"
        Me.txtResourceNotes.ReadOnly = True
        Me.txtResourceNotes.Size = New System.Drawing.Size(220, 301)
        Me.txtResourceNotes.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(472, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Resource Notes:"
        '
        'ScheduledDayListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 426)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtResourceNotes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboWeekDay)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboResource)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdDays)
        Me.Name = "ScheduledDayListView"
        Me.Text = "Scheduled Days"
        CType(Me.grdDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDays As System.Windows.Forms.DataGridView
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents cboResource As MyComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboWeekDay As MyComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents txtResourceNotes As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
