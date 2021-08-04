namespace ArduinoWithCSharp
{
  partial class Form1
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.btnConectar = new System.Windows.Forms.Button();
      this.cbbPorta = new System.Windows.Forms.ComboBox();
      this.btnLigar = new System.Windows.Forms.Button();
      this.timerCOM = new System.Windows.Forms.Timer(this.components);
      this.serialPort = new System.IO.Ports.SerialPort(this.components);
      this.SuspendLayout();
      // 
      // btnConectar
      // 
      this.btnConectar.Location = new System.Drawing.Point(35, 30);
      this.btnConectar.Name = "btnConectar";
      this.btnConectar.Size = new System.Drawing.Size(75, 23);
      this.btnConectar.TabIndex = 0;
      this.btnConectar.Text = "Conectar";
      this.btnConectar.UseVisualStyleBackColor = true;
      this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
      // 
      // cbbPorta
      // 
      this.cbbPorta.FormattingEnabled = true;
      this.cbbPorta.Location = new System.Drawing.Point(136, 30);
      this.cbbPorta.Name = "cbbPorta";
      this.cbbPorta.Size = new System.Drawing.Size(131, 21);
      this.cbbPorta.TabIndex = 1;
      // 
      // btnLigar
      // 
      this.btnLigar.Location = new System.Drawing.Point(150, 143);
      this.btnLigar.Name = "btnLigar";
      this.btnLigar.Size = new System.Drawing.Size(75, 23);
      this.btnLigar.TabIndex = 2;
      this.btnLigar.Text = "Ligar";
      this.btnLigar.UseVisualStyleBackColor = true;
      this.btnLigar.Click += new System.EventHandler(this.btnEnviar_Click);
      // 
      // timerCOM
      // 
      this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick);
      // 
      // serialPort
      // 
      this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkSlateGray;
      this.ClientSize = new System.Drawing.Size(407, 270);
      this.Controls.Add(this.btnLigar);
      this.Controls.Add(this.cbbPorta);
      this.Controls.Add(this.btnConectar);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnConectar;
    private System.Windows.Forms.ComboBox cbbPorta;
    private System.Windows.Forms.Button btnLigar;
    private System.Windows.Forms.Timer timerCOM;
    private System.IO.Ports.SerialPort serialPort;
  }
}

