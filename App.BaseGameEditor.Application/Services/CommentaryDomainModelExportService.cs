using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services
{
    public class CommentaryDomainModelExportService
    {
        private readonly CommentaryDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverDataEntity> _commentaryIndexDriverDataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamDataEntity> _commentaryIndexTeamDataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverDataEntity> _commentaryPrefixDriverDataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamDataEntity> _commentaryPrefixTeamDataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryDriverDataEntity> _commentaryDriverDataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryTeamDataEntity> _commentaryTeamDataEntityFactory;
        private readonly IMapperService _mapperService;

        public CommentaryDomainModelExportService(
            CommentaryDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<CommentaryIndexDriverDataEntity> commentaryIndexDriverDataEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexTeamDataEntity> commentaryIndexTeamDataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixDriverDataEntity> commentaryPrefixDriverDataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixTeamDataEntity> commentaryPrefixTeamDataEntityFactory,
            IIntegerIdentityFactory<CommentaryDriverDataEntity> commentaryDriverDataEntityFactory,
            IIntegerIdentityFactory<CommentaryTeamDataEntity> commentaryTeamDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _commentaryIndexDriverDataEntityFactory = commentaryIndexDriverDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexDriverDataEntityFactory));
            _commentaryIndexTeamDataEntityFactory = commentaryIndexTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexTeamDataEntityFactory));
            _commentaryPrefixDriverDataEntityFactory = commentaryPrefixDriverDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverDataEntityFactory));
            _commentaryPrefixTeamDataEntityFactory = commentaryPrefixTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamDataEntityFactory));
            _commentaryDriverDataEntityFactory = commentaryDriverDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryDriverDataEntityFactory));
            _commentaryTeamDataEntityFactory = commentaryTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryTeamDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportCommentaryIndexDrivers();
            ExportCommentaryIndexTeams();
            ExportCommentaryPrefixDrivers();
            ExportCommentaryPrefixTeams();
            ExportCommentaryDrivers();
            ExportCommentaryTeams();
        }

        private void ExportCommentaryIndexDrivers()
        {
            var entities = _domainService.GetCommentaryIndexDrivers();
            foreach (var item in entities)
            {
                var dataEntity = _commentaryIndexDriverDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.CommentaryIndexDrivers.SetById(dataEntity);
            }
        }

        private void ExportCommentaryIndexTeams()
        {
            var entities = _domainService.GetCommentaryIndexTeams();
            foreach (var item in entities)
            {
                var dataEntity = _commentaryIndexTeamDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.CommentaryIndexTeams.SetById(dataEntity);
            }
        }

        private void ExportCommentaryPrefixDrivers()
        {
            var entities = _domainService.GetCommentaryPrefixDrivers();
            foreach (var item in entities)
            {
                var dataEntity = _commentaryPrefixDriverDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.CommentaryPrefixDrivers.SetById(dataEntity);
            }
        }

        private void ExportCommentaryPrefixTeams()
        {
            var entities = _domainService.GetCommentaryPrefixTeams();
            foreach (var item in entities)
            {
                var dataEntity = _commentaryPrefixTeamDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.CommentaryPrefixTeams.SetById(dataEntity);
            }
        }

        private void ExportCommentaryDrivers()
        {
            var entities = _domainService.GetCommentaryDrivers();
            foreach (var item in entities)
            {
                // Special case where this export transforms one set of records (domain-side) into five sets of records (data-side).
                // This ensures that the driver names and file name prefixes that come from the domain-side
                // are mirrored to the data-side for each of the five driver commentary transcripts P1, P2, P3, Out and Pit.
                // Refer to import for opposite logic.

                // Driver P1
                var dataEntityP1 = _commentaryDriverDataEntityFactory.Create(item.Id); // Record 0-40
                _mapperService.Map(item, dataEntityP1);
                _dataService.CommentaryDrivers.SetById(dataEntityP1);

                // Driver P2
                var dataEntityP2 = _commentaryDriverDataEntityFactory.Create(item.Id + 41); // Record 41-81
                _mapperService.Map(item, dataEntityP2);
                _dataService.CommentaryDrivers.SetById(dataEntityP2);

                // Driver P3
                var dataEntityP3 = _commentaryDriverDataEntityFactory.Create(item.Id + 82); // Record 82-122
                _mapperService.Map(item, dataEntityP3);
                _dataService.CommentaryDrivers.SetById(dataEntityP3);

                // Driver Out
                var dataEntityOut = _commentaryDriverDataEntityFactory.Create(item.Id + 123); // Record 123-163
                _mapperService.Map(item, dataEntityOut);
                _dataService.CommentaryDrivers.SetById(dataEntityOut);

                // Driver Pit
                var dataEntityPit = _commentaryDriverDataEntityFactory.Create(item.Id + 164); // Record 164-204
                _mapperService.Map(item, dataEntityPit);
                _dataService.CommentaryDrivers.SetById(dataEntityPit);
            }
        }

        private void ExportCommentaryTeams()
        {
            var entities = _domainService.GetCommentaryTeams();
            foreach (var item in entities)
            {
                // Team Out
                var dataEntityOut = _commentaryTeamDataEntityFactory.Create(item.Id); // Record 0-10
                _mapperService.Map(item, dataEntityOut);
                _dataService.CommentaryTeams.SetById(dataEntityOut);
            }
        }
    }
}