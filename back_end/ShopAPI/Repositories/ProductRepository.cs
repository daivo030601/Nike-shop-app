using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DetailProductModel> GetProductById(int Id)
        {
            DetailProductModel product =  _mapper.Map<DetailProductModel>(await _context.products.Where(p => p.ProductId== Id).FirstOrDefaultAsync());
            List<string> colors = new List<string>();
            var colorList = from c in _context.colors
                            join cp in _context.colorProducts on c.ColorId equals cp.ColorId
                            where cp.ProductId == Id
                            select c.ColorCode;
            foreach (var color in colorList)
            {
                colors.Add(color);
            }

            List<string> sizes = new List<string>();
            var sizeList = from s in _context.sizes
                            join cp in _context.sizeProducts on s.SizeId equals cp.SizeId
                            where cp.ProductId == Id
                            select s.SizeName;
            foreach (var size in sizeList)
            {
                sizes.Add(size);
            }
            product.ColorCode = colors;
            product.SizeName= sizes;
            return product;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var products = await _context.products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<int> InsertProduct(ProductModel productModel)
        {
            var checkProduct = _context.products.FindAsync(productModel.ProductId);
            if (checkProduct.Result == null)
            {
                var newProduct = _mapper.Map<Product>(productModel);
                await _context.products.AddAsync(newProduct);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
