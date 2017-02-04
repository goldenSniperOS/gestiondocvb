<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoGastos
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
        Me.datosGasto = New System.Windows.Forms.DataGridView()
        Me.Gas_Serie_Cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc_Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc_Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aprobado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Denegado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        CType(Me.datosGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datosGasto
        '
        Me.datosGasto.AllowUserToAddRows = False
        Me.datosGasto.AllowUserToDeleteRows = False
        Me.datosGasto.AllowUserToResizeColumns = False
        Me.datosGasto.AllowUserToResizeRows = False
        Me.datosGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datosGasto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Gas_Serie_Cod, Me.doc_Numero, Me.Apellidos, Me.Nombres, Me.Area, Me.doc_Codigo, Me.Aprobado, Me.Denegado})
        Me.datosGasto.Location = New System.Drawing.Point(12, 12)
        Me.datosGasto.MultiSelect = False
        Me.datosGasto.Name = "datosGasto"
        Me.datosGasto.ReadOnly = True
        Me.datosGasto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datosGasto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datosGasto.Size = New System.Drawing.Size(911, 321)
        Me.datosGasto.TabIndex = 0
        '
        'Gas_Serie_Cod
        '
        Me.Gas_Serie_Cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Gas_Serie_Cod.DataPropertyName = "doc_Gas_SerieCod"
        Me.Gas_Serie_Cod.HeaderText = "Serie"
        Me.Gas_Serie_Cod.Name = "Gas_Serie_Cod"
        Me.Gas_Serie_Cod.ReadOnly = True
        Me.Gas_Serie_Cod.Width = 56
        '
        'doc_Numero
        '
        Me.doc_Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.doc_Numero.DataPropertyName = "doc_Numero"
        Me.doc_Numero.HeaderText = "Numero"
        Me.doc_Numero.Name = "doc_Numero"
        Me.doc_Numero.ReadOnly = True
        Me.doc_Numero.Width = 69
        '
        'Apellidos
        '
        Me.Apellidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Apellidos.DataPropertyName = "per_Apellidos"
        Me.Apellidos.HeaderText = "Apellidos"
        Me.Apellidos.Name = "Apellidos"
        Me.Apellidos.ReadOnly = True
        Me.Apellidos.Width = 74
        '
        'Nombres
        '
        Me.Nombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Nombres.DataPropertyName = "per_Nombres"
        Me.Nombres.HeaderText = "Nombres"
        Me.Nombres.Name = "Nombres"
        Me.Nombres.ReadOnly = True
        Me.Nombres.Width = 74
        '
        'Area
        '
        Me.Area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Area.DataPropertyName = "are_Nombre"
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        Me.Area.Width = 54
        '
        'doc_Codigo
        '
        Me.doc_Codigo.DataPropertyName = "doc_Codigo"
        Me.doc_Codigo.HeaderText = "Codigo"
        Me.doc_Codigo.Name = "doc_Codigo"
        Me.doc_Codigo.ReadOnly = True
        Me.doc_Codigo.Visible = False
        '
        'Aprobado
        '
        Me.Aprobado.DataPropertyName = "doc_ApruebaViat"
        Me.Aprobado.HeaderText = "Aprobado"
        Me.Aprobado.Name = "Aprobado"
        Me.Aprobado.ReadOnly = True
        '
        'Denegado
        '
        Me.Denegado.DataPropertyName = "Gas_Denegar"
        Me.Denegado.HeaderText = "Denegado"
        Me.Denegado.Name = "Denegado"
        Me.Denegado.ReadOnly = True
        Me.Denegado.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(849, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(753, 339)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(90, 23)
        Me.btnSeleccionar.TabIndex = 1
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'frmListadoGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 379)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.datosGasto)
        Me.Name = "frmListadoGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmListadoGastos"
        CType(Me.datosGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents datosGasto As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSeleccionar As Button
    Friend WithEvents Gas_Serie_Cod As DataGridViewTextBoxColumn
    Friend WithEvents doc_Numero As DataGridViewTextBoxColumn
    Friend WithEvents Apellidos As DataGridViewTextBoxColumn
    Friend WithEvents Nombres As DataGridViewTextBoxColumn
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents doc_Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Aprobado As DataGridViewTextBoxColumn
    Friend WithEvents Denegado As DataGridViewTextBoxColumn
End Class
