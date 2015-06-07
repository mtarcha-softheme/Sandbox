using System.Windows.Forms;

namespace MvcProject
{
    public interface IView
    {
        Controller Controller { get; set; } 
    }
}