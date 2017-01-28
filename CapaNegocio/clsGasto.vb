Imports CapaDatos

Public Class clsGasto
    Implements IDisposable

    Public Function Mantenimiento(ByVal Tipo As String, ByVal Data As DataTable) As DataRow
        Dim obj As New clsConexion
        Dim objPrm As New ParametroCollection
        Dim objDtt As DataTable = Nothing
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))
            objDtt = obj.ConsultaAccion("pa_GastoMovilidad", objPrm)
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
    Public Function Listado(ByVal Tipo As String, Optional ByVal Datos As DataTable = Nothing) As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            If (Tipo = "L") Then
                objPrm.Add(New Parametro("@InfoXML", ""))
                objDtt = obj.ConsultaAccion("pa_GastoMovilidad", objPrm)
            Else
                Dim CadenaDatos As String = GetXMLPrincipal(Datos)
                objPrm.Add(New Parametro("@InfoXML", CadenaDatos))
                objDtt = obj.ConsultaAccion("pa_GastoMovilidad", objPrm)
            End If

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

    Public Function Inicializar(ByVal Tipo As String) As DataRow

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            objPrm.Add(New Parametro("@InfoXML", ""))
            objDtt = obj.ConsultaAccion("pa_GastoMovilidad", objPrm)
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
        End Try
    End Function
#Region "Seccion:Dispose"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
            End If
        End If
        disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region

End Class
