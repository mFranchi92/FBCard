using System.ComponentModel.DataAnnotations;

namespace FBCard.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(16)]
        public string Number { get; set; }
        [Required]
        public string ExpDate { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public int CVV { get; set; }
    }
}
