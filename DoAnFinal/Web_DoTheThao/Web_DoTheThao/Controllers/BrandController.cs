using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_DoTheThao.Models;
using Web_DoTheThao.Repository;

namespace Web_DoTheThao.Controllers
{
	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IActionResult> Index(string Slug = "") /* goi ham giao dien cung ten trong view */
		{
			/* truy vấn danh sách các danh mục từ cơ sở dữ liệu, tìm kiếm danh mục có Slug khớp với tham số Slug được truyền vào. */
			BrandModel brand = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
			if (brand == null) return RedirectToAction("Index");
			var productsByBrand = _dataContext.Products.Where(p => p.BrandId == brand.Id);

			return View(await productsByBrand.OrderByDescending(p => p.Id).ToListAsync());
		}
	}
}
