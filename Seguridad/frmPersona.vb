﻿Imports CapaNegocio

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
                .Add("per_Apellidos", GetType(String))
                .Add("per_ppr_Codigo", GetType(String))
                .Add("per_Sexo", GetType(String))
                .Add("per_DNI", GetType(String))
                .Add("per_DNICaducidad", GetType(Date))
                .Add("per_Nacimiento", GetType(Date))
                .Add("per_pca_Codigo", GetType(String))
                .Add("per_Email", GetType(String))
                .Add("per_Telefono", GetType(Integer))
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

                .Add("usu_Nombre", GetType(String))
                .Add("usu_Contrasena", GetType(String))
                .Add("usu_Beneficio", GetType(String))
                .Add("usu_Marcacion", GetType(String))
                .Add("usu_Papeleta", GetType(String))
                .Add("usu_Vacaciones", GetType(String))
                .Add("usu_NotaContable", GetType(String))
                .Add("usu_Persona", GetType(String))

                .Add("are_Codigo", GetType(String))
            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub frmPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsBDArea As New clsArea
        Dim clsBDGrado As New clsGrado
        Dim clsBDCargo As New clsCargo
        Dim clsBDDepartamento As New clsDepartamento
        Dim clsBDZona As New clsZona
        Dim clsBDVia As New clsVia
        Dim clsBDRol As New clsRol

        cmbGrado.DisplayMember = "ppr_Nombre"
        cmbGrado.ValueMember = "ppr_Codigo"
        cmbGrado.DataSource = clsBDGrado.Listado


        cmbCargo.DisplayMember = "pca_Nombre"
        cmbCargo.ValueMember = "pca_Codigo"
        cmbCargo.DataSource = clsBDCargo.Listado

        cmbDepartamento.DisplayMember = "dep_Nombre"
        cmbDepartamento.ValueMember = "dep_Codigo"
        cmbDepartamento.DataSource = clsBDDepartamento.Listado


        cmbZona.DisplayMember = "pzo_Nombre"
        cmbZona.ValueMember = "pzo_Codigo"
        cmbZona.DataSource = clsBDZona.Listado

        cmbVia.DisplayMember = "pvi_Nombre"
        cmbVia.ValueMember = "pvi_Codigo"
        cmbVia.DataSource = clsBDVia.Listado

        cmbRol.DisplayMember = "rol_Descripcion"
        cmbRol.ValueMember = "rol_Id"
        cmbRol.DataSource = clsBDRol.Listado

        cmbArea.DisplayMember = "are_Nombre"
        cmbArea.ValueMember = "are_Codigo"
        cmbArea.DataSource = clsBDArea.Listado

        formLoad = True

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Dim provincia As New clsProvincia
        cmbProvincia.DisplayMember = "pro_Nombre"
        cmbProvincia.ValueMember = "pro_Codigo"
        cmbProvincia.DataSource = provincia.Listado(cmbDepartamento.SelectedValue)
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedIndexChanged
        Dim distrito As New clsDistrito
        cmbDistrito.DisplayMember = "dis_Nombre"
        cmbDistrito.ValueMember = "dis_Codigo"
        cmbDistrito.DataSource = distrito.Listado(cmbProvincia.SelectedValue)
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
            txtTelefono.Text = personaSeleccionada("per_Telefono")
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

            cmbArea.SelectedValue = personaSeleccionada("are_Codigo")

            modificando = True
            gbPermisos.Enabled = False
            gbPersona.Enabled = True
            gbUbicacion.Enabled = True
            gbArea.Enabled = True

            btnBuscar.Enabled = False
            btnCancelar.Enabled = True
            btnNuevo.Enabled = False
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ErrorProvider1.Clear()
        btnBuscar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True

        gbPermisos.Enabled = True
        gbPersona.Enabled = True
        gbUbicacion.Enabled = True
        gbArea.Enabled = True

        LimpiarCampos()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ErrorProvider1.Clear()
        LimpiarCampos()
        gbPermisos.Enabled = False
        gbPersona.Enabled = False
        gbUbicacion.Enabled = False
        gbArea.Enabled = False

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
        Dim nom As Integer = 1
        Dim ape As Integer = 1
        Dim dni As Integer = 1
        Dim email As Integer = 1
        Dim ev As Integer = 1
        Dim people As Integer = 1
        Dim zona As Integer = 1
        Dim via As Integer = 1
        Dim numvia As Integer = 1

        If txtDNI.Text.Trim.Length < 8 Then
            ErrorProvider1.SetError(txtDNI, "debe tener 8 digitos")
            dni = 0
        End If
        If txtCodigoPeople.Text.Trim.Length < 10 Then
            ErrorProvider1.SetError(txtCodigoPeople, "Debe Tener 10 digitos")
            people = 0
        End If
        If txtNombres.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNombres, "Ingrese Nombres")
            nom = 0
        End If
        If txtApellidos.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtApellidos, "Ingrese Apellidos")
            ape = 0
        End If
        If txtDNI.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtDNI, "Ingrese DNI")
            dni = 0
        End If
        If txtEmail.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtEmail, "Ingrese  Email")
            email = 0
        End If

        If txtCodigoPeople.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCodigoPeople, "Ingrese Codigo de people")
            people = 0
        End If
        If txtNombreZona.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNombreZona, "Ingrese una Zona")
            zona = 0
        End If
        If txtNombreVia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNombreVia, "Ingrese Via")
            via = 0
        End If
        If txtNumero.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNumero, "Ingrese Numero")
            numvia = 0
        End If

        If nom = 1 And ape = 1 And dni = 1 And email = 1 And ev = 1 And people = 1 And zona = 1 And via = 1 And numvia = 1 Then
            Dim tablaGuardar As DataTable = GetEstructuraPersona()
            Dim rowGuardar As DataRow = tablaGuardar.NewRow

            Dim clsUsuariosBD As New clsUsuario


            Dim clsBD As New clsPersona
            Dim drRpta As DataRow
            Dim drRptaUsuario As DataRow

            rowGuardar("per_Nombres") = txtNombres.Text
            rowGuardar("per_Apellidos") = txtApellidos.Text
            rowGuardar("per_ppr_Codigo") = cmbGrado.SelectedValue
            rowGuardar("per_Sexo") = cmbGrado.SelectedItem.ToString.Chars(0)
            rowGuardar("per_DNI") = txtDNI.Text
            rowGuardar("per_DNICaducidad") = dtpCaducidadDNI.Value.Date
            rowGuardar("per_Nacimiento") = dtpFechaNacimiento.Value.Date
            rowGuardar("per_pca_Codigo") = cmbCargo.SelectedValue
            rowGuardar("per_Email") = txtEmail.Text
            rowGuardar("per_Telefono") = CType(txtTelefono.Text, Integer)

            rowGuardar("per_CodPeople") = txtCodigoPeople.Text
            rowGuardar("per_EstadoCivil") = cmbEstadoCivil.SelectedItem

            rowGuardar("pdi_dis_Codigo") = cmbDistrito.SelectedValue
            rowGuardar("pdi_pzo_Codigo") = cmbZona.SelectedValue
            rowGuardar("pdi_NombreZona") = txtNombreZona.Text
            rowGuardar("pdi_pvi_Codigo") = cmbVia.SelectedValue
            rowGuardar("pdi_NombreVia") = txtNombreVia.Text
            rowGuardar("pdi_Numero") = txtNumero.Text

            rowGuardar("usu_Persona") = If(chkPersona.Checked, "SI", "NO")
            rowGuardar("usu_Beneficio") = If(chkGasto.Checked, "SI", "NO")
            rowGuardar("usu_Papeleta") = If(chkPapeleta.Checked, "SI", "NO")
            rowGuardar("usu_Vacaciones") = If(chkVacaciones.Checked, "SI", "NO")
            rowGuardar("usu_NotaContable") = If(chkNotaContable.Checked, "SI", "NO")
            rowGuardar("usu_Marcacion") = If(chkMarcacion.Checked, "SI", "NO")

            rowGuardar("are_Codigo") = cmbArea.SelectedValue

            rowGuardar("usu_Nombre") = txtNombres.Text.Split(New Char() {" "c})(0).Substring(0, 1) & txtApellidos.Text.Split(New Char() {" "c})(0).ToString & txtApellidos.Text.Split(New Char() {" "c})(1).Substring(0, 1)
            rowGuardar("usu_Contrasena") = txtDNI.Text



            If (modificando) Then
                rowGuardar("per_Codigo") = personaSeleccionada("per_Codigo")
                rowGuardar("pdi_Codigo") = personaSeleccionada("pdi_Codigo")
                rowGuardar("per_pdi_Codigo") = personaSeleccionada("pdi_Codigo")
                tablaGuardar.Rows.Add(rowGuardar)
                drRpta = clsBD.Mantenimiento("A", tablaGuardar)
                MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                            "Sistema GestionDoc", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                tablaGuardar.Rows.Add(rowGuardar)
                drRpta = clsBD.Mantenimiento("R", tablaGuardar)
                drRptaUsuario = clsUsuariosBD.Registrar(permisosFinales, drRpta)
                MessageBox.Show(drRptaUsuario.Item("MensajeTitulo").ToString & vbCrLf & drRptaUsuario.Item("MensajeProcedure").ToString,
                            "Sistema GestionDoc", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ErrorProvider1.Clear()
            btnCancelar.PerformClick()
        End If

       

    End Sub


    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidos.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDNI.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoPeople_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPeople.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreZona_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreZona.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreVia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreVia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class