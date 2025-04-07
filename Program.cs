using System;
using System.Collections.Generic;

public class Fornecedor
{
    public string Cnpj { get; set; }
    public string RazaoSocial { get; set; }

    public Fornecedor(string nome, string cnpj)
    {
        RazaoSocial = nome;
        Cnpj = cnpj;
    }
}

public class Pessoa
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Logradouro { get; set; }
    public string Email { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
}

public class Cliente : Pessoa
{
    public string Cpf { get; set; }
    public string Rg { get; set; }

    public Cliente(string cpf, string nome)
    {
        Cpf = cpf;
        Nome = nome;
    }
}

public class Produto
{
    public string Descricao { get; set; }
    public double Valor { get; set; }

    public Produto() {}

    public Produto(string descricao, double valor)
    {
        Descricao = descricao;
        Valor = valor;
    }
}

public class NotaFiscal
{
    public double Numero { get; set; }
    public Cliente Cliente { get; set; }
    public Fornecedor Fornecedor { get; set; }
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    public NotaFiscal(Cliente cliente, Fornecedor fornecedor)
    {
        Cliente = cliente;
        Fornecedor = fornecedor;
        Numero = new Random().Next(1000, 9999);
    }

    public void AdicionaProduto(Produto produto)
    {
        Produtos.Add(produto);
    }

    public void MostrarNota()
    {
        Console.WriteLine($"\nNota Fiscal #{Numero}");
        Console.WriteLine($"Cliente: {Cliente.Nome} - CPF: {Cliente.Cpf}");
        Console.WriteLine($"Fornecedor: {Fornecedor.RazaoSocial} - CNPJ: {Fornecedor.Cnpj}");
        Console.WriteLine("Produtos:");
        foreach (var p in Produtos)
        {
            Console.WriteLine($"- {p.Descricao} | R$ {p.Valor:F2}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Cadastro de Cliente");
        Console.Write("Nome: ");
        string nomeCliente = Console.ReadLine();
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        Cliente cliente = new Cliente(cpf, nomeCliente);

        Console.WriteLine("\nCadastro de Fornecedor");
        Console.Write("Razão Social: ");
        string razao = Console.ReadLine();
        Console.Write("CNPJ: ");
        string cnpj = Console.ReadLine();

        Fornecedor fornecedor = new Fornecedor(razao, cnpj);

        NotaFiscal nota = new NotaFiscal(cliente, fornecedor);

        string opcao;
        do
        {
            Console.WriteLine("\n--- Adicionar Produto ---");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor: ");
            double valor = double.Parse(Console.ReadLine());

            Produto produto = new Produto(descricao, valor);
            nota.AdicionaProduto(produto);

            Console.Write("Deseja adicionar outro produto? (s/n): ");
            opcao = Console.ReadLine().ToLower();

        } while (opcao == "s");

        nota.MostrarNota();
    }
}
