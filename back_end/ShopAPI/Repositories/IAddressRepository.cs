using ShopAPI.Data;

namespace ShopAPI.Repositories
{

    public interface IAddressRepository
    {
        Task<int> InsertAddress(AddressModel addressModel);
        Task<List<AddressModel>> GetAddress();
    }
}
