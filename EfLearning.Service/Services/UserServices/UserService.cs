using AutoMapper;
using EfLearning.Data.IRepositories;
using EfLearning.Domain.Entities;
using EfLearning.Service.DTOs.UserDto;
using EfLearning.Service.Exceptions;
using EfLearning.Service.Interfaces.UserInterfaces;

namespace EfLearning.Service.Services.UserServices;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> repository,IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserForViewModel> CreateAsync(UserForCreationDto dto)
    {
        var createUser = await repository.GetAsysn(c => c.UserName == dto.UserName);
        if (createUser is not null)
            throw new CustomException(409, "User is already exist");

        var existUser = await repository.CreateAsync(createUser);
        return mapper.Map<UserForViewModel>(existUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await repository.GetAsysn(e=>e.Id == id);
        if (existUser is null)
            throw new CustomException(404, "User is not found");

        var deleteUser = repository.DeleteAsync(id);
        return true;
    }

    public IEnumerable<UserForViewModel> GetAllAsync()
    {
        var users = repository.GetAll();
        return mapper.Map<IEnumerable<UserForViewModel>>(users);
    }

    public async Task<UserForViewModel> GetAsync(long id)
    {
        var user = await repository.GetAsysn(e=>e.Id == id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        return mapper.Map<UserForViewModel>(user);
    }

    public async Task<UserForViewModel> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await repository.GetAsysn(u=>u.Id == dto.Id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        var updateUser = repository.UpdateAsync(user);
        return mapper.Map<UserForViewModel>(updateUser);
    }
}
