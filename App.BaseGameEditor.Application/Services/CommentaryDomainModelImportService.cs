using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services
{
    public class CommentaryDomainModelImportService
    {
        private const int CommentaryIndexDriverItemCount = 44;
        private const int CommentaryIndexTeamItemCount = 11;
        private const int CommentaryPrefixDriverItemCount = 41;
        private const int CommentaryPrefixTeamItemCount = 11;

        private readonly CommentaryDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverEntity> _commentaryIndexDriverEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamEntity> _commentaryIndexTeamEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverEntity> _commentaryPrefixDriverEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamEntity> _commentaryPrefixTeamEntityFactory;
        private readonly IMapperService _mapperService;

        public CommentaryDomainModelImportService(
            CommentaryDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<CommentaryIndexDriverEntity> commentaryIndexDriverEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexTeamEntity> commentaryIndexTeamEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixDriverEntity> commentaryPrefixDriverEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixTeamEntity> commentaryPrefixTeamEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _commentaryIndexDriverEntityFactory = commentaryIndexDriverEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexDriverEntityFactory));
            _commentaryIndexTeamEntityFactory = commentaryIndexTeamEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexTeamEntityFactory));
            _commentaryPrefixDriverEntityFactory = commentaryPrefixDriverEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverEntityFactory));
            _commentaryPrefixTeamEntityFactory = commentaryPrefixTeamEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportCommentaryIndexDrivers();
            ImportCommentaryIndexTeams();
            ImportCommentaryPrefixDrivers();
            ImportCommentaryPrefixTeams();
        }

        private void ImportCommentaryIndexDrivers()
        {
            var entities = new List<CommentaryIndexDriverEntity>();
            for (var i = 0; i < CommentaryIndexDriverItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.CommentaryIndexDrivers.Get(x => x.Id == id).Single();

                var entity = _commentaryIndexDriverEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryIndexDrivers(entities);
        }

        private void ImportCommentaryIndexTeams()
        {
            var entities = new List<CommentaryIndexTeamEntity>();
            for (var i = 0; i < CommentaryIndexTeamItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.CommentaryIndexTeams.Get(x => x.Id == id).Single();

                var entity = _commentaryIndexTeamEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryIndexTeams(entities);
        }

        private void ImportCommentaryPrefixDrivers()
        {
            var entities = new List<CommentaryPrefixDriverEntity>();
            for (var i = 0; i < CommentaryPrefixDriverItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.CommentaryPrefixDrivers.Get(x => x.Id == id).Single();

                var entity = _commentaryPrefixDriverEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryPrefixDrivers(entities);
        }

        private void ImportCommentaryPrefixTeams()
        {
            var entities = new List<CommentaryPrefixTeamEntity>();
            for (var i = 0; i < CommentaryPrefixTeamItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.CommentaryPrefixTeams.Get(x => x.Id == id).Single();

                var entity = _commentaryPrefixTeamEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryPrefixTeams(entities);
        }
    }
}