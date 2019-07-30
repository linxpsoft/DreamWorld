﻿

Imports System.IO

Public Class FormBackupCheckboxes

#Region "ScreenSize"
    'The following detects  the location of the form in screen coordinates
    Private _screenPosition As ScreenPos

    Public Property ScreenPosition As ScreenPos
        Get
            Return _screenPosition
        End Get
        Set(value As ScreenPos)
            _screenPosition = value
        End Set
    End Property
    Private Handler As New EventHandler(AddressOf Resize_page)
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


    Private Sub FormCritical_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.HelpOnce("Backup Manually")

        TextBox1.BackColor = Me.BackColor
        ' init the scrolling text box
        TextBox1.SelectionStart = 0
        TextBox1.ScrollToCaret()
        TextBox1.SelectionStart = TextBox1.Text.Length
        TextBox1.ScrollToCaret()

        If Not Form1.CheckMysql Then
            MySqlCheckBox.Enabled = True
            MySqlCheckBox.Checked = True
        Else
            MySqlCheckBox.Enabled = False
            MySqlCheckBox.Checked = False
        End If

        If Form1.PropMySetting.FsAssetsEnabled Then
            FSAssetsCheckBox.Enabled = True
            FSAssetsCheckBox.Checked = True
        Else
            FSAssetsCheckBox.Enabled = False
            FSAssetsCheckBox.Checked = False
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)
        Dim ln As Integer = TextBox1.Text.Length
        TextBox1.SelectionStart = ln
        TextBox1.ScrollToCaret()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Foldername = "Full_backup" + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss", Form1.Usa)   ' Set default folder
        Dim Dest As String
        If Form1.PropMySetting.BackupFolder = "AutoBackup" Then
            Dest = Form1.PropMySetting.Myfolder + "\OutworldzFiles\AutoBackup\" + Foldername
        Else
            Dest = Form1.PropMySetting.BackupFolder + "\" + Foldername
        End If
        Try
            If RegionCheckBox.Checked Then
                My.Computer.FileSystem.CreateDirectory(Dest)
                My.Computer.FileSystem.CreateDirectory(Dest + "\Opensim_bin_Regions")
                Print("Backing up Regions Folder")
                cpy(Form1.PropMySetting.Myfolder + "\OutworldzFiles\Opensim\bin\Regions", Dest + "\Opensim_bin_Regions")
                Application.DoEvents()
            End If

            If MySqlCheckBox.Checked Then
                My.Computer.FileSystem.CreateDirectory(Dest)
                My.Computer.FileSystem.CreateDirectory(Dest + "\Mysql_Data")
                Print("Backing up MySql\Data Folder")
                cpy(Form1.PropMySetting.Myfolder + "\OutworldzFiles\Mysql\Data\", Dest + "\Mysql_Data")
                Application.DoEvents()
            End If

            If FSAssetsCheckBox.Checked Then
                My.Computer.FileSystem.CreateDirectory(Dest)
                My.Computer.FileSystem.CreateDirectory(Dest + "\FSAssets")

                Dim folder As String
                If Form1.PropMySetting.BaseDirectory = "./fsassets" Then
                    folder = Form1.PropMySetting.OpensimBinPath & "bin\FSAssets"
                Else
                    folder = Form1.PropMySetting.BaseDirectory
                End If
                Print("Backing up FSAssets Folder")
                Cpy(folder, Dest + "\FSAssets")
                Application.DoEvents()
            End If

            If CustomCheckBox.Checked Then
                My.Computer.FileSystem.CreateDirectory(Dest)
                My.Computer.FileSystem.CreateDirectory(Dest + "\Opensim_WifiPages-Custom")
                My.Computer.FileSystem.CreateDirectory(Dest + "\Opensim_bin_WifiPages-Custom")
                Print("Backing up Wifi Folders")
                cpy(Form1.PropMySetting.Myfolder + "\OutworldzFiles\Opensim\WifiPages\", Dest + "\Opensim_WifiPages-Custom")
                cpy(Form1.PropMySetting.Myfolder + "\OutworldzFiles\Opensim\bin\WifiPages\", Dest + "\Opensim_bin_WifiPages-Custom")
                Application.DoEvents()
            End If

            If SettingsBox.Checked Then
                Print("Backing up Settings")
                My.Computer.FileSystem.CopyFile(Form1.PropMySetting.Myfolder + "\OutworldzFiles\Settings.ini", Dest + "\Settings.ini")
            End If
            Print("Finished with backup at " + Dest)
        Catch ex As IO.IOException
            MsgBox("Something went wrong: " + ex.Message)
        End Try

        DialogResult = DialogResult.OK

    End Sub
    Private Sub Print(Value As String)

        TextBox1.Text = TextBox1.Text & vbCrLf & Value
        Trim()

    End Sub

    Private Sub Trim()
        If TextBox1.Text.Length > TextBox1.MaxLength - 1000 Then
            TextBox1.Text = Mid(TextBox1.Text, 14000)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click

        Form1.Help("Backup Manually")

    End Sub


    Public Sub Cpy(ByVal sourcePath As String, ByVal destinationPath As String)

        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                Print(fileSystemInfo.Name)
                CpyFile(fileSystemInfo.FullName, destinationFileName)
            Else
                ' Recursively call the mothod to copy all the nested folders
                Cpy(fileSystemInfo.FullName, destinationFileName)
            End If

        Next
    End Sub

    Private Sub CpyFile(From As String, Dest As String)

        If From.EndsWith("Opensim.ini") Then Return
        If From.EndsWith("OpenSim.log") Then Return
        If From.EndsWith("OpenSimStats.log") Then Return
        If From.EndsWith("PID.pid") Then Return
        If From.EndsWith("DataSnapshot") Then Return

        'Create the file stream for the source file
        Dim streamRead As New System.IO.FileStream(From, System.IO.FileMode.Open)
        'Create the file stream for the destination file
        Dim streamWrite As New System.IO.FileStream(Dest, System.IO.FileMode.Create)
        'Determine the size in bytes of the source file (-1 as our position starts at 0)
        Dim lngLen As Long = streamRead.Length - 1
        Dim byteBuffer(1048576) As Byte   'our stream buffer
        Dim intBytesRead As Integer    'number of bytes read

        While streamRead.Position < lngLen    'keep streaming until EOF
            'Read from the Source
            intBytesRead = (streamRead.Read(byteBuffer, 0, 1048576))
            'Write to the Target
            streamWrite.Write(byteBuffer, 0, intBytesRead)

            Application.DoEvents()    'do it
        End While

        'Clean up 
        streamWrite.Flush()
        streamWrite.Close()
        streamRead.Close()


    End Sub

End Class