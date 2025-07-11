using Microsoft.EntityFrameworkCore;

namespace Lab06.Models
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

		public DbSet<Loai> Loais { get; set; }
		public DbSet<HangHoa> HangHoas { get; set;}
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
