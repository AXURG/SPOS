Imports System.IO            ' Para usar Path.Combine
Imports System.Data.SQLite   ' Para usar SQLiteConnection


Module DBConnection
    Public Function GetConnectionString() As String
        Dim dbPath As String = Path.Combine(Application.StartupPath & "\data\LARIS.db")
        Return "Data Source=" & dbPath & ";Version=3;"
    End Function

    Public Function GetConnection() As SQLiteConnection
        Return New SQLiteConnection(GetConnectionString())
    End Function
End Module
