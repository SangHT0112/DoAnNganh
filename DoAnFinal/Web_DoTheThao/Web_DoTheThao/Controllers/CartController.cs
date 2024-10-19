using Microsoft.AspNetCore.Mvc;
using Web_DoTheThao.Models;
using Web_DoTheThao.Models.ViewModel;
using Web_DoTheThao.Repository;

namespace Web_DoTheThao.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _dataContext;
		public CartController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public IActionResult Index()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new()
			{
				CartItems = cartItems,
				GrandToTal = cartItems.Sum(x => x.Quantity * x.Price)

			};
			return View(cartVM);
		}
	}
}
