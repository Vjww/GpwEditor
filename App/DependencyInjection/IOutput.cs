namespace App.DependencyInjection
{
    public interface IOutput
    {
        void WriteLine();
        void WriteLine(string value);
    }
}