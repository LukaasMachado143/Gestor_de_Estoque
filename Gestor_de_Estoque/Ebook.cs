using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class Ebook: Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Um produto E-book possui quantidade infinita por ser um produto digital !");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionando vendas do E-book: {nome}");
            Console.WriteLine("Digite a quantidade de vendas realizadas: ");
            int qtd = int.Parse(Console.ReadLine());
            vendas += qtd;
            Console.WriteLine("Quantidade de vendas atualizada com sucesso!");
        }

        public void Exibir()
        {
            Console.WriteLine($"-> Nome do Produto: {nome}");
            Console.WriteLine($"-> Nome do Autor Produto: {autor}");
            Console.WriteLine($"-> Preço do Produto: {preco}");
            Console.WriteLine($"-> Quantidade de Vendas do Produto: {vendas}");
            
        }
    }
}
