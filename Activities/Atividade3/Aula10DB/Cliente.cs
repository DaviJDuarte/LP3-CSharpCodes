namespace Aula10DB.Models;

class Cliente
{
    public int IdCliente { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Regiao { get; set; }
    public string CodigoPostal { get; set; }
    public string Pais { get; set; }
    public string Telefone { get; set; }

    public Cliente(int idCliente, string endereco, string cidade, string regiao, string codigoPostal, string pais, string telefone)
    {
        IdCliente = idCliente;
        Endereco = endereco;
        Cidade = cidade;
        Regiao = regiao;
        CodigoPostal = codigoPostal;
        Pais = pais;
        Telefone = telefone;
    }
}
