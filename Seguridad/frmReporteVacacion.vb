Public Class frmReporteVacacion
    Property Codigo As String


    Private Sub frmReporteVacacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objRep As New rptVacaciones
        objRep.SetParameterValue("@Codigo", Codigo)

        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class