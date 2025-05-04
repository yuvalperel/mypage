using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class SelectBookForm : Form
    {
        private Library library;

        public Book SelectedBook { get; set; }
        public SelectBookForm(Library library)
        {
            InitializeComponent();
            this.library = library;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Load available books into the ComboBox
            comboBox1.DataSource = library.Books
                                              .Where(b => !b.IsBorrowed)
                                              .Select(b => b.BookName)
                                              .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedBookTitle = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedBookTitle))
            {
                MessageBox.Show("Please select a book.");
                return;
            }
            // Find the selected book in the library
            SelectedBook = library.Books.FirstOrDefault(b => b.BookName.Equals(selectedBookTitle, StringComparison.OrdinalIgnoreCase));

            if (SelectedBook != null)
            {
                // Assuming you have the member ID, you can call the BorrowBook method here
                // Example: library.BorrowBook(memberID, SelectedBook.BookName);

                MessageBox.Show($"{SelectedBook.BookName} has been selected.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selected book could not be found.");
            }
        }
    }
}

