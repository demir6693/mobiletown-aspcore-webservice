using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id {get; set;}
    
    [StringLength(255)]
    public string Email {get; set;}

    [StringLength(255)]
    public string Password {get; set;}
}