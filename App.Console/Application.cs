﻿using System;
using App.Console.Controllers;

namespace App.Console
{
    public class Application
    {
        private const string GameFolder = @"C:\gpw";
        private const string TempFolder = @"C:\temp\gpwtest";

        private readonly BaseGameController _baseGameController;
        private readonly TeamController _teamController;
        private readonly PersonController _personController;
        private readonly SupplierController _supplierController;
        private readonly TrackController _trackController;
        private readonly PerformanceCurveController _performanceCurveController;

        public Application(
            BaseGameController baseGameController,
            TeamController teamController,
            PersonController personController,
            SupplierController supplierController,
            TrackController trackController,
            PerformanceCurveController performanceCurveController)
        {
            _baseGameController = baseGameController ?? throw new ArgumentNullException(nameof(baseGameController));
            _teamController = teamController ?? throw new ArgumentNullException(nameof(teamController));
            _personController = personController ?? throw new ArgumentNullException(nameof(personController));
            _supplierController = supplierController ?? throw new ArgumentNullException(nameof(supplierController));
            _trackController = trackController ?? throw new ArgumentNullException(nameof(trackController));
            _performanceCurveController = performanceCurveController ?? throw new ArgumentNullException(nameof(performanceCurveController));
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
            _personController.DisplayPersons();
            _supplierController.DisplaySuppliers();
            _trackController.DisplayTracks();
            _performanceCurveController.DisplayPerformanceCurves();

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