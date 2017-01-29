Public Class frmPrincipal
    Dim usuario As DataRow
    Public Sub DatosU(u As DataRow)
        usuario = u
    End Sub
    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) _
     Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r

    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click
        Dim frm As New frmPapeletas
        frm.ShowDialog()

    End Sub

    Private Sub RegistrarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem1.Click
        Dim frm As New frmRegistroNotaContable
        frm.ShowDialog()
    End Sub

    Private Sub RegistrarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem2.Click
        Dim frm As New frmRegistroDocumentoVacacion
        frm.ShowDialog()
    End Sub

    Private Sub RegistrarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem3.Click
        Dim frm As New frmGastoMovilidad
        frm.ShowDialog()
    End Sub

    Private Sub ListarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListarToolStripMenuItem.Click
        Dim frm As New frmPapeletaListar
        frm.ShowDialog()
    End Sub
End Class