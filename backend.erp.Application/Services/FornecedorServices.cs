using AutoMapper;
using backend.erp.Application.FornecedorDTO;
using backend.erp.Application.Interfaces;
using backend.erp.Domain.Model;
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

        public async Task<RequestFornecedorDTO> AddSuppliersAsync(RequestFornecedorDTO requestFornecedorDTO)
        {
            if (string.IsNullOrEmpty(requestFornecedorDTO.Documento))
            {
                throw new Exception("Documento obrigatório.");
            }
            var suppliers = _mapper.Map<Fornecedores>(requestFornecedorDTO);
            var supplersxists = await _appDbContext.suppliers.AnyAsync(f => f.Documento == suppliers.Documento);
               
            if (supplersxists)
            {
                throw new Exception("Supplier already exists with the same document.");
            }
            await _appDbContext.suppliers.AddAsync(suppliers);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<RequestFornecedorDTO>(suppliers);
        }

        public async Task<List<ResponseFornecedorDTO>> GetAllSuppliersAsync()
        {
            var fornecedores = await _appDbContext.suppliers.ToListAsync();
            return _mapper.Map<List<ResponseFornecedorDTO>>(fornecedores); 
        }
    }
}
