using CarvedRock.Models.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace CarvedRock.Models
{
    public class ProductReview : BaseEntity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }

        public string Review { get; set; }
    }
}
