Public Class Form1
    Dim playerTurn As Integer = 1
    Private gameBoard(2, 2) As Integer
    Private menit, detik As Integer

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public Sub PictureBox_Click(sender As Object, e As EventArgs)
        Dim clickedBox As PictureBox = DirectCast(sender, PictureBox)
        Dim row As Integer = CInt(clickedBox.Tag.ToString().Split(",")(0))
        Dim col As Integer = CInt(clickedBox.Tag.ToString().Split(",")(1))

        If gameBoard(row, col) = 0 Then
            If playerTurn = 1 Then
                UpdatePlayerStatus(clickedBox)
                gameBoard(row, col) = 1
                If CheckWin(1) Then
                    Timer1.Enabled = False
                    Dim ok = MessageBox.Show("Pemain 1 Menang!")
                    If ok Then
                        ResetGame()
                    End If
                Else
                    playerTurn = 2
                End If
            Else
                UpdatePlayerStatus(clickedBox)
                gameBoard(row, col) = 2
                If CheckWin(2) Then
                    Timer1.Enabled = False
                    Dim ok = MessageBox.Show("Pemain 2 Menang!")
                    If ok Then
                        ResetGame()
                    End If
                Else
                    playerTurn = 1
                End If
            End If
        End If
    End Sub

    Private Function CheckWin(player As Integer) As Boolean
        For i As Integer = 0 To 2
            If gameBoard(i, 0) = player AndAlso gameBoard(i, 1) = player AndAlso gameBoard(i, 2) = player Then
                Return True
            End If
        Next

        For i As Integer = 0 To 2
            If gameBoard(0, i) = player AndAlso gameBoard(1, i) = player AndAlso gameBoard(2, i) = player Then
                Return True
            End If
        Next

        If gameBoard(0, 0) = player AndAlso gameBoard(1, 1) = player AndAlso gameBoard(2, 2) = player Then
            Return True
        End If

        If gameBoard(0, 2) = player AndAlso gameBoard(1, 1) = player AndAlso gameBoard(2, 0) = player Then
            Return True
        End If

        Return False
    End Function

    Private Sub UpdatePlayerStatus(boxName As PictureBox)
        If playerTurn = 1 Then
            boxName.BackgroundImage = Image.FromFile("Images/Theme0/x.jpg")
            boxName.BackgroundImageLayout = ImageLayout.Stretch

            player1_status.BackgroundImage = Nothing
            player2_status.BackgroundImage = Image.FromFile("Images/Theme0/check.jpg")
            player2_status.BackgroundImageLayout = ImageLayout.Stretch

            playerTurn = 2
        ElseIf playerTurn = 2 Then
            boxName.BackgroundImage = Image.FromFile("Images/Theme0/o.png")
            boxName.BackgroundImageLayout = ImageLayout.Stretch

            player2_status.BackgroundImage = Nothing
            player1_status.BackgroundImage = Image.FromFile("Images/Theme0/check.jpg")
            player1_status.BackgroundImageLayout = ImageLayout.Stretch

            playerTurn = 1
        End If
    End Sub

    Private Sub ResetGame()
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                gameBoard(i, j) = 0
            Next
        Next

        PictureBox1.BackgroundImage = Nothing
        PictureBox2.BackgroundImage = Nothing
        PictureBox3.BackgroundImage = Nothing
        PictureBox4.BackgroundImage = Nothing
        PictureBox5.BackgroundImage = Nothing
        PictureBox6.BackgroundImage = Nothing
        PictureBox7.BackgroundImage = Nothing
        PictureBox8.BackgroundImage = Nothing
        PictureBox9.BackgroundImage = Nothing

        playerTurn = 1
        player1_status.BackgroundImage = Image.FromFile("Images/Theme0/check.jpg")
        player1_status.BackgroundImageLayout = ImageLayout.Stretch
        player2_status.BackgroundImage = Nothing

        Timer1.Enabled = False
        menit = 0
        detik = 0
        timer.Text = "00:00"
        Timer1.Enabled = True

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Setting.LoadGambar()
        Setting.InitProperty(Me)
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        ResetGame()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        detik += 1
        If detik > 59 Then
            menit += 1
            detik = 0
        End If
        timer.Text = Format(menit, "00") & ":" & Format(detik, "00")
    End Sub

    Private Sub TemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TemaToolStripMenuItem.Click
        MsgBox("Yah fitur ini masih dikembangin:(", MsgBoxStyle.OkOnly, "")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
End Class
