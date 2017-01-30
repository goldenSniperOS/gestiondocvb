Public Module modXML
    Public Function GetXMLPrincipal(ByVal dtDatos As DataTable, Optional ByVal Cabezera As String = "Dato", Optional ByVal Item As String = "Principal") As String
        Try
            Dim CadXML As String = ""

            If dtDatos.Rows.Count > 0 Then
                Dim C As String = """"
                CadXML = "<?xml version=" & C & "1.0" & C & " encoding=" & C & "ISO-8859-1" & C & "?>" & vbCrLf
                CadXML = CadXML & "<" & Cabezera & ">" & vbCrLf
                For Each Fila As DataRow In dtDatos.Rows
                    CadXML = CadXML & "  <" & Item & " "
                    For Each Columna As DataColumn In dtDatos.Columns
                        CadXML = CadXML & Columna.ColumnName & "=" & C &
                                 Fila.Item(Columna.ColumnName.ToString.Trim).ToString & C & " "
                    Next
                    CadXML = CadXML & "/>" + vbCrLf
                Next

                CadXML = CadXML & "</" & Cabezera & ">"
            End If
            Return CadXML
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetXMLExtra(ByVal dtDatos As DataTable, Optional ByVal Cabezera As String = "Dato", Optional ByVal Item As String = "Principal", Optional ByVal Extra As DataRow = Nothing, Optional ByVal ItemExtra As String = "Campo") As String
        Try
            Dim CadXML As String = ""

            If dtDatos.Rows.Count > 0 Or Extra IsNot Nothing Then
                Dim C As String = """"
                CadXML = "<?xml version=" & C & "1.0" & C & " encoding=" & C & "ISO-8859-1" & C & "?>" & vbCrLf
                CadXML = CadXML & "<" & Cabezera & ">" & vbCrLf
                For Each Fila As DataRow In dtDatos.Rows
                    CadXML = CadXML & "  <" & Item & " "
                    For Each Columna As DataColumn In dtDatos.Columns
                        CadXML = CadXML & Columna.ColumnName & "=" & C &
                                 Fila.Item(Columna.ColumnName.ToString.Trim).ToString & C & " "
                    Next
                    CadXML = CadXML & "/>" + vbCrLf

                Next
                'Campo Extra
                CadXML = CadXML & "  <" & ItemExtra & " "
                For Each Columna As DataColumn In Extra.Table.Columns
                    CadXML = CadXML & Columna.ColumnName & "=" & C &
                                 Extra.Item(Columna.ColumnName.ToString.Trim).ToString & C & " "
                Next
                CadXML = CadXML & "/>" + vbCrLf
                CadXML = CadXML & "</" & Cabezera & ">"
            End If
            Return CadXML
        Catch ex As Exception
            Throw
        End Try
    End Function
End Module
