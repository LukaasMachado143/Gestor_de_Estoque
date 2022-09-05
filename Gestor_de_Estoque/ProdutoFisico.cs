using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
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
            
        }

        public void AdicionarSaida()
        {
            
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
