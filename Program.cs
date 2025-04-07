using System;
using System.Collections.Generic;

public class Fornecedor
{
    public string cnpj;
    public string razaoSocial;

    public Fornecedor(string nome, string cnpj)
    {
        razaoSocial = nome;
        this.cnpj = cnpj;
    }
}

public class Pessoa
{
    public string nome;
    public string telefone;
    public string logradouro;
    public string email;
    public string usuario;
    public string senha;
}

public class Cliente : Pessoa
{
    public string cpf;
    public string rg;

    public Cliente(string cpfValor, string nomeValor)
    {
        cpf = cpfValor;
        nome = nomeValor;
    }
}

public class Produto
{
    public string descricao;
    public double valor;

    public Produto() {}

    public Produto(string desc, double val)
    {
        descricao = desc;
        valor = val;
    }
}

public class NotaFiscal
{
    public double numero;
    public Cliente cliente;
    public Fornecedor fornecedor;
    public List<Produto> produtos = new List<Produto>();

    public NotaFiscal(Cliente cli, Fornecedor forn)
    {
        cliente = cli;
        fornecedor = forn;
        numero = new Random().Next(1000, 9999);
    }

    public void AdicionaProduto(Produto p)
    {
        produtos.Add(p);
    }

    public void MostrarNota()
    {
        Console.WriteLine("\nNota Fiscal #" + numero);
        Console.WriteLine("Cliente: " + cliente.nome + " - CPF: " + cliente.cpf);
        Console.WriteLine("Fornecedor: " + fornecedor.razaoSocial + " - CNPJ: " + fornecedor.cnpj);
        Console.WriteLine("Produtos:");
        foreach (Produto p in produtos)
        {
            Console.WriteLine("- " + p.descricao + " | R$ " + p.valor.ToString("F2"));
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

