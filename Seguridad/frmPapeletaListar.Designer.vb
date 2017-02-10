<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPapeletaListar
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
        Me.dgLista = New System.Windows.Forms.DataGridView()
        Me.filtroFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.Agregar = New System.Windows.Forms.Button()
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLista
        '
        Me.dgLista.AllowUserToAddRows = False
        Me.dgLista.AllowUserToDeleteRows = False
        Me.dgLista.AllowUserToResizeColumns = False
        Me.dgLista.AllowUserToResizeRows = False
        Me.dgLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLista.Location = New System.Drawing.Point(12, 38)
        Me.dgLista.MultiSelect = False
        Me.dgLista.Name = "dgLista"
        Me.dgLista.ReadOnly = True
        Me.dgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLista.Size = New System.Drawing.Size(639, 253)
        Me.dgLista.TabIndex = 0
        '
        'filtroFecha
        '
        Me.filtroFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.filtroFecha.Location = New System.Drawing.Point(538, 12)
        Me.filtroFecha.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.filtroFecha.Name = "filtroFecha"
        Me.filtroFecha.Size = New System.Drawing.Size(113, 20)
        Me.filtroFecha.TabIndex = 4
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.Seguridad.My.Resources.Resources.cerrar24
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.Location = New System.Drawing.Point(102, 291)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(73, 34)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'btnAprobar
        '
        Me.btnAprobar.Enabled = False
        Me.btnAprobar.Image = Global.Seguridad.My.Resources.Resources.CHECK2_24
        Me.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAprobar.Location = New System.Drawing.Point(12, 291)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(75, 34)
        Me.btnAprobar.TabIndex = 2
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'Agregar
        '
        Me.Agregar.Image = Global.Seguridad.My.Resources.Resources.NEW24
        Me.Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Agregar.Location = New System.Drawing.Point(574, 292)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(77, 33)
        Me.Agregar.TabIndex = 1
        Me.Agregar.Text = "Agregar"
        Me.Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'frmPapeletaListar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(663, 326)
        Me.Controls.Add(Me.filtroFecha)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.Agregar)
        Me.Controls.Add(Me.dgLista)
        Me.Name = "frmPapeletaListar"
        Me.Text = "Modulo Papeleta"
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgLista As System.Windows.Forms.DataGridView
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents filtroFecha As System.Windows.Forms.DateTimePicker
End Class
