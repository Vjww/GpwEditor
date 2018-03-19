using System.Windows.Forms;
using Autofac;

namespace App.WindowsForms
{
    public class FormFactory
    {
        readonly ILifetimeScope _scope;

        public FormFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public TForm Create<TForm>()
            where TForm : Form
        {
            // As form disposal is handled by the Windows Forms framework
            // (e.g. when the Form.Close() method is invoked), if we are
            // resolving a form from the DI container, then we must notify
            // the DI container when that form has been disposed.

            // By resolving the form within a lifetime scope and subscribing
            // to the form's Closed event, we can dispose of the scope to
            // release the reference held to the form by the DI container.

            // For further information, refer to the following links:
            // https://stackoverflow.com/a/15940185
            // https://stackoverflow.com/a/8855283

            var formScope = _scope.BeginLifetimeScope("FormScope");
            var form = formScope.Resolve<TForm>();
            form.Closed += (s, e) => formScope.Dispose();
            return form;
        }
    }
}