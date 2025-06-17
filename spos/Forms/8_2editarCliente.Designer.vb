<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _8_2editarCliente
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
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.txtNuevo = New System.Windows.Forms.TextBox()
        Me.cmbCampo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClientes = New System.Windows.Forms.PictureBox()
        CType(Me.btnClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.DarkOrange
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnActualizar.Location = New System.Drawing.Point(398, 388)
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(220, 47)
        Me.btnActualizar.TabIndex = 30
        Me.btnActualizar.Text = "ACTUALIZAR"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'txtNuevo
        '
        Me.txtNuevo.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevo.Location = New System.Drawing.Point(365, 319)
        Me.txtNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNuevo.Name = "txtNuevo"
        Me.txtNuevo.Size = New System.Drawing.Size(283, 38)
        Me.txtNuevo.TabIndex = 27
        '
        'cmbCampo
        '
        Me.cmbCampo.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCampo.FormattingEnabled = True
        Me.cmbCampo.Items.AddRange(New Object() {"NOMBRE", "DIRECCION", "CORREO", "NUMERO TELEFONICO", "RFC"})
        Me.cmbCampo.Location = New System.Drawing.Point(306, 145)
        Me.cmbCampo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCampo.Name = "cmbCampo"
        Me.cmbCampo.Size = New System.Drawing.Size(391, 39)
        Me.cmbCampo.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(413, 104)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 25)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Campo a Cambiar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(300, 54)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(452, 31)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Actualizar Informacion del Cliente"
        '
        'BtnRegresar
        '
        Me.BtnRegresar.BackColor = System.Drawing.Color.Tomato
        Me.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRegresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnRegresar.Location = New System.Drawing.Point(134, 340)
        Me.BtnRegresar.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(103, 47)
        Me.BtnRegresar.TabIndex = 22
        Me.BtnRegresar.Text = "REGRESAR"
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'lblLog
        '
        Me.lblLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLog.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblLog.Location = New System.Drawing.Point(-3, 216)
        Me.lblLog.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(986, 25)
        Me.lblLog.TabIndex = 31
        Me.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(409, 273)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 25)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Nueva Informacion"
        '
        'btnClientes
        '
        Me.btnClientes.Image = Global.spos.My.Resources.Resources.btnclientes
        Me.btnClientes.Location = New System.Drawing.Point(134, 13)
        Me.btnClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(147, 116)
        Me.btnClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClientes.TabIndex = 33
        Me.btnClientes.TabStop = False
        Me.btnClientes.Tag = ""
        '
        '_8_2editarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(981, 465)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.txtNuevo)
        Me.Controls.Add(Me.cmbCampo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnRegresar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "_8_2editarCliente"
        Me.Text = "_8_2editarCliente"
        CType(Me.btnClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnActualizar As Button
    Friend WithEvents txtNuevo As TextBox
    Friend WithEvents cmbCampo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents lblLog As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnClientes As PictureBox
End Class
