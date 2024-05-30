Imports System.IO

Module Setting

    Public Sub LoadGambar()
        If Directory.Exists("Images/Theme0") Then
            Form1.PictureBox10.BackgroundImage = Image.FromFile("Images/Theme0/x.jpg")
            Form1.PictureBox10.BackgroundImageLayout = ImageLayout.Stretch

            Form1.PictureBox11.BackgroundImage = Image.FromFile("Images/Theme0/o.png")
            Form1.PictureBox11.BackgroundImageLayout = ImageLayout.Stretch

            Form1.player1_status.BackgroundImage = Image.FromFile("Images/Theme0/check.jpg")
            Form1.player1_status.BackgroundImageLayout = ImageLayout.Stretch

        Else
            MsgBox("DIrectory is not found. Please check your program directory")
        End If

    End Sub

    Public Sub InitProperty(Form As Form1)
        AddHandler Form.PictureBox1.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox2.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox3.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox4.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox5.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox6.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox7.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox8.Click, AddressOf Form.PictureBox_Click
        AddHandler Form.PictureBox9.Click, AddressOf Form.PictureBox_Click

        Form.PictureBox1.Tag = "0,0"
        Form.PictureBox2.Tag = "0,1"
        Form.PictureBox3.Tag = "0,2"
        Form.PictureBox4.Tag = "1,0"
        Form.PictureBox5.Tag = "1,1"
        Form.PictureBox6.Tag = "1,2"
        Form.PictureBox7.Tag = "2,0"
        Form.PictureBox8.Tag = "2,1"
        Form.PictureBox9.Tag = "2,2"
    End Sub

End Module
