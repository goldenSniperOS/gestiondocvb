Public Class frmReporteAreaPerido
    Property Area As String
    Property FechaIni As Date
    Property FechaFin As Date

    Private Sub frmReporteAreaPerido_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objRep As New rptGastoMovilidadAreaPeriodo
        objRep.SetParameterValue("@FechaIni", FechaIni)
        objRep.SetParameterValue("@FechaFin", FechaFin)

        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class