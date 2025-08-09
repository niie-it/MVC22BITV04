using System.ComponentModel.DataAnnotations;

namespace MyEShop01.Models
{
	public class LoginVM
	{
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Từ 5 - 20 kí tự")]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		[MaxLength(50)]
		public string Password { get; set; }
	}
}