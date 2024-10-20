using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_DoTheThao.Models;
using Web_DoTheThao.Repository;

namespace Web_DoTheThao.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		
		private readonly DataContext _dataContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dataContext = context;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Products.OrderByDescending(p =>p.Id).Include(p => p.Category).Include(p => p.Brand).ToListAsync());
		}
        [HttpGet]
        public  IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name");
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductModel product)
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
			if (ModelState.IsValid)
			{
				//Them du lieu
				product.Slug = product.Name.Replace(" ", "_");
				var slug = await _dataContext.Products.FirstOrDefaultAsync( p => p.Slug == product.Slug);
				if(slug != null)
				{
					ModelState.AddModelError("", "Sản phẩm đã có trong Products");
					return View(product);
				}
					if(product.ImageUpLoad != null)
					{
						string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath,"media/products"); //tro den wwwroot
						string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpLoad.FileName;
						string filePath = Path.Combine(uploadsDir, imageName);

						FileStream fs = new FileStream(filePath, FileMode.Create);
						await product.ImageUpLoad.CopyToAsync(fs);
						fs.Close();
						product.Image = imageName;
					}
					_dataContext.Add(product);
					await _dataContext.SaveChangesAsync();
                    TempData["success"] = "Thêm sản phẩm thành công";
					return RedirectToAction("Index");
           
            }
			else
			{
				TempData["error"] = "Model có một vài thứ đang bị lỗi";
				List<string> errors = new List<string>();
				foreach (var value in ModelState.Values)
				{
					foreach (var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string errorMessage = string.Join("\n", errors);
				return BadRequest(errorMessage);
			}
			
			return View(product);
		}
	}
}

