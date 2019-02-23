using System.ComponentModel.DataAnnotations.Schema;

public class CartItems
{
    public int Id { get; set; }

    public int productId { get; set; }

    [ForeignKey("productId")]
    public Product Product { get; set; }

    public int cartId { get; set; }

    [ForeignKey("cartId")]
    public Cart Cart { get; set; }

    public int kolicina { get; set; }
}