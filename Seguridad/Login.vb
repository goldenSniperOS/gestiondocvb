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
        End If
    End Sub
End Class