Public Class principal

    Private Sub BtnSesion_Click(sender As Object, e As EventArgs) Handles BtnSesion.Click
        LOGIN.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        inventario.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        _6opcion.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSellNew_Click(sender As Object, e As EventArgs) Handles BtnSellNew.Click
        VentaN.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        historialVentas.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        gastos.Show()
        Me.Close()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        historialVentas.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        shopConfig.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        historialVentas.Show()
        Me.Close()
    End Sub

    Private Sub principal_Load(sender As Object, e As EventArgs)

        ' Cargar el nombre de usuario al iniciar el formulario
        Dim userName As String = Login.TxtUsr.Text.Trim()
        If Not String.IsNullOrEmpty(userName) Then
            LblUser.Text = "Bienvenid@ " & userName.ToUpper()
        Else
            LblUser.Text = "Bienvenid@"
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        _8historialClientes.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click_1(sender As Object, e As EventArgs) Handles PictureBox5.Click
        _7historialInventario.Show()
        Me.Hide()
    End Sub
End Class