using DomainModel.Aggregates;
using DomainModel.Aggregates.CarAggregate;
using DomainModel.Aggregates.CarDealerAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CosmosDbContext : DbContext
    {
        public DbSet<Car> Cars{ get; set; }

        public DbSet<CarDealer> Dealers { get; set; }

        public CosmosDbContext(DbContextOptions<CosmosDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                databaseName: "Automobiles");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarDealerEntityConfiguration());
        }
    }
}