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

    public virtual DbSet<UsersInfo> UsersInfo {get; set;}

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }
    
    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItems> CartItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<TitlePictureProduct> TitlePictureProducts { get; set; }

    public virtual DbSet<OrderItems> OrderItems { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=localhost;database=webshopmobiletown;user=root;password=;CharSet=utf8;");
        }
    }
}