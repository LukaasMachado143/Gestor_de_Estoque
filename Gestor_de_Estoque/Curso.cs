using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionando vagas DISPONÍVEIS do Curso: {nome}");
            Console.WriteLine("Digite a quantidade a de vagas disponíveis: ");
            int qtd = int.Parse(Console.ReadLine());
            if (qtd <= 0)
            {
                Console.WriteLine("A quantidade digitada é inválida. ");
            }
            else
            {
                vagas += qtd;
                Console.WriteLine("Quantidade de Vagas atualizadza com sucesso");
            }
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionando vagas PREENCHIDAS do Curso: {nome}");
            Console.WriteLine("Digite a quantidade a de vagas preenchidas: ");
            int qtd = int.Parse(Console.ReadLine());
            if (vagas - qtd < 0)
            {
                Console.WriteLine($"Quantidade de vagas excedida, os últimos {vagas - qtd} ficarão para próxima turma.");
                vagas = 0;
            }
            else { vagas -= qtd; }
            vagas -= qtd;
            Console.WriteLine("Quantidade de Vagas atualizadza com sucesso");
        }

        public void Exibir()
        {
            Console.WriteLine($"-> Nome do Produto: {nome}");
            Console.WriteLine($"-> Nome do Autor Produto: {autor}");
            Console.WriteLine($"-> Preço do Produto: {preco}");
            Console.WriteLine($"-> Quantidade de Vagas do Produto: { vagas}");
        }
    }
}
