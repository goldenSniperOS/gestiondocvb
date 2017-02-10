Public Class frmReporteGastoMovilidadEnPeriodos
    Property FechaIni As Date
    Property FechaFin As Date

    Private Sub frmReporteGastoMovilidadEnPeriodos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objRep As New rptGastoMovilidadArea
        objRep.SetParameterValue("@FechaIni", FechaIni)
        objRep.SetParameterValue("@FechaFin", FechaFin)

        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class