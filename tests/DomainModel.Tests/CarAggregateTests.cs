using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainModel.Tests
{
    public class CarAggregateTests
    {
        public CarAggregateTests()
        {

        }

        private static CosmosDbContext context;

        public async Task<CosmosDbContext> InitializeContext()
        {
            if (context is null)
            {
                context = new CosmosDbContext(new DbContextOptions<CosmosDbContext>());

                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
            }

            return context;
        }

        [Fact]
        public async Task CarTest()
        {
            var c = await InitializeContext();

            var peugeotId = Guid.NewGuid();
            var teslaId = Guid.NewGuid();

            var model3Id = Guid.NewGuid();
            var e208Id = Guid.NewGuid();

            c.Cars.Add(new Aggregates.CarAggregate.Car()
            {
                CarId = Guid.NewGuid().ToString(),
                Name = "Car 1",
                Model = new Aggregates.CarAggregate.CarModel()
                {
                    CarModelId = e208Id.ToString(),
                    Name = "e-208",
                    Make = new Aggregates.CarAggregate.CarMake() 
                    {
                        CarMakeId = peugeotId.ToString(),
                        Name = "Peugeot",
                    }
                }
            });

            c.Cars.Add(new Aggregates.CarAggregate.Car()
            {
                CarId = Guid.NewGuid().ToString(),
                Name = "Car 2",
                Model = new Aggregates.CarAggregate.CarModel()
                {
                    CarModelId = model3Id.ToString(),
                    Name = "Model 3",
                    Make = new Aggregates.CarAggregate.CarMake()
                    {
                        CarMakeId = teslaId.ToString(),
                        Name = "Tesla",
                    }
                }
            });

            c.Dealers.Add(new Aggregates.CarDealerAggregate.CarDealer()
            {
                CarDealerId = Guid.NewGuid().ToString(),
                Name = "Tesla Dealer Odense",
                Deals = new List<Aggregates.CarDealerAggregate.CarMake>() 
                { 
                    new Aggregates.CarDealerAggregate.CarMake() 
                    {
                        CarMakeId = teslaId.ToString(),
                        Name = "Tesla",
                        Produces = new List<Aggregates.CarDealerAggregate.CarModel>()
                        {
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "Model S"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = model3Id.ToString(),
                                Name = "Model 3"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "Model X"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "Model Y"
                            },
                        }
                    }
                }
            });

            c.Dealers.Add(new Aggregates.CarDealerAggregate.CarDealer()
            {
                CarDealerId = Guid.NewGuid().ToString(),
                Name = "Peugeot Odense",
                Deals = new List<Aggregates.CarDealerAggregate.CarMake>()
                {
                    new Aggregates.CarDealerAggregate.CarMake()
                    {
                        CarMakeId = peugeotId.ToString(),
                        Name = "Peugeot",
                        Produces = new List<Aggregates.CarDealerAggregate.CarModel>()
                        {
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "e-2008"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = e208Id.ToString(),
                                Name = "e-208"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "308"
                            },
                            new Aggregates.CarDealerAggregate.CarModel()
                            {
                                CarModelId = Guid.NewGuid().ToString(),
                                Name = "3008"
                            },
                        }
                    }
                }
            });
            await c.SaveChangesAsync();
        }
    }
}