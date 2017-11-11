﻿Imports System.Diagnostics.Debug
Imports System.Net


Public Class Expert

#Region "Load/Exit"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        GridName.Text = My.Settings.SimName
        DNSName.Text = My.Settings.DnsName
        SplashPage.Text = My.Settings.SplashPage

        WebStats.Checked = My.Settings.WebStats


        If Form1.isRunning Then
            StatsButton.Enabled = True
        Else
            StatsButton.Enabled = False
        End If

        'passwords are asterisks
        AdminPassword.UseSystemPasswordChar = True
        GmailPassword.UseSystemPasswordChar = True
        RobustDBPassword.UseSystemPasswordChar = True

        ' ports
        AdminPassword.Text = My.Settings.Password
        AdminLast.Text = My.Settings.AdminLast
        AdminFirst.Text = My.Settings.AdminFirst

        'gods
        RegionGod.Checked = My.Settings.region_owner_is_god
        ManagerGod.Checked = My.Settings.region_manager_is_god

        'Wifi

        WifiEnabled.Checked = My.Settings.WifiEnabled
        AdminEmail.Text = My.Settings.AdminEmail
        AccountConfirmationRequired.Checked = My.Settings.AccountConfirmationRequired
        GmailPassword.Text = My.Settings.SmtpPassword
        GmailUsername.Text = My.Settings.SmtpUsername


        ' Unique ID
        UniqueId.Text = My.Settings.MachineID


        Select Case My.Settings.Physics
            Case 0 : PhysicsNone.Checked = True
            Case 1 : PhysicsODE.Checked = True
            Case 2 : PhysicsBullet.Checked = True
            Case 3 : PhysicsSeparate.Checked = True
            Case 4 : PhysicsubODE.Checked = True
            Case Else : PhysicsSeparate.Checked = True
        End Select


        'ports
        DiagnosticPort.Text = My.Settings.DiagnosticPort
        PrivatePort.Text = My.Settings.PrivatePort
        HTTPPort.Text = My.Settings.HttpPort
        DiagnosticPort.Text = My.Settings.DiagnosticPort

        'Database 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        RegionDbName.Text = My.Settings.RegionDBName
        RegionDBUsername.Text = My.Settings.RegionDBUsername
        RegionMySqlPassword.Text = My.Settings.RegionDbPassword


        ' Robust DB
        RobustDbName.Text = My.Settings.RobustMySqlName
        RobustDBPassword.Text = My.Settings.RobustMySqlPassword
        RobustDBUsername.Text = My.Settings.RobustMySqlUsername
        RobustDbPort.Text = My.Settings.MySqlPort

    End Sub
#End Region

#Region "Ports"
    Private Sub http_Port_TextChanged(sender As Object, e As EventArgs)
        My.Settings.DiagnosticPort = DiagnosticPort.Text
        My.Settings.Save()
    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
        My.Settings.Save()
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles DiagnosticPort.TextChanged
        My.Settings.DiagnosticPort = DiagnosticPort.Text
        My.Settings.Save()
    End Sub

    Private Sub HTTP_Port_TextChanged_1(sender As Object, e As EventArgs) Handles HTTPPort.TextChanged
        My.Settings.HttpPort = HTTPPort.Text
        My.Settings.Save()
    End Sub


#End Region

#Region "Wifi"
    Private Sub AdminFirst_TextChanged_2(sender As Object, e As EventArgs) Handles AdminFirst.TextChanged
        My.Settings.AdminFirst = AdminFirst.Text
        My.Settings.Save()
    End Sub

    Private Sub AdminLast_TextChanged(sender As Object, e As EventArgs) Handles AdminLast.TextChanged
        My.Settings.AdminLast = AdminLast.Text
        My.Settings.Save()
    End Sub

    Private Sub Password_click(sender As Object, e As EventArgs) Handles AdminPassword.Click
        AdminPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles AdminPassword.TextChanged
        My.Settings.Password = AdminPassword.Text
        My.Settings.Save()

        If Form1.Running Then
            Form1.ConsoleCommand(Form1.gRobustProcID, "reset user password Wifi Admin " + My.Settings.Password + "{Enter}")
        End If
    End Sub

    Private Sub TextBox1_TextChanged_3(sender As Object, e As EventArgs) Handles AdminEmail.TextChanged
        My.Settings.AdminEmail = AdminEmail.Text
        My.Settings.Save()
    End Sub

    Private Sub AccountConfirmationRequired_CheckedChanged(sender As Object, e As EventArgs) Handles AccountConfirmationRequired.CheckedChanged
        My.Settings.AccountConfirmationRequired = AccountConfirmationRequired.Checked
        My.Settings.Save()
    End Sub

    Private Sub SmtpUsername_TextChanged(sender As Object, e As EventArgs) Handles GmailUsername.TextChanged
        My.Settings.SmtpUsername = GmailUsername.Text
        My.Settings.Save()
    End Sub

    Private Sub SmtpUsername_Click(sender As Object, e As EventArgs) Handles GmailPassword.Click
        GmailPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub SmtpPassword_TextChanged(sender As Object, e As EventArgs) Handles GmailPassword.TextChanged
        My.Settings.SmtpPassword = GmailPassword.Text
        My.Settings.Save()
    End Sub

    Private Sub WifiEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles WifiEnabled.CheckedChanged
        My.Settings.WifiEnabled = WifiEnabled.Checked
        My.Settings.Save()

        If WifiEnabled.Checked Then
            AdminFirst.Enabled = True
            AdminLast.Enabled = True
            AdminPassword.Enabled = True
            AdminEmail.Enabled = True
            AccountConfirmationRequired.Enabled = True
            GmailUsername.Enabled = True
            GmailPassword.Enabled = True
        Else

            AdminFirst.Enabled = False
            AdminLast.Enabled = False
            AdminPassword.Enabled = False
            AdminEmail.Enabled = False
            AccountConfirmationRequired.Enabled = False
            GmailUsername.Enabled = False
            GmailPassword.Enabled = False
        End If

    End Sub

