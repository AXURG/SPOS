<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _8historialClientes
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
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.dtgv_inventario = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.LblUser = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.PictureBox()
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnVerDetalles
        '
        Me.btnVerDetalles.BackColor = System.Drawing.Color.DarkCyan
        Me.btnVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalles.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDetalles.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVerDetalles.Location = New System.Drawing.Point(25, 502)
        Me.btnVerDetalles.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(141, 104)
        Me.btnVerDetalles.TabIndex = 11
        Me.btnVerDetalles.Text = "AGREGAR NUEVO CLIENTE"
        Me.btnVerDetalles.UseVisualStyleBackColor = False
        '
        'dtgv_inventario
        '
        Me.dtgv_inventario.AllowUserToAddRows = False
        Me.dtgv_inventario.AllowUserToDeleteRows = False
        Me.dtgv_inventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_inventario.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.dtgv_inventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.dtgv_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_inventario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column3})
        Me.dtgv_inventario.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtgv_inventario.Location = New System.Drawing.Point(188, 53)
        Me.dtgv_inventario.Margin = New System.Windows.Forms.Padding(4)
        Me.dtgv_inventario.Name = "dtgv_inventario"
        Me.dtgv_inventario.ReadOnly = True
        Me.dtgv_inventario.RowHeadersWidth = 51
        Me.dtgv_inventario.Size = New System.Drawing.Size(828, 709)
        Me.dtgv_inventario.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID CLIENTE"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "NOMBRE CLIENTE"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "RFC"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "CORREO"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'BtnRegresar
        '
        Me.BtnRegresar.BackColor = System.Drawing.Color.Tomato
        Me.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegresar.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnRegresar.Location = New System.Drawing.Point(25, 295)
        Me.BtnRegresar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(141, 66)
        Me.BtnRegresar.TabIndex = 9
        Me.BtnRegresar.Text = "REGRESAR"
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'LblUser
        '
        Me.LblUser.CausesValidation = False
        Me.LblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblUser.Location = New System.Drawing.Point(423, 20)
        Me.LblUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(312, 29)
        Me.LblUser.TabIndex = 12
        Me.LblUser.Text = "HISTORIAL CLIENTES"
        Me.LblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAgregar.Location = New System.Drawing.Point(25, 406)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(141, 47)
        Me.btnAgregar.TabIndex = 22
        Me.btnAgregar.Text = "EDITAR"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnClientes
        '
        Me.btnClientes.Image = Global.spos.My.Resources.Resources.btnclientes
        Me.btnClientes.Location = New System.Drawing.Point(25, 135)
        Me.btnClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(147, 116)
        Me.btnClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClientes.TabIndex = 23
        Me.btnClientes.TabStop = False
        Me.btnClientes.Tag = ""
        '
        '_8historialClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1045, 785)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.LblUser)
        Me.Controls.Add(Me.btnVerDetalles)
        Me.Controls.Add(Me.dtgv_inventario)
        Me.Controls.Add(Me.BtnRegresar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "_8historialClientes"
        Me.Text = "_8historialClientes"
        CType(Me.dtgv_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVerDetalles As Button
    Friend WithEvents dtgv_inventario As DataGridView
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents LblUser As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnClientes As PictureBox
End Class
