namespace Biblioteca.Models {
  public class Livro {
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public bool Disponiblidade { get; set; }

    public Livro(string titulo, string autor, string editora, bool disponiblididade = true) {
      Titulo = titulo;
      Autor = autor;
      Editora = editora;
      Disponiblidade = disponiblididade;
    }

    public Livro() {
      //Construtor Base
    }

  }
}
