using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_DoTheThao.Models;
using Web_DoTheThao.Repository;

namespace Web_DoTheThao.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IActionResult> Index(string Slug = "") /* goi ham giao dien cung ten trong view */
		{
			/* truy vấn danh sách các danh mục từ cơ sở dữ liệu, tìm kiếm danh mục có Slug khớp với tham số Slug được truyền vào. */
			CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
			if (category == null) return RedirectToAction("Index");
			var productsByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);

			return View(await productsByCategory.OrderByDescending(p=>p.Id).ToListAsync());
		}

	}
}
