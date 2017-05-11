# For IDA v6.1 analysis of Grand Prix World
# Script file to assist with disassembly of gpw.exe v1.01b
# To be applied to gpw.exe v1.01b that has been modified by GpwEdit to:
#     include switch idiom
#     include jump bypass
#     include code shift
#     include global unlock
#     include points system upgrade
#     exclude other enhancements (e.g. no cd, gfx/sfx fixes)

# Mark bytes as functions
#def apply_make_functions():
	# MakeFunction https://www.hex-rays.com/products/ida/support/idadoc/330.shtml
	# MakeFunction(0x0043B117)

# Mark bytes as code
#def apply_make_code():
	# MakeCode https://www.hex-rays.com/products/ida/support/idadoc/201.shtml 
	
# Name and prefix user identified functions to uf_ and names to un_
def apply_names():
	# MakeName https://www.hex-rays.com/products/ida/support/idadoc/203.shtml

	# Random
	MakeName(0x00401000, "uf_GlobalUnlockFix")
	MakeName(0x00435CB8, "uf_IsFileExist")
	MakeName(0x0043B0A8, "uf_CreateFont")

	# Buffers
	MakeName(0x00490B6B, "uf_LoadDataFromFileIntoBuffer")
	MakeName(0x00726AC8, "un_DataBufferByteCount")
	MakeName(0x00726ACC, "un_DataBuffer")
	#MakeName(0x0067D675, "uf_") # TODO does this clear buffer/relocate buffer pointer?

	# Resource strings
	MakeName(0x00513887, "uf_LoadResourceStringValueIntoDataBuffer1")
	MakeName(0x005138E2, "uf_LoadResourceStringValueIntoDataBuffer2")
	MakeName(0x0051393D, "uf_LoadResourceStringValueIntoDataBuffer3")
	
	MakeName(0x005133A7, "uf_LoadResourceStrings")
	MakeName(0x00514991, "uf_LoadResourceStringsIntoGlobalArray") # TODO takes parameters SID, memloc, recordCount, recordSize	
	MakeName(0x00D4E4B8, "un_LoadResourceStringsGlobalTextOverrunCount")
	
	# Startup
	MakeName(0x0067BF70, "uf_IsPrimaryDisplayPowerVr2")
	MakeName(0x00546AE0, "uf_LoadDataFromFileLanguageTxt")
	MakeName(0x0047E128, "uf_LoadDataFromFileGpwCfg")
	MakeName(0x0049D3C8, "uf_SetGpwRegistryKeyPath")
	MakeName(0x00538A80, "uf_SetPowerVr2AppHint")
	MakeName(0x005132D0, "uf_SetLanguage")

	# Window
	MakeName(0x00438D4B, "uf_WndProc")
	MakeName(0x00439569, "uf_LoadWindow")
	MakeName(0x004544C2, "uf_IsCursorWithinXYBounds")
	MakeName(0x0045452F, "uf_IsCursorWithinXBounds")
	MakeName(0x00692C68, "un_WindowHandle1")
	MakeName(0x00692CA0, "un_WindowHandle2")
	MakeName(0x015F2F24, "un_WindowName")
	MakeName(0x00692C70, "un_WindowClientRect")
	
	# Mouse
	MakeName(0x00692C88, "un_WM_LBUTTONDOWN_WPARAM")
	MakeName(0x00692414, "un_WM_LBUTTONDOWN_LPARAM_X")
	MakeName(0x00692418, "un_WM_LBUTTONDOWN_LPARAM_Y")
	MakeName(0x0044F289, "uf_WM_KEYDOWN_Handler1") # TODO why does this switch on dword_15F2C90
	MakeName(0x00420388, "uf_WM_KEYDOWN_Handler2") # TODO why does this switch on dword_15F2C90

	# Graphics
	MakeName(0x0043D7EF, "uf_LoadDirectDraw")
	MakeName(0x004353E0, "uf_LoadDataFromFileTga")

	# Timer20
	MakeName(0x0043005E, "uf_CreateTimer20")
	MakeName(0x015F2AC0, "un_Timer20Counter")
	MakeName(0x004300C6, "uf_GetTimer20Counter")
	MakeName(0x0043008D, "uf_SetTimer20Counter")
	
	# TimerUndefined1
	MakeName(0x014DE2D0, "un_TimerUndefined1")
	MakeName(0x0047AA47, "uf_TimerProcUndefined1")
	MakeName(0x007269C0, "un_TimerUndefined1Counter")

	# Movies
	MakeName(0x00438266, "uf_StartStreamingAvi")
	MakeName(0x004381C0, "uf_StopStreamingAvi")
	MakeName(0x015F2C0C, "un_IsStreamingAvi")
	
    # Commentary
	MakeName(0x00520FB0, "uf_LoadCommentaryResourceStrings")
	MakeName(0x007A7DE0, "un_CommentaryFileNames")
	MakeName(0x0079ED58, "un_CommentaryTranscriptions")

	# Track
	MakeName(0x00491337, "uf_LoadDataFromFileTrackRti")
	MakeName(0x00729A48, "un_LoadDataFromFileTrackRtiCounter")
	
	# Track conditions
	#MakeName(0x0070C798, "uf_TrackDrynessRating") # TODO check conditions or dryness?
	
	# 67D854 = _strchr according to vc32rtf
	# 67CDFA = _sprintf according to vc32rtf

	# TODO sub_514320 - Loads strings containing variable names?
	# TODO sub_514C80 - Loads strings containing display text?

	# Flags
	MakeName(0x015F2C74, "un_IsFileStartDatExist")
	MakeName(0x015F2C78, "un_IsFileBoxonDatExist")
	MakeName(0x015F2C7C, "un_IsFileFrameDatExist")
	MakeName(0x015F2C80, "un_IsFileCoordsDatExist")
	MakeName(0x015F2C84, "un_IsFileUnlimitDatExist")
	MakeName(0x015F2C88, "un_IsFileLowresDatExist")
	MakeName(0x015FA880, "un_IsLanguageEnglish")
	MakeName(0x015FA884, "un_IsLanguageFrench")
	MakeName(0x015FA888, "un_IsLanguageGerman")
	
	# 7169B0 - game speed setting 50-150%
	
	# Sponsorship
	#MakeName(0x004E7A25, "uf_LoadSponsorshipDetails")
	
	# ############################ #
	# IMPORTS FROM GPWXP MIGRATION #
	# ############################ #
	MakeName(0x004AC61A, "uf_XpSponsorOfferLogic") # GpwSponsor_SponsorOfferLogic_Unknown()
	MakeName(0x004AD4F5, "uf_XpCalculateSponsorCash") # GpwSponsor_CalculateSponsorCashOffered(SponsorId, CashTeamSponsorFlag, SupplierDealTypeEnum)
	MakeName(0x004B862D, "uf_XpSponsorRaceAdvantage") # GpwSponsor_RaceAdvantage()
	MakeName(0x004B8ABE, "uf_XpUpdatePayDriverCashCommitment") # GpwStaff_UpdatePayDriverCashCommitment()
	MakeName(0x004B8D8D, "uf_XpCalcPayDriverSalaryNextYear") # GpwStaff_CalcPayDriverSalaryNextYear()
	#TODO MakeName(0x00, "uf_XpGetStaffTypeId") # GpwStaff_GetTypeId
	#TODO MakeName(0x00, "uf_XpIsStaffTypeIdADriver") # GpwStaff_IsTypeIdADriver
	#TODO MakeName(0x00, "uf_XpIsStaffTypeIdAChief") # GpwStaff_IsTypeIdAChief
	MakeName(0x004D23F9, "uf_XpUpdateAttributesForNewSeason") # GpwStaff_UpdateAttributesForNewSeason
	MakeName(0x004D7CD0, "uf_XpReturn20000_HeadHunter") # GpwStaff_GetCostOfStaffHeadHunter
	MakeName(0x004D7CE5, "uf_XpReturn10000") # GpwMisc_Return10000
	MakeName(0x004D7CFA, "uf_XpReturn5000") # GpwMisc_Return5000
	MakeName(0x004D7E80, "uf_XpCalcTotalDriverAbility") # GpwStaff_CalcTotalDriverAbility7To35
	#TODO MakeName(0x00, "uf_XpRetireDriversForNewSeason") # GpwStaff_RetireDriversForNewSeason
	MakeName(0x00509310, "uf_XpInitDesignStruct1") # GpwDesign_InitDesignStruct1_Unknown
	MakeName(0x00509A0E, "uf_XpCalcDesignProductivityResults") # GpwDesign_CalcProductivityResults_Unknown
	MakeName(0x0050B55F, "uf_XpGenerateTechnologyRatings") # GpwDesign_GenerateTechnologyRatings
	MakeName(0x0050C09B, "uf_XpTechnologyValues") # GpwDesign_TechnologyValues_Unknown
	MakeName(0x0050C3C4, "uf_XpCalcCarDesignEfficiencyRating") # GpwDesign_CalcCarDesignEfficiencyRating
	MakeName(0x0050C449, "uf_XpCalcNextYearsHandlingPercentage") # GpwDesign_CalcNextYearsHandlingPercentage
	MakeName(0x0050C7A1, "uf_XpCalcCarDevelopmentEfficiencyRating") # GpwDesign_CalcCarDevelopmentEfficiencyRating
	MakeName(0x0050C826, "uf_XpCalcCarDevelopmentHandlingPercentage") # GpwDesign_CalcCarDevelopmentHandlingPercentage
	MakeName(0x0050CA1D, "uf_XpCalcNextDevelopmentUpgrade") # GpwDesign_CalcNextDevelopmentUpgrade
	MakeName(0x0050CEB5, "uf_XpSubmitDrivingAidForFiaApproval") # GpwDesign_SubmitDrivingAidForFiaApproval
	MakeName(0x0050D41E, "uf_XpCalcThisYearsHandlingPercentage") # GpwDesign_CalcThisYearsHandlingPercentage
	MakeName(0x0050D9F2, "uf_XpCalcAiChassisDevelopmentUpgrade") # GpwDesign_CalcAiChassisDevelopmentUpgrade
	MakeName(0x004F77C3, "uf_XpSponsorshipSupportAndHospitalityAdvantage") # GpwSponsor_SponsorshipSupportAndHospitalityAdvantage
	MakeName(0x004F8F50, "uf_XpUnknownVariableValuesFor0To100Value") # GpwUnknown_VariableValuesFor0To100Value
	#TODO MakeName(0x00, "uf_XpTriggerYellowFlagAndMore") # GpwRace_TriggerYellowFlagAndMore_Unknown
	#TODO MakeName(0x00, "uf_XpReturn0") # GpwMisc_Return0
	MakeName(0x0045223B, "uf_XpChangeViewportChannel") # GpwRace_ChangeChannelInViewport(viewportId, direction)
	MakeName(0x0045269B, "uf_XpUnknownHandleMouseCursorInRects") # GpwUi_UnknownHandlesMouseCursorInRects
	#ALREADYDONE MakeName(ref_IsCursorWithinXYBounds) # GpwMain_IsMouseCursorWithinRect
	MakeName(0x00455B20, "uf_XpInitRaceStruct1") # GpwRace_InitRaceStruct1_Unknown
	#TODO MakeName(0x00, "uf_XpSetRaceCarInformationAndOthers) # GpwRace_SetRaceCarEventInformationAndOthers
	#TODO MakeName(0x00, "uf_XpSaveGameRaceData") # GpwFile_SaveGame_RaceData
	#TODO MakeName(0x00, "uf_XpLoadGameRaceData") # GpwFile_LoadGame_RaceData
	#TODO MakeName(0x00, "uf_XpCheckValueIsGreaterThan0AndLessThan200") # GpwMisc_CheckValueIsGreaterThan0AndLessThan200
	MakeName(0x004271E4, "uf_XpDrawImagev2") # GpwGfx_DrawImage_v2
	MakeName(0x004289DC, "uf_XpDrawImagev1") # GpwGfx_DrawImage_v1
	MakeName(0x0042CDC9, "uf_XpDrawTextv2") # GpwGfx_DrawText_v2
	MakeName(0x0042E495, "uf_XpDrawTextv1") # GpwGfx_DrawText_v1
	#ALREADYDONE MakeName(ref_uf_GetTimer20Counter) # GpwMisc_Return_dword_705B8C
	MakeName(0x0040B842, "uf_XpSetupDirectDrawSurface2") # GpwGfx_SetupDirectDrawSurface2
	MakeName(0x0040B469, "uf_XpSetupDirectDrawSurface1") # GpwGfx_SetupDirectDrawSurface1
	MakeName(0x0040B924, "uf_XpDetermineDirect3DDriverFromGfxDat") # GpwGfx_DetermineDirect3DDriverFromGfxDat
	#IGNORE # GpwGfx_UnknownFunction1
	#IGNORE # GpwGfx_InitDirectXStruct1
	MakeName(0x00417B61, "uf_XpDestroyDirectXObjects") # GpwGfx_DestroyDirectXObjects
	MakeName(0x00417DE1, "uf_XpResetDirectXObjects") # GpwGfx_ResetDirectXObjects
	MakeName(0x00417EBB, "uf_XpCreateDirectXObjects") # GpwGfx_CreateDirectXObjects
	MakeName(0x004181FF, "uf_XpCreateDDAndD3D") # GpwGfx_CreateDDAndD3D
	MakeName(0x004185B3, "uf_XpCreate3DDevice") # GpwGfx_Create3DDevice
	MakeName(0x00418627, "uf_XpCreateBuffers") # GpwGfx_CreateBuffers
	MakeName(0x00418B14, "uf_XpCreateZBuffer") # GpwGfx_CreateZBuffer
	MakeName(0x00418C5D, "uf_XpCreateStatic1") # GpwGfx_CreateStatic1
	MakeName(0x00418D78, "uf_XpCreateStatic2") # GpwGfx_CreateStatic2
	MakeName(0x00418EFD, "uf_XpCreateStatic3") # GpwGfx_CreateStatic3
	MakeName(0x00419082, "uf_XpCreateViewport") # GpwGfx_CreateViewport
	#TODO MakeName(0x00, "uf_XpGetBitRateOfDirectDrawSurface") # GpwGfx_GetBitRateOfDirectDrawSurface
	#TODO MakeName(0x00, "uf_XpInitializeWindowEnvironment") # GpwMain_InitializeWindowEnvironment
	#IGNORE # GpwGfx_OutputDebugInformation1
	#IGNORE # GpwFile_IsFileExist
	#IGNORE # GpwMisc_GetRandomValue_v2
	#IGNORE # GpwFile_LoadTgaImage
	#IGNORE # GpwMain_InitializeRaceEnvironment
	#IGNORE # GpwFile_LoadFileIntoBuffer
	MakeName(0x00412EE0, "uf_XpLoadImages") # GpwFile_LoadImage
	#IGNORE # GpwFile_LoadImageFromImageArray
    #IGNORE # GpwFile_LoadFileFromAlternateSource
    #IGNORE # GpwFile_LoadTextIntoGlobalArrays
	MakeName(0x0046DA6B, "uf_XpInitGameData") # GpwMain_InitGameData_Unknown
	MakeName(0x0046E4C8, "uf_XpInitStaffStruct2") # GpwStaff_InitStaffStruct2_Unknown
	MakeName(0x004706D7, "uf_XpInitStaffStruct1") # GpwStaff_InitStaffStruct1_Unknown
	MakeName(0x0047BA2E, "uf_XpSaveGame") # GpwFile_SaveGame
	MakeName(0x0047CDFB, "uf_XpLoadGame") # GpwFile_LoadGame
	#ALREADYDONE MakeName(ref_uf_LoadDataFromFileGpwCfg) # GpwFile_ReadFromGpwConfigFile
	#SUGGESTION 47E090 - WriteGpwCfgFile
	MakeName(0x0047F27C, "uf_XpPostSeasonFunctionUnknown") # GpwRace_PostSeasonFunction_Unknown1
	#IGNORE # GpwFile_CheckFileExists
	MakeName(0x004806F4, "uf_XpPostRaceFunction2") # GpwRace_PostRaceFunction_Unknown2
	MakeName(0x00480D87, "uf_XpPostRaceFunction1") # GpwRace_PostRaceFunction_Unknown
	MakeName(0x00484BA2, "uf_XpMoraleManagementUnknown") # GpwStaff_MoraleManagement_Unknown
	#TODO MakeName(0x00, "uf_XpChangeMoraleForAllDrivers") # GpwStaff_ChangeMoraleForAllDrivers
	#TODO MakeName(0x00, "uf_XpAddValueToAttributeUnknown") # GpwStaff_AddValueToAttribute_Unknown
	#TODO MakeName(0x00, "uf_XpChangeMoraleForOneOrAllDepartments") # GpwStaff_ChangeMoraleForOneOrAllDepartments (if equal to 6, change all departments)
	#TODO MakeName(0x00, "uf_XpGetAttributeSkill") # GpwStaff_GetAttribute_Skill
	#ALREADYDONE MakeName(ref_uf_SetLanguage) # GpwText_SetLanguage
	#ALREADYDONE MakeName(ref_uf_LoadResourceStrings) # GpwText_LoadTextResource
	MakeName(0x0051371B, "uf_XpLoadResourceString3") # GpwText_GetTextFromLanguageFile3
	MakeName(0x00513776, "uf_XpLoadResourceString2") # GpwText_GetTextFromLanguageFile2
	MakeName(0x005137D1, "uf_XpLoadResourceString1") # GpwText_GetTextFromLanguageFile1
	#ALREADYDONE MakeName(ref_uf_LoadResourceStringValueIntoDataBuffer1) # GpwText_GetTextFromLanguageFile4
	#ALREADYDONE MakeName(ref_uf_LoadResourceStringValueIntoDataBuffer2) # GpwText_GetTextFromLanguageFile5
	#ALREADYDONE MakeName(ref_uf_LoadResourceStringValueIntoDataBuffer3) # GpwText_GetTextFromLanguageFile6
	MakeName(0x005139F3, "uf_XpIsStringIdValid") # GpwText_IsStringIdValid
	MakeName(0x004FF4A0, "uf_XpPostRaceManagement") # GpwStaff_PostRaceManagement
	MakeName(0x0050042D, "uf_XpStarWorkersToNormal") # GpwMail_StarWorkersReturningToNormal
	MakeName(0x00500BC5, "uf_XpStaffRetirementCancelledMail") # GpwMail_StaffRetirementCancelled
	MakeName(0x00501323, "uf_XpFinancialYearProfitLoss") # GpwMail_FinancialYearProfitLoss
	MakeName(0x00501D2E, "uf_XpStaffLabourShortage") # GpwMail_StaffLabourShortage
	#TODO MakeName(0x00, "uf_XpChangeReduceMorale") # GpwStaff_ChangeMorale_ReduceMorale
	MakeName(0x004FA8B0, "uf_XpManagerPerformanceAlerts1") # GpwMail_ManagerPerformanceNotifications_InclNewsItems_v1
	MakeName(0x004FB35B, "uf_XpManagerPerformanceAlerts2") # GpwMail_ManagerPerformanceNotifications_InclNewsItems_v2
	MakeName(0x004FBA1B, "uf_XpCreateNewsItem") # GpwNews_CreateItem
	MakeName(0x004FCE70, "uf_XpStaffRetirementCancelledNews") # GpwNews_StaffRetirementCancelled
	MakeName(0x004FE13F, "uf_XpCreateNewsImageTeamLogo") # GpwNews_CreateImage_TeamLogo
	MakeName(0x004FE18E, "uf_XpCreateNewsImageDriverHead") # GpwNews_CreateImage_DriverHead
	MakeName(0x004FE238, "uf_XpCreateNewsImageFiaLogo") # GpwNews_CreateImage_FiaLogo
	#ALREADYDONE MakeName(ref_uf_SetPowerVr2AppHint) # GpwGfx_SetAppHintEnableVPFix1
	MakeName(0x005210D1, "uf_XpPlaySounds") # GpwRace_PlaySounds
	#IGNORE # GpwText_SetPathToRegistryKey
	#IGNORE # GpwText_GetValueFromRegistryKeyInstall2
	#IGNORE # GpwText_GetValueFromRegistryKeyInstall1
	MakeName(0x0051A3D6, "uf_XpDrawRaceCarEventInformation") # GpwRace_DrawRaceCarEventInformation
	MakeName(0x004E70A0, "uf_XpInitSponsorStruct2") # GpwSponsors_InitSponsorStruct2
	MakeName(0x004E7A25, "uf_XpInitSponsorStruct1") # GpwSponsors_InitSponsorStruct1
	MakeName(0x004EEC35, "uf_XpChangeCashAndRndCommitmentUnknown") # GpwSponsor_IncreaseDecreaseCashAndRndCommitment_Unknown
	MakeName(0x00502980, "uf_XpInitTrackStruct1Unknown") # GpwTrack_InitTrackStruct1_Unknown
	#IGNORE # GpwMisc_GetRandomValue
	MakeName(0x00499183, "uf_XpStringFormatIntToCurrency") # GpwMisc_StringFormatIntToCurrency
	#IGNORE # GpwMain_WndProc
	#IGNORE # GpwMain_CreateGameWindow
	MakeName(0x004396CC, "uf_XpGameLoop") # GpwMain_GameLoop
	MakeName(0x00439DEA, "uf_XpInitialize3DEnvironment") # GpwMain_Initialize3DEnvironment
	MakeName(0x0043AB84, "uf_XpIsGameCdInserted") # GpwMain_IsGameCdInserted
	#ALREADYDONE MakeName(ref_uf_CreateFont) # GpwMain_CreateFontArial
	MakeName(0x0062E5AE, "uf_XpHugeSponsorDrawingMethodUnknown") # GpwSponsor_HUGE_SetupAndDrawingMethod_Unknown
	MakeName(0x00601293, "uf_XpCarDesignMouseEvents2") # GpwDesign_CarDesignMouseEvents_Unknown_v2
	#TODO MakeName(0x00, "uf_XpInitSupplierStruct1") # GpwSupplier_InitSupplierStruct1_Unknown
	MakeName(0x005D9435, "uf_XpCarDesignMouseEvents1") # GpwDesign_CarDesignMouseEvents_Unknown
	MakeName(0x005DD3FA, "uf_XpInternalTechnologyConstructionUnknown") # GpwDesign_InternalTechnologyConstruction_Unknown
	MakeName(0x005DEB2F, "uf_XpDriverAidConstructionUnknown") # GpwDesign_DriverAidConstruction_Unknown
	MakeName(0x005AD880, "uf_XpFiaRankingChanges") # GpwFia_FiaRankingChanges
	#ALREADYDONE MakeName(ref_uf_LoadDataFromFileLanguageTxt) # GpwText_DetermineLanguageFromLanguageTxt
	#TODO MakeName(0x00, "uf_XpLicensingUnknown") # GpwLicensing_Unknown1
	MakeName(0x005AB08B, "uf_XpCreateMailItem") # GpwMail_CreateItem
	MakeName(0x00556923, "uf_XpDrawSectionTeamProfile") # GpwGfx_DrawSection_TeamProfile
	#TODO MakeName(0x00, "uf_Xp") # GpwStaff_GetUnadjustedTotalStaffTimeUnits
	#TODO MakeName(0x00, "uf_Xp") # GpwStaff_GetAdjustedTotalStaffTimeUnits
	#TODO MakeName(0x00, "uf_Xp") # GpwMisc_Convert_0to100_To_1to5_v1
	#TODO MakeName(0x00, "uf_Xp") # GpwMisc_Convert_0to100_To_1to5_v2
	#TODO MakeName(0x00, "uf_Xp") # GpwMisc_Convert_1to5_To_20to100
	#IGNORE # GpwLicensing_Unknown2
	#TODO MakeName(0x00, "uf_Xp") # GpwStaff_IsDriverSignedForNextYear
	#TODO MakeName(0x00, "uf_Xp") # GpwStaff_IsChiefSignedForNextYear
	#TODO MakeName(0x00, "uf_Xp") # GpwGfx_DrawConfirmationMessageBox
	#TODO MakeName(0x00, "uf_Xp") # GpwRace_CalcPostRacePoints
	#TODO MakeName(0x00, "uf_Xp") # GpwManager_CalcHallOfFamePointsForEndOfYear
	MakeName(0x00620788, "uf_XpUpdateDriverMorale") # GpwStaff_UpdateDriverMorale
	#ALREADYDONE MakeName(ref_uf_IsPrimaryDisplayPowerVr2) # GpwGfx_IsPrimaryDisplayPowerVR2
	# ###################### #
	# END OF GPWXP MIGRATION #
	# ###################### #
	
# Add comments
#def apply_comments():
	# MakeComm https://www.hex-rays.com/products/ida/support/idadoc/204.shtml 

################################################################################

#apply_make_functions()
#apply_make_codes()
apply_names()
#apply_comments()
