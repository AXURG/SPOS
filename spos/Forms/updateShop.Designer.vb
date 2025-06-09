<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class updateShop
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
        Me.BtnSesion = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnSesion
        '
        Me.BtnSesion.BackColor = System.Drawing.Color.Tomato
        Me.BtnSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSesion.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnSesion.Location = New System.Drawing.Point(370, 840)
        Me.BtnSesion.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnSesion.Name = "BtnSesion"
        Me.BtnSesion.Size = New System.Drawing.Size(212, 103)
        Me.BtnSesion.TabIndex = 5
        Me.BtnSesion.Text = "REGRESAR"
        Me.BtnSesion.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAgregar.Location = New System.Drawing.Point(1027, 840)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(294, 97)
        Me.btnAgregar.TabIndex = 15
        Me.btnAgregar.Text = "GUARDAR CAMBIOS"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'updateShop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1768, 1010)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.BtnSesion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "updateShop"
        Me.Text = "updateShop"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSesion As Button
    Friend WithEvents btnAgregar As Button
End Class
