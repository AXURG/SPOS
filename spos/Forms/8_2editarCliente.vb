Imports System.Data.SQLite
Public Class _8_2editarCliente
    Public Property id As Integer
    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        _8historialClientes.Show()
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim campo As String = cmbCampo.Text.Trim()
        Dim nuevoValor As String = txtNuevo.Text.Trim()

        ' Validaciones
        If String.IsNullOrEmpty(campo) Then
            MessageBox.Show("Por favor, seleccione un campo a cambiar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(nuevoValor) Then
            MessageBox.Show("Por favor, ingrese la nueva información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Verifica que el campo sea permitido (por seguridad)
        Dim camposPermitidos As New List(Of String) From {
            "nombre", "direccion", "correo", "telefono", "rfc"
        }

        If Not camposPermitidos.Contains(campo.ToLower()) Then
            MessageBox.Show("El campo seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Ejecutar actualización
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim query As String = $"UPDATE clientes SET {campo} = @nuevoValor WHERE id = @id"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nuevoValor", nuevoValor)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show("Información actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        _8historialClientes.Close()
                        _8historialClientes.Show()
                    Else
                        MessageBox.Show("No se pudo actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCampo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCampo.SelectedIndexChanged
        Dim campo As String = cmbCampo.Text.Trim()
        If campo = "NUMERO TELEFONICO" Then
            campo = "ntelefono"
        End If

        If String.IsNullOrEmpty(campo) Then Return

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim query As String = $"SELECT {campo} FROM CLIENTES WHERE id = @id"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim resultado As Object = cmd.ExecuteScalar()
                    lblLog.Text = "Registro Anterior: " & resultado?.ToString()
                End Using
            End Using
        Catch ex As Exception
            lblLog.Text = "Error al cargar dato anterior."
        End Try
    End Sub

End Class