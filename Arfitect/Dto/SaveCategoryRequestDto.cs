using System;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Dto
{
	public class SaveCategoryRequestDto
	{
        public int? Id { get; set; }
        public string Title { get; set; }
        public int StockQuantity { get; set; }
	}
}
