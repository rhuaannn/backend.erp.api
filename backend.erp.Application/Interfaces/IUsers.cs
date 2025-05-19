using backend.erp.Application.UsuarioDTO;

namespace backend.erp.Application.Interfaces
{
    public interface IUsers
    {
        Task<List<ResponseUserDTO>> GetAllUsersAsync();
        Task <RequestUserDTO>CreateUserAsync(RequestUserDTO requestUserDTO);
    }
}
