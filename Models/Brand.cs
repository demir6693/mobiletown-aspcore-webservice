using System.ComponentModel.DataAnnotations;

public class Brand
{
    public int Id { get; set; }
    [StringLength(255)]
    public string Name { get; set; }
}