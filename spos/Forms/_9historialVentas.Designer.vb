<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class historialFacturas
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
        Me.dtgv_ventas = New System.Windows.Forms.DataGridView()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.LblUser = New System.Windows.Forms.Label()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.btnRegresarConsulta = New System.Windows.Forms.Button()
        Me.BtnSellNew = New System.Windows.Forms.PictureBox()
        CType(Me.dtgv_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSellNew, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgv_ventas
        '
        Me.dtgv_ventas.AllowUserToAddRows = False
        Me.dtgv_ventas.AllowUserToDeleteRows = False
        Me.dtgv_ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_ventas.Location = New System.Drawing.Point(159, 49)
        Me.dtgv_ventas.Name = "dtgv_ventas"
        Me.dtgv_ventas.ReadOnly = True
        Me.dtgv_ventas.RowHeadersWidth = 51
        Me.dtgv_ventas.Size = New System.Drawing.Size(863, 569)
        Me.dtgv_ventas.TabIndex = 5
        '
        'BtnRegresar
        '
        Me.BtnRegresar.BackColor = System.Drawing.Color.Tomato
        Me.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegresar.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnRegresar.Location = New System.Drawing.Point(20, 211)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(106, 54)
        Me.BtnRegresar.TabIndex = 4
        Me.BtnRegresar.Text = "REGRESAR"
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'LblUser
        '
        Me.LblUser.CausesValidation = False
        Me.LblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblUser.Location = New System.Drawing.Point(171, 15)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(767, 20)
        Me.LblUser.TabIndex = 6
        Me.LblUser.Text = "SELECCIONE LA VENTA DE LA CUAL REQUIERE MAS DETALLES"
        Me.LblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnVerDetalles
        '
        Me.btnVerDetalles.BackColor = System.Drawing.Color.DarkCyan
        Me.btnVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalles.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDetalles.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVerDetalles.Location = New System.Drawing.Point(20, 295)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(106, 54)
        Me.btnVerDetalles.TabIndex = 7
        Me.btnVerDetalles.Text = "VER DETALLES"
        Me.btnVerDetalles.UseVisualStyleBackColor = False
        '
        'btnRegresarConsulta
        '
        Me.btnRegresarConsulta.BackColor = System.Drawing.Color.Tomato
        Me.btnRegresarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegresarConsulta.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresarConsulta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRegresarConsulta.Location = New System.Drawing.Point(20, 211)
        Me.btnRegresarConsulta.Name = "btnRegresarConsulta"
        Me.btnRegresarConsulta.Size = New System.Drawing.Size(106, 54)
        Me.btnRegresarConsulta.TabIndex = 8
        Me.btnRegresarConsulta.Text = "REGRESAR"
        Me.btnRegresarConsulta.UseVisualStyleBackColor = False
        Me.btnRegresarConsulta.Visible = False
        '
        'BtnSellNew
        '
        Me.BtnSellNew.Image = Global.spos.My.Resources.Resources.ingresara
        Me.BtnSellNew.Location = New System.Drawing.Point(20, 75)
        Me.BtnSellNew.Name = "BtnSellNew"
        Me.BtnSellNew.Size = New System.Drawing.Size(110, 94)
        Me.BtnSellNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnSellNew.TabIndex = 9
        Me.BtnSellNew.TabStop = False
        Me.BtnSellNew.Tag = ""
        '
        'historialFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1049, 640)
        Me.Controls.Add(Me.BtnSellNew)
        Me.Controls.Add(Me.btnRegresarConsulta)
        Me.Controls.Add(Me.btnVerDetalles)
        Me.Controls.Add(Me.LblUser)
        Me.Controls.Add(Me.dtgv_ventas)
        Me.Controls.Add(Me.BtnRegresar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "historialFacturas"
        Me.Text = "Historial de Ventas"
        CType(Me.dtgv_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSellNew, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgv_ventas As DataGridView
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents LblUser As Label
    Friend WithEvents btnVerDetalles As Button
    Friend WithEvents btnRegresarConsulta As Button
    Friend WithEvents BtnSellNew As PictureBox
End Class
