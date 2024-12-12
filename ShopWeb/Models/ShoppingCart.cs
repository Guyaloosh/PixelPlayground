using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWeb.Models
{
    public class ShoppingCart
    {

        public List<Product> products;
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product product { get; set; }
        [Range(1,1000,ErrorMessage ="please enter a value between 1 to 1000")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }
        [NotMapped]
        public decimal Price { get; set; }
    }
}
