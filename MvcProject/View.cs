using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvcProject
{
    public partial class View : Form, IView
    {
        public View(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
            Controller.Model.TextLoaded += Model_TextLoaded;
        }

        void Model_TextLoaded(object sender, EventArgs e)
        {
            MyText.Text = Controller.Model.Text;
        }

        public Controller Controller { get; set; }

        private void Load_Click(object sender, EventArgs e)
        {
            Controller.LoadFromFile();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Controller.SaveFile();
        }

        private void MyText_TextChanged(object sender, EventArgs e)
        {
            Controller.SetText(MyText.Text);
        }
    }
}
