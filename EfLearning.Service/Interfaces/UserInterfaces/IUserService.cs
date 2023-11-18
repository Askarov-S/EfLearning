using EfLearning.Service.DTOs.UserDto;

namespace EfLearning.Service.Interfaces.UserInterfaces;

public interface IUserService
{
    public Task<UserForViewModel> CreateAsync(UserForCreationDto dto);
    public Task<UserForViewModel> UpdateAsync(UserForUpdateDto dto);
    public Task<bool> DeleteAsync(long  id);
    public Task<UserForViewModel> GetAsync(long id);
    public IEnumerable<UserForViewModel> GetAllAsync();
}
