<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Mpape = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNotaCont = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MVacaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MTramite = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mpape, Me.MNotaCont, Me.MVacaciones, Me.MTramite})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(693, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Mpape
        '
        Me.Mpape.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem, Me.ListarToolStripMenuItem})
        Me.Mpape.Name = "Mpape"
        Me.Mpape.Size = New System.Drawing.Size(64, 20)
        Me.Mpape.Text = "Papeleta"
        '
        'RegistrarToolStripMenuItem
        '
        Me.RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem"
        Me.RegistrarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RegistrarToolStripMenuItem.Text = "Registrar"
        '
        'MNotaCont
        '
        Me.MNotaCont.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem1})
        Me.MNotaCont.Name = "MNotaCont"
        Me.MNotaCont.Size = New System.Drawing.Size(96, 20)
        Me.MNotaCont.Text = "Nota Contable"
        '
        'RegistrarToolStripMenuItem1
        '
        Me.RegistrarToolStripMenuItem1.Name = "RegistrarToolStripMenuItem1"
        Me.RegistrarToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.RegistrarToolStripMenuItem1.Text = "Registrar"
        '
        'MVacaciones
        '
        Me.MVacaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem2})
        Me.MVacaciones.Name = "MVacaciones"
        Me.MVacaciones.Size = New System.Drawing.Size(77, 20)
        Me.MVacaciones.Text = "Vacaciones"
        '
        'RegistrarToolStripMenuItem2
        '
        Me.RegistrarToolStripMenuItem2.Name = "RegistrarToolStripMenuItem2"
        Me.RegistrarToolStripMenuItem2.Size = New System.Drawing.Size(120, 22)
        Me.RegistrarToolStripMenuItem2.Text = "Registrar"
        '
        'MTramite
        '
        Me.MTramite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem3})
        Me.MTramite.Name = "MTramite"
        Me.MTramite.Size = New System.Drawing.Size(59, 20)
        Me.MTramite.Text = "Tramite"
        '
        'RegistrarToolStripMenuItem3
        '
        Me.RegistrarToolStripMenuItem3.Name = "RegistrarToolStripMenuItem3"
        Me.RegistrarToolStripMenuItem3.Size = New System.Drawing.Size(120, 22)
        Me.RegistrarToolStripMenuItem3.Text = "Registrar"
        '
        'ListarToolStripMenuItem
        '
        Me.ListarToolStripMenuItem.Name = "ListarToolStripMenuItem"
        Me.ListarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ListarToolStripMenuItem.Text = "Listar"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 324)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPrincipal"
        Me.Text = "frmPrincipal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Mpape As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNotaCont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MVacaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MTramite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
