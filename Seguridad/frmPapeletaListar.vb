Imports CapaNegocio

Public Class frmPapeletaListar

    Dim usuario As DataRow
    Public dataRetornar As DataGridViewRow
    Public Sub DatosU(u As DataRow)
        usuario = u
    End Sub

    Private Sub CargarDatos()
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsPapeleta
        drRpta = objCargo.MantenimientoSimple("LP", usuario("par_are_Codigo"))
        dgLista.DataSource = drRpta
        dgLista.ClearSelection()
    End Sub

    Private Sub frmPapeletaListar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
        'dataRetornar = dgvLista.Rows(0)
    End Sub
    Private Sub dgLista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLista.CellContentClick
        dataRetornar = dgLista.Rows(e.RowIndex)
        If dataRetornar.Cells(5).Value = "NO" Then
            btnAprobar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnAprobar.Enabled = False
            btnEliminar.Enabled = False

        End If
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Dim frmNuevo As New frmPapeletas
        frmNuevo.DatosU(usuario)
        If frmNuevo.ShowDialog() = DialogResult.OK Then
            CargarDatos()
        End If

    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Dim result As Integer = MessageBox.Show("¿Desea aprobar la papeleta de " +
                                                dataRetornar.Cells(1).Value + "" +
                                                dataRetornar.Cells(2).Value + "?",
                                                "APROBAR PAPELETA",
                                                MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then
            MessageBox.Show("Proceso Cancelado")
        ElseIf result = DialogResult.Yes Then
            MessageBox.Show("Papeleta Aprobada")
            Dim drRpta As DataTable = Nothing
            Dim objCargo As New clsPapeleta
            drRpta = objCargo.MantenimientoSimple("A", dataRetornar.Cells(0).Value)
            dataRetornar.Cells(5).Value = "SI"
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As Integer = MessageBox.Show("¿Desea eliminar la papeleta de " +
                                                dataRetornar.Cells(1).Value + "" +
                                                dataRetornar.Cells(2).Value + "?",
                                                "ELIMINAR PAPELETA",
                                                MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then
            MessageBox.Show("Proceso Cancelado")
        ElseIf result = DialogResult.Yes Then
            MessageBox.Show("Papeleta Eliminada")
            Dim drRpta As DataTable = Nothing
            Dim objCargo As New clsPapeleta
            drRpta = objCargo.MantenimientoSimple("D", dataRetornar.Cells(0).Value)
            dgLista.Rows.Remove(dataRetornar)
        End If
    End Sub
End Class