using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryIndexDriverDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<CommentaryIndexDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverDataLocator> _dataLocatorFactory;

        public CommentaryIndexDriverDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryIndexDriverDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CommentaryIndexDriverDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            ImportLanguageCatalogueValue(_dataEndpoint, result.Name, dataLocator.Name);
            result.CommentaryIndex = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CommentaryIndex);

            return result;
        }
    }
}