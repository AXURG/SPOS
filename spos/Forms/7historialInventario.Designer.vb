<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _7historialInventario
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
        Me.dtgv_inventario = New System.Windows.Forms.DataGridView()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.LblUser = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dtgv_inventario.Location = New System.Drawing.Point(179, 159)
        Me.dtgv_inventario.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgv_inventario.Name = "dtgv_inventario"
        Me.dtgv_inventario.ReadOnly = True
        Me.dtgv_inventario.RowHeadersWidth = 51
        Me.dtgv_inventario.Size = New System.Drawing.Size(828, 618)
        Me.dtgv_inventario.TabIndex = 5
        '
        'BtnRegresar
        '
        Me.BtnRegresar.BackColor = System.Drawing.Color.Tomato
        Me.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegresar.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnRegresar.Location = New System.Drawing.Point(13, 297)
        Me.BtnRegresar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(141, 66)
        Me.BtnRegresar.TabIndex = 4
        Me.BtnRegresar.Text = "REGRESAR"
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'LblUser
        '
        Me.LblUser.CausesValidation = False
        Me.LblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblUser.Location = New System.Drawing.Point(403, 49)
        Me.LblUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(414, 47)
        Me.LblUser.TabIndex = 11
        Me.LblUser.Text = "REGISTRO INVENTARIO"
        Me.LblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.spos.My.Resources.Resources.reporte
        Me.PictureBox5.Location = New System.Drawing.Point(248, 13)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(147, 116)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Tag = ""
        '
        '_7historialInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 790)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.LblUser)
        Me.Controls.Add(Me.dtgv_inventario)
        Me.Controls.Add(Me.BtnRegresar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "_7historialInventario"
        Me.Text = "_7historialInventario"
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgv_inventario As DataGridView
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents LblUser As Label
    Friend WithEvents PictureBox5 As PictureBox
End Class
