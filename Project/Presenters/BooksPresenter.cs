using Project.Models;
using Project.Repositories;
using Project.ViewModels;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Presenters
{
    public class BooksPresenter
    {
        private readonly IBooksView _view;

        private IEnumerable<BookViewModel> _currentBooks;

        public BooksPresenter(IBooksView booksView)
        {
            _view = booksView;
            FillBooks();
        }

        public void AddBookClicked()
        {
            BookViewModel bvm = new BookViewModel(new Book());
            bvm.ViewMode = ViewMode.Insert;
            OpenBookDetailForm(bvm);
        }

        public void EditBookClicked(BookViewModel bookViewModel)
        {
            bookViewModel.ViewMode = ViewMode.Update;
            OpenBookDetailForm(bookViewModel);
        }

        private void FillBooks()
        {
            List<Book> books = BookRepository.Instance.GetAllBooks();
            _currentBooks = GetBookViewModels(books);
            _view.FillBooks(_currentBooks);
        }

        private IEnumerable<BookViewModel> GetBookViewModels(IEnumerable<Book> books)
        {
            return books.Select(b => new BookViewModel(b));
        }

        private void OpenBookDetailForm(BookViewModel bookViewModel)
        {
            using (BookDetailForm bookForm = new BookDetailForm(bookViewModel))
            {
                bookForm.ShowDialog();
            }
            FillBooks();
        }

    }
}
