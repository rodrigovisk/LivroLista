using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Livros
    {
        List<Livro> acervo = new List<Livro>();

        public List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            if (this.pesquisar(livro) != null) throw new Exception("Já existe um livro com esse ISBN.");
            this.acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            return this.acervo.FirstOrDefault(item => item.Equals(livro));
        }
    }
}
