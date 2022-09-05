﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
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
           
        }

        public void AdicionarSaida()
        {
            
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
