using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UsersInfo
{
    public int Id { get; set; }

    public int IdUser { get; set; }
   
    [ForeignKey("IdUser")]
    public User user { get; set;}
    [StringLength(255)]
    public string fName { get; set; }
    [StringLength(255)]
    public string lName { get; set; }
    [StringLength(255)]
    public string userName { get; set; }
    [StringLength(255)]
    public string adresa { get; set; }
    [StringLength(255)]
    public string grad { get; set; }

    public int postalCode { get; set; }
    [StringLength(255)]
    public string brTelefona { get; set; }
}