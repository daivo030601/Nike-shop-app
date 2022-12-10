using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            var categories = await _context.categories!.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<int> InsertCategory(CategoryModel categoryModel)
        {
            var newCategory = _mapper.Map<Category>(categoryModel);
            _context.categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.CategoryId;
        }
    }
}
