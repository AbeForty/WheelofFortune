﻿Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class dlgSelectPack
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cboPack.SelectedItem <> Nothing Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            WheelController.packName = cboPack.SelectedItem.ToString
            frmMain.Close()
            IntroScreen.Show()
            Me.Close()
        Else
            MsgBox("Please select a pack before clicking OK.", vbExclamation, "Wheel of Fortune")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub getPackNames()
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\WheelPuzzles.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM PUZZLE"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            If Not cboPack.Items.Contains(Trim(rdr("PackName").ToString)) Then
                cboPack.Items.Add(Trim(rdr("PackName")).ToString)
            Else
            End If
        Loop
        connPuzzle.Close()
    End Sub
    Private Sub dlgSelectPack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPackNames()
    End Sub
End Class
