Imports CapaDatos

Public Class clsListados
    Implements IDisposable

    Public Function De(ByVal Listado As String, Optional ByVal Foranea As String = "") As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Listado", Listado))
            objPrm.Add(New Parametro("@Foranea", Foranea))
            objDtt = obj.ConsultaAccion("pa_Listados", objPrm)
            Return objDtt
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
        End Try
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

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

End Class
