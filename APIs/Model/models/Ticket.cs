using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Model.models
{
    [Table("tickets")]
    public class Ticket
    {
        public int id { get; set; }

        [Required]
        public string title { get; set; }


        [Required]
        public int department { get; set; }

        [Required]
        public int status { get; set; }

        //update
        [Required]
        public int id_create { get; set; }

        [Required]
        public int take_user { get; set; }
        [ForeignKey("id_create")]
        public User Creator { get; set; }

        // Navigation property for the user who took the ticket
        [ForeignKey("take_user")]
        public User Handler { get; set; }

    }
}