#End Region

#Region "Gods"

    Private Sub RegionGod_CheckedChanged(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged
        My.Settings.region_owner_is_god = RegionGod.Checked
        My.Settings.Save()
    End Sub

    Private Sub ManagerGod_CheckedChanged(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged
        My.Settings.region_manager_is_god = ManagerGod.Checked
        My.Settings.Save()
    End Sub



#End Region

#Region "Stats"

    Private Sub StatsButton_Click(sender As Object, e As EventArgs) Handles StatsButton.Click
        If Form1.isRunning And WebStats.Checked Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.HttpPort + "/SStats/"
            Process.Start(webAddress)
        Else
            Print("Opensim is not running. Cannot open the Statistics web page.")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles WebStats.CheckedChanged
        My.Settings.WebStats = WebStats.Checked
        My.Settings.Save()
        Form1.WebStatsToolStripMenuItem.Visible = WebStats.Checked
    End Sub
#End Region

#Region "Splash"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SplashPage.TextChanged
        My.Settings.SplashPage = SplashPage.Text
        My.Settings.Save()
    End Sub
#End Region

#Region "Physics"

    Private Sub PhysicsNone_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsNone.CheckedChanged
        If PhysicsNone.Checked Then
            My.Settings.Physics = 0
            My.Settings.Save()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsODE.CheckedChanged
        If PhysicsODE.Checked Then
            My.Settings.Physics = 1
            My.Settings.Save()
        End If
    End Sub

    Private Sub PhysicsBullet_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsBullet.CheckedChanged
        If PhysicsBullet.Checked Then
            My.Settings.Physics = 2
            My.Settings.Save()
        End If
    End Sub

    Private Sub PhysicsSeparate_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsSeparate.CheckedChanged
        If PhysicsSeparate.Checked Then
            My.Settings.Physics = 3
            My.Settings.Save()
        End If
    End Sub

    Private Sub PhysicsubODE_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsubODE.CheckedChanged
        If PhysicsubODE.Checked Then
            My.Settings.Physics = 4
            My.Settings.Save()
        End If
    End Sub

#End Region

#Region "DNS"

    Private Sub DNSButton_Click(sender As Object, e As EventArgs) Handles DNSButton.Click
        Dim F As New DNSName
        F.Show()
    End Sub

    Private Sub TestButton1_Click_1(sender As Object, e As EventArgs) Handles TestButton1.Click
        Dim IP = Form1.DoGetHostAddresses(DNSName.Text)
        Dim address As IPAddress = Nothing
        If IPAddress.TryParse(IP, address) Then
            MsgBox(DNSName.Text + " was resolved to " + IP)
        Else
            MsgBox("Cannot resolve " + DNSName.Text)
        End If
    End Sub

    Private Sub HypericaButton_Click(sender As Object, e As EventArgs) Handles HypericaButton.Click
        Dim webAddress As String = "http://www.hyperica.com/directory/?GridName=" + My.Settings.DnsName
        Process.Start(webAddress)
    End Sub
#End Region

#Region "Database"


    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs) Handles RegionDbName.TextChanged
        My.Settings.RegionDBName = RegionDbName.Text
        My.Settings.Save()
    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs) Handles RegionDBUsername.TextChanged
        My.Settings.RegionDBUsername = RegionDBUsername.Text
        My.Settings.Save()
    End Sub

    Private Sub DbPassword_click(sender As Object, e As EventArgs) Handles RegionMySqlPassword.Click
        RegionMySqlPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs) Handles RegionMySqlPassword.TextChanged
        My.Settings.RegionDbPassword = RegionMySqlPassword.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles RobustDbName.TextChanged
        My.Settings.RobustMySqlName = RobustDbName.Text
        My.Settings.Save()
    End Sub

    Private Sub RobustUsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBUsername.TextChanged
        My.Settings.RobustMySqlUsername = RobustDBUsername.Text
        My.Settings.Save()
    End Sub

    Private Sub RobustPasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBPassword.TextChanged
        My.Settings.RobustMySqlPassword = RobustDBPassword.Text
        My.Settings.Save()
    End Sub

    Private Sub RobustPasswordClicked(sender As Object, e As EventArgs) Handles RobustDBPassword.Click
        RobustDBPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub RobustDbPortTextbox_TextChanged(sender As Object, e As EventArgs) Handles RobustDbPort.TextChanged
        My.Settings.MySqlPort = RobustDbPort.Text
        My.Settings.Save()
    End Sub



#End Region

#Region "Help"

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles GodHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#GridGod"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles DNSHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Grid"
        Process.Start(webAddress)
    End Sub

    Private Sub UniqueId_TextChanged(sender As Object, e As EventArgs) Handles UniqueId.TextChanged
        My.Settings.MachineID = UniqueId.Text
        My.Settings.Save()
    End Sub

#End Region

End Class