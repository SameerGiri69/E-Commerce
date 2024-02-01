using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoInterface _photoInterface;

        public ProductRepository(ApplicationDbContext context, IMapper mapper, IPhotoInterface photoInterface)
        {
            _context = context;
            _mapper = mapper;
            _photoInterface = photoInterface;
        }

        public Task<bool> AddProduct(AddProductViewModel productVM)
        {
            if(productVM.ProductPhoto != null)
            {
                var photoResult = _photoInterface.AddPhotoAsync(productVM.ProductPhoto);
                var product = new Product()
                {
                    AppUser = productVM.AppUser,
                    StockQuantity = productVM.StockQuantity,
                    ProductCategory = productVM.ProductCategory,
                    Description = productVM.Description,
                    Name = productVM.Name,
                    Id = productVM.Id,
                    Price = productVM.Price,
                    ProductImageUrl = photoResult
                };
                
                var addResult = _context.Add(product);
                return Save();
            }
            else
            {
                var product = new Product()
                {
                    AppUser = productVM.AppUser,
                    StockQuantity = productVM.StockQuantity,
                    ProductCategory = productVM.ProductCategory,
                    Description = productVM.Description,
                    Name = productVM.Name,
                    Id = productVM.Id,
                    Price = productVM.Price,
                };
                var addResult = _context.Add(product);
                return Save();
            }
            
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<bool> Save()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
