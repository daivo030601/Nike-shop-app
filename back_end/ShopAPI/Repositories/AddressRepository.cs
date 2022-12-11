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
        public async Task<List<AddressModel>> GetAddress()
        {
            var addresses = await _context.addresses!.ToListAsync();
            return _mapper.Map<List<AddressModel>>(addresses);
        }

        public async Task<int> InsertAddress(AddressModel addressModel)
        {
            var newAddress = _mapper.Map<Address>(addressModel);
            _context.addresses.Add(newAddress);
            await _context.SaveChangesAsync();
            return newAddress.AddressId;
        }
    }
}
