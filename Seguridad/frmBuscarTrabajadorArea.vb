Imports CapaNegocio

Public Class frmBuscarTrabajadorArea
    Public Area As String
    Public dataRetornar As DataGridViewRow
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.CellContentClick
        dataRetornar = dgvLista.Rows(e.RowIndex)
    End Sub

    Private Function getEstructura() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("Area", GetType(String))

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
            dtCargo = getEstructura()
            drCargo = dtCargo.NewRow

            drCargo("Area") = Area
            dtCargo.Rows.Add(drCargo)
            Return dtCargo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub frmBuscarTrabajadorArea_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsCliente

        Dim dtData As DataTable = Nothing
        dtData = LlenarDatos()
        drRpta = objCargo.Listado("L", dtData)
        dgvLista.DataSource = drRpta
        dataRetornar = dgvLista.Rows(0)
    End Sub

    Private Sub Seleccionar_Click(sender As Object, e As EventArgs) Handles Seleccionar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class