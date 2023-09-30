using Product.API.Dto;

namespace Product.API.Business.Interfaces
{
	public interface IProductService
	{
        public List<Entity.Product> SearchProducts(SearchProductsRequestDto model);

        public List<Entity.Product> GetProducts();

        public bool Save(SaveProductRequestDto model);

        public void Delete(int productId);
    }
}

