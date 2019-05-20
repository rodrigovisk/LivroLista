using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Exemplar
    {
        private int tombo;
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar()
        {
            this.emprestimos = new List<Emprestimo>();
        }

        public Exemplar(int t)
        {
            this.tombo = t;
            this.emprestimos = new List<Emprestimo>();
        }

        public bool emprestar()
        {
            if (this.disponivel())
            {
                this.emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }

            return false;
        }

        public bool devolver()
        {
            if (!this.disponivel())
            {
                this.emprestimos[this.emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {
            if (this.emprestimos.Count > 0)
            {
                if (this.emprestimos[this.emprestimos.Count - 1].DtDevolucao == DateTime.MinValue)
                {
                    return false;
                }
            }
            return true;
        }

        public int qtdeEmprestimos()
        {
            return this.emprestimos.Count;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.tombo == ((Exemplar)obj).Tombo;
            return false;
        }
    }
}
