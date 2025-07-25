
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
	public class CitizenExpireDateAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var data = (DateTime?)value;
			if (data == null || data.Value < DateTime.Now)
			{
				return new ValidationResult("Citizen Id is expired");
			}
			return ValidationResult.Success;
		}
	}
}