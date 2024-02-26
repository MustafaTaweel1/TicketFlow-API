using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Model
{
	[Table("users")]
	public class User
    {
        public int id { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
        public string email { get; set; }
		[Required]
		[MaxLength(50),MinLength(6)]
		public string name { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string password { get; set; }



	}
}
