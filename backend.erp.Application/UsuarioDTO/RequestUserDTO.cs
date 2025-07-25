using backend.erp.Domain.UserEnums;

namespace backend.erp.Application.UsuarioDTO;

public class RequestUserDTO
{

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public SituationEnum Situacao { get; set; }

    public RequestUserDTO()
    {
 
    }

}