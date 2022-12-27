using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> DeleteAddress(int addressId)
        {
            try
            {
                var address = await _context.addresses.Where(a => a.id.Equals(addressId)).FirstOrDefaultAsync();
                if (address != null)
                {
                    _context.addresses.Remove(address);
                    await _context.SaveChangesAsync();
                    return address.id;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AddressModel>> GetAddress(string userId)
        {
            var addresses = await _context.addresses!.Where(a => a.UserId.Equals(userId)).ToListAsync();
            return _mapper.Map<List<AddressModel>>(addresses);
        }

        public async Task<AddressModel> GetAddressById(int addressId)
        {
            var address = await _context.addresses.Where(a => a.id.Equals(addressId)).FirstOrDefaultAsync();
            return _mapper.Map<AddressModel>(address);
        }

        public async Task<int> InsertAddress(AddressModel addressModel)
        {
            var newAddress = _mapper.Map<Address>(addressModel);
            _context.addresses.Add(newAddress);
            await _context.SaveChangesAsync();
            return newAddress.id;
        }

        public async Task UpdateAddress(AddressModel address)
        {
            try
            {
                var dbTable = await _context.addresses.Where(a => a.id.Equals(address.id)).FirstOrDefaultAsync();
                if (dbTable != null)
                {
                    dbTable.phone = String.IsNullOrEmpty(address.phone) ? dbTable.phone : address.phone;
                    dbTable.name = String.IsNullOrEmpty(address.name) ? dbTable.name : address.name;
                    dbTable.pin = String.IsNullOrEmpty(address.pin) ? dbTable.pin : address.pin;
                    dbTable.address = String.IsNullOrEmpty(address.address) ? dbTable.address : address.address;
                    dbTable.city = String.IsNullOrEmpty(address.city) ? dbTable.city : address.city;
                    dbTable.district = String.IsNullOrEmpty(address.district) ? dbTable.district : address.district;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
