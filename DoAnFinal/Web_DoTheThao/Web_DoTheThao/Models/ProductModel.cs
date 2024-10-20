﻿using Web_DoTheThao.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_DoTheThao.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Tên Sản phẩm")] /* ko dc de trong, do dai toi thieu la 4, */
		public string Name { get; set; }
		
		public string Slug {  get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả Sản phẩm")]
        public string Description { get; set; }
        [Required, Range(1, double.MaxValue, ErrorMessage = "Yêu cầu nhập Giá Sản phẩm hợp lệ")] // Đảm bảo giá trị lớn hơn 0
        public decimal Price { get; set; }
		public int BrandId {  get; set; }
		public int CategoryId {  get; set; }
		public CategoryModel Category { get; set; }
		public BrandModel Brand { get; set; }
		public string Image { get; set; } = "noimage.jpg";
		[NotMapped]
		[FileExtension]
		public IFormFile ImageUpLoad { get; set; }
	}

}
