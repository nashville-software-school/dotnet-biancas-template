using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BiancasBikes.Models;
using Microsoft.AspNetCore.Identity;

namespace BiancasBikes.Data;
public class BiancasBikesDbContext : IdentityDbContext<UserProfile, IdentityRole<int>, int>
{
    private readonly IConfiguration _configuration;
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<BikeType> BikeTypes { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public BiancasBikesDbContext(DbContextOptions<BiancasBikesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
        {
            Id = 1,
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            UserName = "Administrator",
            Email = "admina@strator.comx",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
        {
            RoleId = 1,
            UserId = 1
        });

        modelBuilder.Entity<Owner>().HasData(
        [
            new Owner
            {
                Id = 1,
                Email="bike.owner@mail.comx",
                Name="Bike Owner",
                Address="421 Tenth Street",
                Telephone="123-456-7890"
            },
            new Owner
            {
                Id = 2,
                Email="una.cycle@mail.comx",
                Name="Una Cycle",
                Address="422 Eight Street",
                Telephone="555-555-5555"
            },
            new Owner {
                Id = 3,
                Email="velo.cipede@mail.comx",
                Name="Velo Cipede",
                Address="101 First Street",
                Telephone="555-555-5555"
            },
        ]);

        modelBuilder.Entity<BikeType>().HasData(
        [
            new BikeType {Id = 1, Name = "Mountain"},
            new BikeType {Id = 2, Name = "Racing"},
            new BikeType {Id = 3, Name = "Cruiser"},
        ]);

        modelBuilder.Entity<Bike>().HasData(
        [
            new Bike
            {
                Id = 1,
                Brand = "Schwinn",
                Color = "Blue",
                OwnerId = 1,
                BikeTypeId = 1
            },
            new Bike
            {
                Id = 2,
                Brand = "Huffy",
                Color = "Red",
                OwnerId = 1,
                BikeTypeId = 3
            },
            new Bike
            {
                Id = 3,
                Brand = "Cannondale",
                Color = "Purple",
                OwnerId = 2,
                BikeTypeId = 2
            },
            new Bike
            {
                Id = 4,
                Brand = "Giant",
                Color = "Green",
                OwnerId = 3,
                BikeTypeId = 1
            },
        ]);

        modelBuilder.Entity<WorkOrder>().HasData(
        [
            new WorkOrder
            {
                Id = 1,
                BikeId = 1,
                Description = "Flat Tire",
                DateInitiated = new DateTime(2023, 7, 15)
            },
            new WorkOrder
            {
                Id = 2,
                BikeId = 3,
                Description = "Bent Fork",
                DateInitiated = new DateTime(2023, 7, 12),
                DateCompleted = new DateTime(2023, 7, 15),
                UserProfileId = 1
            }
        ]);
    }
}