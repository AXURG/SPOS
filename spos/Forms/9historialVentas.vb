Imports System.Data.SQLite

Public Class historialVentas

    Private Sub historialVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                ' Consulta con columna facturacion formateada como Sí o No
                Dim query As String = "
                SELECT 
                    id AS [ID], 
                    fecha AS [Fecha de Venta], 
                    total AS [TOTAL], 
                    vendedor_id AS [Numero de registro del Vendedor],
                    CASE facturacion 
                        WHEN 1 THEN 'Sí' 
                        ELSE 'No' 
                    END AS [Facturación]
                FROM ventas"
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
        If dtgv_ventas.SelectedRows.Count = 0 Then
            MsgBox("Seleccione una venta para ver detalles.", vbExclamation)
            Return
        End If

        Dim idVenta As Integer = Convert.ToInt32(dtgv_ventas.SelectedRows(0).Cells("ID").Value)

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Dim query As String = "
                    SELECT 
                        venta_id AS [ID de Venta],
                        producto_id AS [ID del Producto],
                        nombre_producto AS [Nombre del Producto],
                        precio_unitario AS [Precio Unitario],
                        cantidad AS [Cantidad],
                        importe AS [Importe]
                    FROM DVENTA
                    WHERE venta_id = @venta_id"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@venta_id", idVenta)
                    Using adapter As New SQLiteDataAdapter(command)
                        Dim dbTable As New DataTable()
                        adapter.Fill(dbTable)
                        dtgv_ventas.DataSource = dbTable
                    End Using
                End Using

                BtnRegresar.Visible = False
                btnRegresarConsulta.Visible = True
                btnVerDetalles.Visible = False

            Catch ex As Exception
                MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        seleccionarVenta()
    End Sub

    Private Sub btnRegresarConsulta_Click(sender As Object, e As EventArgs) Handles btnRegresarConsulta.Click
        cargarDatos()
        btnRegresarConsulta.Visible = False
        BtnRegresar.Visible = True
        btnVerDetalles.Visible = True
    End Sub

    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        principal.Show()
        Me.Close()
    End Sub

End Class
