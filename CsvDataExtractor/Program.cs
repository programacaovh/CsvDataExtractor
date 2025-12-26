using CsvDataExtractor;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string caminho = "Data/vendas.csv";
        string[] linhas = File.ReadAllLines(caminho);

        List<Venda> vendas = new List<Venda>();

        for (int i = 1; i < linhas.Length; i++) // pula o cabeçalho
        {
            string[] colunas = linhas[i].Split(',');

            string produto = colunas[0];
            int quantidade = int.Parse(colunas[1]);
            decimal preco = decimal.Parse(colunas[2]);

            Venda venda = new Venda(produto, quantidade, preco);
            vendas.Add(venda);
        }

        foreach (var venda in vendas)
        {
            decimal total = venda.CalcularTotal();
            Console.WriteLine($"Produto: {venda.Produto} | Total: {total}");
        }

        decimal faturamentoTotal = 0;


        foreach (var venda in vendas)
        {
            faturamentoTotal += venda.CalcularTotal();
        }
        Console.WriteLine($"Faturamento total: {faturamentoTotal}");

        if (vendas.Count > 0)
        {
            decimal media = faturamentoTotal / vendas.Count;
            Console.WriteLine($"Média por venda: {media}");
        }
    }
}

