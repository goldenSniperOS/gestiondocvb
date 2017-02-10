Public Class frmGastoMovilidadEnPeriodos

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim objfrom As New frmReporteGastoMovilidadEnPeriodos
        objfrom.FechaIni = CDate(dtpFechaIni.Value.ToString)
        objfrom.FechaFin = CDate(dtpFechaFin.Value.ToString)
        objfrom.Show()
    End Sub
End Class