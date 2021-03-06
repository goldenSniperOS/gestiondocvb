﻿Imports CapaDatos
Public Class clsUsuario
    Implements IDisposable
    Public Function Registrar(ByVal Data As DataTable, ByVal Usuario As DataRow) As DataRow
        Dim obj As New clsConexion
        Dim objPrm As New ParametroCollection
        Dim objDtt As DataTable = Nothing
        Dim CadenaDatos As String = GetXMLExtra(Data, "Dato", "Principal", Usuario, "Usuario")
        Try
            objPrm.Add(New Parametro("@Tipo", "R"))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))

            objDtt = obj.ConsultaAccion("pa_usuario", objPrm)
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

    Public Function Actualizar(ByVal Data As DataTable, ByVal Usuario As DataRow) As DataRow
        Dim obj As New clsConexion
        Dim objPrm As New ParametroCollection
        Dim objDtt As DataTable = Nothing
        Dim CadenaDatos As String = GetXMLExtra(Data, "Dato", "Principal", Usuario, "Usuario")
        Try
            objPrm.Add(New Parametro("@Tipo", "A"))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))

            objDtt = obj.ConsultaAccion("pa_Usuario", objPrm)
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

    Public Function Consultar(ByVal Data As DataTable) As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", "C"))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))
            objDtt = obj.ConsultaAccion("pa_usuario", objPrm)
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

    Public Function Login(ByVal Data As DataTable) As DataTable
        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", "L"))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))
            objDtt = obj.ConsultaAccion("pa_usuario", objPrm)
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

    Public Function PermisosXUsuario(ByVal Data As DataTable) As DataTable
        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Dim CadenaDatos As String = GetXMLPrincipal(Data)
        Try
            objPrm.Add(New Parametro("@Tipo", "P"))
            objPrm.Add(New Parametro("@InfoXML", CadenaDatos))
            objDtt = obj.ConsultaAccion("pa_Usuario", objPrm)
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
