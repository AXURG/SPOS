Imports System.Data.SQLite

Public Class _7historialInventario
    Private Sub cargarDatos()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open
                Dim query As String = "SELECT 
HISTORIAL.id as [ID],
 HISTORIAL.a_b AS [Alta o Baja], 
 PRODUCTOS.nombre as [Nombre Producto],
cantidad AS [Cantidad],  
VENDEDORES.usuario AS [Usuario Vendedor],
HISTORIAL.observaciones AS [Observaciones],
fecha AS [Fecha]  FROM HISTORIAL
INNER JOIN PRODUCTOS ON HISTORIAL.id_producto = PRODUCTOS.id
INNER JOIN VENDEDORES ON HISTORIAL.id_vendedor = VENDEDORES.id;"
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

    Private Sub _7historialInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        Me.Close()
        principal.Show()
    End Sub
End Class