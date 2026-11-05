using MyLibrary.WebApi.DTOs.Request;
using MyLibrary.WebApi.DTOs.Response;

namespace MyLibrary.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDTO> AddUserAsync(RegisterRequestDTO request);
    Task<AuthResponseDTO> Login(LoginRequestDTO request);
    Task<AuthResponseDTO> RefreshToken(string email);
    Task<IEnumerable<UserResponseDTO>> GetAll();
    Task<UserResponseDTO> GetById(int id);
    Task<UserResponseDTO> Update(int id, UpdateUserRequestDTO request);
    Task<UserResponseDTO> Delete(int id);
}
