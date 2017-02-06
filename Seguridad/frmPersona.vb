Imports CapaNegocio

Public Class frmPersona
    Dim permisosFinales As New DataTable
    Dim personaSeleccionada As DataRow
    Dim formLoad As Boolean = False

    Dim modificando As Boolean = False

    Private Function GetEstructuraPersona() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("per_Codigo", GetType(String))
                .Add("per_Nombres", GetType(String))
                .Add("per_ppr_Codigo", GetType(String))
                .Add("per_Sexo", GetType(String))
                .Add("per_DNI", GetType(String))
                .Add("per_DNICaducidad", GetType(Date))
                .Add("per_Nacimiento", GetType(Date))
                .Add("per_pca_Codigo", GetType(String))
                .Add("per_Email", GetType(String))
                .Add("per_pdi_Codigo", GetType(String))
                .Add("per_CodPeople", GetType(String))
                .Add("per_EstadoCivil", GetType(String))

                .Add("pdi_Codigo", GetType(String))
                .Add("pdi_dis_Codigo", GetType(String))
                .Add("pdi_pzo_Codigo", GetType(String))
                .Add("pdi_NombreZona", GetType(String))
                .Add("pdi_pvi_Codigo", GetType(String))
                .Add("pdi_NombreVia", GetType(String))
                .Add("pdi_Numero", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub frmPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listado As New clsListados

        cmbGrado.DisplayMember = "ppr_Nombre"
        cmbGrado.ValueMember = "ppr_Codigo"
        cmbGrado.DataSource = listado.De("Prefijos")


        cmbCargo.DisplayMember = "pca_Nombre"
        cmbCargo.ValueMember = "pca_Codigo"
        cmbCargo.DataSource = listado.De("Cargos")

        cmbDepartamento.DisplayMember = "dep_Nombre"
        cmbDepartamento.ValueMember = "dep_Codigo"
        cmbDepartamento.DataSource = listado.De("Departamentos")


        cmbZona.DisplayMember = "pzo_Nombre"
        cmbZona.ValueMember = "pzo_Codigo"
        cmbZona.DataSource = listado.De("Zonas")


        cmbVia.DisplayMember = "pvi_Nombre"
        cmbVia.ValueMember = "pvi_Codigo"
        cmbVia.DataSource = listado.De("Vias")

        cmbRol.DisplayMember = "rol_Descripcion"
        cmbRol.ValueMember = "rol_Id"
        cmbRol.DataSource = listado.De("Roles")

        formLoad = True

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Dim listado As New clsListados
        cmbProvincia.DisplayMember = "pro_Nombre"
        cmbProvincia.ValueMember = "pro_Codigo"
        cmbProvincia.DataSource = listado.De("Provincias", cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedIndexChanged
        Dim listado As New clsListados
        cmbDistrito.DisplayMember = "dis_Nombre"
        cmbDistrito.ValueMember = "dis_Codigo"
        cmbDistrito.DataSource = listado.De("Distritos", cmbProvincia.SelectedValue)
    End Sub

    Private Sub TreePermisos(Permisos As DataTable, Padre As Integer, ByRef Tree As TreeView, ByRef Item As TreeNode)
        Dim vistaMenu As DataView = New DataView(Permisos)
        vistaMenu.RowFilter = Permisos.Columns("mod_Padre").ColumnName & " = " & Padre
        For Each dataRow As DataRowView In vistaMenu
            Dim node As New TreeNode
            If (dataRow("usu_Codigo") <> 0) Then
                node.Checked = True
            End If
            node.Name = dataRow("usu_mod_Id").ToString
            node.Text = dataRow("mod_Nombre").ToString
            node.Tag = dataRow("mod_ID").ToString
            If Padre = 0 Then
                Tree.Nodes.Add(node)
            Else
                Item.Nodes.Add(node)
            End If
            TreePermisos(Permisos, dataRow("mod_ID"), Tree, node)
        Next
    End Sub

    Private Sub cmbRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRol.SelectedIndexChanged
        If formLoad Then
            trvPermisosPersona.Nodes.Clear()
        End If
        Dim clsBD As New clsRol
        Dim tablaMandar As New DataTable
        With tablaMandar.Columns
            .Add("rol_mod_Rol", GetType(Integer))
        End With
        tablaMandar.Rows.Clear()
        Dim rowMandar As DataRow
        rowMandar = tablaMandar.NewRow
        rowMandar("rol_mod_Rol") = cmbRol.SelectedValue
        tablaMandar.Rows.Add(rowMandar)
        permisosFinales = clsBD.ModulosXRol(tablaMandar)
        TreePermisos(permisosFinales, 0, trvPermisosPersona, Nothing)


        Select Case cmbRol.SelectedValue
            Case 1
                chkVacaciones.Checked = True
                chkPersona.Checked = True
                chkPapeleta.Checked = True
                chkMarcacion.Checked = True
                chkGasto.Checked = True
                chkNotaContable.Checked = True
            Case 2
                chkVacaciones.Checked = False
                chkPersona.Checked = False
                chkPapeleta.Checked = False
                chkMarcacion.Checked = False
                chkGasto.Checked = False
                chkNotaContable.Checked = False
            Case 3
                chkVacaciones.Checked = False
                chkPersona.Checked = False
                chkPapeleta.Checked = False
                chkMarcacion.Checked = False
                chkGasto.Checked = False
                chkNotaContable.Checked = False
            Case 4
                chkVacaciones.Checked = False
                chkPersona.Checked = False
                chkPapeleta.Checked = False
                chkMarcacion.Checked = False
                chkGasto.Checked = True
                chkNotaContable.Checked = True
            Case Else
                chkVacaciones.Checked = False
                chkPersona.Checked = False
                chkPapeleta.Checked = False
                chkMarcacion.Checked = True
                chkGasto.Checked = False
                chkNotaContable.Checked = False
        End Select

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frm As New frmListadoPersona
        If frm.ShowDialog() = DialogResult.OK Then
            personaSeleccionada = frm.persona
            txtNombres.Text = personaSeleccionada("per_Nombres")
            txtApellidos.Text = personaSeleccionada("per_Apellidos")
            txtCodigoPeople.Text = personaSeleccionada("per_CodPeople")
            txtDNI.Text = personaSeleccionada("per_DNI")
            txtEmail.Text = personaSeleccionada("per_Email")
            txtNombreVia.Text = personaSeleccionada("pdi_NombreVia")
            txtNombreZona.Text = personaSeleccionada("pdi_NombreZona")
            txtNumero.Text = personaSeleccionada("pdi_Numero")
            cmbCargo.SelectedValue = personaSeleccionada("pca_Codigo")
            cmbDepartamento.SelectedValue = personaSeleccionada("dep_Codigo")
            cmbProvincia.SelectedValue = personaSeleccionada("pro_Codigo")
            cmbDistrito.SelectedValue = personaSeleccionada("pdi_dis_Codigo")
            cmbEstadoCivil.SelectedItem = personaSeleccionada("per_EstadoCivil")
            cmbGrado.SelectedValue = personaSeleccionada("per_ppr_Codigo")

            chkGasto.Checked = (personaSeleccionada("usu_Beneficio") = "SI")
            chkMarcacion.Checked = (personaSeleccionada("usu_Marcacion") = "SI")
            chkNotaContable.Checked = (personaSeleccionada("usu_NotaContable") = "SI")
            chkPapeleta.Checked = (personaSeleccionada("usu_Papeleta") = "SI")
            chkPersona.Checked = (personaSeleccionada("usu_Persona") = "SI")
            chkVacaciones.Checked = (personaSeleccionada("usu_Vacaciones") = "SI")

            dtpFechaNacimiento.Value = personaSeleccionada("per_Nacimiento")
            dtpCaducidadDNI.Value = personaSeleccionada("per_DNICaducidad")

            modificando = True
            gbPermisos.Enabled = False
            gbPersona.Enabled = True
            gbUbicacion.Enabled = True

            btnBuscar.Enabled = False
            btnCancelar.Enabled = True
            btnNuevo.Enabled = False
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnBuscar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True

        gbPermisos.Enabled = True
        gbPersona.Enabled = True
        gbUbicacion.Enabled = True

        LimpiarCampos()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarCampos()
        gbPermisos.Enabled = False
        gbPersona.Enabled = False
        gbUbicacion.Enabled = False

        btnBuscar.Enabled = True
        btnCancelar.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
    End Sub

    Private Sub LimpiarCampos()
        txtApellidos.Text = ""
        txtCodigoPeople.Text = ""
        txtDNI.Text = ""
        txtNombres.Text = ""
        txtNombreVia.Text = ""
        txtNombreZona.Text = ""
        txtNumero.Text = ""
        txtNombres.Text = ""
        txtEmail.Text = ""

        cmbCargo.SelectedIndex = 0
        cmbDepartamento.SelectedIndex = 0
        cmbEstadoCivil.SelectedIndex = 0
        cmbGrado.SelectedIndex = 0
        cmbRol.SelectedIndex = 0
        cmbGenero.SelectedIndex = 0
        cmbVia.SelectedIndex = 0
        cmbZona.SelectedIndex = 0
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tablaGuardar As DataTable = GetEstructuraPersona()
        Dim rowGuardar As DataRow = tablaGuardar.NewRow

        Dim clsBD As New clsPersona

        Dim drRpta As DataRow




        rowGuardar("per_Nombres") = txtNombres.Text
        rowGuardar("per_ppr_Codigo") = cmbGrado.SelectedValue
        rowGuardar("per_Sexo") = cmbGrado.SelectedItem.ToString.Chars(0)
        rowGuardar("per_DNI") = txtDNI.Text
        rowGuardar("per_DNICaducidad") = dtpCaducidadDNI.Value.Date
        rowGuardar("per_Nacimiento") = dtpFechaNacimiento.Value.Date
        rowGuardar("per_pca_Codigo") = cmbCargo.SelectedValue
        rowGuardar("per_Email") = txtEmail.Text
        rowGuardar("per_pdi_Codigo") = cmbDistrito.SelectedValue
        rowGuardar("per_CodPeople") = txtCodigoPeople.Text
        rowGuardar("per_EstadoCivil") = cmbEstadoCivil.SelectedItem

        rowGuardar("pdi_dis_Codigo") = cmbDistrito.SelectedValue
        rowGuardar("pdi_pzo_Codigo") = cmbZona.SelectedValue
        rowGuardar("pdi_NombreZona") = txtNombreZona.Text
        rowGuardar("pdi_pvi_Codigo") = cmbVia.SelectedValue
        rowGuardar("pdi_NombreVia") = txtNombreVia.Text
        rowGuardar("pdi_Numero") = txtNumero.Text



        If (modificando) Then
            rowGuardar("per_Codigo") = personaSeleccionada("per_Codigo")
            rowGuardar("pdi_Codigo") = personaSeleccionada("pdi_Codigo")
            tablaGuardar.Rows.Add(rowGuardar)
            drRpta = clsBD.Mantenimiento("A", tablaGuardar)
        Else
            rowGuardar("per_Codigo") = ""
            rowGuardar("pdi_Codigo") = ""
            tablaGuardar.Rows.Add(rowGuardar)
            drRpta = clsBD.Mantenimiento("R", tablaGuardar)
        End If

        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                        "Sistema GestionDoc", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class