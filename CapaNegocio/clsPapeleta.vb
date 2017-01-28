﻿Imports CapaDatos
Public Class clsPapeleta
    Implements IDisposable

    Public Function Mantenimiento(Tipo As String, Data As DataTable) As DataRow
        Dim objConexion As New clsConexion
        Dim objParametros As New ParametroCollection
        Dim objData As DataTable = Nothing
        Try
            objParametros.Add(New Parametro("@Tipo", Tipo))
            objParametros.Add(New Parametro("@InfoXML", GetXMLPrincipal(Data)))

            objData = objConexion.ConsultaAccion("pa_Papeleta", objParametros)

            Return objData.Rows(0)
        Catch ex As Exception
            If Not objConexion Is Nothing Then
                objConexion.Dispose()
                objConexion = Nothing
            End If

            If objData IsNot Nothing Then
                objData.Dispose()
                objData = Nothing
            End If
            If objParametros IsNot Nothing Then
                objParametros = Nothing
            End If
        End Try

    End Function


    Public Function Listado(ByVal Tipo As String) As DataTable

        Dim obj As New clsConexion
        Dim objDtt As DataTable = Nothing
        Dim objPrm As New ParametroCollection
        Try
            objPrm.Add(New Parametro("@Tipo", Tipo))
            objPrm.Add(New Parametro("@InfoXML", ""))
            objDtt = obj.ConsultaAccion("pa_ListaPapeletas", objPrm)
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
