using Biblioteca.Models;
using System.Collections.Generic;

namespace Biblioteca.Controllers {
  public static class AutenticacaoHelper {

    public static int AutenticarUsuario(string usuario, string senhaTentativa) {
      var listaFuncionarios = new List<Funcionario>();
      listaFuncionarios = DAOFuncionario.ListFuncionarios();
      foreach (var funcionario in listaFuncionarios) {
        if (funcionario.Username == usuario && funcionario.Password == senhaTentativa) {
          return 1;
        }
      }
      return 0;
    }
  }
}
