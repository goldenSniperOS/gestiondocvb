<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoDocumentoVacacion
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_RETORNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JEFE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RRHH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DNI:"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(47, 6)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(230, 20)
        Me.txtDNI.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(283, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(176, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(380, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "LISTADO DE VACACIONES"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.FECHA, Me.APELLIDOS, Me.NOMBRES, Me.FECHA_SALIDA, Me.FECHA_RETORNO, Me.DIAS, Me.JEFE, Me.RRHH})
        Me.dgvListado.Location = New System.Drawing.Point(12, 59)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(933, 535)
        Me.dgvListado.TabIndex = 4
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "Vaca_Codigo"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CODIGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CODIGO.Visible = False
        '
        'FECHA
        '
        Me.FECHA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FECHA.DataPropertyName = "doc_Fecha"
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Width = 67
        '
        'APELLIDOS
        '
        Me.APELLIDOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.APELLIDOS.DataPropertyName = "per_Apellidos"
        Me.APELLIDOS.HeaderText = "APELLIDOS"
        Me.APELLIDOS.Name = "APELLIDOS"
        Me.APELLIDOS.ReadOnly = True
        Me.APELLIDOS.Width = 91
        '
        'NOMBRES
        '
        Me.NOMBRES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NOMBRES.DataPropertyName = "per_Nombres"
        Me.NOMBRES.HeaderText = "NOMBRES"
        Me.NOMBRES.Name = "NOMBRES"
        Me.NOMBRES.ReadOnly = True
        Me.NOMBRES.Width = 86
        '
        'FECHA_SALIDA
        '
        Me.FECHA_SALIDA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FECHA_SALIDA.DataPropertyName = "Vaca_FechaSalida"
        Me.FECHA_SALIDA.HeaderText = "FECHA_SALIDA"
        Me.FECHA_SALIDA.Name = "FECHA_SALIDA"
        Me.FECHA_SALIDA.ReadOnly = True
        Me.FECHA_SALIDA.Width = 111
        '
        'FECHA_RETORNO
        '
        Me.FECHA_RETORNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FECHA_RETORNO.DataPropertyName = "Vaca_FechaRetorno"
        Me.FECHA_RETORNO.HeaderText = "FECHA_RETORNO"
        Me.FECHA_RETORNO.Name = "FECHA_RETORNO"
        Me.FECHA_RETORNO.ReadOnly = True
        Me.FECHA_RETORNO.Width = 127
        '
        'DIAS
        '
        Me.DIAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DIAS.DataPropertyName = "Vaca_Dias"
        Me.DIAS.HeaderText = "DIAS"
        Me.DIAS.Name = "DIAS"
        Me.DIAS.ReadOnly = True
        Me.DIAS.Width = 57
        '
        'JEFE
        '
        Me.JEFE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JEFE.DataPropertyName = "Vaca_Pape_ApruebaJefe"
        Me.JEFE.HeaderText = "JEFE"
        Me.JEFE.Name = "JEFE"
        Me.JEFE.ReadOnly = True
        Me.JEFE.Width = 57
        '
        'RRHH
        '
        Me.RRHH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RRHH.DataPropertyName = "Vaca_Pape_ApruebaRRHH"
        Me.RRHH.HeaderText = "RRHH"
        Me.RRHH.Name = "RRHH"
        Me.RRHH.ReadOnly = True
        Me.RRHH.Width = 64
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(689, 4)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 5
        Me.btnVer.Text = "VER"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'btnAprobar
        '
        Me.btnAprobar.Location = New System.Drawing.Point(770, 4)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(75, 23)
        Me.btnAprobar.TabIndex = 6
        Me.btnAprobar.Text = "APROBAR"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'frmListadoDocumentoVacacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 606)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtDNI)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmListadoDocumentoVacacion"
        Me.Text = "frmListadoDocumentoVacacion"
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APELLIDOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_RETORNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JEFE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RRHH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
End Class
