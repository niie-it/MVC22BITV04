using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data
{
	public class BankDataContext : DbContext
	{
		public BankDataContext(DbContextOptions<BankDataContext> options) : base(options) { }

		public DbSet<Bank> Banks { get; set; }
		public DbSet<BankAccount> BankAccounts { get; set; }
	}
}
