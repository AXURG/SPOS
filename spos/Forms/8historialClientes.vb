Imports System.Data.SQLite

Public Class _8historialClientes
    Private Sub cargarClientes()
        Using connection As SQLiteConnection = DBConnection.GetConnection()
            Try
                connection.Open()
                Dim query As String = "
                SELECT 
                    id AS [ID], 
                    nombre AS [Cliente], 
                    direccion AS [Dirección], 
                    correo AS [Correo],
                    ntelefono AS [Teléfono],
rfc AS [RFC]
                FROM CLIENTES"
                Using adapter As New SQLiteDataAdapter(query, connection)
                    Dim dbTable As New DataTable()
                    adapter.Fill(dbTable)
                    dgv_clientes.DataSource = dbTable
                End Using
            Catch ex As Exception
                MsgBox("Error: No se ha encontrado la base de datos o hubo un error en la consulta." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    'Ver Ventas
    Private Sub seleccionarCliente()
        If dgv_clientes.SelectedRows.Count = 0 Then
            MsgBox("Seleccione una venta para ver detalles.", vbExclamation)
            Return
        Else
            Dim idCliente As Integer = Convert.ToInt32(dgv_clientes.SelectedRows(0).Cells("ID").Value)
            _8_2editarCliente.id = idCliente
            _8_2editarCliente.Show()
           
            Me.Hide()
        End If
    End Sub
    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        principal.Show()
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        seleccionarCliente()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.Close()
        _8_1agregarCliente_.Show()
    End Sub

    Private Sub _8historialClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
    End Sub
End Class