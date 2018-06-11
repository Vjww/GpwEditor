using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.EntityValidators;
using App.Core.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class CommentaryDomainService
    {
        private readonly IRepository<CommentaryIndexDriverEntity> _commentaryIndexDriverRepository;
        private readonly IEntityValidator<CommentaryIndexDriverEntity> _commentaryIndexDriverEntityValidator;
        private readonly IRepository<CommentaryIndexTeamEntity> _commentaryIndexTeamRepository;
        private readonly IEntityValidator<CommentaryIndexTeamEntity> _commentaryIndexTeamEntityValidator;
        private readonly IRepository<CommentaryPrefixDriverEntity> _commentaryPrefixDriverRepository;
        private readonly IEntityValidator<CommentaryPrefixDriverEntity> _commentaryPrefixDriverEntityValidator;
        private readonly IRepository<CommentaryPrefixTeamEntity> _commentaryPrefixTeamRepository;
        private readonly IEntityValidator<CommentaryPrefixTeamEntity> _commentaryPrefixTeamEntityValidator;
        private readonly IRepository<CommentaryDriverEntity> _commentaryDriverRepository;
        private readonly IEntityValidator<CommentaryDriverEntity> _commentaryDriverEntityValidator;
        private readonly IRepository<CommentaryTeamEntity> _commentaryTeamRepository;
        private readonly IEntityValidator<CommentaryTeamEntity> _commentaryTeamEntityValidator;
        private readonly CommentaryFileDirectoryListingService _commentaryFileDirectoryListingService;

        public CommentaryDomainService(
            IRepository<CommentaryIndexDriverEntity> commentaryIndexDriverRepository,
            IEntityValidator<CommentaryIndexDriverEntity> commentaryIndexDriverEntityValidator,
            IRepository<CommentaryIndexTeamEntity> commentaryIndexTeamRepository,
            IEntityValidator<CommentaryIndexTeamEntity> commentaryIndexTeamEntityValidator,
            IRepository<CommentaryPrefixDriverEntity> commentaryPrefixDriverRepository,
            IEntityValidator<CommentaryPrefixDriverEntity> commentaryPrefixDriverEntityValidator,
            IRepository<CommentaryPrefixTeamEntity> commentaryPrefixTeamRepository,
            IEntityValidator<CommentaryPrefixTeamEntity> commentaryPrefixTeamEntityValidator,
            IRepository<CommentaryDriverEntity> commentaryDriverRepository,
            IEntityValidator<CommentaryDriverEntity> commentaryDriverEntityValidator,
            IRepository<CommentaryTeamEntity> commentaryTeamRepository,
            IEntityValidator<CommentaryTeamEntity> commentaryTeamEntityValidator,
            CommentaryFileDirectoryListingService commentaryFileDirectoryListingService)
        {
            _commentaryIndexDriverRepository = commentaryIndexDriverRepository ?? throw new ArgumentNullException(nameof(commentaryIndexDriverRepository));
            _commentaryIndexDriverEntityValidator = commentaryIndexDriverEntityValidator ?? throw new ArgumentNullException(nameof(commentaryIndexDriverEntityValidator));
            _commentaryIndexTeamRepository = commentaryIndexTeamRepository ?? throw new ArgumentNullException(nameof(commentaryIndexTeamRepository));
            _commentaryIndexTeamEntityValidator = commentaryIndexTeamEntityValidator ?? throw new ArgumentNullException(nameof(commentaryIndexTeamEntityValidator));
            _commentaryPrefixDriverRepository = commentaryPrefixDriverRepository ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverRepository));
            _commentaryPrefixDriverEntityValidator = commentaryPrefixDriverEntityValidator ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverEntityValidator));
            _commentaryPrefixTeamRepository = commentaryPrefixTeamRepository ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamRepository));
            _commentaryPrefixTeamEntityValidator = commentaryPrefixTeamEntityValidator ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamEntityValidator));
            _commentaryDriverRepository = commentaryDriverRepository ?? throw new ArgumentNullException(nameof(commentaryDriverRepository));
            _commentaryDriverEntityValidator = commentaryDriverEntityValidator ?? throw new ArgumentNullException(nameof(commentaryDriverEntityValidator));
            _commentaryTeamRepository = commentaryTeamRepository ?? throw new ArgumentNullException(nameof(commentaryTeamRepository));
            _commentaryTeamEntityValidator = commentaryTeamEntityValidator ?? throw new ArgumentNullException(nameof(commentaryTeamEntityValidator));
            _commentaryFileDirectoryListingService = commentaryFileDirectoryListingService ?? throw new ArgumentNullException(nameof(commentaryFileDirectoryListingService));
        }

        public IEnumerable<CommentaryIndexDriverEntity> GetCommentaryIndexDrivers()
        {
            return _commentaryIndexDriverRepository.Get();
        }

        public void SetCommentaryIndexDrivers(IEnumerable<CommentaryIndexDriverEntity> commentaryIndexDrivers)
        {
            if (commentaryIndexDrivers == null) throw new ArgumentNullException(nameof(commentaryIndexDrivers));

            var validationMessages = new List<string>();

            var list = commentaryIndexDrivers as IList<CommentaryIndexDriverEntity> ?? commentaryIndexDrivers.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryIndexDriverEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryIndexDriverRepository.Set(list);
        }

        public void SetCommentaryIndexDriver(CommentaryIndexDriverEntity commentaryIndexDriver)
        {
            if (commentaryIndexDriver == null) throw new ArgumentNullException(nameof(commentaryIndexDriver));

            var validationMessages = new List<string>();

            var messages = _commentaryIndexDriverEntityValidator.Validate(commentaryIndexDriver);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryIndexDriverRepository.SetById(commentaryIndexDriver);
        }

        public IEnumerable<CommentaryIndexTeamEntity> GetCommentaryIndexTeams()
        {
            return _commentaryIndexTeamRepository.Get();
        }

        public void SetCommentaryIndexTeams(IEnumerable<CommentaryIndexTeamEntity> commentaryIndexTeams)
        {
            if (commentaryIndexTeams == null) throw new ArgumentNullException(nameof(commentaryIndexTeams));

            var validationMessages = new List<string>();

            var list = commentaryIndexTeams as IList<CommentaryIndexTeamEntity> ?? commentaryIndexTeams.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryIndexTeamEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryIndexTeamRepository.Set(list);
        }

        public void SetCommentaryIndexTeam(CommentaryIndexTeamEntity commentaryIndexTeam)
        {
            if (commentaryIndexTeam == null) throw new ArgumentNullException(nameof(commentaryIndexTeam));

            var validationMessages = new List<string>();

            var messages = _commentaryIndexTeamEntityValidator.Validate(commentaryIndexTeam);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryIndexTeamRepository.SetById(commentaryIndexTeam);
        }

        public IEnumerable<CommentaryPrefixDriverEntity> GetCommentaryPrefixDrivers()
        {
            return _commentaryPrefixDriverRepository.Get();
        }

        public void SetCommentaryPrefixDrivers(IEnumerable<CommentaryPrefixDriverEntity> commentaryPrefixDrivers)
        {
            if (commentaryPrefixDrivers == null) throw new ArgumentNullException(nameof(commentaryPrefixDrivers));

            var validationMessages = new List<string>();

            var list = commentaryPrefixDrivers as IList<CommentaryPrefixDriverEntity> ?? commentaryPrefixDrivers.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryPrefixDriverEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryPrefixDriverRepository.Set(list);
        }

        public void SetCommentaryPrefixDriver(CommentaryPrefixDriverEntity commentaryPrefixDriver)
        {
            if (commentaryPrefixDriver == null) throw new ArgumentNullException(nameof(commentaryPrefixDriver));

            var validationMessages = new List<string>();

            var messages = _commentaryPrefixDriverEntityValidator.Validate(commentaryPrefixDriver);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryPrefixDriverRepository.SetById(commentaryPrefixDriver);
        }

        public IEnumerable<CommentaryPrefixTeamEntity> GetCommentaryPrefixTeams()
        {
            return _commentaryPrefixTeamRepository.Get();
        }

        public void SetCommentaryPrefixTeams(IEnumerable<CommentaryPrefixTeamEntity> commentaryPrefixTeams)
        {
            if (commentaryPrefixTeams == null) throw new ArgumentNullException(nameof(commentaryPrefixTeams));

            var validationMessages = new List<string>();

            var list = commentaryPrefixTeams as IList<CommentaryPrefixTeamEntity> ?? commentaryPrefixTeams.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryPrefixTeamEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryPrefixTeamRepository.Set(list);
        }

        public void SetCommentaryPrefixTeam(CommentaryPrefixTeamEntity commentaryPrefixTeam)
        {
            if (commentaryPrefixTeam == null) throw new ArgumentNullException(nameof(commentaryPrefixTeam));

            var validationMessages = new List<string>();

            var messages = _commentaryPrefixTeamEntityValidator.Validate(commentaryPrefixTeam);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryPrefixTeamRepository.SetById(commentaryPrefixTeam);
        }

        public IEnumerable<CommentaryDriverEntity> GetCommentaryDrivers()
        {
            return _commentaryDriverRepository.Get();
        }

        public void SetCommentaryDrivers(IEnumerable<CommentaryDriverEntity> commentaryDrivers)
        {
            if (commentaryDrivers == null) throw new ArgumentNullException(nameof(commentaryDrivers));

            var validationMessages = new List<string>();

            var list = commentaryDrivers as IList<CommentaryDriverEntity> ?? commentaryDrivers.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryDriverEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryDriverRepository.Set(list);
        }

        public void SetCommentaryDriver(CommentaryDriverEntity commentaryDriver)
        {
            if (commentaryDriver == null) throw new ArgumentNullException(nameof(commentaryDriver));

            var validationMessages = new List<string>();

            var messages = _commentaryDriverEntityValidator.Validate(commentaryDriver);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryDriverRepository.SetById(commentaryDriver);
        }

        public IEnumerable<CommentaryTeamEntity> GetCommentaryTeams()
        {
            return _commentaryTeamRepository.Get();
        }

        public void SetCommentaryTeams(IEnumerable<CommentaryTeamEntity> commentaryTeams)
        {
            if (commentaryTeams == null) throw new ArgumentNullException(nameof(commentaryTeams));

            var validationMessages = new List<string>();

            var list = commentaryTeams as IList<CommentaryTeamEntity> ?? commentaryTeams.ToList();
            foreach (var item in list)
            {
                var messages = _commentaryTeamEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryTeamRepository.Set(list);
        }

        public void SetCommentaryTeam(CommentaryTeamEntity commentaryTeam)
        {
            if (commentaryTeam == null) throw new ArgumentNullException(nameof(commentaryTeam));

            var validationMessages = new List<string>();

            var messages = _commentaryTeamEntityValidator.Validate(commentaryTeam);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _commentaryTeamRepository.SetById(commentaryTeam);
        }

        public IEnumerable<CommentaryFileEntity> GetCommentaryFiles(string gameFolderPath)
        {
            var result = new List<CommentaryFileEntity>();

            var id = 0;
            foreach (var item in _commentaryFileDirectoryListingService.GetCommentaryFiles(gameFolderPath))
            {
                result.Add(new CommentaryFileEntity { Id = id, FileName = item });
                id++;
            }

            return result;
        }

        public IEnumerable<CommentaryIndexDriverEntity> GetDriverIndicesFromOriginalValues(IEnumerable<CommentaryIndexDriverEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var values = new[]
            {
                67,
                68,
                69,
                70,
                71,
                72,
                73,
                74,
                75,
                76,
                77,
                78,
                79,
                80,
                81,
                82,
                83,
                84,
                85,
                86,
                87,
                88,
                89,
                90,
                91,
                92,
                93,
                94,
                95,
                96,
                97,
                98,
                99,
                100,
                101,
                102,
                103,
                104,
                105,
                106,
                107, // Shared
                107, // Shared
                107, // Shared
                107  // Shared
            };

            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).CommentaryIndex = values[id];
            }

            return modifiedEntities;
        }

        public IEnumerable<CommentaryPrefixDriverEntity> GetDriverPrefixesFromOriginalValues(IEnumerable<CommentaryPrefixDriverEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var values = new[]
            {
                "NEWH",
                "FREN",
                "TOY",
                "SCHU",
                "IRV",
                "BAD",
                "FIS",
                "WURZ",
                "ANON",
                "HAK",
                "COUL",
                "ZON",
                "HIL",
                "RALF",
                "ANON",
                "PAN",
                "TRU",
                "SAR",
                "ALES",
                "HERB",
                "MULL",
                "DIN",
                "SAL",
                "COL",
                "BARI",
                "MAG",
                "ANON",
                "TAK",
                "ROS",
                "MONT",
                "NAK",
                "TUER",
                "RED",
                "ELL",
                "MAR",
                "RAIM",
                "TAN",
                "EBE",
                "PAT",
                "FELL",
                "LAUR",
                "EIS",
                "WILL",
                "MOR"
            };

            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).FileNamePrefix = values[id];
            }

            return modifiedEntities;
        }

        public IEnumerable<CommentaryPrefixDriverEntity> GetDriverPrefixesFromAnonymousValues(IEnumerable<CommentaryPrefixDriverEntity> entities)
        {
            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).FileNamePrefix = "ANON";
            }

            return modifiedEntities;
        }

        public IEnumerable<CommentaryIndexTeamEntity> GetTeamIndicesFromOriginalValues(IEnumerable<CommentaryIndexTeamEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var values = new[]
            {
                231,
                232,
                233,
                234,
                235,
                236,
                237,
                238,
                239,
                240,
                241
            };

            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).CommentaryIndex = values[id];
            }

            return modifiedEntities;
        }

        public IEnumerable<CommentaryPrefixTeamEntity> GetTeamPrefixesFromOriginalValues(IEnumerable<CommentaryPrefixTeamEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var values = new[]
            {
                "WIL",
                "FER",
                "BEN",
                "MCL",
                "JOR",
                "PRO",
                "SAU",
                "ARR",
                "STEW",
                "TYR",
                "MIN"
            };

            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).FileNamePrefix = values[id];
            }

            return modifiedEntities;
        }

        public IEnumerable<CommentaryPrefixTeamEntity> GetTeamPrefixesFromAnonymousValues(IEnumerable<CommentaryPrefixTeamEntity> entities)
        {
            var modifiedEntities = entities.ToList();

            for (var i = 0; i < modifiedEntities.Count; i++)
            {
                var id = i;
                modifiedEntities.Single(x => x.Id == id).FileNamePrefix = "ANON";
            }

            return modifiedEntities;
        }
    }
}