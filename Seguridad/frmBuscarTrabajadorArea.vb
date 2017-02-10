Imports CapaNegocio

Public Class frmBuscarTrabajadorArea
    Public Area As String
    Public dataRetornar As DataGridViewRow
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.CellContentClick
        dataRetornar = dgvLista.Rows(e.RowIndex)
    End Sub

    Private Sub frmBuscarTrabajadorArea_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsPapeleta

        drRpta = objCargo.MantenimientoSimple("L", Area)
        dgvLista.DataSource = drRpta
        dataRetornar = dgvLista.Rows(0)
    End Sub

    Private Sub Seleccionar_Click(sender As Object, e As EventArgs) Handles Seleccionar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class