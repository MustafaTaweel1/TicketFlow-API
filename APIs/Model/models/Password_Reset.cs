using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Model.models
{
    public class Password_Reset
    {
        public int id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string token { get; set; }
        public DateTime created_at { get; set; }

    }
}
