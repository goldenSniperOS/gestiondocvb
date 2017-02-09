<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteGastosMovilidadAreaPeriodo
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
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReportar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {"-- SELECCIONE AREA  --", "UNIVERSIDAD CESAR VALLEJO FILIAL CHICLAYO", "DIRECCIÓN ACADÉMICA", "ESCUELA DE LIDERES", "ESCUELA DE INGENIERÍA DE MINAS", "ESCUELA DE INGENIERÍA CIVIL", "ESCUELA DE INGENIERÍA AMBIENTAL", "ESCUELA DE INGENIERÍA AGRONÓMICA", "ESCUELA DE INGENIERÍA EMPRESARIAL", "ESCUELA DE PSICOLOGIA", "ESCUELA DE IDIOMAS TRADUCCIÓN E INTERPRETACIÓN", "ESCUELA DE EDUCACIÓN PRIMARIA", "ESCUELA DE EDUCACIÓN INICIAL", "ESCUELA DE ADMINISTRACIÓN", "ESCUELA DE ECONOMÍA", "ESCUELA DE CONTABILIDAD", "ESCUELA DE NEGOCIOS INTERNACIONALES", "ESCUELA DE MARKETING Y DIRECCIÓN DE EMPRESAS", "OFICINA DE REGISTROS ACADÉMICOS", "OFICINA DE DESARROLLO ACADEMICO", "ESCUELA DE DERECHO", "OFICINA DE INVESTIGACIÓN", "OFICINA DE FORMACIÓN GENERAL", "CENTRO DE INFORMACIÓN", "OFICINA DE ADMISIÓN", "DIRECCIÓN DE ASUNTOS ESTUDIANTILES", "PROYECCION SOCIAL", "EXTENSION Y PROYECCION UNIVERSITARIA", "OFICINA DE BOLSA DE TRABAJO", "SERVICIOS MÉDICOS", "CONSULTORIO PSICOLÓGICO", "OFICINA DE TUTORIA Y PASTORAL UNIVERSITARIA", "ACTIVIDADES INTEGRADORAS", "OFICINA DE TRABAJO SOCIAL", "DIRECCION GENERAL", "OFICINA DE FINANZAS DEL ALUMNO", "OFICINA DE IMAGEN INSTITUCIONAL", "CENTRO DE IDIOMAS", "CENTRO DE INFORMÁTICA Y SISTEMAS", "OFICINA DE CONTABILIDAD", "OFICINA DE TECNOLOGÍAS DE LA INFORMACIÓN", "SOPORTE TECNICO", "OFICINA GESTIÓN TALENTO HUMANO", "OFICINA DE LOGÍSTICA", "OFICINA DE CONTROL PATRIMONIAL", "OFICINA DE INFRAESTRUCTURA Y SEGURIDAD", "MESA PARTES CHICLAYO", "OFICINA DE MARKETING Y PROMOCIÓN", "OFICINA DE PLANIFICACION Y DESARROLLO INSTITUCIONAL", "OFICINA DE CALIDAD UNIVERSITARIA", "CENTRO DE ESTUDIOS ECONOMICOS Y DE MERCADO", "DIRECCIÓN DE POSTGRADO", "PROGRAMA DE FORMACIÓN PARA ADULTOS", "COMMUNITY MANAGER", "CONSULTORIO JURIDICO", "SSOMA", "COOPERACION Y RELACIONES INTERNACIONALES", "DEFENSORIA UNIVERSITARIA", "EXTERNO", "OFICINA DE ADMINISTRACIÓN Y FINANZAS", "FOTOCOPIADO", "UNIDADES MOVILES", "UCV SATELITAL", "MANTENIMIENTO Y JARDINERIA", "CENTRO PREUNIVERSITARIO", "CASETA DE VIGILANCIA", "EXPER LABORAL EADM", "EXPER LABORAL ECONT", "EXPER LABORAL ICIV", "EXPER LABORAL IMEC", "OFICINA DE SEGUIMIENTO DE GRADUADOS"})
        Me.cmbArea.Location = New System.Drawing.Point(147, 22)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(282, 21)
        Me.cmbArea.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SELECCIONAR AREA:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbArea)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 108)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCION DE REPORTE"
        '
        '
        '
        '
        '
        '
        '
        '
        '
        'btnReportar
        '
        Me.btnReportar.Location = New System.Drawing.Point(366, 126)
        Me.btnReportar.Name = "btnReportar"
        Me.btnReportar.Size = New System.Drawing.Size(75, 23)
        Me.btnReportar.TabIndex = 3
        Me.btnReportar.Text = "REPORTE"
        Me.btnReportar.UseVisualStyleBackColor = True
        '
        'frmReporteGastosMovilidadAreaPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 157)
        Me.Controls.Add(Me.btnReportar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmReporteGastosMovilidadAreaPeriodo"
        Me.Text = "frmReporteGastosMovilidadAreaPeriodo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnReportar As System.Windows.Forms.Button
End Class
