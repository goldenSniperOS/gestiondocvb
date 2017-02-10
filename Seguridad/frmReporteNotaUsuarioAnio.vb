Public Class frmReporteNotaUsuarioAnio
    Property Anio As Integer

    Private Sub frmReporteNotaUsuarioAnio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objRep As New rptReporteNotaUsuarioAnio
        objRep.SetParameterValue("@Año", Anio)

        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class