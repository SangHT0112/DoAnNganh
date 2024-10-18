using System.ComponentModel.DataAnnotations;

namespace Web_DoTheThao.Models
{
	public class BrandModel
	{
		[Key]
		public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Tên Thương hiệu")] /* ko dc de trong, do dai toi thieu la 4, */
		public string Name { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả Thương hiệu")]
		public string Description { get; set; }
		[Required]
		public string Slug { get; set; }

		public int Status { get; set; }
	}
}
