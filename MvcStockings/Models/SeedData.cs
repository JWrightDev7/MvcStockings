using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MvcStockings.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MvcStockings.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcStockingsContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<MvcStockingsContext>>()))
            {
                if (context.Stocking.Any())
                {
                    return; //There is no need to seed the DB because there is already seeded information in the database.
                }

                //Creating the data to seed the database incase there is no information in the DB
                context.Stocking.AddRange(
                    new Stocking
                    {
                        Name = "Medical Compression Stockings",
                        Type = "Compression",
                        Material = "Nylon, Spandex, Cotton",
                        Price = 7.98,
                        Review = 3
                    },

                    new Stocking
                    {
                        Name = "Striped Stockings",
                        Type = "Stripe pattern",
                        Material = "Acrylic Staple Fibre",
                        Price = 10.40,
                        Review = 2
                    },
                    new Stocking
                    {
                        Name = "AmongUs Stockings",
                        Type = "Patterned",
                        Material = "Terylene",
                        Price = 12.16,
                        Review = 3
                    },
                    new Stocking
                    {
                        Name = "Ladies Knee High",
                        Type = "Knee High",
                        Material = "Cotton, Polyester, Spandex",
                        Price = 7.97,
                        Review = 5
                    },
                    new Stocking
                    {
                        Name = "Thigh High Opaque Stockings",
                        Type = "Opaque",
                        Material = "Nylon",
                        Price = 34.18,
                        Review = 4
                    },
                    new Stocking
                    {
                        Name = "Christmas Stockings",
                        Type = "Holiday, Decorative",
                        Material = "Fabric",
                        Price = 11.99,
                        Review = 5
                    },
                    new Stocking
                    {
                        Name = "Scrunch Top Stockings",
                        Type = "Scrunched Top",
                        Material = "Polyester, Nylon, Spandex",
                        Price = 12.00,
                        Review = 5
                    },
                    new Stocking
                    {
                        Name = "Transparent Stripe Stockings",
                        Type = "transparent",
                        Material = "Spandex",
                        Price = 8.90,
                        Review = 3
                    },
                    new Stocking
                    {
                        Name = "Sport Compression Stockings",
                        Type = "Sport Compression",
                        Material = "Polyamid, lycra",
                        Price = 30.00,
                        Review = 5
                    },
                    new Stocking
                    {
                        Name = "Winter Stockings",
                        Type = "Warm",
                        Material = "Cotton",
                        Price = 16.29,
                        Review = 4
                    }
                );
                //Commiting the seed data to the database and saving it
                context.SaveChanges();
            }
        }
    }
}
