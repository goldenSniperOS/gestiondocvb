<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoPersona
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
        Me.dgvPersonas = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoCivil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estudios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioContrasena = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioTramite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioMarcacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioPapeleta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioNotaContable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioGasto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DistritoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZonaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreZona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaNacimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DireccionCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPeople = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaducidadDNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CargoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProvinciaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartamentoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtro:"
        '
        'dgvPersonas
        '
        Me.dgvPersonas.AllowUserToAddRows = False
        Me.dgvPersonas.AllowUserToDeleteRows = False
        Me.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.EstadoCivil, Me.Estudios, Me.UsuarioCodigo, Me.UsuarioNombre, Me.UsuarioContrasena, Me.UsuarioTramite, Me.UsuarioMarcacion, Me.UsuarioPapeleta, Me.UsuarioNotaContable, Me.UsuarioGasto, Me.UsuarioPersona, Me.UsuarioVacaciones, Me.DistritoCodigo, Me.ViaCodigo, Me.ZonaCodigo, Me.NombreZona, Me.NombreVia, Me.NumeroVia, Me.FechaNacimiento, Me.DireccionCodigo, Me.Email, Me.Nombres, Me.Apellidos, Me.DNI, Me.CodPeople, Me.Area, Me.Cargo, Me.CaducidadDNI, Me.CodigoArea, Me.CargoCodigo, Me.Prefijo, Me.Sexo, Me.ProvinciaCodigo, Me.DepartamentoCodigo})
        Me.dgvPersonas.Location = New System.Drawing.Point(15, 43)
        Me.dgvPersonas.MultiSelect = False
        Me.dgvPersonas.Name = "dgvPersonas"
        Me.dgvPersonas.ReadOnly = True
        Me.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPersonas.Size = New System.Drawing.Size(1057, 383)
        Me.dgvPersonas.TabIndex = 1
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "per_Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Visible = False
        '
        'EstadoCivil
        '
        Me.EstadoCivil.DataPropertyName = "per_EstadoCivil"
        Me.EstadoCivil.HeaderText = "EstadoCivil"
        Me.EstadoCivil.Name = "EstadoCivil"
        Me.EstadoCivil.ReadOnly = True
        Me.EstadoCivil.Visible = False
        '
        'Estudios
        '
        Me.Estudios.DataPropertyName = "per_Estudios"
        Me.Estudios.HeaderText = "Estudios"
        Me.Estudios.Name = "Estudios"
        Me.Estudios.ReadOnly = True
        Me.Estudios.Visible = False
        '
        'UsuarioCodigo
        '
        Me.UsuarioCodigo.DataPropertyName = "usu_Codigo"
        Me.UsuarioCodigo.HeaderText = "UsuarioCodigo"
        Me.UsuarioCodigo.Name = "UsuarioCodigo"
        Me.UsuarioCodigo.ReadOnly = True
        Me.UsuarioCodigo.Visible = False
        '
        'UsuarioNombre
        '
        Me.UsuarioNombre.DataPropertyName = "usu_Nombre"
        Me.UsuarioNombre.HeaderText = "UsuarioNombre"
        Me.UsuarioNombre.Name = "UsuarioNombre"
        Me.UsuarioNombre.ReadOnly = True
        Me.UsuarioNombre.Visible = False
        '
        'UsuarioContrasena
        '
        Me.UsuarioContrasena.DataPropertyName = "usu_Contrasena"
        Me.UsuarioContrasena.HeaderText = "UsuarioContrasena"
        Me.UsuarioContrasena.Name = "UsuarioContrasena"
        Me.UsuarioContrasena.ReadOnly = True
        Me.UsuarioContrasena.Visible = False
        '
        'UsuarioTramite
        '
        Me.UsuarioTramite.DataPropertyName = "usu_Tramite"
        Me.UsuarioTramite.HeaderText = "UsuarioTramite"
        Me.UsuarioTramite.Name = "UsuarioTramite"
        Me.UsuarioTramite.ReadOnly = True
        Me.UsuarioTramite.Visible = False
        '
        'UsuarioMarcacion
        '
        Me.UsuarioMarcacion.DataPropertyName = "usu_Marcacion"
        Me.UsuarioMarcacion.HeaderText = "UsuarioMarcacion"
        Me.UsuarioMarcacion.Name = "UsuarioMarcacion"
        Me.UsuarioMarcacion.ReadOnly = True
        Me.UsuarioMarcacion.Visible = False
        '
        'UsuarioPapeleta
        '
        Me.UsuarioPapeleta.DataPropertyName = "usu_Papeleta"
        Me.UsuarioPapeleta.HeaderText = "UsuarioPapeleta"
        Me.UsuarioPapeleta.Name = "UsuarioPapeleta"
        Me.UsuarioPapeleta.ReadOnly = True
        Me.UsuarioPapeleta.Visible = False
        '
        'UsuarioNotaContable
        '
        Me.UsuarioNotaContable.DataPropertyName = "usu_NotaContable"
        Me.UsuarioNotaContable.HeaderText = "UsuarioNotaContable"
        Me.UsuarioNotaContable.Name = "UsuarioNotaContable"
        Me.UsuarioNotaContable.ReadOnly = True
        Me.UsuarioNotaContable.Visible = False
        '
        'UsuarioGasto
        '
        Me.UsuarioGasto.DataPropertyName = "usu_Beneficio"
        Me.UsuarioGasto.HeaderText = "UsuarioGasto"
        Me.UsuarioGasto.Name = "UsuarioGasto"
        Me.UsuarioGasto.ReadOnly = True
        Me.UsuarioGasto.Visible = False
        '
        'UsuarioPersona
        '
        Me.UsuarioPersona.DataPropertyName = "usu_Persona"
        Me.UsuarioPersona.HeaderText = "UsuarioPersona"
        Me.UsuarioPersona.Name = "UsuarioPersona"
        Me.UsuarioPersona.ReadOnly = True
        Me.UsuarioPersona.Visible = False
        '
        'UsuarioVacaciones
        '
        Me.UsuarioVacaciones.DataPropertyName = "usu_Vacaciones"
        Me.UsuarioVacaciones.HeaderText = "UsuarioVacaciones"
        Me.UsuarioVacaciones.Name = "UsuarioVacaciones"
        Me.UsuarioVacaciones.ReadOnly = True
        Me.UsuarioVacaciones.Visible = False
        '
        'DistritoCodigo
        '
        Me.DistritoCodigo.DataPropertyName = "pdi_dis_Codigo"
        Me.DistritoCodigo.HeaderText = "DistritoCodigo"
        Me.DistritoCodigo.Name = "DistritoCodigo"
        Me.DistritoCodigo.ReadOnly = True
        Me.DistritoCodigo.Visible = False
        '
        'ViaCodigo
        '
        Me.ViaCodigo.DataPropertyName = "pdi_pvi_Codigo"
        Me.ViaCodigo.HeaderText = "ViaCodigo"
        Me.ViaCodigo.Name = "ViaCodigo"
        Me.ViaCodigo.ReadOnly = True
        Me.ViaCodigo.Visible = False
        '
        'ZonaCodigo
        '
        Me.ZonaCodigo.DataPropertyName = "pdi_pzo_Codigo"
        Me.ZonaCodigo.HeaderText = "ZonaCodigo"
        Me.ZonaCodigo.Name = "ZonaCodigo"
        Me.ZonaCodigo.ReadOnly = True
        Me.ZonaCodigo.Visible = False
        '
        'NombreZona
        '
        Me.NombreZona.DataPropertyName = "pdi_NombreZona"
        Me.NombreZona.HeaderText = "NombreZona"
        Me.NombreZona.Name = "NombreZona"
        Me.NombreZona.ReadOnly = True
        Me.NombreZona.Visible = False
        '
        'NombreVia
        '
        Me.NombreVia.DataPropertyName = "pdi_NombreVia"
        Me.NombreVia.HeaderText = "NombreVia"
        Me.NombreVia.Name = "NombreVia"
        Me.NombreVia.ReadOnly = True
        Me.NombreVia.Visible = False
        '
        'NumeroVia
        '
        Me.NumeroVia.DataPropertyName = "pdi_Numero"
        Me.NumeroVia.HeaderText = "NumeroVia"
        Me.NumeroVia.Name = "NumeroVia"
        Me.NumeroVia.ReadOnly = True
        Me.NumeroVia.Visible = False
        '
        'FechaNacimiento
        '
        Me.FechaNacimiento.DataPropertyName = "per_Nacimiento"
        Me.FechaNacimiento.HeaderText = "FechaNacimiento"
        Me.FechaNacimiento.Name = "FechaNacimiento"
        Me.FechaNacimiento.ReadOnly = True
        Me.FechaNacimiento.Visible = False
        '
        'DireccionCodigo
        '
        Me.DireccionCodigo.DataPropertyName = "pdi_Codigo"
        Me.DireccionCodigo.HeaderText = "DireccionCodigo"
        Me.DireccionCodigo.Name = "DireccionCodigo"
        Me.DireccionCodigo.ReadOnly = True
        Me.DireccionCodigo.Visible = False
        '
        'Email
        '
        Me.Email.DataPropertyName = "per_Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Visible = False
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
        'Apellidos
        '
        Me.Apellidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Apellidos.DataPropertyName = "per_Apellidos"
        Me.Apellidos.HeaderText = "Apellidos"
        Me.Apellidos.Name = "Apellidos"
        Me.Apellidos.ReadOnly = True
        Me.Apellidos.Width = 74
        '
        'DNI
        '
        Me.DNI.DataPropertyName = "per_DNI"
        Me.DNI.HeaderText = "DNI"
        Me.DNI.Name = "DNI"
        Me.DNI.ReadOnly = True
        '
        'CodPeople
        '
        Me.CodPeople.DataPropertyName = "per_CodPeople"
        Me.CodPeople.HeaderText = "CodPeople"
        Me.CodPeople.Name = "CodPeople"
        Me.CodPeople.ReadOnly = True
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
        'Cargo
        '
        Me.Cargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cargo.DataPropertyName = "pca_Nombre"
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Width = 60
        '
        'CaducidadDNI
        '
        Me.CaducidadDNI.DataPropertyName = "per_DNICaducidad"
        Me.CaducidadDNI.HeaderText = "CaducidadDNI"
        Me.CaducidadDNI.Name = "CaducidadDNI"
        Me.CaducidadDNI.ReadOnly = True
        Me.CaducidadDNI.Visible = False
        '
        'CodigoArea
        '
        Me.CodigoArea.DataPropertyName = "are_Codigo"
        Me.CodigoArea.HeaderText = "CodigoArea"
        Me.CodigoArea.Name = "CodigoArea"
        Me.CodigoArea.ReadOnly = True
        Me.CodigoArea.Visible = False
        '
        'CargoCodigo
        '
        Me.CargoCodigo.DataPropertyName = "pca_Codigo"
        Me.CargoCodigo.HeaderText = "CargoCodigo"
        Me.CargoCodigo.Name = "CargoCodigo"
        Me.CargoCodigo.ReadOnly = True
        Me.CargoCodigo.Visible = False
        '
        'Prefijo
        '
        Me.Prefijo.DataPropertyName = "per_ppr_Codigo"
        Me.Prefijo.HeaderText = "Prefijo"
        Me.Prefijo.Name = "Prefijo"
        Me.Prefijo.ReadOnly = True
        Me.Prefijo.Visible = False
        '
        'Sexo
        '
        Me.Sexo.DataPropertyName = "per_Sexo"
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
        Me.Sexo.Visible = False
        '
        'ProvinciaCodigo
        '
        Me.ProvinciaCodigo.DataPropertyName = "pro_Codigo"
        Me.ProvinciaCodigo.HeaderText = "ProvinciaCodigo"
        Me.ProvinciaCodigo.Name = "ProvinciaCodigo"
        Me.ProvinciaCodigo.ReadOnly = True
        Me.ProvinciaCodigo.Visible = False
        '
        'DepartamentoCodigo
        '
        Me.DepartamentoCodigo.DataPropertyName = "dep_Codigo"
        Me.DepartamentoCodigo.HeaderText = "DepartamentoCodigo"
        Me.DepartamentoCodigo.Name = "DepartamentoCodigo"
        Me.DepartamentoCodigo.ReadOnly = True
        Me.DepartamentoCodigo.Visible = False
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(997, 432)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionar.TabIndex = 2
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(50, 17)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(941, 20)
        Me.txtFiltro.TabIndex = 3
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(997, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmListadoPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 478)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.dgvPersonas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmListadoPersona"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmListadoPersona"
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvPersonas As DataGridView
    Friend WithEvents btnSeleccionar As Button
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents EstadoCivil As DataGridViewTextBoxColumn
    Friend WithEvents Estudios As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCodigo As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioNombre As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioContrasena As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioTramite As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioMarcacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioPapeleta As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioNotaContable As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioGasto As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioPersona As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioVacaciones As DataGridViewTextBoxColumn
    Friend WithEvents DistritoCodigo As DataGridViewTextBoxColumn
    Friend WithEvents ViaCodigo As DataGridViewTextBoxColumn
    Friend WithEvents ZonaCodigo As DataGridViewTextBoxColumn
    Friend WithEvents NombreZona As DataGridViewTextBoxColumn
    Friend WithEvents NombreVia As DataGridViewTextBoxColumn
    Friend WithEvents NumeroVia As DataGridViewTextBoxColumn
    Friend WithEvents FechaNacimiento As DataGridViewTextBoxColumn
    Friend WithEvents DireccionCodigo As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Nombres As DataGridViewTextBoxColumn
    Friend WithEvents Apellidos As DataGridViewTextBoxColumn
    Friend WithEvents DNI As DataGridViewTextBoxColumn
    Friend WithEvents CodPeople As DataGridViewTextBoxColumn
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents Cargo As DataGridViewTextBoxColumn
    Friend WithEvents CaducidadDNI As DataGridViewTextBoxColumn
    Friend WithEvents CodigoArea As DataGridViewTextBoxColumn
    Friend WithEvents CargoCodigo As DataGridViewTextBoxColumn
    Friend WithEvents Prefijo As DataGridViewTextBoxColumn
    Friend WithEvents Sexo As DataGridViewTextBoxColumn
    Friend WithEvents ProvinciaCodigo As DataGridViewTextBoxColumn
    Friend WithEvents DepartamentoCodigo As DataGridViewTextBoxColumn
End Class
