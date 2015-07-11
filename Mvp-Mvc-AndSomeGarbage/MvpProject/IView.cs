using System.Windows.Forms;
using MvpProject;

namespace MvcProject
{
    public interface IView
    {
        IController Controller { get; set; }

        TextBox TextBoxProperty { get; }
    }
}