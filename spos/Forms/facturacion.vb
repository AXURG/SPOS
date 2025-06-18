Imports System.Data.SQLite

Public Class Facturacion

    Public IDVenta As Integer ' Se debe asignar al abrir este formulario



    Private Sub FacturacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        lblVendedor.Text = ObtenerNombreUsuario(session.userid)
        LlenarRFCs()
        CargarDetalleVenta()
    End Sub

    ' Cargar RFCs excepto el cliente general
    Private Sub LlenarRFCs()
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT rfc FROM clientes WHERE id > 0", conn)
            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                cmbRFC.Items.Clear()
                While reader.Read()
                    cmbRFC.Items.Add(reader("rfc").ToString())
                End While
            End Using
        End Using
    End Sub

    ' Mostrar teléfono al seleccionar RFC
    Private Sub cmbRFC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFC.SelectedIndexChanged
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT ntelefono FROM clientes WHERE rfc = @rfc", conn)
            cmd.Parameters.AddWithValue("@rfc", cmbRFC.Text)
            Dim telefono As Object = cmd.ExecuteScalar()
            If telefono IsNot Nothing Then
                txtTelefono.Text = telefono.ToString()
            Else
                txtTelefono.Text = ""
            End If
        End Using
    End Sub

    ' Obtener nombre del usuario (vendedor)
    Private Function ObtenerNombreUsuario(idUsuario As Integer) As String
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT nombre FROM VENDEDORES WHERE id = @id", conn)
            cmd.Parameters.AddWithValue("@id", idUsuario)
            Dim nombre As Object = cmd.ExecuteScalar()
            If nombre IsNot Nothing Then
                Return nombre.ToString()
            Else
                Return "Desconocido"
            End If
        End Using
    End Function

    ' Cargar productos de la venta y calcular totales
    Private Sub CargarDetalleVenta()
        Dim subtotal As Decimal = 0
        dgvDetalleVenta.Rows.Clear()

        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SQLiteCommand("
                SELECT p.nombre, d.cantidad, d.precio_unitario, d.importe
                FROM DVENTA d
                JOIN productos p ON p.id = d.producto_id
                WHERE d.venta_id = @idventa", conn)

            cmd.Parameters.AddWithValue("@idventa", IDVenta)
            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim nombre = reader("nombre").ToString()
                    Dim cantidad = Convert.ToInt32(reader("cantidad"))
                    Dim precio_unitario = Convert.ToDecimal(reader("precio_unitario"))
                    Dim importe = Convert.ToDecimal(reader("importe"))

                    DgvDetalleVenta.Rows.Add(nombre, cantidad, precio_unitario.ToString("C"), importe.ToString("C"))
                    subtotal += importe
                End While
            End Using
        End Using

        Dim iva As Decimal = subtotal * 0.16D
        Dim totalVenta As Decimal = subtotal + iva

        lblSubtotal.Text = subtotal.ToString("C")
        lblIVA.Text = iva.ToString("C")
        lblTotal.Text = totalVenta.ToString("C")
    End Sub

    Private Sub btnCreateFactura_Click(sender As Object, e As EventArgs) Handles btnCreateFactura.Click
        Dim subtotal As Decimal = 0D
        Dim iva As Decimal = 0D
        Dim total As Decimal = 0D
        Dim clienteID As Integer = -1

        ' Obtener datos de la venta (incluye ID del cliente)
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()

            ' Obtener el cliente a partir del RFC seleccionado
            If String.IsNullOrEmpty(CmbRFC.Text) Then
                MsgBox("Seleccione un RFC para facturar.", vbExclamation)
                Return
            End If

            Dim cmdCliente As New SQLiteCommand("SELECT id FROM clientes WHERE rfc = @rfc", conn)
            cmdCliente.Parameters.AddWithValue("@rfc", CmbRFC.Text)

            Dim result = cmdCliente.ExecuteScalar()
            If result Is Nothing OrElse IsDBNull(result) Then
                MsgBox("No se encontró el cliente con ese RFC.", vbCritical)
                Return
            End If
            clienteID = Convert.ToInt32(result)


            ' Calcular subtotal desde DVENTA
            Dim cmdTotal As New SQLiteCommand("
            SELECT SUM(importe) 
            FROM DVENTA 
            WHERE venta_id = @ventaID", conn)
            cmdTotal.Parameters.AddWithValue("@ventaID", IDVenta)

            Dim totalStr = cmdTotal.ExecuteScalar()
            If totalStr IsNot Nothing AndAlso Not IsDBNull(totalStr) Then
                subtotal = Convert.ToDecimal(totalStr)
            End If

            iva = subtotal * 0.16D
            total = subtotal + iva

            ' Insertar en tabla facturas
            Dim cmdInsert As New SQLiteCommand("
            INSERT INTO facturas (venta_id, cliente_id, fecha, subtotal, iva, total)
            VALUES (@venta_id, @cliente_id, datetime('now','localtime'), @subtotal, @iva, @total)
        ", conn)

            cmdInsert.Parameters.AddWithValue("@venta_id", IDVenta)
            cmdInsert.Parameters.AddWithValue("@cliente_id", clienteID)
            cmdInsert.Parameters.AddWithValue("@subtotal", subtotal)
            cmdInsert.Parameters.AddWithValue("@iva", iva)
            cmdInsert.Parameters.AddWithValue("@total", total)

            cmdInsert.ExecuteNonQuery()
        End Using

        MsgBox("Factura creada correctamente.", vbInformation)
        Me.Close()
    End Sub

End Class
