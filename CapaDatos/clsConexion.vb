Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class clsConexion
    Implements IDisposable

    Private CadenaConexion As String
    Private ObjConexion As SqlConnection = Nothing
    Private objComando As SqlCommand
    Private objAdaptador As SqlDataAdapter

    Public ValorMaximo As Integer = 1000
    Private ObjTra As SqlTransaction = Nothing

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes
    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
        End If
        Me.disposedValue = True
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Sub New()
        'CadenaConexion = "Data Source=LENOVO-PC\MANUELSQLSERVER;Initial Catalog=BDGestionDocumentaria;Integrated Security=True"
        CadenaConexion = "Data Source=23.249.166.131;Initial Catalog=BDGestionDocumentaria;User Id = sa; Password = EiAb129018H"
        ObjConexion = New SqlConnection(CadenaConexion)
    End Sub

    Private Sub Open()
        ObjConexion.Open()
    End Sub

    Private Sub Close()
        If (ObjConexion.State = ConnectionState.Open) Then
            ObjConexion.Close()
        End If
    End Sub

    Public Function ConsultaAccion(ByVal lpStrSP As String, ByVal lpObjArrParams As ParametroCollection, _
                                   Optional ByVal lpBoolAcceptChangesDuringFill As Boolean = True) As DataTable
        Dim lvObjDap As New SqlDataAdapter
        Dim lvObjRet As New DataTable

        Me.Open()
        lvObjDap.SelectCommand = MapearParametros(lpStrSP, lpObjArrParams)
        Try
            lvObjDap.AcceptChangesDuringFill = lpBoolAcceptChangesDuringFill
            lvObjDap.Fill(lvObjRet)
        Catch ex As Exception
            If lvObjRet IsNot Nothing Then
                lvObjRet.Dispose()
                lvObjRet = Nothing
            End If
            Throw ex
        Finally
            If lvObjDap IsNot Nothing Then
                lvObjDap.Dispose()
                lvObjDap = Nothing
            End If
            Me.Close()
        End Try
        Return lvObjRet
    End Function

#Region "Creacion DataTable"
    Private Function MapearParametros(ByVal lpStrSP As String, ByVal lpObjArrParams As ParametroCollection) As SqlCommand
        Dim lvObjCmd As New SqlCommand(lpStrSP, ObjConexion)
        Dim lvObjPrm As SqlParameter = Nothing
        Try
            lvObjCmd.CommandType = CommandType.StoredProcedure
            lvObjCmd.CommandTimeout = ValorMaximo


            If Not lpObjArrParams Is Nothing Then
                For Each lvObjParam As Parametro In lpObjArrParams
                    lvObjPrm = New SqlParameter
                    lvObjPrm.ParameterName = lvObjParam.Nombre
                    Select Case lvObjParam.Direccion
                        Case Parametro.TipoDir.Entrada
                            lvObjPrm.Direction = ParameterDirection.Input
                        Case Parametro.TipoDir.EntradaSalida
                            lvObjPrm.Direction = ParameterDirection.InputOutput
                        Case Parametro.TipoDir.Retorno
                            lvObjPrm.Direction = ParameterDirection.ReturnValue
                        Case Parametro.TipoDir.Salida
                            lvObjPrm.Direction = ParameterDirection.Output
                    End Select
                    lvObjPrm.SourceColumn = lvObjParam.Columna
                    lvObjPrm.Value = lvObjParam.Valor
                    lvObjParam.__objParam = lvObjPrm
                    lvObjCmd.Parameters.Add(lvObjPrm)
                Next
            End If
            lvObjCmd.Transaction = ObjTra
            Return lvObjCmd
        Catch ex As Exception
            If lvObjCmd IsNot Nothing Then
                lvObjCmd.Dispose()
                lvObjCmd = Nothing
            End If
            Throw ex
        Finally
            If lvObjPrm IsNot Nothing Then
                lvObjPrm = Nothing
            End If
        End Try
    End Function
#End Region

End Class