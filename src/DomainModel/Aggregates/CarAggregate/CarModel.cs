using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Aggregates.CarAggregate
{
    [Owned]
    public class CarModel
    {
        public string CarModelId { get; set; }

        public string Name { get; set; }

        public CarMake Make { get; set; }
    }
}