namespace App.Console.Outputs
{
    public interface IOutput
    {
        void WriteLine();
        void WriteLine(string value);
    }
}