Imports CapaDatos

Public Class clsNotaContable
    Implements IDisposable


    Public Function Mantenimiento(ByVal Tipo As String, ByVal Data As DataTable) As DataRow
        Dim obj As New clsConexion
        Dim objPrm As New ParametroCollection
        Dim objDtt As DataTable = Nothing
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))

            objDtt = obj.ConsultaAccion("pa_MantenimientoNotaContable", objPrm)
            Return objDtt.Rows(0)
        Catch ex As Exception
            Throw ex
        Finally
            If Not obj Is Nothing Then
                obj.Dispose()
                objDtt = Nothing
            End If
            If objDtt IsNot Nothing Then
                objDtt.Dispose()
                objDtt = Nothing
            End If
            If objPrm IsNot Nothing Then
                objPrm = Nothing
            End If
        End Try

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: eliminar estado administrado (objetos administrados).
            End If

            ' TODO: liberar recursos no administrados (objetos no administrados) e invalidar Finalize() below.
            ' TODO: Establecer campos grandes como Null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: invalidar Finalize() sólo si la instrucción Dispose(ByVal disposing As Boolean) anterior tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Ponga el código de limpieza en la instrucción Dispose(ByVal disposing As Boolean) anterior.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose(disposing As Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
