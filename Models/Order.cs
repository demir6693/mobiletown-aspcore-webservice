using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    public int Id { get; set; }

    public int userInfoId { get; set; }

    [ForeignKey("userInfoId")]
    public UsersInfo UsersInfo { get; set; }

    public int cartId { get; set; }

    [ForeignKey("cartId")]
    public Cart Cart { get; set; }

    public System.DateTime dateOrder { get; set;}
}