using System;
using Microsoft.EntityFrameworkCore;
using Product.API.Business.Interfaces;
using Product.API.Dto;

namespace Product.API.Business
{
	public class ProductManager : IProductService
	{
		private readonly Entity.ProductApiDbContext _dbContext;

		public ProductManager(Entity.ProductApiDbContext productApiDbContext)
		{
            _dbContext = productApiDbContext;
		}

		public List<Entity.Product> SearchProducts(SearchProductsRequestDto model)
		{
			//TO DO: Stock quantity sorgusu düzenlenecek
			return  _dbContext
					.Products
					.Include(x => x.Category)
					.Where(product => product.Title.Contains(model.Title) ||
							product.Description.Contains(model.Description) ||
							product.Category.Title.Contains(model.CategoryName) ||
							(product.StockQuantity < model.MaxStockQuantity && product.StockQuantity > model.MaxStockQuantity))
					.ToList();
		}

        public List<Entity.Product> GetProducts()
        {
            return _dbContext
                    .Products
                    .Include(x => x.Category)
                    .ToList();
        }
    }
}

