using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApi.Data
{
	[Table("Bank")]
	public class Bank
	{
		[Key]
		public string BankCode { get; set; }
		public string BankName { get; set; }
	}

	[Table("BankAccount")]
	public class BankAccount
	{
		[Key]
		public string AccountNumber { get; set; }
		public string AccountHolder { get; set; }
		public string Phone { get; set; }
		public string CitizenId { get; set; }
		public DateTime PidExpireDate { get; set; }
		public double Balance { get; set; }
		public string BankCode { get; set; }
		[ForeignKey(nameof(BankCode))]
		public Bank Bank { get; set; }
	}
}
