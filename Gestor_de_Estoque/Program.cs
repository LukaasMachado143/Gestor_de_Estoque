using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    internal class Program
    {
        
        static List<IEstoque> produtosExistentes = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            bool fecharPrograma = false;

            CarregarDados();

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
                            ListarDados();
                            break;
                        case Menu.Adicionar:
                            RealizarCadastro();
                            break;
                        case Menu.Remover:
                            RemoverDados();
                            break;
                        case Menu.Entrada:
                            ControleEstoque("ADICIONAR");
                            break;
                        case Menu.Saida:
                            ControleEstoque("RETIRAR");
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

        static void CarregarDados()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtosExistentes = (List<IEstoque>)encoder.Deserialize(stream);
                if (produtosExistentes == null)
                {
                    produtosExistentes = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtosExistentes = new List<IEstoque>();
            }

            stream.Close();
        }

        static void ListarDados()
        {
            int i=0;
            Console.WriteLine("* Lista de Itens *\n");
            foreach (IEstoque produto in produtosExistentes)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine($"-> ID: {i}");
                produto.Exibir();
                i++;
            }
            Console.WriteLine("==========================================\n");
            Console.ReadLine();
            //Console.Clear();
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
            SalvarDados();

            Console.WriteLine("Cadastro Realizado com sucesso");
            Console.ReadLine();
            Console.Clear();
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
            SalvarDados();

            Console.WriteLine("Cadastro Realizado com sucesso");
            Console.ReadLine();
            Console.Clear();
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
            SalvarDados();

            Console.WriteLine("Cadastro Realizado com sucesso");
            Console.ReadLine();
            Console.Clear();
        }
        static void RemoverDados()
        {
            ListarDados();
            Console.WriteLine("-> Informe o ID para remover o Produto: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 || id < produtosExistentes.Count)
            {
                produtosExistentes.RemoveAt(id);
                SalvarDados();
                Console.WriteLine("Remoção realizada com sucesso.");
                Console.ReadLine();
            }
        }
        static void ControleEstoque(string auxAcao)
        {
            ListarDados();
            Console.WriteLine("-> Informe o ID do Produto a ser manipulado: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 || id < produtosExistentes.Count)
            {
                if (auxAcao == "ADICIONAR")
                {
                    produtosExistentes[id].AdicionarEntrada();
                    SalvarDados();
                }
                else if (auxAcao == "RETIRAR")
                {
                    produtosExistentes[id].AdicionarSaida();
                    SalvarDados();
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void SalvarDados()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtosExistentes);

            stream.Close();
        }
    }
}
