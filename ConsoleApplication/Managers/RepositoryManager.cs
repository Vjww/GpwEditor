using System.Collections.ObjectModel;
using ConsoleApplication.DataSources;
using ConsoleApplication.Entities;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers;
using ConsoleApplication.Populators;
using ConsoleApplication.Repositories;
using ConsoleApplication.Services;

namespace ConsoleApplication.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        public IRepository<CarNumberEntity> CarNumberRepository { get; set; }

        public void ImportRepositoryFromGameFiles(ConnectionStrings connectionStrings)
        {
            // Create streams
            var gameExecutableStream = new MemoryStreamService();
            var englishLanguageResourceStream = new MemoryStreamService();
            var frenchLanguageResourceStream = new MemoryStreamService();
            var germanLanguageResourceStream = new MemoryStreamService();
            var englishCommentaryResourceStream = new MemoryStreamService();
            var frenchCommentaryResourceStream = new MemoryStreamService();
            var germanCommentaryResourceStream = new MemoryStreamService();

            // Load file data into streams
            gameExecutableStream.Set(new BinaryFileService().LoadFromFileIntoMemoryStream(connectionStrings.GameExecutable));
            englishLanguageResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.EnglishLanguageResource));
            frenchLanguageResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.FrenchLanguageResource));
            germanLanguageResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.GermanLanguageResource));
            englishCommentaryResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.EnglishCommentaryResource));
            frenchCommentaryResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.FrenchCommentaryResource));
            germanCommentaryResourceStream.Set(new TextFileService().LoadFromFileIntoMemoryStream(connectionStrings.GermanCommentaryResource));

            // Use streams as a datasource
            var dataSource = new DataSource(
                gameExecutableStream,
                englishLanguageResourceStream,
                frenchLanguageResourceStream,
                germanLanguageResourceStream,
                englishCommentaryResourceStream,
                frenchCommentaryResourceStream,
                germanCommentaryResourceStream
            );

            // Import repository data from datasource
            CarNumberRepository = PopulateRepositoryFromDataSource<CarNumberEntity, CarNumberMapper, CarNumberPopulator>(dataSource, 22);

            // TODO: foreach (var repository in _repositories)
            // TODO: {
            // TODO:     repository.PopulateRepositoryFromDataSource(datasource, repository.Length);
            // TODO: }
        }

        public void ExportRepositoryToGameFiles(ConnectionStrings connectionStrings)
        {
            // Create streams
            var gameExecutableStream = new MemoryStreamService();
            var englishLanguageResourceStream = new MemoryStreamService();
            var frenchLanguageResourceStream = new MemoryStreamService();
            var germanLanguageResourceStream = new MemoryStreamService();
            var englishCommentaryResourceStream = new MemoryStreamService();
            var frenchCommentaryResourceStream = new MemoryStreamService();
            var germanCommentaryResourceStream = new MemoryStreamService();

            // Use streams as a datasource
            var dataSource = new DataSource(
                gameExecutableStream,
                englishLanguageResourceStream,
                frenchLanguageResourceStream,
                germanLanguageResourceStream,
                englishCommentaryResourceStream,
                frenchCommentaryResourceStream,
                germanCommentaryResourceStream
            );

            return; // TODO: remove

            // Export repository data to datasource
            PopulateDataSourceFromCarNumberRepository(dataSource, CarNumberRepository, 22);

            // TODO: foreach (var repository in _repositories)
            // TODO: {
            // TODO:     repository.PopulateDataSourceFromRepository(_streams);
            // TODO: }

            // Save stream data into files
            new BinaryFileService().SaveFromMemoryStreamIntoFile(connectionStrings.GameExecutable, gameExecutableStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.EnglishLanguageResource, englishLanguageResourceStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.FrenchLanguageResource, frenchLanguageResourceStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.GermanLanguageResource, germanLanguageResourceStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.EnglishCommentaryResource, englishCommentaryResourceStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.FrenchCommentaryResource, frenchCommentaryResourceStream.Get());
            new TextFileService().SaveFromMemoryStreamIntoFile(connectionStrings.GermanCommentaryResource, germanCommentaryResourceStream.Get());
        }

        private static Repository<T> PopulateRepositoryFromDataSource<T, TU, TV>(IDataSource dataSource, int items)
            where T : class, IEntity, new()
            where TU : class, IMapper, new()
            where TV : PopulatorBase<T, TU>, new()
        {
            var collection = new Collection<T>();
            for (var i = 0; i < items; i++)
            {
                var entity = new T { Id = i };
                var mapper = new TU { Id = i };
                mapper.Map();

                var populator = new TV();
                populator.PopulateEntityFromDataSource(dataSource, entity, mapper);

                collection.Add(entity);
            }
            return new Repository<T>(collection);
        }

        private static void PopulateDataSourceFromCarNumberRepository(IDataSource dataSource, IRepository<CarNumberEntity> repository, int items)
        {
            // TODO:
        }
    }
}