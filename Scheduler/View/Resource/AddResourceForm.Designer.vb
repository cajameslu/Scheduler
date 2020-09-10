<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddResourceForm
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
		Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtNotes = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.cboCategory = New MyComboBox()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 54)
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
		Me.Label2.Size = New System.Drawing.Size(133, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Please enter resource info:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 84)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(58, 13)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Start Date:"
		'
		'txtName
		'
		Me.txtName.Location = New System.Drawing.Point(80, 50)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(200, 20)
		Me.txtName.TabIndex = 3
		'
		'dtpStartDate
		'
		Me.dtpStartDate.Location = New System.Drawing.Point(80, 80)
		Me.dtpStartDate.Name = "dtpStartDate"
		Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
		Me.dtpStartDate.TabIndex = 4
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(320, 50)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 5
		Me.btnOK.Text = "Add"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(320, 90)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 6
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(12, 114)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(52, 13)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "Category:"
		'
		'txtNotes
		'
		Me.txtNotes.Location = New System.Drawing.Point(80, 150)
		Me.txtNotes.Multiline = True
		Me.txtNotes.Name = "txtNotes"
		Me.txtNotes.Size = New System.Drawing.Size(310, 150)
		Me.txtNotes.TabIndex = 9
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(12, 150)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(38, 13)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "Notes:"
		'
		'cboCategory
		'
		Me.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboCategory.FormattingEnabled = True
		Me.cboCategory.Location = New System.Drawing.Point(80, 110)
		Me.cboCategory.Name = "cboCategory"
		Me.cboCategory.Size = New System.Drawing.Size(200, 21)
		Me.cboCategory.TabIndex = 8
		'
		'AddResourceForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(412, 317)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.txtNotes)
		Me.Controls.Add(Me.cboCategory)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.dtpStartDate)
		Me.Controls.Add(Me.txtName)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AddResourceForm"
		Me.Text = "Add New Resource"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents txtName As TextBox
	Friend WithEvents dtpStartDate As DateTimePicker
	Friend WithEvents btnOK As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents cboCategory As MyComboBox
	Friend WithEvents txtNotes As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
