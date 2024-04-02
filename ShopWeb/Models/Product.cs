using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public decimal Price { get; set; }

        public decimal PublishPrice { get; set; }

        public int Sold { get; set; }  //number of copy solds

        public int Popularity { get; set; }


        public int Quantity { get; set; }


        public int MinAge { get; set; }

        
        public bool onSale { get; set; }

        
        public DateTime RealishDate { get; set; }

        //public bool isDigital {  get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        
        public string? ImageUrl { get; set; }

        public int Position {  get; set; }

        //public int tempQuantity { get; set; }
    }


}

