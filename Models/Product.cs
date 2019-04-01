using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Name { get; set; }

    public decimal Msrp { get; set; }

    public decimal price { get; set; }

    public int pictureId { get; set; }
    
    [ForeignKey("pictureId")]
    public TitlePictureProduct TitlePictureProduct { get; set; }
    public int groupId { get; set; }
    
    [ForeignKey("groupId")]
    public Group Group { get; set; }

    public int brandId { get; set; }
    
    [ForeignKey("brandId")]
    public Brand Brand { get; set; }
    
    [Column("stanje", TypeName = "bit")]
    [DefaultValue(true)]
    public bool? stanje { get; set; }
}