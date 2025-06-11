Imports System.Data.Entity.Core
Imports System.Data.SQLite
Public Class historialVentas

    ''
    '''
    '' FALTA EDICION
    '''
    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        principal.Show()
        Me.Close()
    End Sub

    Private Sub historialVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Private Sub cargarDatos()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Dim query As String = "SELECT id AS [ID], fecha AS [Fecha de Venta], total AS [TOTAL], 
vendedor_id AS [Numero de registro del Vendedor] FROM ventas"
                Using adapter As New SQLiteDataAdapter(query, connection)
                    Dim dbTable As New DataTable()
                    adapter.Fill(dbTable)
                    dtgv_ventas.DataSource = dbTable
                End Using
            Catch ex As Exception
                MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub seleccionarVenta()
        For Each row As DataGridViewRow In dtgv_ventas.SelectedRows
            If Not row.IsNewRow Then

                Using connection As SQLiteConnection = DBConnection.GetConnection()
                    Try
                        connection.Open()
                        Dim idVenta = row.Cells(0).Value.ToString()
                        Dim query As String = "SELECT id AS [ID],
venta_id AS [ID de Venta], producto_id AS [ID del Producto],
nombre_producto AS [Nombre del Producto], precio_unitario AS [Precio Unitario],
cantidad AS [Cantidad], importe AS [Importe] FROM detalle_venta
WHERE id=" & idVenta
                        Using adapter As New SQLiteDataAdapter(query, connection)
                            Dim dbTable As New DataTable()
                            adapter.Fill(dbTable)
                            dtgv_ventas.DataSource = dbTable
                        End Using
                        BtnRegresar.Visible = False
                        btnRegresarConsulta.Visible = True
                        btnVerDetalles.Visible = False

                    Catch ex As Exception
                        MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
                    End Try

                End Using
            End If
        Next
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        seleccionarVenta()
    End Sub

    Private Sub btnRegresarConsulta_Click(sender As Object, e As EventArgs) Handles btnRegresarConsulta.Click
        cargarDatos()
        btnRegresarConsulta.Hide()
        BtnRegresar.Show()
        btnVerDetalles.Show()
    End Sub
End Class