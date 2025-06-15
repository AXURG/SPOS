<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inventario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.dtgv_inventario = New System.Windows.Forms.DataGridView()
        Me.LblUser = New System.Windows.Forms.Label()
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnRegresar
        '
        Me.BtnRegresar.BackColor = System.Drawing.Color.Tomato
        Me.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegresar.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnRegresar.Location = New System.Drawing.Point(20, 598)
        Me.BtnRegresar.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(212, 103)
        Me.BtnRegresar.TabIndex = 2
        Me.BtnRegresar.Text = "REGRESAR"
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'dtgv_inventario
        '
        Me.dtgv_inventario.AllowUserToAddRows = False
        Me.dtgv_inventario.AllowUserToDeleteRows = False
        Me.dtgv_inventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_inventario.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.dtgv_inventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.dtgv_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_inventario.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtgv_inventario.Location = New System.Drawing.Point(264, 80)
        Me.dtgv_inventario.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.dtgv_inventario.Name = "dtgv_inventario"
        Me.dtgv_inventario.ReadOnly = True
        Me.dtgv_inventario.RowHeadersWidth = 51
        Me.dtgv_inventario.Size = New System.Drawing.Size(1242, 1108)
        Me.dtgv_inventario.TabIndex = 3
        '
        'LblUser
        '
        Me.LblUser.CausesValidation = False
        Me.LblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblUser.Location = New System.Drawing.Point(543, 14)
        Me.LblUser.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(468, 45)
        Me.LblUser.TabIndex = 10
        Me.LblUser.Text = "INVENTARIO"
        Me.LblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1548, 1244)
        Me.Controls.Add(Me.LblUser)
        Me.Controls.Add(Me.dtgv_inventario)
        Me.Controls.Add(Me.BtnRegresar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "inventario"
        Me.Text = "inventario"
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents dtgv_inventario As DataGridView
    Friend WithEvents LblUser As Label
End Class
