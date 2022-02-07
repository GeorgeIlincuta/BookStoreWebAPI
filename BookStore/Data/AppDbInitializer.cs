using BookStore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Nefertiti, Queen and Pharaoh of Egypt: Her Life and Afterlife",
                        Description = "Egypt's sun queen magnificently revealed in a new book by renowned Egyptologist, Aidan Dodson",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https://sanet.pics/storage-8/0222/xVyUQXelFyC6kNFk3haU0XOdayijBO7G.jpg",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "The Wrecks of HM Frigates Assurance (1753) and Pomone (1811)",
                        Description = "With the thought of treasure, Isle of Wight islander, Derek Williams researched ancient local wreck records.",
                        IsRead = false,
                        Genre = "Biography",
                        CoverUrl = "https://sanet.pics/storage-8/0222/BXtkVlXEroyBZx8ori0pyRF7eCZxsbvK.jpg",
                        DateAdded = DateTime.Now
                    }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
