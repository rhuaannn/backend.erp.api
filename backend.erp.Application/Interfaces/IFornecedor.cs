using backend.erp.Application.FornecedorDTO;
using backend.erp.Domain.Model;

namespace backend.erp.Application.Interfaces;

public interface IFornecedor
{
    public Task<List<ResponseFornecedorDTO>> GetAllFornecedoresAsync();
    
}