Imports CapaNegocio

Public Class frmUsuarios
    Dim permisosTotales As DataTable
    Dim permisosFinales As DataTable
    Dim userSelected As DataRow

    Dim initLoad As Boolean = False
    Dim inNew As Boolean = False

    Property usuarioLogueado As DataRow
    Property usuarioLogueadoQuery As DataTable

    Private Function GetEstructuraUsuario() As DataTable
        Try
            Dim dataTablePersona = New DataTable
            With dataTablePersona.Columns
                .Add("usu_Codigo", GetType(String))
                .Add("usu_Nombre", GetType(String))
                .Add("usu_Password", GetType(String))
                .Add("usu_Estado", GetType(Boolean))
            End With
            dataTablePersona.Rows.Clear()
            Return dataTablePersona
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetEstructuraFiltrado() As DataTable
        Try
            Dim dataTablePersona = New DataTable
            With dataTablePersona.Columns
                .Add("usu_Nombre", GetType(String))
            End With
            dataTablePersona.Rows.Clear()
            Return dataTablePersona
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetEstructuraPermisos() As DataTable
        Try
            Dim dataTablePersona = New DataTable
            With dataTablePersona.Columns
                .Add("usu_mod_Id", GetType(Integer))
                .Add("usu_mod_Modulo", GetType(Integer))
                .Add("usu_mod_Usuario", GetType(String))
                .Add("Accion", GetType(String))
            End With
            dataTablePersona.Rows.Clear()
            Return dataTablePersona
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub frmAsignarPermisos_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox("Usuario Logueado " & usuarioLogueado("usu_Nombre"))
        Dim clsBD As New clsUsuario
        Dim clsRolesBD As New clsRol

        

        cmbRol.DisplayMember = "rol_Descripcion"
        cmbRol.ValueMember = "rol_Id"
        cmbRol.DataSource = clsRolesBD.Listado

        lblLogueado.Text = usuarioLogueado("per_Nombres") & " " & usuarioLogueado("per_Apellidos")

        Dim clsBDPersona As New clsPersona
        dgvUsuarios.DataSource = clsBDPersona.Filtro(txtFiltro.Text)

        userSelected = usuarioLogueado
        usuarioLogueadoQuery.Rows(0)("usu_Nombre") = usuarioLogueado("usu_Nombre")
        usuarioLogueadoQuery.Rows(0)("usu_Contrasena") = usuarioLogueado("usu_Contrasena")

        chkVacaciones.Checked = (userSelected("usu_Vacaciones") = "SI")
        chkPersona.Checked = (userSelected("usu_Persona") = "SI")
        chkPapeleta.Checked = (userSelected("usu_Papeleta") = "SI")
        chkMarcacion.Checked = (userSelected("usu_Marcacion") = "SI")
        chkGasto.Checked = (userSelected("usu_Beneficio") = "SI")
        chkNotaContable.Checked = (userSelected("usu_NotaContable") = "SI")

        permisosFinales = GetEstructuraPermisos()
        permisosTotales = clsBD.PermisosXUsuario(usuarioLogueadoQuery)
        TreePermisos(permisosTotales, 0, trvPermisos, Nothing)
        initLoad = True
    End Sub

    Private Sub TreePermisos(Permisos As DataTable, Padre As Integer, ByRef Tree As TreeView, ByRef Item As TreeNode)
        Dim vistaMenu As DataView = New DataView(Permisos)
        vistaMenu.RowFilter = Permisos.Columns("mod_Padre").ColumnName & " = " & Padre
        For Each dataRow As DataRowView In vistaMenu
            Dim node As New TreeNode
            If (dataRow("usu_Codigo") <> "NOUSERCODE") Then
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

    Private Sub trvPermisos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvPermisos.AfterCheck
        For Each dataRow As DataRow In permisosFinales.Rows
            If (dataRow("usu_mod_Modulo") = e.Node.Tag.ToString) Then
                If (dataRow("Accion") = "NOTHING") Then
                    If e.Node.Checked Then
                        dataRow("Accion") = "INSERT"
                    Else
                        dataRow("Accion") = "DELETE"
                    End If
                Else
                    dataRow("Accion") = "NOTHING"
                End If
                Return
            End If
        Next
        Dim rowNueva As DataRow = permisosFinales.NewRow
        rowNueva("usu_mod_Id") = e.Node.Name
        rowNueva("usu_mod_Usuario") = userSelected("usu_Codigo")
        rowNueva("usu_mod_Modulo") = CInt(e.Node.Tag.ToString)
        If e.Node.Checked Then
            rowNueva("Accion") = "INSERT"
        Else
            rowNueva("Accion") = "DELETE"
        End If
        permisosFinales.Rows.Add(rowNueva)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim listRows() As DataRow = permisosFinales.Select("Accion <> 'NOTHING'")
        Dim clsUsuariosBD As New clsUsuario

        Dim dataTableGuardar As DataTable
        dataTableGuardar = Nothing
        dataTableGuardar = GetEstructuraPermisos()
        For Each row As DataRow In listRows
            dataTableGuardar.ImportRow(row)
        Next
        Dim drRpta As DataRow
        If (userSelected("usu_Codigo") = usuarioLogueado("usu_Codigo")) Then
            'El Usuario Esta Logueado
        Else
            userSelected("usu_Nombre") = txtUsuario.Text
            userSelected("usu_Contrasena") = txtPassword.Text
        End If


        If (inNew) Then
            drRpta = clsUsuariosBD.Registrar(dataTableGuardar, userSelected)
        Else
            drRpta = clsUsuariosBD.Actualizar(dataTableGuardar, userSelected)
        End If

        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                           "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information)

        gbUsuario.Enabled = False
        gbListado.Enabled = True
        Dim tablaUsuario As DataTable = GetEstructuraFiltrado()
        Dim usuarioFilter As DataRow = tablaUsuario.NewRow
        txtFiltro.Text = ""
        usuarioFilter("usu_Nombre") = txtFiltro.Text
        tablaUsuario.Rows.Add(usuarioFilter)
        dgvUsuarios.DataSource = clsUsuariosBD.Consultar(tablaUsuario)
        inNew = False

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim clsBD As New clsPersona
        dgvUsuarios.DataSource = clsBD.Filtro(txtFiltro.Text)
    End Sub

    Private Sub dgvUsuarios_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs)
        If (dgvUsuarios.SelectedRows.Count > 0) Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        inNew = False
        trvPermisos.Nodes.Clear()
        Dim clsUsuariosBD As New clsUsuario
        Dim row As DataRow = (DirectCast(dgvUsuarios.SelectedRows(0).DataBoundItem, DataRowView)).Row
        userSelected = row
        If (userSelected("usu_Codigo") = usuarioLogueado("usu_Codigo")) Then
            gbUsuario.Enabled = False
        Else
            gbUsuario.Enabled = True
        End If

        chkVacaciones.Checked = (userSelected("usu_Vacaciones") = "SI")
        chkPersona.Checked = (userSelected("usu_Persona") = "SI")
        chkPapeleta.Checked = (userSelected("usu_Papeleta") = "SI")
        chkMarcacion.Checked = (userSelected("usu_Marcacion") = "SI")
        chkGasto.Checked = (userSelected("usu_Beneficio") = "SI")
        chkNotaContable.Checked = (userSelected("usu_NotaContable") = "SI")

        txtUsuario.Text = userSelected("usu_Nombre")
        txtPassword.Text = userSelected("usu_Contrasena")

        lblLogueado.Text = userSelected("per_Nombres") & " " & userSelected("per_Apellidos")

        permisosFinales = GetEstructuraPermisos()
        usuarioLogueadoQuery.Rows(0)("usu_Nombre") = userSelected("usu_Nombre")
        usuarioLogueadoQuery.Rows(0)("usu_Contrasena") = userSelected("usu_Contrasena")
        permisosTotales = clsUsuariosBD.PermisosXUsuario(usuarioLogueadoQuery)
        TreePermisos(permisosTotales, 0, trvPermisos, Nothing)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        inNew = True
        gbUsuario.Enabled = True
        gbListado.Enabled = False

        userSelected = GetEstructuraUsuario().NewRow
        userSelected("usu_Codigo") = "NOUSERCODE"
        userSelected("usu_Estado") = 1
        trvPermisos.Nodes.Clear()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        inNew = False
        Dim result As Integer = MessageBox.Show("Desea Eliminar a al Usuario", "Eliminar", MessageBoxButtons.YesNoCancel)
        Dim clsUsuariosBD As New clsUsuario
        If result = DialogResult.Yes Then
            'Dim objDBPermisos As New clsPermisos
            'Dim row As DataRow = (DirectCast(dgvUsuarios.SelectedRows(0).DataBoundItem, DataRowView)).Row
            'userSelected = row
            'If (userSelected("usu_ID") = usuarioLogueado("usu_ID")) Then
            '    MsgBox("No puede eliminar el usuario que esta en sesion")
            'End If

            'userSelected("usu_Estado") = 0
            'Dim drRpta As DataRow

            'drRpta = objDBPermisos.Mantenimiento("R", permisosFinales, userSelected)
            'MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
            '           "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'gbUsuario.Enabled = False
        'gbListado.Enabled = True
        'Dim tablaUsuario As DataTable = GetEstructuraFiltrado()
        'Dim usuarioFilter As DataRow = tablaUsuario.NewRow
        'txtFiltro.Text = ""
        'usuarioFilter("usu_Nombre") = txtFiltro.Text
        'tablaUsuario.Rows.Add(usuarioFilter)
        'dgvUsuarios.DataSource = clsUsuariosBD.Listar(tablaUsuario)
        'trvPermisos.Nodes.Clear()

    End Sub

    Private Sub cmbRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRol.SelectedIndexChanged
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
        'trvPermisos.Nodes.Clear()
        'If initLoad Then
        ' TreePermisos(permisosFinales, 0, trvPermisos, Nothing)
        'End If
    End Sub

    Private Sub gbListado_Enter(sender As Object, e As EventArgs) Handles gbListado.Enter

    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvPersonas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick

    End Sub

    Private Sub chkPapeleta_CheckedChanged(sender As Object, e As EventArgs) Handles chkPapeleta.CheckedChanged

    End Sub
End Class