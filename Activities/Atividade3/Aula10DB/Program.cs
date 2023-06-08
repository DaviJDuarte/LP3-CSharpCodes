using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;
using System;
using System.Collections.Generic;

namespace Aula10DB
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Informe os parâmetros corretamente.");
                Console.WriteLine("Exemplo: dotnet run -- Cliente Inserir");
                return;
            }

            string tabela = args[0];
            string acao = args[1];

            var databaseConfig = new DatabaseConfig();
            var clienteRepository = new ClienteRepository(databaseConfig);
            var pedidoRepository = new PedidoRepository(databaseConfig);

            if (tabela == "Cliente")
            {
                if (acao == "Listar")
                {
                    Console.WriteLine("\nListar Cliente");
                    foreach (var cliente in clienteRepository.Listar())
                    {
                        Console.WriteLine($"{cliente.IdCliente}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais}, {cliente.Telefone}");
                    }
                }
                else if (acao == "Inserir")
                {
                    Console.WriteLine("\nInserir Cliente\n");
                    Console.WriteLine("Digite o Id: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o endereço: ");
                    string endereco = Console.ReadLine();
                    Console.WriteLine("Digite a cidade: ");
                    string cidade = Console.ReadLine();
                    Console.WriteLine("Digite a região: ");
                    string regiao = Console.ReadLine();
                    Console.WriteLine("Digite o código postal: ");
                    string codigoPostal = Console.ReadLine();
                    Console.WriteLine("Digite o país: ");
                    string pais = Console.ReadLine();
                    Console.WriteLine("Digite o telefone: ");
                    string telefone = Console.ReadLine();
                    var cliente = new Cliente(idCliente, endereco, cidade, regiao, codigoPostal, pais, telefone);
                    clienteRepository.Inserir(cliente);
                }
                else
                {
                    Console.WriteLine("Ação inválida para a tabela Cliente.");
                }
            }
            else if (tabela == "Pedido")
            {
                if (acao == "Listar")
                {
                    Console.WriteLine("Listar Pedido");
                    foreach (var pedido in pedidoRepository.Listar())
                    {
                        Console.WriteLine($"{pedido.IdPedido}, {pedido.EmpregadoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
                    }
                }
                else if (acao == "Inserir")
                {
                    Console.WriteLine("\nInserir Pedido\n");
                    Console.WriteLine("Digite o Id do Pedido: ");
                    int idPedido = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Id do Empregado: ");
                    int idEmpregado = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a data do pedido: ");
                    string dataPedido = Console.ReadLine();
                    Console.WriteLine("Digite o peso do pedido: ");
                    string peso = Console.ReadLine();
                    Console.WriteLine("Digite o código da transportadora: ");
                    int codTransportadora = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Id do Cliente que fez o Pedido: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());
                    var pedido = new Pedido(idPedido, idEmpregado, dataPedido, peso, codTransportadora, idCliente);
                    pedidoRepository.Inserir(pedido);
                }
                else
                {
                    Console.WriteLine("Ação inválida para a tabela Pedido.");
                }
            }
            else
            {
                Console.WriteLine("Tabela inválida.");
            }
        }
    }
}
