Imports CapaNegocio

Public Class frmRegistroDocumentoVacacion
    Dim usuario As DataRow
    Dim NuevoCodigoDocumento As String
    Dim StartDate As Date
    Dim EndDate As Date
    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable
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


    Private Function GetEstructuraDocumentoVacacion() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("Vaca_doc_Cod", GetType(String))
                .Add("Vaca_FechaSalida", GetType(String))
                .Add("Vaca_FechaTermino", GetType(String))
                .Add("Vaca_FechaRetorno", GetType(String))
                .Add("Vaca_Dias", GetType(Integer))
                .Add("Vaca_Pape_ApruebaJefe", GetType(String))
                .Add("Vaca_Pape_ApruebaRRHH", GetType(String))
                .Add("Vaca_Observacion", GetType(String))
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
            drCargo("doc_usu_Codigo") = usuarioLogueado("usu_Codigo")
            drCargo("doc_Numero") = "PAPELETA-0100025-OFA/UCV-CH-16"
            drCargo("doc_dan_Codigo") = "DAN010"
            drCargo("doc_Titulo") = "DTI0000008"
            drCargo("doc_Remitente") = usuarioLogueado("usu_Codigo")
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

    Private Sub CodigoDocumento()
        Dim dataResult As DataRow = Nothing
        Dim objNegocio As New clsDocumentoVacacion

        dataResult = objNegocio.Inicializar("I")

        Dim ultimoCodigo As String = dataResult("doc_Codigo")
        Dim codigo As Integer = Integer.Parse(ultimoCodigo.Substring(3))
        Dim nuevoCodigo As String = (codigo + 1) & ""
        nuevoCodigo = nuevoCodigo.PadLeft(7, "0")
        txtCodigo.Text = "DOC" & nuevoCodigo
    End Sub

    Private Function LlenarDatosDocumentoVacacion() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing
        Try
            dtCargo = GetEstructuraDocumentoVacacion()
            drCargo = dtCargo.NewRow

            drCargo("Vaca_doc_Cod") = NuevoCodigoDocumento
            drCargo("Vaca_FechaSalida") = dtpFechaSalida.Value.ToString("yyyy-MM-dd")
            drCargo("Vaca_FechaTermino") = EndDate.ToString("yyyy-MM-dd")
            drCargo("Vaca_FechaRetorno") = EndDate.AddDays(1).ToString("yyyy-MM-dd")
            drCargo("Vaca_Dias") = cmbDias.SelectedItem
            drCargo("Vaca_Pape_ApruebaJefe") = "NO"
            drCargo("Vaca_Pape_ApruebaRRHH") = "NO"
            drCargo("Vaca_Observacion") = ""

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objCargo As New clsMantenimiento
        Dim dtData As DataTable = Nothing
        Dim drRpta As DataRow = Nothing
        CodigoDocumento()
        dtData = LlenarDatos()

        drRpta = objCargo.MantenimientoDocumento("R", dtData)

        Dim objCargo2 As New clsDocumentoVacacion
        Dim dtData2 As DataTable = Nothing
        Dim drRpta2 As DataRow = Nothing

        dtData2 = LlenarDatosDocumentoVacacion()

        drRpta2 = objCargo2.Mantenimiento("R", dtData2)

        MessageBox.Show(drRpta2.Item("MensajeTitulo").ToString & vbCrLf & drRpta2.Item("MensajeProcedure").ToString, _
                        "Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Calcular()
        StartDate = dtpFechaSalida.Value
        EndDate = StartDate.Add(TimeSpan.FromDays(CInt(cmbDias.SelectedItem)))
        If EndDate.DayOfWeek = DayOfWeek.Sunday Then
            EndDate = EndDate.Add(TimeSpan.FromDays(1))
        End If
        Calendar.SelectionRange = New SelectionRange(StartDate, EndDate)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Calcular()
    End Sub
End Class