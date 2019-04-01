using System.ComponentModel.DataAnnotations.Schema;

public class ReceiptItems
{
    public int Id { get; set; }
    public int receiptId { get; set; }
    
    [ForeignKey("receiptId")]
    public Receipt Receipt { get; set; }
    public int productId { get; set; }
    public Product Product { get; set; }
    public int? kolicina { get; set; }
}