using AutoMapper;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Collection, CollectionModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Product, DetailProductModel>().ReverseMap();
        }
    }
}
