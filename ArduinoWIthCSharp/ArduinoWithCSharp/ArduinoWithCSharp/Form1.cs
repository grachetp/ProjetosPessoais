using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoWithCSharp
{
  public partial class Form1 : Form
  {
    string RxString;
    public Form1()
    {
      InitializeComponent();
      timerCOM.Enabled = true;
    }

    private void atualizaListaCOMs()
    {
      int i;
      bool quantDiferente;    //flag para sinalizar que a quantidade de portas mudou

      i = 0;
      quantDiferente = false;

      //se a quantidade de portas mudou
      if (cbbPorta.Items.Count == SerialPort.GetPortNames().Length)
      {
        foreach (string s in SerialPort.GetPortNames())
        {
          if (cbbPorta.Items[i++].Equals(s) == false)
          {
            quantDiferente = true;
          }
        }
      }
      else
      {
        quantDiferente = true;
      }

      //Se não foi detectado diferença
      if (quantDiferente == false)
      {
        return;                     //retorna
      }

      //limpa comboBox
      cbbPorta.Items.Clear();

      //adiciona todas as COM diponíveis na lista
      foreach (string s in SerialPort.GetPortNames())
      {
        cbbPorta.Items.Add(s);
      }
      //seleciona a primeira posição da lista
      cbbPorta.SelectedIndex = 0;
    }

    private void timerCOM_Tick(object sender, EventArgs e)
    {
      atualizaListaCOMs();
    }

    private void btnConectar_Click(object sender, EventArgs e)
    {
      if (serialPort.IsOpen == false)
      {
        try
        {
          serialPort.PortName = cbbPorta.Items[cbbPorta.SelectedIndex].ToString();
          serialPort.Open();

        }
        catch
        {
          return;

        }
        if (serialPort.IsOpen)
        {
          btnConectar.Text = "Desconectar";
          cbbPorta.Enabled = false;

        }
      }
      else
      {

        try
        {
          serialPort.Close();
          cbbPorta.Enabled = true;
          btnConectar.Text = "Conectar";
        }
        catch
        {
          return;
        }

      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (serialPort.IsOpen == true)  // se porta aberta
        serialPort.Close();            //fecha a porta
    }

    private void btnEnviar_Click(object sender, EventArgs e)
    {
      if (serialPort.IsOpen == true)
      {
        serialPort.Write("A");
        if (btnLigar.Text == "Ligar")
        {
          btnLigar.Text = "Desligar";
        }
        else
        {
          btnLigar.Text = "Ligar";
        }
      }
    }

    private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      RxString = serialPort.ReadExisting();              //le o dado disponível na serial
      this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
    }
    private void trataDadoRecebido(object sender, EventArgs e)
    {
      //txtReceber.AppendText(RxString);
    }
  }
}
