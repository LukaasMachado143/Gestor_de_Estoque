using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionando estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade a ser inserida no estoque: ");
            int qtd = int.Parse(Console.ReadLine());
            if (qtd <= 0 )
            {
                Console.WriteLine("A quantidade digitada é inválida. ");
            }
            else 
            {
                estoque += qtd;
                Console.WriteLine("Estoque atualizado com sucesso");
            }
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Retirando estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade a ser retirada do estoque: ");
            int qtd = int.Parse(Console.ReadLine());
            if (estoque - qtd < 0)
            {
                Console.WriteLine($"Quantidade em estoque é menor do que o solicitado, {estoque - qtd} ficarão para próxima venda.");
                estoque = 0;
            }
            else { estoque -= qtd; }
            Console.WriteLine("Estoque atualizado com sucesso");
        }

        public void Exibir()
        {
            Console.WriteLine($"-> Nome do Produto: {nome}");
            Console.WriteLine($"-> Preço do Produto: {preco}");
            Console.WriteLine($"-> Valor do Frete do Produto: {frete}");
            Console.WriteLine($"-> Quantidade em Estoque do Produto: {estoque}");
        }
    }
}
