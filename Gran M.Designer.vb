<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gran_M
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
        Me.dgvRespuesta = New System.Windows.Forms.DataGridView()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnResolver = New System.Windows.Forms.Button()
        CType(Me.dgvRespuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRespuesta
        '
        Me.dgvRespuesta.AllowUserToAddRows = False
        Me.dgvRespuesta.AllowUserToDeleteRows = False
        Me.dgvRespuesta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRespuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRespuesta.Location = New System.Drawing.Point(49, 48)
        Me.dgvRespuesta.Name = "dgvRespuesta"
        Me.dgvRespuesta.ReadOnly = True
        Me.dgvRespuesta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvRespuesta.Size = New System.Drawing.Size(501, 252)
        Me.dgvRespuesta.TabIndex = 0
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(588, 96)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(75, 38)
        Me.btnSiguiente.TabIndex = 1
        Me.btnSiguiente.Text = "Siguiente Iteracion"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnResolver
        '
        Me.btnResolver.Location = New System.Drawing.Point(588, 171)
        Me.btnResolver.Name = "btnResolver"
        Me.btnResolver.Size = New System.Drawing.Size(75, 23)
        Me.btnResolver.TabIndex = 2
        Me.btnResolver.Text = "Resolver"
        Me.btnResolver.UseVisualStyleBackColor = True
        '
        'Gran_M
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 398)
        Me.Controls.Add(Me.btnResolver)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.dgvRespuesta)
        Me.Name = "Gran_M"
        Me.Text = "Simplex- Gran M"
        CType(Me.dgvRespuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvRespuesta As System.Windows.Forms.DataGridView
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnResolver As Button
End Class
