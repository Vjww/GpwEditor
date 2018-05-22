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
        private readonly IMapperService _mapperService;

        public CommentaryDomainModelExportService(
            CommentaryDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<CommentaryIndexDriverDataEntity> commentaryIndexDriverDataEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexTeamDataEntity> commentaryIndexTeamDataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixDriverDataEntity> commentaryPrefixDriverDataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixTeamDataEntity> commentaryPrefixTeamDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _commentaryIndexDriverDataEntityFactory = commentaryIndexDriverDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexDriverDataEntityFactory));
            _commentaryIndexTeamDataEntityFactory = commentaryIndexTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexTeamDataEntityFactory));
            _commentaryPrefixDriverDataEntityFactory = commentaryPrefixDriverDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverDataEntityFactory));
            _commentaryPrefixTeamDataEntityFactory = commentaryPrefixTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportCommentaryIndexDrivers();
            ExportCommentaryIndexTeams();
            ExportCommentaryPrefixDrivers();
            ExportCommentaryPrefixTeams();
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
    }
}