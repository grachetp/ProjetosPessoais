using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca.Controllers {
  class DAOFuncionario {

    static List<Funcionario> contas;

    public static void CriarFuncionario(Funcionario func) {
      var caminhoArquivo = "contas.txt";
      var arquivo = File.AppendText(caminhoArquivo);
      arquivo.Write($"\n{func.Username},{func.Password}");
      arquivo.Close();
    }


    public static void ListarUsuarios() {
      var contas = ListFuncionarios();
      foreach (var conta in contas) {
        Console.WriteLine($"Usuário: {conta.Username}");
      }
    }

    //method to login of user
    public static void Login() {
      var Leitor = new StreamReader("contas.txt", Encoding.Default);
      string[] linhas = Leitor.ReadToEnd().Split('\n');

      foreach (var linha in linhas) {
        Console.WriteLine(linha);
      }
    }


    //List using for autenticação
    public static List<Funcionario> ListFuncionarios() {
      var caminhoArquivo = "contas.txt";
      contas = new List<Funcionario>();
      using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Open))
      using (var leitor = new StreamReader(fluxoDeArquivo)) {
        while (!leitor.EndOfStream) {
          var linha = leitor.ReadLine();
          var func = ConverterStringParaFuncionario(linha);
          contas.Add(func);
        }
        return contas;
      }
    }


    public static Funcionario ConverterStringParaFuncionario(string linha) {
      string[] fields = linha.Split(',');

      var username = fields[0];
      var senha = fields[1];

      var func = new Funcionario();
      func.Username = username;
      func.Password = senha;

      return func;
    }
  }
}
