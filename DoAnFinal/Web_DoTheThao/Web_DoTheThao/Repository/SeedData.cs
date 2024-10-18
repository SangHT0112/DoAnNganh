using Microsoft.EntityFrameworkCore;
using Web_DoTheThao.Models;
namespace Web_DoTheThao.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if(!_context.Products.Any()) /* Neu du lieu trong Products chua co */
			{
				CategoryModel GangTay = new CategoryModel() { Name = "Găng tay", Slug = "găng tay", Description = "Chất liệu cao, thoải mái", Status = 1 };
				CategoryModel QuanAoTheThao = new CategoryModel() { Name = "Quần áo thể thao", Slug = "quần áo thể thao", Description = "Thời trang, phong cách", Status = 1 };
				BrandModel Adidas = new BrandModel() { Name = "Adidas", Slug = "adidas", Description = "Thời thượng, trẻ trung", Status = 1 };
				BrandModel Nike = new BrandModel() { Name = "Nike", Slug = "nike", Description = "Phong cách, năng động", Status = 1 };
				_context.Products.AddRange(
					new ProductModel {  Name="Áo bóng đá",Slug="áo bóng đá",Description="Chất vải bền",Image="aobongda1.jpg",Category=QuanAoTheThao,Brand=Adidas,Price=160000},
					new ProductModel { Name = "Găng tay thủ môn", Slug = "găng tay thủ môn", Description = "Bắt dính", Image = "gangtaythumon1.jpg", Category = GangTay, Brand = Nike, Price = 100000 }
					);
				_context.SaveChanges();
			}
		}
	}
}
