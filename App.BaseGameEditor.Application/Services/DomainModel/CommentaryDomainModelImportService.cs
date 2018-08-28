using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class CommentaryDomainModelImportService
    {
        private const int CommentaryIndexDriverItemCount = 44;
        private const int CommentaryIndexTeamItemCount = 11;
        private const int CommentaryPrefixDriverItemCount = 41;
        private const int CommentaryPrefixTeamItemCount = 11;
        private const int CommentaryDriverItemCount = 41;
        private const int CommentaryTeamItemCount = 11;

        private readonly CommentaryDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverEntity> _commentaryIndexDriverEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamEntity> _commentaryIndexTeamEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverEntity> _commentaryPrefixDriverEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamEntity> _commentaryPrefixTeamEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryDriverEntity> _commentaryDriverEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryTeamEntity> _commentaryTeamEntityFactory;
        private readonly IMapperService _mapperService;

        public CommentaryDomainModelImportService(
            CommentaryDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<CommentaryIndexDriverEntity> commentaryIndexDriverEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexTeamEntity> commentaryIndexTeamEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixDriverEntity> commentaryPrefixDriverEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixTeamEntity> commentaryPrefixTeamEntityFactory,
            IIntegerIdentityFactory<CommentaryDriverEntity> commentaryDriverEntityFactory,
            IIntegerIdentityFactory<CommentaryTeamEntity> commentaryTeamEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _commentaryIndexDriverEntityFactory = commentaryIndexDriverEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexDriverEntityFactory));
            _commentaryIndexTeamEntityFactory = commentaryIndexTeamEntityFactory ?? throw new ArgumentNullException(nameof(commentaryIndexTeamEntityFactory));
            _commentaryPrefixDriverEntityFactory = commentaryPrefixDriverEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverEntityFactory));
            _commentaryPrefixTeamEntityFactory = commentaryPrefixTeamEntityFactory ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamEntityFactory));
            _commentaryDriverEntityFactory = commentaryDriverEntityFactory ?? throw new ArgumentNullException(nameof(commentaryDriverEntityFactory));
            _commentaryTeamEntityFactory = commentaryTeamEntityFactory ?? throw new ArgumentNullException(nameof(commentaryTeamEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportCommentaryIndexDrivers();
            ImportCommentaryIndexTeams();
            ImportCommentaryPrefixDrivers();
            ImportCommentaryPrefixTeams();
            ImportCommentaryDrivers();
            ImportCommentaryTeams();
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

        private void ImportCommentaryDrivers()
        {
            var entities = new List<CommentaryDriverEntity>();
            for (var i = 0; i < CommentaryDriverItemCount; i++)
            {
                // Special case where this import only takes into the domain-side the first of five sets of records that are available on the data-side.
                // Note that only the first <CommentaryDriverItemCount> records are processed from a larger set of records that are available.
                // This ensures that the driver names and file name prefixes that come from the data-side are only taken from the
                // driver commentary transcripts for P1, and where P2, P3, Out and Pit are ignored.
                // Refer to export for opposite logic.

                var id = i;

                var dataEntity = _dataService.CommentaryDrivers.Get(x => x.Id == id).Single();

                var entity = _commentaryDriverEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryDrivers(entities);
        }

        private void ImportCommentaryTeams()
        {
            var entities = new List<CommentaryTeamEntity>();
            for (var i = 0; i < CommentaryTeamItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.CommentaryTeams.Get(x => x.Id == id).Single();

                var entity = _commentaryTeamEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetCommentaryTeams(entities);
        }
    }
}