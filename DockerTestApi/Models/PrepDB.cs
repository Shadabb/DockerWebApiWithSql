using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DockerTestApi.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
        }

        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Appling Migrations.....");

            context.Database.Migrate();

            if (!context.Colours.Any())
            {
                System.Console.WriteLine("Adding data - seeding....");

                context.Colours.AddRange(
                    new colour() {ColourName = "Red"},
                    new colour() { ColourName = "Red" },
                    new colour() { ColourName = "Blue" },
                    new colour() { ColourName = "Green" },
                    new colour() { ColourName = "Yellow" },
                    new colour() { ColourName = "White" }
                    );

                    context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
