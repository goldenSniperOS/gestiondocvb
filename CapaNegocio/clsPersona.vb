﻿Imports CapaDatos
Public Class clsPersona
    Implements IDisposable
    Public Function Mantenimiento(ByVal Tipo As String, ByVal Data As DataTable) As DataRow
        Dim obj As New clsConexion
        Dim objPrm As New ParametroCollection
        Dim objDtt As DataTable = Nothing
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))

            objDtt = obj.ConsultaAccion("pa_persona", objPrm)
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

    Public Function Listado() As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Tipo", "L"))
            objPrm.Add(New Parametro("@InfoXML", ""))
            objDtt = obj.ConsultaAccion("pa_persona", objPrm)
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

    Public Function Filtro(ByVal FiltroCadena As String) As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Tipo", "F"))
            objPrm.Add(New Parametro("@InfoXML", FiltroCadena))
            objDtt = obj.ConsultaAccion("pa_persona", objPrm)
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

#Region "Seccion:Dispose"
    Private disposedValue As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
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