using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id {get; set;}
    
    [StringLength(255)]
    public string Name {get; set;}

    [StringLength(255)]
    public string LastName {get; set;}
}