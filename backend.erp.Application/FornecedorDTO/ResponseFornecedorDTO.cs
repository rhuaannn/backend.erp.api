using backend.erp.Domain.UserEnums;

namespace backend.erp.Application.FornecedorDTO;

public class ResponseFornecedorDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public SituationEnum Situacao { get; set; }

    public ResponseFornecedorDTO()
    {
        
    }


}
 