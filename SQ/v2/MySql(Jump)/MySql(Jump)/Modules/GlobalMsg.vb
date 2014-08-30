Module GlobalMsg
    Public Sub NotifyMsgBox(ByVal mycondition As String, ByVal myobject As String)
        Select Case LCase(mycondition)
            Case "rt"
                MsgBox("Retrieving complete information failed." & vbCrLf & "Please try again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Retreiving Failed")
            Case "re"
                MsgBox("All required field must be valid.", vbInformation + MsgBoxStyle.OkOnly, "Saving Failed")
            Case "ex"
                MsgBox("Something went wrong while exporting the database." & _
                       vbCrLf & "All connection query must be closed first.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "im"
                MsgBox("Something went wrong while importing the database." & _
                       vbCrLf & "All connection query must be closed first.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "conn"
                MsgBox("The system is not connected to the server." & vbCrLf & "Please wait until it repairs the connection.", vbExclamation + vbOKOnly, "Connection Error")
            Case "pr"
                MsgBox("Something went wrong while retrieving all the " & myobject & " information." & _
                       vbCrLf & "Check you connection status then press refresh button to refresh again.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "ps"
                MsgBox("Something went wrong while saving all the " & myobject & " information." & _
                       vbCrLf & "Check your connection status then press save button to save again.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "r"
                MsgBox("Something went wrong while retrieving all the " & myobject & " information, Press reload button to refresh again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
            Case "s"
                MsgBox("Something went wrong while saving all the " & myobject & " information, Press save button to save again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
            Case "j"
                MsgBox("Only one recipient is allowed!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Jump SO Management")
            Case "a"
                MsgBox("Something went wrong while approving the selected " & myobject & ", Press approve button to save again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
            Case "as"
                MsgBox("Something went wrong while approving the selected " & myobject & "." & _
                                    vbCrLf & "Check your connection status then press approve button to save again.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "d"
                MsgBox("Something went wrong while rejecting the selected " & myobject & ", Press reject button to save again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
            Case "ds"
                MsgBox("Something went wrong while rejecting the selected " & myobject & "." & _
                                    vbCrLf & "Check your connection status then press reject button to save again.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            Case "c"
                MsgBox("Something went wrong while confirming the selected " & myobject & ", Press confirm button to save again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
            Case "cs"
                MsgBox("Something went wrong while confirming the selected " & myobject & "." & _
                                    vbCrLf & "Check your connection status then press confirm button to save again.", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
        End Select
    End Sub
End Module
