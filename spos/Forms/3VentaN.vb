Imports System.Data.SQLite

Public Class VentaN
    ' Variables de control
    Private Subtotal As Decimal = 0
    Private ProductosReservados As New Dictionary(Of String, Integer)

    ' Evento que carga los productos al iniciar el formulario
    Private Sub VentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    ' Método para cargar los productos en el ComboBox desde la base de datos
    Private Sub CargarProductos()
        Dim query As String = "SELECT NOMBRE FROM productos"

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Using command As New SQLiteCommand(query, connection)
                connection.Open()
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        CmbProducto.Items.Add(reader("NOMBRE").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Botón para agregar productos al carrito
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim producto As String = CmbProducto.Text
        Dim piezas As Integer
        Dim precio As Decimal
        Dim existencias As Integer

        ' Validaciones básicas
        If String.IsNullOrEmpty(producto) Then
            MsgBox("Seleccione un producto.", vbExclamation, "Error")
            Return
        End If

        If Not Integer.TryParse(TxtPZ.Text, piezas) OrElse piezas <= 0 Then
            MsgBox("Ingrese una cantidad válida.", vbExclamation, "Error")
            Return
        End If

        ' Obtener precio y existencias disponibles
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Dim query As String = "SELECT PRECIO, EXISTENCIAS FROM productos WHERE NOMBRE = @nombre"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@nombre", producto)
                connection.Open()
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        precio = Convert.ToDecimal(reader("PRECIO"))
                        existencias = Convert.ToInt32(reader("EXISTENCIAS"))
                    Else
                        MsgBox("El producto no existe en la base de datos.", vbExclamation, "Error")
                        Return
                    End If
                End Using
            End Using
        End Using

        ' Validar si hay suficientes existencias considerando las reservadas
        Dim existenciasReservadas = If(ProductosReservados.ContainsKey(producto), ProductosReservados(producto), 0)
        If piezas > existencias - existenciasReservadas Then
            MsgBox("No hay suficientes existencias disponibles.", vbExclamation, "Error")
            Return
        End If

        ' Actualizar productos reservados
        If ProductosReservados.ContainsKey(producto) Then
            ProductosReservados(producto) += piezas
        Else
            ProductosReservados(producto) = piezas
        End If

        ' Agregar producto al DataGridView
        Dim total As Decimal = piezas * precio
        DgvProductos.Rows.Add(producto, piezas, precio.ToString("C2"), total.ToString("C2"))

        ' Actualizar subtotal y mostrarlo
        Subtotal += total
        TxtTotal.Text = Subtotal.ToString("C2")
    End Sub

    ' Método para actualizar el total mostrado en pantalla
    Private Sub ActualizarTotal()
        TxtTotal.Text = Subtotal.ToString("C2")
    End Sub

    ' Botón para eliminar productos seleccionados del carrito
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If DgvProductos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In DgvProductos.SelectedRows
                If Not row.IsNewRow Then
                    Dim producto As String = row.Cells(0).Value.ToString()
                    Dim cantidad As Integer = Convert.ToInt32(row.Cells(1).Value)

                    ' Actualizar registro temporal de productos reservados
                    If ProductosReservados.ContainsKey(producto) Then
                        ProductosReservados(producto) -= cantidad
                        If ProductosReservados(producto) <= 0 Then
                            ProductosReservados.Remove(producto)
                        End If
                    End If

                    ' Actualizar subtotal
                    Dim total As Decimal = Convert.ToDecimal(row.Cells(3).Value.ToString().Replace("$", ""))
                    Subtotal -= total

                    ' Eliminar la fila del DataGridView
                    DgvProductos.Rows.Remove(row)
                End If
            Next
            TxtTotal.Text = Subtotal.ToString("C2")
        Else
            MsgBox("Seleccione un producto para eliminar.", vbExclamation, "Error")
        End If
    End Sub

    ' Botón para cerrar el formulario y restaurar existencias (si aplica)
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        If ProductosReservados.Count > 0 Then
            Using connection As SQLiteConnection = DBConnection.GetConnection()
                connection.Open()

                ' Actualizar existencias en la base de datos
                For Each kvp In ProductosReservados
                    Dim query As String = "UPDATE productos SET EXISTENCIAS = @cantidad WHERE NOMBRE = @nombre"
                    Using command As New SQLiteCommand(query, connection)
                        command.Parameters.AddWithValue("@cantidad", kvp.Value)
                        command.Parameters.AddWithValue("@nombre", kvp.Key)
                        command.ExecuteNonQuery()
                    End Using
                Next
            End Using
        End If
        Me.Close()
    End Sub

    ' Método para restaurar existencias manualmente (no se usa directamente en el flujo principal)
    Private Sub RestaurarExistencias()
        If ProductosReservados.Count = 0 Then Return

        Using connection As SQLiteConnection = DBConnection.GetConnection()
            connection.Open()

            For Each kvp In ProductosReservados
                Dim query As String = "UPDATE productos SET EXISTENCIAS = @cantidad WHERE NOMBRE = @nombre"
                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@nombre", kvp.Key)
                    command.ExecuteNonQuery()
                End Using
            Next
        End Using

        ' Limpiar registro temporal
        ProductosReservados.Clear()
    End Sub

    ' Botón para finalizar la venta
    Private Sub BtnFinalizar_Click(sender As Object, e As EventArgs) Handles BtnFinalizar.Click
        If DgvProductos.Rows.Count = 0 Then
            MsgBox("No hay productos en el carrito.", vbExclamation, "Error")
            Return
        End If

        Dim confirmacionVenta = MsgBox("¿Esta seguro de terminar la venta? No se podrá revertir esta acción", vbYesNo And vbInformation, "Terminar Venta")

        If confirmacionVenta = vbYes Then
            ' Mensaje en caso de que se requiera factura
            factura()
            ventaEfectuada()
            MsgBox("Venta finalizada exitosamente.", vbInformation, "Éxito")
            LimpiarFormulario()
            ProductosReservados.Clear()
        Else
            Return
        End If
    End Sub


    Private Sub ventaEfectuada()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            connection.Open()
            ' Descontar existencias en la base de datos
            For Each row As DataGridViewRow In DgvProductos.Rows
                If row.IsNewRow Then Continue For

                Dim producto As String = row.Cells(0).Value.ToString()
                Dim cantidad As Integer = Convert.ToInt32(row.Cells(1).Value)

                Dim query As String = "UPDATE productos SET EXISTENCIAS = EXISTENCIAS - @cantidad WHERE NOMBRE = @nombre"
                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@cantidad", cantidad)
                    command.Parameters.AddWithValue("@nombre", producto)
                    command.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub


    Private Sub factura()
        Dim btnFacturacionReq = MsgBox("¿Se desea facturar?", vbYesNo, "Facturación")
        If btnFacturacionReq = vbYes Then
            facturacion.Show()
        Else
            Return
        End If
    End Sub

    ' Método para limpiar todos los campos del formulario después de finalizar venta
    Private Sub LimpiarFormulario()
        CmbProducto.SelectedIndex = -1
        TxtPZ.Clear()
        DgvProductos.Rows.Clear()
        Subtotal = 0
        ActualizarTotal()
    End Sub

    ' Botón para regresar (cerrar formulario)
    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        Me.Close()
    End Sub

End Class

