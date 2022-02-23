using Application.Models;
using Application.Services.Contracts;
using AutoMapper;
using DataAccess.Contracts;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserModel>>(users);
    }
}
