Imports System.Data.SQLite
Public Class inventario

    Private Sub inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Public Sub cargarDatos()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Dim query As String = "SELECT id as [ID], nombre AS [Nombre], precio AS [Precio], existencia AS [Existencias] FROM PRODUCTOS"
                Using adapter As New SQLiteDataAdapter(query, connection)
                    Dim dbTable As New DataTable()
                    adapter.Fill(dbTable)
                    dtgv_inventario.DataSource = dbTable
                End Using
            Catch ex As Exception
                MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnSesion_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        principal.Show()
        Me.Close()
    End Sub
End Class

