Imports System.IO
Imports System.Data.SQLite

Module DBConnection
    Public Function GetConnectionString() As String
        ' Verifica que Application.StartupPath no sea nulo
        If String.IsNullOrEmpty(Application.StartupPath) Then
            Throw New InvalidOperationException("No se pudo determinar la ruta de inicio de la aplicación")
        End If

        ' Usa Path.Combine correctamente para todas las partes de la ruta
        Dim dbDirectory As String = Path.Combine(Application.StartupPath, "data")
        Dim dbPath As String = Path.Combine(dbDirectory, "LARIS.db")

        ' Verifica y crea la estructura de directorios si no existe
        Try
            If Not Directory.Exists(dbDirectory) Then
                Directory.CreateDirectory(dbDirectory)
            End If
        Catch ex As Exception
            Throw New IOException($"No se pudo crear el directorio: {dbDirectory}", ex)
        End Try

        Return $"Data Source={dbPath};Version=3;"
    End Function

    Public Function GetConnection() As SQLiteConnection
        Dim connectionString As String
        Try
            connectionString = GetConnectionString()
        Catch ex As Exception
            MessageBox.Show($"Error al obtener cadena de conexión: {ex.Message}")
            Return Nothing
        End Try

        Return New SQLiteConnection(connectionString)
    End Function
End Module