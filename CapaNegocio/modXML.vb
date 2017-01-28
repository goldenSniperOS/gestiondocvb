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
End Module
