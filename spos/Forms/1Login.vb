Imports System.Data.SQLite

Public Class Login

    ' Función para validar el inicio de sesión y guardar el ID del usuario
    Public Function Login(usr As String, pass As String) As Boolean
        ' Consulta SQL parametrizada
        Dim query As String = "SELECT id FROM VENDEDORES WHERE usuario = @usuario AND password = @password"

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@usuario", usr)
                command.Parameters.AddWithValue("@password", pass)

                connection.Open()

                ' Usamos ExecuteReader para obtener el ID
                Dim reader As SQLiteDataReader = command.ExecuteReader()

                If reader.Read() Then
                    ' Guardamos el ID del usuario en la variable global
                    session.userid = Convert.ToInt32(reader("id"))
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function

    ' Evento para cerrar la aplicación
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Application.Exit()
    End Sub

    ' Evento para minimizar la app
    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles BtnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    ' Evento de clic en botón de login
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim user As String = TxtUsr.Text.Trim()
        Dim password As String = TxtPass.Text.Trim()

        If Login(user, password) Then
            MsgBox("¡BIENVENID@!", vbInformation, "Inicio Exitoso")

            principal.LblUser.Text = "Bienvenid@ " & user.ToUpper()
            Me.Hide()

            TxtUsr.Clear()
            TxtPass.Clear()

            principal.Show()
        Else
            MsgBox("Usuario o contraseña incorrectos", vbExclamation, "Reintentar")
            TxtUsr.Clear()
            TxtPass.Clear()
        End If
    End Sub


End Class
