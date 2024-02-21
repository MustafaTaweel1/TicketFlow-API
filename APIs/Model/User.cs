using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Model
{
    public class User
    {
        public int id { get; set; }
        public required int userUN { get; set; }
        public required string userName { get; set; }
        public required string email { get; set; }

        [DataType(DataType.Password)]
        public required string password { get; set; }

    }
}
