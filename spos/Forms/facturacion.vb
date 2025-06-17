Imports System.Data.SQLite

Public Class facturacion
    Private Sub CmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProducto.SelectedIndexChanged

    End Sub

    Private Sub CargarProductos()
        Dim query As String = "SELECT nombre FROM CLIENTES"

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Using command As New SQLiteCommand(query, connection)
                connection.Open()
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        CmbProducto.Items.Add(reader("nombre").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub
End Class