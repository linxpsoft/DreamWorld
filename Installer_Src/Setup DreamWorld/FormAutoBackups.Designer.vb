﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAutoBackups
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAutoBackups))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AutoBackupHelp = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BaseFolder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AutoBackupKeepFilesForDays = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AutoBackupInterval = New System.Windows.Forms.ComboBox()
        Me.AutoBackup = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServerTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullSQLBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.AutoBackupHelp)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.BaseFolder)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.AutoBackupKeepFilesForDays)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.AutoBackupInterval)
        Me.GroupBox3.Controls.Add(Me.AutoBackup)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 37)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 184)
        Me.GroupBox3.TabIndex = 1863
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Backup"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Outworldz.My.Resources.Resources.folder
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(191, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 33)
        Me.PictureBox1.TabIndex = 1858
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Click to change the folder")
        '
        'AutoBackupHelp
        '
        Me.AutoBackupHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.AutoBackupHelp.Location = New System.Drawing.Point(93, 9)
        Me.AutoBackupHelp.Name = "AutoBackupHelp"
        Me.AutoBackupHelp.Size = New System.Drawing.Size(28, 32)
        Me.AutoBackupHelp.TabIndex = 1857
        Me.AutoBackupHelp.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Backup Folder"
        '
        'BaseFolder
        '
        Me.BaseFolder.Location = New System.Drawing.Point(9, 133)
        Me.BaseFolder.Name = "BaseFolder"
        Me.BaseFolder.Size = New System.Drawing.Size(176, 20)
        Me.BaseFolder.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.BaseFolder, "Normally set to ""AutoBackup"" folder in OutworldzFiles.  Click to change the folde" &
        "r")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Keep for Days"
        '
        'AutoBackupKeepFilesForDays
        '
        Me.AutoBackupKeepFilesForDays.Location = New System.Drawing.Point(125, 85)
        Me.AutoBackupKeepFilesForDays.Name = "AutoBackupKeepFilesForDays"
        Me.AutoBackupKeepFilesForDays.Size = New System.Drawing.Size(47, 20)
        Me.AutoBackupKeepFilesForDays.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.AutoBackupKeepFilesForDays, "How long to keep the backups. After this time in days, the oldest get deleted.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Interval:"
        '
        'AutoBackupInterval
        '
        Me.AutoBackupInterval.AutoCompleteCustomSource.AddRange(New String() {"1 Hour", "4 Hour", "12 Hour", "Daily", "Weekly"})
        Me.AutoBackupInterval.FormattingEnabled = True
        Me.AutoBackupInterval.Items.AddRange(New Object() {"Hourly", "12 Hour", "Daily", "2 days", " 3 days", "4 days", "5 days", "6 days", "Weekly"})
        Me.AutoBackupInterval.Location = New System.Drawing.Point(80, 55)
        Me.AutoBackupInterval.Name = "AutoBackupInterval"
        Me.AutoBackupInterval.Size = New System.Drawing.Size(121, 21)
        Me.AutoBackupInterval.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.AutoBackupInterval, "How long Openim runs before an Auto backup occurs")
        '
        'AutoBackup
        '
        Me.AutoBackup.AutoSize = True
        Me.AutoBackup.Location = New System.Drawing.Point(22, 24)
        Me.AutoBackup.Name = "AutoBackup"
        Me.AutoBackup.Size = New System.Drawing.Size(65, 17)
        Me.AutoBackup.TabIndex = 1
        Me.AutoBackup.Text = "Enabled"
        Me.ToolTip1.SetToolTip(Me.AutoBackup, "If enabled, Openim will save OARS  after running this long")
        Me.AutoBackup.UseVisualStyleBackColor = True
        '
        'MenuStrip2
        '
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem30, Me.BackupToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(278, 28)
        Me.MenuStrip2.TabIndex = 18601
        Me.MenuStrip2.Text = "0"
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerTypeToolStripMenuItem})
        Me.ToolStripMenuItem30.Image = Global.Outworldz.My.Resources.Resources.question_and_answer
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        Me.ToolStripMenuItem30.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripMenuItem30.Text = "Help"
        '
        'ServerTypeToolStripMenuItem
        '
        Me.ServerTypeToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.about
        Me.ServerTypeToolStripMenuItem.Name = "ServerTypeToolStripMenuItem"
        Me.ServerTypeToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ServerTypeToolStripMenuItem.Text = "Help"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FullSQLBackupToolStripMenuItem, Me.DataOnlyToolStripMenuItem})
        Me.BackupToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disks
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(78, 24)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'FullSQLBackupToolStripMenuItem
        '
        Me.FullSQLBackupToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_blue
        Me.FullSQLBackupToolStripMenuItem.Name = "FullSQLBackupToolStripMenuItem"
        Me.FullSQLBackupToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.FullSQLBackupToolStripMenuItem.Text = "Backup Data Files"
        '
        'DataOnlyToolStripMenuItem
        '
        Me.DataOnlyToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_yellow
        Me.DataOnlyToolStripMenuItem.Name = "DataOnlyToolStripMenuItem"
        Me.DataOnlyToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.DataOnlyToolStripMenuItem.Text = "Export .SQL file"
        '
        'FormAutoBackups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(278, 242)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormAutoBackups"
        Me.Text = "Auto Backups"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents AutoBackupHelp As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BaseFolder As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents AutoBackupKeepFilesForDays As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents AutoBackupInterval As ComboBox
    Friend WithEvents AutoBackup As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem30 As ToolStripMenuItem
    Friend WithEvents ServerTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FullSQLBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataOnlyToolStripMenuItem As ToolStripMenuItem
End Class