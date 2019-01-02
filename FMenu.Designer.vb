<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbMaxMin = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudVariables = New System.Windows.Forms.NumericUpDown()
        Me.nudRestricciones = New System.Windows.Forms.NumericUpDown()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.cbMetodo = New System.Windows.Forms.ComboBox()
        Me.dgvEntrada = New System.Windows.Forms.DataGridView()
        CType(Me.nudVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRestricciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbMaxMin
        '
        Me.cbMaxMin.FormattingEnabled = True
        Me.cbMaxMin.Items.AddRange(New Object() {"Maximizar", "Minimizar"})
        Me.cbMaxMin.Location = New System.Drawing.Point(184, 58)
        Me.cbMaxMin.Name = "cbMaxMin"
        Me.cbMaxMin.Size = New System.Drawing.Size(121, 21)
        Me.cbMaxMin.TabIndex = 0
        Me.cbMaxMin.Text = "Max-Min"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero de Variables"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numero de Restricciones"
        '
        'nudVariables
        '
        Me.nudVariables.Location = New System.Drawing.Point(205, 136)
        Me.nudVariables.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudVariables.Name = "nudVariables"
        Me.nudVariables.Size = New System.Drawing.Size(120, 20)
        Me.nudVariables.TabIndex = 3
        Me.nudVariables.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudRestricciones
        '
        Me.nudRestricciones.Location = New System.Drawing.Point(205, 167)
        Me.nudRestricciones.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudRestricciones.Name = "nudRestricciones"
        Me.nudRestricciones.Size = New System.Drawing.Size(120, 20)
        Me.nudRestricciones.TabIndex = 4
        Me.nudRestricciones.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(548, 440)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(75, 23)
        Me.btnSiguiente.TabIndex = 5
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'cbMetodo
        '
        Me.cbMetodo.FormattingEnabled = True
        Me.cbMetodo.Items.AddRange(New Object() {"Gran M", "Simplex Revisado"})
        Me.cbMetodo.Location = New System.Drawing.Point(184, 86)
        Me.cbMetodo.Name = "cbMetodo"
        Me.cbMetodo.Size = New System.Drawing.Size(121, 21)
        Me.cbMetodo.TabIndex = 6
        Me.cbMetodo.Text = "Metodo"
        '
        'dgvEntrada
        '
        Me.dgvEntrada.AllowUserToAddRows = False
        Me.dgvEntrada.AllowUserToDeleteRows = False
        Me.dgvEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntrada.Location = New System.Drawing.Point(98, 210)
        Me.dgvEntrada.Name = "dgvEntrada"
        Me.dgvEntrada.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvEntrada.Size = New System.Drawing.Size(494, 183)
        Me.dgvEntrada.TabIndex = 7
        '
        'FMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 491)
        Me.Controls.Add(Me.dgvEntrada)
        Me.Controls.Add(Me.cbMetodo)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.nudRestricciones)
        Me.Controls.Add(Me.nudVariables)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbMaxMin)
        Me.Name = "FMenu"
        Me.Text = "Simplex-Menu"
        CType(Me.nudVariables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRestricciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbMaxMin As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudVariables As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudRestricciones As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents cbMetodo As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEntrada As System.Windows.Forms.DataGridView

End Class
