Imports CapaNegocio

Public Class frmPersona
    Dim permisosFinales As New DataTable
    Dim personaSeleccionada As DataRow
    Dim formLoad As Boolean = False
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

        End If
    End Sub
End Class