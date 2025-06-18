Imports System.Data.SQLite

Public Class agregarCliente_Fac
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtRFC.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtDireccion.Clear()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Capturar valores
        Dim nombre As String = txtNombre.Text.Trim()
        Dim rfc As String = txtRFC.Text.Trim()
        Dim ntelefono As String = txtTelefono.Text.Trim()
        Dim correo As String = txtCorreo.Text.Trim()
        Dim direccion As String = txtDireccion.Text.Trim()

        ' Validar campos vacíos
        If nombre = "" Then
            MsgBox("Por favor, ingrese el nombre completo.", MsgBoxStyle.Exclamation)
            txtNombre.Focus()
            Exit Sub
        End If
        If rfc = "" Then
            MsgBox("Por favor, ingrese el RFC.", MsgBoxStyle.Exclamation)
            txtRFC.Focus()
            Exit Sub
        End If
        If ntelefono = "" Then
            MsgBox("Por favor, ingrese el teléfono.", MsgBoxStyle.Exclamation)
            txtTelefono.Focus()
            Exit Sub
        End If
        If correo = "" Then
            MsgBox("Por favor, ingrese el correo.", MsgBoxStyle.Exclamation)
            txtCorreo.Focus()
            Exit Sub
        End If
        If direccion = "" Then
            MsgBox("Por favor, ingrese la dirección.", MsgBoxStyle.Exclamation)
            txtDireccion.Focus()
            Exit Sub
        End If

        ' Conectar a SQLite
        Using conexion As SQLiteConnection = GetConnection()
            Try
                conexion.Open()
                Dim comando As New SQLiteCommand("INSERT INTO CLIENTES (nombre, direccion, correo, ntelefono, rfc) VALUES (@nombre, @direccion, @correo, @telefono, @rfc)", conexion)
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@direccion", direccion)
                comando.Parameters.AddWithValue("@correo", correo)
                comando.Parameters.AddWithValue("@telefono", ntelefono)
                comando.Parameters.AddWithValue("@rfc", rfc)

                comando.ExecuteNonQuery()
                MsgBox("Cliente agregado correctamente.", MsgBoxStyle.Information)


                recargarrfc()
                LimpiarCampos()
                regresar()
            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub
    Private Sub recargarrfc()
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT rfc FROM clientes WHERE id > 0", conn)
            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                Facturacion.CmbRFC.Items.Clear()
                While reader.Read()
                    Facturacion.CmbRFC.Items.Add(reader("rfc").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        regresar()
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        ' Solo permitir dígitos, teclas de control (como borrar) y evitar todo lo demás
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub regresar()
        Me.Close()
    End Sub
End Class