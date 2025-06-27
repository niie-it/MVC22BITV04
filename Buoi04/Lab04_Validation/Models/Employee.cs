using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab04_Validation.Models
{
	public class Employee
	{
		public int Id { get; set; }

		[Display(Name = "Mã nhân viên")]
		[Remote(controller:"Employee", action:"IsExistedEmployee")]
		public string EmployeeNo { get; set; }

		[Display(Name = "Họ tên")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Họ tên từ 3 .. 100 kí tự")]
		public string FullName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[EmailAddress]
		[Compare("Email", ErrorMessage = "Email chưa khớp")]
		public string ConfirmEmail { get; set; }

		[Url]
		public string? Website { get; set; }

		[DataType(DataType.Date)]
		[BirthDateCheck]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Giới tính")]
		public bool Gender { get; set; } = true;

		[Display(Name = "Lương")]
		[Range(0, double.MaxValue)]
		public double Salary { get; set; }

		[Display(Name = "Bán thời gian")]
		public bool IsPartTime { get; set; } = false;

		[Display(Name = "Địa chỉ")]
		[RegularExpression("[a-zA-Z 0-9]*")]
		public string Address { get; set; }

		[Display(Name = "Điện thoại")]
		[RegularExpression("0[3789][0-9]{8}")]
		public string Phone { get; set; }

		[Display(Name = "Số tài khoản")]
		[DataType(DataType.CreditCard)]
		public string? CreditCard { get; set; }

		[Display(Name = "Thông tin thêm")]
		[DataType(DataType.MultilineText)]
		[MaxLength(255, ErrorMessage = "Tối đa 255 kí tự")]
		public string? Description { get; set; }

	}

	public class BirthDateCheckAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var birthDate = (DateTime)value;
			if (DateTime.Now.Year - birthDate.Year < 10)
			{
				return new ValidationResult("Chưa đủ 10 tuổi");
			}
			if (DateTime.Now.Year - birthDate.Year > 65)
			{
				return new ValidationResult("Quá tuổi");
			}
			return ValidationResult.Success;
		}
	}
}
