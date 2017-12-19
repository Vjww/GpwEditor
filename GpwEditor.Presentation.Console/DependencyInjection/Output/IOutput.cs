namespace GpwEditor.Presentation.Console.DependencyInjection.Output
{
    public interface IOutput
    {
        void WriteLine();
        void WriteLine(string value);
    }
}