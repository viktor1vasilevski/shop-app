using Data.Context;
using EntityModels.Interfaces;
using EntityModels.Models;
using Main.DTOs.Auth;
using Main.Interfaces;
using Main.Requests.Auth;
using Main.Responses;

namespace Main.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork<ApplicationDbContext> _uow;
    private readonly IGenericRepository<User> _userRepository;
    public AuthService(IUnitOfWork<ApplicationDbContext> uow)
    {
        _uow = uow;
        _userRepository = _uow.GetGenericRepository<User>();
    }
    public Task<ApiResponse<RegisterDTO>> RegisterUserAsync(UserRegisterRequest request)
    {
        throw new NotImplementedException();
    }
}
