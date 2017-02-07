<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Me.gbListado = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gbUsuario = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbRol = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.trvPermisos = New System.Windows.Forms.TreeView()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.chkNotaContable = New System.Windows.Forms.CheckBox()
        Me.chkMarcacion = New System.Windows.Forms.CheckBox()
        Me.chkGasto = New System.Windows.Forms.CheckBox()
        Me.chkVacaciones = New System.Windows.Forms.CheckBox()
        Me.chkPapeleta = New System.Windows.Forms.CheckBox()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.lblLogueado = New System.Windows.Forms.Label()
        Me.gbListado.SuspendLayout()
        Me.gbUsuario.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbListado
        '
        Me.gbListado.Controls.Add(Me.dgvUsuarios)
        Me.gbListado.Controls.Add(Me.btnEliminar)
        Me.gbListado.Controls.Add(Me.btnNuevo)
        Me.gbListado.Controls.Add(Me.btnModificar)
        Me.gbListado.Controls.Add(Me.Label2)
        Me.gbListado.Controls.Add(Me.txtFiltro)
        Me.gbListado.Controls.Add(Me.btnBuscar)
        Me.gbListado.Location = New System.Drawing.Point(352, 31)
        Me.gbListado.Name = "gbListado"
        Me.gbListado.Size = New System.Drawing.Size(538, 240)
        Me.gbListado.TabIndex = 13
        Me.gbListado.TabStop = False
        Me.gbListado.Text = "Listado"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(295, 200)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(376, 200)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 8
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(457, 200)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 7
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Filtro"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(38, 17)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(413, 20)
        Me.txtFiltro.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(457, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gbUsuario
        '
        Me.gbUsuario.Controls.Add(Me.Label5)
        Me.gbUsuario.Controls.Add(Me.cmbRol)
        Me.gbUsuario.Controls.Add(Me.txtPassword)
        Me.gbUsuario.Controls.Add(Me.Label4)
        Me.gbUsuario.Controls.Add(Me.Label3)
        Me.gbUsuario.Controls.Add(Me.txtUsuario)
        Me.gbUsuario.Enabled = False
        Me.gbUsuario.Location = New System.Drawing.Point(352, 277)
        Me.gbUsuario.Name = "gbUsuario"
        Me.gbUsuario.Size = New System.Drawing.Size(532, 104)
        Me.gbUsuario.TabIndex = 12
        Me.gbUsuario.TabStop = False
        Me.gbUsuario.Text = "Usuario"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Rol"
        '
        'cmbRol
        '
        Me.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRol.FormattingEnabled = True
        Me.cmbRol.Location = New System.Drawing.Point(98, 66)
        Me.cmbRol.Name = "cmbRol"
        Me.cmbRol.Size = New System.Drawing.Size(428, 21)
        Me.cmbRol.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(98, 39)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(428, 20)
        Me.txtPassword.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(98, 13)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(428, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Location = New System.Drawing.Point(12, 9)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(64, 13)
        Me.lblHead.TabIndex = 11
        Me.lblHead.Text = "Permisos de"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(755, 387)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(129, 23)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar Cambios"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'trvPermisos
        '
        Me.trvPermisos.CheckBoxes = True
        Me.trvPermisos.Location = New System.Drawing.Point(12, 74)
        Me.trvPermisos.Name = "trvPermisos"
        Me.trvPermisos.Size = New System.Drawing.Size(310, 307)
        Me.trvPermisos.TabIndex = 9
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Telefono, Me.EstadoCivil, Me.Estudios, Me.UsuarioCodigo, Me.UsuarioNombre, Me.UsuarioContrasena, Me.UsuarioTramite, Me.UsuarioMarcacion, Me.UsuarioPapeleta, Me.UsuarioNotaContable, Me.UsuarioGasto, Me.UsuarioPersona, Me.UsuarioVacaciones, Me.DistritoCodigo, Me.ViaCodigo, Me.ZonaCodigo, Me.NombreZona, Me.NombreVia, Me.NumeroVia, Me.FechaNacimiento, Me.DireccionCodigo, Me.Email, Me.Nombres, Me.Apellidos, Me.DNI, Me.CodPeople, Me.Area, Me.Cargo, Me.CaducidadDNI, Me.CodigoArea, Me.CargoCodigo, Me.Prefijo, Me.Sexo, Me.ProvinciaCodigo, Me.DepartamentoCodigo})
        Me.dgvUsuarios.Location = New System.Drawing.Point(6, 43)
        Me.dgvUsuarios.MultiSelect = False
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(526, 140)
        Me.dgvUsuarios.TabIndex = 14
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "per_Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Visible = False
        '
        'Telefono
        '
        Me.Telefono.DataPropertyName = "per_Telefono"
        Me.Telefono.HeaderText = "Telefono"
        Me.Telefono.Name = "Telefono"
        Me.Telefono.ReadOnly = True
        Me.Telefono.Visible = False
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
        Me.Area.Visible = False
        Me.Area.Width = 54
        '
        'Cargo
        '
        Me.Cargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cargo.DataPropertyName = "pca_Nombre"
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Visible = False
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
        'chkNotaContable
        '
        Me.chkNotaContable.AutoSize = True
        Me.chkNotaContable.Location = New System.Drawing.Point(228, 53)
        Me.chkNotaContable.Name = "chkNotaContable"
        Me.chkNotaContable.Size = New System.Drawing.Size(94, 17)
        Me.chkNotaContable.TabIndex = 17
        Me.chkNotaContable.Text = "Nota Contable"
        Me.chkNotaContable.UseVisualStyleBackColor = True
        '
        'chkMarcacion
        '
        Me.chkMarcacion.AutoSize = True
        Me.chkMarcacion.Location = New System.Drawing.Point(114, 53)
        Me.chkMarcacion.Name = "chkMarcacion"
        Me.chkMarcacion.Size = New System.Drawing.Size(76, 17)
        Me.chkMarcacion.TabIndex = 18
        Me.chkMarcacion.Text = "Marcacion"
        Me.chkMarcacion.UseVisualStyleBackColor = True
        '
        'chkGasto
        '
        Me.chkGasto.AutoSize = True
        Me.chkGasto.Location = New System.Drawing.Point(15, 53)
        Me.chkGasto.Name = "chkGasto"
        Me.chkGasto.Size = New System.Drawing.Size(54, 17)
        Me.chkGasto.TabIndex = 19
        Me.chkGasto.Text = "Gasto"
        Me.chkGasto.UseVisualStyleBackColor = True
        '
        'chkVacaciones
        '
        Me.chkVacaciones.AutoSize = True
        Me.chkVacaciones.Location = New System.Drawing.Point(228, 31)
        Me.chkVacaciones.Name = "chkVacaciones"
        Me.chkVacaciones.Size = New System.Drawing.Size(82, 17)
        Me.chkVacaciones.TabIndex = 16
        Me.chkVacaciones.Text = "Vacaciones"
        Me.chkVacaciones.UseVisualStyleBackColor = True
        '
        'chkPapeleta
        '
        Me.chkPapeleta.AutoSize = True
        Me.chkPapeleta.Location = New System.Drawing.Point(114, 30)
        Me.chkPapeleta.Name = "chkPapeleta"
        Me.chkPapeleta.Size = New System.Drawing.Size(68, 17)
        Me.chkPapeleta.TabIndex = 15
        Me.chkPapeleta.Text = "Papeleta"
        Me.chkPapeleta.UseVisualStyleBackColor = True
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Location = New System.Drawing.Point(15, 31)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(65, 17)
        Me.chkPersona.TabIndex = 14
        Me.chkPersona.Text = "Persona"
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'lblLogueado
        '
        Me.lblLogueado.AutoSize = True
        Me.lblLogueado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogueado.ForeColor = System.Drawing.Color.Green
        Me.lblLogueado.Location = New System.Drawing.Point(82, 9)
        Me.lblLogueado.Name = "lblLogueado"
        Me.lblLogueado.Size = New System.Drawing.Size(0, 13)
        Me.lblLogueado.TabIndex = 11
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 435)
        Me.Controls.Add(Me.chkNotaContable)
        Me.Controls.Add(Me.chkMarcacion)
        Me.Controls.Add(Me.chkGasto)
        Me.Controls.Add(Me.chkVacaciones)
        Me.Controls.Add(Me.chkPapeleta)
        Me.Controls.Add(Me.chkPersona)
        Me.Controls.Add(Me.gbListado)
        Me.Controls.Add(Me.gbUsuario)
        Me.Controls.Add(Me.lblLogueado)
        Me.Controls.Add(Me.lblHead)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.trvPermisos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Usuarios"
        Me.gbListado.ResumeLayout(False)
        Me.gbListado.PerformLayout()
        Me.gbUsuario.ResumeLayout(False)
        Me.gbUsuario.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbListado As GroupBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents gbUsuario As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lblHead As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents trvPermisos As TreeView
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoCivil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estudios As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioContrasena As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioTramite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioMarcacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioPapeleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioNotaContable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioGasto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioVacaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DistritoCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViaCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZonaCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreZona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaNacimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DireccionCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Apellidos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DNI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodPeople As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaducidadDNI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CargoCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prefijo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProvinciaCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartamentoCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkNotaContable As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarcacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkGasto As System.Windows.Forms.CheckBox
    Friend WithEvents chkVacaciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkPapeleta As System.Windows.Forms.CheckBox
    Friend WithEvents chkPersona As System.Windows.Forms.CheckBox
    Friend WithEvents lblLogueado As System.Windows.Forms.Label
End Class
