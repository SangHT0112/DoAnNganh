using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_DoTheThao.Repository.Components
{
	public class BrandsViewComponent : ViewComponent /* Lay du lieu cua Category */
	{
		private readonly DataContext _dataContext;
		public BrandsViewComponent(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IViewComponentResult> InvokeAsync() => View(await _dataContext.Brands.ToListAsync());
	}
}
