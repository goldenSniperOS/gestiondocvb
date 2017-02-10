Imports CapaNegocio

Public Class frmPapeletaListar



    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable
    Public dataRetornar As DataGridViewRow
    

    Private Sub CargarDatos()
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsPapeleta
        drRpta = objCargo.MantenimientoSimple("LP", filtroFecha.Value.ToString("yyyy-MM-dd"))
        dgLista.DataSource = drRpta
        dgLista.ClearSelection()
    End Sub

    Private Sub frmPapeletaListar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
        If (usuarioLogueado("per_Codigo") = usuarioLogueado("par_per_Codigo")) Then
            btnAprobar.Visible = True
        End If

        'dataRetornar = dgvLista.Rows(0)
    End Sub
    Private Sub dgLista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLista.CellContentClick
        dataRetornar = dgLista.Rows(e.RowIndex)
        If dataRetornar.Cells(4).Value = "NO" Then
            btnAprobar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnAprobar.Enabled = False
            btnEliminar.Enabled = False

        End If
        If usuarioLogueado("per_Nombres") = dataRetornar.Cells(0).Value And
            usuarioLogueado("per_Apellidos") = dataRetornar.Cells(1).Value Then
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Dim frmNuevo As New frmPapeletas
        frmNuevo.DatosU(usuarioLogueado)
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

    Private Sub filtroFecha_ValueChanged(sender As Object, e As EventArgs) Handles filtroFecha.ValueChanged
        CargarDatos()
    End Sub

    Private Sub dgLista_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgLista.CellFormatting
        'If e.Value = "SI" Then
        'If e.Value IsNot Nothing Then
        'e.CellStyle.BackColor = Color.LightGreen
        'End If
        'ElseIf e.Value = "NO" Then
        'If e.Value IsNot Nothing Then
        'e.CellStyle.BackColor = Color.LightCoral
        'End If
        'End If
    End Sub
End Class