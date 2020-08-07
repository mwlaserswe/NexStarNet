Option Explicit On

Imports System.IO
Imports System.IO.Ports
Imports System.Runtime.Remoting.Messaging

Module Communication

    Public Structure CommandItem
        Dim No As Integer
        Dim Cmd As String
        Dim Comment As String
    End Structure

    Public CommandBuffer As New List(Of CommandItem)
    Dim CommandCnt As Integer


    Public Sub PushCommandBuffer(NexStarCmd As CommandItem)
        Dim dummy As String

        CommandBuffer.Add(NexStarCmd)

        dummy = "HeaderHandler"
    End Sub


    Public Function PopCommandBuffer() As CommandItem
        PopCommandBuffer = CommandBuffer.Item(0)
        CommandBuffer.RemoveRange(0, 1)
    End Function


    Public Sub Writelog(NexStarCmd As CommandItem, Mode As ProtokollMode)
        Dim CommFile As Integer
        Dim i As Integer

        On Error GoTo OpenError

        CommFileName = Path.Combine(DefaultPath, "Commu_.txt")

        CommFile = FreeFile()                'Nächste freie DateiNr.
        FileOpen(CommFile, CommFileName, OpenMode.Append)

        If Mode = ProtokollMode.Send Then
            PrintLine(CommFile, NexStarCmd.No & " --> Send:    " & NexStarCmd.Comment)
            FrmCommunication.ListBox1.Items.Add(NexStarCmd.No & " --> Send:    " & NexStarCmd.Comment)
            If Not FrmCommunication.StopFlag Then
                FrmCommunication.ListBox1.SelectedIndex = FrmCommunication.ListBox1.Items.Count - 1
            End If
        ElseIf Mode = ProtokollMode.Receive Then
            PrintLine(CommFile, NexStarCmd.No & " --> Receive: " & NexStarCmd.Comment)
            FrmCommunication.ListBox1.Items.Add(NexStarCmd.No & " --> Receive: " & NexStarCmd.Comment)
            If Not FrmCommunication.StopFlag Then
                FrmCommunication.ListBox1.SelectedIndex = FrmCommunication.ListBox1.Items.Count - 1
            End If
        End If

        FileClose(CommFile)

        Exit Sub

OpenError:
        '      MsgBox(Err.Description)
    End Sub

End Module
