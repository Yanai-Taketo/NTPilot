Imports System.ServiceProcess
Imports System.Diagnostics
Imports System.Text

''' <summary>
''' Wraps W32Time service control and w32tm command execution.
''' Values are returned as-is from Windows — no conversion or formatting.
''' </summary>
Public Module W32TimeHelper

    Public Const ServiceName As String = "W32Time"

    ' ------------------------------------------------------------------ Service control

    Public Function GetServiceStatus() As ServiceControllerStatus
        Try
            Using sc As New ServiceController(ServiceName)
                Return sc.Status
            End Using
        Catch
            Return ServiceControllerStatus.Stopped
        End Try
    End Function

    Public Function IsRunning() As Boolean
        Return GetServiceStatus() = ServiceControllerStatus.Running
    End Function

    Public Sub StartService()
        Using sc As New ServiceController(ServiceName)
            If sc.Status <> ServiceControllerStatus.Running Then
                sc.Start()
                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30))
            End If
        End Using
    End Sub

    Public Sub StopService()
        Using sc As New ServiceController(ServiceName)
            If sc.Status <> ServiceControllerStatus.Stopped Then
                sc.Stop()
                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30))
            End If
        End Using
    End Sub

    Public Sub RestartService()
        StopService()
        StartService()
    End Sub

    ' ------------------------------------------------------------------ w32tm execution

    ''' <summary>
    ''' Runs w32tm with the given arguments and returns stdout (or stderr on failure).
    ''' Encoding uses the system default (OEM code page) which matches w32tm's output.
    ''' </summary>
    Public Function RunW32tm(args As String) As String
        Try
            Dim psi As New ProcessStartInfo("w32tm", args) With {
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True,
                .StandardOutputEncoding = Encoding.Default,
                .StandardErrorEncoding = Encoding.Default
            }
            Using proc As Process = Process.Start(psi)
                Dim output = proc.StandardOutput.ReadToEnd()
                Dim err = proc.StandardError.ReadToEnd()
                proc.WaitForExit(15000)
                Return If(String.IsNullOrWhiteSpace(output), err, output)
            End Using
        Catch ex As Exception
            Return $"Error: {ex.Message}"
        End Try
    End Function

    ' ------------------------------------------------------------------ Parsed queries

    ''' <summary>
    ''' Returns key-value pairs from w32tm /query /status /verbose.
    ''' Keys and values are raw strings from Windows.
    ''' </summary>
    Public Function QueryStatus() As List(Of KeyValuePair(Of String, String))
        Dim result As New List(Of KeyValuePair(Of String, String))
        Dim output = RunW32tm("/query /status /verbose")
        For Each line In output.Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            Dim idx = line.IndexOf(":")
            If idx > 0 Then
                Dim key = line.Substring(0, idx).Trim()
                Dim value = line.Substring(idx + 1).Trim()
                result.Add(New KeyValuePair(Of String, String)(key, value))
            End If
        Next
        Return result
    End Function

    ''' <summary>
    ''' Returns peer info from w32tm /query /peers.
    ''' All fields are raw strings from Windows.
    ''' </summary>
    Public Function QueryPeers() As List(Of PeerInfo)
        Dim result As New List(Of PeerInfo)
        Dim output = RunW32tm("/query /peers")
        Dim peer As PeerInfo = Nothing

        For Each line In output.Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            Dim trimmed = line.Trim()
            If trimmed.StartsWith("#Peers:", StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If
            If trimmed.StartsWith("Peer:", StringComparison.OrdinalIgnoreCase) Then
                If peer IsNot Nothing Then result.Add(peer)
                peer = New PeerInfo() With {.Server = trimmed.Substring(5).Trim()}
            ElseIf peer IsNot Nothing Then
                Dim idx = trimmed.IndexOf(":")
                If idx > 0 Then
                    Dim key = trimmed.Substring(0, idx).Trim()
                    Dim val = trimmed.Substring(idx + 1).Trim()
                    Select Case key.ToLowerInvariant()
                        Case "state" : peer.State = val
                        Case "stratum" : peer.Stratum = val
                        Case "offset (s)" : peer.Offset = val
                        Case "root delay (s)" : peer.RootDelay = val
                        Case "root dispersion (s)" : peer.RootDispersion = val
                        Case "mode" : peer.Mode = val
                        Case "peerpoll interval" : peer.PeerPollInterval = val
                        Case "hostpoll interval" : peer.HostPollInterval = val
                    End Select
                End If
            End If
        Next
        If peer IsNot Nothing Then result.Add(peer)
        Return result
    End Function

    ''' <summary>Initiates an immediate time synchronization.</summary>
    Public Function ResyncForce() As String
        Return RunW32tm("/resync /force")
    End Function

    ''' <summary>Returns raw output of w32tm /query /configuration /verbose.</summary>
    Public Function QueryConfiguration() As String
        Return RunW32tm("/query /configuration /verbose")
    End Function

End Module

' ------------------------------------------------------------------ Data model

Public Class PeerInfo
    Public Property Server As String = ""
    Public Property State As String = ""
    Public Property Stratum As String = ""
    Public Property Offset As String = ""
    Public Property RootDelay As String = ""
    Public Property RootDispersion As String = ""
    Public Property Mode As String = ""
    Public Property PeerPollInterval As String = ""
    Public Property HostPollInterval As String = ""
End Class
