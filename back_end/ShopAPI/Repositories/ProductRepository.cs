using AutoMapper;
using AutoMapper.Internal;
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

        public async Task<int> DeleteProduct(int productId)
        {
            try
            {
                var product = await _context.products.Where(p => p.ProductId.Equals(productId)).FirstOrDefaultAsync();
                if (product != null)
                {
                    _context.products.Remove(product);
                    await _context.SaveChangesAsync();
                    return product.ProductId;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
            
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

        public async Task<List<ProductModel>> GetProductsByCollection(int CollectionId)
        {
            var productList = await _context.products
                .Where(p => p.CollectionId == CollectionId)
                .ToListAsync();
            return _mapper.Map<List<ProductModel>>(productList);
        }
        //Add
        public async Task<int> InsertProduct(ProductModel productModel)
        {
            var checkProduct = _context.products.FindAsync(productModel.ProductId);
            if (checkProduct.Result == null)
            {
                var newProduct = _mapper.Map<Product>(productModel);
                //newProduct.ColorProducts = productModel.ColorsId.Select(p => new ColorProduct(p)).ToList();
                await _context.products.AddAsync(newProduct);
                await _context.SaveChangesAsync();
                await AddSizeProduct(newProduct.ProductId, productModel.SizesId);
                await AddColorProduct(newProduct.ProductId, productModel.ColorsId);
                return 1;
            }
            return 0;
        }

        public async Task UpdateProduct(ProductModel product)
        {
            var dbTable = await _context.products.Where(p => p.ProductId.Equals(product.ProductId)).FirstOrDefaultAsync();
            if (dbTable != null)
            {
                dbTable.Name = String.IsNullOrEmpty(product.Name) ? dbTable.Name : product.Name;
                dbTable.Price = product.Price == null ? dbTable.Price : product.Price;
                dbTable.Discount = product.Discount == null ? dbTable.Discount : product.Discount;
                dbTable.Quantity = product.Quantity == null ? dbTable.Quantity : product.Quantity;
                dbTable.Variety = String.IsNullOrEmpty(product.Variety) ? dbTable.Variety : product.Variety;
                dbTable.Description = String.IsNullOrEmpty(product.Description) ? dbTable.Description : product.Description;
                dbTable.CollectionId = product.CollectionId == null ? dbTable.CollectionId : product.CollectionId;
                dbTable.CategoryId = product.CategoryId == null ? dbTable.CategoryId : product.CategoryId;
                await UpdateSizeProduct(product.ProductId, product.SizesId);
                await UpdateColorProduct(product.ProductId, product.ColorsId);
                //await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddSizeProduct(int ProductId, List<int> sizes)
        {
            if(ProductId != 0)
            {
                try
                {
                    foreach (var item in sizes)
                    {
                        var newSizeProduct = new SizeProduct(ProductId, item);
                        await _context.sizeProducts.AddAsync(newSizeProduct);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task AddColorProduct(int ProductId, List<int> colors)
        {
            if (ProductId != 0)
            {
                try
                {
                    foreach (var item in colors)
                    {
                        var newColorProduct = new ColorProduct(ProductId, item);
                        await _context.colorProducts.AddAsync(newColorProduct);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task UpdateSizeProduct(int ProductId, List<int> sizes)
        {
            var sizeProductList = await _context.sizeProducts
                .Where(p => p.ProductId == ProductId)
                .ToListAsync();
            if(sizeProductList != null){
                try
                {
                    _context.sizeProducts.RemoveRange(sizeProductList);
                    foreach (var item in sizes)
                    {
                        var newSizeProduct = new SizeProduct(ProductId, item);
                        await _context.sizeProducts.AddAsync(newSizeProduct);
                        await _context.SaveChangesAsync();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task UpdateColorProduct(int ProductId, List<int> colors)
        {
            var colorProductList = await _context.colorProducts
                .Where(p => p.ProductId == ProductId)
                .ToListAsync();
            if (colorProductList != null)
            {
                try
                {
                    _context.colorProducts.RemoveRange(colorProductList);
                    foreach (var item in colors)
                    {
                        var newColorProduct = new ColorProduct(ProductId, item);
                        await _context.colorProducts.AddAsync(newColorProduct);
                        await _context.SaveChangesAsync();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
