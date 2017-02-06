<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersona
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
        Me.gbPersona = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpCaducidadDNI = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.cmbGenero = New System.Windows.Forms.ComboBox()
        Me.txtCodigoPeople = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtApellidos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.gbUbicacion = New System.Windows.Forms.GroupBox()
        Me.cmbVia = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNombreVia = New System.Windows.Forms.TextBox()
        Me.txtNombreZona = New System.Windows.Forms.TextBox()
        Me.gbPermisos = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.trvPermisosPersona = New System.Windows.Forms.TreeView()
        Me.chkNotaContable = New System.Windows.Forms.CheckBox()
        Me.chkMarcacion = New System.Windows.Forms.CheckBox()
        Me.chkGasto = New System.Windows.Forms.CheckBox()
        Me.chkVacaciones = New System.Windows.Forms.CheckBox()
        Me.cmbRol = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkPapeleta = New System.Windows.Forms.CheckBox()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gbPersona.SuspendLayout()
        Me.gbUbicacion.SuspendLayout()
        Me.gbPermisos.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.Label17)
        Me.gbPersona.Controls.Add(Me.Label6)
        Me.gbPersona.Controls.Add(Me.cmbEstadoCivil)
        Me.gbPersona.Controls.Add(Me.Label5)
        Me.gbPersona.Controls.Add(Me.dtpCaducidadDNI)
        Me.gbPersona.Controls.Add(Me.dtpFechaNacimiento)
        Me.gbPersona.Controls.Add(Me.cmbGenero)
        Me.gbPersona.Controls.Add(Me.txtCodigoPeople)
        Me.gbPersona.Controls.Add(Me.Label4)
        Me.gbPersona.Controls.Add(Me.Label18)
        Me.gbPersona.Controls.Add(Me.txtDNI)
        Me.gbPersona.Controls.Add(Me.Label3)
        Me.gbPersona.Controls.Add(Me.txtEmail)
        Me.gbPersona.Controls.Add(Me.txtApellidos)
        Me.gbPersona.Controls.Add(Me.Label8)
        Me.gbPersona.Controls.Add(Me.txtNombres)
        Me.gbPersona.Controls.Add(Me.Label2)
        Me.gbPersona.Controls.Add(Me.Label1)
        Me.gbPersona.Controls.Add(Me.Label7)
        Me.gbPersona.Controls.Add(Me.lblGrado)
        Me.gbPersona.Controls.Add(Me.cmbCargo)
        Me.gbPersona.Controls.Add(Me.cmbGrado)
        Me.gbPersona.Enabled = False
        Me.gbPersona.Location = New System.Drawing.Point(12, 12)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(329, 427)
        Me.gbPersona.TabIndex = 2
        Me.gbPersona.TabStop = False
        Me.gbPersona.Text = "Datos de Persona"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 375)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Estado Civil"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Caducidad de DNI:"
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCivil.FormattingEnabled = True
        Me.cmbEstadoCivil.Items.AddRange(New Object() {"SOLTERO", "CASADO", "DIVORCIADO", "SEPARADO"})
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(6, 391)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(150, 21)
        Me.cmbEstadoCivil.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha de Nacimiento:"
        '
        'dtpCaducidadDNI
        '
        Me.dtpCaducidadDNI.Location = New System.Drawing.Point(6, 255)
        Me.dtpCaducidadDNI.Name = "dtpCaducidadDNI"
        Me.dtpCaducidadDNI.Size = New System.Drawing.Size(314, 20)
        Me.dtpCaducidadDNI.TabIndex = 8
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(6, 208)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(314, 20)
        Me.dtpFechaNacimiento.TabIndex = 8
        '
        'cmbGenero
        '
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenero.FormattingEnabled = True
        Me.cmbGenero.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbGenero.Location = New System.Drawing.Point(170, 121)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(150, 21)
        Me.cmbGenero.TabIndex = 7
        '
        'txtCodigoPeople
        '
        Me.txtCodigoPeople.Location = New System.Drawing.Point(162, 391)
        Me.txtCodigoPeople.Name = "txtCodigoPeople"
        Me.txtCodigoPeople.Size = New System.Drawing.Size(158, 20)
        Me.txtCodigoPeople.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(167, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Genero:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(159, 375)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Codigo de PeopleSoft:"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(6, 122)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(143, 20)
        Me.txtDNI.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DNI:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(6, 347)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(314, 20)
        Me.txtEmail.TabIndex = 3
        '
        'txtApellidos
        '
        Me.txtApellidos.Location = New System.Drawing.Point(6, 83)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(314, 20)
        Me.txtApellidos.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Email:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(6, 42)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(314, 20)
        Me.txtNombres.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Apellidos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombres"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Cargo:"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Location = New System.Drawing.Point(6, 145)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(36, 13)
        Me.lblGrado.TabIndex = 1
        Me.lblGrado.Text = "Grado"
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(6, 300)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(314, 21)
        Me.cmbCargo.TabIndex = 0
        '
        'cmbGrado
        '
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(6, 164)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(314, 21)
        Me.cmbGrado.TabIndex = 0
        '
        'gbUbicacion
        '
        Me.gbUbicacion.Controls.Add(Me.cmbVia)
        Me.gbUbicacion.Controls.Add(Me.Label15)
        Me.gbUbicacion.Controls.Add(Me.cmbZona)
        Me.gbUbicacion.Controls.Add(Me.Label13)
        Me.gbUbicacion.Controls.Add(Me.cmbDistrito)
        Me.gbUbicacion.Controls.Add(Me.Label11)
        Me.gbUbicacion.Controls.Add(Me.cmbProvincia)
        Me.gbUbicacion.Controls.Add(Me.Label10)
        Me.gbUbicacion.Controls.Add(Me.txtNumero)
        Me.gbUbicacion.Controls.Add(Me.cmbDepartamento)
        Me.gbUbicacion.Controls.Add(Me.Label16)
        Me.gbUbicacion.Controls.Add(Me.Label9)
        Me.gbUbicacion.Controls.Add(Me.Label14)
        Me.gbUbicacion.Controls.Add(Me.Label12)
        Me.gbUbicacion.Controls.Add(Me.txtNombreVia)
        Me.gbUbicacion.Controls.Add(Me.txtNombreZona)
        Me.gbUbicacion.Enabled = False
        Me.gbUbicacion.Location = New System.Drawing.Point(347, 12)
        Me.gbUbicacion.Name = "gbUbicacion"
        Me.gbUbicacion.Size = New System.Drawing.Size(332, 343)
        Me.gbUbicacion.TabIndex = 3
        Me.gbUbicacion.TabStop = False
        Me.gbUbicacion.Text = "Ubicacion de la Persona"
        '
        'cmbVia
        '
        Me.cmbVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVia.FormattingEnabled = True
        Me.cmbVia.Location = New System.Drawing.Point(9, 254)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.Size = New System.Drawing.Size(314, 21)
        Me.cmbVia.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 238)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Tipo de Via"
        '
        'cmbZona
        '
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(9, 208)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(314, 21)
        Me.cmbZona.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Tipo de Zona:"
        '
        'cmbDistrito
        '
        Me.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(6, 123)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(314, 21)
        Me.cmbDistrito.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Distrito"
        '
        'cmbProvincia
        '
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(6, 83)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(314, 21)
        Me.cmbProvincia.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Provincia"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(253, 301)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(70, 20)
        Me.txtNumero.TabIndex = 3
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(6, 41)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(314, 21)
        Me.cmbDepartamento.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(250, 285)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Numero:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Departamento"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 284)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Nombre de la Via:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 147)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Nombre de Zona:"
        '
        'txtNombreVia
        '
        Me.txtNombreVia.Location = New System.Drawing.Point(9, 301)
        Me.txtNombreVia.Name = "txtNombreVia"
        Me.txtNombreVia.Size = New System.Drawing.Size(238, 20)
        Me.txtNombreVia.TabIndex = 3
        '
        'txtNombreZona
        '
        Me.txtNombreZona.Location = New System.Drawing.Point(9, 164)
        Me.txtNombreZona.Name = "txtNombreZona"
        Me.txtNombreZona.Size = New System.Drawing.Size(314, 20)
        Me.txtNombreZona.TabIndex = 3
        Me.txtNombreZona.Text = "CERCADO DE CHICLAYO"
        '
        'gbPermisos
        '
        Me.gbPermisos.Controls.Add(Me.Label20)
        Me.gbPermisos.Controls.Add(Me.trvPermisosPersona)
        Me.gbPermisos.Controls.Add(Me.chkNotaContable)
        Me.gbPermisos.Controls.Add(Me.chkMarcacion)
        Me.gbPermisos.Controls.Add(Me.chkGasto)
        Me.gbPermisos.Controls.Add(Me.chkVacaciones)
        Me.gbPermisos.Controls.Add(Me.cmbRol)
        Me.gbPermisos.Controls.Add(Me.Label19)
        Me.gbPermisos.Controls.Add(Me.chkPapeleta)
        Me.gbPermisos.Controls.Add(Me.chkPersona)
        Me.gbPermisos.Enabled = False
        Me.gbPermisos.Location = New System.Drawing.Point(685, 12)
        Me.gbPermisos.Name = "gbPermisos"
        Me.gbPermisos.Size = New System.Drawing.Size(275, 343)
        Me.gbPermisos.TabIndex = 4
        Me.gbPermisos.TabStop = False
        Me.gbPermisos.Text = "Datos de Usuario"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 111)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Permisos por Rol:"
        '
        'trvPermisosPersona
        '
        Me.trvPermisosPersona.CheckBoxes = True
        Me.trvPermisosPersona.Location = New System.Drawing.Point(9, 127)
        Me.trvPermisosPersona.Name = "trvPermisosPersona"
        Me.trvPermisosPersona.Size = New System.Drawing.Size(253, 194)
        Me.trvPermisosPersona.TabIndex = 4
        '
        'chkNotaContable
        '
        Me.chkNotaContable.AutoSize = True
        Me.chkNotaContable.Location = New System.Drawing.Point(180, 41)
        Me.chkNotaContable.Name = "chkNotaContable"
        Me.chkNotaContable.Size = New System.Drawing.Size(94, 17)
        Me.chkNotaContable.TabIndex = 3
        Me.chkNotaContable.Text = "Nota Contable"
        Me.chkNotaContable.UseVisualStyleBackColor = True
        '
        'chkMarcacion
        '
        Me.chkMarcacion.AutoSize = True
        Me.chkMarcacion.Location = New System.Drawing.Point(93, 41)
        Me.chkMarcacion.Name = "chkMarcacion"
        Me.chkMarcacion.Size = New System.Drawing.Size(76, 17)
        Me.chkMarcacion.TabIndex = 3
        Me.chkMarcacion.Text = "Marcacion"
        Me.chkMarcacion.UseVisualStyleBackColor = True
        '
        'chkGasto
        '
        Me.chkGasto.AutoSize = True
        Me.chkGasto.Location = New System.Drawing.Point(6, 41)
        Me.chkGasto.Name = "chkGasto"
        Me.chkGasto.Size = New System.Drawing.Size(54, 17)
        Me.chkGasto.TabIndex = 3
        Me.chkGasto.Text = "Gasto"
        Me.chkGasto.UseVisualStyleBackColor = True
        '
        'chkVacaciones
        '
        Me.chkVacaciones.AutoSize = True
        Me.chkVacaciones.Location = New System.Drawing.Point(180, 19)
        Me.chkVacaciones.Name = "chkVacaciones"
        Me.chkVacaciones.Size = New System.Drawing.Size(82, 17)
        Me.chkVacaciones.TabIndex = 2
        Me.chkVacaciones.Text = "Vacaciones"
        Me.chkVacaciones.UseVisualStyleBackColor = True
        '
        'cmbRol
        '
        Me.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRol.FormattingEnabled = True
        Me.cmbRol.Location = New System.Drawing.Point(6, 83)
        Me.cmbRol.Name = "cmbRol"
        Me.cmbRol.Size = New System.Drawing.Size(263, 21)
        Me.cmbRol.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(23, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Rol"
        '
        'chkPapeleta
        '
        Me.chkPapeleta.AutoSize = True
        Me.chkPapeleta.Location = New System.Drawing.Point(93, 19)
        Me.chkPapeleta.Name = "chkPapeleta"
        Me.chkPapeleta.Size = New System.Drawing.Size(68, 17)
        Me.chkPapeleta.TabIndex = 1
        Me.chkPapeleta.Text = "Papeleta"
        Me.chkPapeleta.UseVisualStyleBackColor = True
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Location = New System.Drawing.Point(6, 19)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(65, 17)
        Me.chkPersona.TabIndex = 0
        Me.chkPersona.Text = "Persona"
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(830, 415)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(128, 23)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar Persona"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(749, 415)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(668, 415)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(587, 415)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 455)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbPermisos)
        Me.Controls.Add(Me.gbUbicacion)
        Me.Controls.Add(Me.gbPersona)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPersona"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPersona"
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        Me.gbUbicacion.ResumeLayout(False)
        Me.gbUbicacion.PerformLayout()
        Me.gbPermisos.ResumeLayout(False)
        Me.gbPermisos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbPersona As GroupBox
    Friend WithEvents lblGrado As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpCaducidadDNI As DateTimePicker
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents cmbGenero As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDNI As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtApellidos As TextBox
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbCargo As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbEstadoCivil As ComboBox
    Friend WithEvents txtCodigoPeople As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents gbUbicacion As GroupBox
    Friend WithEvents cmbVia As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbDistrito As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbProvincia As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents cmbDepartamento As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNombreVia As TextBox
    Friend WithEvents txtNombreZona As TextBox
    Friend WithEvents gbPermisos As GroupBox
    Friend WithEvents chkNotaContable As CheckBox
    Friend WithEvents chkMarcacion As CheckBox
    Friend WithEvents chkGasto As CheckBox
    Friend WithEvents chkVacaciones As CheckBox
    Friend WithEvents chkPapeleta As CheckBox
    Friend WithEvents chkPersona As CheckBox
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents trvPermisosPersona As TreeView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnBuscar As Button
End Class
