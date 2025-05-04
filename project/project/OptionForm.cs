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
    public partial class OptionForm : Form
    {
        private Library library; // Add this to hold the library instance

        public OptionForm(Library library) // Modify the constructor to accept a Library instance
        {
            InitializeComponent();
            this.library = library; // Initialize the library instance
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectBookForm form3;

            if (radioButton1.Checked)
            {
                form3 = new SelectBookForm(library); // Pass the library instance to the form
                form3.Show();
                this.Hide(); // Hide the current form
            }
            else if (radioButton2.Checked)
            {
                form3 = new SelectBookForm(library); // Pass the library instance to the form
                form3.Show();
                this.Hide(); // Hide the current form
            }
        }
    }
}