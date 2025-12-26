using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CsvDataExtractor
{
    internal class Venda
    {
        public string Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }


        public Venda(string produto, int quantidade, decimal preco)
        {

            if (string.IsNullOrWhiteSpace(produto))
                throw new Exception("Produto inválido");

            if (quantidade <= 0)
                throw new Exception("Quantidade inválida");

            if (preco <= 0)
                throw new Exception("Preço inválido");

            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
        }

        public decimal CalcularTotal()
        {
            return Quantidade * Preco;
        }

    }
}
