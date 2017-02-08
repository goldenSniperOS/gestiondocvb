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

        gbPermisos.Text = "Permisos de " & usuarioLogueado("per_Nombres") & " " & usuarioLogueado("per_Apellidos")

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

    Private Sub TreePermisosRoles(Permisos As DataTable, Padre As Integer, ByRef Tree As TreeView, ByRef Item As TreeNode)
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
            TreePermisosRoles(Permisos, dataRow("mod_ID"), Tree, node)
        Next
    End Sub

    Private Sub trvPermisos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvPermisos.AfterCheck
        'For Each dataRow As DataRow In permisosFinales.Rows
        '    If (dataRow("usu_mod_Modulo") = e.Node.Tag.ToString) Then
        '        If (dataRow("Accion") = "NOTHING") Then
        '            If e.Node.Checked Then
        '                dataRow("Accion") = "INSERT"
        '            Else
        '                dataRow("Accion") = "DELETE"
        '            End If
        '        Else
        '            dataRow("Accion") = "NOTHING"
        '        End If
        '        Return
        '    End If
        'Next
        'Dim rowNueva As DataRow = permisosFinales.NewRow
        'rowNueva("usu_mod_Id") = e.Node.Name
        'rowNueva("usu_mod_Usuario") = userSelected("usu_Codigo")
        'rowNueva("usu_mod_Modulo") = CInt(e.Node.Tag.ToString)
        'If e.Node.Checked Then
        '    rowNueva("Accion") = "INSERT"
        'Else
        '    rowNueva("Accion") = "DELETE"
        'End If
        'permisosFinales.Rows.Add(rowNueva)
    End Sub

    Public Sub getCheckedList()
        permisosFinales.Rows.Clear()
        For Each rootNode As TreeNode In trvPermisos.Nodes
            If (rootNode.Checked) Then
                Dim rowNueva As DataRow = permisosFinales.NewRow
                rowNueva("usu_mod_Id") = rootNode.Name
                rowNueva("usu_mod_Usuario") = userSelected("usu_Codigo")
                rowNueva("usu_mod_Modulo") = CInt(rootNode.Tag.ToString)
                rowNueva("Accion") = "INSERT"
                permisosFinales.Rows.Add(rowNueva)
                getChildNodes(rootNode)
            End If
        Next
    End Sub

    Public Sub getChildNodes(ByVal rootTreeNode As TreeNode)
        Try
            For Each rootNode As TreeNode In rootTreeNode.Nodes
                If (rootNode.Checked) Then
                    Dim rowNueva As DataRow = permisosFinales.NewRow
                    rowNueva("usu_mod_Id") = rootNode.Name
                    rowNueva("usu_mod_Usuario") = userSelected("usu_Codigo")
                    rowNueva("usu_mod_Modulo") = CInt(rootNode.Tag.ToString)
                    rowNueva("Accion") = "INSERT"
                    permisosFinales.Rows.Add(rowNueva)
                    getChildNodes(rootNode)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim clsUsuariosBD As New clsUsuario
        Dim drRpta As DataRow
        If (userSelected("usu_Codigo") = usuarioLogueado("usu_Codigo")) Then
            'El Usuario Esta Logueado
        Else
            userSelected("usu_Nombre") = txtUsuario.Text
            userSelected("usu_Contrasena") = txtPassword.Text
        End If

        userSelected("usu_Persona") = If(chkPersona.Checked, "SI", "NO")
        userSelected("usu_Beneficio") = If(chkGasto.Checked, "SI", "NO")
        userSelected("usu_Papeleta") = If(chkPapeleta.Checked, "SI", "NO")
        userSelected("usu_Vacaciones") = If(chkVacaciones.Checked, "SI", "NO")
        userSelected("usu_NotaContable") = If(chkNotaContable.Checked, "SI", "NO")
        userSelected("usu_Marcacion") = If(chkMarcacion.Checked, "SI", "NO")

        getCheckedList()

        If (inNew) Then
            drRpta = clsUsuariosBD.Registrar(permisosFinales, userSelected)
        Else
            drRpta = clsUsuariosBD.Actualizar(permisosFinales, userSelected)
        End If

        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                           "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information)

        gbUsuario.Enabled = False
        gbListado.Enabled = True
        Dim clsBDPersona As New clsPersona
        dgvUsuarios.DataSource = clsBDPersona.Filtro(txtFiltro.Text)
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

        gbPermisos.Text = "Permisos de " & usuarioLogueado("per_Nombres") & " " & usuarioLogueado("per_Apellidos")

        permisosFinales = GetEstructuraPermisos()
        usuarioLogueadoQuery.Rows(0)("usu_Nombre") = userSelected("usu_Nombre")
        usuarioLogueadoQuery.Rows(0)("usu_Contrasena") = userSelected("usu_Contrasena")
        permisosTotales = clsUsuariosBD.PermisosXUsuario(usuarioLogueadoQuery)
        TreePermisos(permisosTotales, 0, trvPermisos, Nothing)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
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
            Dim objDBPermisos As New clsUsuario
            Dim row As DataRow = (DirectCast(dgvUsuarios.SelectedRows(0).DataBoundItem, DataRowView)).Row
            userSelected = row
            If (userSelected("usu_Codigo") = usuarioLogueado("usu_Codigo")) Then
                MsgBox("No puede eliminar el usuario que esta en sesion")
            End If

            userSelected("usu_Estado") = 0
            Dim drRpta As DataRow

            permisosFinales.Rows.Clear()

            drRpta = objDBPermisos.Actualizar(permisosFinales, userSelected)
            MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString,
                       "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        gbUsuario.Enabled = False
        gbListado.Enabled = True
        Dim clsBDPersona As New clsPersona
        dgvUsuarios.DataSource = clsBDPersona.Filtro(txtFiltro.Text)
    End Sub

    Private Sub cmbRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRol.SelectedIndexChanged
        If initLoad Then
            trvPermisos.Nodes.Clear()
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
            TreePermisosRoles(permisosFinales, 0, trvPermisos, Nothing)


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
        End If

    End Sub

    Private Sub dgvUsuarios_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvUsuarios.CellFormatting
        If e.ColumnIndex = 36 Then
            If e.Value Then
                If e.Value IsNot Nothing Then
                    e.CellStyle.BackColor = Color.LightGreen
                    e.Value = "ACTIVO"
                End If
            Else
                If e.Value IsNot Nothing Then
                    e.CellStyle.BackColor = Color.LightCoral
                    e.Value = "INHABILITADO"
                End If
            End If
        End If
    End Sub
End Class