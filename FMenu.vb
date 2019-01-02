Public Class FMenu

    Private Sub nudVariables_ValueChanged(sender As Object, e As EventArgs) Handles nudVariables.ValueChanged
        n = nudVariables.Value
        dgvEntrada.ColumnCount = n + 3

        'El encabezado del dgv
        dgvEntrada.Columns(n).HeaderText = "X" & n
        dgvEntrada.Columns(n + 1).HeaderText = ">=<"
        dgvEntrada.Columns(n + 2).HeaderText = "b"
    End Sub

    Private Sub nudRestricciones_ValueChanged(sender As Object, e As EventArgs) Handles nudRestricciones.ValueChanged
        m = nudRestricciones.Value
        dgvEntrada.RowCount = m + 2

        'Para que no se vea feo el tamanho
        dgvEntrada.Height = Minimo(250, (m + 4) * 22 - 20)

        'Columna Z
        dgvEntrada.Rows(m).Cells(0).Value = "0"

    End Sub

    Private Sub FMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvEntrada.Rows(0).Cells(0).Value = "1"
        nudRestricciones.Value = 2
        nudRestricciones.Value = 1
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click        
        Dim i, k As Integer

        'Si escogieron gran M
        'Cambia el tamanho de los arreglos
        Redimensionar()
        Try
            'pasar el dvg a la matriz
            DGVaMatriz(dgvEntrada, Matriz, 1, m, 0, n, 1, 0)
            DGVaVector(dgvEntrada, b, 1, m, n + 2, n + 2, 1)
            DGVaVector(dgvEntrada, Cotas, m + 1, m + 1, 1, n, 1)
            DGVaVector(dgvEntrada, Z, 0, 0, 0, n, 0)
            bZ = dgvEntrada.Rows(0).Cells(n + 2).Value
        Catch ex As Exception
            MsgBox("Existen datos invalidos en la tabla", MsgBoxStyle.Critical, "Cuidado")
            Exit Sub
        End Try

        bZM = 0

        n = nudVariables.Value
        m = nudRestricciones.Value

        s = n + 1
        cantPares = 0
        cantNegativos = 0
        cantArtificiales = 0

        'Para el simplex revisado
        For cantCJ = 1 To n
            CJindices(cantCJ) = cantCJ
        Next
        cantCJ = n

        'Revisar cotas
        For i = 1 To n
            'No tiene cota
            If Cotas(i) = 1 Then
                cantPares += 1
                Pares(0, cantPares) = i
                Pares(1, cantPares) = s
                For k = 1 To m
                    Matriz(k, s) = -Matriz(k, i)
                Next
                Z(s) = -Z(i)
                s += 1
                'Si su cota es un negativo
            ElseIf Cotas(i) < 0 Then
                cantNegativos += 1
                Negativos(0, cantNegativos) = i
                Negativos(1, cantNegativos) = Cotas(i)
                For k = 1 To m
                    b(k) -= Matriz(k, i) * Cotas(i)
                Next
                bZ -= Z(i) * Cotas(i)
            End If
        Next

        'Revisar por b<0
        For i = 1 To m
            If b(i) < 0 Then
                MatrizporEscalar(-1, Matriz, i, i, 1, n)
                b(i) = -b(i)
                If dgvEntrada.Rows(i).Cells(n + 1).Value = ">" Then
                    dgvEntrada.Rows(i).Cells(n + 1).Value = "<"
                ElseIf dgvEntrada.Rows(i).Cells(n + 1).Value = "<" Then
                    dgvEntrada.Rows(i).Cells(n + 1).Value = ">"
                End If
            End If
        Next

        For i = 1 To m
            'Agregar las de holgura
            If dgvEntrada.Rows(i).Cells(n + 1).Value = "<" Then
                holgura(i)

                'agregar las arificiales
            ElseIf dgvEntrada.Rows(i).Cells(n + 1).Value = "=" Then
                agrartificiales(i)

                'agregar las de exceso
            ElseIf dgvEntrada.Rows(i).Cells(n + 1).Value = ">" Then
                'Revisado
                cantCJ += 1
                CJindices(cantCJ) = s

                Matriz(i, s) = -1
                s += 1
                agrartificiales(i)
            End If
        Next

        Nt = s - 1
        'Pasar b a la Matriz
        For i = 1 To m
            Matriz(i, Nt + 1) = b(i)

            'Revisado
            'Construir XB
            XB(i, 1) = b(i)
            bb(i, 1) = b(i)
        Next
        'Pasar los bz a los vectores Z
        ZM(Nt + 1) = bZM
        Z(Nt + 1) = bZ


        'Revisado
        'Construir C
        Dim uno As Integer = -1
        If (cbMaxMin.SelectedIndex = 1) Then uno = 1

        For i = 1 To Nt
            C(1, i) = uno * Z(i)
            CM(1, i) = -1 * uno * CM(1, i)
        Next


        'Si van a minimizar
        If (cbMaxMin.SelectedIndex = 1) Then
            VectorpoEscalar(-1, Z, 0, Nt + 1)
            'VectorpoEscalar(-1, ZM, 0, Nt + 1)
        End If


        If cbMetodo.SelectedIndex = 0 Then
            FGranM = New Gran_M
            FGranM.Show()
        ElseIf cbMetodo.SelectedIndex = 1 Then


            FRevisado = New Revisado
            FRevisado.Show()
        Else
            MsgBox("Necesitas escoger una opcion", MsgBoxStyle.Critical, "Atencion")
        End If

        'Me.Hide()
    End Sub

    Private Sub holgura(ByRef i As Integer)
        basicas(i) = s
        Matriz(i, s) = 1

        'Para el revisado
        CBindices(i) = s

        s += 1
    End Sub

    Private Sub agrartificiales(ByVal i As Integer)
        holgura(i)

        'Para el simplex revisado
        CM(1, s - 1) = 1

        cantArtificiales += 1
        Artificiales(cantArtificiales) = s - 1
        For k = 1 To s - 2
            ZM(k) -= Matriz(i, k)            
        Next
        bZM -= b(i)
    End Sub

    Private Sub dgvEntrada_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntrada.CellEndEdit
        Dim prueba As String
        Dim i As Integer
        prueba = dgvEntrada.CurrentCell.Value
        Try
            i = CInt(prueba)
        Catch ex As Exception
            If Not (prueba = "=" Or prueba = "<" Or prueba = ">") Then
                MsgBox("Datos Invalidos en la celda que acaba de modificar", MsgBoxStyle.Critical, "Simplex")
            End If
        End Try
    End Sub

    Private Sub dgvEntrada_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvEntrada.ColumnWidthChanged
        DGVWidthMinimo(dgvEntrada, 500, 45)
    End Sub

    Private Sub Redimensionar()
        Dim m5 As Integer = m + 5
        Dim n2 As Integer = 2 * n + m + 5
        ReDim Matriz(m5, n2)
        ReDim Z(n2)
        ReDim ZM(n2)
        ReDim Cotas(n + 5)
        ReDim Pares(n + 5, 2)
        ReDim b(m5)
        ReDim Negativos(n + 5, 2)
        ReDim basicas(m5)
        ReDim indicesColumnas(n2)
        ReDim Artificiales(m5)

        ReDim C(3, n2)
        ReDim CM(3, n2)
        ReDim CB(3, n2)
        ReDim CB_M(3, n2)
        ReDim CBindices(n2)
        ReDim CJ(3, n2)
        ReDim CJ_M(3, n2)
        ReDim CJindices(n2)
        ReDim Y(3, n2)
        ReDim Y_M(3, n2)
        ReDim P(m5, n2)
        ReDim Z_CJ(3, n2)
        ReDim Z_CJ_M(3, n2)
        ReDim B_1(m + 3, m + 3)
        ReDim EE(m + 3, m + 3)
        ReDim XB(m5, 3)
        ReDim alfaj(m5, 3)
        ReDim bb(m5, 3)
        ReDim Pj(m5, 3)
        ReDim Identidad(m + 3, m + 3)
    End Sub
End Class
