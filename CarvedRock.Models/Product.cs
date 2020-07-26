using CarvedRock.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarvedRock.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductReviews = new HashSet<ProductReview>();
        }

        [StringLength(100)]
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}
