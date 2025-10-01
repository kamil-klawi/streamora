using UsersService.Domain.Common;
using UsersService.Domain.Entities;

namespace UsersService.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<PageResult<User>> GetUsers(int pageSize, int pageNumber);
        Task<User?> GetUserById(Guid id);
        Task<Guid> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
