<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DayBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
		Me.lblDay = New System.Windows.Forms.Label()
		Me.btnAddSelected = New System.Windows.Forms.Button()
		Me.btnRemove = New System.Windows.Forms.Button()
		Me.lstResource = New MyListBox()
		Me.SuspendLayout()
		'
		'lblDay
		'
		Me.lblDay.AutoSize = True
		Me.lblDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDay.Location = New System.Drawing.Point(3, 0)
		Me.lblDay.Name = "lblDay"
		Me.lblDay.Size = New System.Drawing.Size(36, 16)
		Me.lblDay.TabIndex = 0
		Me.lblDay.Text = "Day"
		'
		'btnAddSelected
		'
		Me.btnAddSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnAddSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnAddSelected.Location = New System.Drawing.Point(119, 50)
		Me.btnAddSelected.Name = "btnAddSelected"
		Me.btnAddSelected.Size = New System.Drawing.Size(20, 20)
		Me.btnAddSelected.TabIndex = 2
		Me.btnAddSelected.Text = ">"
		Me.btnAddSelected.UseVisualStyleBackColor = False
		'
		'btnRemove
		'
		Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRemove.Location = New System.Drawing.Point(119, 76)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(20, 20)
		Me.btnRemove.TabIndex = 3
		Me.btnRemove.Text = "<"
		Me.btnRemove.UseVisualStyleBackColor = False
		'
		'lstResource
		'
		Me.lstResource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
				  Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lstResource.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstResource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
		Me.lstResource.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstResource.FormattingEnabled = True
		Me.lstResource.HighlightColor = System.Drawing.Color.Yellow
		Me.lstResource.Location = New System.Drawing.Point(6, 48)
		Me.lstResource.Name = "lstResource"
		Me.lstResource.Size = New System.Drawing.Size(107, 52)
		Me.lstResource.TabIndex = 1
		'
		'DayBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Controls.Add(Me.btnRemove)
		Me.Controls.Add(Me.btnAddSelected)
		Me.Controls.Add(Me.lstResource)
		Me.Controls.Add(Me.lblDay)
		Me.Name = "DayBox"
		Me.Size = New System.Drawing.Size(144, 104)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

    Friend WithEvents lblDay As Label
	Friend WithEvents lstResource As MyListBox
    Friend WithEvents btnAddSelected As Button
	Friend WithEvents btnRemove As Button
End Class
