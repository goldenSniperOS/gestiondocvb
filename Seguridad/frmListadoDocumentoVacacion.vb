Imports CapaNegocio
Public Class frmListadoDocumentoVacacion
    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable

    Private objVacacion As New clsDocumentoVacacion
    Private dtData As DataTable
    Public dgvrSeleccion As DataGridViewRow

    Private Sub LlenarData()
        Dim dtParam As New DataTable
        dtData = objVacacion.Listar("1", dtParam)
        dgvListado.DataSource = dtData
    End Sub

    Private Sub frmListadoDocumentoVacacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarData()
    End Sub

    Private Function GetEstructuraConsulta() As DataTable
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

    Private Function LlenarDatosConsulta() As DataTable
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
            LlenarData()
        Else
            dtData = LlenarDatosConsulta()
            drRpta = objCargo.Listar("2", dtData)
            dgvListado.DataSource = drRpta
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaListado()
    End Sub
End Class