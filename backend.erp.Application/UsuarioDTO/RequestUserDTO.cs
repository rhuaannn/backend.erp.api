namespace backend.erp.Application.UsuarioDTO;

public class RequestUserDTO
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public bool Situacao { get; set; }

    public RequestUserDTO()
    {
        
    }

}