using AutoMapper;
using backend.erp.Application.FornecedorDTO;
using backend.erp.Application.Interfaces;
using backend.erp.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.erp.Application.Services
{
    public class Fornecedor  : IFornecedor
    {
        
        private readonly AppDbContext _appDbContext; 
        private readonly IMapper _mapper;

        public Fornecedor(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<List<ResponseFornecedorDTO>> GetAllFornecedoresAsync()
        {
            var fornecedores = await _appDbContext.suppliers.ToListAsync();
            return _mapper.Map<List<ResponseFornecedorDTO>>(fornecedores); 
        }
    }
}
