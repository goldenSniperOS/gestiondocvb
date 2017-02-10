Imports CapaNegocio
Public Class Login

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    Private Function GetEstructuraCliente() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("usu_Nombre", GetType(String))
                .Add("usu_Contrasena", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarDatos() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = GetEstructuraCliente()
            drCargo = dtCargo.NewRow

            drCargo("usu_Nombre") = txtUsu.Text
            drCargo("usu_Contrasena") = txtCont.Text
            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception

            Throw ex
        End Try
    End Function
    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim usu As Integer
        Dim con As Integer
        If txtUsu.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtUsu, "Ingresa Usuario")
            usu = 0
        Else
            usu = 1
        End If

        If txtCont.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCont, "Ingresa Contraseña")
            con = 0
        Else
            con = 1
        End If

        If usu = 1 And con = 1 Then
            ErrorProvider1.SetError(txtUsu, "")
            ErrorProvider1.SetError(txtCont, "")
            Dim objCargo As New clsUsuario
            Dim dtData As DataTable = Nothing
            Dim drRpta As DataTable = Nothing

            dtData = LlenarDatos()

            drRpta = objCargo.Login(dtData)
            If drRpta.Rows.Count <> 0 Then
                MsgBox("Bienvenid@ " + drRpta.Rows(0)("per_Nombres").ToString + " " + drRpta.Rows(0)("per_Apellidos").ToString)
                Dim objfrom As New frmPrincipal
                objfrom.permissions = drRpta
                objfrom.userQuery = dtData
                objfrom.Show()
                Me.Hide()
            Else
                MsgBox("DATOS INCORRECTOS O AUN NO TIENE PERMISOS PARA EL SISTEMA. POR FAVOR CONTACTAR CON EL ADMINISTRADOR", MsgBoxStyle.Exclamation)
                limpiar()
            End If
        End If
        
    End Sub
    Public Sub limpiar()
        txtCont.Text = ""
        txtUsu.Text = ""
        ErrorProvider1.Clear()
    End Sub
    Private Sub txtUsu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsu.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCont_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCont.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class