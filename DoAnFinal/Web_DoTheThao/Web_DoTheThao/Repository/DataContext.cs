using Microsoft.EntityFrameworkCore;
using Web_DoTheThao.Models;

namespace Web_DoTheThao.Repository
{
	public class DataContext : DbContext
	{
		/* Truy van CSDL SQL */ /*Chuyen cau lenh EtityFramework sang Sql */
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{ 

		}
		public DbSet<BrandModel> Brands { get; set; }
		public DbSet<ProductModel> Products { get; set; }
		public DbSet<CategoryModel> Categories { get; set; }
	}
}
