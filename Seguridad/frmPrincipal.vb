Imports System.Globalization
Public Class frmPrincipal
    Dim usuario As DataRow
    Public Sub DatosU(u As DataRow)
        usuario = u
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r

    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New frmPapeletas
        frm.DatosU(usuario)
        frm.ShowDialog()

    End Sub

    Private Sub RegistrarToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim frm As New frmRegistroNotaContable
        frm.ShowDialog()
    End Sub

    Private Sub RegistrarToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Dim frm As New frmRegistroDocumentoVacacion
        frm.ShowDialog()
    End Sub

    Private Sub RegistrarToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        Dim frm As New frmGastoMovilidad
        frm.ShowDialog()
    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click
        Me.Close()
    End Sub
    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) _
     Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim frm As New frmPapeletas
        panelContenedor.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        panelContenedor.Controls.Add(frm)
        frm.DatosU(usuario)
        frm.Show()

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim frm As New frmPapeletaListar
        panelContenedor.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        panelContenedor.Controls.Add(frm)
        'frm.DatosU(usuario)
        frm.Show()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim frm As New frmRegistroNotaContable
        panelContenedor.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        panelContenedor.Controls.Add(frm)
        'frm.DatosU(usuario)
        frm.Show()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Dim frm As New frmRegistroDocumentoVacacion
        panelContenedor.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        panelContenedor.Controls.Add(frm)
        'frm.DatosU(usuario)
        frm.Show()
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click

    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        Dim frm As New frmRegistroNotaContable
        panelContenedor.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        panelContenedor.Controls.Add(frm)
        'frm.DatosU(usuario)
        frm.Show()
    End Sub
End Class