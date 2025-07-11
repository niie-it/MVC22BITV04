using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.Models
{
	[Table("HoaDon")]
	public class Order
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public DateTime OrderDate { get; set; }
	}

	[Table("ChiTietHoaDon")]
	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		[ForeignKey("OrderId")]
		public Order Order { get; set; }
		[ForeignKey("ProductId")]
		public HangHoa Product { get; set; }
	}
}
