using ShopAPI.Data;

namespace ShopAPI.Repositories
{

    public interface IAddressRepository
    {
        Task<int> InsertAddress(AddressModel addressModel);
        Task<List<AddressModel>> GetAddress(string userId);
        Task<int> DeleteAddress(int addressId);
        Task UpdateAddress(AddressModel address);
        Task<AddressModel> GetAddressById(int addressId);
    }
}
