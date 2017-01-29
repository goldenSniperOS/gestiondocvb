Imports CapaNegocio

Public Class frmPapeletas
    Dim usuario As DataRow
    Public Sub DatosU(u As DataRow)
        usuario = u
    End Sub
    Private Function getEstructuraMantenimiento() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("doc_Codigo", GetType(String))
                .Add("doc_dpl_Codigo", GetType(String))
                .Add("doc_usu_Codigo", GetType(String))
                .Add("doc_Numero", GetType(String))
                .Add("doc_dan_Codigo", GetType(String))
                .Add("doc_Titulo", GetType(String))
                .Add("doc_Remitente", GetType(String))
                .Add("doc_Destinatario", GetType(String))
                .Add("doc_Asunto", GetType(String))
                .Add("doc_Contenido", GetType(String))
                .Add("doc_Referencia", GetType(String))
                .Add("doc_Estado", GetType(Integer))
                .Add("doc_Actividad", GetType(String))
                .Add("doc_CodigoPresupues", GetType(String))
                .Add("doc_Meta", GetType(String))
                .Add("doc_DescargaDocumento", GetType(String))
                .Add("doc_ConfirmaFirma", GetType(String))
                .Add("doc_Firma", GetType(String))
                .Add("doc_Fecha", GetType(String))
                .Add("doc_Gas_SerieCod", GetType(String))
                .Add("doc_ApruebaMov", GetType(String))
                .Add("doc_ApruebaPape", GetType(String))
                .Add("doc_ApruebaViat", GetType(String))

            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function getEstructuraMantenimientoPapeleta() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("Pape_Codigo", GetType(Integer))
                .Add("Pape_doc_Cod", GetType(String))
                .Add("Pape_Motivo", GetType(String))
                .Add("Pape_Lugar", GetType(String))
                .Add("Pape_Justificacion", GetType(String))
                .Add("Pape_Retorno", GetType(String))
                .Add("Pape_Fecha", GetType(String))
                .Add("Pape_HoraSalida", GetType(String))
                .Add("Pape_HoraEntrada", GetType(String))
                .Add("Pape_ApruebaPapeRRHH", GetType(String))
                .Add("Pape_Observacion", GetType(String))

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
            dtCargo = getEstructuraMantenimiento()
            drCargo = dtCargo.NewRow
            drCargo("doc_Codigo") = txtCodigo.Text
            drCargo("doc_dpl_Codigo") = "DPL0000010"
            drCargo("doc_usu_Codigo") = usuario("usu_Codigo")
            drCargo("doc_Numero") = "PAPELETA-0100025-OFA/UCV-CH-16"
            drCargo("doc_dan_Codigo") = "DAN010"
            drCargo("doc_Titulo") = "DTI0000008"
            drCargo("doc_Remitente") = lbCodigoRemitente.Text
            drCargo("doc_Fecha") = Date.Now.ToString("yyyy-MM-dd")
            drCargo("doc_Destinatario") = "PER0000084"
            drCargo("doc_Asunto") = ""
            drCargo("doc_Contenido") = ""
            drCargo("doc_Referencia") = ""
            drCargo("doc_Estado") = 1
            drCargo("doc_Actividad") = ""
            drCargo("doc_CodigoPresupues") = ""
            drCargo("doc_Meta") = ""
            drCargo("doc_DescargaDocumento") = ""
            drCargo("doc_ConfirmaFirma") = "NO"
            drCargo("doc_Firma") = "NO"
            drCargo("doc_Gas_SerieCod") = ""
            drCargo("doc_ApruebaMov") = "NO"
            drCargo("doc_ApruebaPape") = "NO"
            drCargo("doc_ApruebaViat") = "NO"
            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function LlenarDatosPapeleta() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing

        Try
            dtCargo = getEstructuraMantenimientoPapeleta()
            drCargo = dtCargo.NewRow
            Dim Motivo As Integer
            Select Case cbMotivo.SelectedItem.ToString
                Case "Comisión de Servicios"
                    Motivo = 1
                Case "Consulta Médica"
                    Motivo = 2
                Case "Asuntos Personales"
                    Motivo = 3
                Case "Otros"
                    Motivo = 4
            End Select
            drCargo("Pape_doc_Cod") = txtCodigo.Text
            drCargo("Pape_Motivo") = Motivo
            drCargo("Pape_Lugar") = txtLugar.Text
            drCargo("Pape_Justificacion") = txtJustificacion.Text
            drCargo("Pape_Retorno") = cbRetorno.SelectedItem.ToString
            drCargo("Pape_Fecha") = txtFecha.Value.Date.ToString("yyyy-MM-dd")
            drCargo("Pape_HoraSalida") = "00:00:00"
            drCargo("Pape_HoraEntrada") = "00:00:00"
            drCargo("Pape_ApruebaPapeRRHH") = "NO"
            drCargo("Pape_Observacion") = ""
            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub Nuevo()
        Dim dataResult As DataRow = Nothing
        Dim objNegocio As New clsMantenimientoPapeleta

        dataResult = objNegocio.Inicializar("I")

        Dim ultimoCodigo As String = dataResult("doc_Codigo")
        Dim codigo As Integer = Integer.Parse(ultimoCodigo.Substring(3))
        Dim nuevoCodigo As String = (codigo + 1) & ""
        nuevoCodigo = nuevoCodigo.PadLeft(7, "0")
        txtCodigo.Text = "DOC" & nuevoCodigo

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objCargo As New clsMantenimiento
        Dim dtData As DataTable = Nothing
        Dim drRpta As DataRow = Nothing
        Dim objPapeleta As New clsMantenimientoPapeleta
        Dim dtDataPapeleta As DataTable = Nothing
        Dim drRptaPapeleta As DataRow = Nothing
        dtData = LlenarDatos()
        drRpta = objCargo.MantenimientoDocumento("R", dtData)
        dtDataPapeleta = LlenarDatosPapeleta()
        drRptaPapeleta = objPapeleta.Mantenimiento("R", dtDataPapeleta)
        MessageBox.Show(drRptaPapeleta.Item("MensajeTitulo").ToString & vbCrLf & drRptaPapeleta.Item("MensajeProcedure").ToString, _
                            "Sistema Banco", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frmDialogo As New frmBuscarTrabajadorArea
        frmDialogo.Area = usuario("par_are_Codigo")
        If frmDialogo.ShowDialog() = DialogResult.OK Then
            lbCodigoRemitente.Text = frmDialogo.dataRetornar.Cells(0).Value
            lbRemitente.Text = frmDialogo.dataRetornar.Cells(1).Value + "" + frmDialogo.dataRetornar.Cells(2).Value
        End If
    End Sub

    Private Sub frmPapeletas_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbMotivo.SelectedIndex = 0
        cbRetorno.SelectedIndex = 0
        Nuevo()
    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged

    End Sub
End Class