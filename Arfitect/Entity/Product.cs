using System;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Entity
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public int StockQuantity { get; set; }
    }

}

