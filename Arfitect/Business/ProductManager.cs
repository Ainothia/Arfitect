using System.ComponentModel.DataAnnotations;
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
			return _dbContext
					.Products
					.AsNoTracking()
					.Include(x => x.Category)
					.Where(product => (product.Title.Contains(model.Keyword) ||
									  product.Description.Contains(model.Keyword) ||
									  product.Category.Title.Contains(model.Keyword)) && 
									  (model.MaxStockQuantity > 0 ?
									  (product.StockQuantity >= model.MinStockQuantity &&
									  product.StockQuantity <= model.MaxStockQuantity) : true))
					.ToList();
		}

        public List<Entity.Product> GetProducts()
        {
            return _dbContext
                    .Products
					.AsNoTracking()
                    .Include(x => x.Category)
                    .ToList();
        }

		public bool Save(SaveProductRequestDto model)
		{
			var entity = _dbContext
				.Products
				.Find(model.Id);

			if(entity?.Id != null)
			{
				entity.Title = model.Title;
				entity.Description = model.Description;
				entity.StockQuantity = model.StockQuantity;

				_dbContext.Update(entity);
			}
			else
			{
				entity = new Entity.Product
                {
                    Title = model.Title,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    StockQuantity = model.StockQuantity
                };

                _dbContext.Add(entity);
            }

            if(!ValidateStockQuantity(entity))
			{
				throw new ValidationException();
			}

            _dbContext.SaveChanges();

			return true;
		}

		public bool ValidateStockQuantity(Entity.Product entity)
		{
			var category = new Entity.Category();
			if(entity.Category == null)
			{
				category = _dbContext
					.Categories
					.Where(category => category.Id == entity.CategoryId)
					.FirstOrDefault();
			}
			else
			{
				category = entity.Category; 
			}

			if(entity.StockQuantity < category.StockQuantity) { 
				return false;
			}

			return true;
		}

		public void Delete(int productId)
		{
			var entity = _dbContext.Products
				.Where(product => product.Id == productId)
				.FirstOrDefault();

			_dbContext.Products.Remove(entity);
			_dbContext.SaveChanges();
		}
    }
}

