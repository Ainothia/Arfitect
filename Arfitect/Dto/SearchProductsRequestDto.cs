using System.ComponentModel.DataAnnotations;

namespace Product.API.Dto
{
	public class SearchProductsRequestDto
	{
        [StringLength(200)]
        public string Keyword { get; set; }
        public int MinStockQuantity { get; set; }
        public int MaxStockQuantity { get; set; }
    }
}

