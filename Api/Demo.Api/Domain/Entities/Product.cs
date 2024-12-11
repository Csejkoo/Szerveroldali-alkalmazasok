using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Domain.Entities
{
    [Table("product")]
    public record class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("product_name")]
        [MaxLength(100)]
        public string? ProductName { get; set; }
        [Column("product_code")]
        [MaxLength(10)]
        public string? ProductDescription { get; set; }
        [Column("price", TypeName= "decimal(7, 2)")]
        public decimal ProductPrice { get; set; }
    }
}
