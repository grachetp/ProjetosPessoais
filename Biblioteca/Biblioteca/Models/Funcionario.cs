using System;

namespace Biblioteca.Models {
  public class Funcionario {
    public string Username { get; set; }
    public string Password { get; set; }


    public Funcionario(string username, string password) {
      Username = username;
      Password = password;
      Console.WriteLine("Funcionario Criado");
    }

    public Funcionario() {

    }
  }
}
