using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Model
{
    public class Currency
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string currency { get; set; }



        [Column(TypeName = "decimal(9, 5)")]
        public decimal price { get; set; }
    }
}
