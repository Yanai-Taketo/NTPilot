Imports Microsoft.Win32

''' <summary>
''' Thin wrapper around HKLM registry access for W32Time paths.
''' All read operations return a default value on error rather than throwing.
''' Write operations throw so callers can surface the error to the user.
''' </summary>
Public Module RegistryHelper

    ' ------------------------------------------------------------------ Registry paths

    Public Const ParamsPath As String =
        "SYSTEM\CurrentControlSet\Services\W32Time\Parameters"

    Public Const ConfigPath As String =
        "SYSTEM\CurrentControlSet\Services\W32Time\Config"

    Public Const NtpClientPath As String =
        "SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpClient"

    Public Const NtpServerPath As String =
        "SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpServer"

    ' ------------------------------------------------------------------ Read helpers

    Public Function GetString(subKey As String, valueName As String,
                              Optional defaultValue As String = "") As String
        Try
            Using key = Registry.LocalMachine.OpenSubKey(subKey)
                If key Is Nothing Then Return defaultValue
                Dim val = key.GetValue(valueName)
                Return If(val IsNot Nothing, val.ToString(), defaultValue)
            End Using
        Catch
            Return defaultValue
        End Try
    End Function

    Public Function GetDWord(subKey As String, valueName As String,
                             Optional defaultValue As Integer = 0) As Integer
        Try
            Using key = Registry.LocalMachine.OpenSubKey(subKey)
                If key Is Nothing Then Return defaultValue
                Dim val = key.GetValue(valueName)
                If val Is Nothing Then Return defaultValue
                Return Convert.ToInt32(val)
            End Using
        Catch
            Return defaultValue
        End Try
    End Function

    ''' <summary>Returns all value names and their raw string representations.</summary>
    Public Function GetAllValues(subKey As String) As List(Of KeyValuePair(Of String, String))
        Dim result As New List(Of KeyValuePair(Of String, String))
        Try
            Using key = Registry.LocalMachine.OpenSubKey(subKey)
                If key Is Nothing Then Return result
                For Each name In key.GetValueNames()
                    Dim val = key.GetValue(name)
                    result.Add(New KeyValuePair(Of String, String)(name,
                        If(val IsNot Nothing, val.ToString(), "")))
                Next
            End Using
        Catch
        End Try
        Return result
    End Function

    ' ------------------------------------------------------------------ Write helpers

    Public Sub SetString(subKey As String, valueName As String, value As String)
        Using key = Registry.LocalMachine.OpenSubKey(subKey, True)
            If key Is Nothing Then Throw New InvalidOperationException($"Registry key not found: {subKey}")
            key.SetValue(valueName, value, RegistryValueKind.String)
        End Using
    End Sub

    Public Sub SetDWord(subKey As String, valueName As String, value As Integer)
        Using key = Registry.LocalMachine.OpenSubKey(subKey, True)
            If key Is Nothing Then Throw New InvalidOperationException($"Registry key not found: {subKey}")
            key.SetValue(valueName, value, RegistryValueKind.DWord)
        End Using
    End Sub

End Module
