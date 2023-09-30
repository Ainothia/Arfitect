using Product.API.Dto;

namespace Product.API.Business.Interfaces
{
	public interface ICategoryService
	{
        public bool Save(SaveCategoryRequestDto model);
    }
}

