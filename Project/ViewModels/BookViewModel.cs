using Project.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Project.ViewModels
{
    public class BookViewModel
    {
        private readonly Book _book;

        public BookViewModel(Book book)
        {
            _book = book;
        }

        public Book Book
        {
            get
            {
                return _book;
            }
        }

        public string Name
        {
            get { return _book.Name; }
            set { _book.Name = value; }
        }

        public string Author
        {
            get { return _book.Author; }
            set { _book.Author = value; }
        }

        public string Genre
        {
            get { return _book.Genre; }
            set { _book.Genre = value; }
        }

        public string Page
        {
            get { return _book.Page.ToString(CultureInfo.InvariantCulture); }
            set
            {
                int page;
                bool parsed = int.TryParse(value, out page);
                ShowPageValidationError = !parsed;

                if (parsed)
                {
                    _book.Page = page;
                }
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Author) && !string.IsNullOrEmpty(Genre) && !string.IsNullOrEmpty(Page) && !ShowPageValidationError;
            }
        }

        public bool ShowPageValidationError { get; set; }

        public ViewMode ViewMode { get; set; }

    }

    public enum ViewMode
    {
        Insert,
        Update
    }
}
