using System.ComponentModel.DataAnnotations;

public class Group
{
    public int Id { get; set; }
    [StringLength(255)]
    public string Name { get; set; }
}