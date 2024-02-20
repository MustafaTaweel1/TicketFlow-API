using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Model
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }



    }
}
