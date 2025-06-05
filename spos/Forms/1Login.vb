Imports System.Data.SQLite

Public Class Login

    ' Función para validar el inicio de sesión
    Public Function Login(usr As String, pass As String) As Boolean
        ' Consulta SQL parametrizada para evitar inyección SQL
        Dim query As String = "SELECT COUNT(*) FROM vendedores WHERE nombre = @nombre AND password = @password"

        ' Usamos el módulo DBConnection para obtener la conexión
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Using command As New SQLiteCommand(query, connection)
                ' Agregamos los parámetros de forma segura
                command.Parameters.AddWithValue("@nombre", usr)
                command.Parameters.AddWithValue("@password", pass)

                ' Abrimos la conexión y ejecutamos la consulta
                connection.Open()
                Dim resultado As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' Retornamos True si las credenciales son válidas
                Return resultado > 0
            End Using
        End Using
    End Function

    ' Evento para cerrar la aplicación
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Application.Exit()
    End Sub

    'Evento para minimizar la app
    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles BtnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim user As String = TxtUsr.Text.Trim()
        Dim password As String = TxtPass.Text.Trim()


        If Login(user, password) Then
            MsgBox("¡BIENVENID@!", vbInformation, "Inicio Exitoso")

            principal.LblUser.Text = "Bienvenid@ " & user.ToUpper()
            Me.Hide()

            ' Limpiamos los campos de texto
            TxtUsr.Clear()
            TxtPass.Clear()

            ' Mostramos el formulario principal
            principal.Show()
        Else
            MsgBox("Usuario o contraseña incorrectos", vbExclamation, "Reintentar")
            TxtUsr.Clear()
            TxtPass.Clear()
        End If
    End Sub
End Class
