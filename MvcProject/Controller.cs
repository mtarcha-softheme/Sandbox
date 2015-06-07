using System;
using System.Windows.Forms;

namespace MvcProject
{
    public class Controller
    {
        private IView _view;
        private Model _model;
        
        public Controller()
        {
            _model = new Model();
        }
        
        public Model Model
        {
            get { return _model; }
        }

        public View CreateAndReturnView()
        {
            _view = new View(this);
            return (View)_view;
        }

        public void SaveFile()
        {
            _model.SaveFile();
        }

        public void LoadFromFile()
        {
            _model.LoadFromFile();
        }

        public void SetText(string text)
        {
            _model.Text = text;
        }
        
    }
}