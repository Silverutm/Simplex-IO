Module Funciones
    'Pasa el intervalo de elementos de un gv a  una matriz
    Public Sub DGVaMatriz(ByVal dgv As DataGridView, ByRef MatrizTemp As Double(,), ByVal irg As Integer, ByVal frg As Integer, ByVal icg As Integer, ByVal fcg As Integer, ByVal im As Integer, ByVal jm As Integer)
        '                                                                           irg inicio del renglon del grid         icg inicio de la columna del grid       im inicio renglong matriz jm inicio columna matriz
        Dim i, j, comodin As Integer
        comodin = jm
        For i = irg To frg
            jm = comodin
            For j = icg To fcg
                MatrizTemp(im, jm) = dgv.Rows(i).Cells(j).Value
                jm += 1
            Next
            im += 1
        Next
    End Sub

    'Pasa un reglon/columna de un datagrid view a un vector
    Public Sub DGVaVector(ByVal dgv As DataGridView, ByRef VectorTemp As Double(), ByVal irg As Integer, ByVal frg As Integer, ByVal icg As Integer, ByVal fcg As Integer, ByVal im As Integer)
        'Los parametros son identicos a los de la funcion de DGVaMatriz
        Dim i, j As Integer
        For i = irg To frg
            For j = icg To fcg
                VectorTemp(im) = dgv.Rows(i).Cells(j).Value
                im += 1
            Next
        Next
    End Sub

    'Multiplicar Matriz por escalar
    Public Sub MatrizporEscalar(ByVal e As Double, ByRef MatrizTemp As Double(,), ByVal im As Integer, ByVal ifm As Integer, ByVal jm As Integer, ByVal jfm As Integer)
        '                           e escalar                                       renglon inicial         renglon final       columna inicial         columna final
        Dim i, j As Integer
        For i = im To ifm
            For j = jm To jfm
                MatrizTemp(i, j) *= e
            Next
        Next
    End Sub

    'Multiplicar vector por escalar
    Public Sub VectorpoEscalar(ByVal e As Double, ByRef VectorTemp As Double(), ByVal im As Integer, ByVal ifm As Integer)
        'Los parametros son identicos a la funcion MatrizporEscalar
        Dim i As Integer
        For i = im To ifm
            VectorTemp(i) *= e
        Next
    End Sub

    'Mete los datos de una matriz a un datagridview
    Public Sub MatrizaDGV(ByRef dgv As DataGridView, ByVal MatrizTemp As Double(,), ByVal irg As Integer, ByVal frg As Integer, ByVal icg As Integer, ByVal fcg As Integer, ByVal im As Integer, ByVal jm As Integer)
        '                                                                       irg inicio del renglon de M                 icg inicio de la columna del M              im inicio renglong dgv  jm inicio columna dgv
        Dim i, j, comodin As Integer
        comodin = jm
        For i = irg To frg
            jm = comodin
            For j = icg To fcg
                dgv.Rows(im).Cells(jm).Value = MatrizTemp(i, j)
                jm += 1
            Next
            im += 1
        Next
    End Sub

    'Seam r1 y r2 renglones de una matriz.. r1 += r2
    Public Sub SumarRenglonesR1(ByRef MatrizTemp, ByVal r1, ByVal r2, ByVal im, ByVal fm)
        Dim c As Integer
        For c = im To fm
            MatrizTemp(r1, c) += MatrizTemp(r2, c)
        Next
    End Sub

    'Sea el renglon Z del simplex Z += r1
    Public Sub SumarZ(ByRef ZTemp As Double(), ByVal MatrizTemp(,) As Double, ByVal r2 As Integer)
        Dim pivote As Double
        pivote = -ZTemp(ColumnaPivote)
        If pivote = 0 Then Exit Sub
        MatrizporEscalar(pivote, Matriz, RenglonPivote, RenglonPivote, 0, Nt + 1)

        Dim c As Integer
        For c = 0 To Nt + 1
            ZTemp(c) += Matriz(RenglonPivote, c)
        Next

        MatrizporEscalar(1 / pivote, Matriz, RenglonPivote, RenglonPivote, 0, Nt + 1)
    End Sub

    'Devuelve el minimo de dos numeros
    Public Function Minimo(ByVal i As Integer, ByVal j As Integer) As Integer
        If i > j Then Return j
        Return i
    End Function

    'Width minimo de un dgv
    Public Sub DGVWidthMinimo(ByRef dgv As DataGridView, ByVal limite As Integer, ByVal total As Integer)
        'Para que se vea bonito
        Dim i As Integer
        For i = 0 To dgv.ColumnCount - 1
            total += dgv.Columns(i).Width
        Next
        dgv.Width = Minimo(limite, total)
    End Sub
End Module
