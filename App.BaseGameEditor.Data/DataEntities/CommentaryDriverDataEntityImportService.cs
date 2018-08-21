using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryDriverDataEntityImportService : IDataEntityImportService<CommentaryDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryDriverDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryDriverDataLocator> _dataLocatorFactory;

        public CommentaryDriverDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryDriverDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<CommentaryDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CommentaryDriverDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndex).TranscriptPrefix;
            result.FileNamePrefix = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndex).FileNamePrefix;

            return result;
        }
    }
}