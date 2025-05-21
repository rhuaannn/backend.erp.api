using AutoMapper;
using backend.erp.Application.FornecedorDTO;
using backend.erp.Application.Interfaces;
using backend.erp.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.erp.Application.Services
{
    public class FornecedorServices  : IFornecedor
    {
        
        private readonly AppDbContext _appDbContext; 
        private readonly IMapper _mapper;

        public FornecedorServices(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<List<ResponseFornecedorDTO>> GetAllSuppliersAsync()
        {
            var fornecedores = await _appDbContext.suppliers.ToListAsync();
            return _mapper.Map<List<ResponseFornecedorDTO>>(fornecedores); 
        }
    }
}
