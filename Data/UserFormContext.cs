using BlueBird.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueBird.Data
{
    public class UserFormContext : DbContext
    {
        public DbSet<Sector> Sector { get; set; }
        public DbSet<SectorData> SectorData { get; set; }
        public DbSet<UserFormFilling> UserFormFilling { get; set; }

        public UserFormContext(DbContextOptions<UserFormContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SectorData>(entity => {
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<SectorData>()
                .HasIndex(u => u.Value)
                .IsUnique();

            Guid parentIdLvl1;
            Guid parentIdLvl2;
            Guid parentIdLvl3;

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl1 = Guid.NewGuid(), Value = 1, Name = "Manufacturing" });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 19, Name = "Construction materials", ParentId = parentIdLvl1 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 18, Name = "Electronics and Optics", ParentId = parentIdLvl1 },
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 6, Name = "Food and Beverage", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 342, Name = "Bakery & confectionery products", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 43, Name = "Beverages", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 42, Name = "Fish & fish products", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 40, Name = "Meat & meat products", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 39, Name = "Milk & dairy products", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 437, Name = "Other", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 378, Name = "Sweets & snack food", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 13, Name = "Furniture", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 389, Name = "Bathroom/sauna", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 385, Name = "Bedroom", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 390, Name = "Children's room", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 98, Name = "Kitchen", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 101, Name = "Living room", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 392, Name = "Office", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 394, Name = "Other (Furniture)", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 341, Name = "Outdoor", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 99, Name = "Project furniture", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 12, Name = "Machinery", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 94, Name = "Machinery components", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 91, Name = "Machinery equipment/tools", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 224, Name = "Manufacture of machinery", ParentId = parentIdLvl2 },
                new SectorData { SectorId = parentIdLvl3 = Guid.NewGuid(), Value = 97, Name = "Maritime", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 271, Name = "Aluminium and steel workboats", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 269, Name = "Boat/Yacht building", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 230, Name = "Ship repair and conversion", ParentId = parentIdLvl3 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 93, Name = "Metal structures", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 508, Name = "Other", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 227, Name = "Repair and maintenance service", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 11, Name = "Metalworking", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 67, Name = "Construction of metal structures", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 263, Name = "Houses and buildings", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 267, Name = "Metal products", ParentId = parentIdLvl2 },
                new SectorData { SectorId = parentIdLvl3 = Guid.NewGuid(), Value = 542, Name = "Metal works", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 75, Name = "CNC-machining", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 62, Name = "Forgings, Fasteners", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 69, Name = "Gas, Plasma, Laser cutting", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 66, Name = "MIG, TIG, Aluminum welding", ParentId = parentIdLvl3 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 9, Name = "Plastic and Rubber", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 54, Name = "Packaging", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 556, Name = "Plastic goods", ParentId = parentIdLvl2 },
                new SectorData { SectorId = parentIdLvl3 = Guid.NewGuid(), Value = 559, Name = "Plastic processing technology", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 55, Name = "Blowing", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 57, Name = "Moulding", ParentId = parentIdLvl3 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 53, Name = "Plastics welding and processing", ParentId = parentIdLvl3 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 560, Name = "Plastic profiles", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 5, Name = "Printing", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 148, Name = "Advertising", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 150, Name = "Book/Periodicals printing", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 145, Name = "Labelling and packaging printing", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 7, Name = "Textile and Clothing", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 44, Name = "Clothing", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 45, Name = "Textile", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 8, Name = "Wood", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 337, Name = "Other (Wood)", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 51, Name = "Wooden building materials", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 47, Name = "Wooden houses", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl1 = Guid.NewGuid(), Value = 3, Name = "Other" });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 37, Name = "Creative industries", ParentId = parentIdLvl1 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 29, Name = "Energy technology", ParentId = parentIdLvl1 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 33, Name = "Environment", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = parentIdLvl1 = Guid.NewGuid(), Value = 2, Name = "Service" });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 25, Name = "Business services", ParentId = parentIdLvl1 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 35, Name = "Engineering", ParentId = parentIdLvl1 },
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 28, Name = "Information Technology and Telecommunications", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 581, Name = "Data processing, Web portals, E-marketing", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 576, Name = "Programming, Consultancy", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 121, Name = "Software, Hardware", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 122, Name = "Telecommunications", ParentId = parentIdLvl2 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 22, Name = "Tourism", ParentId = parentIdLvl1 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 141, Name = "Translation services", ParentId = parentIdLvl1 },
                new SectorData { SectorId = parentIdLvl2 = Guid.NewGuid(), Value = 21, Name = "Transport and Logistics", ParentId = parentIdLvl1 });

            modelBuilder.Entity<SectorData>().HasData(
                new SectorData { SectorId = Guid.NewGuid(), Value = 111, Name = "Air", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 114, Name = "Rail", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 112, Name = "Road", ParentId = parentIdLvl2 },
                new SectorData { SectorId = Guid.NewGuid(), Value = 113, Name = "Water", ParentId = parentIdLvl2 });
        }
    }
}
