using App.DependencyInjection;

namespace App.Output
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine()
        {
            System.Console.WriteLine();
        }

        public void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}