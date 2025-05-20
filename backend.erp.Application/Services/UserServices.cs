using AutoMapper;
using backend.erp.Application.Interfaces;
using backend.erp.Application.UsuarioDTO;
using backend.erp.Domain.Model;
using backend.erp.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

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

        public async Task<ResponseUserDTO> CreateUserAsync(RequestUserDTO requestUserDTO)
        {
            var addUser = _mapper.Map<Usuarios>(requestUserDTO);
            addUser.Senha = BCrypt.Net.BCrypt.HashPassword(addUser.Senha);

            await _appDbContext.users.AddAsync(addUser);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<ResponseUserDTO>(addUser);
        }

    }
}
