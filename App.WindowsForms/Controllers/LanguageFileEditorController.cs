using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.BaseGameEditor.Infrastructure.Services;
using App.LanguageFileEditor.Application.Services.Application;
using App.LanguageFileEditor.Domain.Entities;
using App.WindowsForms.Factories;
using App.WindowsForms.Models;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class LanguageFileEditorController : ControllerBase
    {
        private LanguageFileEditorForm _view;

        private readonly LanguageFileEditorApplicationService _languageFileEditorApplicationService;
        private readonly FormFactory _formFactory;

        public LanguageFileEditorController(
            LanguageFileEditorApplicationService languageFileEditorApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _languageFileEditorApplicationService = languageFileEditorApplicationService ?? throw new ArgumentNullException(nameof(languageFileEditorApplicationService));
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<LanguageFileEditorForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public void Import()
        {
            _languageFileEditorApplicationService.Import(
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

            _languageFileEditorApplicationService.Export(
                _view.GameFolderPath,
                _view.GameExecutableFilePath,
                _view.EnglishLanguageFilePath,
                _view.FrenchLanguageFilePath,
                _view.GermanLanguageFilePath,
                _view.EnglishCommentaryFilePath,
                _view.FrenchCommentaryFilePath,
                _view.GermanCommentaryFilePath);
        }

        public void UpdateDomainModelWithValues()
        {
            // TODO: Example controller method that can be called by the view to update the model

            throw new NotImplementedException();
        }

        private void UpdateModelsFromService()
        {
            _view.Languages = UpdateModelFromService<IEnumerable<LanguageEntity>, IEnumerable<LanguageModel>>(_languageFileEditorApplicationService.DomainModel.Languages.GetLanguages);
        }

        private void UpdateServiceFromModels()
        {
            UpdateServiceFromModel<IEnumerable<LanguageModel>, IEnumerable<LanguageEntity>>(_languageFileEditorApplicationService.DomainModel.Languages.SetLanguages, _view.Languages);
        }
    }
}