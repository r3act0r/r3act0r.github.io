using ADCD.Data;
using ADCD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace ADCD.Models
{
    public class SeedData
    {
        static string imgPath = "wwwroot/img/Cranes/";
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Cranes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cranes.AddRange(
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "17 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$105.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "17Ton.jpg"))
                    },
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "25 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$125.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "25Ton.jpg"))
                    },
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "35 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$150.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "35Ton.jpg"))
                    },
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "60 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$185.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "60Ton.jpg"))
                    },
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "75 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$205.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "75Ton.jpg"))
                    },
                    new Crane
                    {
                        CraneType = "Boom Truck",
                        Capacity = "100 Ton",
                        BoomLength = "PH",
                        JibLength = "PH",
                        PerHourRate = "$265.00",
                        Image = @"data:image / jpeg; base64," + Convert.ToBase64String(File.ReadAllBytes(imgPath + "100Ton.jpg"))
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
