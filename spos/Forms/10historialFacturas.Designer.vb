<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _10historialFacturas
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
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscarRFC = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.btnRegresarConsulta = New System.Windows.Forms.Button()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFacturas
        '
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Location = New System.Drawing.Point(63, 253)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersWidth = 82
        Me.dgvFacturas.RowTemplate.Height = 33
        Me.dgvFacturas.Size = New System.Drawing.Size(1818, 790)
        Me.dgvFacturas.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(570, 102)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 44)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "RFC:"
        '
        'txtBuscarRFC
        '
        Me.txtBuscarRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarRFC.FormattingEnabled = True
        Me.txtBuscarRFC.Location = New System.Drawing.Point(693, 94)
        Me.txtBuscarRFC.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBuscarRFC.Name = "txtBuscarRFC"
        Me.txtBuscarRFC.Size = New System.Drawing.Size(392, 52)
        Me.txtBuscarRFC.TabIndex = 6
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Location = New System.Drawing.Point(1137, 80)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(6)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(294, 91)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.BackColor = System.Drawing.Color.DarkCyan
        Me.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalle.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVerDetalle.Location = New System.Drawing.Point(280, 1097)
        Me.btnVerDetalle.Margin = New System.Windows.Forms.Padding(6)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(212, 103)
        Me.btnVerDetalle.TabIndex = 15
        Me.btnVerDetalle.Text = "VER DETALLES"
        Me.btnVerDetalle.UseVisualStyleBackColor = False
        '
        'btnRegresarConsulta
        '
        Me.btnRegresarConsulta.BackColor = System.Drawing.Color.Tomato
        Me.btnRegresarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegresarConsulta.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresarConsulta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRegresarConsulta.Location = New System.Drawing.Point(1139, 1110)
        Me.btnRegresarConsulta.Margin = New System.Windows.Forms.Padding(6)
        Me.btnRegresarConsulta.Name = "btnRegresarConsulta"
        Me.btnRegresarConsulta.Size = New System.Drawing.Size(212, 103)
        Me.btnRegresarConsulta.TabIndex = 16
        Me.btnRegresarConsulta.Text = "REGRESAR"
        Me.btnRegresarConsulta.UseVisualStyleBackColor = False
        Me.btnRegresarConsulta.Visible = False
        '
        '_10historialFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1939, 1255)
        Me.Controls.Add(Me.btnRegresarConsulta)
        Me.Controls.Add(Me.btnVerDetalle)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBuscarRFC)
        Me.Controls.Add(Me.dgvFacturas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "_10historialFacturas"
        Me.Text = "_10historialFacturas"
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvFacturas As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscarRFC As ComboBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnVerDetalle As Button
    Friend WithEvents btnRegresarConsulta As Button
End Class
