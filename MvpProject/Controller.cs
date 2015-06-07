using System;
using System.Windows.Forms;
using MvcProject;
using MvpProject;
using View = System.Windows.Forms.View;

namespace MvpProject
{
    public class Controller : IController
    {
        private readonly IView _view;
        private readonly Model _model;

        public Controller(IView view)
        {
            _view = view;
            _model = new Model();
        }

        public void SaveToFile(string text)
        {
            _model.Text = text;
            _model.SaveFile();
        }

        public void LoadFromFile()
        {
            _model.LoadFromFile();
            _view.TextBoxProperty.Text = _model.Text;
        }

        public void SetText(string text)
        {
            _model.Text = text;
        }

    }
}