using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Product.API.Entity
{
	public class ProductApiDbContext: DbContext
	{
		public ProductApiDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
    }
}

