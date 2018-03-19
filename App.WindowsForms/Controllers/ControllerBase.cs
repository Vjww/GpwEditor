using System.Windows.Forms;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public abstract class ControllerBase
    {
        public void ShowView(Form parentView, EditorForm childView)
        {
            childView.FormClosing += delegate { parentView.Show(); };
            childView.Show(parentView);
            parentView.Hide();
        }
    }
}