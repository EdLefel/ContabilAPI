namespace SimpleCrudApp.client.models{

public class Client
{
    public int Id { get; set; }
    public string Tipopessoa { get; set; }  = string.Empty;
    public string Razaosocial { get; set; }= string.Empty;
    public string Nomefic { get; set; }= string.Empty;
    public string Email { get; set; }= string.Empty;
    public string Telefonecontato1 { get; set; }= string.Empty;
    public string Telefonecontato2 { get; set; }= string.Empty;
    public string Cpfcnpj { get; set; }= string.Empty;
    public string Rg { get; set; }= string.Empty;
    public DateTime Datacadastro { get; set; }
    public DateTime Datanascimento { get; set; }
    public string Cep { get; set; }= string.Empty;
    public string Endereco { get; set; }= string.Empty;
    public string Numero { get; set; }= string.Empty;
    public string Cidade { get; set; }= string.Empty;
    public string Uf { get; set; }= string.Empty;
    public int Devendo { get; set; }
}
}