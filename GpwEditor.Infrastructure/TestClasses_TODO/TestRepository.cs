using System;
using Common.Editor.Infrastructure.DataSets;
using Common.Editor.Infrastructure.Repositories;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestRepository : RepositoryBase
    {
        private readonly IRepositoryExporter _exporter;
        private readonly IRepositoryImporter _importer;

        public TestRepository(
            IRepositoryExporter exporter,
            IRepositoryImporter importer,
            IDataSet testDataSet)
        {
            _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
            _importer = importer ?? throw new ArgumentNullException(nameof(importer));
            if (testDataSet == null) throw new ArgumentNullException(nameof(testDataSet));
            Add(testDataSet);
        }

        public override void Import()
        {
            _importer.Import(this);
        }

        public override void Export()
        {
            _exporter.Export(this);
        }
    }
}