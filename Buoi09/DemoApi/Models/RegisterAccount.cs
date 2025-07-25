using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
	public class RegisterAccount
	{
		public string AccountNumber { get; set; }
		public string AccountHolder { get; set; }
		public string Phone { get; set; }

		[RegularExpression(@"\d{12}", ErrorMessage ="Must 12 digits.")]
		public string CitizenId { get; set; }

		//[CitizenExpireDate]
		public DateTime ExpireDate { get; set; }

		[Range(100000, double.MaxValue, ErrorMessage ="Minimum 100k")]
		public double InitialBalance { get; set; }
	}
}
