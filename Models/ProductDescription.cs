using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductDescription
{
    public int Id { get; set; }
    public int productId { get; set; }
    [ForeignKey("productId")]
    public Product Product { get; set; }
    [StringLength(255)]
    public string descriptionName { get; set; }
    [StringLength(255)]
    public string description { get; set; }
}