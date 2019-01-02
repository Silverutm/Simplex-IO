<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Revisado
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
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnResolver = New System.Windows.Forms.Button()
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(38, 35)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(75, 23)
        Me.btnSiguiente.TabIndex = 0
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnResolver
        '
        Me.btnResolver.Location = New System.Drawing.Point(38, 87)
        Me.btnResolver.Name = "btnResolver"
        Me.btnResolver.Size = New System.Drawing.Size(75, 23)
        Me.btnResolver.TabIndex = 1
        Me.btnResolver.Text = "Resolver"
        Me.btnResolver.UseVisualStyleBackColor = True
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Location = New System.Drawing.Point(174, 35)
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRespuesta.Size = New System.Drawing.Size(370, 340)
        Me.txtRespuesta.TabIndex = 2
        '
        'Revisado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 440)
        Me.Controls.Add(Me.txtRespuesta)
        Me.Controls.Add(Me.btnResolver)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Name = "Revisado"
        Me.Text = "Revisado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnResolver As Button
    Friend WithEvents txtRespuesta As TextBox
End Class
