Imports CapaNegocio

Public Class frmListadoGastos
    Public dataRetornar As DataGridViewRow
    Public listadoRetornar As DataTable
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

        dataMandar.Rows.Add(rowMandar)

        drRpta = objCargo.Listado("LD", dataMandar)
        listadoRetornar = drRpta
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class