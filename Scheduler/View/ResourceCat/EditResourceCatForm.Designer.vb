﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditResourceCatForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtName = New System.Windows.Forms.TextBox()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnPickColor = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 53)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(38, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Name:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 21)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(121, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Resource Category info:"
		'
		'txtName
		'
		Me.txtName.Location = New System.Drawing.Point(70, 50)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(220, 20)
		Me.txtName.TabIndex = 3
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(61, 136)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 5
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(164, 136)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 6
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnPickColor
		'
		Me.btnPickColor.Location = New System.Drawing.Point(70, 80)
		Me.btnPickColor.Name = "btnPickColor"
		Me.btnPickColor.Size = New System.Drawing.Size(160, 23)
		Me.btnPickColor.TabIndex = 7
		Me.btnPickColor.Text = "Pick a Color"
		Me.btnPickColor.UseVisualStyleBackColor = True
		'
		'EditResourceCatForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(317, 174)
		Me.Controls.Add(Me.btnPickColor)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtName)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "EditResourceCatForm"
		Me.Text = "Edit Resource Category"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtName As TextBox
	Friend WithEvents btnOK As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnPickColor As System.Windows.Forms.Button
End Class
