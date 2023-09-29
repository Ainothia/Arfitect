using System;
using Product.API.Entity;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Dto
{
	public class SearchProductsRequestDto
	{
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int MinStockQuantity { get; set; }

        public int MaxStockQuantity { get; set; }
    }
}

