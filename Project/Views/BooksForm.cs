using Project.Presenters;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views
{
    public partial class BooksForm : Form, IBooksView
    {
        private readonly BooksPresenter _presenter;

        public BooksForm()
        {
            InitializeComponent();
            _presenter = new BooksPresenter(this);
        }

        public void FillBooks(IEnumerable<BookViewModel> bookViewModels)
        {
            bindingSource1.DataSource = bookViewModels;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BookViewModel bvm = dataGridView1.Rows[e.RowIndex].DataBoundItem as BookViewModel;
            _presenter.EditBookClicked(bvm);
        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            _presenter.AddBookClicked();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchClicked(txSearchBox.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;
            BookViewModel bvm = dataGridView1.Rows[index].DataBoundItem as BookViewModel;
            _presenter.DeleteBookClicked(bvm);
        }
    }
}
