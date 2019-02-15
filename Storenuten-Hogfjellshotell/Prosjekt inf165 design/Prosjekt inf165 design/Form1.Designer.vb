<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBrukernavn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAvslutt = New System.Windows.Forms.Button()
        Me.btnLoginn = New System.Windows.Forms.Button()
        Me.txtPassord = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBrukernavn
        '
        Me.txtBrukernavn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBrukernavn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrukernavn.Location = New System.Drawing.Point(253, 135)
        Me.txtBrukernavn.Name = "txtBrukernavn"
        Me.txtBrukernavn.Size = New System.Drawing.Size(229, 26)
        Me.txtBrukernavn.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Brukernavn:"
        '
        'btnAvslutt
        '
        Me.btnAvslutt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAvslutt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvslutt.Location = New System.Drawing.Point(418, 231)
        Me.btnAvslutt.Name = "btnAvslutt"
        Me.btnAvslutt.Size = New System.Drawing.Size(90, 33)
        Me.btnAvslutt.TabIndex = 6
        Me.btnAvslutt.Text = "Avslutt"
        Me.btnAvslutt.UseVisualStyleBackColor = True
        '
        'btnLoginn
        '
        Me.btnLoginn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLoginn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoginn.Location = New System.Drawing.Point(224, 231)
        Me.btnLoginn.Name = "btnLoginn"
        Me.btnLoginn.Size = New System.Drawing.Size(90, 33)
        Me.btnLoginn.TabIndex = 4
        Me.btnLoginn.Text = "Logg inn"
        Me.btnLoginn.UseVisualStyleBackColor = True
        '
        'txtPassord
        '
        Me.txtPassord.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPassord.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassord.Location = New System.Drawing.Point(253, 163)
        Me.txtPassord.Name = "txtPassord"
        Me.txtPassord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassord.Size = New System.Drawing.Size(229, 26)
        Me.txtPassord.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Passord:"
        '
        'btnClear
        '
        Me.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClear.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(321, 231)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 33)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 362)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtBrukernavn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAvslutt)
        Me.Controls.Add(Me.btnLoginn)
        Me.Controls.Add(Me.txtPassord)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBrukernavn As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAvslutt As Button
    Friend WithEvents btnLoginn As Button
    Friend WithEvents txtPassord As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClear As Button
End Class
