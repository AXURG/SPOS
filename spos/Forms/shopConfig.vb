Imports System.Data.SQLite
Imports System.IO

Public Class shopConfig

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ofd As New OpenFileDialog()
        ofd.Title = "Seleccionar logotipo"
        ofd.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"

        If ofd.ShowDialog() = DialogResult.OK Then
            txtRutaLogo.Text = ofd.FileName ' Mostrar ruta en el textbox

            ' (Opcional) Mostrar la imagen en un PictureBox
            If File.Exists(ofd.FileName) Then
                pbLogo.Image = Image.FromFile(ofd.FileName)
                pbLogo.SizeMode = PictureBoxSizeMode.Zoom
            End If
        End If
    End Sub




    Private Sub shopConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim cmd As New SQLiteCommand("SELECT * FROM FACTURACION_EMISORES LIMIT 1", conn)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtRFC.Text = reader("RFC").ToString()
                        txtNombre.Text = reader("NOMBRE").ToString()
                        txtCalle.Text = reader("CALLE").ToString()
                        txtNo.Text = reader("NOEXTERIOR").ToString()
                        txtColonia.Text = reader("COLONIA").ToString()
                        txtLocalidad.Text = reader("LOCALIDAD").ToString()
                        txtMunicipio.Text = reader("MUNICIPIO").ToString()
                        txtEstado.Text = reader("ESTADO").ToString()
                        txtPais.Text = reader("PAIS").ToString()
                        txtCP.Text = reader("CODIGOPOSTAL").ToString()
                        txtEmail.Text = reader("EMAIL").ToString()
                        txtTelefono.Text = reader("TELEFONO").ToString()
                        txtRutaLogo.Text = reader("LOGO").ToString()

                        ' Mostrar logo si existe
                        If File.Exists(txtRutaLogo.Text) Then
                            pbLogo.Image = Image.FromFile(txtRutaLogo.Text)
                            pbLogo.SizeMode = PictureBoxSizeMode.Zoom
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar configuración: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Verificar campos obligatorios
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
       String.IsNullOrWhiteSpace(txtRFC.Text) OrElse
       String.IsNullOrWhiteSpace(txtCalle.Text) OrElse
       String.IsNullOrWhiteSpace(txtNo.Text) OrElse
       String.IsNullOrWhiteSpace(txtColonia.Text) OrElse
       String.IsNullOrWhiteSpace(txtMunicipio.Text) OrElse
       String.IsNullOrWhiteSpace(txtEstado.Text) OrElse
       String.IsNullOrWhiteSpace(txtPais.Text) OrElse
       String.IsNullOrWhiteSpace(txtCP.Text) Then

            MessageBox.Show("Por favor completa todos los campos obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' Verificar si ya existe un emisor
                Dim exists As Boolean = False
                Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM FACTURACION_EMISORES", conn)
                    exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0
                End Using

                ' Insertar o actualizar
                Dim sql As String
                If exists Then
                    sql = "UPDATE FACTURACION_EMISORES SET
                        RFC = @RFC,
                        NOMBRE = @Nombre,
                        CALLE = @Calle,
                        NOEXTERIOR = @NoExterior,
                        NOINTERIOR = @NoInterior,
                        COLONIA = @Colonia,
                        LOCALIDAD = @Localidad,
                        MUNICIPIO = @Municipio,
                        ESTADO = @Estado,
                        PAIS = @Pais,
                        EMAIL = @Email,
                        TELEFONO = @Telefono,
                        CODIGOPOSTAL = @CP,
                        LOGO = @Logo,
                        LEYENDATICKET = @Leyenda,
                        FOLIO = @Folio,
                        SERIEF = @Serie
                        WHERE ID = 1"
                Else
                    sql = "INSERT INTO FACTURACION_EMISORES (
                        RFC, NOMBRE, CALLE, NOEXTERIOR, NOINTERIOR, COLONIA, LOCALIDAD, MUNICIPIO, ESTADO, PAIS,
                        EMAIL, TELEFONO, CODIGOPOSTAL, LOGO, LEYENDATICKET, FOLIO, SERIEF)
                        VALUES (
                        @RFC, @Nombre, @Calle, @NoExterior, @NoInterior, @Colonia, @Localidad, @Municipio, @Estado, @Pais,
                        @Email, @Telefono, @CP, @Logo, @Leyenda, @Folio, @Serie)"
                End If

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RFC", txtRFC.Text.Trim().ToUpper())
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@Calle", txtCalle.Text.Trim())
                    cmd.Parameters.AddWithValue("@NoExterior", txtNo.Text.Trim())
                    cmd.Parameters.AddWithValue("@NoInterior", "") ' Si quieres agregar campo de interior, cambia esto
                    cmd.Parameters.AddWithValue("@Colonia", txtColonia.Text.Trim())
                    cmd.Parameters.AddWithValue("@Localidad", txtLocalidad.Text.Trim())
                    cmd.Parameters.AddWithValue("@Municipio", txtMunicipio.Text.Trim())
                    cmd.Parameters.AddWithValue("@Estado", txtEstado.Text.Trim())
                    cmd.Parameters.AddWithValue("@Pais", txtPais.Text.Trim())
                    cmd.Parameters.AddWithValue("@CP", txtCP.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim())
                    cmd.Parameters.AddWithValue("@Logo", txtRutaLogo.Text.Trim())
                    cmd.Parameters.AddWithValue("@Leyenda", "¡Gracias por su preferencia!") ' puedes hacer txtLeyenda si deseas
                    cmd.Parameters.AddWithValue("@Folio", 1) ' puede venir de un textbox o control
                    cmd.Parameters.AddWithValue("@Serie", 1) ' puede venir de otro textbox si usas series personalizadas
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al guardar configuración: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
        principal.Show()
    End Sub
End Class