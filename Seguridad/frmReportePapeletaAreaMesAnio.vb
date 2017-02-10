Public Class frmReportePapeletaAreaMesAnio
    Property Anio As Integer


    Private Sub frmReportePapeletaAreaMesAnio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objRep As New rptReportePapeletaAreaMesAnio
        objRep.SetParameterValue("@Año", Anio)

        CrystalReportViewer1.ReportSource = objRep
    End Sub
End Class