Imports CapaNegocio

Public Class frmPapeletaListar

    Private Sub frmPapeletaListar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsPapeleta
        drRpta = objCargo.Listado("L")
        dgLista.DataSource = drRpta
        'dataRetornar = dgvLista.Rows(0)
    End Sub
    Private Sub dgLista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLista.CellContentClick

    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Dim frmNuevo As New frmPapeletas
        frmNuevo.Show()

    End Sub
End Class