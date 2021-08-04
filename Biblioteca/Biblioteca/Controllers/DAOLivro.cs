using Biblioteca.Models;
using System;
using System.IO;

namespace Biblioteca.Controllers {
  public class DAOLivro {



    //C
    public static void CriarLivro(Livro livro) {
      var caminhoArquivo = "livros.txt";
      var arquivo = File.AppendText(caminhoArquivo);
      arquivo.Write($"{livro.Titulo},{livro.Autor},{livro.Editora},{livro.Disponiblidade}\n");
      arquivo.Close();
    }
    //R
    public static void ListarLivros() {
      var caminhoArquivo = "livros.txt";
      using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Open))
      using (var leitor = new StreamReader(fluxoDeArquivo)) {
        while (!leitor.EndOfStream) {
          var linha = leitor.ReadLine();
          var livro = ConverterStringParaLivro(linha);

          var txtDisponivel = "";

          if (livro.Disponiblidade == true) {
            txtDisponivel = "Sim";
          }
          else {
            txtDisponivel = "Não";
          }

          var msg = $"Titulo: {livro.Titulo}\n" +
            $"Autor: {livro.Autor}\n" +
            $"Editora: {livro.Editora}\n" +
            $"Disponível: {txtDisponivel}\n\n";

          Console.WriteLine(msg);
        }
      }
    }
    //U
    //D
    public void RemoverLivro(Livro livro) {

    }

    public static Livro ConverterStringParaLivro(string linha) {
      string[] fields = linha.Split(',');

      var titulo = fields[0];
      var autor = fields[1];
      var editora = fields[2];
      var disponibilidade = Boolean.Parse(fields[3]);

      var livro = new Livro();
      livro.Titulo = titulo;
      livro.Autor = autor;
      livro.Editora = editora;
      livro.Disponiblidade = disponibilidade;

      return livro;

    }

  }
}
