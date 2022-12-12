using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteUser(int Id)
        {
            var user = await _context.users.Where(u => u.UserId.Equals(Id)).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserModel> GetUserById(int Id)
        {
            var user = await _context.users.Where(u => u.UserId.Equals(Id)).FirstOrDefaultAsync();
            return _mapper.Map<UserModel>(user);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _context.users!.ToListAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<int> InsertUser(UserModel userModel)
        {
            var checkUser = _context.users.Where(u => u.Username.Equals(userModel.Username)).FirstOrDefaultAsync();
            if (checkUser.Result == null)
            {
                var newUser = _mapper.Map<User>(userModel);
                await _context.users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public Task<int> UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
