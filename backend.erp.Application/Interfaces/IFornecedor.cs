using backend.erp.Application.FornecedorDTO;
using backend.erp.Domain.Model;

namespace backend.erp.Application.Interfaces;

public interface IFornecedor
{
    public Task<List<ResponseFornecedorDTO>> GetAllSuppliersAsync();
    public Task<RequestFornecedorDTO> AddSuppliersAsync(RequestFornecedorDTO requestFornecedorDTO);

}