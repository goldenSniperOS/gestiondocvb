Imports CapaNegocio

Public Class frmListadoPersona
    Property persona As DataRow

    Private Sub frmListadoPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsBD As New clsPersona
        dgvPersonas.DataSource = clsBD.Listado


    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        persona = (DirectCast(dgvPersonas.SelectedRows(0).DataBoundItem, DataRowView)).Row
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim clsBD As New clsPersona
        dgvPersonas.DataSource = clsBD.Filtro(txtFiltro.Text)
    End Sub
End Class