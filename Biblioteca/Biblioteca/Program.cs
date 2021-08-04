using Biblioteca.Controllers;
using Biblioteca.Models;
using System;
using System.IO;

namespace Biblioteca {
  class Program {
    static void Main(string[] args) {
      Inicializar();
      MenuPrincipal();


    }

    static void MenuPrincipal() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|   1 - Acessar o Sistema   |");
      Console.WriteLine("|   2 - Listar os Livros    |");
      Console.WriteLine("|   3 - Sair do App         |");
      Console.WriteLine("*---------------------------*");
      Console.Write(" Digite sua opção: ");
      var opcao = Console.ReadLine();
      switch (opcao) {
        case "1":
          Console.Clear();
          Login();
          //MenuInterno -> MenuLivros -> Cadastrar Livros
          break;
        case "2":
          Console.Clear();
          MenuListarLivroPublico();
          break;
        case "3":
          Console.WriteLine("\n\nObrigado por utilizar o sistema." +
            " Saindo em 3 segundos");
          System.Threading.Thread.Sleep(3000);
          break;
        default:
          Console.WriteLine("Valor Inválido. Tente novamente: ");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuPrincipal();
          break;
      }
    }


    static void Login() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|           Login           |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Digite seu usuário: ");
      var login = Console.ReadLine();
      Console.Write("Digite sua senha: ");
      var senhaTentativa = Console.ReadLine();
      var autenticado = AutenticacaoHelper.AutenticarUsuario(login, senhaTentativa);
      if (autenticado == 1) {
        GeradorLogs.GravaAcao($"{login}","Login");
        Console.Clear();
        MenuInterno();
      }
      else {
        Console.WriteLine("\nSenha ou usuário incorretos!\nTente novamente!");
        GeradorLogs.GravaAcao($"{login}", "Tentativa de Login");
        System.Threading.Thread.Sleep(3000);
        Console.Clear();
        Login();
      }
    }

    private static void MenuInterno() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|       1 - Livros          |");
      Console.WriteLine("|       2 - Usuarios        |");
      Console.WriteLine("|       3 - Logs            |");
      Console.WriteLine("|       4 - Logoff          |");
      Console.WriteLine("*---------------------------*");
      Console.Write(" Digite sua opção: ");
      var opcao = Console.ReadLine();
      switch (opcao) {
        case "1":
          Console.Clear();
          MenuLivro();
          break;
        case "2":
          Console.Clear();
          MenuUsuario();
          break;
        case "3":
          Console.Clear();
          GeradorLogs.MostrarLog();
          Console.Write("\nAperte qualquer tecla para voltar.");
          Console.Read();
          Console.Clear();
          MenuInterno();

          break;

        case "4":
          Console.WriteLine("\n\nObrigado por utilizar o sistema." +
            " Saindo...");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuPrincipal();
          break;
        default:
          Console.WriteLine("Valor Inválido. Tente novamente: ");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuPrincipal();
          break;
      }
    }


    static void MenuLivro() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|   1 - Cadastrar Livros    |");
      Console.WriteLine("|   2 - Listar Livros       |");
      Console.WriteLine("|   3 - Voltar ao Menu      |");
      Console.WriteLine("*---------------------------*");
      Console.Write(" Digite sua opção: ");
      var opcao = Console.ReadLine();
      switch (opcao) {
        case "1":
          Console.Clear();
          MenuCadastrarLivro();
          break;

        case "2":
          Console.Clear();
          MenuListarLivroInterno();
          break;

        case "3":
          Console.Clear();
          MenuInterno();
          break;

        default:
          Console.WriteLine("Valor Inválido. Tente novamente: ");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuLivro();
          break;
      }
    }



    static void MenuCadastrarLivro() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|      Cadastro Livros      |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Titulo: ");
      var titulo = Console.ReadLine();
      Console.Write("Autor: ");
      var autor = Console.ReadLine();
      Console.Write("Editora: ");
      var editora = Console.ReadLine();
      Livro livro = new Livro(titulo, autor, editora);
      DAOLivro.CriarLivro(livro);
      Console.WriteLine("Livro cadastrado com sucesso!");
      GeradorLogs.GravaAcao($"{titulo}", "Cadastro de Livro");
      System.Threading.Thread.Sleep(1000);
      Console.Clear();
      MenuLivro();
    }

    //método interno para menu
    static void MenuListarLivroInterno() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|    Listagem de Livros     |");
      Console.WriteLine("*---------------------------*\n");
      DAOLivro.ListarLivros();
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|1 - Voltar ao Menu Anterior|");
      Console.WriteLine("|      2 - Sair do App      |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Digite sua opção: ");
      var opcao = Console.ReadLine();

      switch (opcao) {
        case "1":
          Console.Clear();
          MenuLivro();
          break;
        case "2":
          Console.WriteLine("\n\nObrigado por utilizar o sistema." +
            " Saindo em 3 segundos");
          System.Threading.Thread.Sleep(3000);
          System.Environment.Exit(1);
          break;
        default:
          Console.WriteLine("Opção Inválida. Tente Novamente!");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuListarLivroInterno();
          break;
      }

    }

    static void MenuListarLivroPublico() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|    Listagem de Livros     |");
      Console.WriteLine("*---------------------------*\n");
      DAOLivro.ListarLivros();
      MenuEscolhaOpcaoLivroListagem();
    }

    static void MenuEscolhaOpcaoLivroListagem() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|1 - Voltar ao Menu Anterior|");
      Console.WriteLine("|      2 - Sair do App      |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Digite sua opção: ");
      var opcao = Console.ReadLine();

      switch (opcao) {
        case "1":
          Console.Clear();
          MenuPrincipal();
          break;
        case "2":
          Console.WriteLine("\n\nObrigado por utilizar o sistema." +
            " Saindo em 3 segundos");
          System.Threading.Thread.Sleep(3000);
          System.Environment.Exit(1);
          break;
        default:
          Console.WriteLine("Opção Inválida. Tente Novamente!");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuEscolhaOpcaoLivroListagem();
          break;
      }
    }


    //USUARIO
    static void MenuUsuario() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|   1 - Cadastrar Usuario   |");
      Console.WriteLine("|   2 - Listar Usuarios     |");
      //Console.WriteLine("|   3 - Remover {teste}     |");
      Console.WriteLine("|   3 - Voltar ao Menu      |");
      Console.WriteLine("*---------------------------*");
      Console.Write(" Digite sua opção: ");
      var opcao = Console.ReadLine();
      switch (opcao) {
        case "1":
          Console.Clear();
          MenuCadastrarUsuario();
          break;
        case "2":
          Console.Clear();
          MenuListarUsuarios();
          break;

        case "3":
          Console.Clear();
          MenuInterno();
          break;

        default:
          Console.WriteLine("Opção Inválida. Tente Novamente!");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuUsuario();
          break;
      }
    }

    static void MenuCadastrarUsuario() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|      Cadastro Usuario     |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Username: ");
      var username = Console.ReadLine();
      Console.Write("Senha: ");
      var senha = Console.ReadLine();
      var func = new Funcionario(username, senha);
      DAOFuncionario.CriarFuncionario(func);
      Console.WriteLine("\nUsuário cadastrado com sucesso!");
      GeradorLogs.GravaAcao($"{username}", "Cadastro de Usuario");
      System.Threading.Thread.Sleep(3000);
      Console.Clear();
      MenuUsuario();
    }

    static void MenuListarUsuarios() {
      Console.WriteLine("*---------------------------*");
      Console.WriteLine("|---- Biblioteca Online ----|");
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("|    Listagem de Usuarios   |");
      Console.WriteLine("*---------------------------*\n");
      DAOFuncionario.ListarUsuarios();
      Console.WriteLine("\n*---------------------------*");
      Console.WriteLine("|1 - Voltar ao Menu Anterior|");
      Console.WriteLine("|      2 - Sair do App      |");
      Console.WriteLine("*---------------------------*");
      Console.Write("Digite sua opção: ");
      var opcao = Console.ReadLine();

      switch (opcao) {
        case "1":
          Console.Clear();
          MenuUsuario();
          break;
        case "2":
          Console.WriteLine("\n\nObrigado por utilizar o sistema." +
            " Saindo em 3 segundos");
          System.Threading.Thread.Sleep(3000);
          System.Environment.Exit(1);
          break;
        default:
          Console.WriteLine("Opção Inválida. Tente Novamente!");
          System.Threading.Thread.Sleep(3000);
          Console.Clear();
          MenuListarLivroInterno();
          break;
      }
    }

    static void Inicializar() {
      if (!File.Exists("livros.txt")) {
        File.Create("livros.txt").Dispose();
      }
      if (!File.Exists("log.txt")) {
        File.Create("log.txt").Dispose(); ;
      }
      if (!File.Exists("contas.txt")) {
        var arquivo = File.AppendText("contas.txt");
        arquivo.Write($"partner,2010#@");
        arquivo.Close();
      }
    }
  }
}