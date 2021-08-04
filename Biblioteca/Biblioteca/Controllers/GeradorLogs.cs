using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Biblioteca.Controllers {
  public class GeradorLogs {
    public static void GravaAcao(string msg, string acao) {
      var caminhoArquivo = "log.txt";
      var arquivo = File.AppendText(caminhoArquivo);
      arquivo.Write($"Ação: {acao} - {msg} - Data: {DateTime.Today}\n");
      arquivo.Close();
      arquivo.Dispose();
    }

    public static void MostrarLog() {
      var Leitor = new StreamReader("log.txt", Encoding.UTF8);
      string[] linhas = Leitor.ReadToEnd().Split('\n');

      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|----- Log's do Sistema ----|");
      Console.WriteLine("*---------------------------*\n");
      foreach (var linha in linhas) {
        Console.WriteLine(linha);
      }
    }
  }
}
