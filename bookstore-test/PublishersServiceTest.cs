using BookStore.Data;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace bookstore_test
{
    public class PublishersServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;

        AppDbContext context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var publishers = new List<Publisher>()
            {
                new Publisher() 
                {
                    Id = 1,
                    Name = "publisher 1"
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "publisher 2"
                },
                new Publisher()
                {
                    Id = 3,
                    Name = "publisher 3"
                }
            };
            context.Publishers.AddRange(publishers);

            var authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    FullName = "Author 1"
                },
                new Author()
                {
                    Id = 2,
                    FullName = "Author 2"
                }
            };
            context.Authors.AddRange(authors);

            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Book 1 Description",
                    IsRead = false,
                    Genre = "Genre",
                    CoverUrl = "https://sanet.pics/storage-7/1221/9mCOROwJtoNN4OVMZFG51FRR6MucjVcs.jpg",
                    DateAdded = DateTime.Now.AddDays(-10),
                    PublisherId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "Book 2 Description",
                    IsRead = false,
                    Genre = "Genre",
                    CoverUrl = "https://sanet.pics/storage-7/1221/9mCOROwJtoNN4OVMZFG51FRR6MucjVcs.jpg",
                    DateAdded = DateTime.Now.AddDays(-10),
                    PublisherId = 1
                }
            };
            context.Books.AddRange(books);

            var book_authors = new List<Book_Author>()
            {
                new Book_Author()
                {
                    Id= 1,
                    BookId = 1,
                    AuthorId = 1
                },
                new Book_Author()
                {
                    Id= 2,
                    BookId = 1,
                    AuthorId = 2
                },
                new Book_Author()
                {
                    Id= 3,
                    BookId = 2,
                    AuthorId = 2
                }
            };
            context.Book_Authors.AddRange(book_authors);

            context.SaveChanges();
        }

    }
}