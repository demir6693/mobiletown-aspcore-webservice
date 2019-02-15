using Microsoft.EntityFrameworkCore;

public class webContextDb : DbContext
{
    public webContextDb()
    {

    }

    public webContextDb(DbContextOptions<webContextDb> options)
    :base(options)
    {

    }

    public virtual DbSet<User> User{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=5.79.70.193;database=webshopdb;user=root;password=IDMrcxUOSoup;");
        }
    }
}