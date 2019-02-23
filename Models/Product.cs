using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Name;

    public decimal Msrp { get; set; }

    public decimal price { get; set; }
    
    [StringLength(65535)]
    public string picture { get; set; }

    public int groupId { get; set; }
    
    [ForeignKey("groupId")]
    public Group Group { get; set; }

    public int brandId { get; set; }
    
    [ForeignKey("brandId")]
    public Brand Brand { get; set; }
}