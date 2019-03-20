using System.ComponentModel.DataAnnotations.Schema;

public class BrandByGroup
{
    public int Id { get; set; }
    public int brandId { get; set; }
    [ForeignKey("brandId")]
    public Brand Brand { get; set; }
    public int groupId { get; set; }
    [ForeignKey("groupId")]
    public Group Group { get; set; }
}