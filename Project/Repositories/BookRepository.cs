using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        private static readonly object Lock = new object();
        private static volatile BookRepository _instance;

        public BookRepository()
        {
            _books = new List<Book>();
            InitBooks();
        }

        public static BookRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BookRepository();
                        }
                    }
                }

                return _instance;
            }
        }

        private void InitBooks()
        {
            _books.Add(new Book { Author = "R.A Salvatore", Genre = "Fantastik Kurgu", Name = "Ana Yurt", Page = 352 });
            _books.Add(new Book { Author = "Arthur C. Clarke", Genre = "Bilim Kurgu", Name = "2001: Bir Uzay Efsanesi", Page = 365 });
            _books.Add(new Book { Author = "Robert Jordan", Genre = "Fantastik Kurgu", Name = "Zaman çarkı : Kılıçtan Taç", Page = 895 });
            _books.Add(new Book { Author = "Emre Kongar", Genre = "Tarih/Siyaset", Name = "Tarihimizle Yüzleşmek", Page = 246 });
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public List<Book> GetAllBooks(string filter)
        {
            return _books.Where(x => x.Author.Contains(filter) || x.Genre.Contains(filter) || x.Name.Contains(filter) || x.Page.ToString().Contains(filter)).ToList();
        }

        public void InsertBook(Book book)
        {
            // Business operations
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            // Business operations
        }
    }
}
