using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace project
{ 
    public partial class RegisterForm : Form
    {
        private Library library;
        public RegisterForm(Library library)
        {
            InitializeComponent();
            this.library = library;

        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Ruppin's Library\nPlease register first");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string id = textBox2.Text;

            // checking if the member is existing in the list
            bool memberExists = false;
            foreach (var member in library.Members)
            {
                if (member.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && member.MemberID.Equals(id))
                {
                    memberExists = true;
                    break;
                }
            }

            if (!memberExists)
            {
                // adding new member if not exist
                library.Members.Add(new Member(id, name));
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Member already exists.");
                return;
            }


            OptionForm form2 = new OptionForm(library); // new form, Pass the library instance to the form
            form2.Show(); 
            this.Hide(); // hiding the current form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
