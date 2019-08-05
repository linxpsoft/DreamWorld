﻿Public Class FormPermissions

    Dim initted As Boolean = False

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

    'The following detects  the location of the form in screen coordinates
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

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        EnableMaxPrims.Checked = Form1.PropMySetting.Primlimits()

        'gods
        AllowGods.Checked = Form1.PropMySetting.AllowGridGods
        RegionGod.Checked = Form1.PropMySetting.RegionOwnerIsGod
        ManagerGod.Checked = Form1.PropMySetting.RegionManagerIsGod
        Clouds.Checked = Form1.PropMySetting.Clouds
        LSLCheckbox.Checked = Form1.PropMySetting.LSLHTTP()

        Dim var As Double = Form1.PropMySetting.Density

        If var = -1 Then var = 5

        Dim v = CInt(var * 10)
        If (var > 9) Then var = 9
        If (var < 0) Then var = 0
        DomainUpDown1.SelectedIndex = v

        SetScreen()
        Form1.HelpOnce("Permissions")
        initted = True

    End Sub
    Private Sub IsClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Closed

        Form1.PropViewedSettings = True
        Form1.PropMySetting.SaveSettings()

    End Sub

#Region "Subs"

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles GodHelp.Click

        Form1.Help("Permissions")

    End Sub

    Private Sub LSLCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles LSLCheckbox.CheckedChanged

        If initted Then
            Form1.PropMySetting.LSLHTTP() = LSLCheckbox.Checked
            Form1.PropMySetting.SaveSettings()
        End If

    End Sub

    Private Sub EnableMaxPrims_CheckedChanged(sender As Object, e As EventArgs) Handles EnableMaxPrims.CheckedChanged

        If initted Then
            Form1.PropMySetting.Primlimits() = EnableMaxPrims.Checked
            Form1.PropMySetting.SaveSettings()
        End If

    End Sub

    Private Sub AllowGods_CheckedChanged(sender As Object, e As EventArgs) Handles AllowGods.CheckedChanged

        If Not initted Then Return
        Form1.PropMySetting.AllowGridGods = AllowGods.Checked
        Form1.PropMySetting.SaveSettings()

    End Sub

    Private Sub RegionGod_CheckedChanged_1(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged

        If Not initted Then Return
        Form1.PropMySetting.RegionOwnerIsGod = RegionGod.Checked
        Form1.PropMySetting.SaveSettings()

    End Sub

    Private Sub ManagerGod_CheckedChanged_1(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged

        If Not initted Then Return
        Form1.PropMySetting.RegionManagerIsGod = ManagerGod.Checked
        Form1.PropMySetting.SaveSettings()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Clouds.CheckedChanged

        If Not initted Then Return
        Form1.PropMySetting.Clouds = Clouds.Checked
        Form1.PropMySetting.SaveSettings()

    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown1.SelectedItemChanged

        If initted Then
            Dim var As Double = CType(DomainUpDown1.SelectedIndex, Double)

            If var = -1 Then var = 0.5
            var = var / 10
            If (var > 1) Then var = 1
            If (var < 0) Then var = 0
            Debug.Print(var.ToString(Form1.Usa))

            Form1.PropMySetting.Density = var
            Form1.PropMySetting.SaveSettings()
        End If

    End Sub

    Private Sub DatabaseSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseSetupToolStripMenuItem.Click
        Form1.Help("Permissions")
    End Sub

#End Region

End Class