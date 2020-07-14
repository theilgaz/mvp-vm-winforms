using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Views
{
    public interface IBooksView
    {
        void FillBooks(IEnumerable<BookViewModel> bookViewModels);
    }
}
