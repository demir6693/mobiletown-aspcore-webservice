using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductPicture
{
    public int Id { get; set; }
    
    public int idProd { get; set; }
    
    [ForeignKey("idProd")]
    public Product Product { get; set; }
    
    public string picture { get; set; }
}