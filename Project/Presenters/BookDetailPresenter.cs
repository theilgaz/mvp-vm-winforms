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
    public class BookDetailPresenter
    {
        private readonly IBookDetailView _view;

        private BookViewModel _currentBook;

        public BookDetailPresenter(IBookDetailView view, BookViewModel currentBook)
        {
            _view = view;
            SetCurrentBook(currentBook);
        }

        public void SetCurrentBook(BookViewModel currentBook)
        {
            _currentBook = currentBook;
            _view.SetCurrentBook(_currentBook);
        }

        public void SaveBook()
        {
            if (_currentBook.ViewMode == ViewMode.Insert)
            {
                BookRepository.Instance.InsertBook(_currentBook.Book);
            }
            else if (_currentBook.ViewMode == ViewMode.Update)
            {
                BookRepository.Instance.UpdateBook(_currentBook.Book);
            }
            else
            {
                _view.ShowError("Kitap kaydedilirken bir hata oluştu");
            }
            _view.Close();
        }

        public void Cancel()
        {
            _view.Close();
        }
    }
}
