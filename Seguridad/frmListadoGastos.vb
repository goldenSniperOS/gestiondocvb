Imports CapaNegocio

Public Class frmListadoGastos
    Public dataRetornar As DataGridViewRow
    Public listadoRetornar As DataTable
    Property documento As DataRow

    Private Sub frmListadoGastos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsGasto
        drRpta = objCargo.Listado("L")
        datosGasto.DataSource = drRpta
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsGasto

        Dim dataMandar As New DataTable
        dataMandar.Columns.Add("doc_Codigo", GetType(String))
        Dim rowMandar As DataRow = Nothing
        rowMandar = dataMandar.NewRow
        rowMandar("doc_Codigo") = datosGasto.SelectedRows(0).Cells(5).Value
        documento = (DirectCast(datosGasto.SelectedRows(0).DataBoundItem, DataRowView)).Row

        dataMandar.Rows.Add(rowMandar)

        drRpta = objCargo.Listado("LD", dataMandar)
        listadoRetornar = drRpta
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub datosGasto_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles datosGasto.CellFormatting
        If e.Value = "SI" Then
            If e.Value IsNot Nothing Then
                e.CellStyle.BackColor = Color.LightGreen
            End If
        ElseIf e.Value = "NO" Then
            If e.Value IsNot Nothing Then
                e.CellStyle.BackColor = Color.LightCoral
            End If
        End If
    End Sub
End Class