using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    internal class Program
    {

        static List<IEstoque> produtosExistentes = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            bool fecharPrograma = false;
            Console.WriteLine("Gestor de Estoque CMD com C#\n");
            while (fecharPrograma == false)
            {
                Console.WriteLine("-> Opções disponíveis:");
                Console.WriteLine("1 -> Listar Produtos");
                Console.WriteLine("2 -> Adicionar Produtos");
                Console.WriteLine("3 -> Remover Produtos");
                Console.WriteLine("4 -> Registrar Entrada de Produtos");
                Console.WriteLine("5 -> Registrar Saída de Produtos");
                Console.WriteLine("6 -> Encerrar o Programa");

                int opEscolhida = int.Parse(Console.ReadLine());
                if (opEscolhida > 0 && opEscolhida < 7)
                {
                    Menu tipoOpcao = (Menu)opEscolhida;
                    Console.Clear();
                    switch (tipoOpcao)
                    {
                        case Menu.Listar:
                            break;
                        case Menu.Adicionar:
                            RealizarCadastro();
                            break;
                        case Menu.Remover:
                            break;
                        case Menu.Entrada:
                            break;
                        case Menu.Saida:
                            break;
                        case Menu.Sair:
                            Console.WriteLine("Programa encerrado com sucesso.\nPressione ENTER para fechar a tela.");
                            Console.ReadLine();
                            fecharPrograma = true;
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("A opção escolhida é inválida.\nPressione ENTER para encerrar o programa.");
                    Console.ReadLine();
                    fecharPrograma = true;
                }
            }
        }

        static void RealizarCadastro()
        {
            Console.WriteLine("Cadastro de Produtos selecionado\n");
            Console.WriteLine("-> Opções disponíveis para cadastro:");
            Console.WriteLine("1 -> Produto Físico");
            Console.WriteLine("2 -> E-book");
            Console.WriteLine("3 -> Curso");

            int opEscolhida = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opEscolhida)
            {
                case 1:
                    Console.WriteLine("-> Cadastro de Produto Físico selecionado:");
                    CadastroProdutoFisico();
                    break;
                case 2:
                    Console.WriteLine("-> Cadastro de Ebook selecionado:");
                    CadastroEBook();
                    break;
                case 3:
                    Console.WriteLine("-> Cadastro de Curso selecionado:");
                    CadastroCurso();
                    break;
            }
        }
        static void CadastroProdutoFisico()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtosExistentes.Add(pf);

            Console.WriteLine("Cadastro Realizado com sucesso");
        }

        static void CadastroEBook()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            

            Ebook eb = new Ebook(nome, preco, autor);
            produtosExistentes.Add(eb);

            Console.WriteLine("Cadastro Realizado com sucesso");
        }

        static void CadastroCurso()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());


            Curso cs = new Curso(nome, preco, autor);
            produtosExistentes.Add(cs);

            Console.WriteLine("Cadastro Realizado com sucesso");
        }
    }
}
