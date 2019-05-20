using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        List<Exemplar> exemplares = new List<Exemplar>();

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro()
            : this(0, "", "", "")
        { }

        public Livro(int i) { this.isbn = i; }

        public Livro(int i, string t, string a, string e)
        {
            this.isbn = i;
            this.titulo = t;
            this.autor = a;
            this.editora = e;
            this.exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            foreach (Exemplar exemp in this.exemplares)
                if (exemp.Equals(exemplar)) throw new Exception("Já existe um exemplar com este tombo.");
            this.exemplares.Add(exemplar);


        }

        public int qtdeExemplares()
        {
            return this.exemplares.Count;

        }

        public int qtdeDisponiveis()
        {
            int disponiveis = 0;
            foreach (Exemplar exemp in this.exemplares)
            {
                if (exemp.disponivel())
                    disponiveis++;
            }

            return disponiveis;
        }

        public int qtdeEmprestimos()
        {
            int emprestados = 0;
            foreach (Exemplar exemp in this.exemplares)
            {
                if (exemp.disponivel())
                    emprestados++;
            }

            return emprestados;
        }

        public double percDisponibilidade()
        {
            double exemp = this.qtdeExemplares();
            double disp = this.qtdeDisponiveis();

            if (exemp == 0 || disp == 0)
            {
                return 0.0;
            }
            else
            {
                return (disp / exemp) * 100;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.isbn.Equals(((Livro)obj).isbn);
            return false;
        }

    }
}
