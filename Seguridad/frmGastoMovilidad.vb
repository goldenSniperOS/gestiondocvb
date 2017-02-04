Imports CapaNegocio

Public Class frmGastoMovilidad
    Dim modificando As Boolean = False

    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable

    Private dataControl As DataTable
    Private Sub frmGastoMovilidad_Load(sender As Object, e As EventArgs) Handles Me.Load
        dataControl = New DataTable

        With dataControl.Columns
            .Add("Gas_doc_Cod", GetType(String))
            .Add("Gas_Usuario", GetType(String))
            .Add("Gas_Fecha", GetType(Date))
            .Add("Gas_Motivo", GetType(String))
            .Add("Gas_Ruta", GetType(String))
            .Add("Gas_Subtotal", GetType(Decimal))
            .Add("Gas_Tipo", GetType(String))
            .Add("Gas_Denegar", GetType(String))
        End With
        dataControl.Rows.Clear()
        dtpNuevoGasto.MaxDate = DateTime.Today
        Nuevo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmDialogo As New frmListadoGastos
        If frmDialogo.ShowDialog() = DialogResult.OK Then
            dgvDetalle.DataSource = frmDialogo.listadoRetornar

            btnRegistrar.Enabled = False
            modificando = True
            btnAprobar.Enabled = True
            gbGasto.Enabled = False
        End If
    End Sub

    Private Sub Nuevo()
        Dim dataResult As DataRow = Nothing
        Dim objNegocio As New clsGasto

        While (dgvDetalle.Rows.Count > 0)
            dgvDetalle.Rows.RemoveAt(0)
        End While

        dataControl.Rows.Clear()
    End Sub

    Private Sub btnAddGasto_Click(sender As Object, e As EventArgs) Handles btnAddGasto.Click
        dgvDetalle.DataSource = dataControl

        Dim drCargo As DataRow = Nothing
        drCargo = dataControl.NewRow
        drCargo("Gas_Usuario") = usuarioLogueado("usu_Codigo")
        drCargo("Gas_Motivo") = txtMotivo.Text
        drCargo("Gas_Ruta") = txtRuta.Text
        drCargo("Gas_Fecha") = dtpNuevoGasto.Value.Date
        drCargo("Gas_Subtotal") = Decimal.Parse(txtSubtotal.Text)
        drCargo("Gas_Tipo") = "D"
        drCargo("Gas_Denegar") = "NO"
        dataControl.Rows.Add(drCargo)
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim cargoDocumento As New clsDocumento
        Dim cargoGasto As New clsGasto

        Dim dataResult As DataRow = Nothing
        Dim objNegocio As New clsGasto

        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("doc_Codigo", GetType(String))
                .Add("doc_dpl_Codigo", GetType(String))
                .Add("doc_usu_Codigo", GetType(String))
                .Add("doc_Fecha", GetType(Date))
                .Add("doc_Hora", GetType(DateTime))
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
                .Add("doc_Gas_SerieCod", GetType(String))
                .Add("doc_ApruebaMov", GetType(String))
                .Add("doc_ApruebaPape", GetType(String))
                .Add("doc_ApruebaViat", GetType(String))
            End With
            dtCargo.Rows.Clear()


            Dim drCargo As DataRow = Nothing
            drCargo = dtCargo.NewRow

            drCargo("doc_dpl_Codigo") = "DPL0000007"
            drCargo("doc_usu_Codigo") = usuarioLogueado("usu_Codigo")
            drCargo("doc_Fecha") = dtpFechaDocumento.Value.Date
            drCargo("doc_Hora") = CType(dtpFechaDocumento.Value.Hour.ToString + ":" + dtpFechaDocumento.Value.Minute.ToString + ":" + dtpFechaDocumento.Value.Second.ToString, DateTime)
            drCargo("doc_Numero") = usuarioLogueado("are_Abreviatura")
            drCargo("doc_dan_Codigo") = "DAN010"
            drCargo("doc_Titulo") = "DTI0000006"
            drCargo("doc_Remitente") = usuarioLogueado("per_Codigo")
            drCargo("doc_Destinatario") = "PER0000126"
            drCargo("doc_Asunto") = ""
            drCargo("doc_Contenido") = ""
            drCargo("doc_Referencia") = ""
            drCargo("doc_Estado") = CInt("1")
            drCargo("doc_Actividad") = ""
            drCargo("doc_CodigoPresupues") = ""
            drCargo("doc_Meta") = ""
            drCargo("doc_DescargaDocumento") = ""
            drCargo("doc_ConfirmaFirma") = ""
            drCargo("doc_Firma") = ""
            drCargo("doc_ApruebaMov") = "NO"
            drCargo("doc_ApruebaPape") = "NO"
            drCargo("doc_ApruebaViat") = "NO"
            dtCargo.Rows.Add(drCargo)

            Dim drRptaDocumento As DataRow = Nothing
            Dim drRpta As DataRow = Nothing

            drRptaDocumento = cargoDocumento.Mantenimiento("RG", dtCargo)

            txtNumero.Text = drRptaDocumento("doc_Numero")
            txtSerie.Text = drRptaDocumento("doc_Gas_SerieCod")

            For Each row As DataRow In dataControl.Rows
                row("Gas_doc_Cod") = drRptaDocumento("doc_Codigo")
            Next row

            drRpta = cargoGasto.Mantenimiento("R", dataControl)

            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                        "Sistema GestionDoc", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
        txtMotivo.Text = ""
        txtRuta.Text = ""
        txtSubtotal.Text = ""
        btnRegistrar.Enabled = True
        modificando = False
        btnAprobar.Enabled = False
        gbGasto.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs)
        Dim dtCargo As New DataTable

        Dim cargoGasto As New clsGasto

        With dtCargo.Columns
            .Add("Gas_doc_Cod", GetType(String))
            .Add("Gas_Denegar", GetType(String))
        End With

        Dim drCargo As DataRow = Nothing
        drCargo = dtCargo.NewRow

        drCargo("Gas_doc_Cod") = dgvDetalle.Rows(0).Cells(4).Value
        drCargo("Gas_Denegar") = "NO"
        dtCargo.Rows.Add(drCargo)

        Dim drRpta As DataRow = Nothing
        drRpta = cargoGasto.Mantenimiento("AP", dtCargo)
        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                    "Sistema GestionDoc", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub btnAprobar_Click_1(sender As Object, e As EventArgs) Handles btnAprobar.Click

    End Sub
End Class
