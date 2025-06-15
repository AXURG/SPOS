Imports System.Data.SQLite
Imports System.Globalization
Imports System.Threading

Public Class VentaN
    Private Subtotal As Decimal = 0
    Private ProductosReservados As New Dictionary(Of String, Integer)

    Private Sub VentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Forzar cultura a México para formato de moneda en pesos
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")

        CargarProductos()
    End Sub

    Private Sub CargarProductos()
        Dim query As String = "SELECT nombre FROM PRODUCTOS"

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

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim producto As String = CmbProducto.Text
        Dim piezas As Integer
        Dim precio As Decimal
        Dim existencias As Integer

        If String.IsNullOrEmpty(producto) Then
            MsgBox("Seleccione un producto.", vbExclamation)
            Return
        End If

        If Not Integer.TryParse(TxtPZ.Text, piezas) OrElse piezas <= 0 Then
            MsgBox("Ingrese una cantidad válida.", vbExclamation)
            Return
        End If

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Dim query As String = "SELECT precio, existencia FROM productos WHERE nombre = @nombre"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@nombre", producto)
                connection.Open()
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        precio = Convert.ToDecimal(reader("precio"))
                        existencias = Convert.ToInt32(reader("existencia"))
                    Else
                        MsgBox("El producto no existe.", vbExclamation)
                        Return
                    End If
                End Using
            End Using
        End Using

        Dim existenciasReservadas = If(ProductosReservados.ContainsKey(producto), ProductosReservados(producto), 0)
        If piezas > existencias - existenciasReservadas Then
            MsgBox("No hay suficientes existencias.", vbExclamation)
            Return
        End If

        If ProductosReservados.ContainsKey(producto) Then
            ProductosReservados(producto) += piezas
        Else
            ProductosReservados(producto) = piezas
        End If

        Dim total As Decimal = piezas * precio
        DgvProductos.Rows.Add(producto, piezas, precio.ToString("C2"), total.ToString("C2"))
        Subtotal += total
        TxtTotal.Text = Subtotal.ToString("C2")
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If DgvProductos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In DgvProductos.SelectedRows
                If Not row.IsNewRow Then
                    Dim producto As String = row.Cells(0).Value.ToString()
                    Dim cantidad As Integer = Convert.ToInt32(row.Cells(1).Value)

                    If ProductosReservados.ContainsKey(producto) Then
                        ProductosReservados(producto) -= cantidad
                        If ProductosReservados(producto) <= 0 Then
                            ProductosReservados.Remove(producto)
                        End If
                    End If

                    ' Quitar símbolo moneda, espacios y formato para decimal
                    Dim totalStr = row.Cells(3).Value.ToString().Replace("$", "").Replace(" ", "").Replace("€", "").Trim()
                    Dim total As Decimal = 0
                    Decimal.TryParse(totalStr, total)

                    Subtotal -= total
                    DgvProductos.Rows.Remove(row)

                End If
            Next
            TxtTotal.Text = Subtotal.ToString("C2")
        Else
            MsgBox("Seleccione un producto para eliminar.", vbExclamation)
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnFinalizar_Click(sender As Object, e As EventArgs) Handles BtnFinalizar.Click
        If DgvProductos.Rows.Count = 0 Then
            MsgBox("No hay productos en el carrito.", vbExclamation)
            Return
        End If

        Dim confirmacionVenta = MsgBox("¿Está seguro de terminar la venta? No se podrá revertir.", vbYesNo Or vbInformation)
        If confirmacionVenta = vbYes Then
            Dim facturar = MsgBox("¿Se desea facturar?", vbYesNo, "Facturación")
            Dim facturacionFlag As Integer = If(facturar = vbYes, 1, 0)

            RegistrarVenta(facturacionFlag)
            MsgBox("Venta finalizada exitosamente.", vbInformation)
            LimpiarFormulario()
            ProductosReservados.Clear()
            Subtotal = 0
        End If
    End Sub

    Private Sub RegistrarVenta(facturacion As Integer)
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            connection.Open()

            Dim transaction As SQLiteTransaction = connection.BeginTransaction()

            Try
                Dim insertVenta As String = "INSERT INTO VENTAS (fecha, total, total_productos, facturacion, vendedor_id) VALUES (@fecha, @total, @total_productos, @facturacion, @vendedor_id)"
                Using cmdVenta As New SQLiteCommand(insertVenta, connection)
                    cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmdVenta.Parameters.AddWithValue("@total", Subtotal)
                    ' Contar filas reales (no nueva) del DataGridView para total_productos
                    Dim totalProductos As Integer = DgvProductos.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow)
                    cmdVenta.Parameters.AddWithValue("@total_productos", totalProductos)
                    cmdVenta.Parameters.AddWithValue("@facturacion", facturacion)
                    cmdVenta.Parameters.AddWithValue("@vendedor_id", session.userid)
                    cmdVenta.ExecuteNonQuery()
                End Using

                Dim ventaId As Long
                Using cmdId As New SQLiteCommand("SELECT last_insert_rowid()", connection)
                    ventaId = CLng(cmdId.ExecuteScalar())
                End Using

                For Each row As DataGridViewRow In DgvProductos.Rows
                    If row.IsNewRow Then Continue For

                    Dim nombreProducto As String = row.Cells(0).Value.ToString()
                    Dim cantidad As Integer = Convert.ToInt32(row.Cells(1).Value)
                    Dim precioUnitarioStr As String = row.Cells(2).Value.ToString().Replace("$", "").Replace(" ", "").Replace("€", "").Trim()
                    Dim importeStr As String = row.Cells(3).Value.ToString().Replace("$", "").Replace(" ", "").Replace("€", "").Trim()

                    Dim precioUnitario As Decimal = 0
                    Decimal.TryParse(precioUnitarioStr, precioUnitario)
                    Dim importe As Decimal = 0
                    Decimal.TryParse(importeStr, importe)

                    Dim productoId As Integer
                    Using cmdProd As New SQLiteCommand("SELECT id FROM PRODUCTOS WHERE nombre = @nombre", connection)
                        cmdProd.Parameters.AddWithValue("@nombre", nombreProducto)
                        productoId = Convert.ToInt32(cmdProd.ExecuteScalar())
                    End Using

                    Dim insertDetalle As String = "INSERT INTO DVENTA (venta_id, producto_id, nombre_producto, precio_unitario, cantidad, importe) VALUES (@venta_id, @producto_id, @nombre_producto, @precio_unitario, @cantidad, @importe)"
                    Using cmdDet As New SQLiteCommand(insertDetalle, connection)
                        cmdDet.Parameters.AddWithValue("@venta_id", ventaId)
                        cmdDet.Parameters.AddWithValue("@producto_id", productoId)
                        cmdDet.Parameters.AddWithValue("@nombre_producto", nombreProducto)
                        cmdDet.Parameters.AddWithValue("@precio_unitario", precioUnitario)
                        cmdDet.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdDet.Parameters.AddWithValue("@importe", importe)
                        cmdDet.ExecuteNonQuery()
                    End Using

                    Dim updateExistencia As String = "UPDATE productos SET existencia = existencia - @cantidad WHERE id = @id"
                    Using cmdUpd As New SQLiteCommand(updateExistencia, connection)
                        cmdUpd.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdUpd.Parameters.AddWithValue("@id", productoId)
                        cmdUpd.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                MsgBox("Error al registrar la venta: " & ex.Message, vbCritical)
            End Try
        End Using
    End Sub

    Private Sub LimpiarFormulario()
        CmbProducto.SelectedIndex = -1
        TxtPZ.Clear()
        DgvProductos.Rows.Clear()
        Subtotal = 0
        TxtTotal.Text = "$0.00"
    End Sub

    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        principal.Show()
        Me.Close()
    End Sub
End Class
