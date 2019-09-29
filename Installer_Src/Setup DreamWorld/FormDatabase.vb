﻿#Region "Copyright"

' Copyright 2014 Fred Beckhusen for www.Outworldz.com https://opensource.org/licenses/AGPL

'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software
' And associated documentation files (the "Software"), to deal in the Software without restriction,
'including without limitation the rights To use, copy, modify, merge, publish, distribute, sublicense,
'And/Or sell copies Of the Software, And To permit persons To whom the Software Is furnished To
'Do so, subject To the following conditions:

'The above copyright notice And this permission notice shall be included In all copies Or '
'substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED,
' INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR
'PURPOSE And NONINFRINGEMENT.In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE
'For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or
'OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER
'DEALINGS IN THE SOFTWARE.Imports System

#End Region

Imports System.Text.RegularExpressions

Public Class FormDatabase

    Dim initted As Boolean = False
    Dim changed As Boolean = False
    Dim DNSName As String = ""

#Region "Properties"

    Public Property Initted1 As Boolean
        Get
            Return initted
        End Get
        Set(value As Boolean)
            initted = value
        End Set
    End Property

    Public Property Changed1 As Boolean
        Get
            Return changed
        End Get
        Set(value As Boolean)
            changed = value
        End Set
    End Property

    Public Property DNSName1 As String
        Get
            Return DNSName
        End Get
        Set(value As String)
            DNSName = value
        End Set
    End Property

#End Region

#Region "ScreenSize"

    'The following detects  the location of the form in screen coordinates
    Private _screenPosition As ScreenPos

    Private Handler As New EventHandler(AddressOf Resize_page)

    Public Property ScreenPosition As ScreenPos
        Get
            Return _screenPosition
        End Get
        Set(value As ScreenPos)
            _screenPosition = value
        End Set
    End Property

    Private Sub Resize_page(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Text = "Form screen position = " + Me.Location.ToString
        ScreenPosition.SaveXY(Me.Left, Me.Top)
    End Sub

    Private Sub SetScreen()
        Me.Show()
        ScreenPosition = New ScreenPos(Me.Name)
        AddHandler ResizeEnd, Handler
        Dim xy As List(Of Integer) = ScreenPosition.GetXY()
        Me.Left = xy.Item(0)
        Me.Top = xy.Item(1)
    End Sub

#End Region

#Region "Load/Exit"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        'Database
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        RegionDbName.Text = Form1.Settings.RegionDBName
        RegionDBUsername.Text = Form1.Settings.RegionDBUsername
        RegionMySqlPassword.Text = Form1.Settings.RegionDbPassword
        RegionServer.Text = Form1.Settings.RegionServer
        MysqlRegionPort.Text = CStr(Form1.Settings.MySqlRegionDBPort)

        ' Robust DB
        RobustServer.Text = Form1.Settings.RobustServer
        RobustDbName.Text = Form1.Settings.RobustDataBaseName
        RobustDBPassword.Text = Form1.Settings.RobustPassword
        RobustDBUsername.Text = Form1.Settings.RobustUsername
        RobustDbPort.Text = Form1.Settings.MySqlRobustDBPort.ToString(Form1.Invarient)
        RobustDBPassword.UseSystemPasswordChar = True

        SetScreen()

        Initted1 = True
        Form1.HelpOnce("Database")
        Form1.HelpOnce("ServerType")
        MsgBox("Changes to this area may require special changes to MySQL. If you change these, you will probably break things. Please read the Help section bvefore making changes!", vbInformation)

    End Sub

    Private Sub Form_exit() Handles Me.Closed
        If Changed1 Then
            Form1.PropViewedSettings = True
            SaveAll()
        End If
    End Sub

    Private Sub SaveAll()

        Form1.PropViewedSettings = True
        Form1.Settings.SaveSettings()
        Changed1 = False ' do not trigger the save a second time

    End Sub

#End Region

#Region "Database"

    Private Sub RobustServer_TextChanged(sender As Object, e As EventArgs) Handles RobustServer.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RobustServer = RobustServer.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs) Handles RegionDbName.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RegionDBName = RegionDbName.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs) Handles RegionDBUsername.TextChanged
        If Not Initted1 Then Return
        Form1.Settings.RegionDBUsername = RegionDBUsername.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub DbPassword_Clicked(sender As Object, e As EventArgs) Handles RegionMySqlPassword.Click

        RegionMySqlPassword.UseSystemPasswordChar = False

    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs) Handles RegionMySqlPassword.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RegionDbPassword = RegionMySqlPassword.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles RobustDbName.TextChanged
        If Not Initted1 Then Return
        Form1.Settings.RobustDataBaseName = RobustDbName.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub RobustUsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBUsername.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RobustUsername = RobustDBUsername.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub RobustPasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBPassword.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RobustPassword = RobustDBPassword.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub RobustDbPortTextbox_click(sender As Object, e As EventArgs) Handles RobustDBPassword.Click

        RobustDBPassword.UseSystemPasswordChar = False

    End Sub

    Private Sub Database_Click(sender As Object, e As EventArgs) Handles DBHelp.Click

        Form1.Help("Database")

    End Sub

    Private Sub RobustDbPort_TextChanged(sender As Object, e As EventArgs) Handles RobustDbPort.TextChanged

        If Not Initted1 Then Return
        Dim digitsOnly As Regex = New Regex("[^\d]")
        RobustDbPort.Text = digitsOnly.Replace(RobustDbPort.Text, "")
        Form1.Settings.MySqlRobustDBPort = CInt(RobustDbPort.Text)
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles RegionServer.TextChanged

        If Not Initted1 Then Return
        Form1.Settings.RegionServer = RegionServer.Text
        Form1.Settings.SaveSettings()

    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles MysqlRegionPort.TextChanged

        If Not Initted1 Then Return
        Dim digitsOnly As Regex = New Regex("[^\d]")
        MysqlRegionPort.Text = digitsOnly.Replace(MysqlRegionPort.Text, "")

        Form1.Settings.MySqlRegionDBPort = CInt(MysqlRegionPort.Text)
        Form1.Settings.SaveSettings()

    End Sub

#End Region

#Region "Grid type"

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

        Form1.Help("Database")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim FsAssets As New FormFsAssets
        FsAssets.Show()

    End Sub

    Private Sub DatabaseSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseSetupToolStripMenuItem.Click
        Form1.Help("Database")
    End Sub

    Private Sub FullSQLBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullSQLBackupToolStripMenuItem.Click

        Dim CriticalForm = New FormBackupCheckboxes
        CriticalForm.Activate()
        CriticalForm.Visible = True

    End Sub

    Private Sub DataOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataOnlyToolStripMenuItem.Click

        Form1.BackupDB()

    End Sub

    Private Shared Sub Button2_Click(sender As Object, e As EventArgs) Handles ClearRegionTable.Click

        MysqlInterface.DeregisterRegions()

    End Sub

#End Region

End Class