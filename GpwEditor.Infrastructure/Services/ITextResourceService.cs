namespace GpwEditor.Infrastructure.Services
{
    public interface ITextResourceService
    {
        string Read(int id);
        void Write(int id, string value);
    }
}