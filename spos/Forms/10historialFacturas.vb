Imports System.Data.SQLite
Imports System.Text ' Necesario para StringBuilder

Public Class _10historialFacturas
    Private Sub _10historialFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarFacturas()
        ' Configura las columnas del DataGridView si no lo has hecho en el diseñador
        ' Si ya lo haces en el diseñador, puedes omitir esta parte.
        If dgvFacturas.Columns.Count = 0 Then
            dgvFacturas.Columns.Add("ID", "ID Factura") ' Columna 0 (invisible pero útil)
            dgvFacturas.Columns.Add("Fecha", "Fecha")
            dgvFacturas.Columns.Add("Cliente", "Cliente")
            dgvFacturas.Columns.Add("RFC", "RFC Cliente")
            dgvFacturas.Columns.Add("Total", "Total Factura")
        End If

        ' Opcional: Ocultar la columna ID si no quieres que sea visible para el usuario
        If dgvFacturas.Columns.Contains("ID") Then
            dgvFacturas.Columns("ID").Visible = False
        End If

        ' Configurar DataGridView para selección de fila completa
        dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvFacturas.MultiSelect = False ' Solo permite seleccionar una fila a la vez
    End Sub

    Private Sub CargarFacturas(Optional ByVal filtroRFC As String = "")
        dgvFacturas.Rows.Clear()

        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim query As String = "SELECT f.id, f.fecha, f.total, c.nombre AS cliente, c.rfc, f.venta_id " &
                                   "FROM facturas f " &
                                   "INNER JOIN clientes c ON f.cliente_id = c.id"

            If Not String.IsNullOrEmpty(filtroRFC) Then
                query &= " WHERE c.rfc LIKE @filtro"
            End If

            Using cmd As New SQLiteCommand(query, conn)
                If Not String.IsNullOrEmpty(filtroRFC) Then
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtroRFC & "%")
                End If

                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        dgvFacturas.Rows.Add(
                            reader("id"),        ' Columna 0: ID de la factura (para uso interno)
                            reader("fecha"),
                            reader("cliente"),
                            reader("rfc"),
                            FormatCurrency(reader("total")))
                        ' NO añadimos venta_id directamente aquí, pero lo recuperamos para ObtenerDetallesFactura

                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Asumo que tienes un TextBox llamado txtBuscarRFC para el filtro de RFC
        CargarFacturas(txtBuscarRFC.Text)
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        ' 1. Verificar si hay una fila seleccionada en el DataGridView
        If dgvFacturas.SelectedRows.Count > 0 Then
            ' 2. Obtener el ID de la factura de la fila seleccionada
            '    Asumimos que el ID de la factura está en la primera columna visible/invisible (índice 0)
            Dim idFactura As Integer
            Try
                idFactura = CInt(dgvFacturas.SelectedRows(0).Cells(0).Value)
            Catch ex As Exception
                MsgBox("Error al obtener el ID de la factura: " & ex.Message, MsgBoxStyle.Critical, "Error")
                Return
            End Try

            ' 3. Obtener los detalles completos de la factura (incluyendo ítems de DVENTA)
            Dim detallesFactura As String = ObtenerDetallesFacturaConItems(idFactura)

            ' 4. Mostrar los detalles en un MsgBox
            If Not String.IsNullOrEmpty(detallesFactura) Then
                MsgBox(detallesFactura, MsgBoxStyle.Information, "Detalles de Factura")
            Else
                MsgBox("No se encontraron detalles para la factura seleccionada o sus ítems.", MsgBoxStyle.Information, "Información")
            End If
        Else
            MsgBox("Por favor, seleccione una factura de la lista para ver sus detalles.", MsgBoxStyle.Information, "Factura no Seleccionada")
        End If
    End Sub

    ' Nueva función para obtener los detalles completos de una factura, incluyendo los ítems de DVENTA
    Private Function ObtenerDetallesFacturaConItems(idFactura As Integer) As String
        Dim detalles As New StringBuilder() ' Usamos StringBuilder para construir el mensaje

        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()

            ' 1. Obtener los datos generales de la factura y del cliente, y el venta_id
            Dim queryFactura As String = "SELECT f.id, f.fecha, f.subtotal, f.iva, f.total, f.venta_id, " &
                                         "c.nombre AS cliente_nombre, c.rfc AS cliente_rfc, c.direccion AS cliente_direccion " &
                                         "FROM facturas f " &
                                         "INNER JOIN clientes c ON f.cliente_id = c.id " &
                                         "WHERE f.id = @idFactura"

            Dim ventaId As Integer = -1 ' Para almacenar el venta_id

            Using cmdFactura As New SQLiteCommand(queryFactura, conn)
                cmdFactura.Parameters.AddWithValue("@idFactura", idFactura)

                Using readerFactura As SQLiteDataReader = cmdFactura.ExecuteReader()
                    If readerFactura.Read() Then
                        detalles.AppendLine($"--- Detalles de Factura #{readerFactura("id")} ---")
                        detalles.AppendLine($"Fecha: {CDate(readerFactura("fecha")).ToShortDateString()}")
                        detalles.AppendLine($"Cliente: {readerFactura("cliente_nombre")}")
                        detalles.AppendLine($"RFC Cliente: {readerFactura("cliente_rfc")}")
                        If Not IsDBNull(readerFactura("cliente_direccion")) Then
                            detalles.AppendLine($"Dirección: {readerFactura("cliente_direccion")}")
                        End If
                        detalles.AppendLine($"Subtotal: {FormatCurrency(readerFactura("subtotal"))}")
                        detalles.AppendLine($"IVA: {FormatCurrency(readerFactura("iva"))}")
                        detalles.AppendLine($"Total Factura: {FormatCurrency(readerFactura("total"))}")
                        detalles.AppendLine("") ' Salto de línea

                        ventaId = CInt(readerFactura("venta_id")) ' Obtenemos el venta_id
                    Else
                        Return "" ' No se encontró la factura con ese ID
                    End If
                End Using
            End Using

            ' 2. Si se encontró el venta_id, obtener los ítems de la tabla DVENTA
            If ventaId <> -1 Then
                detalles.AppendLine("--- Ítems de la Venta ---")

                ' Adaptar esta consulta a la estructura REAL de tu tabla DVENTA
                ' EJEMPLO: Si DVENTA tiene 'producto_nombre', 'cantidad', 'precio_unitario', 'importe'
                Dim queryDventa As String = "SELECT producto_nombre, cantidad, precio_unitario, importe " &
                                            "FROM DVENTA " &
                                            "WHERE venta_id = @ventaId"

                Using cmdDventa As New SQLiteCommand(queryDventa, conn)
                    cmdDventa.Parameters.AddWithValue("@ventaId", ventaId)

                    Using readerDventa As SQLiteDataReader = cmdDventa.ExecuteReader()
                        If readerDventa.HasRows Then
                            While readerDventa.Read()
                                detalles.AppendLine($"- {readerDventa("producto_nombre")}")
                                detalles.AppendLine($"  Cantidad: {readerDventa("cantidad")}, P.U.: {FormatCurrency(readerDventa("precio_unitario"))}, Importe: {FormatCurrency(readerDventa("importe"))}")
                            End While
                        Else
                            detalles.AppendLine("  No se encontraron ítems para esta venta.")
                        End If
                    End Using
                End Using
            Else
                detalles.AppendLine("No se encontró un ID de Venta asociado a esta factura.")
            End If

        End Using

        Return detalles.ToString()
    End Function

    ' Asegúrate de que tienes esta función o utiliza Convert.ToDecimal.ToString("C")
    Private Function FormatCurrency(value As Object) As String
        If IsDBNull(value) OrElse value Is Nothing Then
            Return FormatCurrency(0) ' O "" si prefieres vacío para nulos
        End If
        Return CStr(Format(CDec(value), "C")) ' Formato de moneda del sistema
    End Function
End Class

