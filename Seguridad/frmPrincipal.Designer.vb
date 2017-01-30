<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mnuGeneral = New System.Windows.Forms.MenuStrip()
        Me.SuspendLayout()
        '
        'mnuGeneral
        '
        Me.mnuGeneral.Location = New System.Drawing.Point(0, 0)
        Me.mnuGeneral.Name = "mnuGeneral"
        Me.mnuGeneral.Size = New System.Drawing.Size(693, 24)
        Me.mnuGeneral.TabIndex = 0
        Me.mnuGeneral.Text = "MenuStrip1"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 324)
        Me.Controls.Add(Me.mnuGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.mnuGeneral
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrincipal"
        Me.Text = "frmPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuGeneral As System.Windows.Forms.MenuStrip
End Class
