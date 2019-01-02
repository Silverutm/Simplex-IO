Public Class Revisado
    Private Sub Revisado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer

        'Hacer B-1 la identidad
        HacerIdentidad(B_1, m)
        HacerIdentidad(Identidad, m)
        'B_1 = Copiar(Identidad)

        'Cargar los datos iniciales
        HacerMatrices()
        txtRespuesta.Text = "     Valores iniciales" & Chr(13) + Chr(10)
        impresionparcial("CB", CB, 1, 1, 1, m) ''''''''''''''''''''''
        impresionparcial("CB_Gran M", CB_M, 1, 1, 1, m) ''''''''''''''''''''''
        impresionparcial("CJ", CJ, 1, 1, 1, cantCJ) '''''''''''''''''''''
        impresionparcial("CJ_Gran M", CJ_M, 1, 1, 1, cantCJ) '''''''''''''''''''''
        impresionparcial("XB", XB, 1, m, 1, 1) '''''''''''''''''''''
        impresionparcial("P", P, 1, m, 1, cantCJ)

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If vuelta() = True Then
            imprimir()
        End If
    End Sub

    Private Sub btnResolver_Click(sender As Object, e As EventArgs) Handles btnResolver.Click

    End Sub
    Private Function vuelta() As Boolean
        txtRespuesta.Text &= "-------Iteracion---------" & Chr(13) + Chr(10)
        Dim jentrante, i, rsaliente As Integer
        Dim a As Double
        'impresionparcial("CB", CB, 1, 1, 1, m) ''''''''''''''''''''''
        'impresionparcial("CJ", CJ, 1, 1, 1, cantCJ) '''''''''''''''''''''
        'impresionparcial("al comenzar XB", XB, 1, m, 1, 1) '''''''''''''''''''''
        'impresionparcial("P", XB, 1, m, 1, 1)

        '1
        'Detectar Vector entrante PJ, las no basicas
        '   a)
        Y = Multiplicar(CB, B_1, 1, m, m)
        Y_M = Multiplicar(CB_M, B_1, 1, m, m)

        impresionparcial("Y", Y, 1, 1, 1, m) ''''''''''''''''''''''''''''''''''''
        impresionparcial("Y Gran M", Y_M, 1, 1, 1, m) ''''''''''''''''''''''''''''''''''''

        '   b) para toda j no basica
        Z_CJ = Restar(Multiplicar(Y, P, 1, m, cantCJ), CJ, 1, cantCJ)
        Z_CJ_M = Restar(Multiplicar(Y_M, P, 1, m, cantCJ), CJ_M, 1, cantCJ)

        impresionparcial("Z-C", Z_CJ, 1, 1, 1, cantCJ) ''''''''''''''''''''''''''''''
        impresionparcial("Z-C Gran M", Z_CJ_M, 1, 1, 1, cantCJ) ''''''''''''''''''''''''''''''
        '       jentrante
        a = Z_CJ_M(1, 1)
        jentrante = 1
        For i = 2 To cantCJ
            If a > Z_CJ_M(1, i) Then
                a = Z_CJ_M(1, i)
                jentrante = i
            ElseIf a = Z_CJ_M(1, i) Then
                If Z_CJ(1, jentrante) > Z_CJ(1, i) Then
                    jentrante = i
                End If
            End If
        Next

        If Z_CJ_M(1, jentrante) > 0 Or (Z_CJ_M(1, jentrante) = 0 And Z_CJ(1, jentrante) >= 0) Then
            'MsgBox("Solucion optima encontrada", MsgBoxStyle.Exclamation, "Simplex IO")
            txtRespuesta.Text &= "Variables basicas" & Chr(13) + Chr(10)
            For i = 1 To m
                txtRespuesta.Text &= CBindices(i) & "  "
            Next
            txtRespuesta.Text &= Chr(13) + Chr(10)

            XB = Multiplicar(B_1, bb, m, m, 1)
            impresionparcial("XB", XB, 1, m, 1, 1) '''''''''''''''''''''
            Dim S1 As String = StrM(Multiplicar(CB_M, XB, 1, m, 1)(1, 1), Multiplicar(CB, XB, 1, m, 1)(1, 1))
            MsgBox(S1, MsgBoxStyle.Information, "Respuesta")
            txtRespuesta.Text &= "Z =" & S1
            '
            'Queda pendiente revisar si es factible
            Factible()
            '
            '
            Return False
        End If


        '2
        '   a) Determinar vector saliente r, dado jentrante
        XB = Multiplicar(B_1, bb, m, m, 1)
        impresionparcial("XB", XB, 1, m, 1, 1) ''''''''''''''''''''''''''''''''''''''''''''''''''''

        '   b) coef de restriccion entrante alfaj
        '       pasar P(j) a pj
        For i = 1 To m
            Pj(i, 1) = P(i, CJindices(jentrante))
        Next
        alfaj = Multiplicar(B_1, Pj, m, m, 1)
        impresionparcial("Alfa " & jentrante, alfaj, 1, m, 1, 1) ''''''''''''''''''''''''''''''''''''''''

        '       Encontrar al minimo
        rsaliente = -1
        For i = 1 To m
            If alfaj(i, 1) > 0 Then
                If rsaliente = -1 Then
                    rsaliente = i
                ElseIf XB(i, 1) / alfaj(i, 1) < XB(rsaliente, 1) / alfaj(rsaliente, 1) Then
                    rsaliente = i
                ElseIf XB(i, 1) / alfaj(i, 1) = XB(rsaliente, 1) / alfaj(rsaliente, 1) Then
                    Dim k = MsgBox("Tenemos algo degenerado, no es seguro continuar, desea continuar" _
                                   , MsgBoxStyle.YesNo, "Cuidado")
                    If k = MsgBoxResult.No Then
                        Return False
                    End If
                End If
            End If
        Next

        If rsaliente = -1 Then
            MsgBox("Z no acotada", MsgBoxStyle.Critical, "Cuidado")
            Return False
        End If

        '3
        'Bsiguiente
        'Crear la matriz EE
        HacerIdentidad(EE, m)
        'impresionparcial("E", EE, 1, m, 1, m) '''''''''''''''''''''''''''''''''
        impresionparcial("B", B_1, 1, m, 1, m) ''''''''''''''''''''''
        For i = 1 To m
            EE(i, rsaliente) = -alfaj(i, 1) / alfaj(rsaliente, 1)
        Next
        EE(rsaliente, rsaliente) = 1 / alfaj(rsaliente, 1)
        'impresionparcial("multi", Multiplicar(EE, B_1, m, m, m), 1, m, 1, m)
        B_1 = Multiplicar(EE, B_1, m, m, m)
        'impresionparcial("E", EE, 1, m, 1, m) ''''''''''''''''''''''''''''''
        'impresionparcial("B", B_1, 1, m, 1, m) '''''''''''''''''''''''''''''
       
        

        impresionparcial("E", EE, 1, m, 1, m) ''''''''''''''''''''''''''''''
        impresionparcial("B siguiente", B_1, 1, m, 1, m) ''''''''''''''''''''''''''''''


        'txtRespuesta.Text &= "antes del cambio" & Chr(13) + Chr(10)
        'For i = 1 To cantCJ
        'txtRespuesta.Text &= CJindices(i) & "  "
        'Next
        'txtRespuesta.Text &= Chr(13) + Chr(10)
        'For i = 1 To m
        ' txtRespuesta.Text &= CBindices(i) & "  "
        'Next
        'txtRespuesta.Text &= Chr(13) + Chr(10)


        Dim comodin As Integer
        comodin = CBindices(rsaliente)
        CBindices(rsaliente) = CJindices(jentrante)
        CJindices(jentrante) = comodin

        'txtRespuesta.Text &= "despues" & Chr(13) + Chr(10)
        'For i = 1 To cantCJ
        'txtRespuesta.Text &= CJindices(i) & "  "
        'Next
        'txtRespuesta.Text &= Chr(13) + Chr(10)
        'For i = 1 To m
        ' txtRespuesta.Text &= CBindices(i) & "  "
        'Next
        'txtRespuesta.Text &= Chr(13) + Chr(10)

        'Obtener Cj y CB y las demas muchas cosas
        HacerMatrices()


        impresionparcial("CB", CB, 1, 1, 1, m) ''''''''''''''''''''''
        impresionparcial("CB_Gran M", CB_M, 1, 1, 1, m) ''''''''''''''''''''''
        impresionparcial("CJ", CJ, 1, 1, 1, cantCJ) '''''''''''''''''''''
        impresionparcial("CJ_Gran M", CJ_M, 1, 1, 1, cantCJ) '''''''''''''''''''''
        impresionparcial("XB", XB, 1, m, 1, 1) '''''''''''''''''''''
        impresionparcial("P", P, 1, m, 1, cantCJ)

        Return True
    End Function

    Private Sub imprimir()

    End Sub

    Private Sub impresionparcial(ByVal nombre As String, ByVal MatTemp As Double(,), ByVal i As Integer, ByVal ifi As Integer, ByVal j As Integer, ByVal jf As Integer)
        Dim renglon, columna As Integer
        txtRespuesta.Text &= nombre & Chr(13) + Chr(10)
        For renglon = i To ifi
            For columna = j To jf
                txtRespuesta.Text &= MatTemp(renglon, columna) & "  "
            Next
        txtRespuesta.Text &= Chr(13) + Chr(10)
        Next
        txtRespuesta.Text &= Chr(13) + Chr(10)
        txtRespuesta.Text &= Chr(13) + Chr(10)
    End Sub

    Private Sub HacerMatrices()
        Dim i, j As Integer

        'Hacer el P original
        For i = 1 To cantCJ
            For j = 1 To m
                P(j, i) = Matriz(j, CJindices(i))
            Next
        Next

        'Hacer CB Y CBM ORIGINAL
        For i = 1 To m
            CB(1, i) = C(1, CBindices(i))
            CB_M(1, i) = CM(1, CBindices(i))
        Next

        'CJ y CJM original
        For i = 1 To cantCJ
            CJ(1, i) = C(1, CJindices(i))
            CJ_M(1, i) = CM(1, CJindices(i))
        Next
    End Sub

    Private Sub Factible()
        Dim i, j As Integer
        For i = 1 To cantArtificiales
            For j = 1 To m
                If Artificiales(i) = CBindices(j) Then
                    MsgBox("Solucion optima no factible", MsgBoxStyle.Critical, "Simplex IO")
                    Exit Sub
                End If
            Next
        Next
    End Sub
End Class