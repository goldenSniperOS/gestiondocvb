Imports System.Runtime.InteropServices

Public Class Parametro
    Enum TipoDir
        Entrada = 0
        Salida = 1
        EntradaSalida = 2
        Retorno = 3
    End Enum

    Public Nombre As String
    Friend __Valor As Object
    Friend __objParam As IDbDataParameter
    Public Columna As String
    Public Direccion As TipoDir = TipoDir.Entrada
    Public Tipo As Integer

    Public Sub New(ByVal lpStrNombre As String, _
                   ByVal lpObjValor As Object)
        Nombre = lpStrNombre
        Valor = lpObjValor
        Tipo = DbType.AnsiString
    End Sub

    Public Sub New(ByVal lpStrNombre As String, _
                   ByVal lpObjValor As Object, _
                   ByVal lpDireccion As TipoDir)
        Nombre = lpStrNombre
        Valor = lpObjValor
        Direccion = lpDireccion
        Tipo = DbType.AnsiString
    End Sub

    Public Sub New(ByVal lpStrNombre As String, _
                   ByVal lpObjValor As Object, _
                   ByVal lpDireccion As TipoDir, _
                   ByVal lpIntTipo As DbType)
        Nombre = lpStrNombre
        Valor = lpObjValor
        Direccion = lpDireccion
        Tipo = lpIntTipo
    End Sub

    Public Property Valor() As Object
        Get
            If (Not IsNothing(__objParam)) Then
                Return __objParam.Value
            Else
                Return Me.__Valor
            End If
        End Get
        Set(ByVal Value As Object)
            Me.__Valor = Value
        End Set
    End Property
End Class

Public Class ParametroCollection
    Inherits ArrayList

    Public Shadows Sub Add(ByVal lpObjParam As Parametro)
        MyBase.Add(lpObjParam)
    End Sub

    Public Shadows Property Item(ByVal lpIntIndex As Integer) As Parametro
        Get
            Return CType(MyBase.Item(lpIntIndex), Parametro)
        End Get
        Set(ByVal Value As Parametro)
            MyBase.Item(lpIntIndex) = Value
        End Set
    End Property

End Class
