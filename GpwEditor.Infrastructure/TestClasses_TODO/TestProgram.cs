using System.Collections.Generic;
using Common.Editor.Infrastructure.DataSets;
using Common.Editor.Infrastructure.Entities;
using Common.Editor.Infrastructure.Repositories;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestProgram
    {
        public TestProgram()
        {
            var repository = new TestRepository(
                new RepositoryExporter(new DataSetExporter(new TestEntityExporter(new TestDataContext(new TestFileResource(), new TestTextFileResource())))),
                new RepositoryImporter(new DataSetImporter(new TestEntityImporter(new TestDataContext(new TestFileResource(), new TestTextFileResource())))),
                new DataSetBase(new List<IEntity>(), 1)
                );
            repository.Import();
        }
    }
}