using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Receipt
{
    public int Id { get; set; }
    public int userInfoId { get; set; }

    [ForeignKey("userInfoId")]
    public UsersInfo UsersInfo { get; set; }
    public DateTime DateofReceipt { get; set; }

}