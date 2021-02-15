using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Aggregates.CarAggregate
{
    [Owned]
    public class CarMake
    {
        public string CarMakeId { get; set; }

        public string Name { get; set; }
    }
}