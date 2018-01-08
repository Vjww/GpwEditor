﻿using System;
using App.BaseGameEditor.Presentation.Controllers;

namespace App
{
    public class Application
    {
        private const string GameFolder = @"C:\gpw";
        private const string TempFolder = @"C:\temp\gpwtest";

        private readonly BaseGameController _baseGameController;
        private readonly TeamController _teamController;

        public Application(
            BaseGameController baseGameController,
            TeamController teamController)
        {
            _baseGameController = baseGameController ?? throw new ArgumentNullException(nameof(baseGameController));
            _teamController = teamController ?? throw new ArgumentNullException(nameof(teamController));
        }

        public void Run()
        {
            _baseGameController.Import(
                $@"{GameFolder}",
                $@"{GameFolder}\gpw.exe",
                $@"{GameFolder}\english.txt",
                $@"{GameFolder}\french.txt",
                $@"{GameFolder}\german.txt",
                $@"{GameFolder}\text\comme.txt",
                $@"{GameFolder}\textf\commf.txt",
                $@"{GameFolder}\textg\commg.txt");

            _teamController.DisplayTeams();

            _baseGameController.Export(
                $@"{TempFolder}",
                $@"{TempFolder}\gpw.exe",
                $@"{TempFolder}\english.txt",
                $@"{TempFolder}\french.txt",
                $@"{TempFolder}\german.txt",
                $@"{TempFolder}\comme.txt",
                $@"{TempFolder}\commf.txt",
                $@"{TempFolder}\commg.txt");
        }
    }
}