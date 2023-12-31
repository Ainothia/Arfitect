﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entity
{
    public class Product
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Required]
		[StringLength(200)]
		[MinLength(1)]
		public string Title { get; set; }
		public string? Description { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		[Range(0,Int32.MaxValue)]
        public int StockQuantity { get; set; }
    }
}

