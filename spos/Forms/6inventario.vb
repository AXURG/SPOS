Public Class _6opcion
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        agregar.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        _6_2baja.Show()
        Me.Close()
    End Sub

    Private Sub BtnSesion_Click(sender As Object, e As EventArgs) Handles BtnSesion.Click
        Me.Close()
        principal.Show()
    End Sub
End Class