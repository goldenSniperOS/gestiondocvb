Imports CapaNegocio

Public Class frmMarcacion
    Private objVacacion As New clsPapeleta
    Private dtData As DataTable

    Private Sub LlenarData()
        Dim dtParam As New DataTable
        dtData = objVacacion.MantenimientoXML("1", dtParam)
        dgvListadoPapeletas.DataSource = dtData
    End Sub

    Private Sub dgvListadoPapeletas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListadoPapeletas.CellFormatting
        If e.ColumnIndex = 4 Then
            If e.Value = 1 Then
                e.Value = "Comisión de Servicios"
            ElseIf e.Value = 2 Then
                e.Value = "Consulta Médica"
            ElseIf e.Value = 3 Then
                e.Value = "Asuntos Personales"
            ElseIf e.Value = 4 Then
                e.Value = "Otros"
            End If
        End If
    End Sub

    Private Sub frmMarcacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarData()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Function EstructuraBuscar() As DataTable
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

    Private Function LlenarEstructuraBuscar() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = EstructuraBuscar()
            drCargo = dtCargo.NewRow

            drCargo("per_DNI") = txtDNI.Text

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BuscarDNI()
        Dim objCargo As New clsPapeleta
        Dim dtData As DataTable = Nothing
        Dim drRpta As DataTable = Nothing
        If (txtDNI.Text = "") Then
            LlenarData()
        Else
            dtData = LlenarEstructuraBuscar()
            drRpta = objCargo.MantenimientoXML("2", dtData)
            dgvListadoPapeletas.DataSource = drRpta
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarDNI()
    End Sub

    Private Function EstructuraMarca() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("Pape_Codigo", GetType(Integer))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarMarca() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = EstructuraMarca()
            drCargo = dtCargo.NewRow

            drCargo("Pape_Codigo") = dgvListadoPapeletas.CurrentRow.Cells("CODIGO").Value.ToString

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click
        If dgvListadoPapeletas.CurrentRow.Cells("Salida").Value.ToString = "00:00:00" Then
            Dim objCargo As New clsPapeleta
            Dim dtData As DataTable = Nothing
            Dim drRpta As DataRow = Nothing

            dtData = LlenarMarca()
            drRpta = objCargo.Marcacion("3", dtData)

            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                            "Sistema De Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarDNI()
        ElseIf dgvListadoPapeletas.CurrentRow.Cells("Entrada").Value.ToString = "00:00:00" Then
            Dim objCargo As New clsPapeleta
            Dim dtData As DataTable = Nothing
            Dim drRpta As DataRow = Nothing

            dtData = LlenarMarca()
            drRpta = objCargo.Marcacion("4", dtData)

            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                            "Sistema De Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarDNI()
        Else
            MessageBox.Show("Campos de Marcacion Completos")
        End If
    End Sub
End Class