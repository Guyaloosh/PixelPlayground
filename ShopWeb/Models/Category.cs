using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models
{
    public class Category
    {
        [Key] //data  annotation - make the Id to be the Primary key , by default Id is the primary key 
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be between 1 and 100.")] 
        public int DisplayOrder { get; set; }
    }
}
