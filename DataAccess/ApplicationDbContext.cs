using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<StaticFooter> StaticFooters { get; set; }
        public DbSet<WhatWeDo> WhatWeDos { get; set; }
        public DbSet<WhyWeUs> WhyWeUss { get; set; }
        public DbSet<AboutUsText> AboutUsTexts { get; set; }
        public DbSet<Contact> Contacts { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserToRoles");
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "abcd53!d",
                    Name="admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp="dwdwsderf54edc"
                }
                );
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1023",
                    Email = "admin@gmail.com",
                    PhoneNumber = "+994-55-800-67-97",
                    UserName = "tumyemadmin",
                    ConcurrencyStamp = "sdchsuicmkms",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    NormalizedUserName = "TUMYEMADMIN",
                    TwoFactorEnabled = true,
                    AccessFailedCount = 1,
                    LockoutEnd = DateTime.Now,
                    PasswordHash = "TumYemAdmin123_",
                    SecurityStamp = null,
                });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "abcd53!d",
                    UserId= "1023"
                });
            builder.Entity<Category>().HasData(
                new Category
                {
                    ID = 1,
                    Name = "Toyuq Yemi",
                    IconUrl = "https://www.pngfind.com/pngs/m/103-1032042_png-file-svg-chicken-icon-png-white-transparent.png"
                }
                );
            builder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name= "Kənd ənənə yemi",
                    Description="Coxlu istifade ucun nezerde tutulub ve keyfiyyeti Iso9001 standartlarina uygundur",
                    Price=10,
                    Discount=0,
                    InStock=5,
                    IsDay=false,
                    IsDeleted=false,
                    IsFeatured=false,
                    PublishDate=DateTime.Now,
                    PhotoUrl= "http://gilanfeed.com/media/product_photo/large/37.jpg",
                    SKU="548",
                    CategoryID=1,
                }
                );
            builder.Entity<Slider>().HasData(
                new Slider
                {
                    ID= 1,
                    HeaderLeft="TUM",
                    HeaderRight="YEM",
                    BackgroundPhoto= "https://organicfeeds.com/wp-content/uploads/2020/05/How-Much-You-Should-Feed-Chickens-Per-Day.jpg",
                    Summary="Bütün məhsullarımıza baxmaq üçün məhsullar düyməsinə toxunaraq keçib baxa bilərsiniz",
                    IsShow=true
                }
                );

            
            
        }



    }
}