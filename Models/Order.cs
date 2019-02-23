using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    public int Id { get; set; }

    public int userId { get; set; }

    [ForeignKey("userId")]
    public User User { get; set; }

    public int cartId { get; set; }

    [ForeignKey("cartId")]
    public Cart Cart { get; set; }

    public System.DateTime dateOrder { get; set;}
}