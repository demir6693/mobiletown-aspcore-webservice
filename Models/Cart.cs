using System.ComponentModel.DataAnnotations.Schema;

public class  Cart
{
    public int Id { get; set; }

    public int userId { get; set; }

    [ForeignKey("userId")]
    public User User { get; set; }

    public System.DateTime dateCreated { get; set; }
}