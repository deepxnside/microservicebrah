using Discount.API.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Entities;

public class DbInitializer 
{
    
    private readonly ModelBuilder modelBuilder;
    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
        
    }

    public void SeedData()
    {
         
        
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon(){ ProductName = "Huawei",Description = "+999 credits",Amount = 0},
            new Coupon(){ ProductName = "Apple",Description = "China No 2",Amount = 0}
            

        );
    }
}