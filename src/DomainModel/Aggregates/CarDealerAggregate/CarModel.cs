using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Aggregates.CarDealerAggregate
{
    [Owned]
    public class CarModel
    {
        public string CarModelId { get; set; }

        public string Name { get; set; }
    }
}