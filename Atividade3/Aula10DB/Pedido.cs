namespace Aula10DB.Models
{
    class Pedido
    {
        public int IdPedido { get; set; }
        public int EmpregadoId { get; set; }
        public string DataPedido { get; set; }
        public string Peso { get; set; }
        public int CodTransportadora { get; set; }
        public int PedidoClienteId { get; set; }

        public Pedido(int idPedido, int empregadoId, string dataPedido, string peso, int codTransportadora, int pedidoClienteId)
        {
            IdPedido = idPedido;
            EmpregadoId = empregadoId;
            DataPedido = dataPedido;
            Peso = peso;
            CodTransportadora = codTransportadora;
            PedidoClienteId = pedidoClienteId;
        }
    }
}
