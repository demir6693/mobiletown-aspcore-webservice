using System.ComponentModel.DataAnnotations.Schema;

public class OrderItems
{   
    public int Id { get; set; }

    public int orderId { get; set; }
    [ForeignKey("orderId")]
    public Order Order { get; set; }

    public int productId { get; set; }
    [ForeignKey("productId")]
    public Product Product { get; set; }
    public int? kolicina { get; set; }
}