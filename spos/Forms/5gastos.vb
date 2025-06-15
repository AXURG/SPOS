Imports System.Data.SQLite
Public Class gastos
    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtImporte.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso (Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c) Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso TxtImporte.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim description As String = TxtConcepto.Text
        Dim amount As String = TxtImporte.Text
        If String.IsNullOrEmpty(description) OrElse String.IsNullOrEmpty(amount) Then
            MessageBox.Show("Por favor, complete todos los campos.")
            Return
        End If

        Dim parsedAmount As Decimal
        If Not Decimal.TryParse(amount, parsedAmount) OrElse parsedAmount <= 0 Then
            MessageBox.Show("El importe debe ser un número positivo.")
            Return
        End If
        Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Using transaction As SQLiteTransaction = connection.BeginTransaction()
                    ' Insertar el nuevo gasto en la tabla 'gastos'
                    Dim insertQuery As String = "INSERT INTO GASTOS (descripcion, cantidad, fecha) VALUES (@description, @amount, @date)"
                    Using insertCommand As New SQLiteCommand(insertQuery, connection)
                        insertCommand.Parameters.AddWithValue("@description", description)
                        insertCommand.Parameters.AddWithValue("@amount", parsedAmount)
                        insertCommand.Parameters.AddWithValue("@date", currentDate)
                        insertCommand.ExecuteNonQuery()
                    End Using
                    transaction.Commit()
                End Using
                MessageBox.Show("Gasto registrado exitosamente.")
                cargardatos()
            Catch ex As Exception
                ' Si ocurre un error, mostrar un mensaje de error
                MessageBox.Show("Error al registrar el gasto: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub gastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        principal.Show()
        Me.Close()
    End Sub


    Public Sub cargardatos()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM gastos"
                Using adapter As New SQLiteDataAdapter(query, connection)
                    Dim dbTable As New DataTable()
                    adapter.Fill(dbTable)
                    DgvGasto.DataSource = dbTable
                End Using
            Catch ex As Exception

                MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub
End Class