<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
		Me.components = New System.ComponentModel.Container()
		Me.grdResource = New System.Windows.Forms.DataGridView()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.btnResourceCategoryManager = New System.Windows.Forms.Button()
		Me.btnHighlight = New System.Windows.Forms.Button()
		Me.btnDeleteResource = New System.Windows.Forms.Button()
		Me.btnEditResource = New System.Windows.Forms.Button()
        Me.cboWeekDay = New MyComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
		Me.btnAddResource = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
		Me.dtpStart = New System.Windows.Forms.DateTimePicker()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.mnuMain = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNew = New System.Windows.Forms.ToolStripMenuItem()
		Me.miOpen = New System.Windows.Forms.ToolStripMenuItem()
		Me.miSave = New System.Windows.Forms.ToolStripMenuItem()
		Me.miSaveAs = New System.Windows.Forms.ToolStripMenuItem()
		Me.miClose = New System.Windows.Forms.ToolStripMenuItem()
		Me.miQuit = New System.Windows.Forms.ToolStripMenuItem()
		Me.UtilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.miDeleteHistoricalData = New System.Windows.Forms.ToolStripMenuItem()
		Me.miManageResourceCategory = New System.Windows.Forms.ToolStripMenuItem()
		Me.miScheduledDaysGridView = New System.Windows.Forms.ToolStripMenuItem()
		Me.dsScheduler = New System.Windows.Forms.BindingSource(Me.components)
		Me.monthView1 = New MonthView()
		CType(Me.grdResource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.mnuMain.SuspendLayout()
		CType(Me.dsScheduler, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'grdResource
		'
		Me.grdResource.AllowUserToAddRows = False
		Me.grdResource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
				  Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grdResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdResource.Location = New System.Drawing.Point(10, 120)
		Me.grdResource.Name = "grdResource"
		Me.grdResource.Size = New System.Drawing.Size(495, 462)
		Me.grdResource.TabIndex = 0
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnResourceCategoryManager)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnHighlight)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnDeleteResource)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnEditResource)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cboWeekDay)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddResource)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
		Me.SplitContainer1.Panel1.Controls.Add(Me.dtpEnd)
		Me.SplitContainer1.Panel1.Controls.Add(Me.dtpStart)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.grdResource)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.AutoScroll = True
		Me.SplitContainer1.Panel2.AutoScrollMinSize = New System.Drawing.Size(500, 500)
		Me.SplitContainer1.Panel2.Controls.Add(Me.monthView1)
		Me.SplitContainer1.Size = New System.Drawing.Size(1066, 620)
		Me.SplitContainer1.SplitterDistance = 513
		Me.SplitContainer1.TabIndex = 1
		'
		'btnResourceCategoryManager
		'
		Me.btnResourceCategoryManager.Location = New System.Drawing.Point(300, 60)
		Me.btnResourceCategoryManager.Name = "btnResourceCategoryManager"
		Me.btnResourceCategoryManager.Size = New System.Drawing.Size(150, 23)
		Me.btnResourceCategoryManager.TabIndex = 14
		Me.btnResourceCategoryManager.Text = "Resource Category Manager"
		Me.btnResourceCategoryManager.UseVisualStyleBackColor = True
		'
		'btnHighlight
		'
		Me.btnHighlight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnHighlight.Location = New System.Drawing.Point(290, 592)
		Me.btnHighlight.Name = "btnHighlight"
		Me.btnHighlight.Size = New System.Drawing.Size(120, 23)
		Me.btnHighlight.TabIndex = 13
		Me.btnHighlight.Text = "Highlight in Schedule"
		Me.btnHighlight.UseVisualStyleBackColor = True
		'
		'btnDeleteResource
		'
		Me.btnDeleteResource.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnDeleteResource.Location = New System.Drawing.Point(170, 592)
		Me.btnDeleteResource.Name = "btnDeleteResource"
		Me.btnDeleteResource.Size = New System.Drawing.Size(75, 23)
		Me.btnDeleteResource.TabIndex = 11
		Me.btnDeleteResource.Text = "Delete Resource"
		Me.btnDeleteResource.UseVisualStyleBackColor = True
		'
		'btnEditResource
		'
		Me.btnEditResource.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnEditResource.Location = New System.Drawing.Point(90, 592)
		Me.btnEditResource.Name = "btnEditResource"
		Me.btnEditResource.Size = New System.Drawing.Size(75, 23)
		Me.btnEditResource.TabIndex = 10
		Me.btnEditResource.Text = "Edit Resource"
		Me.btnEditResource.UseVisualStyleBackColor = True
		'
		'cboWeekDay
		'
		Me.cboWeekDay.FormattingEnabled = True
		Me.cboWeekDay.Location = New System.Drawing.Point(70, 60)
		Me.cboWeekDay.Name = "cboWeekDay"
		Me.cboWeekDay.Size = New System.Drawing.Size(155, 21)
		Me.cboWeekDay.TabIndex = 9
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(7, 64)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(52, 13)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "Count by:"
		'
		'btnAddResource
		'
		Me.btnAddResource.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnAddResource.Location = New System.Drawing.Point(10, 592)
		Me.btnAddResource.Name = "btnAddResource"
		Me.btnAddResource.Size = New System.Drawing.Size(75, 23)
		Me.btnAddResource.TabIndex = 7
		Me.btnAddResource.Text = "Add Resource"
		Me.btnAddResource.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(7, 9)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(78, 13)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Statistic Dates:"
		'
		'dtpEnd
		'
		Me.dtpEnd.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.dsScheduler, "StatisticEndDate", True))
		Me.dtpEnd.Location = New System.Drawing.Point(300, 30)
		Me.dtpEnd.Name = "dtpEnd"
		Me.dtpEnd.Size = New System.Drawing.Size(155, 20)
		Me.dtpEnd.TabIndex = 5
		'
		'dtpStart
		'
		Me.dtpStart.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.dsScheduler, "StatisticStartDate", True))
		Me.dtpStart.Location = New System.Drawing.Point(70, 30)
		Me.dtpStart.Name = "dtpStart"
		Me.dtpStart.Size = New System.Drawing.Size(155, 20)
		Me.dtpStart.TabIndex = 4
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(243, 33)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(55, 13)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "End Date:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(7, 34)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(58, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Start Date:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(7, 100)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(75, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Resource List:"
		'
		'mnuMain
		'
		Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilToolStripMenuItem})
		Me.mnuMain.Location = New System.Drawing.Point(0, 0)
		Me.mnuMain.Name = "mnuMain"
		Me.mnuMain.Size = New System.Drawing.Size(1066, 24)
		Me.mnuMain.TabIndex = 8
		Me.mnuMain.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNew, Me.miOpen, Me.miSave, Me.miSaveAs, Me.miClose, Me.miQuit})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
		Me.FileToolStripMenuItem.Text = "Schedule"
		'
		'miNew
		'
		Me.miNew.Name = "miNew"
		Me.miNew.Size = New System.Drawing.Size(112, 22)
		Me.miNew.Text = "New"
		'
		'miOpen
		'
		Me.miOpen.Name = "miOpen"
		Me.miOpen.Size = New System.Drawing.Size(112, 22)
		Me.miOpen.Text = "Open"
		'
		'miSave
		'
		Me.miSave.Name = "miSave"
		Me.miSave.Size = New System.Drawing.Size(112, 22)
		Me.miSave.Text = "Save"
		'
		'miSaveAs
		'
		Me.miSaveAs.Name = "miSaveAs"
		Me.miSaveAs.Size = New System.Drawing.Size(112, 22)
		Me.miSaveAs.Text = "Save as"
		'
		'miClose
		'
		Me.miClose.Name = "miClose"
		Me.miClose.Size = New System.Drawing.Size(112, 22)
		Me.miClose.Text = "Close"
		'
		'miQuit
		'
		Me.miQuit.Name = "miQuit"
		Me.miQuit.Size = New System.Drawing.Size(112, 22)
		Me.miQuit.Text = "Quit"
		'
		'UtilToolStripMenuItem
		'
		Me.UtilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDeleteHistoricalData, Me.miManageResourceCategory, Me.miScheduledDaysGridView})
		Me.UtilToolStripMenuItem.Name = "UtilToolStripMenuItem"
		Me.UtilToolStripMenuItem.Size = New System.Drawing.Size(34, 20)
		Me.UtilToolStripMenuItem.Text = "Util"
		'
		'miDeleteHistoricalData
		'
		Me.miDeleteHistoricalData.Name = "miDeleteHistoricalData"
		Me.miDeleteHistoricalData.Size = New System.Drawing.Size(212, 22)
		Me.miDeleteHistoricalData.Text = "Delete Historical Data"
		'
		'miManageResourceCategory
		'
		Me.miManageResourceCategory.Name = "miManageResourceCategory"
		Me.miManageResourceCategory.Size = New System.Drawing.Size(212, 22)
		Me.miManageResourceCategory.Text = "Resource Category Manager"
		'
		'miScheduledDaysGridView
		'
		Me.miScheduledDaysGridView.Name = "miScheduledDaysGridView"
		Me.miScheduledDaysGridView.Size = New System.Drawing.Size(212, 22)
		Me.miScheduledDaysGridView.Text = "Scheduled Days List View"
		'
		'dsScheduler
		'
		Me.dsScheduler.DataSource = GetType(Scheduler)
		'
		'monthView1
		'
		Me.monthView1.AutoScroll = True
		Me.monthView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.monthView1.Location = New System.Drawing.Point(0, 0)
		Me.monthView1.MinimumSize = New System.Drawing.Size(500, 500)
		Me.monthView1.Name = "monthView1"
		Me.monthView1.Scheduler = Nothing
		Me.monthView1.SelectedMonth = Nothing
		Me.monthView1.Size = New System.Drawing.Size(549, 620)
		Me.monthView1.TabIndex = 1
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1066, 644)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.mnuMain)
		Me.Name = "MainForm"
		Me.Text = "Scheduler"
		CType(Me.grdResource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.mnuMain.ResumeLayout(False)
		Me.mnuMain.PerformLayout()
		CType(Me.dsScheduler, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents grdResource As System.Windows.Forms.DataGridView
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents monthView1 As MonthView
	Friend WithEvents dtpEnd As DateTimePicker
	Friend WithEvents dtpStart As DateTimePicker
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents btnAddResource As Button
	Friend WithEvents dsScheduler As BindingSource
	Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miOpen As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miSave As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miNew As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miSaveAs As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miClose As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboWeekDay As MyComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents btnDeleteResource As System.Windows.Forms.Button
	Friend WithEvents btnEditResource As System.Windows.Forms.Button
	Friend WithEvents btnHighlight As System.Windows.Forms.Button
	Friend WithEvents UtilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miDeleteHistoricalData As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miManageResourceCategory As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miScheduledDaysGridView As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents btnResourceCategoryManager As System.Windows.Forms.Button
End Class
