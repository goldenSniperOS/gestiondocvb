Imports CapaNegocio
Public Class frmListadoDocumentoVacacion
    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable

    Private objVacacion As New clsDocumentoVacacion
    Private dtData As DataTable

    Private Sub LlenarData()
        Dim dtParam As New DataTable
        dtData = objVacacion.Listar("1", dtParam)
        dgvListado.DataSource = dtData
    End Sub

    Private Function EstructuraPorArea() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("are_Codigo", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarDatosPorArea() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = EstructuraPorArea()
            drCargo = dtCargo.NewRow

            drCargo("are_Codigo") = usuarioLogueado.Item("are_Codigo").ToString

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub LlenarDataPorArea()
        Dim dtParam As New DataTable
        dtParam = LlenarDatosPorArea()
        dtData = objVacacion.Listar("2", dtParam)
        dgvListado.DataSource = dtData
    End Sub

    Private Sub VerificarUsuario()
        If (usuarioLogueado.Item("usu_per_Codigo") = usuarioLogueado.Item("are_Jefe") Or
           usuarioLogueado.Item("are_Codigo") = "ARE0000042") Then
            btnAprobar.Visible = True
        Else
            btnAprobar.Visible = False
        End If

        If usuarioLogueado.Item("are_Codigo") = "ARE0000042" Then
            LlenarData()
        Else
            LlenarDataPorArea()
        End If
    End Sub
    Private Sub frmListadoDocumentoVacacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerificarUsuario()
    End Sub

    Private Function GetEstructuraConsulta() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("per_DNI", GetType(String))
                .Add("are_Codigo", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarDatosConsulta() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = GetEstructuraConsulta()
            drCargo = dtCargo.NewRow

            drCargo("per_DNI") = txtDNI.Text
            drCargo("are_Codigo") = usuarioLogueado.Item("are_Codigo")

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetEstructuraConsultaRRHH() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("per_DNI", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarDatosConsultaRRHH() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = GetEstructuraConsulta()
            drCargo = dtCargo.NewRow

            drCargo("per_DNI") = txtDNI.Text

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ConsultaListado()
        Dim objCargo As New clsDocumentoVacacion
        Dim dtData As DataTable = Nothing
        Dim drRpta As DataTable = Nothing
        If (txtDNI.Text = "") Then
            VerificarUsuario()
        Else
            If usuarioLogueado.Item("are_Codigo") = "ARE0000042" Then
                dtData = LlenarDatosConsultaRRHH()
                drRpta = objCargo.Listar("6", dtData)
                dgvListado.DataSource = drRpta
            Else
                dtData = LlenarDatosConsulta()
                drRpta = objCargo.Listar("3", dtData)
                dgvListado.DataSource = drRpta
            End If
        End If
    End Sub

    Private Function EstructuraAprueba() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("Vaca_Codigo", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarAprueba() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = EstructuraAprueba()
            drCargo = dtCargo.NewRow

            drCargo("Vaca_Codigo") = dgvListado.CurrentRow.Cells("CODIGO").Value.ToString

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaListado()
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        If (usuarioLogueado.Item("are_Codigo") = "ARE0000042" And usuarioLogueado.Item("usu_Vacaciones") = "SI") Then
            Dim objCargo As New clsDocumentoVacacion
            Dim dtData As DataTable = Nothing
            Dim drRpta As DataRow = Nothing

            dtData = LlenarAprueba()
            drRpta = objCargo.Mantenimiento("5", dtData)

            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                            "Sistema De Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VerificarUsuario()
        ElseIf usuarioLogueado.Item("usu_per_Codigo") = usuarioLogueado.Item("are_Jefe") Then
            Dim objCargo As New clsDocumentoVacacion
            Dim dtData As DataTable = Nothing
            Dim drRpta As DataRow = Nothing

            dtData = LlenarAprueba()
            drRpta = objCargo.Mantenimiento("4", dtData)

            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                            "Sistema De Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VerificarUsuario()
        Else
        MessageBox.Show("Usted No Tiene Permiso Para Aceptar Vacaciones")
        End If
    End Sub
End Class