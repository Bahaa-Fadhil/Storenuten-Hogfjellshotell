<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Valgmuligheter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Valgmuligheter))
        Me.btnBestOpp = New System.Windows.Forms.Button()
        Me.btnAvslutt = New System.Windows.Forms.Button()
        Me.btnRegnskap = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBestOpp
        '
        Me.btnBestOpp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBestOpp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBestOpp.Location = New System.Drawing.Point(597, 237)
        Me.btnBestOpp.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBestOpp.Name = "btnBestOpp"
        Me.btnBestOpp.Size = New System.Drawing.Size(158, 67)
        Me.btnBestOpp.TabIndex = 0
        Me.btnBestOpp.Text = "Bestillinger" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Opphold"
        Me.btnBestOpp.UseVisualStyleBackColor = True
        '
        'btnAvslutt
        '
        Me.btnAvslutt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAvslutt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvslutt.Location = New System.Drawing.Point(597, 392)
        Me.btnAvslutt.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAvslutt.Name = "btnAvslutt"
        Me.btnAvslutt.Size = New System.Drawing.Size(158, 67)
        Me.btnAvslutt.TabIndex = 2
        Me.btnAvslutt.Text = "Avslutt"
        Me.btnAvslutt.UseVisualStyleBackColor = True
        '
        'btnRegnskap
        '
        Me.btnRegnskap.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRegnskap.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegnskap.Location = New System.Drawing.Point(597, 314)
        Me.btnRegnskap.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegnskap.Name = "btnRegnskap"
        Me.btnRegnskap.Size = New System.Drawing.Size(158, 67)
        Me.btnRegnskap.TabIndex = 1
        Me.btnRegnskap.Text = "Regnskap"
        Me.btnRegnskap.UseVisualStyleBackColor = True
        '
        'Valgmuligheter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 737)
        Me.Controls.Add(Me.btnRegnskap)
        Me.Controls.Add(Me.btnAvslutt)
        Me.Controls.Add(Me.btnBestOpp)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Valgmuligheter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valg Meny"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBestOpp As Button
    Friend WithEvents btnAvslutt As Button
    Friend WithEvents btnRegnskap As Button
End Class
