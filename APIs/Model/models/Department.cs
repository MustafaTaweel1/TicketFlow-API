using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Model.models
{
	[Table("Department")]
	public class Department
	{
		public Department()
		{
			User = new List<User>();
		}
		public int Id { get; set; }
		public string DepartmentName { get; set; }
		public List<User> User { get; set; }


	}
}
