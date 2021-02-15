using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Aggregates.CarDealerAggregate
{
    public class CarDealer
    {
        public string CarDealerId { get; set; }

        public string Name { get; set; }

        public List<CarMake> Deals { get; set; }
    }

    public class CarDealerEntityConfiguration : IEntityTypeConfiguration<CarDealer>
    {
        public void Configure(EntityTypeBuilder<CarDealer> builder)
        {
            builder.HasKey(p => p.CarDealerId);
            builder.ToContainer("Cars");
        }
    }
}