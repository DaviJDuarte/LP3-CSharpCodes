CREATE TABLE Cliente (
    ClienteId INT,
    Endereco varchar(80),
    Cidade varchar(30),
    Regiao varchar(10),
    CodigoPostal varchar(10),
    Pais varchar(30),
    Telefone varchar(15),
    PRIMARY KEY(ClienteId)
);

CREATE TABLE Pedido(
    PedidoId int,
    EmpregadoId int,
    DataPedido varchar(10),
    Peso varchar(10),
    CodTransportadora int,
    PedidoClienteId int,
    FOREIGN KEY (PedidoClienteId) REFERENCES Clientes(ClienteId)
);