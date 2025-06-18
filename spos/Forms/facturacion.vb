Imports System.Data.SQLite
Imports System.IO
Imports System.Drawing
Public Class Facturacion

    Public IDVenta As Integer ' Se debe asignar al abrir este formulario

    Private Sub FacturacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        LblVendedor.Text = (session.user_vendedor)
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
            clienteid = Convert.ToInt32(result)
            session.userid = clienteid

            ' Ruta donde deseas guardar la imagen (puedes modificarla o usar FolderBrowserDialog)
            Dim fechaFormateada As String = DateTime.Now.ToString("hh:mmtt._dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture).ToLower()
            Dim rutaGuardar As String = "C:\Facturas\captura_factura_" & fechaFormateada.Replace(":", "").Replace("/", "-") & "_" & clienteid & "_" & IDVenta & ".png"

            ' Crear un bitmap con el tamaño del formulario
            Dim bmp As New Bitmap(Me.Width, Me.Height)

            ' Dibujar el contenido del formulario en el bitmap
            Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))

            ' Verifica si la carpeta existe, si no, la crea
            Dim carpeta As String = Path.GetDirectoryName(rutaGuardar)
            If Not Directory.Exists(carpeta) Then
                Directory.CreateDirectory(carpeta)
            End If

            ' Guardar el bitmap como imagen
            bmp.Save(rutaGuardar, Imaging.ImageFormat.Png)


            ' 🔄 ACTUALIZAR el campo id_cliente en la tabla ventas
            Dim cmdUpdate As New SQLiteCommand("UPDATE ventas SET cliente_id = @clienteid WHERE id = @ventaid", conn)
            cmdUpdate.Parameters.AddWithValue("@clienteid", clienteid)
            cmdUpdate.Parameters.AddWithValue("@ventaid", IDVenta)
            cmdUpdate.ExecuteNonQuery()

            ' Confirmación
            MessageBox.Show("Factura capturada y guardada en: " & rutaGuardar, "Captura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Me.Close()
        End Using

    End Sub

    Private Sub BtnSesion_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregarCliente_Fac.ShowDialog()
        LlenarRFCs()
        Me.Show()
    End Sub


End Class
