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

            using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Cliente";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var idCliente = reader.GetInt32(reader.GetOrdinal("ClienteId"));
                        var endereco = reader.GetString(reader.GetOrdinal("Endereco"));
                        var cidade = reader.GetString(reader.GetOrdinal("Cidade"));
                        var regiao = reader.GetString(reader.GetOrdinal("Regiao"));
                        var codigoPostal = reader.GetString(reader.GetOrdinal("CodigoPostal"));
                        var pais = reader.GetString(reader.GetOrdinal("Pais"));
                        var telefone = reader.GetString(reader.GetOrdinal("Telefone"));

                        var cliente = new Cliente(idCliente, endereco, cidade, regiao, codigoPostal, pais, telefone);
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public Cliente Inserir(Cliente cliente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Cliente VALUES($idCliente, $endereco, $cidade, $regiao, $codigoPostal, $pais, $telefone)";
                command.Parameters.AddWithValue("$idCliente", cliente.IdCliente);
                command.Parameters.AddWithValue("$endereco", cliente.Endereco);
                command.Parameters.AddWithValue("$cidade", cliente.Cidade);
                command.Parameters.AddWithValue("$regiao", cliente.Regiao);
                command.Parameters.AddWithValue("$codigoPostal", cliente.CodigoPostal);
                command.Parameters.AddWithValue("$pais", cliente.Pais);
                command.Parameters.AddWithValue("$telefone", cliente.Telefone);

                command.ExecuteNonQuery();
            }

            return cliente;
        }

        private Cliente ReaderToCliente(SqliteDataReader reader)
        {
            var idCliente = reader.GetInt32(reader.GetOrdinal("ClienteId"));
            var endereco = reader.GetString(reader.GetOrdinal("Endereco"));
            var cidade = reader.GetString(reader.GetOrdinal("Cidade"));
            var regiao = reader.GetString(reader.GetOrdinal("Regiao"));
            var codigoPostal = reader.GetString(reader.GetOrdinal("CodigoPostal"));
            var pais = reader.GetString(reader.GetOrdinal("Pais"));
            var telefone = reader.GetString(reader.GetOrdinal("Telefone"));

            var cliente = new Cliente(idCliente, endereco, cidade, regiao, codigoPostal, pais, telefone);

            return cliente;
        }

        public Cliente GetByIdCliente(int idCliente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Cliente WHERE ClienteId = $idCliente";
                command.Parameters.AddWithValue("$idCliente", idCliente);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var cliente = ReaderToCliente(reader);

                    return cliente;
                }
            }
        }

        public bool ExistByIdCliente(int idCliente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT count(ClienteId) FROM Cliente WHERE ClienteId = $idCliente";
                command.Parameters.AddWithValue("$idCliente", idCliente);

                var count = (long)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
