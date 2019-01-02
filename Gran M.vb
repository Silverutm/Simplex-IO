Public Class Gran_M
    Private Sub imprimir()
        'Pasar las matrices al data grid view
        MatrizaDGV(dgvRespuesta, Matriz, 1, m, 0, Nt + 1, 1, 0)

        For i = 1 To Nt
            dgvRespuesta.Columns(i).HeaderText = "X" & i
        Next

        For i = 0 To Nt + 1
            dgvRespuesta.Rows(0).Cells(i).Value = StrM(ZM(i), Z(i))
        Next

        For i = 1 To m
            dgvRespuesta.Rows(i).HeaderCell.Value = "X" & basicas(i)
        Next
        DGVWidthMinimo(dgvRespuesta, 550, 75)
        dgvRespuesta.Height = Minimo(250, (m + 3) * 22 - 20)
        'Aun no hace nada
        ListadeVariables()
    End Sub

    Private Sub Gran_M_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvRespuesta.ColumnCount = Nt + 2
        dgvRespuesta.RowCount = m + 1

        dgvRespuesta.Columns(Nt + 1).HeaderText = "b"
        dgvRespuesta.Columns(0).HeaderText = "Z"

        imprimir()
    End Sub

    Private Sub btnResolver_Click(sender As Object, e As EventArgs) Handles btnResolver.Click
        'Resuelve de golpe las iteraciones
        While iteracion() = True
        End While
        imprimir()
    End Sub

    Private Function iteracion() As Boolean
        'Encontrar el minimo        columna pivote
        Dim a, pivote As Double
        Dim i As Integer
        a = ZM(1)
        ColumnaPivote = 1
        For i = 2 To Nt
            If a > ZM(i) Then
                a = ZM(i)
                ColumnaPivote = i
            ElseIf a = ZM(i) Then
                If Z(ColumnaPivote) > Z(i) Then
                    ColumnaPivote = i
                End If
            End If
        Next

        'Verificar si ya llegamos a la solucion optima
        If ZM(ColumnaPivote) > 0 Or (ZM(ColumnaPivote) = 0 And Z(ColumnaPivote) >= 0) Then
            MsgBox("Solucion optima encontrada", MsgBoxStyle.Exclamation, "Simplex IO")
            EsFactible()
            Return False
        End If

        'Buscar la variable entrante
        RenglonPivote = -1
        For i = 1 To m
            If Matriz(i, ColumnaPivote) > 0 Then
                If RenglonPivote = -1 Then
                    RenglonPivote = i
                ElseIf Matriz(i, Nt + 1) / Matriz(i, ColumnaPivote) < Matriz(RenglonPivote, Nt + 1) / Matriz(RenglonPivote, ColumnaPivote) Then
                    RenglonPivote = i
                ElseIf Matriz(i, Nt + 1) / Matriz(i, ColumnaPivote) = Matriz(RenglonPivote, Nt + 1) / Matriz(RenglonPivote, ColumnaPivote) Then
                    Dim k = MsgBox("Tenemos algo degenerado, no es seguro continuar, desea continuar" _
                                   , MsgBoxStyle.YesNo, "Cuidado")
                    If k = MsgBoxResult.No Then
                        Return False
                    End If
                End If
            End If
        Next

        If RenglonPivote = -1 Then
            MsgBox("Z no acotada", MsgBoxStyle.Critical, "Cuidado")
            Return False
        End If

        'Variable saliente
        basicas(RenglonPivote) = ColumnaPivote

        'Gauss
        pivote = Matriz(RenglonPivote, ColumnaPivote)
        MatrizporEscalar(1 / pivote, Matriz, RenglonPivote, RenglonPivote, 0, Nt + 1)
        For i = 1 To m
            If i = RenglonPivote Then Continue For
            pivote = -Matriz(i, ColumnaPivote)
            If pivote = 0 Then Continue For
            MatrizporEscalar(pivote, Matriz, RenglonPivote, RenglonPivote, 0, Nt + 1)
            SumarRenglonesR1(Matriz, i, RenglonPivote, 0, Nt + 1)
            MatrizporEscalar(1 / pivote, Matriz, RenglonPivote, RenglonPivote, 0, Nt + 1)
        Next

        SumarZ(Z, Matriz, RenglonPivote)
        SumarZ(ZM, Matriz, RenglonPivote)

        Return True
    End Function

    Private Sub EsFactible()
        Dim i, j As Integer
        For i = 1 To cantArtificiales
            For j = 1 To m
                If Artificiales(i) = basicas(j) Then
                    MsgBox("Solucion optima no factible", MsgBoxStyle.Critical, "Simplex IO")
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub ListadeVariables()

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If iteracion() = True Then
            imprimir()
        End If
    End Sub
End Class