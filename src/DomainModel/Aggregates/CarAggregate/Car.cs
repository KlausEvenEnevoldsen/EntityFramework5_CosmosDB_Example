using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Aggregates.CarAggregate
{
    public class Car
    {
        public string CarId { get; set; }

        public string Name { get; set; }

        public CarModel Model { get; set; }
    }

    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(p => p.CarId);
            builder.ToContainer("Cars");
        }
    }
}