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
        }
    }
}
