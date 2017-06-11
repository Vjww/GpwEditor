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

scriptTitle = "***** Grand Prix World *****"
	
appliedNameAddress = []

def NameAddress(address, name):
	#global appliedNameAddress
	for applied in appliedNameAddress:
		if applied == address:
			print("Duplicate address found at 0x{0:08x}".format(address))
	MakeName(address, name) # MakeName https://www.hex-rays.com/products/ida/support/idadoc/203.shtml
	appliedNameAddress.append(address)
	
# Name and prefix user identified functions to uf_ and names to un_
def apply_names():
	# Random
	NameAddress(0x00401000, "uf_GlobalUnlockFix")
	NameAddress(0x00435CB8, "uf_IsFileExist")
	NameAddress(0x0043B0A8, "uf_CreateFont")
	NameAddress(0x00498A5A, "uf_GetRandomNumber")

	# Buffers
	NameAddress(0x00490B6B, "uf_LoadDataFromFileIntoBuffer")
	NameAddress(0x00726AC8, "un_DataBufferByteCount")
	NameAddress(0x00726ACC, "un_DataBuffer")
	#NameAddress(0x0067D675, "uf_") # TODO does this clear buffer/relocate buffer pointer?

	# Resource strings
	NameAddress(0x00513887, "uf_LoadResourceStringValueIntoDataBuffer1")
	NameAddress(0x005138E2, "uf_LoadResourceStringValueIntoDataBuffer2")
	NameAddress(0x0051393D, "uf_LoadResourceStringValueIntoDataBuffer3")
	
	NameAddress(0x005133A7, "uf_LoadResourceStrings")
	NameAddress(0x00514991, "uf_LoadResourceStringsIntoGlobalArray") # TODO takes parameters SID, memloc, recordCount, recordSize	
	NameAddress(0x00D4E4B8, "un_LoadResourceStringsGlobalTextOverrunCount")

	NameAddress(0x00D4B2F0, "un_ResourceStringArray_Index5696_Size020_Count012_Team")
	NameAddress(0x00D4B0C0, "un_ResourceStringArray_Index5708_Size020_Count012_TeamShortChassis")
	NameAddress(0x00D4E580, "un_ResourceStringArray_Index5720_Size030_Count011")
	NameAddress(0x00D4E440, "un_ResourceStringArray_Index5731_Size020_Count006")
	NameAddress(0x00D4E160, "un_ResourceStringArray_Index5744_Size020_Count024")
	NameAddress(0x00D4DB30, "un_ResourceStringArray_Index5769_Size040_Count026")
	NameAddress(0x00D4E6D0, "un_ResourceStringArray_Index5795_Size040_Count140_Person")
	NameAddress(0x00D4BAF0, "un_ResourceStringArray_Index5936_Size020_Count016_NationalityShort")
	NameAddress(0x00D4C890, "un_ResourceStringArray_Index5952_Size020_Count016_NationalityLong")
	NameAddress(0x00D4FEC0, "un_ResourceStringArray_Index5967_Size020_Count019")
	NameAddress(0x00D50420, "un_ResourceStringArray_Index5986_Size020_Count012_Chassis")
	NameAddress(0x00D4D190, "un_ResourceStringArray_Index5998_Size020_Count008")
	NameAddress(0x00D4D400, "un_ResourceStringArray_Index6006_Size020_Count020")
	NameAddress(0x00D4C9D0, "un_ResourceStringArray_Index6026_Size040_Count017_TrackLong")
	NameAddress(0x00D4D860, "un_ResourceStringArray_Index6043_Size020_Count017_TrackShort")
	NameAddress(0x00D4B730, "un_ResourceStringArray_Index6060_Size025_Count009")
	NameAddress(0x00D507B0, "un_ResourceStringArray_Index6069_Size025_Count006")
	NameAddress(0x00D4C590, "un_ResourceStringArray_Index6075_Size025_Count006")
	NameAddress(0x00D4FDB0, "un_ResourceStringArray_Index6081_Size020_Count013")
	NameAddress(0x00D50890, "un_ResourceStringArray_Index6094_Size005_Count013")
	NameAddress(0x00D4CD00, "un_ResourceStringArray_Index6107_Size004_Count007")
	NameAddress(0x00D4CDA0, "un_ResourceStringArray_Index6114_Size020_Count011")
	NameAddress(0x00D50040, "un_ResourceStringArray_Index6125_Size030_Count003")
	NameAddress(0x00D505E0, "un_ResourceStringArray_Index6128_Size020_Count004")
	NameAddress(0x00D4D0A0, "un_ResourceStringArray_Index6132_Size030_Count008")
	NameAddress(0x00D4CE80, "un_ResourceStringArray_Index6140_Size030_Count018")
	NameAddress(0x00D4BC30, "un_ResourceStringArray_Index6158_Size030_Count017")
	NameAddress(0x00D508E0, "un_ResourceStringArray_Index6175_Size020_Count003")
	NameAddress(0x00D4D3B0, "un_ResourceStringArray_Index6178_Size020_Count004")
	NameAddress(0x00D4C630, "un_ResourceStringArray_Index6182_Size050_Count007")
	NameAddress(0x00D4C430, "un_ResourceStringArray_Index6189_Size050_Count007")
	NameAddress(0x00D4D820, "un_ResourceStringArray_Index6196_Size020_Count003")
	NameAddress(0x00D4E030, "un_ResourceStringArray_Index6199_Size100_Count003")
	NameAddress(0x00D50720, "un_ResourceStringArray_Index6202_Size020_Count007")
	NameAddress(0x00D4D6F0, "un_ResourceStringArray_Index6209_Size020_Count015")
	NameAddress(0x00D50630, "un_ResourceStringArray_Index6224_Size030_Count008")
	NameAddress(0x00D4FCF0, "un_ResourceStringArray_Index6231_Size030_Count006")
	NameAddress(0x00D4B3E0, "un_ResourceStringArray_Index6237_Size060_Count012_HeadquartersLocation")
	NameAddress(0x00D4E000, "un_ResourceStringArray_Index6249_Size020_Count002")
	NameAddress(0x00D4B1B0, "un_ResourceStringArray_Index6251_Size020_Count002")
	NameAddress(0x00D4DA80, "un_ResourceStringArray_Index6253_Size020_Count002")
	NameAddress(0x00D4DAB0, "un_ResourceStringArray_Index6255_Size020_Count006")
	NameAddress(0x00D4B2A0, "un_ResourceStringArray_Index6261_Size020_Count004")
	NameAddress(0x00D4D9C0, "un_ResourceStringArray_Index6265_Size030_Count006")
	NameAddress(0x00D4B1E0, "un_ResourceStringArray_Index6271_Size030_Count006")
	NameAddress(0x00D4DF40, "un_ResourceStringArray_Index6277_Size030_Count006")
	NameAddress(0x00D4E4C0, "un_ResourceStringArray_Index6283_Size030_Count006")
	NameAddress(0x00D4CC80, "un_ResourceStringArray_Index6289_Size030_Count004")
	NameAddress(0x00D4D590, "un_ResourceStringArray_Index6293_Size030_Count006")
	NameAddress(0x00D4C810, "un_ResourceStringArray_Index6299_Size030_Count004")
	NameAddress(0x00D4CD20, "un_ResourceStringArray_Index6303_Size020_Count006")
	NameAddress(0x00D50510, "un_ResourceStringArray_Index6309_Size020_Count005")
	NameAddress(0x00D50390, "un_ResourceStringArray_Index6314_Size020_Count007")
	NameAddress(0x00D4BA60, "un_ResourceStringArray_Index6321_Size020_Count007")
	NameAddress(0x00D4D650, "un_ResourceStringArray_Index6328_Size030_Count005")
	NameAddress(0x00D4B820, "un_ResourceStringArray_Index6333_Size040_Count004")
	NameAddress(0x00D4B940, "un_ResourceStringArray_Index6337_Size040_Count003")
	NameAddress(0x00D4B9C0, "un_ResourceStringArray_Index6340_Size030_Count005")
	NameAddress(0x00D4BE30, "un_ResourceStringArray_Index6345_Size030_Count047")
	NameAddress(0x00D4C3C0, "un_ResourceStringArray_Index6392_Size020_Count005")
	NameAddress(0x00D500A0, "un_ResourceStringArray_Index6397_Size030_Count030")
	NameAddress(0x00D4B6B0, "un_ResourceStringArray_Index6422_Size020_Count006")
	NameAddress(0x00D4B8C0, "un_ResourceStringArray_Index6428_Size020_Count006")
	NameAddress(0x00D50580, "un_ResourceStringArray_Index6432_Size015_Count006")
	NameAddress(0x00D4FCB0, "un_ResourceStringArray_Index6438_Size015_Count004")
	NameAddress(0x00D4C790, "un_ResourceStringArray_Index6442_Size020_Count006")
	NameAddress(0x00D50850, "un_ResourceStringArray_Index6448_Size020_Count003")
	NameAddress(0x00D4D300, "un_ResourceStringArray_Index6451_Size020_Count006")
	NameAddress(0x00D4D380, "un_ResourceStringArray_Index6457_Size004_Count012_TeamShort")
	NameAddress(0x00D4A850, "un_ResourceStringArray_Index6469_Size020_Count004")
	NameAddress(0x00D4A710, "un_ResourceStringArray_Index6473_Size020_Count005")
	NameAddress(0x00D4B070, "un_ResourceStringArray_Index6478_Size020_Count004")
	NameAddress(0x00D4A6C0, "un_ResourceStringArray_Index6482_Size020_Count004")
	NameAddress(0x00D4AEB0, "un_ResourceStringArray_Index6486_Size003_Count012_TeamShortSupplier")
	NameAddress(0x00D4A800, "un_ResourceStringArray_Index6498_Size020_Count004")
	NameAddress(0x00D4A910, "un_ResourceStringArray_Index6502_Size030_Count008")
	NameAddress(0x00D49E90, "un_ResourceStringArray_Index6510_Size020_Count003")
	NameAddress(0x00D4B030, "un_ResourceStringArray_Index6513_Size020_Count003")
	NameAddress(0x00D4AFB0, "un_ResourceStringArray_Index6516_Size020_Count006")
	NameAddress(0x00D49F40, "un_ResourceStringArray_Index6522_Size020_Count003")
	NameAddress(0x00D4AC60, "un_ResourceStringArray_Index6525_Size020_Count004")
	NameAddress(0x00D4AEE0, "un_ResourceStringArray_Index6529_Size040_Count005_PersonFastestLapDriver")
	NameAddress(0x00D4A8A0, "un_ResourceStringArray_Index6534_Size020_Count005")
	NameAddress(0x00D49ED0, "un_ResourceStringArray_Index6539_Size020_Count005")
	NameAddress(0x00D4ADF0, "un_ResourceStringArray_Index6544_Size020_Count009")
	NameAddress(0x00D4A040, "un_ResourceStringArray_Index6553_Size050_Count011")
	NameAddress(0x00D4AA80, "un_ResourceStringArray_Index6564_Size050_Count004")
	NameAddress(0x00D4A330, "un_ResourceStringArray_Index6568_Size050_Count018")
	NameAddress(0x00D4AA00, "un_ResourceStringArray_Index6586_Size020_Count006")
	NameAddress(0x00D49F80, "un_ResourceStringArray_Index6592_Size020_Count009")
	NameAddress(0x00D4AB50, "un_ResourceStringArray_Index6601_Size030_Count009")
	NameAddress(0x00D4A780, "un_ResourceStringArray_Index6610_Size030_Count004")
	NameAddress(0x00D4ACB0, "un_ResourceStringArray_Index6614_Size040_Count008")
	NameAddress(0x00D4A266, "un_ResourceStringArray_Index6622_Size050_Count004")
	NameAddress(0x00D4E340, "un_ResourceStringArray_Index6626_Size050_Count005")
	NameAddress(0x00D4D230, "un_ResourceStringArray_Index6631_Size050_Count004")

	
	# Startup
	NameAddress(0x0067BF70, "uf_IsPrimaryDisplayPowerVr2")
	NameAddress(0x00546AE0, "uf_LoadDataFromFileLanguageTxt")
	NameAddress(0x0047E128, "uf_LoadDataFromFileGpwCfg")
	NameAddress(0x0049D3C8, "uf_SetGpwRegistryKeyPath")
	NameAddress(0x00538A80, "uf_SetPowerVr2AppHint")
	NameAddress(0x005132D0, "uf_SetLanguage")

	# Window
	NameAddress(0x00438D4B, "uf_WndProc")
	NameAddress(0x00439569, "uf_LoadWindow")
	NameAddress(0x004544C2, "uf_IsCursorWithinXYBounds")
	NameAddress(0x0045452F, "uf_IsCursorWithinXBounds")
	NameAddress(0x00692C68, "un_WindowHandle1")
	NameAddress(0x00692CA0, "un_WindowHandle2")
	# NameAddress(0x015F2F24, "un_WindowName") # lpCaption???
	NameAddress(0x00692C70, "un_WindowClientRect")
	
	# Mouse
	NameAddress(0x00692C88, "un_WM_LBUTTONDOWN_WPARAM")
	NameAddress(0x00692414, "un_WM_LBUTTONDOWN_LPARAM_X")
	NameAddress(0x00692418, "un_WM_LBUTTONDOWN_LPARAM_Y")
	NameAddress(0x0044F289, "uf_WM_KEYDOWN_Handler1") # TODO why does this switch on dword_15F2C90
	NameAddress(0x00420388, "uf_WM_KEYDOWN_Handler2") # TODO why does this switch on dword_15F2C90

	# Graphics
	NameAddress(0x0043D7EF, "uf_LoadDirectDraw")
	NameAddress(0x004353E0, "uf_LoadDataFromFileTga")

	# Timer20
	NameAddress(0x0043005E, "uf_CreateTimer20")
	NameAddress(0x015F2AC0, "un_Timer20Counter")
	NameAddress(0x004300C6, "uf_GetTimer20Counter")
	NameAddress(0x0043008D, "uf_SetTimer20Counter")
	
	# TimerUndefined1
	NameAddress(0x014DE2D0, "un_TimerUndefined1")
	NameAddress(0x0047AA47, "uf_TimerProcUndefined1")
	NameAddress(0x007269C0, "un_TimerUndefined1Counter")

	# Movies
	NameAddress(0x00438266, "uf_StartStreamingAvi")
	NameAddress(0x004381C0, "uf_StopStreamingAvi")
	NameAddress(0x015F2C0C, "un_IsStreamingAvi")

	# Commentary
	NameAddress(0x00520FB0, "uf_LoadCommentaryResourceStrings")
	NameAddress(0x007A7DE0, "un_CommentaryFileNames")
	NameAddress(0x0079ED58, "un_CommentaryTranscriptions")

	# Track
	NameAddress(0x00491337, "uf_LoadDataFromFileTrackRti")
	NameAddress(0x00729A48, "un_LoadDataFromFileTrackRtiCounter")

	# Testing
	NameAddress(0x00878504, "un_TestingProgressDevelopment_Unknown")
	
	NameAddress(0x0087848C, "un_EngineeringNextYearCarCount")
	NameAddress(0x00878490, "un_EngineeringSpareCount")
	
	# Options
	NameAddress(0x01535EF8, "un_OptionConfirmationMessagesFlag")

	
	# Track conditions
	#NameAddress(0x0070C798, "uf_TrackDrynessRating") # TODO check conditions or dryness?
	
	# 67D854 = _strchr according to vc32rtf
	# 67CDFA = _sprintf according to vc32rtf

	# TODO sub_514320 - Loads strings containing variable names?
	# TODO sub_514C80 - Loads strings containing display text?

	# Flags
	NameAddress(0x015F2C74, "un_IsFileStartDatExist")
	NameAddress(0x015F2C78, "un_IsFileBoxonDatExist")
	NameAddress(0x015F2C7C, "un_IsFileFrameDatExist")
	NameAddress(0x015F2C80, "un_IsFileCoordsDatExist")
	NameAddress(0x015F2C84, "un_IsFileUnlimitDatExist")
	NameAddress(0x015F2C88, "un_IsFileLowresDatExist")
	NameAddress(0x015FA880, "un_IsLanguageEnglish")
	NameAddress(0x015FA884, "un_IsLanguageFrench")
	NameAddress(0x015FA888, "un_IsLanguageGerman")
	
	# 7169B0 - game speed setting 50-150%
	
	# Sponsorship
	#NameAddress(0x004E7A25, "uf_LoadSponsorshipDetails")
	
	# Financial
	NameAddress(0x012039E0, "un_PreviousBalance_Unknown")
	NameAddress(0x01202FB0, "un_CurrentBalance")
	
	# News
	NameAddress(0x00500C57, "uf_MailChiefVacancyAlerts1")
	NameAddress(0x00500E76, "uf_MailChiefVacancyAlerts2")	

	NameAddress(0x014E0A70, "un_ResourceStringBufferUnknown1")
	NameAddress(0x014E0E60, "un_ResourceStringBufferUnknown2")
	
	# Unknown (temporary memory area values?)
	NameAddress(0x0148CBF0, "un_TeamId_Unknown")
	NameAddress(0x0148CC00, "un_Salary_Unknown")
	NameAddress(0x0148CC04, "un_RaceBonus_Unknown")
	NameAddress(0x0148CC08, "un_ChampionshipBonus_Unknown")


	NameAddress(0x004CF9F7, "uf_IsPersonInTeamAndOfTypeUnknown")
	NameAddress(0x004CFA77, "uf_IsPersonOfTypeDriver")
	NameAddress(0x004DD547, "uf_ProcessPersonRetirementFlags")
	NameAddress(0x00482598, "uf_GetPersonAttribute_Championships")
	NameAddress(0x004FCE09, "uf_News_Person_RetirementPending")
	NameAddress(0x00500B33, "uf_Mail_Person_RetirementPending")
	NameAddress(0x004FCE70, "uf_News_Person_RetirementCancelled")
	NameAddress(0x00500BC5, "uf_Mail_Person_RetirementCancelled")
	
	NameAddress(0x004FE4B7, "uf_News_Person_InjuryReturning")
	

	# Person
	NameAddress(0x0116C400, "un_Person_Type")
	NameAddress(0x0116C404, "un_Person_Index_Unknown")
	NameAddress(0x0116C408, "un_Person_TeamThisYear_Unknown")
	NameAddress(0x0116C40C, "un_Person_TeamNextYear_Unknown1")
	NameAddress(0x0116C410, "un_Person_TeamNextYear_Unknown2")
	NameAddress(0x0116C414, "un_Person_Salary")
	NameAddress(0x0116C418, "un_Person_Age")
	NameAddress(0x0116C41C, "un_Person_RaceBonus")
	NameAddress(0x0116C420, "un_Person_ChampionshipBonus")
	NameAddress(0x0116C424, "un_Person_Royalty")
	NameAddress(0x0116C428, "un_Person_Ability")
	NameAddress(0x0116C430, "un_Person_Points")
	NameAddress(0x0116C43C, "un_Person_Wins")
	NameAddress(0x0116C440, "un_Person_PolePosition")
	NameAddress(0x0116C4A8, "un_Person_Nationality")
	NameAddress(0x0116C4AC, "un_Person_DriverLoyalty")
	NameAddress(0x0116C434, "un_XpPersonAttributeUnknown1")
	NameAddress(0x0116C4B0, "un_Person_ContractLength_Unknown1")
	NameAddress(0x0116C4C0, "un_Person_ContractLength_Unknown2")
	NameAddress(0x0116C4C4, "un_Person_ContractYear_Unknown1")
	# 116C4C8 -> 116D008 has memory reset on new season
	NameAddress(0x0116C4C8, "un_Person_SalaryNextYear_Unknown")
	NameAddress(0x0116C4D4, "un_Person_RaceBonusNextYear_Unknown")
	NameAddress(0x0116C4E0, "un_Person_ChampionshipBonusNextYear_Unknown")
	NameAddress(0x0116C4EC, "un_Person_ContractLengthNextYear_Unknown")
	# 116C4C8 -> 116D008 has memory reset on new season
	NameAddress(0x0116D040, "un_Person_Speed")
	NameAddress(0x0116D044, "un_Person_Overtaking")
	NameAddress(0x0116D048, "un_Person_WetWeather")
	NameAddress(0x0116D04C, "un_Person_Concentration")
	NameAddress(0x0116D050, "un_Person_Experience")
	NameAddress(0x0116D054, "un_Person_Stamina")
	NameAddress(0x0116D058, "un_Person_Morale")
	NameAddress(0x0116D05C, "un_Person_MoraleChange_Unknown")
	NameAddress(0x0116D060, "un_Person_Skill")
	NameAddress(0x0116D078, "un_Person_Championships")
	NameAddress(0x0116D07C, "un_Person_Races")
	NameAddress(0x0116D084, "un_Person_PointsFinishes")
	NameAddress(0x0116D088, "un_Person_FastestLaps")
	NameAddress(0x0116D0C0, "un_Person_RetirementPendingFlag")
	NameAddress(0x0116D0C4, "un_Person_RetirementCancelledFlag")
	NameAddress(0x0116D0C8, "un_Person_RetirementCurrentFlag")
	NameAddress(0x0116D0D0, "un_Person_RetirementReturningFlag")
	NameAddress(0x0116D0CC, "un_Person_Unknown2")
	NameAddress(0x0116D0D4, "un_Person_Unknown3")
	NameAddress(0x0116D0D8, "un_Person_Unknown4")
	
	NameAddress(0x0116D138, "un_Person_TeamOrdersFlag_Unknown2")
	NameAddress(0x0116D13C, "un_Person_TeamOrdersFlag_Unknown1")
	NameAddress(0x0116D118, "un_Person_DriverRole_Unknown1Normal")
	NameAddress(0x0116D070, "un_Person_DriverRole_Unknown2Temporary")

	NameAddress(0x0116D1C4, "un_Person_InjuryReturningFlag_Unknown")
	NameAddress(0x0116D0DC, "un_Person_InjuryLengthRemaining_Unknown")
	
	NameAddress(0x0116D144, "un_Person_TeamOrdersDriverAbsentFlag_Unknown")
	NameAddress(0x0116D148, "un_Person_TeamOrdersDriverReturningFlag_Unknown")
	
	NameAddress(0x0116D008, "un_Person_TypeNextYear")
	NameAddress(0x0116D06C, "un_XpPersonAttributePayDriverLevel1To5") # GpwStaff_Attribute_PayDriverLevel1To5
	NameAddress(0x0116D068, "un_XpPersonAttributePayDriverSalaryNextYearUnknown") # GpwStaff_Attribute_PayDriverSalaryNextYear_Unknown
	NameAddress(0x0116D10C, "un_Person_PersonTypeUnknown_Unknown")
	NameAddress(0x0116D1E8, "un_Person_FirstPolePositionFlag")
	# Max 116D1F8		

	# Season
	NameAddress(0x0116C42C, "un_Person_SeasonPoints_Unknown")
	NameAddress(0x0116C444, "un_Person_SeasonPolePosition_Unknown")
	NameAddress(0x0116C448, "un_Person_SeasonWins_Unknown")
	
	
	
	# Morale
	NameAddress(0x00486282, "uf_ChangeMorale_Unknown")
	
	NameAddress(0x00486219, "uf_ChangeDriverMoraleForTeamForTypeByAmount")
	NameAddress(0x004862C8, "uf_ChangeChiefMoraleForTeamForTypeByAmount")

	# Career Statistics
	NameAddress(0x012025FC, "un_SeasonScore_Unknown")
	NameAddress(0x012025B4, "un_CareerScore_Unknown")
	NameAddress(0x014C74A8, "un_CareerYear_Unknown")
	NameAddress(0x0120263C, "un_CareerGrandPrix_Unknown")
	NameAddress(0x004D7A0B, "un_GetCareerChampionships_Unknown")

	# Driver Orders
	NameAddress(0x008496C0, "un_DriverOrdersAcceleration")
	NameAddress(0x008496C4, "un_DriverOrdersBraking")
	NameAddress(0x008496C8, "un_DriverOrdersTopSpeed")
	NameAddress(0x008496CC, "un_DriverOrdersKerbUse")
	NameAddress(0x008496D0, "un_DriverOrdersOffRacingLine")
	NameAddress(0x008496D4, "un_DriverOrdersLineDefence")
	NameAddress(0x008496D8, "un_DriverOrdersOvertakePosition")
	NameAddress(0x008496DC, "un_DriverOrdersOvertakeBackmarkers")

	NameAddress(0x00F5E090, "un_Person_RaceSpeed_Unknown")
	NameAddress(0x00F5E094, "un_Person_RaceOvertaking_Unknown")
	NameAddress(0x00F5E098, "un_Person_RaceWetWeather_Unknown")
	NameAddress(0x00F5E09C, "un_Person_RaceConcentration_Unknown")
	NameAddress(0x00F5E0A0, "un_Person_RaceExperience_Unknown")
	NameAddress(0x00F5E0A4, "un_Person_RaceStamina_Unknown")
	NameAddress(0x00F5E0A8, "un_Person_RaceMorale_Unknown")
	NameAddress(0x00F5E0AC, "un_Person_RaceSkill_Unknown")
	
	
	# Game Environment
	NameAddress(0x01202588, "un_PlayerTeamId")
	NameAddress(0x009D5CB4, "un_GameYear")

	# File Buffer
	NameAddress(0x00849980, "un_FileBuffer_bmp_whitecar.bmp_0x2200")
	NameAddress(0x0085EED0, "un_FileBuffer_bmp_bluecar.bmp_0x2200")
	NameAddress(0x0086BC60, "un_FileBuffer_bmp_sid_dash.bmp_0x180")
	NameAddress(0x0086BF60, "un_FileBuffer_bmp_mid_dash.bmp_0x500")
	NameAddress(0x0084DDD0, "un_FileBuffer_bmp_roflag_0.bmp_0x8880")

	# Switch and Draw
	NameAddress(0x0055FED0, "uf_Switch_Team_Staff")
	NameAddress(0x00560044, "uf_Draw_Team_Staff_Drivers_Tab")
	NameAddress(0x00561314, "uf_Draw_Team_Staff_AllChiefs_Tab")
	NameAddress(0x00565007, "uf_Draw_Team_Staff_RecruitStaff_Modal")
	NameAddress(0x0058680A, "uf_Draw_Team_Rating_CareerAndRanking_Tabs")
	NameAddress(0x00541604, "uf_Draw_Team_Rating_HallOfFame_Tab")
	NameAddress(0x005D388D, "uf_Switch_Engineering_Design")
	NameAddress(0x005D633E, "uf_Draw_Engineering_Design_Summary_Tab")
	NameAddress(0x005D7F5D, "uf_Draw_Engineering_Design_NextYearsChassis_Tab")
	NameAddress(0x005D9CB8, "uf_Draw_Engineering_Design_ThisYearsChassis_Tab")
	NameAddress(0x005DBBD5, "uf_Draw_Engineering_Design_Technology_Tab")
	NameAddress(0x005DD89D, "uf_Draw_Engineering_Design_DrivingAids_Tab")
	NameAddress(0x0061C3B8, "uf_Switch_Racing_Orders")
	NameAddress(0x0061D000, "uf_Draw_Racing_Orders_TeamOrders_Tab")
	NameAddress(0x0061E8DF, "uf_Draw_Racing_Orders_DriverX_Tab")
	NameAddress(0x0061ACAB, "uf_Draw_Racing_Orders_DriverInformation_Modal")

	# Misc
	NameAddress(0x004D7CD0, "uf_GetHeadHunterCost")
	NameAddress(0x004D7CE5, "uf_GetValue10000")
	NameAddress(0x004D7CFA, "uf_GetValue5000")
	NameAddress(0x015F5200, "un_HeadquartersCapacity_Unknown")
	
	NameAddress(0x012026A0, "un_DepartmentMorale")
	NameAddress(0x012026A4, "un_DepartmentMoraleChange_Unknown")

	NameAddress(0x005B8C5D, "un_ProcessRaceResults")	
	
	# ############################ #
	# IMPORTS FROM GPWXP MIGRATION #
	# ############################ #
	NameAddress(0x004AC61A, "uf_XpSponsorOfferLogic") # GpwSponsor_SponsorOfferLogic_Unknown()
	NameAddress(0x004AD4F5, "uf_XpCalculateSponsorCash") # GpwSponsor_CalculateSponsorCashOffered(SponsorId, CashTeamSponsorFlag, SupplierDealTypeEnum)
	NameAddress(0x004B862D, "uf_XpSponsorRaceAdvantage") # GpwSponsor_RaceAdvantage()
	NameAddress(0x004B8ABE, "uf_XpUpdatePayDriverCashCommitment") # GpwStaff_UpdatePayDriverCashCommitment()
	NameAddress(0x004B8D8D, "uf_XpCalcPayDriverSalaryNextYear") # GpwStaff_CalcPayDriverSalaryNextYear()
	#TODO NameAddress(0x00, "uf_XpGetStaffTypeId") # GpwStaff_GetTypeId
	#TODO NameAddress(0x00, "uf_XpIsStaffTypeIdADriver") # GpwStaff_IsTypeIdADriver
	#TODO NameAddress(0x00, "uf_XpIsStaffTypeIdAChief") # GpwStaff_IsTypeIdAChief
	NameAddress(0x004D23F9, "uf_XpUpdateAttributesForNewSeason") # GpwStaff_UpdateAttributesForNewSeason
	NameAddress(0x004D7E80, "uf_XpCalcTotalDriverAbility") # GpwStaff_CalcTotalDriverAbility7To35
	#TODO NameAddress(0x00, "uf_XpRetireDriversForNewSeason") # GpwStaff_RetireDriversForNewSeason
	NameAddress(0x00509310, "uf_XpInitDesignStruct1") # GpwDesign_InitDesignStruct1_Unknown
	NameAddress(0x00509A0E, "uf_XpCalcDesignProductivityResults") # GpwDesign_CalcProductivityResults_Unknown
	NameAddress(0x0050B55F, "uf_XpGenerateTechnologyRatings") # GpwDesign_GenerateTechnologyRatings
	NameAddress(0x0050C09B, "uf_XpTechnologyValues") # GpwDesign_TechnologyValues_Unknown
	NameAddress(0x0050C3C4, "uf_GetChassisDesignEfficiencyRating") # GpwDesign_CalcCarDesignEfficiencyRating
	NameAddress(0x0050C449, "uf_XpCalcNextYearsHandlingPercentage") # GpwDesign_CalcNextYearsHandlingPercentage
	NameAddress(0x0050C7A1, "uf_XpCalcCarDevelopmentEfficiencyRating") # GpwDesign_CalcCarDevelopmentEfficiencyRating
	NameAddress(0x0050C826, "uf_XpCalcCarDevelopmentHandlingPercentage") # GpwDesign_CalcCarDevelopmentHandlingPercentage
	NameAddress(0x0050CA1D, "uf_XpCalcNextDevelopmentUpgrade") # GpwDesign_CalcNextDevelopmentUpgrade
	NameAddress(0x0050CEB5, "uf_XpSubmitDrivingAidForFiaApproval") # GpwDesign_SubmitDrivingAidForFiaApproval
	NameAddress(0x0050D41E, "uf_XpCalcThisYearsHandlingPercentage") # GpwDesign_CalcThisYearsHandlingPercentage
	NameAddress(0x0050D9F2, "uf_XpCalcAiChassisDevelopmentUpgrade") # GpwDesign_CalcAiChassisDevelopmentUpgrade
	NameAddress(0x004F77C3, "uf_XpSponsorshipSupportAndHospitalityAdvantage") # GpwSponsor_SponsorshipSupportAndHospitalityAdvantage
	NameAddress(0x004F8F50, "uf_XpUnknownVariableValuesFor0To100Value") # GpwUnknown_VariableValuesFor0To100Value
	#TODO NameAddress(0x00, "uf_XpTriggerYellowFlagAndMore") # GpwRace_TriggerYellowFlagAndMore_Unknown
	#TODO NameAddress(0x00, "uf_XpReturn0") # GpwMisc_Return0
	NameAddress(0x0045223B, "uf_XpChangeViewportChannel") # GpwRace_ChangeChannelInViewport(viewportId, direction)
	NameAddress(0x0045269B, "uf_XpUnknownHandleMouseCursorInRects") # GpwUi_UnknownHandlesMouseCursorInRects
	#ALREADYDONE NameAddress(ref_IsCursorWithinXYBounds) # GpwMain_IsMouseCursorWithinRect
	NameAddress(0x00455B20, "uf_XpInitRaceStruct1") # GpwRace_InitRaceStruct1_Unknown
	NameAddress(0x0045F4DE, "uf_XpSetRaceCarInformationAndOthers") # GpwRace_SetRaceCarEventInformationAndOthers
	#TODO NameAddress(0x00, "uf_XpSaveGameRaceData") # GpwFile_SaveGame_RaceData
	#TODO NameAddress(0x00, "uf_XpLoadGameRaceData") # GpwFile_LoadGame_RaceData
	#TODO NameAddress(0x00, "uf_XpCheckValueIsGreaterThan0AndLessThan200") # GpwMisc_CheckValueIsGreaterThan0AndLessThan200
	NameAddress(0x004271E4, "uf_XpDrawImagev2") # GpwGfx_DrawImage_v2
	NameAddress(0x004289DC, "uf_XpDrawImagev1") # GpwGfx_DrawImage_v1
	NameAddress(0x0042CDC9, "uf_XpDrawTextv2") # GpwGfx_DrawText_v2
	NameAddress(0x0042E495, "uf_XpDrawTextv1") # GpwGfx_DrawText_v1
	#ALREADYDONE NameAddress(ref_uf_GetTimer20Counter) # GpwMisc_Return_dword_705B8C
	NameAddress(0x0040B842, "uf_XpSetupDirectDrawSurface2") # GpwGfx_SetupDirectDrawSurface2
	NameAddress(0x0040B469, "uf_XpSetupDirectDrawSurface1") # GpwGfx_SetupDirectDrawSurface1
	NameAddress(0x0040B924, "uf_XpDetermineDirect3DDriverFromGfxDat") # GpwGfx_DetermineDirect3DDriverFromGfxDat
	#IGNORE # GpwGfx_UnknownFunction1
	#IGNORE # GpwGfx_InitDirectXStruct1
	NameAddress(0x00417B61, "uf_XpDestroyDirectXObjects") # GpwGfx_DestroyDirectXObjects
	NameAddress(0x00417DE1, "uf_XpResetDirectXObjects") # GpwGfx_ResetDirectXObjects
	NameAddress(0x00417EBB, "uf_XpCreateDirectXObjects") # GpwGfx_CreateDirectXObjects
	NameAddress(0x004181FF, "uf_XpCreateDDAndD3D") # GpwGfx_CreateDDAndD3D
	NameAddress(0x004185B3, "uf_XpCreate3DDevice") # GpwGfx_Create3DDevice
	NameAddress(0x00418627, "uf_XpCreateBuffers") # GpwGfx_CreateBuffers
	NameAddress(0x00418B14, "uf_XpCreateZBuffer") # GpwGfx_CreateZBuffer
	NameAddress(0x00418C5D, "uf_XpCreateStatic1") # GpwGfx_CreateStatic1
	NameAddress(0x00418D78, "uf_XpCreateStatic2") # GpwGfx_CreateStatic2
	NameAddress(0x00418EFD, "uf_XpCreateStatic3") # GpwGfx_CreateStatic3
	NameAddress(0x00419082, "uf_XpCreateViewport") # GpwGfx_CreateViewport
	#TODO NameAddress(0x00, "uf_XpGetBitRateOfDirectDrawSurface") # GpwGfx_GetBitRateOfDirectDrawSurface
	#TODO NameAddress(0x00, "uf_XpInitializeWindowEnvironment") # GpwMain_InitializeWindowEnvironment
	#IGNORE # GpwGfx_OutputDebugInformation1
	#IGNORE # GpwFile_IsFileExist
	#IGNORE # GpwMisc_GetRandomValue_v2
	#IGNORE # GpwFile_LoadTgaImage
	#IGNORE # GpwMain_InitializeRaceEnvironment
	#IGNORE # GpwFile_LoadFileIntoBuffer
	NameAddress(0x00412EE0, "uf_LoadImageByFileNameIntoBufferOfSize")
	#IGNORE # GpwFile_LoadImageFromImageArray
    #IGNORE # GpwFile_LoadFileFromAlternateSource
    #IGNORE # GpwFile_LoadTextIntoGlobalArrays
	NameAddress(0x0046DA6B, "uf_XpInitGameData") # GpwMain_InitGameData_Unknown
	NameAddress(0x0046E4C8, "uf_XpInitStaffStruct2") # GpwStaff_InitStaffStruct2_Unknown
	NameAddress(0x004706D7, "uf_XpInitStaffStruct1") # GpwStaff_InitStaffStruct1_Unknown
	NameAddress(0x0047BA2E, "uf_XpSaveGame") # GpwFile_SaveGame
	NameAddress(0x0047CDFB, "uf_XpLoadGame") # GpwFile_LoadGame
	#ALREADYDONE NameAddress(ref_uf_LoadDataFromFileGpwCfg) # GpwFile_ReadFromGpwConfigFile
	#SUGGESTION 47E090 - WriteGpwCfgFile
	NameAddress(0x0047F27C, "uf_XpPostSeasonFunctionUnknown") # GpwRace_PostSeasonFunction_Unknown1
	#IGNORE # GpwFile_CheckFileExists
	NameAddress(0x004806F4, "uf_XpPostRaceFunction2") # GpwRace_PostRaceFunction_Unknown2
	NameAddress(0x00480D87, "uf_XpPostRaceFunction1") # GpwRace_PostRaceFunction_Unknown
	NameAddress(0x00484BA2, "uf_XpMoraleManagementUnknown") # GpwStaff_MoraleManagement_Unknown
	#TODO NameAddress(0x00, "uf_XpChangeMoraleForAllDrivers") # GpwStaff_ChangeMoraleForAllDrivers
	#TODO NameAddress(0x00, "uf_XpAddValueToAttributeUnknown") # GpwStaff_AddValueToAttribute_Unknown
	#TODO NameAddress(0x00, "uf_XpChangeMoraleForOneOrAllDepartments") # GpwStaff_ChangeMoraleForOneOrAllDepartments (if equal to 6, change all departments)
	#TODO NameAddress(0x00, "uf_XpGetAttributeSkill") # GpwStaff_GetAttribute_Skill
	#ALREADYDONE NameAddress(ref_uf_SetLanguage) # GpwText_SetLanguage
	#ALREADYDONE NameAddress(ref_uf_LoadResourceStrings) # GpwText_LoadTextResource
	NameAddress(0x0051371B, "uf_XpLoadResourceString3") # GpwText_GetTextFromLanguageFile3
	NameAddress(0x00513776, "uf_XpLoadResourceString2") # GpwText_GetTextFromLanguageFile2
	NameAddress(0x005137D1, "uf_XpLoadResourceString1") # GpwText_GetTextFromLanguageFile1
	#ALREADYDONE NameAddress(ref_uf_LoadResourceStringValueIntoDataBuffer1) # GpwText_GetTextFromLanguageFile4
	#ALREADYDONE NameAddress(ref_uf_LoadResourceStringValueIntoDataBuffer2) # GpwText_GetTextFromLanguageFile5
	#ALREADYDONE NameAddress(ref_uf_LoadResourceStringValueIntoDataBuffer3) # GpwText_GetTextFromLanguageFile6
	NameAddress(0x005139F3, "uf_XpIsStringIdValid") # GpwText_IsStringIdValid
	NameAddress(0x004FF4A0, "uf_XpPostRaceManagement") # GpwStaff_PostRaceManagement
	NameAddress(0x0050042D, "uf_XpStarWorkersToNormal") # GpwMail_StarWorkersReturningToNormal
	NameAddress(0x00501323, "uf_XpFinancialYearProfitLoss") # GpwMail_FinancialYearProfitLoss
	NameAddress(0x00501D2E, "uf_XpStaffLabourShortage") # GpwMail_StaffLabourShortage
	#TODO NameAddress(0x00, "uf_XpChangeReduceMorale") # GpwStaff_ChangeMorale_ReduceMorale
	NameAddress(0x004FA8B0, "uf_XpManagerPerformanceAlerts1") # GpwMail_ManagerPerformanceNotifications_InclNewsItems_v1
	NameAddress(0x004FB35B, "uf_XpManagerPerformanceAlerts2") # GpwMail_ManagerPerformanceNotifications_InclNewsItems_v2
	NameAddress(0x004FBA1B, "uf_XpCreateNewsItem") # GpwNews_CreateItem



	NameAddress(0x004FE13F, "uf_XpCreateNewsImageTeamLogo") # GpwNews_CreateImage_TeamLogo
	NameAddress(0x004FE18E, "uf_XpCreateNewsImageDriverHead") # GpwNews_CreateImage_DriverHead
	NameAddress(0x004FE238, "uf_XpCreateNewsImageFiaLogo") # GpwNews_CreateImage_FiaLogo
	#ALREADYDONE NameAddress(ref_uf_SetPowerVr2AppHint) # GpwGfx_SetAppHintEnableVPFix1
	NameAddress(0x005210D1, "uf_XpPlaySounds") # GpwRace_PlaySounds
	#IGNORE # GpwText_SetPathToRegistryKey
	#IGNORE # GpwText_GetValueFromRegistryKeyInstall2
	#IGNORE # GpwText_GetValueFromRegistryKeyInstall1
	NameAddress(0x0051A3D6, "uf_XpDrawRaceCarEventInformation") # GpwRace_DrawRaceCarEventInformation
	NameAddress(0x004E70A0, "uf_XpInitSponsorStruct2") # GpwSponsors_InitSponsorStruct2
	NameAddress(0x004E7A25, "uf_XpInitSponsorStruct1") # GpwSponsors_InitSponsorStruct1
	NameAddress(0x004EEC35, "uf_XpChangeCashAndRndCommitmentUnknown") # GpwSponsor_IncreaseDecreaseCashAndRndCommitment_Unknown
	NameAddress(0x00502980, "uf_XpInitTrackStruct1Unknown") # GpwTrack_InitTrackStruct1_Unknown
	#IGNORE # GpwMisc_GetRandomValue
	NameAddress(0x00499183, "uf_XpStringFormatIntToCurrency") # GpwMisc_StringFormatIntToCurrency
	#IGNORE # GpwMain_WndProc
	#IGNORE # GpwMain_CreateGameWindow
	NameAddress(0x004396CC, "uf_XpGameLoop") # GpwMain_GameLoop
	NameAddress(0x00439DEA, "uf_XpInitialize3DEnvironment") # GpwMain_Initialize3DEnvironment
	NameAddress(0x0043AB84, "uf_XpIsGameCdInserted") # GpwMain_IsGameCdInserted
	#ALREADYDONE NameAddress(ref_uf_CreateFont) # GpwMain_CreateFontArial
	NameAddress(0x0062E5AE, "uf_XpHugeSponsorDrawingMethodUnknown") # GpwSponsor_HUGE_SetupAndDrawingMethod_Unknown
	NameAddress(0x00601293, "uf_XpCarDesignMouseEvents2") # GpwDesign_CarDesignMouseEvents_Unknown_v2
	#TODO NameAddress(0x00, "uf_XpInitSupplierStruct1") # GpwSupplier_InitSupplierStruct1_Unknown
	NameAddress(0x005D9435, "uf_XpCarDesignMouseEvents1") # GpwDesign_CarDesignMouseEvents_Unknown
	NameAddress(0x005DD3FA, "uf_XpInternalTechnologyConstructionUnknown") # GpwDesign_InternalTechnologyConstruction_Unknown
	NameAddress(0x005DEB2F, "uf_XpDriverAidConstructionUnknown") # GpwDesign_DriverAidConstruction_Unknown
	NameAddress(0x005AD880, "uf_XpFiaRankingChanges") # GpwFia_FiaRankingChanges
	#ALREADYDONE NameAddress(ref_uf_LoadDataFromFileLanguageTxt) # GpwText_DetermineLanguageFromLanguageTxt
	#TODO NameAddress(0x00, "uf_XpLicensingUnknown") # GpwLicensing_Unknown1

	NameAddress(0x005AB08B, "uf_XpCreateMailItem") # GpwMail_CreateItem
	NameAddress(0x009C81E8, "un_MailRoundIndexUnknown")
	
	
	NameAddress(0x00556923, "uf_XpDrawSectionTeamProfile") # GpwGfx_DrawSection_TeamProfile
	#TODO NameAddress(0x00, "uf_Xp") # GpwStaff_GetUnadjustedTotalStaffTimeUnits
	#TODO NameAddress(0x00, "uf_Xp") # GpwStaff_GetAdjustedTotalStaffTimeUnits
	#TODO NameAddress(0x00, "uf_Xp") # GpwMisc_Convert_0to100_To_1to5_v1
	#TODO NameAddress(0x00, "uf_Xp") # GpwMisc_Convert_0to100_To_1to5_v2
	NameAddress(0x00564393, "uf_XpConvert1to5To20to100") # GpwMisc_Convert_1to5_To_20to100
	#IGNORE # GpwLicensing_Unknown2
	#TODO NameAddress(0x00, "uf_Xp") # GpwStaff_IsDriverSignedForNextYear
	#TODO NameAddress(0x00, "uf_Xp") # GpwStaff_IsChiefSignedForNextYear
	#TODO NameAddress(0x00, "uf_Xp") # GpwGfx_DrawConfirmationMessageBox
	#TODO NameAddress(0x00, "uf_Xp") # GpwRace_CalcPostRacePoints
	#TODO NameAddress(0x00, "uf_Xp") # GpwManager_CalcHallOfFamePointsForEndOfYear
	NameAddress(0x00620788, "uf_Update_TeamOrdersMorale_Unknown")
	#ALREADYDONE NameAddress(ref_uf_IsPrimaryDisplayPowerVr2) # GpwGfx_IsPrimaryDisplayPowerVR2
	# ###################### #
	# END OF GPWXP MIGRATION #
	# ###################### #
	
	# Variables - GpwDesign
	NameAddress(0x008CF4A0, "un_ChassisDesignEfficiencyRating_Unknown") # GpwDesign_CarDesignEfficiencyRating
	NameAddress(0x008CF4E8, "un_ChassisDesignStage1Progress") # GpwDesign_CarDesignStage1Progress
	NameAddress(0x008CF4EC, "un_ChassisDesignStage2Progress") # GpwDesign_CarDesignStage2Progress
	NameAddress(0x008CF4F0, "un_ChassisDesignStage3Progress") # GpwDesign_CarDesignStage3Progress
	NameAddress(0x008CF4F4, "un_ChassisDesignStage4Progress") # GpwDesign_CarDesignStage4Progress
	NameAddress(0x008CF584, "un_XpCarDevelopmentStage1Progress") # GpwDesign_CarDevelopmentStage1Progress
	NameAddress(0x008CF588, "un_XpCarDevelopmentStage2Progress") # GpwDesign_CarDevelopmentStage2Progress
	NameAddress(0x008CF58C, "un_XpCarDevelopmentStage3Progress") # GpwDesign_CarDevelopmentStage3Progress
	NameAddress(0x008CF590, "un_XpCarDevelopmentStage4Progress") # GpwDesign_CarDevelopmentStage4Progress
	NameAddress(0x008CF5CC, "un_XpCarDevelopmentUpgradeId") # GpwDesign_DevelopmentUpgradeId
	NameAddress(0x008CF508, "un_XpCarHandlingPercentageNextYearsUnknown") # GpwDesign_NextYearsHandlingPercentage_Unknown
	NameAddress(0x008CF528, "un_ChassisHandlingThisYearsCurrent") # GpwDesign_ThisYearsHandlingPercentage_Current
	NameAddress(0x008CF52C, "un_ChassisHandlingThisYearsPending") # GpwDesign_ThisYearsHandlingPercentage_Development
	
	NameAddress(0x008CF530, "un_XpCarHandlingPercentageThisYearsUnknown") # GpwDesign_ThisYearsHandlingPercentage_Unknown

	# Technology
	NameAddress(0x008CF668, "un_TechnologyBrakesEffortPercentage_Unknown")
	NameAddress(0x008CF5F8, "un_TechnologyBrakesPerformanceRatingCurrent")
	NameAddress(0x008CF614, "un_TechnologyBrakesReliabilityRatingCurrent")
	NameAddress(0x008CF630, "un_TechnologyBrakesPerformanceRatingPending")
	NameAddress(0x008CF64C, "un_TechnologyBrakesReliabilityRatingPending")
	NameAddress(0x008CF6A0, "un_TechnologyBrakesProgress_Unknown")
	NameAddress(0x008CF5FC, "un_TechnologyClutchPerformanceRatingCurrent")
	NameAddress(0x008CF618, "un_TechnologyClutchReliabilityRatingCurrent")
	NameAddress(0x008CF634, "un_TechnologyClutchPerformanceRatingPending")
	NameAddress(0x008CF650, "un_TechnologyClutchReliabilityRatingPending")
	NameAddress(0x008CF600, "un_TechnologyElectronicsPerformanceRatingCurrent")
	NameAddress(0x008CF61C, "un_TechnologyElectronicsReliabilityRatingCurrent")
	NameAddress(0x008CF638, "un_TechnologyElectronicsPerformanceRatingPending")
	NameAddress(0x008CF654, "un_TechnologyElectronicsReliabilityRatingPending")
	NameAddress(0x008CF604, "un_TechnologyGearboxPerformanceRatingCurrent")
	NameAddress(0x008CF620, "un_TechnologyGearboxReliabilityRatingCurrent")
	NameAddress(0x008CF63C, "un_TechnologyGearboxPerformanceRatingPending")
	NameAddress(0x008CF658, "un_TechnologyGearboxReliabilityRatingPending")
	NameAddress(0x008CF608, "un_TechnologyHydraulicsPerformanceRatingCurrent")
	NameAddress(0x008CF624, "un_TechnologyHydraulicsReliabilityRatingCurrent")
	NameAddress(0x008CF640, "un_TechnologyHydraulicsPerformanceRatingPending")
	NameAddress(0x008CF65C, "un_TechnologyHydraulicsReliabilityRatingPending")
	NameAddress(0x008CF60C, "un_TechnologySuspensionPerformanceRatingCurrent")
	NameAddress(0x008CF628, "un_TechnologySuspensionReliabilityRatingCurrent")
	NameAddress(0x008CF644, "un_TechnologySuspensionPerformanceRatingPending")
	NameAddress(0x008CF660, "un_TechnologySuspensionReliabilityRatingPending")
	NameAddress(0x008CF610, "un_TechnologyThrottlePerformanceRatingCurrent")
	NameAddress(0x008CF62C, "un_TechnologyThrottleReliabilityRatingCurrent")
	NameAddress(0x008CF648, "un_TechnologyThrottlePerformanceRatingPending")
	NameAddress(0x008CF664, "un_TechnologyThrottleReliabilityRatingPending")

	# Driving Aids
	NameAddress(0x008CF734, "un_DrivingAidActiveSuspensionEffortPercentage_Unknown")
	NameAddress(0x008CF6D0, "un_DrivingAidActiveSuspensionLevelCurrent")
	NameAddress(0x008CF6E0, "un_DrivingAidActiveSuspensionLevelPending")
	NameAddress(0x008CF6F0, "un_DrivingAidActiveSuspensionLevelApproved")
	NameAddress(0x008CF710, "un_DrivingAidActiveSuspensionProgress_Unknown")
	NameAddress(0x008CF738, "un_DrivingAidAutomaticGearsEffortPercentage_Unknown")
	NameAddress(0x008CF6D4, "un_DrivingAidAutomaticGearsLevelCurrent")
	NameAddress(0x008CF6E4, "un_DrivingAidAutomaticGearsLevelPending")
	NameAddress(0x008CF6F4, "un_DrivingAidAutomaticGearsLevelApproved")
	NameAddress(0x008CF714, "un_DrivingAidAutomaticGearsProgress_Unknown")
	NameAddress(0x008CF73C, "un_DrivingAidPowerBrakesEffortPercentage_Unknown")
	NameAddress(0x008CF6D8, "un_DrivingAidPowerBrakesLevelCurrent")
	NameAddress(0x008CF6E8, "un_DrivingAidPowerBrakesLevelPending")
	NameAddress(0x008CF6F8, "un_DrivingAidPowerBrakesLevelApproved")
	NameAddress(0x008CF718, "un_DrivingAidPowerBrakesProgress_Unknown")
	NameAddress(0x008CF740, "un_DrivingAidTractionControlEffortPercentage_Unknown")
	NameAddress(0x008CF6DC, "un_DrivingAidTractionControlLevelCurrent")
	NameAddress(0x008CF6EC, "un_DrivingAidTractionControlLevelPending")
	NameAddress(0x008CF6FC, "un_DrivingAidTractionControlLevelApproved")
	NameAddress(0x008CF71C, "un_DrivingAidTractionControlProgress_Unknown")

	NameAddress(0x0086C9C0, "un_DrivingAidActiveSuspensionLevel_Unknown1")
	NameAddress(0x0086CA64, "un_DrivingAidActiveSuspensionLevel_Unknown2")
	NameAddress(0x0086C9C4, "un_DrivingAidAutomaticGearsLevel_Unknown1")
	NameAddress(0x0086CA68, "un_DrivingAidAutomaticGearsLevel_Unknown2")
	NameAddress(0x0086C9C8, "un_DrivingAidPowerBrakesLevel_Unknown1")
	NameAddress(0x0086CA6C, "un_DrivingAidPowerBrakesLevel_Unknown2")
	NameAddress(0x0086C9CC, "un_DrivingAidTractionControlLevel_Unknown1")
	NameAddress(0x0086CA70, "un_DrivingAidTractionControlLevel_Unknown2")
	
	
	NameAddress(0x0116C080, "un_HallOfFameName")
	NameAddress(0x0116C0C4, "un_HallOfFameYears")
	NameAddress(0x0116C0C8, "un_HallOfFameGrandPrix")
	NameAddress(0x0116C0CC, "un_HallOfFameConstructorsChampionships")
	NameAddress(0x0116C0D0, "un_HallOfFamePoints")


	NameAddress(0x00542429, "uf_DrawSaveGameTab_Unknown")
	NameAddress(0x00499499, "uf_FormatNumberToString_Unknown")
	
	
	NameAddress(0x01202594, "un_XpLastYearsChampionshipPositionUnknown") # GpwDesign_LastYearsChampionshipPosition_Unknown
	# TODO move onto GpwFile names now that GpwDesign names are done
	
	# Variables - GpwFile
	#ALREADYDONE NameAddress(ref_un_IsFileBoxonDatExist) # GpwFile_BoxonDatFlag
	#ALREADYDONE NameAddress(ref_un_DataBuffer) # GpwFile_Buffer
	#ALREADYDONE NameAddress(ref_un_DataBufferByteCount) # GpwFile_BufferSize
	#ALREADYDONE NameAddress(ref_un_IsFileCoordsDatExist) # GpwFile_CoordsDatFlagDatFlag
	#ALREADYDONE NameAddress(ref_un_IsFileFrameDatExist) # GpwFile_FrameDatFlagDatFlag
	#ALREADYDONE NameAddress(ref_un_IsFileLowresDatExist) # GpwFile_LowresDatFlag
	#ALREADYDONE NameAddress(ref_un_IsFileStartDatExist) # GpwFile_StartDatFlag
	#ALREADYDONE NameAddress(ref_un_IsFileUnlimitDatExist) # GpwFile_UnlimitDatFlag

	# Variables - GpwGfx
	NameAddress(0x015F2C58, "un_XpDirectXStruct1Object") # GpwGfx_DirectXStruct1_Object
	NameAddress(0x015F0FE0, "un_XpGfxObjectUnknown1") # GpwGfx_UnknownValue1
	NameAddress(0x015F0FF0, "un_XpGfxObjectUnknown2") # GpwGfx_UnknownValue2
	NameAddress(0x015F0FDC, "un_XpGfxObjectUnknown3") # GpwGfx_UnknownValue3

	# Variables - GpwMain
	#IGNORE # GpwMain_GameInstanceHandle
	#IGNORE # GpwMain_GameWindowHandle
	
	# Variables - GpwMisc

	NameAddress(0x015F60A0, "un_PersonType01_TeamPrincipal")
	NameAddress(0x015F60A4, "un_PersonType02_ChiefCommerce")
	NameAddress(0x015F60A8, "un_PersonType03_ChiefDesigner")
	NameAddress(0x015F60AC, "un_PersonType04_ChiefEngineer")
	NameAddress(0x015F60B0, "un_PersonType05_ChiefMechanic")
	NameAddress(0x015F60B4, "un_PersonType06_DriverOne")
	NameAddress(0x015F60B8, "un_PersonType07_DriverTwo")
	NameAddress(0x015F60BC, "un_PersonType08_DriverTest")
	NameAddress(0x015F60C0, "un_PersonType09_DriverUnknown")
	NameAddress(0x015F60C4, "un_PersonType10_DriverNonF1")

	NameAddress(0x014C74AC, "un_XpCurrentRoundId") # GpwMisc_CurrentRoundId
	NameAddress(0x015F5148, "un_XpValueA_1") # GpwMisc_Value1_1
	NameAddress(0x015F514C, "un_XpValueA_2") # GpwMisc_Value1_2
	NameAddress(0x015F5150, "un_XpValueA_3") # GpwMisc_Value1_3
	NameAddress(0x015F5154, "un_XpValueA_4") # GpwMisc_Value1_4
	NameAddress(0x015F5158, "un_XpValueA_5") # GpwMisc_Value1_5
	NameAddress(0x015F515C, "un_XpValueB_0") # GpwMisc_Value2_0
	NameAddress(0x015F5160, "un_XpValueB_1") # GpwMisc_Value2_1
	NameAddress(0x015F5164, "un_XpValueB_2") # GpwMisc_Value2_2
	NameAddress(0x015F5168, "un_XpValueB_3") # GpwMisc_Value2_3
	NameAddress(0x015F516C, "un_XpValueB_4") # GpwMisc_Value2_4
	NameAddress(0x015F5170, "un_XpValueC_0") # GpwMisc_Value3_0
	NameAddress(0x015F5174, "un_XpValueC_1") # GpwMisc_Value3_1
	NameAddress(0x015F5178, "un_XpValueC_2") # GpwMisc_Value3_2
	NameAddress(0x015F517C, "un_XpValueC_3") # GpwMisc_Value3_3
	NameAddress(0x015F5180, "un_XpValueC_4") # GpwMisc_Value3_4
	NameAddress(0x015F5184, "un_XpValueC_5") # GpwMisc_Value3_5
	NameAddress(0x015F5188, "un_XpValueD_0") # GpwMisc_Value4_0
	NameAddress(0x015F518C, "un_XpValueD_1") # GpwMisc_Value4_1
	NameAddress(0x015F5190, "un_XpValueD_2") # GpwMisc_Value4_2
	NameAddress(0x015F5194, "un_XpValueD_3") # GpwMisc_Value4_3
	NameAddress(0x015F5198, "un_XpValueD_4") # GpwMisc_Value4_4
	NameAddress(0x015F519C, "un_XpValueD_5") # GpwMisc_Value4_5
	NameAddress(0x015F51A0, "un_XpValueE_0") # GpwMisc_Value5_0
	NameAddress(0x015F51A4, "un_XpValueE_1") # GpwMisc_Value5_1
	NameAddress(0x015F51A8, "un_XpValueE_2") # GpwMisc_Value5_2
	NameAddress(0x015F51AC, "un_XpValueE_3") # GpwMisc_Value5_3
	NameAddress(0x015F51B0, "un_XpValueE_4") # GpwMisc_Value5_4
	NameAddress(0x015F51B4, "un_XpValueF_0") # GpwMisc_Value6_0
	NameAddress(0x015F51B8, "un_XpValueF_1") # GpwMisc_Value6_1
	NameAddress(0x015F51BC, "un_XpValueF_2") # GpwMisc_Value6_2
	NameAddress(0x015F51C0, "un_XpValueF_3") # GpwMisc_Value6_3
	NameAddress(0x015F51C4, "un_XpValueG_0") # GpwMisc_Value7_0
	NameAddress(0x015F51C8, "un_XpValueG_1") # GpwMisc_Value7_1
	NameAddress(0x015F51CC, "un_XpValueG_2") # GpwMisc_Value7_2
	NameAddress(0x015F51D0, "un_XpValueG_3") # GpwMisc_Value7_3
	NameAddress(0x015F51D4, "un_XpValueG_4") # GpwMisc_Value7_4
	NameAddress(0x015F51D8, "un_XpValueG_5") # GpwMisc_Value7_5
	NameAddress(0x015FFA10, "un_XpValueH_0") # Manual migration
	NameAddress(0x015FFA14, "un_XpValueH_1") # Manual migration
	NameAddress(0x015FFA18, "un_XpValueH_2") # Manual migration
	NameAddress(0x015FFA1C, "un_XpValueH_3") # Manual migration
	NameAddress(0x015FFA20, "un_XpValueH_4") # Manual migration
	NameAddress(0x015FFA24, "un_XpValueH_5") # Manual migration
	NameAddress(0x015FFA28, "un_XpValueH_6") # Manual migration
	#ALREADYDONE NameAddress(ref_un_WM_LBUTTONDOWN_WPARAM) # GpwMisc_WM_LBUTTONDOWN_WPARAM
	#ALREADYDONE NameAddress(ref_un_WM_LBUTTONDOWN_LPARAM_X) # GpwMisc_WM_LBUTTONDOWN_X
	#ALREADYDONE NameAddress(ref_un_WM_LBUTTONDOWN_LPARAM_Y) # GpwMisc_WM_LBUTTONDOWN_Y

	# Variables - GpwPlayer
	NameAddress(0x012039D8, "un_XpPlayerSelectedTeamFlag") # GpwPlayer_SelectedTeamFlag

	# Variables - GpwRace
	NameAddress(0x00726F28, "un_XpRaceChannelIdUnknown") # GpwRace_ChannelId
	NameAddress(0x015F321C, "un_XpRaceDatFileTrackId") # GpwRace_DatFileTrackId
	NameAddress(0x007061A0, "un_XpRaceCarEventInformation") # GpwRace_RaceCarEventInformation
	NameAddress(0x015F2F44, "un_XpRaceActiveViewportId") # GpwRace_ViewportId

	# Variables - GpwSfx
	NameAddress(0x007314FC, "un_XpDirectSoundBuffer") # GpwSfx_DirectSoundBuffer
	NameAddress(0x0072F200, "un_XpDirectSoundDevice") # GpwSfx_DirectSoundDevice
	NameAddress(0x0072F208, "un_XpDsBufferDesc") # GpwSfx_DsBufferDesc
	NameAddress(0x0072F20C, "un_XpDsBufferDesc_dwFlags") # GpwSfx_DsBufferDesc_dwFlags

	# Variables - GpwSponsor
	NameAddress(0x007E5CB2, "un_XpTeamSuccessRatingOrSponsorTypeUnknown") # GpwSponsor_TeamSuccessRatingOrSponsorType_Unknown


	
	NameAddress(0x015FFB30, "un_XpEffortChiefTimeUnits") # GpwStaff_ChiefTimeUnits
	NameAddress(0x015FFB18, "un_XpEffortStaffTimeUnits") # GpwStaff_StaffTimeUnits	

	# Variables - GpwText
	#ALREADYDONE NameAddress(ref_un_IsLanguageEnglish) # GpwText_IsLanguageEnglish
	#ALREADYDONE NameAddress(ref_un_IsLanguageFrench) # GpwText_IsLanguageFrench
	#ALREADYDONE NameAddress(ref_un_IsLanguageGerman) # GpwText_IsLanguageGerman
	NameAddress(0x00731E38, "un_XpPathToRegistryKey") # GpwText_PathToRegistryKey

	NameAddress(0x00535B90, "uf_RaceEngineUnknown")
	

# Add comments
#def apply_comments():
	# MakeComm https://www.hex-rays.com/products/ida/support/idadoc/204.shtml 

################################################################################

print(scriptTitle)
print("Script commencing...")
#apply_make_functions()
#apply_make_codes()
apply_names()
#apply_comments()

print("Applied {0} names to addresses.".format(len(appliedNameAddress)))
print("Script complete!")
print("")
