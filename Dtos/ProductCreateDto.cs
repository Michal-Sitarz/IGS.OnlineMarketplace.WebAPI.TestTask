using System.ComponentModel.DataAnnotations;

namespace IGS.OnlineMarketplace.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price is required and cannot be smaller than 0.01")]
        public double Price { get; set; }
    }
}