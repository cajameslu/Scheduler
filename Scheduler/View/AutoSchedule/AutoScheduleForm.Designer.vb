﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoScheduleForm
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
		Me.btnClose = New System.Windows.Forms.Button()
		Me.btnAutoSchedule = New System.Windows.Forms.Button()
		Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
		Me.Label6 = New System.Windows.Forms.Label()
        Me.lstResourceCat = New MyListBox()
        Me.lstDays = New MyListBox()
        Me.Label5 = New System.Windows.Forms.Label()
		Me.cboResourceNo = New System.Windows.Forms.ComboBox()
		Me.dtpStatisticStartDate = New System.Windows.Forms.DateTimePicker()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(20, 230)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(142, 13)
		Me.Label4.TabIndex = 18
		Me.Label4.Text = "Exclude Resource Category:"
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(340, 110)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(100, 23)
		Me.btnClose.TabIndex = 17
		Me.btnClose.Text = "Close"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'btnAutoSchedule
		'
		Me.btnAutoSchedule.Location = New System.Drawing.Point(340, 70)
		Me.btnAutoSchedule.Name = "btnAutoSchedule"
		Me.btnAutoSchedule.Size = New System.Drawing.Size(100, 23)
		Me.btnAutoSchedule.TabIndex = 16
		Me.btnAutoSchedule.Text = "Auto Schedule"
		Me.btnAutoSchedule.UseVisualStyleBackColor = True
		'
		'dtpStartDate
		'
		Me.dtpStartDate.Location = New System.Drawing.Point(90, 100)
		Me.dtpStartDate.Name = "dtpStartDate"
		Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpStartDate.TabIndex = 15
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(22, 104)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(58, 13)
		Me.Label3.TabIndex = 13
		Me.Label3.Text = "Start Date:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(20, 70)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(173, 13)
		Me.Label2.TabIndex = 12
		Me.Label2.Text = "Auto Schedule Configuration:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(20, 170)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(124, 13)
		Me.Label1.TabIndex = 11
		Me.Label1.Text = "# of Resources Per Day:"
		'
		'dtpEndDate
		'
		Me.dtpEndDate.Location = New System.Drawing.Point(90, 130)
		Me.dtpEndDate.Name = "dtpEndDate"
		Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpEndDate.TabIndex = 23
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(22, 134)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(55, 13)
		Me.Label6.TabIndex = 22
		Me.Label6.Text = "End Date:"
		'
		'lstResourceCat
		'
		Me.lstResourceCat.FormattingEnabled = True
		Me.lstResourceCat.Location = New System.Drawing.Point(90, 250)
		Me.lstResourceCat.Name = "lstResourceCat"
		Me.lstResourceCat.Size = New System.Drawing.Size(200, 95)
		Me.lstResourceCat.TabIndex = 24
		'
		'lstDays
		'
		Me.lstDays.FormattingEnabled = True
		Me.lstDays.Location = New System.Drawing.Point(90, 380)
		Me.lstDays.Name = "lstDays"
		Me.lstDays.Size = New System.Drawing.Size(200, 95)
		Me.lstDays.TabIndex = 26
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(20, 360)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(75, 13)
		Me.Label5.TabIndex = 25
		Me.Label5.Text = "Exclude Days:"
		'
		'cboResourceNo
		'
		Me.cboResourceNo.FormattingEnabled = True
		Me.cboResourceNo.Location = New System.Drawing.Point(90, 190)
		Me.cboResourceNo.Name = "cboResourceNo"
		Me.cboResourceNo.Size = New System.Drawing.Size(200, 21)
		Me.cboResourceNo.TabIndex = 27
		'
		'dtpStatisticStartDate
		'
		Me.dtpStatisticStartDate.Location = New System.Drawing.Point(90, 30)
		Me.dtpStatisticStartDate.Name = "dtpStatisticStartDate"
		Me.dtpStatisticStartDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpStatisticStartDate.TabIndex = 29
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(20, 10)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(98, 13)
		Me.Label7.TabIndex = 28
		Me.Label7.Text = "Statistic Start Date:"
		'
		'AutoScheduleForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(460, 493)
		Me.Controls.Add(Me.dtpStatisticStartDate)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.cboResourceNo)
		Me.Controls.Add(Me.lstDays)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.lstResourceCat)
		Me.Controls.Add(Me.dtpEndDate)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.btnAutoSchedule)
		Me.Controls.Add(Me.dtpStartDate)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AutoScheduleForm"
		Me.Text = "Auto Schedule"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents btnAutoSchedule As System.Windows.Forms.Button
	Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lstResourceCat As MyListBox
    Friend WithEvents lstDays As MyListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents cboResourceNo As System.Windows.Forms.ComboBox
	Friend WithEvents dtpStatisticStartDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
