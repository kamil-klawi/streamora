using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Common;
using UsersService.Domain.Entities;
using UsersService.Domain.Repositories;
using UsersService.Infrastructure.Persistence;

namespace UsersService.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _dbContext;

        public UsersRepository(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PageResult<User>> GetUsers(int pageSize, int pageNumber)
        {
            var totalCount = await _dbContext.Users.CountAsync();

            var users = await _dbContext.Users
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<User>
            {
                Items = users,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<Guid> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _dbContext.Attach(user);
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
