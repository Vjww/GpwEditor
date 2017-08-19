using ConsoleApplication.Entities;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Repositories;

namespace ConsoleApplication.Managers
{
    public interface IRepositoryManager
    {
        IRepository<CarNumberEntity> CarNumberRepository { get; set; }

        void ImportRepositoryFromGameFiles(ConnectionStrings connectionStrings);
        void ExportRepositoryToGameFiles(ConnectionStrings connectionStrings);
    }
}