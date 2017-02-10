Public Class frmNotasContablesFilialMesAño

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim objfrm As New frmReporteNotaFilialMesAnio
        objfrm.Anio = CInt(txtAnio.Text)
        objfrm.Show()
    End Sub
End Class