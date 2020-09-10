<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddResourceCatForm
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
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
		Me.Label2.Size = New System.Drawing.Size(177, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Please enter resource category info:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 85)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(34, 13)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Color:"
		'
		'txtName
		'
		Me.txtName.Location = New System.Drawing.Point(76, 46)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(200, 20)
		Me.txtName.TabIndex = 3
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(61, 136)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 5
		Me.btnOK.Text = "Add"
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
		Me.btnPickColor.Location = New System.Drawing.Point(78, 83)
		Me.btnPickColor.Name = "btnPickColor"
		Me.btnPickColor.Size = New System.Drawing.Size(160, 23)
		Me.btnPickColor.TabIndex = 8
		Me.btnPickColor.Text = "Pick a Color"
		Me.btnPickColor.UseVisualStyleBackColor = True
		'
		'AddResourceCatForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(317, 189)
		Me.Controls.Add(Me.btnPickColor)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtName)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AddResourceCatForm"
		Me.Text = "Add New Resource Category"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents txtName As TextBox
	Friend WithEvents btnOK As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnPickColor As System.Windows.Forms.Button
End Class
