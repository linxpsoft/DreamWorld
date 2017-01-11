﻿Imports System.Text.RegularExpressions
Imports System.Net

Public Class DNSName

#Region "Functions"

    Private Function Getnewname()
        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?r=" + Random())
        Catch ex As Exception
            Form1.Log("Cannot get new name:" + ex.Message)
        End Try
        Return Checkname
    End Function
    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function
#End Region

#Region "Buttons"
    Private Sub DNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = "DynDNS"

        TextBox1.Text = My.Settings.DnsName

        NextNameButton.Enabled = True
        If TextBox1.Text = String.Empty Then
            RichTextBox1.Text = "Type in a name for your grid, or just press 'Next' to get a suggested name. You can also use a Dynamic DNS name."
        End If

    End Sub


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus

        If TextBox1.Text <> String.Empty Then

            TextBox1.Text = TextBox1.Text.Replace("http://", "")
            TextBox1.Text = TextBox1.Text.Replace("https://", "")
            'TextBox1.Text = Replace(TextBox1.Text, "[^\da-z\.-]+", String.Empty)

            Dim client As New System.Net.WebClient
            Dim Checkname As String = String.Empty
            Try
                Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + TextBox1.Text + "&r=" + Random())
            Catch ex As Exception
                Form1.Log("Cannot get a check of the DNS Name" + ex.Message)
            End Try
            If (Checkname = TextBox1.Text) Then
                TextBox1.Text = Checkname

            ElseIf Checkname = "USED" Then
                RichTextBox1.Text = "That name is already in use"

            End If
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        If TextBox1.Text <> String.Empty Then
            Dim client As New System.Net.WebClient

            RichTextBox1.Text = "Saving..."
            Dim Checkname As String = String.Empty
            If Not InStr(TextBox1.Text, ".") Then
                Dim pub As String
                If My.Settings.DNSPublic Then
                    pub = "1"
                Else
                    pub = "0"
                End If
                Try
                    Checkname = client.DownloadString("http://outworldz.net/dns.plx/?GridName=" + TextBox1.Text + "&Public=" + pub + "&r=" + Random())
                Catch ex As Exception
                    Form1.Log("Cannot check the DNS Name" + ex.Message)
                End Try
            End If

            Dim IP = DoGetHostAddresses(TextBox1.Text)
            Dim address As IPAddress = Nothing
            If IPAddress.TryParse(IP, address) Then
                My.Settings.DnsName = TextBox1.Text
                My.Settings.Save()
                Form1.ActualForm.DnsName.Text = TextBox1.Text
                Me.Close()
            Else
                MsgBox("DNS lookup failed for " + TextBox1.Text, vbInformation)
            End If
        Else
            My.Settings.DnsName = TextBox1.Text
            My.Settings.Save()
            Form1.ActualForm.DnsName.Text = TextBox1.Text
            Me.Close()
        End If

    End Sub

    Public Function DoGetHostAddresses(hostName As [String]) As String

        Dim ips As IPAddress()

        ips = Dns.GetHostAddresses(hostName)

        Debug.Print("GetHostAddresses(" + hostName + ") returns: ")

        Dim index As Integer
        For index = 0 To ips.Length - 1
            Debug.Print(ips(index).ToString())
            Dim str = ips(index).ToString()
            Return str
        Next index
        Return Nothing

    End Function

    Private Sub NextNameButton_Click(sender As Object, e As EventArgs) Handles NextNameButton.Click

        RichTextBox1.Text = "Busy..."
        TextBox1.Text = String.Empty
        Application.DoEvents()
        Dim newname = Getnewname()
        If newname = String.Empty Then
            RichTextBox1.Text = "Please enter a DNS name, if you have one, Or register for one at http://www.noip.com"
            NextNameButton.Enabled = False
        Else
            RichTextBox1.Text = ""
            NextNameButton.Enabled = True
            TextBox1.Text = newname
        End If

    End Sub

    Private Sub PublicBox_CheckedChanged(sender As Object, e As EventArgs) Handles PublicBox.CheckedChanged
        If PublicBox.Checked Then
            My.Settings.DNSPublic = True
        Else
            My.Settings.DNSPublic = False
        End If
    End Sub





#End Region
End Class