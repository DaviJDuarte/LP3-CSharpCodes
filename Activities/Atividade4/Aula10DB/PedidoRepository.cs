using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Aula10DB.Repositories
{
    class PedidoRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public PedidoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public List<Pedido> Listar()
        {
            var pedidos = new List<Pedido>();

            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Pedido";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var pedidoid = reader.GetInt32(0);
                var empregadoid = reader.GetInt32(1);
                var datapedido = reader.GetString(2);
                var peso = reader.GetString(3);
                var codtransportadora = reader.GetInt32(4);
                var pedidoclienteid = reader.GetInt32(5);

                var pedido = new Pedido(pedidoid, empregadoid, datapedido, peso, codtransportadora, pedidoclienteid);
                pedidos.Add(pedido);
            }

            connection.Close();

            return pedidos;
        }

        public Pedido Inserir(Pedido pedido)
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Pedido VALUES($pedidoid, $empregadoid, $datapedido, $peso, $codtransportadora, $pedidoclienteid)";
            command.Parameters.AddWithValue("$pedidoid", pedido.IdPedido);
            command.Parameters.AddWithValue("$empregadoid", pedido.EmpregadoId);
            command.Parameters.AddWithValue("$datapedido", pedido.DataPedido);
            command.Parameters.AddWithValue("$peso", pedido.Peso);
            command.Parameters.AddWithValue("$codtransportadora", pedido.CodTransportadora);
            command.Parameters.AddWithValue("$pedidoclienteid", pedido.PedidoClienteId);

            command.ExecuteNonQuery();
            connection.Close();

            return pedido;
        }

        private Pedido ReaderToPedido(SqliteDataReader reader)
        {
            var pedidoid = reader.GetInt32(0);
            var empregadoid = reader.GetInt32(1);
            var datapedido = reader.GetString(2);
            var peso = reader.GetString(3);
            var codtransportadora = reader.GetInt32(4);
            var pedidoclienteid = reader.GetInt32(5);

            var pedido = new Pedido(pedidoid, empregadoid, datapedido, peso, codtransportadora, pedidoclienteid);

            return pedido;
        }

        public Pedido GetByIdPedido(int pedidoid)
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Pedido WHERE (pedidoid = $pedidoid)";
            command.Parameters.AddWithValue("$pedidoid", pedidoid);

            var reader = command.ExecuteReader();
            reader.Read();

            var pedido = ReaderToPedido(reader);

            connection.Close();

            return pedido;
        }

        public bool ExistByIdPedido(int pedidoid)
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT count(pedidoid) FROM Pedido WHERE (pedidoid = $pedidoid)";
            command.Parameters.AddWithValue("$pedidoid", pedidoid);

            var reader = command.ExecuteReader();
            reader.Read();
            var resultPedido = reader.GetBoolean(0);

            return resultPedido;
        }
    }
}
