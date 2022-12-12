using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface IUserRepository
    {
        Task<int> InsertUser(UserModel userModel);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(int Id);
        Task DeleteUser(int Id);
        Task<int> UpdateUser(UserModel userModel);
    }
}
