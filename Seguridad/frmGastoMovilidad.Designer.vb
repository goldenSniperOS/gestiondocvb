<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGastoMovilidad
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.dtpFechaDocumento = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.Gas_Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_Subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_doc_Cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gas_Denegar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.gbGasto = New System.Windows.Forms.GroupBox()
        Me.btnAddGasto = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpNuevoGasto = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGasto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(282, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "NUMERO"
        '
        'txtNumero
        '
        Me.txtNumero.Enabled = False
        Me.txtNumero.Location = New System.Drawing.Point(343, 6)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(230, 20)
        Me.txtNumero.TabIndex = 1
        '
        'dtpFechaDocumento
        '
        Me.dtpFechaDocumento.Enabled = False
        Me.dtpFechaDocumento.Location = New System.Drawing.Point(61, 6)
        Me.dtpFechaDocumento.Name = "dtpFechaDocumento"
        Me.dtpFechaDocumento.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaDocumento.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "FECHA"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Gas_Fecha, Me.Gas_Motivo, Me.Gas_Ruta, Me.Gas_Subtotal, Me.Gas_doc_Cod, Me.Gas_Usuario, Me.Gas_Denegar})
        Me.dgvDetalle.Location = New System.Drawing.Point(16, 222)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(767, 181)
        Me.dgvDetalle.TabIndex = 4
        '
        'Gas_Fecha
        '
        Me.Gas_Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Gas_Fecha.DataPropertyName = "Gas_Fecha"
        Me.Gas_Fecha.HeaderText = "Fecha"
        Me.Gas_Fecha.Name = "Gas_Fecha"
        Me.Gas_Fecha.ReadOnly = True
        Me.Gas_Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gas_Fecha.Width = 62
        '
        'Gas_Motivo
        '
        Me.Gas_Motivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Gas_Motivo.DataPropertyName = "Gas_Motivo"
        Me.Gas_Motivo.HeaderText = "Motivo"
        Me.Gas_Motivo.Name = "Gas_Motivo"
        Me.Gas_Motivo.ReadOnly = True
        Me.Gas_Motivo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gas_Motivo.Width = 64
        '
        'Gas_Ruta
        '
        Me.Gas_Ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Gas_Ruta.DataPropertyName = "Gas_Ruta"
        Me.Gas_Ruta.HeaderText = "Ruta"
        Me.Gas_Ruta.Name = "Gas_Ruta"
        Me.Gas_Ruta.ReadOnly = True
        Me.Gas_Ruta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gas_Ruta.Width = 55
        '
        'Gas_Subtotal
        '
        Me.Gas_Subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Gas_Subtotal.DataPropertyName = "Gas_Subtotal"
        Me.Gas_Subtotal.HeaderText = "Subtotal"
        Me.Gas_Subtotal.Name = "Gas_Subtotal"
        Me.Gas_Subtotal.ReadOnly = True
        Me.Gas_Subtotal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gas_Subtotal.Width = 71
        '
        'Gas_doc_Cod
        '
        Me.Gas_doc_Cod.DataPropertyName = "Gas_doc_Cod"
        Me.Gas_doc_Cod.HeaderText = "Codigo"
        Me.Gas_doc_Cod.Name = "Gas_doc_Cod"
        Me.Gas_doc_Cod.ReadOnly = True
        Me.Gas_doc_Cod.Visible = False
        '
        'Gas_Usuario
        '
        Me.Gas_Usuario.DataPropertyName = "Gas_Usuario"
        Me.Gas_Usuario.HeaderText = "Usuario"
        Me.Gas_Usuario.Name = "Gas_Usuario"
        Me.Gas_Usuario.ReadOnly = True
        Me.Gas_Usuario.Visible = False
        '
        'Gas_Denegar
        '
        Me.Gas_Denegar.DataPropertyName = "Gas_Denegar"
        Me.Gas_Denegar.HeaderText = "Denegar"
        Me.Gas_Denegar.Name = "Gas_Denegar"
        Me.Gas_Denegar.ReadOnly = True
        Me.Gas_Denegar.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Gastos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(579, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "SERIE"
        '
        'txtSerie
        '
        Me.txtSerie.Enabled = False
        Me.txtSerie.Location = New System.Drawing.Point(629, 6)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(154, 20)
        Me.txtSerie.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 409)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(710, 412)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(629, 412)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 2
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'gbGasto
        '
        Me.gbGasto.Controls.Add(Me.btnAddGasto)
        Me.gbGasto.Controls.Add(Me.Label6)
        Me.gbGasto.Controls.Add(Me.dtpNuevoGasto)
        Me.gbGasto.Controls.Add(Me.Label9)
        Me.gbGasto.Controls.Add(Me.txtSubtotal)
        Me.gbGasto.Controls.Add(Me.Label8)
        Me.gbGasto.Controls.Add(Me.txtRuta)
        Me.gbGasto.Controls.Add(Me.Label7)
        Me.gbGasto.Controls.Add(Me.txtMotivo)
        Me.gbGasto.Location = New System.Drawing.Point(18, 49)
        Me.gbGasto.Name = "gbGasto"
        Me.gbGasto.Size = New System.Drawing.Size(614, 135)
        Me.gbGasto.TabIndex = 1
        Me.gbGasto.TabStop = False
        Me.gbGasto.Text = "Nuevo Gasto"
        '
        'btnAddGasto
        '
        Me.btnAddGasto.Location = New System.Drawing.Point(467, 98)
        Me.btnAddGasto.Name = "btnAddGasto"
        Me.btnAddGasto.Size = New System.Drawing.Size(121, 23)
        Me.btnAddGasto.TabIndex = 4
        Me.btnAddGasto.Text = "Agregar Gasto"
        Me.btnAddGasto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "FECHA GASTO"
        '
        'dtpNuevoGasto
        '
        Me.dtpNuevoGasto.Location = New System.Drawing.Point(100, 22)
        Me.dtpNuevoGasto.MaxDate = New Date(2017, 2, 3, 0, 0, 0, 0)
        Me.dtpNuevoGasto.Name = "dtpNuevoGasto"
        Me.dtpNuevoGasto.Size = New System.Drawing.Size(208, 20)
        Me.dtpNuevoGasto.TabIndex = 0
        Me.dtpNuevoGasto.Value = New Date(2017, 2, 3, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "SUBTOTAL"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(100, 100)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(62, 20)
        Me.txtSubtotal.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RUTA"
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(100, 74)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(488, 20)
        Me.txtRuta.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "MOTIVO"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(100, 48)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(488, 20)
        Me.txtMotivo.TabIndex = 1
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(547, 412)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAprobar
        '
        Me.btnAprobar.Enabled = False
        Me.btnAprobar.Location = New System.Drawing.Point(679, 100)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(75, 23)
        Me.btnAprobar.TabIndex = 11
        Me.btnAprobar.Text = "APROBAR"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'frmGastoMovilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 447)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.gbGasto)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFechaDocumento)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGastoMovilidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGastoMovilidad"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGasto.ResumeLayout(False)
        Me.gbGasto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents dtpFechaDocumento As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents gbGasto As GroupBox
    Friend WithEvents btnAddGasto As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpNuevoGasto As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Gas_Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Gas_Motivo As DataGridViewTextBoxColumn
    Friend WithEvents Gas_Ruta As DataGridViewTextBoxColumn
    Friend WithEvents Gas_Subtotal As DataGridViewTextBoxColumn
    Friend WithEvents Gas_doc_Cod As DataGridViewTextBoxColumn
    Friend WithEvents Gas_Usuario As DataGridViewTextBoxColumn
    Friend WithEvents Gas_Denegar As DataGridViewTextBoxColumn
    Friend WithEvents btnAprobar As Button
End Class
