Public Class frmReporteGastosMovilidadAreaPeriodo

    Public Function GenerarCodigo(num As Integer) As String
        Dim Codigo As String
        If num < 10 Then
            Codigo = "ARE000000" + num.ToString
            Return Codigo
        Else
            Codigo = "ARE00000" + num.ToString
            Return Codigo
        End If
    End Function

    Private Sub btnReportar_Click(sender As Object, e As EventArgs) Handles btnReportar.Click
        Dim objfrom As New frmReporteAreaPerido
        objfrom.Area = GenerarCodigo(cmbArea.SelectedIndex)
        objfrom.FechaIni = CDate(dtpFechaInicio.Value.ToString)
        objfrom.FechaFin = CDate(dtpFechaFin.Value.ToString)
        objfrom.Show()
    End Sub

    Private Sub frmReporteGastosMovilidadAreaPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class