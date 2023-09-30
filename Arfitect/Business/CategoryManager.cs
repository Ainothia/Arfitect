using Product.API.Business.Interfaces;
using Product.API.Dto;

namespace Product.API.Business
{
	public class CategoryManager : ICategoryService
    {
	    private readonly Entity.ProductApiDbContext _dbContext;

        public CategoryManager(Entity.ProductApiDbContext productApiDbContext)
        {
            _dbContext = productApiDbContext;
        }

        public bool Save(SaveCategoryRequestDto model)
        {
            var entity = _dbContext
                .Categories
                .Find(model.Id);

            if (entity?.Id != null)
            {
                entity.Title = model.Title;
                entity.StockQuantity = model.StockQuantity;

                _dbContext.Update(entity);
            }
            else
            {
                entity = new Entity.Category
                {
                    Title = model.Title,
                    StockQuantity = model.StockQuantity
                };

                _dbContext.Add(entity);
            }

            _dbContext.SaveChanges();

            return true;
        }
    }
}

