using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {
        static Livros livros = new Livros();

        static void Main(string[] args)
        {
            int choice = 0;


            do
            {

                Console.WriteLine("MENU");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)*");
                Console.WriteLine("3. Pesquisar livro (analítico)**");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("\nOPÇÃO: ");
                choice = int.Parse(Console.ReadLine());

                Console.Clear();

                try
                {
                    if (choice == 0)
                    {
                    }
                    else if (choice == 1)
                    {

                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());
                        if (livros.pesquisar(new Livro(isbn)) != null) throw new Exception("Já existe um livro com esse ISBN");

                        Console.Write("Digite o título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Digite o autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Digite a editora: ");
                        string editora = Console.ReadLine();

                        livros.adicionar(new Livro(isbn, titulo, autor, editora));
                        Console.WriteLine("Exemplar cadastrado com sucesso!");
                        Console.ReadKey();


                    }
                    else if (choice == 2)
                    {
                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());
                        Livro livro = livros.pesquisar(new Livro(isbn));
                        if (livro == null) throw new Exception("Livro não encontrado.");

                        Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
                        Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
                        Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
                        Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");

                        Console.ReadKey();
                    }
                    else if (choice == 3)
                    {
                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());
                        Livro livro = livros.pesquisar(new Livro(isbn));
                        if (livro == null) throw new Exception("Livro não encontrado.");

                        Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
                        Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
                        Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
                        Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");

                        livro.Exemplares.ForEach(i => {
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("Tombo: " + i.Tombo);
                            i.Emprestimos.ForEach(j => {
                                String devolucao = (j.DtDevolucao != DateTime.MinValue) ? j.DtDevolucao.ToString() : "-------------------";
                                Console.WriteLine("----------------------------------------------------------");
                                Console.WriteLine("Data Empréstimo: " + j.DtEmprestimo);
                                Console.WriteLine("Data Devolução:  " + devolucao);
                            });
                        });

                        Console.ReadKey();


                    }
                    else if (choice == 4)
                    {
                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());

                        Livro livro = livros.pesquisar(new Livro(isbn));
                        if (livro == null) throw new Exception("Livro não encontrado.");

                        Console.Write("Digite o Tombo: ");
                        int tombo = Int32.Parse(Console.ReadLine());
                        livro.adicionarExemplar(new Exemplar(tombo));
                        Console.WriteLine("Exemplar cadastrado com sucesso!");

                        Console.ReadKey();


                    }
                    else if (choice == 5)
                    {
                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());

                        Livro livro = livros.pesquisar(new Livro(isbn));
                        if (livro == null) throw new Exception("Livro não encontrado.");

                        Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.emprestar());
                        if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " emprestado com sucesso!");
                        else throw new Exception("Não há exemplares disponíveis.");
                        Console.ReadKey();


                    }
                    else if (choice == 6)
                    {
                        Console.Write("\nDigite o ISBN: ");
                        int isbn = Int32.Parse(Console.ReadLine());

                        Livro livro = livros.pesquisar(new Livro(isbn));
                        if (livro == null) throw new Exception("Livro não encontrado.");

                        Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.devolver());
                        if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " devolvido com sucesso!");
                        else Console.WriteLine("Não há exemplares emprestados.");
                        Console.ReadKey();


                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                
                Console.Clear();


            }
            while (choice != 0);
        }
    }
}
