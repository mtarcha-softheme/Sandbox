using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvcProject;

namespace MvpProject
{
    public partial class View : Form, IView
    {

        public View()
        {
            InitializeComponent();
        }

        public IController Controller { get; set; }

        public TextBox TextBoxProperty
        {
            get { return TextBox; }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            //Chek that Controller is not null.
            Controller.LoadFromFile();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Chek that Controller is not null.
            Controller.SaveToFile(TextBox.Text);
        }
    }
}
