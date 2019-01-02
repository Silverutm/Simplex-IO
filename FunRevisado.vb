Module FunRevisado
    'Multicplica dos matrices una de axb y bxc
    Public Function Multiplicar(ByVal Mat1 As Double(,), ByVal Mat2 As Double(,), ByVal a As Integer, ByVal b As Integer, ByVal c As Integer) As Double(,)
        Dim MatRespuesta As Double(,)
        ReDim MatRespuesta(a + 3, c + 3)

        Dim i, j, k As Integer
        Dim pp As Double = 0

        For i = 1 To a
            For j = 1 To c
                pp = 0
                For k = 1 To b
                    pp += Mat1(i, k) * Mat2(k, j)
                Next
                MatRespuesta(i, j) = pp
            Next
        Next

        Return MatRespuesta
    End Function

    'Resta dos matrices renglon, es de uso especifico
    Public Function Restar(ByVal Mat1 As Double(,), ByVal Mat2 As Double(,), ByVal ini As Integer, ByVal fin As Integer) As Double(,)
        Dim i As Integer
        Dim MatRespuesta As Double(,)
        ReDim MatRespuesta(1 + 3, fin + 3)
        For i = ini To fin
            MatRespuesta(1, i) = Mat1(1, i) - Mat2(1, i)
        Next
        Return MatRespuesta
    End Function

    'Copiar una matriz
    Public Function Copiar(ByVal MatTemp As Double(,)) As Double(,)
        Return MatTemp
    End Function

    Public Sub HacerIdentidad(ByRef MatTemp As Double(,), ByVal tam As Integer)
        Dim i, j As Integer
        For i = 1 To tam
            For j = 1 To tam
                If i = j Then
                    MatTemp(i, j) = 1
                Else
                    MatTemp(i, j) = 0
                End If                
            Next            
        Next
    End Sub

    Public Function StrM(ByVal k1 As Double, ByVal k2 As Double) As String
        'Para que en el dgv se vea bonito el renglon Z
        Dim str As String = ""
        If k1 <> 0 Then
            str = k1 & "M"
            If k2 < 0 Then
                str &= "   " & k2
            ElseIf k2 > 0 Then
                str &= " + " & k2
            End If
        Else : str = k2
        End If
        Return str
    End Function
End Module
