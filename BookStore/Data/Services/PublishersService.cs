using BookStore.Data.Models;
using BookStore.Data.Models.ViewModel;
using BookStore.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookStore.Data.Services
{
    public class PublishersService
    {
        public AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StrigStartWithNumber(publisher.Name))
            {
                throw new PublisherNameException("Name starts with number", publisher.Name);
            }

            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }

        private bool StrigStartWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
