using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Model
{
    [Table("tickets")]
    public class Ticket
    {
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        [MaxLength(50), MinLength(5)]
        public string creatorName { get; set; }

        [Required]
        public string department { get; set; }

        [Required]
        public int status { get; set; }

        [Required]
        public int id_user { get; set; }

    }
}
