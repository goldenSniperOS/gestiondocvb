Imports System.Reflection

Public Class frmPrincipal
    Dim usuario As DataRow
    Property userQuery As DataTable
    Property permissions As DataTable

    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) _
     Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usuario = permissions.Rows(0)
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.CurrencyDecimalSeparator = "."
        r.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = r
        Me.MenuPrincipal(permissions, 0, mnuGeneral, Nothing)
    End Sub

    Private Sub MenuPrincipal(Permisos As DataTable, Padre As Integer, ByRef Menu As MenuStrip, ByRef Item As ToolStripMenuItem)
        Dim vistaMenu As DataView = New DataView(Permisos)
        vistaMenu.RowFilter = Permisos.Columns("mod_Padre").ColumnName & " = " & Padre
        For Each dataRow As DataRowView In vistaMenu
            Dim objMenu As New ToolStripMenuItem
            objMenu.Name = dataRow("mod_ID").ToString
            objMenu.Text = dataRow("mod_Nombre").ToString
            objMenu.Tag = dataRow("mod_Formulario").ToString
            If Padre = 0 Then
                Menu.Items.Add(objMenu)
            Else
                AddHandler objMenu.Click, AddressOf MenuItemClickHandler
                Item.DropDownItems.Add(objMenu)
            End If
            MenuPrincipal(Permisos, dataRow("mod_ID"), Menu, objMenu)
        Next
    End Sub

    Private Sub MenuItemClickHandler(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim frm As New Form
        frm = DirectCast(CreateObjectInstance(clickedItem.Tag), Form)
        Dim formType As Type = frm.GetType
        Dim propInfo As PropertyInfo = formType.GetProperty("usuarioLogueado")
        Dim propInfoQuery As PropertyInfo = formType.GetProperty("usuarioLogueadoQuery")
        If propInfo IsNot Nothing Then
            propInfo.SetValue(frm, permissions.Rows(0))
            propInfoQuery.SetValue(frm, userQuery)
        End If
        frm.ShowDialog()
    End Sub

    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If
            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)
        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj
    End Function
End Class