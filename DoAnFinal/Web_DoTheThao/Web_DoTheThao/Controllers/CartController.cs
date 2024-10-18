using Microsoft.AspNetCore.Mvc;

namespace Web_DoTheThao.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
