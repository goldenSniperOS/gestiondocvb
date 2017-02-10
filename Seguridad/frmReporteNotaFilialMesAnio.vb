Public Class frmReporteNotaFilialMesAnio
    Property Anio As Integer

    Private Sub frmReporteNotaFilialMesAnio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objRep As New rptNotaFilialMesAnio
        objRep.SetParameterValue("@Año", Anio)
        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class