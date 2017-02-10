Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports CapaNegocio

Public Class frmAsignarVacaciones
    Private Function getEstructura() As DataTable
        Try
            Dim dtCargo As New DataTable

            With dtCargo.Columns
                .Add("DNI", GetType(String))
                .Add("Persona", GetType(String))
                .Add("Vacaciones", GetType(Integer))

            End With
            dtCargo.Rows.Clear()
            Return dtCargo
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Sub frmAsignarVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (dialog.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = System.IO.Path.GetFullPath(dialog.FileName)
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + System.IO.Path.GetFullPath(dialog.FileName) + "';Extended Properties='Excel 12.0 XML;HDR={1}'")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Hoja1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            dgvLista.DataSource = DtSet.Tables(0)
            MyConnection.Close()
        End If

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim drRpta As DataTable = Nothing
        Dim objCargo As New clsDocumentoVacacion
        drRpta = objCargo.MantenimientoSimple("B", txtBuscador.Text)
        dgvLista.DataSource = drRpta
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Dim drRpta As DataRow = Nothing
        Dim objCargo As New clsDocumentoVacacion
        drRpta = objCargo.Mantenimiento("AS", dgvLista.DataSource)
        MessageBox.Show(drRpta.Item("MensajeTitulo").ToString & vbCrLf & drRpta.Item("MensajeProcedure").ToString, _
                            "Gestion Documentaria", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Function GetAssemblyDirectoryPath() As String
        Dim fullAssemblyPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Return fullAssemblyPath.Substring(0, fullAssemblyPath.LastIndexOf("\"c))
    End Function
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim filename = sPath + "FormatoVacaciones.xlsx"
        IO.File.WriteAllBytes(filename, My.Resources.FormatoVacaciones)
        Process.Start(filename)

    End Sub
End Class