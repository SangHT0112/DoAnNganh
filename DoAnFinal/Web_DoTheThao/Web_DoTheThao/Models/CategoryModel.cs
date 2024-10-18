using System.ComponentModel.DataAnnotations;

namespace Web_DoTheThao.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }
		[Required,MinLength(4,ErrorMessage ="Yêu cầu nhập Tên Danh mục")] /* ko dc de trong, do dai toi thieu la 4, */
		public string Name { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả Danh mục")]
		public string Description { get; set; }
		[Required]
		public string Slug {  get; set; }

		public int Status {  get; set; }
	}
}
