using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_DoTheThao.Repository.Components
{
	public class CategoriesViewComponent : ViewComponent /* Lay du lieu cua Category */
	{
		private readonly DataContext _dataContext;
		public CategoriesViewComponent(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IViewComponentResult> InvokeAsync() => View(await _dataContext.Categories.ToListAsync()); /*truy xuất tất cả các mục từ bảng Categories trong cơ sở dữ liệu */
	}
}
