using Microsoft.Data.Sqlite;

namespace Aula10DB.Database
{
    class DatabaseSetup
    {
        private readonly DatabaseConfig _databaseConfig;

        public DatabaseSetup(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
            CriarTabelaCliente();
            CriarTabelaPedido();
        }

        private void CriarTabelaCliente()
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Cliente(
                    ClienteId INTEGER PRIMARY KEY,
                    Endereco TEXT NOT NULL,
                    Cidade TEXT NOT NULL,
                    Regiao TEXT NOT NULL,
                    CodigoPostal TEXT NOT NULL,
                    Pais TEXT NOT NULL,
                    Telefone TEXT NOT NULL
                );
            ";

            command.ExecuteNonQuery();
            connection.Close();
        }

        private void CriarTabelaPedido()
        {
            var connection = new SqliteConnection(_databaseConfig.ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Pedido(
                    PedidoId INTEGER PRIMARY KEY,
                    EmpregadoId INTEGER NOT NULL,
                    DataPedido TEXT NOT NULL,
                    Peso TEXT NOT NULL,
                    CodTransportadora INTEGER NOT NULL,
                    PedidoClienteId INTEGER NOT NULL
                );
            ";

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
