﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Models;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class ConfigureGameController : ControllerBase
    {
        private ConfigureGameForm _view;

        private readonly PerformanceCurveValuesController _performanceCurveValuesController;
        private readonly ConfigureGameApplicationService _configureGameApplicationService;
        private readonly FormFactory _formFactory;

        public ConfigureGameController(
            PerformanceCurveValuesController performanceCurveValuesController,
            ConfigureGameApplicationService configureGameApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _performanceCurveValuesController = performanceCurveValuesController ?? throw new ArgumentNullException(nameof(performanceCurveValuesController));
            _configureGameApplicationService = configureGameApplicationService ?? throw new ArgumentNullException(nameof(configureGameApplicationService));
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<ConfigureGameForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public void Import()
        {
            _configureGameApplicationService.Import(
                _view.GameFolderPath,
                _view.GameExecutableFilePath,
                _view.EnglishLanguageFilePath,
                _view.FrenchLanguageFilePath,
                _view.GermanLanguageFilePath,
                _view.EnglishCommentaryFilePath,
                _view.FrenchCommentaryFilePath,
                _view.GermanCommentaryFilePath);

            UpdateModelsFromService();
        }

        public void Export()
        {
            UpdateServiceFromModels();

            _configureGameApplicationService.Export(
                _view.GameFolderPath,
                _view.GameExecutableFilePath,
                _view.EnglishLanguageFilePath,
                _view.FrenchLanguageFilePath,
                _view.GermanLanguageFilePath,
                _view.EnglishCommentaryFilePath,
                _view.FrenchCommentaryFilePath,
                _view.GermanCommentaryFilePath);
        }

        public void RunEditPerformanceCurveForm()
        {
            _performanceCurveValuesController.Run(_view, this);
        }

        public void UpdateCommentaryModelWithDriverIndicesFromOriginalValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryIndexDriverModel>, IEnumerable<CommentaryIndexDriverEntity>>(_view.CommentaryIndexDrivers);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetDriverIndicesFromOriginalValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryIndexDriverEntity>, IEnumerable<CommentaryIndexDriverModel>>(modifiedEntities);
            _view.UpdateCommentaryIndicesDriverModelWithUpdatedCommentaryIndexValues(model);
        }

        public void UpdateCommentaryModelWithDriverPrefixesFromOriginalValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryPrefixDriverModel>, IEnumerable<CommentaryPrefixDriverEntity>>(_view.CommentaryPrefixDrivers);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetDriverPrefixesFromOriginalValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryPrefixDriverEntity>, IEnumerable<CommentaryPrefixDriverModel>>(modifiedEntities);
            _view.UpdateCommentaryPrefixesDriverModelWithUpdatedFileNamePrefixValues(model);
        }

        public void UpdateCommentaryModelWithDriverPrefixesFromAnonymousValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryPrefixDriverModel>, IEnumerable<CommentaryPrefixDriverEntity>>(_view.CommentaryPrefixDrivers);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetDriverPrefixesFromAnonymousValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryPrefixDriverEntity>, IEnumerable<CommentaryPrefixDriverModel>>(modifiedEntities);
            _view.UpdateCommentaryPrefixesDriverModelWithUpdatedFileNamePrefixValues(model);
        }

        public void UpdateCommentaryModelWithTeamIndicesFromOriginalValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryIndexTeamModel>, IEnumerable<CommentaryIndexTeamEntity>>(_view.CommentaryIndexTeams);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetTeamIndicesFromOriginalValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryIndexTeamEntity>, IEnumerable<CommentaryIndexTeamModel>>(modifiedEntities);
            _view.UpdateCommentaryIndicesTeamModelWithUpdatedCommentaryIndexValues(model);
        }

        public void UpdateCommentaryModelWithTeamPrefixesFromOriginalValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryPrefixTeamModel>, IEnumerable<CommentaryPrefixTeamEntity>>(_view.CommentaryPrefixTeams);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetTeamPrefixesFromOriginalValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryPrefixTeamEntity>, IEnumerable<CommentaryPrefixTeamModel>>(modifiedEntities);
            _view.UpdateCommentaryPrefixesTeamModelWithUpdatedFileNamePrefixValues(model);
        }

        public void UpdateCommentaryModelWithTeamPrefixesFromAnonymousValues()
        {
            var entities = MapperService.Map<IEnumerable<CommentaryPrefixTeamModel>, IEnumerable<CommentaryPrefixTeamEntity>>(_view.CommentaryPrefixTeams);

            var modifiedEntities = _configureGameApplicationService.DomainModel.Commentaries.GetTeamPrefixesFromAnonymousValues(entities);

            var model = MapperService.Map<IEnumerable<CommentaryPrefixTeamEntity>, IEnumerable<CommentaryPrefixTeamModel>>(modifiedEntities);
            _view.UpdateCommentaryPrefixesTeamModelWithUpdatedFileNamePrefixValues(model);
        }

        private void UpdateModelsFromService()
        {
            _view.DisableGameCd = _configureGameApplicationService.DomainModel.Configurations.DisableGameCd;
            _view.DisableColourMode = _configureGameApplicationService.DomainModel.Configurations.DisableColourMode;
            _view.DisableSampleApp = _configureGameApplicationService.DomainModel.Configurations.DisableSampleApp;
            _view.DisableMemoryResetForRaceSounds = _configureGameApplicationService.DomainModel.Configurations.DisableMemoryResetForRaceSounds;
            // _view.DisablePitExitPriority = _configureGameApplicationService.DomainModel.Configurations.DisablePitExitPriority; // TODO: Not yet implemented
            _view.DisableYellowFlagPenalties = _configureGameApplicationService.DomainModel.Configurations.DisableYellowFlagPenalties;
            _view.EnableCarHandlingDesignCalculation = _configureGameApplicationService.DomainModel.Configurations.EnableCarHandlingDesignCalculation;
            _view.EnableCarPerformanceRaceCalcuation = _configureGameApplicationService.DomainModel.Configurations.EnableCarPerformanceRaceCalcuation;
            _view.PointsScoringSystemDefault = _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemDefault;
            _view.PointsScoringSystemOption1 = _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption1;
            _view.PointsScoringSystemOption2 = _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption2;
            _view.PointsScoringSystemOption3 = _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption3;

            _view.CommentaryIndexDrivers = UpdateModelFromService<IEnumerable<CommentaryIndexDriverEntity>, IEnumerable<CommentaryIndexDriverModel>>(_configureGameApplicationService.DomainModel.Commentaries.GetCommentaryIndexDrivers);
            _view.CommentaryIndexTeams = UpdateModelFromService<IEnumerable<CommentaryIndexTeamEntity>, IEnumerable<CommentaryIndexTeamModel>>(_configureGameApplicationService.DomainModel.Commentaries.GetCommentaryIndexTeams);
            _view.CommentaryPrefixDrivers = UpdateModelFromService<IEnumerable<CommentaryPrefixDriverEntity>, IEnumerable<CommentaryPrefixDriverModel>>(_configureGameApplicationService.DomainModel.Commentaries.GetCommentaryPrefixDrivers);
            _view.CommentaryPrefixTeams = UpdateModelFromService<IEnumerable<CommentaryPrefixTeamEntity>, IEnumerable<CommentaryPrefixTeamModel>>(_configureGameApplicationService.DomainModel.Commentaries.GetCommentaryPrefixTeams);
            _view.CommentaryFiles = UpdateCommentaryFilesModelFromService(_view.GameFolderPath);

            // TODO: Perhaps the data type of Performance Curve should be int[] rather than a model, or the model is not enumerable but rather a model of PerformanceCurveModel.Values
            _view.PerformanceCurves = UpdateModelFromService<IEnumerable<PerformanceCurveEntity>, IEnumerable<PerformanceCurveModel>>(_configureGameApplicationService.DomainModel.PerformanceCurveValues.GetPerformanceCurves);
        }

        private IEnumerable<CommentaryFileModel> UpdateCommentaryFilesModelFromService(string gameFolderPath)
        {
            var entities = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryFiles(gameFolderPath);
            return MapperService.Map<IEnumerable<CommentaryFileEntity>, IEnumerable<CommentaryFileModel>>(entities);
        }

        private void UpdateServiceFromModels()
        {
            _configureGameApplicationService.DomainModel.Configurations.DisableGameCd = _view.DisableGameCd;
            _configureGameApplicationService.DomainModel.Configurations.DisableColourMode = _view.DisableColourMode;
            _configureGameApplicationService.DomainModel.Configurations.DisableSampleApp = _view.DisableSampleApp;
            _configureGameApplicationService.DomainModel.Configurations.DisableMemoryResetForRaceSounds = _view.DisableMemoryResetForRaceSounds;
            // _configureGameApplicationService.DomainModel.Configurations.DisablePitExitPriority = _view.DisablePitExitPriority; // TODO: Not yet implemented
            _configureGameApplicationService.DomainModel.Configurations.DisableYellowFlagPenalties = _view.DisableYellowFlagPenalties;
            _configureGameApplicationService.DomainModel.Configurations.EnableCarHandlingDesignCalculation = _view.EnableCarHandlingDesignCalculation;
            _configureGameApplicationService.DomainModel.Configurations.EnableCarPerformanceRaceCalcuation = _view.EnableCarPerformanceRaceCalcuation;
            _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemDefault = _view.PointsScoringSystemDefault;
            _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption1 = _view.PointsScoringSystemOption1;
            _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption2 = _view.PointsScoringSystemOption2;
            _configureGameApplicationService.DomainModel.Configurations.PointsScoringSystemOption3 = _view.PointsScoringSystemOption3;

            // Update commentary driver services
            UpdateServiceFromModel<IEnumerable<CommentaryIndexDriverModel>, IEnumerable<CommentaryIndexDriverEntity>>(_configureGameApplicationService.DomainModel.Commentaries.SetCommentaryIndexDrivers, _view.CommentaryIndexDrivers);
            UpdateServiceFromModel<IEnumerable<CommentaryPrefixDriverModel>, IEnumerable<CommentaryPrefixDriverEntity>>(_configureGameApplicationService.DomainModel.Commentaries.SetCommentaryPrefixDrivers, _view.CommentaryPrefixDrivers);
            SynchroniseChangesToCommentaryDriversService();

            // Update commentary team services
            UpdateServiceFromModel<IEnumerable<CommentaryIndexTeamModel>, IEnumerable<CommentaryIndexTeamEntity>>(_configureGameApplicationService.DomainModel.Commentaries.SetCommentaryIndexTeams, _view.CommentaryIndexTeams);
            UpdateServiceFromModel<IEnumerable<CommentaryPrefixTeamModel>, IEnumerable<CommentaryPrefixTeamEntity>>(_configureGameApplicationService.DomainModel.Commentaries.SetCommentaryPrefixTeams, _view.CommentaryPrefixTeams);
            SynchroniseChangesToCommentaryTeamsService();

            UpdateServiceFromModel<IEnumerable<PerformanceCurveModel>, IEnumerable<PerformanceCurveEntity>>(_configureGameApplicationService.DomainModel.PerformanceCurveValues.SetPerformanceCurves, _view.PerformanceCurves);
        }

        private void SynchroniseChangesToCommentaryDriversService()
        {
            // Update the domain so each commentary line is synchronised with changes to driver indices and prefixes
            var commentaryDrivers = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryDrivers().ToList();

            var commentaryIndexDrivers = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryIndexDrivers().ToList();
            var commentaryPrefixDrivers = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryPrefixDrivers().ToList();

            // Iterate through each commentary line and update line according to values registered against the commentary index
            var counter = 0;
            foreach (var item in commentaryDrivers)
            {
                // Take first driver if multiple drivers share same commentary index
                item.Name = commentaryIndexDrivers.First(x => x.CommentaryIndex == 67 + counter).Name;                      // 67 is the first commentary index for drivers
                item.FileNamePrefix = commentaryPrefixDrivers.First(x => x.CommentaryIndex == 67 + counter).FileNamePrefix; // 67 is the first commentary index for drivers

                counter++;
            }

            _configureGameApplicationService.DomainModel.Commentaries.SetCommentaryDrivers(commentaryDrivers);
        }

        private void SynchroniseChangesToCommentaryTeamsService()
        {
            // Update the domain so each commentary line is synchronised with changes to team indices and prefixes
            var commentaryTeams = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryTeams().ToList();

            var commentaryIndexTeams = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryIndexTeams().ToList();
            var commentaryPrefixTeams = _configureGameApplicationService.DomainModel.Commentaries.GetCommentaryPrefixTeams().ToList();

            // Iterate through each commentary line and update line according to values registered against the commentary index
            var counter = 0;
            foreach (var item in commentaryTeams)
            {
                // Take first team if multiple teams share same commentary index
                item.Name = commentaryIndexTeams.First(x => x.CommentaryIndex == 231 + counter).Name;                      // 231 is the first commentary index for teams
                item.FileNamePrefix = commentaryPrefixTeams.First(x => x.CommentaryIndex == 231 + counter).FileNamePrefix; // 231 is the first commentary index for teams

                counter++;
            }

            _configureGameApplicationService.DomainModel.Commentaries.SetCommentaryTeams(commentaryTeams);
        }

        public IEnumerable<int> GetProposedSeriesValuesFromPerformanceCurveChart()
        {
            return _view.GetProposedSeriesValuesFromPerformanceCurveChart();
        }

        public void UpdatePerformanceCurveChartWithHiddenSeriesValues(int[] values)
        {
            _view.UpdatePerformanceCurveChartWithHiddenSeriesValues(values);
        }
    }
}