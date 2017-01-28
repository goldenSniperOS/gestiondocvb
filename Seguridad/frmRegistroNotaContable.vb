Imports CapaNegocio

Public Class frmRegistroNotaContable
    Dim usuario As DataRow
    Dim NuevoCodigoDocumento As String

    Public Sub DatosU(u As DataRow)
        usuario = u
    End Sub

    Private Function GetEstructuraDocumento() As DataTable
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
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function GetEstructuraNotaContable() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns

                .Add("Ndcon_doc_Cod", GetType(String))
                .Add("Ndcon_Usuario", GetType(String))
                .Add("Ndcon_Fecha", GetType(Date))
                .Add("Ndcon_Motivo", GetType(String))
                .Add("Ndcon_Subtotal", GetType(Decimal))
                .Add("Ndcon_Denegar", GetType(String))
                .Add("Ndcon_Filialuno", GetType(String))
                .Add("Ndcon_Cargouno", GetType(String))
                .Add("Ndcon_Abonouno", GetType(String))
                .Add("Ndcon_Filialdos", GetType(String))
                .Add("Ndcon_Cargodos", GetType(String))
                .Add("Ndcon_Abonodos", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function LlenarDatosDocumento() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing
        Try
            dtCargo = GetEstructuraDocumento()
            drCargo = dtCargo.NewRow

            drCargo("doc_Codigo") = NuevoCodigoDocumento
            drCargo("doc_dpl_Codigo") = "DPL0000007"
            drCargo("doc_usu_Codigo") = usuario.Item("usu_Codigo")
            drCargo("doc_Fecha") = dtpDocumento.Value.Date
            drCargo("doc_Hora") = CType(dtpDocumento.Value.Hour.ToString + ":" + dtpDocumento.Value.Minute.ToString + ":" + dtpDocumento.Value.Second.ToString, DateTime)
            drCargo("doc_Numero") = txtNumero.Text
            drCargo("doc_dan_Codigo") = "DAN010"
            drCargo("doc_Titulo") = "DTI0000009"
            drCargo("doc_Remitente") = txtRemitente.Text
            drCargo("doc_Destinatario") = txtDestinatario.Text
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

    Private Function LlenarDatosNotaContable() As DataTable
        Dim dtCargo As DataTable = Nothing
        Dim drCargo As DataRow = Nothing
        Try
            dtCargo = GetEstructuraNotaContable()
            drCargo = dtCargo.NewRow

            drCargo("Ndcon_doc_Cod") = NuevoCodigoDocumento
            drCargo("Ndcon_Usuario") = usuario.Item("usu_Codigo")
            drCargo("Ndcon_Fecha") = dtpFecha.Value.Date
            drCargo("Ndcon_Motivo") = txtMotivo.Text
            drCargo("Ndcon_Subtotal") = CDec(txtSubtotal.Text)
            drCargo("Ndcon_Denegar") = txtDenegar.Text
            drCargo("Ndcon_Filialuno") = txtFilialuno.Text
            drCargo("Ndcon_Cargouno") = txtCargouno.Text
            drCargo("Ndcon_Abonouno") = txtAbonouno.Text
            drCargo("Ndcon_Filialdos") = txtFilialdos.Text
            drCargo("Ndcon_Cargodos") = txtCargodos.Text
            drCargo("Ndcon_Abonodos") = txtAbonodos.Text

            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objCargo As New clsDocumento
        Dim dtData As DataTable = Nothing
        Dim drRpta As DataRow = Nothing
        NuevoCodigoDocumento = CodigoDocumento()

        dtData = LlenarDatosDocumento()

        drRpta = objCargo.Mantenimiento("R", dtData)

        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                        "Sistema Documentario", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim objCargo2 As New clsNotaContable
        Dim dtData2 As DataTable = Nothing
        Dim drRpta2 As DataRow = Nothing

        dtData2 = LlenarDatosNotaContable()

        drRpta2 = objCargo2.Mantenimiento("R", dtData2)

        MessageBox.Show(drRpta2.Item("MensajeTitulo").ToString & vbCrLf & drRpta2.Item("MensajeProcedure").ToString, _
                        "Sistema Documentario", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function CodigoDocumento() As String
        Dim dataResult As DataRow = Nothing
        Dim objNegocio As New clsGasto
        Dim docCodigo As String
        Try
            dataResult = objNegocio.Inicializar("I")

            txtNumero.Text = dataResult("doc_Numero")

            Dim ultimoCodigo As String = dataResult("doc_Codigo")
            Dim codigo As Integer = Integer.Parse(UltimoCodigo.Substring(3))
            Dim nuevoCodigo As String = (codigo + 1) & ""
            nuevoCodigo = nuevoCodigo.PadLeft(7, "0")

            docCodigo = "DOC" & nuevoCodigo

            Return docCodigo
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub frmRegistroNotaContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class