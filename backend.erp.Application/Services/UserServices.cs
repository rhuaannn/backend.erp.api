using AutoMapper;
using backend.erp.Application.Interfaces;
using backend.erp.Application.UsuarioDTO;
using backend.erp.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.erp.Application.Services
{
    public class UserServices : IUsers
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UserServices(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<List<ResponseUserDTO>> GetAllUsersAsync()
        {
            var users = await _appDbContext.users.ToListAsync();
            return _mapper.Map<List<ResponseUserDTO>>(users);
        }
    }
}
