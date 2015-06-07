using System;
using System.IO;

namespace MvcProject
{
    public class Model
    {
        private string _text;
        public event EventHandler TextLoaded;

        public string Text
        {
            get { return _text; }

            set
            {
                if (_text != value)
                {
                    _text = value;
                    TextLoaded(this, EventArgs.Empty);
                }
                
            }
        }

        public void SaveFile()
        {
            using (var streamWriter = new StreamWriter("C:\\MyFile.txt"))
            {
                streamWriter.Write(Text);
            }
        }

        public void LoadFromFile()
        {
            using (var streamReader = new StreamReader("C:\\MyFile.txt"))
            {
                Text = streamReader.ReadToEnd();
            }
        }
    }
}