using DemoApi.Data;
using DemoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Accounts : ControllerBase
	{
		private readonly BankDataContext _context;

		public Accounts(BankDataContext context)
		{
			_context = context;
		}

		[HttpPost("register")]
		public IActionResult CreateNewAccount(RegisterAccount model)
		{
			var acc = _context.BankAccounts.SingleOrDefault(p => p.AccountNumber == model.AccountNumber);
			if (acc != null)
			{
				return Ok(new
				{
					Status = "FAIL",
					Message = $"Account number {model.AccountNumber} is existed"
				});
			}
			var newAccount = new BankAccount
			{

			};
			_context.Add(newAccount);
			_context.SaveChanges();

			return Ok(model);
		}
	}
}
