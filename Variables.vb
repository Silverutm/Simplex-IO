Module Variables
    Public n As Integer 'Numero de variables
    Public m As Integer 'Numero de restricciones

    Public Matriz As Double(,) 'Matriz del simplex
    Public Z As Double()
    Public ZM As Double()   'Guarda los valores de M grande en Z
    Public Pares As Integer(,)  'Las variables sin cota
    Public cantPares As Integer
    Public Artificiales As Integer()    'Las variables artificiales
    Public cantArtificiales As Integer
    Public b As Double()    'El vector provisional b; Ax=b
    Public Cotas As Double()    'Donde guardo Xi>=a
    Public Negativos As Double(,)   'Las variables cuya cota a<0
    Public cantNegativos As Integer
    Public basicas As Integer() 'Las variables basicas al solucionar simplex
    Public indicesColumnas As Integer() 'No sirve (i)=i

    Public s As Integer     'Siguiente variable, cuando se esta estandarizando
    Public Nt As Integer    'Final total de variables
    Public bZ As Double     'El valor de b en el renglo Z
    Public bZM As Double    'El valor de M grande de b en el renglon Z

    Public ColumnaPivote As Integer 'Se utiliza para variable entrante
    Public RenglonPivote As Integer 'Para saber que variable sale

    Public FGranM As New Gran_M 'Nueva form
    Public Finicio As FMenu
    Public FRevisado As New Revisado
End Module
