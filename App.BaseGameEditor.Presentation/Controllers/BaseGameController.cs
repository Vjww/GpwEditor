﻿using System;
using App.BaseGameEditor.Application.DomainServices;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class BaseGameController : IController
    {
        private readonly DomainService _dataService;

        public BaseGameController(DomainService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public void Export(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            // TODO: Validation of file paths in presentation layer?

            _dataService.Export(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);
        }

        public void Import(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            // TODO: Validation of file paths in presentation layer?

            _dataService.Import(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);
        }
    }
}