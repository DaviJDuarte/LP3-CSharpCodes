using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Aula10DB.Repositories
{
    class ClienteRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public ClienteRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public List<Cliente> Listar()
        {
            var clientes = new List<Cliente>();

            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Cliente";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var IdCliente = reader.GetInt32(0);
                var endereco = reader.GetString(1);
                var cidade = reader.GetString(2);
                var regiao = reader.GetString(3);
                var codigoPostal = reader.GetString(4);
                var pais = reader.GetString(5);
                var telefone = reader.GetString(6);

                var cliente = new Cliente(IdCliente, endereco, cidade, regiao, codigoPostal, pais, telefone);
                clientes.Add(cliente);
            }

            connection.Close();

            return clientes;
        }

        public Cliente Inserir(Cliente cliente)
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Cliente VALUES($IdCliente, $endereco, $cidade, $regiao, $codigoPostal, $pais, $telefone)";
            command.Parameters.AddWithValue("$IdCliente", cliente.IdCliente);
            command.Parameters.AddWithValue("$endereco", cliente.Endereco);
            command.Parameters.AddWithValue("$cidade", cliente.Cidade);
            command.Parameters.AddWithValue("$regiao", cliente.Regiao);
            command.Parameters.AddWithValue("$codigoPostal", cliente.CodigoPostal);
            command.Parameters.AddWithValue("$pais", cliente.Pais);
            command.Parameters.AddWithValue("$telefone", cliente.Telefone);

            command.ExecuteNonQuery();
            connection.Close();

            return cliente;
        }

        private Cliente ReaderToCliente(SqliteDataReader reader)
        {
            var IdCliente = reader.GetInt32(0);
            var endereco = reader.GetString(1);
            var cidade = reader.GetString(2);
            var regiao = reader.GetString(3);
            var codigoPostal = reader.GetString(4);
            var pais = reader.GetString(5);
            var telefone = reader.GetString(6);

            var cliente = new Cliente(IdCliente, endereco, cidade, regiao, codigoPostal, pais, telefone);

            return cliente;
        }
    }
}
