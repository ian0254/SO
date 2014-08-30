Public Class FrmCP

    Private Sub FrmCP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If txtNP.Text <> txtCNP.Text Then
            MsgBox("New password does not match.", vbInformation + MsgBoxStyle.OkOnly, "New Password Mismatched")
            txtNP.Clear()
            txtCNP.Clear()
            txtNP.Focus()
        End If

        If txtOP.Text <> "" And txtNP.Text <> "" And txtCNP.Text <> "" And txtUN.Text <> "" Then
            Dim slot As Integer = CreateConn(-1)
            If slot > 0 Then
                Try
                    With sqlcommand(slot)
                        With .Parameters
                            .Clear()
                            .AddWithValue("@un", txtUN.Text)
                            .AddWithValue("@ps", txtOP.Text)
                            .AddWithValue("@id", My.Settings.LID)
                            .AddWithValue("@np", txtNP.Text)
                        End With
                        .CommandText = ("SELECT COUNT(*) FROM tbl_login WHERE ctrl_id=@id AND uname=@un AND upass=@ps")
                        Dim es = Convert.ToInt32(.ExecuteScalar)
                        If es = 0 Then
                            MsgBox("Incorrect account information.", vbInformation + MsgBoxStyle.OkOnly, "Change Password Failed")
                            txtNP.Clear()
                            txtOP.Clear()
                            txtCNP.Clear()
                            txtOP.Focus()
                        Else
                            .CommandText = ("UPDATE tbl_login SET upass=@np WHERE ctrl_id=@id")
                            .ExecuteNonQuery()
                            MsgBox("Your account password is now changed.", vbInformation + MsgBoxStyle.OkOnly, "Change Password Success")
                            txtNP.Clear()
                            txtOP.Clear()
                            txtCNP.Clear()
                            txtUN.Clear()
                            txtUN.Focus()
                        End If
                        CloseConn(slot)
                    End With
                Catch ex As Exception
                    CloseConn(slot)
                    MsgBox("Something went wrong while retrieving all the account information, Press save button to save again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
                End Try
            Else
                MsgBox("Something went wrong while retrieving all the account information." & _
                       vbCrLf & "If there is an available query slot try to press save button to save again..", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            End If
        Else
            MsgBox("You missed a required field.", vbInformation + MsgBoxStyle.OkOnly, "Required Field Missing")
        End If
    End Sub
End Class