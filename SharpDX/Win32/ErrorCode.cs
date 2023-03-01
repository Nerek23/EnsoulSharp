using System;

namespace SharpDX.Win32
{
	// Token: 0x02000060 RID: 96
	public enum ErrorCode
	{
		// Token: 0x04000109 RID: 265
		Success,
		// Token: 0x0400010A RID: 266
		InvalidFunction,
		// Token: 0x0400010B RID: 267
		FileNotFound,
		// Token: 0x0400010C RID: 268
		PathNotFound,
		// Token: 0x0400010D RID: 269
		TooManyOpenFiles,
		// Token: 0x0400010E RID: 270
		AccessDenied,
		// Token: 0x0400010F RID: 271
		InvalidHandle,
		// Token: 0x04000110 RID: 272
		ArenaTrashed,
		// Token: 0x04000111 RID: 273
		NotEnoughMemory,
		// Token: 0x04000112 RID: 274
		InvalidBlock,
		// Token: 0x04000113 RID: 275
		BadEnvironment,
		// Token: 0x04000114 RID: 276
		BadFormat,
		// Token: 0x04000115 RID: 277
		InvalidAccess,
		// Token: 0x04000116 RID: 278
		InvalidData,
		// Token: 0x04000117 RID: 279
		Outofmemory,
		// Token: 0x04000118 RID: 280
		InvalidDrive,
		// Token: 0x04000119 RID: 281
		CurrentDirectory,
		// Token: 0x0400011A RID: 282
		NotSameDevice,
		// Token: 0x0400011B RID: 283
		NoMoreFiles,
		// Token: 0x0400011C RID: 284
		WriteProtect,
		// Token: 0x0400011D RID: 285
		BadUnit,
		// Token: 0x0400011E RID: 286
		NotReady,
		// Token: 0x0400011F RID: 287
		BadCommand,
		// Token: 0x04000120 RID: 288
		Crc,
		// Token: 0x04000121 RID: 289
		BadLength,
		// Token: 0x04000122 RID: 290
		Seek,
		// Token: 0x04000123 RID: 291
		NotDosDisk,
		// Token: 0x04000124 RID: 292
		SectorNotFound,
		// Token: 0x04000125 RID: 293
		OutOfPaper,
		// Token: 0x04000126 RID: 294
		WriteFault,
		// Token: 0x04000127 RID: 295
		ReadFault,
		// Token: 0x04000128 RID: 296
		GenFailure,
		// Token: 0x04000129 RID: 297
		SharingViolation,
		// Token: 0x0400012A RID: 298
		LockViolation,
		// Token: 0x0400012B RID: 299
		WrongDisk,
		// Token: 0x0400012C RID: 300
		SharingBufferExceeded = 36,
		// Token: 0x0400012D RID: 301
		HandleEof = 38,
		// Token: 0x0400012E RID: 302
		HandleDiskFull,
		// Token: 0x0400012F RID: 303
		NotSupported = 50,
		// Token: 0x04000130 RID: 304
		RemNotList,
		// Token: 0x04000131 RID: 305
		DupName,
		// Token: 0x04000132 RID: 306
		BadNetpath,
		// Token: 0x04000133 RID: 307
		NetworkBusy,
		// Token: 0x04000134 RID: 308
		DevNotExist,
		// Token: 0x04000135 RID: 309
		TooManyCmds,
		// Token: 0x04000136 RID: 310
		AdapHdwErr,
		// Token: 0x04000137 RID: 311
		BadNetResp,
		// Token: 0x04000138 RID: 312
		UnexpNetErr,
		// Token: 0x04000139 RID: 313
		BadRemAdap,
		// Token: 0x0400013A RID: 314
		PrintqFull,
		// Token: 0x0400013B RID: 315
		NoSpoolSpace,
		// Token: 0x0400013C RID: 316
		PrintCancelled,
		// Token: 0x0400013D RID: 317
		NetnameDeleted,
		// Token: 0x0400013E RID: 318
		NetworkAccessDenied,
		// Token: 0x0400013F RID: 319
		BadDevType,
		// Token: 0x04000140 RID: 320
		BadNetName,
		// Token: 0x04000141 RID: 321
		TooManyNames,
		// Token: 0x04000142 RID: 322
		TooManySess,
		// Token: 0x04000143 RID: 323
		SharingPaused,
		// Token: 0x04000144 RID: 324
		ReqNotAccep,
		// Token: 0x04000145 RID: 325
		RedirPaused,
		// Token: 0x04000146 RID: 326
		FileExists = 80,
		// Token: 0x04000147 RID: 327
		CannotMake = 82,
		// Token: 0x04000148 RID: 328
		FailI24,
		// Token: 0x04000149 RID: 329
		OutOfStructures,
		// Token: 0x0400014A RID: 330
		AlreadyAssigned,
		// Token: 0x0400014B RID: 331
		InvalidPassword,
		// Token: 0x0400014C RID: 332
		InvalidParameter,
		// Token: 0x0400014D RID: 333
		NetWriteFault,
		// Token: 0x0400014E RID: 334
		NoProcSlots,
		// Token: 0x0400014F RID: 335
		TooManySemaphores = 100,
		// Token: 0x04000150 RID: 336
		ExclSemAlreadyOwned,
		// Token: 0x04000151 RID: 337
		SemIsSet,
		// Token: 0x04000152 RID: 338
		TooManySemRequests,
		// Token: 0x04000153 RID: 339
		InvalidAtInterruptTime,
		// Token: 0x04000154 RID: 340
		SemOwnerDied,
		// Token: 0x04000155 RID: 341
		SemUserLimit,
		// Token: 0x04000156 RID: 342
		DiskChange,
		// Token: 0x04000157 RID: 343
		DriveLocked,
		// Token: 0x04000158 RID: 344
		BrokenPipe,
		// Token: 0x04000159 RID: 345
		OpenFailed,
		// Token: 0x0400015A RID: 346
		BufferOverflow,
		// Token: 0x0400015B RID: 347
		DiskFull,
		// Token: 0x0400015C RID: 348
		NoMoreSearchHandles,
		// Token: 0x0400015D RID: 349
		InvalidTargetHandle,
		// Token: 0x0400015E RID: 350
		InvalidCategory = 117,
		// Token: 0x0400015F RID: 351
		InvalidVerifySwitch,
		// Token: 0x04000160 RID: 352
		BadDriverLevel,
		// Token: 0x04000161 RID: 353
		CallNotImplemented,
		// Token: 0x04000162 RID: 354
		SemTimeout,
		// Token: 0x04000163 RID: 355
		InsufficientBuffer,
		// Token: 0x04000164 RID: 356
		InvalidName,
		// Token: 0x04000165 RID: 357
		InvalidLevel,
		// Token: 0x04000166 RID: 358
		NoVolumeLabel,
		// Token: 0x04000167 RID: 359
		ModNotFound,
		// Token: 0x04000168 RID: 360
		ProcNotFound,
		// Token: 0x04000169 RID: 361
		WaitNoChildren,
		// Token: 0x0400016A RID: 362
		ChildNotComplete,
		// Token: 0x0400016B RID: 363
		DirectAccessHandle,
		// Token: 0x0400016C RID: 364
		NegativeSeek,
		// Token: 0x0400016D RID: 365
		SeekOnDevice,
		// Token: 0x0400016E RID: 366
		IsJoinTarget,
		// Token: 0x0400016F RID: 367
		IsJoined,
		// Token: 0x04000170 RID: 368
		IsSubsted,
		// Token: 0x04000171 RID: 369
		NotJoined,
		// Token: 0x04000172 RID: 370
		NotSubsted,
		// Token: 0x04000173 RID: 371
		JoinToJoin,
		// Token: 0x04000174 RID: 372
		SubstToSubst,
		// Token: 0x04000175 RID: 373
		JoinToSubst,
		// Token: 0x04000176 RID: 374
		SubstToJoin,
		// Token: 0x04000177 RID: 375
		BusyDrive,
		// Token: 0x04000178 RID: 376
		SameDrive,
		// Token: 0x04000179 RID: 377
		DirNotRoot,
		// Token: 0x0400017A RID: 378
		DirNotEmpty,
		// Token: 0x0400017B RID: 379
		IsSubstPath,
		// Token: 0x0400017C RID: 380
		IsJoinPath,
		// Token: 0x0400017D RID: 381
		PathBusy,
		// Token: 0x0400017E RID: 382
		IsSubstTarget,
		// Token: 0x0400017F RID: 383
		SystemTrace,
		// Token: 0x04000180 RID: 384
		InvalidEventCount,
		// Token: 0x04000181 RID: 385
		TooManyMuxwaiters,
		// Token: 0x04000182 RID: 386
		InvalidListFormat,
		// Token: 0x04000183 RID: 387
		LabelTooLong,
		// Token: 0x04000184 RID: 388
		TooManyTcbs,
		// Token: 0x04000185 RID: 389
		SignalRefused,
		// Token: 0x04000186 RID: 390
		Discarded,
		// Token: 0x04000187 RID: 391
		NotLocked,
		// Token: 0x04000188 RID: 392
		BadThreadidAddr,
		// Token: 0x04000189 RID: 393
		BadArguments,
		// Token: 0x0400018A RID: 394
		BadPathname,
		// Token: 0x0400018B RID: 395
		SignalPending,
		// Token: 0x0400018C RID: 396
		MaxThrdsReached = 164,
		// Token: 0x0400018D RID: 397
		LockFailed = 167,
		// Token: 0x0400018E RID: 398
		Busy = 170,
		// Token: 0x0400018F RID: 399
		DeviceSupportInProgress,
		// Token: 0x04000190 RID: 400
		CancelViolation = 173,
		// Token: 0x04000191 RID: 401
		AtomicLocksNotSupported,
		// Token: 0x04000192 RID: 402
		InvalidSegmentNumber = 180,
		// Token: 0x04000193 RID: 403
		InvalidOrdinal = 182,
		// Token: 0x04000194 RID: 404
		AlreadyExists,
		// Token: 0x04000195 RID: 405
		InvalidFlagNumber = 186,
		// Token: 0x04000196 RID: 406
		SemNotFound,
		// Token: 0x04000197 RID: 407
		InvalidStartingCodeseg,
		// Token: 0x04000198 RID: 408
		InvalidStackseg,
		// Token: 0x04000199 RID: 409
		InvalidModuletype,
		// Token: 0x0400019A RID: 410
		InvalidExeSignature,
		// Token: 0x0400019B RID: 411
		ExeMarkedInvalid,
		// Token: 0x0400019C RID: 412
		BadExeFormat,
		// Token: 0x0400019D RID: 413
		IteratedDataExceeds64k,
		// Token: 0x0400019E RID: 414
		InvalidMinallocsize,
		// Token: 0x0400019F RID: 415
		DynlinkFromInvalidRing,
		// Token: 0x040001A0 RID: 416
		IoplNotEnabled,
		// Token: 0x040001A1 RID: 417
		InvalidSegdpl,
		// Token: 0x040001A2 RID: 418
		AutodatasegExceeds64k,
		// Token: 0x040001A3 RID: 419
		Ring2segMustBeMovable,
		// Token: 0x040001A4 RID: 420
		RelocChainXeedsSeglim,
		// Token: 0x040001A5 RID: 421
		InfloopInRelocChain,
		// Token: 0x040001A6 RID: 422
		EnvvarNotFound,
		// Token: 0x040001A7 RID: 423
		NoSignalSent = 205,
		// Token: 0x040001A8 RID: 424
		FilenameExcedRange,
		// Token: 0x040001A9 RID: 425
		Ring2StackInUse,
		// Token: 0x040001AA RID: 426
		MetaExpansionTooLong,
		// Token: 0x040001AB RID: 427
		InvalidSignalNumber,
		// Token: 0x040001AC RID: 428
		Thread1Inactive,
		// Token: 0x040001AD RID: 429
		Locked = 212,
		// Token: 0x040001AE RID: 430
		TooManyModules = 214,
		// Token: 0x040001AF RID: 431
		NestingNotAllowed,
		// Token: 0x040001B0 RID: 432
		ExeMachineTypeMismatch,
		// Token: 0x040001B1 RID: 433
		ExeCannotModifySignedBinary,
		// Token: 0x040001B2 RID: 434
		ExeCannotModifyStrongSignedBinary,
		// Token: 0x040001B3 RID: 435
		FileCheckedOut = 220,
		// Token: 0x040001B4 RID: 436
		CheckoutRequired,
		// Token: 0x040001B5 RID: 437
		BadFileType,
		// Token: 0x040001B6 RID: 438
		FileTooLarge,
		// Token: 0x040001B7 RID: 439
		FormsAuthRequired,
		// Token: 0x040001B8 RID: 440
		VirusInfected,
		// Token: 0x040001B9 RID: 441
		VirusDeleted,
		// Token: 0x040001BA RID: 442
		PipeLocal = 229,
		// Token: 0x040001BB RID: 443
		BadPipe,
		// Token: 0x040001BC RID: 444
		PipeBusy,
		// Token: 0x040001BD RID: 445
		NoData,
		// Token: 0x040001BE RID: 446
		PipeNotConnected,
		// Token: 0x040001BF RID: 447
		MoreData,
		// Token: 0x040001C0 RID: 448
		NoWorkDone,
		// Token: 0x040001C1 RID: 449
		VcDisconnected = 240,
		// Token: 0x040001C2 RID: 450
		InvalidEaName = 254,
		// Token: 0x040001C3 RID: 451
		EaListInconsistent,
		// Token: 0x040001C4 RID: 452
		NoMoreItems = 259,
		// Token: 0x040001C5 RID: 453
		CannotCopy = 266,
		// Token: 0x040001C6 RID: 454
		Directory,
		// Token: 0x040001C7 RID: 455
		EasDidntFit = 275,
		// Token: 0x040001C8 RID: 456
		EaFileCorrupt,
		// Token: 0x040001C9 RID: 457
		EaTableFull,
		// Token: 0x040001CA RID: 458
		InvalidEaHandle,
		// Token: 0x040001CB RID: 459
		EasNotSupported = 282,
		// Token: 0x040001CC RID: 460
		NotOwner = 288,
		// Token: 0x040001CD RID: 461
		TooManyPosts = 298,
		// Token: 0x040001CE RID: 462
		PartialCopy,
		// Token: 0x040001CF RID: 463
		OplockNotGranted,
		// Token: 0x040001D0 RID: 464
		InvalidOplockProtocol,
		// Token: 0x040001D1 RID: 465
		DiskTooFragmented,
		// Token: 0x040001D2 RID: 466
		DeletePending,
		// Token: 0x040001D3 RID: 467
		IncompatibleWithGlobalShortNameRegistrySetting,
		// Token: 0x040001D4 RID: 468
		ShortNamesNotEnabledOnVolume,
		// Token: 0x040001D5 RID: 469
		SecurityStreamIsInconsistent,
		// Token: 0x040001D6 RID: 470
		InvalidLockRange,
		// Token: 0x040001D7 RID: 471
		ImageSubsystemNotPresent,
		// Token: 0x040001D8 RID: 472
		NotificationGuidAlreadyDefined,
		// Token: 0x040001D9 RID: 473
		InvalidExceptionHandler,
		// Token: 0x040001DA RID: 474
		DuplicatePrivileges,
		// Token: 0x040001DB RID: 475
		NoRangesProcessed,
		// Token: 0x040001DC RID: 476
		NotAllowedOnSystemFile,
		// Token: 0x040001DD RID: 477
		DiskResourcesExhausted,
		// Token: 0x040001DE RID: 478
		InvalidToken,
		// Token: 0x040001DF RID: 479
		DeviceFeatureNotSupported,
		// Token: 0x040001E0 RID: 480
		MrMidNotFound,
		// Token: 0x040001E1 RID: 481
		ScopeNotFound,
		// Token: 0x040001E2 RID: 482
		UndefinedScope,
		// Token: 0x040001E3 RID: 483
		InvalidCap,
		// Token: 0x040001E4 RID: 484
		DeviceUnreachable,
		// Token: 0x040001E5 RID: 485
		DeviceNoResources,
		// Token: 0x040001E6 RID: 486
		DataChecksumError,
		// Token: 0x040001E7 RID: 487
		IntermixedKernelEaOperation,
		// Token: 0x040001E8 RID: 488
		FileLevelTrimNotSupported = 326,
		// Token: 0x040001E9 RID: 489
		OffsetAlignmentViolation,
		// Token: 0x040001EA RID: 490
		InvalidFieldInParameterList,
		// Token: 0x040001EB RID: 491
		OperationInProgress,
		// Token: 0x040001EC RID: 492
		BadDevicePath,
		// Token: 0x040001ED RID: 493
		TooManyDescriptors,
		// Token: 0x040001EE RID: 494
		ScrubDataDisabled,
		// Token: 0x040001EF RID: 495
		NotRedundantStorage,
		// Token: 0x040001F0 RID: 496
		ResidentFileNotSupported,
		// Token: 0x040001F1 RID: 497
		CompressedFileNotSupported,
		// Token: 0x040001F2 RID: 498
		DirectoryNotSupported,
		// Token: 0x040001F3 RID: 499
		NotReadFromCopy,
		// Token: 0x040001F4 RID: 500
		FtWriteFailure,
		// Token: 0x040001F5 RID: 501
		FtDiScanRequired,
		// Token: 0x040001F6 RID: 502
		InvalidKernelInfoVersion,
		// Token: 0x040001F7 RID: 503
		InvalidPepInfoVersion,
		// Token: 0x040001F8 RID: 504
		ObjectNotExternallyBacked,
		// Token: 0x040001F9 RID: 505
		ExternalBackingProviderUnknown,
		// Token: 0x040001FA RID: 506
		CompressionNotBeneficial,
		// Token: 0x040001FB RID: 507
		StorageTopologyIdMismatch,
		// Token: 0x040001FC RID: 508
		BlockedByParentalControls,
		// Token: 0x040001FD RID: 509
		BlockTooManyReferences,
		// Token: 0x040001FE RID: 510
		MarkedToDisallowWrites,
		// Token: 0x040001FF RID: 511
		EnclaveFailure,
		// Token: 0x04000200 RID: 512
		FailNoactionReboot,
		// Token: 0x04000201 RID: 513
		FailShutdown,
		// Token: 0x04000202 RID: 514
		FailRestart,
		// Token: 0x04000203 RID: 515
		MaxSessionsReached,
		// Token: 0x04000204 RID: 516
		NetworkAccessDeniedEdp,
		// Token: 0x04000205 RID: 517
		DeviceHintNameBufferTooSmall,
		// Token: 0x04000206 RID: 518
		EdpPolicyDeniesOperation,
		// Token: 0x04000207 RID: 519
		EdpDplPolicyCantBeSatisfied,
		// Token: 0x04000208 RID: 520
		CloudFileSyncRootMetadataCorrupt,
		// Token: 0x04000209 RID: 521
		DeviceInMaintenance,
		// Token: 0x0400020A RID: 522
		NotSupportedOnDax,
		// Token: 0x0400020B RID: 523
		DaxMappingExists,
		// Token: 0x0400020C RID: 524
		CloudFileProviderNotRunning,
		// Token: 0x0400020D RID: 525
		CloudFileMetadataCorrupt,
		// Token: 0x0400020E RID: 526
		CloudFileMetadataTooLarge,
		// Token: 0x0400020F RID: 527
		CloudFilePropertyBlobTooLarge,
		// Token: 0x04000210 RID: 528
		CloudFilePropertyBlobChecksumMismatch,
		// Token: 0x04000211 RID: 529
		ChildProcessBlocked,
		// Token: 0x04000212 RID: 530
		StorageLostDataPersistence,
		// Token: 0x04000213 RID: 531
		FileSystemVirtualizationUnavailable,
		// Token: 0x04000214 RID: 532
		FileSystemVirtualizationMetadataCorrupt,
		// Token: 0x04000215 RID: 533
		FileSystemVirtualizationBusy,
		// Token: 0x04000216 RID: 534
		FileSystemVirtualizationProviderUnknown,
		// Token: 0x04000217 RID: 535
		GdiHandleLeak,
		// Token: 0x04000218 RID: 536
		CloudFileTooManyPropertyBlobs,
		// Token: 0x04000219 RID: 537
		CloudFilePropertyVersionNotSupported,
		// Token: 0x0400021A RID: 538
		NotACloudFile,
		// Token: 0x0400021B RID: 539
		CloudFileNotInSync,
		// Token: 0x0400021C RID: 540
		CloudFileAlreadyConnected,
		// Token: 0x0400021D RID: 541
		CloudFileNotSupported,
		// Token: 0x0400021E RID: 542
		CloudFileInvalidRequest,
		// Token: 0x0400021F RID: 543
		CloudFileReadOnlyVolume,
		// Token: 0x04000220 RID: 544
		CloudFileConnectedProviderOnly,
		// Token: 0x04000221 RID: 545
		CloudFileValidationFailed,
		// Token: 0x04000222 RID: 546
		Smb1NotAvailable,
		// Token: 0x04000223 RID: 547
		FileSystemVirtualizationInvalidOperation,
		// Token: 0x04000224 RID: 548
		CloudFileAuthenticationFailed,
		// Token: 0x04000225 RID: 549
		CloudFileInsufficientResources,
		// Token: 0x04000226 RID: 550
		CloudFileNetworkUnavailable,
		// Token: 0x04000227 RID: 551
		CloudFileUnsuccessful,
		// Token: 0x04000228 RID: 552
		CloudFileNotUnderSyncRoot,
		// Token: 0x04000229 RID: 553
		CloudFileInUse,
		// Token: 0x0400022A RID: 554
		CloudFilePinned,
		// Token: 0x0400022B RID: 555
		CloudFileRequestAborted,
		// Token: 0x0400022C RID: 556
		CloudFilePropertyCorrupt,
		// Token: 0x0400022D RID: 557
		CloudFileAccessDenied,
		// Token: 0x0400022E RID: 558
		CloudFileIncompatibleHardlinks,
		// Token: 0x0400022F RID: 559
		CloudFilePropertyLockConflict,
		// Token: 0x04000230 RID: 560
		CloudFileRequestCanceled,
		// Token: 0x04000231 RID: 561
		ExternalSyskeyNotSupported,
		// Token: 0x04000232 RID: 562
		ThreadModeAlreadyBackground,
		// Token: 0x04000233 RID: 563
		ThreadModeNotBackground,
		// Token: 0x04000234 RID: 564
		ProcessModeAlreadyBackground,
		// Token: 0x04000235 RID: 565
		ProcessModeNotBackground,
		// Token: 0x04000236 RID: 566
		CapauthzNotDevunlocked = 450,
		// Token: 0x04000237 RID: 567
		CapauthzChangeType,
		// Token: 0x04000238 RID: 568
		CapauthzNotProvisioned,
		// Token: 0x04000239 RID: 569
		CapauthzNotAuthorized,
		// Token: 0x0400023A RID: 570
		CapauthzNoPolicy,
		// Token: 0x0400023B RID: 571
		CapauthzDbCorrupted,
		// Token: 0x0400023C RID: 572
		CapauthzSccdInvalidCatalog,
		// Token: 0x0400023D RID: 573
		CapauthzSccdNoAuthEntity,
		// Token: 0x0400023E RID: 574
		CapauthzSccdParseError,
		// Token: 0x0400023F RID: 575
		CapauthzSccdDevModeRequired,
		// Token: 0x04000240 RID: 576
		CapauthzSccdNoCapabilityMatch,
		// Token: 0x04000241 RID: 577
		PnpQueryRemoveDeviceTimeout = 480,
		// Token: 0x04000242 RID: 578
		PnpQueryRemoveRelatedDeviceTimeout,
		// Token: 0x04000243 RID: 579
		PnpQueryRemoveUnrelatedDeviceTimeout,
		// Token: 0x04000244 RID: 580
		DeviceHardwareError,
		// Token: 0x04000245 RID: 581
		InvalidAddress = 487,
		// Token: 0x04000246 RID: 582
		VrfCfgEnabled = 1183,
		// Token: 0x04000247 RID: 583
		PartitionTerminating,
		// Token: 0x04000248 RID: 584
		UserProfileLoad = 500,
		// Token: 0x04000249 RID: 585
		ArithmeticOverflow = 534,
		// Token: 0x0400024A RID: 586
		PipeConnected,
		// Token: 0x0400024B RID: 587
		PipeListening,
		// Token: 0x0400024C RID: 588
		VerifierStop,
		// Token: 0x0400024D RID: 589
		AbiosError,
		// Token: 0x0400024E RID: 590
		Wx86Warning,
		// Token: 0x0400024F RID: 591
		Wx86Error,
		// Token: 0x04000250 RID: 592
		TimerNotCanceled,
		// Token: 0x04000251 RID: 593
		Unwind,
		// Token: 0x04000252 RID: 594
		BadStack,
		// Token: 0x04000253 RID: 595
		InvalidUnwindTarget,
		// Token: 0x04000254 RID: 596
		InvalidPortAttributes,
		// Token: 0x04000255 RID: 597
		PortMessageTooLong,
		// Token: 0x04000256 RID: 598
		InvalidQuotaLower,
		// Token: 0x04000257 RID: 599
		DeviceAlreadyAttached,
		// Token: 0x04000258 RID: 600
		InstructionMisalignment,
		// Token: 0x04000259 RID: 601
		ProfilingNotStarted,
		// Token: 0x0400025A RID: 602
		ProfilingNotStopped,
		// Token: 0x0400025B RID: 603
		CouldNotInterpret,
		// Token: 0x0400025C RID: 604
		ProfilingAtLimit,
		// Token: 0x0400025D RID: 605
		CantWait,
		// Token: 0x0400025E RID: 606
		CantTerminateSelf,
		// Token: 0x0400025F RID: 607
		UnexpectedMmCreateErr,
		// Token: 0x04000260 RID: 608
		UnexpectedMmMapError,
		// Token: 0x04000261 RID: 609
		UnexpectedMmExtendErr,
		// Token: 0x04000262 RID: 610
		BadFunctionTable,
		// Token: 0x04000263 RID: 611
		NoGuidTranslation,
		// Token: 0x04000264 RID: 612
		InvalidLdtSize,
		// Token: 0x04000265 RID: 613
		InvalidLdtOffset = 563,
		// Token: 0x04000266 RID: 614
		InvalidLdtDescriptor,
		// Token: 0x04000267 RID: 615
		TooManyThreads,
		// Token: 0x04000268 RID: 616
		ThreadNotInProcess,
		// Token: 0x04000269 RID: 617
		PagefileQuotaExceeded,
		// Token: 0x0400026A RID: 618
		LogonServerConflict,
		// Token: 0x0400026B RID: 619
		SynchronizationRequired,
		// Token: 0x0400026C RID: 620
		NetOpenFailed,
		// Token: 0x0400026D RID: 621
		IoPrivilegeFailed,
		// Token: 0x0400026E RID: 622
		ControlCExit,
		// Token: 0x0400026F RID: 623
		MissingSystemfile,
		// Token: 0x04000270 RID: 624
		UnhandledException,
		// Token: 0x04000271 RID: 625
		AppInitFailure,
		// Token: 0x04000272 RID: 626
		PagefileCreateFailed,
		// Token: 0x04000273 RID: 627
		InvalidImageHash,
		// Token: 0x04000274 RID: 628
		NoPagefile,
		// Token: 0x04000275 RID: 629
		IllegalFloatContext,
		// Token: 0x04000276 RID: 630
		NoEventPair,
		// Token: 0x04000277 RID: 631
		DomainCtrlrConfigError,
		// Token: 0x04000278 RID: 632
		IllegalCharacter,
		// Token: 0x04000279 RID: 633
		UndefinedCharacter,
		// Token: 0x0400027A RID: 634
		FloppyVolume,
		// Token: 0x0400027B RID: 635
		BiosFailedToConnectInterrupt,
		// Token: 0x0400027C RID: 636
		BackupController,
		// Token: 0x0400027D RID: 637
		MutantLimitExceeded,
		// Token: 0x0400027E RID: 638
		FsDriverRequired,
		// Token: 0x0400027F RID: 639
		CannotLoadRegistryFile,
		// Token: 0x04000280 RID: 640
		DebugAttachFailed,
		// Token: 0x04000281 RID: 641
		SystemProcessTerminated,
		// Token: 0x04000282 RID: 642
		DataNotAccepted,
		// Token: 0x04000283 RID: 643
		VdmHardError,
		// Token: 0x04000284 RID: 644
		DriverCancelTimeout,
		// Token: 0x04000285 RID: 645
		ReplyMessageMismatch,
		// Token: 0x04000286 RID: 646
		LostWritebehindData,
		// Token: 0x04000287 RID: 647
		ClientServerParametersInvalid,
		// Token: 0x04000288 RID: 648
		NotTinyStream,
		// Token: 0x04000289 RID: 649
		StackOverflowRead,
		// Token: 0x0400028A RID: 650
		ConvertToLarge,
		// Token: 0x0400028B RID: 651
		FoundOutOfScope,
		// Token: 0x0400028C RID: 652
		AllocateBucket,
		// Token: 0x0400028D RID: 653
		MarshallOverflow,
		// Token: 0x0400028E RID: 654
		InvalidVariant,
		// Token: 0x0400028F RID: 655
		BadCompressionBuffer,
		// Token: 0x04000290 RID: 656
		AuditFailed,
		// Token: 0x04000291 RID: 657
		TimerResolutionNotSet,
		// Token: 0x04000292 RID: 658
		InsufficientLogonInfo,
		// Token: 0x04000293 RID: 659
		BadDllEntrypoint,
		// Token: 0x04000294 RID: 660
		BadServiceEntrypoint,
		// Token: 0x04000295 RID: 661
		IpAddressConflict1,
		// Token: 0x04000296 RID: 662
		IpAddressConflict2,
		// Token: 0x04000297 RID: 663
		RegistryQuotaLimit,
		// Token: 0x04000298 RID: 664
		NoCallbackActive,
		// Token: 0x04000299 RID: 665
		PwdTooShort,
		// Token: 0x0400029A RID: 666
		PwdTooRecent,
		// Token: 0x0400029B RID: 667
		PwdHistoryConflict,
		// Token: 0x0400029C RID: 668
		UnsupportedCompression,
		// Token: 0x0400029D RID: 669
		InvalidHwProfile,
		// Token: 0x0400029E RID: 670
		InvalidPlugplayDevicePath,
		// Token: 0x0400029F RID: 671
		QuotaListInconsistent,
		// Token: 0x040002A0 RID: 672
		EvaluationExpiration,
		// Token: 0x040002A1 RID: 673
		IllegalDllRelocation,
		// Token: 0x040002A2 RID: 674
		DllInitFailedLogoff,
		// Token: 0x040002A3 RID: 675
		ValidateContinue,
		// Token: 0x040002A4 RID: 676
		NoMoreMatches,
		// Token: 0x040002A5 RID: 677
		RangeListConflict,
		// Token: 0x040002A6 RID: 678
		ServerSidMismatch,
		// Token: 0x040002A7 RID: 679
		CantEnableDenyOnly,
		// Token: 0x040002A8 RID: 680
		FloatMultipleFaults,
		// Token: 0x040002A9 RID: 681
		FloatMultipleTraps,
		// Token: 0x040002AA RID: 682
		Nointerface,
		// Token: 0x040002AB RID: 683
		DriverFailedSleep,
		// Token: 0x040002AC RID: 684
		CorruptSystemFile,
		// Token: 0x040002AD RID: 685
		CommitmentMinimum,
		// Token: 0x040002AE RID: 686
		PnpRestartEnumeration,
		// Token: 0x040002AF RID: 687
		SystemImageBadSignature,
		// Token: 0x040002B0 RID: 688
		PnpRebootRequired,
		// Token: 0x040002B1 RID: 689
		InsufficientPower,
		// Token: 0x040002B2 RID: 690
		MultipleFaultViolation,
		// Token: 0x040002B3 RID: 691
		SystemShutdown,
		// Token: 0x040002B4 RID: 692
		PortNotSet,
		// Token: 0x040002B5 RID: 693
		DsVersionCheckFailure,
		// Token: 0x040002B6 RID: 694
		RangeNotFound,
		// Token: 0x040002B7 RID: 695
		NotSafeModeDriver = 646,
		// Token: 0x040002B8 RID: 696
		FailedDriverEntry,
		// Token: 0x040002B9 RID: 697
		DeviceEnumerationError,
		// Token: 0x040002BA RID: 698
		MountPointNotResolved,
		// Token: 0x040002BB RID: 699
		InvalidDeviceObjectParameter,
		// Token: 0x040002BC RID: 700
		McaOccured,
		// Token: 0x040002BD RID: 701
		DriverDatabaseError,
		// Token: 0x040002BE RID: 702
		SystemHiveTooLarge,
		// Token: 0x040002BF RID: 703
		DriverFailedPriorUnload,
		// Token: 0x040002C0 RID: 704
		VolsnapPrepareHibernate,
		// Token: 0x040002C1 RID: 705
		HibernationFailure,
		// Token: 0x040002C2 RID: 706
		PwdTooLong,
		// Token: 0x040002C3 RID: 707
		FileSystemLimitation = 665,
		// Token: 0x040002C4 RID: 708
		AssertionFailure = 668,
		// Token: 0x040002C5 RID: 709
		AcpiError,
		// Token: 0x040002C6 RID: 710
		WowAssertion,
		// Token: 0x040002C7 RID: 711
		PnpBadMpsTable,
		// Token: 0x040002C8 RID: 712
		PnpTranslationFailed,
		// Token: 0x040002C9 RID: 713
		PnpIrqTranslationFailed,
		// Token: 0x040002CA RID: 714
		PnpInvalidId,
		// Token: 0x040002CB RID: 715
		WakeSystemDebugger,
		// Token: 0x040002CC RID: 716
		HandlesClosed,
		// Token: 0x040002CD RID: 717
		ExtraneousInformation,
		// Token: 0x040002CE RID: 718
		RxactCommitNecessary,
		// Token: 0x040002CF RID: 719
		MediaCheck,
		// Token: 0x040002D0 RID: 720
		GuidSubstitutionMade,
		// Token: 0x040002D1 RID: 721
		StoppedOnSymlink,
		// Token: 0x040002D2 RID: 722
		Longjump,
		// Token: 0x040002D3 RID: 723
		PlugplayQueryVetoed,
		// Token: 0x040002D4 RID: 724
		UnwindConsolidate,
		// Token: 0x040002D5 RID: 725
		RegistryHiveRecovered,
		// Token: 0x040002D6 RID: 726
		DllMightBeInsecure,
		// Token: 0x040002D7 RID: 727
		DllMightBeIncompatible,
		// Token: 0x040002D8 RID: 728
		DbgExceptionNotHandled,
		// Token: 0x040002D9 RID: 729
		DbgReplyLater,
		// Token: 0x040002DA RID: 730
		DbgUnableToProvideHandle,
		// Token: 0x040002DB RID: 731
		DbgTerminateThread,
		// Token: 0x040002DC RID: 732
		DbgTerminateProcess,
		// Token: 0x040002DD RID: 733
		DbgControlC,
		// Token: 0x040002DE RID: 734
		DbgPrintexceptionC,
		// Token: 0x040002DF RID: 735
		DbgRipexception,
		// Token: 0x040002E0 RID: 736
		DbgControlBreak,
		// Token: 0x040002E1 RID: 737
		DbgCommandException,
		// Token: 0x040002E2 RID: 738
		ObjectNameExists,
		// Token: 0x040002E3 RID: 739
		ThreadWasSuspended,
		// Token: 0x040002E4 RID: 740
		ImageNotAtBase,
		// Token: 0x040002E5 RID: 741
		RxactStateCreated,
		// Token: 0x040002E6 RID: 742
		SegmentNotification,
		// Token: 0x040002E7 RID: 743
		BadCurrentDirectory,
		// Token: 0x040002E8 RID: 744
		FtReadRecoveryFromBackup,
		// Token: 0x040002E9 RID: 745
		FtWriteRecovery,
		// Token: 0x040002EA RID: 746
		ImageMachineTypeMismatch,
		// Token: 0x040002EB RID: 747
		ReceivePartial,
		// Token: 0x040002EC RID: 748
		ReceiveExpedited,
		// Token: 0x040002ED RID: 749
		ReceivePartialExpedited,
		// Token: 0x040002EE RID: 750
		EventDone,
		// Token: 0x040002EF RID: 751
		EventPending,
		// Token: 0x040002F0 RID: 752
		CheckingFileSystem,
		// Token: 0x040002F1 RID: 753
		FatalAppExit,
		// Token: 0x040002F2 RID: 754
		PredefinedHandle,
		// Token: 0x040002F3 RID: 755
		WasUnlocked,
		// Token: 0x040002F4 RID: 756
		ServiceNotification,
		// Token: 0x040002F5 RID: 757
		WasLocked,
		// Token: 0x040002F6 RID: 758
		LogHardError,
		// Token: 0x040002F7 RID: 759
		AlreadyWin32,
		// Token: 0x040002F8 RID: 760
		ImageMachineTypeMismatchExe,
		// Token: 0x040002F9 RID: 761
		NoYieldPerformed,
		// Token: 0x040002FA RID: 762
		TimerResumeIgnored,
		// Token: 0x040002FB RID: 763
		ArbitrationUnhandled,
		// Token: 0x040002FC RID: 764
		CardbusNotSupported,
		// Token: 0x040002FD RID: 765
		MpProcessorMismatch,
		// Token: 0x040002FE RID: 766
		Hibernated,
		// Token: 0x040002FF RID: 767
		ResumeHibernation,
		// Token: 0x04000300 RID: 768
		FirmwareUpdated,
		// Token: 0x04000301 RID: 769
		DriversLeakingLockedPages,
		// Token: 0x04000302 RID: 770
		WakeSystem,
		// Token: 0x04000303 RID: 771
		Wait1,
		// Token: 0x04000304 RID: 772
		Wait2,
		// Token: 0x04000305 RID: 773
		Wait3,
		// Token: 0x04000306 RID: 774
		Wait63,
		// Token: 0x04000307 RID: 775
		AbandonedWait0,
		// Token: 0x04000308 RID: 776
		AbandonedWait63,
		// Token: 0x04000309 RID: 777
		UserApc,
		// Token: 0x0400030A RID: 778
		KernelApc,
		// Token: 0x0400030B RID: 779
		Alerted,
		// Token: 0x0400030C RID: 780
		ElevationRequired,
		// Token: 0x0400030D RID: 781
		Reparse,
		// Token: 0x0400030E RID: 782
		OplockBreakInProgress,
		// Token: 0x0400030F RID: 783
		VolumeMounted,
		// Token: 0x04000310 RID: 784
		RxactCommitted,
		// Token: 0x04000311 RID: 785
		NotifyCleanup,
		// Token: 0x04000312 RID: 786
		PrimaryTransportConnectFailed,
		// Token: 0x04000313 RID: 787
		PageFaultTransition,
		// Token: 0x04000314 RID: 788
		PageFaultDemandZero,
		// Token: 0x04000315 RID: 789
		PageFaultCopyOnWrite,
		// Token: 0x04000316 RID: 790
		PageFaultGuardPage,
		// Token: 0x04000317 RID: 791
		PageFaultPagingFile,
		// Token: 0x04000318 RID: 792
		CachePageLocked,
		// Token: 0x04000319 RID: 793
		CrashDump,
		// Token: 0x0400031A RID: 794
		BufferAllZeros,
		// Token: 0x0400031B RID: 795
		ReparseObject,
		// Token: 0x0400031C RID: 796
		ResourceRequirementsChanged,
		// Token: 0x0400031D RID: 797
		TranslationComplete,
		// Token: 0x0400031E RID: 798
		NothingToTerminate,
		// Token: 0x0400031F RID: 799
		ProcessNotInJob,
		// Token: 0x04000320 RID: 800
		ProcessInJob,
		// Token: 0x04000321 RID: 801
		VolsnapHibernateReady,
		// Token: 0x04000322 RID: 802
		FsfilterOpCompletedSuccessfully,
		// Token: 0x04000323 RID: 803
		InterruptVectorAlreadyConnected,
		// Token: 0x04000324 RID: 804
		InterruptStillConnected,
		// Token: 0x04000325 RID: 805
		WaitForOplock,
		// Token: 0x04000326 RID: 806
		DbgExceptionHandled,
		// Token: 0x04000327 RID: 807
		DbgContinue,
		// Token: 0x04000328 RID: 808
		CallbackPopStack,
		// Token: 0x04000329 RID: 809
		CompressionDisabled,
		// Token: 0x0400032A RID: 810
		Cantfetchbackwards,
		// Token: 0x0400032B RID: 811
		Cantscrollbackwards,
		// Token: 0x0400032C RID: 812
		Rowsnotreleased,
		// Token: 0x0400032D RID: 813
		BadAccessorFlags,
		// Token: 0x0400032E RID: 814
		ErrorsEncountered,
		// Token: 0x0400032F RID: 815
		NotCapable,
		// Token: 0x04000330 RID: 816
		RequestOutOfSequence,
		// Token: 0x04000331 RID: 817
		VersionParseError,
		// Token: 0x04000332 RID: 818
		Badstartposition,
		// Token: 0x04000333 RID: 819
		MemoryHardware,
		// Token: 0x04000334 RID: 820
		DiskRepairDisabled,
		// Token: 0x04000335 RID: 821
		InsufficientResourceForSpecifiedSharedSectionSize,
		// Token: 0x04000336 RID: 822
		SystemPowerstateTransition,
		// Token: 0x04000337 RID: 823
		SystemPowerstateComplexTransition,
		// Token: 0x04000338 RID: 824
		McaException,
		// Token: 0x04000339 RID: 825
		AccessAuditByPolicy,
		// Token: 0x0400033A RID: 826
		AccessDisabledNoSaferUiByPolicy,
		// Token: 0x0400033B RID: 827
		AbandonHiberfile,
		// Token: 0x0400033C RID: 828
		LostWritebehindDataNetworkDisconnected,
		// Token: 0x0400033D RID: 829
		LostWritebehindDataNetworkServerError,
		// Token: 0x0400033E RID: 830
		LostWritebehindDataLocalDiskError,
		// Token: 0x0400033F RID: 831
		BadMcfgTable,
		// Token: 0x04000340 RID: 832
		DiskRepairRedirected,
		// Token: 0x04000341 RID: 833
		DiskRepairUnsuccessful,
		// Token: 0x04000342 RID: 834
		CorruptLogOverfull,
		// Token: 0x04000343 RID: 835
		CorruptLogCorrupted,
		// Token: 0x04000344 RID: 836
		CorruptLogUnavailable,
		// Token: 0x04000345 RID: 837
		CorruptLogDeletedFull,
		// Token: 0x04000346 RID: 838
		CorruptLogCleared,
		// Token: 0x04000347 RID: 839
		OrphanNameExhausted,
		// Token: 0x04000348 RID: 840
		OplockSwitchedToNewHandle,
		// Token: 0x04000349 RID: 841
		CannotGrantRequestedOplock,
		// Token: 0x0400034A RID: 842
		CannotBreakOplock,
		// Token: 0x0400034B RID: 843
		OplockHandleClosed,
		// Token: 0x0400034C RID: 844
		NoAceCondition,
		// Token: 0x0400034D RID: 845
		InvalidAceCondition,
		// Token: 0x0400034E RID: 846
		FileHandleRevoked,
		// Token: 0x0400034F RID: 847
		ImageAtDifferentBase,
		// Token: 0x04000350 RID: 848
		EncryptedIoNotPossible,
		// Token: 0x04000351 RID: 849
		FileMetadataOptimizationInProgress,
		// Token: 0x04000352 RID: 850
		QuotaActivity,
		// Token: 0x04000353 RID: 851
		HandleRevoked,
		// Token: 0x04000354 RID: 852
		CallbackInvokeInline,
		// Token: 0x04000355 RID: 853
		CpuSetInvalid,
		// Token: 0x04000356 RID: 854
		EnclaveNotTerminated,
		// Token: 0x04000357 RID: 855
		EaAccessDenied = 994,
		// Token: 0x04000358 RID: 856
		OperationAborted,
		// Token: 0x04000359 RID: 857
		IoIncomplete,
		// Token: 0x0400035A RID: 858
		IoPending,
		// Token: 0x0400035B RID: 859
		Noaccess,
		// Token: 0x0400035C RID: 860
		Swaperror,
		// Token: 0x0400035D RID: 861
		StackOverflow = 1001,
		// Token: 0x0400035E RID: 862
		InvalidMessage,
		// Token: 0x0400035F RID: 863
		CanNotComplete,
		// Token: 0x04000360 RID: 864
		InvalidFlags,
		// Token: 0x04000361 RID: 865
		UnrecognizedVolume,
		// Token: 0x04000362 RID: 866
		FileInvalid,
		// Token: 0x04000363 RID: 867
		FullscreenMode,
		// Token: 0x04000364 RID: 868
		NoToken,
		// Token: 0x04000365 RID: 869
		Baddb,
		// Token: 0x04000366 RID: 870
		Badkey,
		// Token: 0x04000367 RID: 871
		Cantopen,
		// Token: 0x04000368 RID: 872
		Cantread,
		// Token: 0x04000369 RID: 873
		Cantwrite,
		// Token: 0x0400036A RID: 874
		RegistryRecovered,
		// Token: 0x0400036B RID: 875
		RegistryCorrupt,
		// Token: 0x0400036C RID: 876
		RegistryIoFailed,
		// Token: 0x0400036D RID: 877
		NotRegistryFile,
		// Token: 0x0400036E RID: 878
		KeyDeleted,
		// Token: 0x0400036F RID: 879
		NoLogSpace,
		// Token: 0x04000370 RID: 880
		KeyHasChildren,
		// Token: 0x04000371 RID: 881
		ChildMustBeVolatile,
		// Token: 0x04000372 RID: 882
		NotifyEnumDir,
		// Token: 0x04000373 RID: 883
		DependentServicesRunning = 1051,
		// Token: 0x04000374 RID: 884
		InvalidServiceControl,
		// Token: 0x04000375 RID: 885
		ServiceRequestTimeout,
		// Token: 0x04000376 RID: 886
		ServiceNoThread,
		// Token: 0x04000377 RID: 887
		ServiceDatabaseLocked,
		// Token: 0x04000378 RID: 888
		ServiceAlreadyRunning,
		// Token: 0x04000379 RID: 889
		InvalidServiceAccount,
		// Token: 0x0400037A RID: 890
		ServiceDisabled,
		// Token: 0x0400037B RID: 891
		CircularDependency,
		// Token: 0x0400037C RID: 892
		ServiceDoesNotExist,
		// Token: 0x0400037D RID: 893
		ServiceCannotAcceptCtrl,
		// Token: 0x0400037E RID: 894
		ServiceNotActive,
		// Token: 0x0400037F RID: 895
		FailedServiceControllerConnect,
		// Token: 0x04000380 RID: 896
		ExceptionInService,
		// Token: 0x04000381 RID: 897
		DatabaseDoesNotExist,
		// Token: 0x04000382 RID: 898
		ServiceSpecificError,
		// Token: 0x04000383 RID: 899
		ProcessAborted,
		// Token: 0x04000384 RID: 900
		ServiceDependencyFail,
		// Token: 0x04000385 RID: 901
		ServiceLogonFailed,
		// Token: 0x04000386 RID: 902
		ServiceStartHang,
		// Token: 0x04000387 RID: 903
		InvalidServiceLock,
		// Token: 0x04000388 RID: 904
		ServiceMarkedForDelete,
		// Token: 0x04000389 RID: 905
		ServiceExists,
		// Token: 0x0400038A RID: 906
		AlreadyRunningLkg,
		// Token: 0x0400038B RID: 907
		ServiceDependencyDeleted,
		// Token: 0x0400038C RID: 908
		BootAlreadyAccepted,
		// Token: 0x0400038D RID: 909
		ServiceNeverStarted,
		// Token: 0x0400038E RID: 910
		DuplicateServiceName,
		// Token: 0x0400038F RID: 911
		DifferentServiceAccount,
		// Token: 0x04000390 RID: 912
		CannotDetectDriverFailure,
		// Token: 0x04000391 RID: 913
		CannotDetectProcessAbort,
		// Token: 0x04000392 RID: 914
		NoRecoveryProgram,
		// Token: 0x04000393 RID: 915
		ServiceNotInExe,
		// Token: 0x04000394 RID: 916
		NotSafebootService,
		// Token: 0x04000395 RID: 917
		EndOfMedia = 1100,
		// Token: 0x04000396 RID: 918
		FilemarkDetected,
		// Token: 0x04000397 RID: 919
		BeginningOfMedia,
		// Token: 0x04000398 RID: 920
		SetmarkDetected,
		// Token: 0x04000399 RID: 921
		NoDataDetected,
		// Token: 0x0400039A RID: 922
		PartitionFailure,
		// Token: 0x0400039B RID: 923
		InvalidBlockLength,
		// Token: 0x0400039C RID: 924
		DeviceNotPartitioned,
		// Token: 0x0400039D RID: 925
		UnableToLockMedia,
		// Token: 0x0400039E RID: 926
		UnableToUnloadMedia,
		// Token: 0x0400039F RID: 927
		MediaChanged,
		// Token: 0x040003A0 RID: 928
		BusReset,
		// Token: 0x040003A1 RID: 929
		NoMediaInDrive,
		// Token: 0x040003A2 RID: 930
		NoUnicodeTranslation,
		// Token: 0x040003A3 RID: 931
		DllInitFailed,
		// Token: 0x040003A4 RID: 932
		ShutdownInProgress,
		// Token: 0x040003A5 RID: 933
		NoShutdownInProgress,
		// Token: 0x040003A6 RID: 934
		IoDevice,
		// Token: 0x040003A7 RID: 935
		SerialNoDevice,
		// Token: 0x040003A8 RID: 936
		IrqBusy,
		// Token: 0x040003A9 RID: 937
		MoreWrites,
		// Token: 0x040003AA RID: 938
		CounterTimeout,
		// Token: 0x040003AB RID: 939
		FloppyIdMarkNotFound,
		// Token: 0x040003AC RID: 940
		FloppyWrongCylinder,
		// Token: 0x040003AD RID: 941
		FloppyUnknownError,
		// Token: 0x040003AE RID: 942
		FloppyBadRegisters,
		// Token: 0x040003AF RID: 943
		DiskRecalibrateFailed,
		// Token: 0x040003B0 RID: 944
		DiskOperationFailed,
		// Token: 0x040003B1 RID: 945
		DiskResetFailed,
		// Token: 0x040003B2 RID: 946
		EomOverflow,
		// Token: 0x040003B3 RID: 947
		NotEnoughServerMemory,
		// Token: 0x040003B4 RID: 948
		PossibleDeadlock,
		// Token: 0x040003B5 RID: 949
		MappedAlignment,
		// Token: 0x040003B6 RID: 950
		SetPowerStateVetoed = 1140,
		// Token: 0x040003B7 RID: 951
		SetPowerStateFailed,
		// Token: 0x040003B8 RID: 952
		TooManyLinks,
		// Token: 0x040003B9 RID: 953
		OldWinVersion = 1150,
		// Token: 0x040003BA RID: 954
		AppWrongOs,
		// Token: 0x040003BB RID: 955
		SingleInstanceApp,
		// Token: 0x040003BC RID: 956
		RmodeApp,
		// Token: 0x040003BD RID: 957
		InvalidDll,
		// Token: 0x040003BE RID: 958
		NoAssociation,
		// Token: 0x040003BF RID: 959
		DdeFail,
		// Token: 0x040003C0 RID: 960
		DllNotFound,
		// Token: 0x040003C1 RID: 961
		NoMoreUserHandles,
		// Token: 0x040003C2 RID: 962
		MessageSyncOnly,
		// Token: 0x040003C3 RID: 963
		SourceElementEmpty,
		// Token: 0x040003C4 RID: 964
		DestinationElementFull,
		// Token: 0x040003C5 RID: 965
		IllegalElementAddress,
		// Token: 0x040003C6 RID: 966
		MagazineNotPresent,
		// Token: 0x040003C7 RID: 967
		DeviceReinitializationNeeded,
		// Token: 0x040003C8 RID: 968
		DeviceRequiresCleaning,
		// Token: 0x040003C9 RID: 969
		DeviceDoorOpen,
		// Token: 0x040003CA RID: 970
		DeviceNotConnected,
		// Token: 0x040003CB RID: 971
		NotFound,
		// Token: 0x040003CC RID: 972
		NoMatch,
		// Token: 0x040003CD RID: 973
		SetNotFound,
		// Token: 0x040003CE RID: 974
		PointNotFound,
		// Token: 0x040003CF RID: 975
		NoTrackingService,
		// Token: 0x040003D0 RID: 976
		NoVolumeId,
		// Token: 0x040003D1 RID: 977
		UnableToRemoveReplaced = 1175,
		// Token: 0x040003D2 RID: 978
		UnableToMoveReplacement,
		// Token: 0x040003D3 RID: 979
		UnableToMoveReplacement2,
		// Token: 0x040003D4 RID: 980
		JournalDeleteInProgress,
		// Token: 0x040003D5 RID: 981
		JournalNotActive,
		// Token: 0x040003D6 RID: 982
		PotentialFileFound,
		// Token: 0x040003D7 RID: 983
		JournalEntryDeleted,
		// Token: 0x040003D8 RID: 984
		ShutdownIsScheduled = 1190,
		// Token: 0x040003D9 RID: 985
		ShutdownUsersLoggedOn,
		// Token: 0x040003DA RID: 986
		BadDevice = 1200,
		// Token: 0x040003DB RID: 987
		ConnectionUnavail,
		// Token: 0x040003DC RID: 988
		DeviceAlreadyRemembered,
		// Token: 0x040003DD RID: 989
		NoNetOrBadPath,
		// Token: 0x040003DE RID: 990
		BadProvider,
		// Token: 0x040003DF RID: 991
		CannotOpenProfile,
		// Token: 0x040003E0 RID: 992
		BadProfile,
		// Token: 0x040003E1 RID: 993
		NotContainer,
		// Token: 0x040003E2 RID: 994
		ExtendedError,
		// Token: 0x040003E3 RID: 995
		InvalidGroupname,
		// Token: 0x040003E4 RID: 996
		InvalidComputername,
		// Token: 0x040003E5 RID: 997
		InvalidEventname,
		// Token: 0x040003E6 RID: 998
		InvalidDomainname,
		// Token: 0x040003E7 RID: 999
		InvalidServicename,
		// Token: 0x040003E8 RID: 1000
		InvalidNetname,
		// Token: 0x040003E9 RID: 1001
		InvalidSharename,
		// Token: 0x040003EA RID: 1002
		InvalidPasswordname,
		// Token: 0x040003EB RID: 1003
		InvalidMessagename,
		// Token: 0x040003EC RID: 1004
		InvalidMessagedest,
		// Token: 0x040003ED RID: 1005
		SessionCredentialConflict,
		// Token: 0x040003EE RID: 1006
		RemoteSessionLimitExceeded,
		// Token: 0x040003EF RID: 1007
		DupDomainname,
		// Token: 0x040003F0 RID: 1008
		NoNetwork,
		// Token: 0x040003F1 RID: 1009
		Cancelled,
		// Token: 0x040003F2 RID: 1010
		UserMappedFile,
		// Token: 0x040003F3 RID: 1011
		ConnectionRefused,
		// Token: 0x040003F4 RID: 1012
		GracefulDisconnect,
		// Token: 0x040003F5 RID: 1013
		AddressAlreadyAssociated,
		// Token: 0x040003F6 RID: 1014
		AddressNotAssociated,
		// Token: 0x040003F7 RID: 1015
		ConnectionInvalid,
		// Token: 0x040003F8 RID: 1016
		ConnectionActive,
		// Token: 0x040003F9 RID: 1017
		NetworkUnreachable,
		// Token: 0x040003FA RID: 1018
		HostUnreachable,
		// Token: 0x040003FB RID: 1019
		ProtocolUnreachable,
		// Token: 0x040003FC RID: 1020
		PortUnreachable,
		// Token: 0x040003FD RID: 1021
		RequestAborted,
		// Token: 0x040003FE RID: 1022
		ConnectionAborted,
		// Token: 0x040003FF RID: 1023
		Retry,
		// Token: 0x04000400 RID: 1024
		ConnectionCountLimit,
		// Token: 0x04000401 RID: 1025
		LoginTimeRestriction,
		// Token: 0x04000402 RID: 1026
		LoginWkstaRestriction,
		// Token: 0x04000403 RID: 1027
		IncorrectAddress,
		// Token: 0x04000404 RID: 1028
		AlreadyRegistered,
		// Token: 0x04000405 RID: 1029
		ServiceNotFound,
		// Token: 0x04000406 RID: 1030
		NotAuthenticated,
		// Token: 0x04000407 RID: 1031
		NotLoggedOn,
		// Token: 0x04000408 RID: 1032
		Continue,
		// Token: 0x04000409 RID: 1033
		AlreadyInitialized,
		// Token: 0x0400040A RID: 1034
		NoMoreDevices,
		// Token: 0x0400040B RID: 1035
		NoSuchSite,
		// Token: 0x0400040C RID: 1036
		DomainControllerExists,
		// Token: 0x0400040D RID: 1037
		OnlyIfConnected,
		// Token: 0x0400040E RID: 1038
		OverrideNochanges,
		// Token: 0x0400040F RID: 1039
		BadUserProfile,
		// Token: 0x04000410 RID: 1040
		NotSupportedOnSbs,
		// Token: 0x04000411 RID: 1041
		ServerShutdownInProgress,
		// Token: 0x04000412 RID: 1042
		HostDown,
		// Token: 0x04000413 RID: 1043
		NonAccountSid,
		// Token: 0x04000414 RID: 1044
		NonDomainSid,
		// Token: 0x04000415 RID: 1045
		ApphelpBlock,
		// Token: 0x04000416 RID: 1046
		AccessDisabledByPolicy,
		// Token: 0x04000417 RID: 1047
		RegNatConsumption,
		// Token: 0x04000418 RID: 1048
		CscshareOffline,
		// Token: 0x04000419 RID: 1049
		PkinitFailure,
		// Token: 0x0400041A RID: 1050
		SmartcardSubsystemFailure,
		// Token: 0x0400041B RID: 1051
		DowngradeDetected,
		// Token: 0x0400041C RID: 1052
		MachineLocked = 1271,
		// Token: 0x0400041D RID: 1053
		SmbGuestLogonBlocked,
		// Token: 0x0400041E RID: 1054
		CallbackSuppliedInvalidData,
		// Token: 0x0400041F RID: 1055
		SyncForegroundRefreshRequired,
		// Token: 0x04000420 RID: 1056
		DriverBlocked,
		// Token: 0x04000421 RID: 1057
		InvalidImportOfNonDll,
		// Token: 0x04000422 RID: 1058
		AccessDisabledWebblade,
		// Token: 0x04000423 RID: 1059
		AccessDisabledWebbladeTamper,
		// Token: 0x04000424 RID: 1060
		RecoveryFailure,
		// Token: 0x04000425 RID: 1061
		AlreadyFiber,
		// Token: 0x04000426 RID: 1062
		AlreadyThread,
		// Token: 0x04000427 RID: 1063
		StackBufferOverrun,
		// Token: 0x04000428 RID: 1064
		ParameterQuotaExceeded,
		// Token: 0x04000429 RID: 1065
		DebuggerInactive,
		// Token: 0x0400042A RID: 1066
		DelayLoadFailed,
		// Token: 0x0400042B RID: 1067
		VdmDisallowed,
		// Token: 0x0400042C RID: 1068
		UnidentifiedError,
		// Token: 0x0400042D RID: 1069
		InvalidCruntimeParameter,
		// Token: 0x0400042E RID: 1070
		BeyondVdl,
		// Token: 0x0400042F RID: 1071
		IncompatibleServiceSidType,
		// Token: 0x04000430 RID: 1072
		DriverProcessTerminated,
		// Token: 0x04000431 RID: 1073
		ImplementationLimit,
		// Token: 0x04000432 RID: 1074
		ProcessIsProtected,
		// Token: 0x04000433 RID: 1075
		ServiceNotifyClientLagging,
		// Token: 0x04000434 RID: 1076
		DiskQuotaExceeded,
		// Token: 0x04000435 RID: 1077
		ContentBlocked,
		// Token: 0x04000436 RID: 1078
		IncompatibleServicePrivilege,
		// Token: 0x04000437 RID: 1079
		AppHang,
		// Token: 0x04000438 RID: 1080
		InvalidLabel,
		// Token: 0x04000439 RID: 1081
		NotAllAssigned,
		// Token: 0x0400043A RID: 1082
		SomeNotMapped,
		// Token: 0x0400043B RID: 1083
		NoQuotasForAccount,
		// Token: 0x0400043C RID: 1084
		LocalUserSessionKey,
		// Token: 0x0400043D RID: 1085
		NullLmPassword,
		// Token: 0x0400043E RID: 1086
		UnknownRevision,
		// Token: 0x0400043F RID: 1087
		RevisionMismatch,
		// Token: 0x04000440 RID: 1088
		InvalidOwner,
		// Token: 0x04000441 RID: 1089
		InvalidPrimaryGroup,
		// Token: 0x04000442 RID: 1090
		NoImpersonationToken,
		// Token: 0x04000443 RID: 1091
		CantDisableMandatory,
		// Token: 0x04000444 RID: 1092
		NoLogonServers,
		// Token: 0x04000445 RID: 1093
		NoSuchLogonSession,
		// Token: 0x04000446 RID: 1094
		NoSuchPrivilege,
		// Token: 0x04000447 RID: 1095
		PrivilegeNotHeld,
		// Token: 0x04000448 RID: 1096
		InvalidAccountName,
		// Token: 0x04000449 RID: 1097
		UserExists,
		// Token: 0x0400044A RID: 1098
		NoSuchUser,
		// Token: 0x0400044B RID: 1099
		GroupExists,
		// Token: 0x0400044C RID: 1100
		NoSuchGroup,
		// Token: 0x0400044D RID: 1101
		MemberInGroup,
		// Token: 0x0400044E RID: 1102
		MemberNotInGroup,
		// Token: 0x0400044F RID: 1103
		LastAdmin,
		// Token: 0x04000450 RID: 1104
		WrongPassword,
		// Token: 0x04000451 RID: 1105
		IllFormedPassword,
		// Token: 0x04000452 RID: 1106
		PasswordRestriction,
		// Token: 0x04000453 RID: 1107
		LogonFailure,
		// Token: 0x04000454 RID: 1108
		AccountRestriction,
		// Token: 0x04000455 RID: 1109
		InvalidLogonHours,
		// Token: 0x04000456 RID: 1110
		InvalidWorkstation,
		// Token: 0x04000457 RID: 1111
		PasswordExpired,
		// Token: 0x04000458 RID: 1112
		AccountDisabled,
		// Token: 0x04000459 RID: 1113
		NoneMapped,
		// Token: 0x0400045A RID: 1114
		TooManyLuidsRequested,
		// Token: 0x0400045B RID: 1115
		LuidsExhausted,
		// Token: 0x0400045C RID: 1116
		InvalidSubAuthority,
		// Token: 0x0400045D RID: 1117
		InvalidAcl,
		// Token: 0x0400045E RID: 1118
		InvalidSid,
		// Token: 0x0400045F RID: 1119
		InvalidSecurityDescr,
		// Token: 0x04000460 RID: 1120
		BadInheritanceAcl = 1340,
		// Token: 0x04000461 RID: 1121
		ServerDisabled,
		// Token: 0x04000462 RID: 1122
		ServerNotDisabled,
		// Token: 0x04000463 RID: 1123
		InvalidIdAuthority,
		// Token: 0x04000464 RID: 1124
		AllottedSpaceExceeded,
		// Token: 0x04000465 RID: 1125
		InvalidGroupAttributes,
		// Token: 0x04000466 RID: 1126
		BadImpersonationLevel,
		// Token: 0x04000467 RID: 1127
		CantOpenAnonymous,
		// Token: 0x04000468 RID: 1128
		BadValidationClass,
		// Token: 0x04000469 RID: 1129
		BadTokenType,
		// Token: 0x0400046A RID: 1130
		NoSecurityOnObject,
		// Token: 0x0400046B RID: 1131
		CantAccessDomainInfo,
		// Token: 0x0400046C RID: 1132
		InvalidServerState,
		// Token: 0x0400046D RID: 1133
		InvalidDomainState,
		// Token: 0x0400046E RID: 1134
		InvalidDomainRole,
		// Token: 0x0400046F RID: 1135
		NoSuchDomain,
		// Token: 0x04000470 RID: 1136
		DomainExists,
		// Token: 0x04000471 RID: 1137
		DomainLimitExceeded,
		// Token: 0x04000472 RID: 1138
		InternalDbCorruption,
		// Token: 0x04000473 RID: 1139
		InternalError,
		// Token: 0x04000474 RID: 1140
		GenericNotMapped,
		// Token: 0x04000475 RID: 1141
		BadDescriptorFormat,
		// Token: 0x04000476 RID: 1142
		NotLogonProcess,
		// Token: 0x04000477 RID: 1143
		LogonSessionExists,
		// Token: 0x04000478 RID: 1144
		NoSuchPackage,
		// Token: 0x04000479 RID: 1145
		BadLogonSessionState,
		// Token: 0x0400047A RID: 1146
		LogonSessionCollision,
		// Token: 0x0400047B RID: 1147
		InvalidLogonType,
		// Token: 0x0400047C RID: 1148
		CannotImpersonate,
		// Token: 0x0400047D RID: 1149
		RxactInvalidState,
		// Token: 0x0400047E RID: 1150
		RxactCommitFailure,
		// Token: 0x0400047F RID: 1151
		SpecialAccount,
		// Token: 0x04000480 RID: 1152
		SpecialGroup,
		// Token: 0x04000481 RID: 1153
		SpecialUser,
		// Token: 0x04000482 RID: 1154
		MembersPrimaryGroup,
		// Token: 0x04000483 RID: 1155
		TokenAlreadyInUse,
		// Token: 0x04000484 RID: 1156
		NoSuchAlias,
		// Token: 0x04000485 RID: 1157
		MemberNotInAlias,
		// Token: 0x04000486 RID: 1158
		MemberInAlias,
		// Token: 0x04000487 RID: 1159
		AliasExists,
		// Token: 0x04000488 RID: 1160
		LogonNotGranted,
		// Token: 0x04000489 RID: 1161
		TooManySecrets,
		// Token: 0x0400048A RID: 1162
		SecretTooLong,
		// Token: 0x0400048B RID: 1163
		InternalDbError,
		// Token: 0x0400048C RID: 1164
		TooManyContextIds,
		// Token: 0x0400048D RID: 1165
		LogonTypeNotGranted,
		// Token: 0x0400048E RID: 1166
		NtCrossEncryptionRequired,
		// Token: 0x0400048F RID: 1167
		NoSuchMember,
		// Token: 0x04000490 RID: 1168
		InvalidMember,
		// Token: 0x04000491 RID: 1169
		TooManySids,
		// Token: 0x04000492 RID: 1170
		LmCrossEncryptionRequired,
		// Token: 0x04000493 RID: 1171
		NoInheritance,
		// Token: 0x04000494 RID: 1172
		FileCorrupt,
		// Token: 0x04000495 RID: 1173
		DiskCorrupt,
		// Token: 0x04000496 RID: 1174
		NoUserSessionKey,
		// Token: 0x04000497 RID: 1175
		LicenseQuotaExceeded,
		// Token: 0x04000498 RID: 1176
		WrongTargetName,
		// Token: 0x04000499 RID: 1177
		MutualAuthFailed,
		// Token: 0x0400049A RID: 1178
		TimeSkew,
		// Token: 0x0400049B RID: 1179
		CurrentDomainNotAllowed,
		// Token: 0x0400049C RID: 1180
		InvalidWindowHandle,
		// Token: 0x0400049D RID: 1181
		InvalidMenuHandle,
		// Token: 0x0400049E RID: 1182
		InvalidCursorHandle,
		// Token: 0x0400049F RID: 1183
		InvalidAccelHandle,
		// Token: 0x040004A0 RID: 1184
		InvalidHookHandle,
		// Token: 0x040004A1 RID: 1185
		InvalidDwpHandle,
		// Token: 0x040004A2 RID: 1186
		TlwWithWschild,
		// Token: 0x040004A3 RID: 1187
		CannotFindWndClass,
		// Token: 0x040004A4 RID: 1188
		WindowOfOtherThread,
		// Token: 0x040004A5 RID: 1189
		HotkeyAlreadyRegistered,
		// Token: 0x040004A6 RID: 1190
		ClassAlreadyExists,
		// Token: 0x040004A7 RID: 1191
		ClassDoesNotExist,
		// Token: 0x040004A8 RID: 1192
		ClassHasWindows,
		// Token: 0x040004A9 RID: 1193
		InvalidIndex,
		// Token: 0x040004AA RID: 1194
		InvalidIconHandle,
		// Token: 0x040004AB RID: 1195
		PrivateDialogIndex,
		// Token: 0x040004AC RID: 1196
		ListboxIdNotFound,
		// Token: 0x040004AD RID: 1197
		NoWildcardCharacters,
		// Token: 0x040004AE RID: 1198
		ClipboardNotOpen,
		// Token: 0x040004AF RID: 1199
		HotkeyNotRegistered,
		// Token: 0x040004B0 RID: 1200
		WindowNotDialog,
		// Token: 0x040004B1 RID: 1201
		ControlIdNotFound,
		// Token: 0x040004B2 RID: 1202
		InvalidComboboxMessage,
		// Token: 0x040004B3 RID: 1203
		WindowNotCombobox,
		// Token: 0x040004B4 RID: 1204
		InvalidEditHeight,
		// Token: 0x040004B5 RID: 1205
		DcNotFound,
		// Token: 0x040004B6 RID: 1206
		InvalidHookFilter,
		// Token: 0x040004B7 RID: 1207
		InvalidFilterProc,
		// Token: 0x040004B8 RID: 1208
		HookNeedsHmod,
		// Token: 0x040004B9 RID: 1209
		GlobalOnlyHook,
		// Token: 0x040004BA RID: 1210
		JournalHookSet,
		// Token: 0x040004BB RID: 1211
		HookNotInstalled,
		// Token: 0x040004BC RID: 1212
		InvalidLbMessage,
		// Token: 0x040004BD RID: 1213
		SetcountOnBadLb,
		// Token: 0x040004BE RID: 1214
		LbWithoutTabstops,
		// Token: 0x040004BF RID: 1215
		DestroyObjectOfOtherThread,
		// Token: 0x040004C0 RID: 1216
		ChildWindowMenu,
		// Token: 0x040004C1 RID: 1217
		NoSystemMenu,
		// Token: 0x040004C2 RID: 1218
		InvalidMsgboxStyle,
		// Token: 0x040004C3 RID: 1219
		InvalidSpiValue,
		// Token: 0x040004C4 RID: 1220
		ScreenAlreadyLocked,
		// Token: 0x040004C5 RID: 1221
		HwndsHaveDiffParent,
		// Token: 0x040004C6 RID: 1222
		NotChildWindow,
		// Token: 0x040004C7 RID: 1223
		InvalidGwCommand,
		// Token: 0x040004C8 RID: 1224
		InvalidThreadId,
		// Token: 0x040004C9 RID: 1225
		NonMdichildWindow,
		// Token: 0x040004CA RID: 1226
		PopupAlreadyActive,
		// Token: 0x040004CB RID: 1227
		NoScrollbars,
		// Token: 0x040004CC RID: 1228
		InvalidScrollbarRange,
		// Token: 0x040004CD RID: 1229
		InvalidShowwinCommand,
		// Token: 0x040004CE RID: 1230
		NoSystemResources,
		// Token: 0x040004CF RID: 1231
		NonpagedSystemResources,
		// Token: 0x040004D0 RID: 1232
		PagedSystemResources,
		// Token: 0x040004D1 RID: 1233
		WorkingSetQuota,
		// Token: 0x040004D2 RID: 1234
		PagefileQuota,
		// Token: 0x040004D3 RID: 1235
		CommitmentLimit,
		// Token: 0x040004D4 RID: 1236
		MenuItemNotFound,
		// Token: 0x040004D5 RID: 1237
		InvalidKeyboardHandle,
		// Token: 0x040004D6 RID: 1238
		HookTypeNotAllowed,
		// Token: 0x040004D7 RID: 1239
		RequiresInteractiveWindowstation,
		// Token: 0x040004D8 RID: 1240
		Timeout,
		// Token: 0x040004D9 RID: 1241
		InvalidMonitorHandle,
		// Token: 0x040004DA RID: 1242
		IncorrectSize,
		// Token: 0x040004DB RID: 1243
		SymlinkClassDisabled,
		// Token: 0x040004DC RID: 1244
		SymlinkNotSupported,
		// Token: 0x040004DD RID: 1245
		XmlParseError,
		// Token: 0x040004DE RID: 1246
		XmldsigError,
		// Token: 0x040004DF RID: 1247
		RestartApplication,
		// Token: 0x040004E0 RID: 1248
		WrongCompartment,
		// Token: 0x040004E1 RID: 1249
		AuthipFailure,
		// Token: 0x040004E2 RID: 1250
		NoNvramResources,
		// Token: 0x040004E3 RID: 1251
		NotGuiProcess,
		// Token: 0x040004E4 RID: 1252
		EventlogFileCorrupt = 1500,
		// Token: 0x040004E5 RID: 1253
		EventlogCantStart,
		// Token: 0x040004E6 RID: 1254
		LogFileFull,
		// Token: 0x040004E7 RID: 1255
		EventlogFileChanged,
		// Token: 0x040004E8 RID: 1256
		ContainerAssigned,
		// Token: 0x040004E9 RID: 1257
		JobNoContainer,
		// Token: 0x040004EA RID: 1258
		InvalidTaskName = 1550,
		// Token: 0x040004EB RID: 1259
		InvalidTaskIndex,
		// Token: 0x040004EC RID: 1260
		ThreadAlreadyInTask,
		// Token: 0x040004ED RID: 1261
		InstallServiceFailure = 1601,
		// Token: 0x040004EE RID: 1262
		InstallUserexit,
		// Token: 0x040004EF RID: 1263
		InstallFailure,
		// Token: 0x040004F0 RID: 1264
		InstallSuspend,
		// Token: 0x040004F1 RID: 1265
		UnknownProduct,
		// Token: 0x040004F2 RID: 1266
		UnknownFeature,
		// Token: 0x040004F3 RID: 1267
		UnknownComponent,
		// Token: 0x040004F4 RID: 1268
		UnknownProperty,
		// Token: 0x040004F5 RID: 1269
		InvalidHandleState,
		// Token: 0x040004F6 RID: 1270
		BadConfiguration,
		// Token: 0x040004F7 RID: 1271
		IndexAbsent,
		// Token: 0x040004F8 RID: 1272
		InstallSourceAbsent,
		// Token: 0x040004F9 RID: 1273
		InstallPackageVersion,
		// Token: 0x040004FA RID: 1274
		ProductUninstalled,
		// Token: 0x040004FB RID: 1275
		BadQuerySyntax,
		// Token: 0x040004FC RID: 1276
		InvalidField,
		// Token: 0x040004FD RID: 1277
		DeviceRemoved,
		// Token: 0x040004FE RID: 1278
		InstallAlreadyRunning,
		// Token: 0x040004FF RID: 1279
		InstallPackageOpenFailed,
		// Token: 0x04000500 RID: 1280
		InstallPackageInvalid,
		// Token: 0x04000501 RID: 1281
		InstallUiFailure,
		// Token: 0x04000502 RID: 1282
		InstallLogFailure,
		// Token: 0x04000503 RID: 1283
		InstallLanguageUnsupported,
		// Token: 0x04000504 RID: 1284
		InstallTransformFailure,
		// Token: 0x04000505 RID: 1285
		InstallPackageRejected,
		// Token: 0x04000506 RID: 1286
		FunctionNotCalled,
		// Token: 0x04000507 RID: 1287
		FunctionFailed,
		// Token: 0x04000508 RID: 1288
		InvalidTable,
		// Token: 0x04000509 RID: 1289
		DatatypeMismatch,
		// Token: 0x0400050A RID: 1290
		UnsupportedType,
		// Token: 0x0400050B RID: 1291
		CreateFailed,
		// Token: 0x0400050C RID: 1292
		InstallTempUnwritable,
		// Token: 0x0400050D RID: 1293
		InstallPlatformUnsupported,
		// Token: 0x0400050E RID: 1294
		InstallNotused,
		// Token: 0x0400050F RID: 1295
		PatchPackageOpenFailed,
		// Token: 0x04000510 RID: 1296
		PatchPackageInvalid,
		// Token: 0x04000511 RID: 1297
		PatchPackageUnsupported,
		// Token: 0x04000512 RID: 1298
		ProductVersion,
		// Token: 0x04000513 RID: 1299
		InvalidCommandLine,
		// Token: 0x04000514 RID: 1300
		InstallRemoteDisallowed,
		// Token: 0x04000515 RID: 1301
		SuccessRebootInitiated,
		// Token: 0x04000516 RID: 1302
		PatchTargetNotFound,
		// Token: 0x04000517 RID: 1303
		PatchPackageRejected,
		// Token: 0x04000518 RID: 1304
		InstallTransformRejected,
		// Token: 0x04000519 RID: 1305
		InstallRemoteProhibited,
		// Token: 0x0400051A RID: 1306
		PatchRemovalUnsupported,
		// Token: 0x0400051B RID: 1307
		UnknownPatch,
		// Token: 0x0400051C RID: 1308
		PatchNoSequence,
		// Token: 0x0400051D RID: 1309
		PatchRemovalDisallowed,
		// Token: 0x0400051E RID: 1310
		InvalidPatchXml,
		// Token: 0x0400051F RID: 1311
		PatchManagedAdvertisedProduct,
		// Token: 0x04000520 RID: 1312
		InstallServiceSafeboot,
		// Token: 0x04000521 RID: 1313
		FailFastException,
		// Token: 0x04000522 RID: 1314
		InstallRejected,
		// Token: 0x04000523 RID: 1315
		DynamicCodeBlocked,
		// Token: 0x04000524 RID: 1316
		NotSameObject,
		// Token: 0x04000525 RID: 1317
		StrictCfgViolation,
		// Token: 0x04000526 RID: 1318
		SetContextDenied = 1660,
		// Token: 0x04000527 RID: 1319
		CrossPartitionViolation,
		// Token: 0x04000528 RID: 1320
		InvalidUserBuffer = 1784,
		// Token: 0x04000529 RID: 1321
		UnrecognizedMedia,
		// Token: 0x0400052A RID: 1322
		NoTrustLsaSecret,
		// Token: 0x0400052B RID: 1323
		NoTrustSamAccount,
		// Token: 0x0400052C RID: 1324
		TrustedDomainFailure,
		// Token: 0x0400052D RID: 1325
		TrustedRelationshipFailure,
		// Token: 0x0400052E RID: 1326
		TrustFailure,
		// Token: 0x0400052F RID: 1327
		NetlogonNotStarted = 1792,
		// Token: 0x04000530 RID: 1328
		AccountExpired,
		// Token: 0x04000531 RID: 1329
		RedirectorHasOpenHandles,
		// Token: 0x04000532 RID: 1330
		PrinterDriverAlreadyInstalled,
		// Token: 0x04000533 RID: 1331
		UnknownPort,
		// Token: 0x04000534 RID: 1332
		UnknownPrinterDriver,
		// Token: 0x04000535 RID: 1333
		UnknownPrintprocessor,
		// Token: 0x04000536 RID: 1334
		InvalidSeparatorFile,
		// Token: 0x04000537 RID: 1335
		InvalidPriority,
		// Token: 0x04000538 RID: 1336
		InvalidPrinterName,
		// Token: 0x04000539 RID: 1337
		PrinterAlreadyExists,
		// Token: 0x0400053A RID: 1338
		InvalidPrinterCommand,
		// Token: 0x0400053B RID: 1339
		InvalidDatatype,
		// Token: 0x0400053C RID: 1340
		InvalidEnvironment,
		// Token: 0x0400053D RID: 1341
		NologonInterdomainTrustAccount = 1807,
		// Token: 0x0400053E RID: 1342
		NologonWorkstationTrustAccount,
		// Token: 0x0400053F RID: 1343
		NologonServerTrustAccount,
		// Token: 0x04000540 RID: 1344
		DomainTrustInconsistent,
		// Token: 0x04000541 RID: 1345
		ServerHasOpenHandles,
		// Token: 0x04000542 RID: 1346
		ResourceDataNotFound,
		// Token: 0x04000543 RID: 1347
		ResourceTypeNotFound,
		// Token: 0x04000544 RID: 1348
		ResourceNameNotFound,
		// Token: 0x04000545 RID: 1349
		ResourceLangNotFound,
		// Token: 0x04000546 RID: 1350
		NotEnoughQuota,
		// Token: 0x04000547 RID: 1351
		InvalidTime = 1901,
		// Token: 0x04000548 RID: 1352
		InvalidFormName,
		// Token: 0x04000549 RID: 1353
		InvalidFormSize,
		// Token: 0x0400054A RID: 1354
		AlreadyWaiting,
		// Token: 0x0400054B RID: 1355
		PrinterDeleted,
		// Token: 0x0400054C RID: 1356
		InvalidPrinterState,
		// Token: 0x0400054D RID: 1357
		PasswordMustChange,
		// Token: 0x0400054E RID: 1358
		DomainControllerNotFound,
		// Token: 0x0400054F RID: 1359
		AccountLockedOut,
		// Token: 0x04000550 RID: 1360
		NoSitename = 1919,
		// Token: 0x04000551 RID: 1361
		CantAccessFile,
		// Token: 0x04000552 RID: 1362
		CantResolveFilename,
		// Token: 0x04000553 RID: 1363
		KmDriverBlocked = 1930,
		// Token: 0x04000554 RID: 1364
		ContextExpired,
		// Token: 0x04000555 RID: 1365
		PerUserTrustQuotaExceeded,
		// Token: 0x04000556 RID: 1366
		AllUserTrustQuotaExceeded,
		// Token: 0x04000557 RID: 1367
		UserDeleteTrustQuotaExceeded,
		// Token: 0x04000558 RID: 1368
		AuthenticationFirewallFailed,
		// Token: 0x04000559 RID: 1369
		RemotePrintConnectionsBlocked,
		// Token: 0x0400055A RID: 1370
		NtlmBlocked,
		// Token: 0x0400055B RID: 1371
		PasswordChangeRequired,
		// Token: 0x0400055C RID: 1372
		LostModeLogonRestriction,
		// Token: 0x0400055D RID: 1373
		InvalidPixelFormat = 2000,
		// Token: 0x0400055E RID: 1374
		BadDriver,
		// Token: 0x0400055F RID: 1375
		InvalidWindowStyle,
		// Token: 0x04000560 RID: 1376
		MetafileNotSupported,
		// Token: 0x04000561 RID: 1377
		TransformNotSupported,
		// Token: 0x04000562 RID: 1378
		ClippingNotSupported,
		// Token: 0x04000563 RID: 1379
		InvalidCmm = 2010,
		// Token: 0x04000564 RID: 1380
		InvalidProfile,
		// Token: 0x04000565 RID: 1381
		TagNotFound,
		// Token: 0x04000566 RID: 1382
		TagNotPresent,
		// Token: 0x04000567 RID: 1383
		DuplicateTag,
		// Token: 0x04000568 RID: 1384
		ProfileNotAssociatedWithDevice,
		// Token: 0x04000569 RID: 1385
		ProfileNotFound,
		// Token: 0x0400056A RID: 1386
		InvalidColorspace,
		// Token: 0x0400056B RID: 1387
		IcmNotEnabled,
		// Token: 0x0400056C RID: 1388
		DeletingIcmXform,
		// Token: 0x0400056D RID: 1389
		InvalidTransform,
		// Token: 0x0400056E RID: 1390
		ColorspaceMismatch,
		// Token: 0x0400056F RID: 1391
		InvalidColorindex,
		// Token: 0x04000570 RID: 1392
		ProfileDoesNotMatchDevice,
		// Token: 0x04000571 RID: 1393
		ConnectedOtherPassword = 2108,
		// Token: 0x04000572 RID: 1394
		ConnectedOtherPasswordDefault,
		// Token: 0x04000573 RID: 1395
		BadUsername = 2202,
		// Token: 0x04000574 RID: 1396
		NotConnected = 2250,
		// Token: 0x04000575 RID: 1397
		OpenFiles = 2401,
		// Token: 0x04000576 RID: 1398
		ActiveConnections,
		// Token: 0x04000577 RID: 1399
		DeviceInUse = 2404,
		// Token: 0x04000578 RID: 1400
		UnknownPrintMonitor = 3000,
		// Token: 0x04000579 RID: 1401
		PrinterDriverInUse,
		// Token: 0x0400057A RID: 1402
		SpoolFileNotFound,
		// Token: 0x0400057B RID: 1403
		SplNoStartdoc,
		// Token: 0x0400057C RID: 1404
		SplNoAddjob,
		// Token: 0x0400057D RID: 1405
		PrintProcessorAlreadyInstalled,
		// Token: 0x0400057E RID: 1406
		PrintMonitorAlreadyInstalled,
		// Token: 0x0400057F RID: 1407
		InvalidPrintMonitor,
		// Token: 0x04000580 RID: 1408
		PrintMonitorInUse,
		// Token: 0x04000581 RID: 1409
		PrinterHasJobsQueued,
		// Token: 0x04000582 RID: 1410
		SuccessRebootRequired,
		// Token: 0x04000583 RID: 1411
		SuccessRestartRequired,
		// Token: 0x04000584 RID: 1412
		PrinterNotFound,
		// Token: 0x04000585 RID: 1413
		PrinterDriverWarned,
		// Token: 0x04000586 RID: 1414
		PrinterDriverBlocked,
		// Token: 0x04000587 RID: 1415
		PrinterDriverPackageInUse,
		// Token: 0x04000588 RID: 1416
		CoreDriverPackageNotFound,
		// Token: 0x04000589 RID: 1417
		FailRebootRequired,
		// Token: 0x0400058A RID: 1418
		FailRebootInitiated,
		// Token: 0x0400058B RID: 1419
		PrinterDriverDownloadNeeded,
		// Token: 0x0400058C RID: 1420
		PrintJobRestartRequired,
		// Token: 0x0400058D RID: 1421
		InvalidPrinterDriverManifest,
		// Token: 0x0400058E RID: 1422
		PrinterNotShareable,
		// Token: 0x0400058F RID: 1423
		RequestPaused = 3050,
		// Token: 0x04000590 RID: 1424
		IoReissueAsCached = 3950,
		// Token: 0x04000591 RID: 1425
		WinsInternal = 4000,
		// Token: 0x04000592 RID: 1426
		CanNotDelLocalWins,
		// Token: 0x04000593 RID: 1427
		StaticInit,
		// Token: 0x04000594 RID: 1428
		IncBackup,
		// Token: 0x04000595 RID: 1429
		FullBackup,
		// Token: 0x04000596 RID: 1430
		RecNonExistent,
		// Token: 0x04000597 RID: 1431
		RplNotAllowed,
		// Token: 0x04000598 RID: 1432
		DhcpAddressConflict = 4100,
		// Token: 0x04000599 RID: 1433
		WmiGuidNotFound = 4200,
		// Token: 0x0400059A RID: 1434
		WmiInstanceNotFound,
		// Token: 0x0400059B RID: 1435
		WmiItemidNotFound,
		// Token: 0x0400059C RID: 1436
		WmiTryAgain,
		// Token: 0x0400059D RID: 1437
		WmiDpNotFound,
		// Token: 0x0400059E RID: 1438
		WmiUnresolvedInstanceRef,
		// Token: 0x0400059F RID: 1439
		WmiAlreadyEnabled,
		// Token: 0x040005A0 RID: 1440
		WmiGuidDisconnected,
		// Token: 0x040005A1 RID: 1441
		WmiServerUnavailable,
		// Token: 0x040005A2 RID: 1442
		WmiDpFailed,
		// Token: 0x040005A3 RID: 1443
		WmiInvalidMof,
		// Token: 0x040005A4 RID: 1444
		WmiInvalidReginfo,
		// Token: 0x040005A5 RID: 1445
		WmiAlreadyDisabled,
		// Token: 0x040005A6 RID: 1446
		WmiReadOnly,
		// Token: 0x040005A7 RID: 1447
		WmiSetFailure,
		// Token: 0x040005A8 RID: 1448
		NotAppcontainer = 4250,
		// Token: 0x040005A9 RID: 1449
		AppcontainerRequired,
		// Token: 0x040005AA RID: 1450
		NotSupportedInAppcontainer,
		// Token: 0x040005AB RID: 1451
		InvalidPackageSidLength,
		// Token: 0x040005AC RID: 1452
		InvalidMedia = 4300,
		// Token: 0x040005AD RID: 1453
		InvalidLibrary,
		// Token: 0x040005AE RID: 1454
		InvalidMediaPool,
		// Token: 0x040005AF RID: 1455
		DriveMediaMismatch,
		// Token: 0x040005B0 RID: 1456
		MediaOffline,
		// Token: 0x040005B1 RID: 1457
		LibraryOffline,
		// Token: 0x040005B2 RID: 1458
		Empty,
		// Token: 0x040005B3 RID: 1459
		NotEmpty,
		// Token: 0x040005B4 RID: 1460
		MediaUnavailable,
		// Token: 0x040005B5 RID: 1461
		ResourceDisabled,
		// Token: 0x040005B6 RID: 1462
		InvalidCleaner,
		// Token: 0x040005B7 RID: 1463
		UnableToClean,
		// Token: 0x040005B8 RID: 1464
		ObjectNotFound,
		// Token: 0x040005B9 RID: 1465
		DatabaseFailure,
		// Token: 0x040005BA RID: 1466
		DatabaseFull,
		// Token: 0x040005BB RID: 1467
		MediaIncompatible,
		// Token: 0x040005BC RID: 1468
		ResourceNotPresent,
		// Token: 0x040005BD RID: 1469
		InvalidOperation,
		// Token: 0x040005BE RID: 1470
		MediaNotAvailable,
		// Token: 0x040005BF RID: 1471
		DeviceNotAvailable,
		// Token: 0x040005C0 RID: 1472
		RequestRefused,
		// Token: 0x040005C1 RID: 1473
		InvalidDriveObject,
		// Token: 0x040005C2 RID: 1474
		LibraryFull,
		// Token: 0x040005C3 RID: 1475
		MediumNotAccessible,
		// Token: 0x040005C4 RID: 1476
		UnableToLoadMedium,
		// Token: 0x040005C5 RID: 1477
		UnableToInventoryDrive,
		// Token: 0x040005C6 RID: 1478
		UnableToInventorySlot,
		// Token: 0x040005C7 RID: 1479
		UnableToInventoryTransport,
		// Token: 0x040005C8 RID: 1480
		TransportFull,
		// Token: 0x040005C9 RID: 1481
		ControllingIeport,
		// Token: 0x040005CA RID: 1482
		UnableToEjectMountedMedia,
		// Token: 0x040005CB RID: 1483
		CleanerSlotSet,
		// Token: 0x040005CC RID: 1484
		CleanerSlotNotSet,
		// Token: 0x040005CD RID: 1485
		CleanerCartridgeSpent,
		// Token: 0x040005CE RID: 1486
		UnexpectedOmid,
		// Token: 0x040005CF RID: 1487
		CantDeleteLastItem,
		// Token: 0x040005D0 RID: 1488
		MessageExceedsMaxSize,
		// Token: 0x040005D1 RID: 1489
		VolumeContainsSysFiles,
		// Token: 0x040005D2 RID: 1490
		IndigenousType,
		// Token: 0x040005D3 RID: 1491
		NoSupportingDrives,
		// Token: 0x040005D4 RID: 1492
		CleanerCartridgeInstalled,
		// Token: 0x040005D5 RID: 1493
		IeportFull,
		// Token: 0x040005D6 RID: 1494
		FileOffline = 4350,
		// Token: 0x040005D7 RID: 1495
		RemoteStorageNotActive,
		// Token: 0x040005D8 RID: 1496
		RemoteStorageMediaError,
		// Token: 0x040005D9 RID: 1497
		NotAReparsePoint = 4390,
		// Token: 0x040005DA RID: 1498
		ReparseAttributeConflict,
		// Token: 0x040005DB RID: 1499
		InvalidReparseData,
		// Token: 0x040005DC RID: 1500
		ReparseTagInvalid,
		// Token: 0x040005DD RID: 1501
		ReparseTagMismatch,
		// Token: 0x040005DE RID: 1502
		ReparsePointEncountered,
		// Token: 0x040005DF RID: 1503
		AppDataNotFound = 4400,
		// Token: 0x040005E0 RID: 1504
		AppDataExpired,
		// Token: 0x040005E1 RID: 1505
		AppDataCorrupt,
		// Token: 0x040005E2 RID: 1506
		AppDataLimitExceeded,
		// Token: 0x040005E3 RID: 1507
		AppDataRebootRequired,
		// Token: 0x040005E4 RID: 1508
		SecurebootRollbackDetected = 4420,
		// Token: 0x040005E5 RID: 1509
		SecurebootPolicyViolation,
		// Token: 0x040005E6 RID: 1510
		SecurebootInvalidPolicy,
		// Token: 0x040005E7 RID: 1511
		SecurebootPolicyPublisherNotFound,
		// Token: 0x040005E8 RID: 1512
		SecurebootPolicyNotSigned,
		// Token: 0x040005E9 RID: 1513
		SecurebootNotEnabled,
		// Token: 0x040005EA RID: 1514
		SecurebootFileReplaced,
		// Token: 0x040005EB RID: 1515
		SecurebootPolicyNotAuthorized,
		// Token: 0x040005EC RID: 1516
		SecurebootPolicyUnknown,
		// Token: 0x040005ED RID: 1517
		SecurebootPolicyMissingAntirollbackversion,
		// Token: 0x040005EE RID: 1518
		SecurebootPlatformIdMismatch,
		// Token: 0x040005EF RID: 1519
		SecurebootPolicyRollbackDetected,
		// Token: 0x040005F0 RID: 1520
		SecurebootPolicyUpgradeMismatch,
		// Token: 0x040005F1 RID: 1521
		SecurebootRequiredPolicyFileMissing,
		// Token: 0x040005F2 RID: 1522
		SecurebootNotBasePolicy,
		// Token: 0x040005F3 RID: 1523
		SecurebootNotSupplementalPolicy,
		// Token: 0x040005F4 RID: 1524
		OffloadReadFltNotSupported = 4440,
		// Token: 0x040005F5 RID: 1525
		OffloadWriteFltNotSupported,
		// Token: 0x040005F6 RID: 1526
		OffloadReadFileNotSupported,
		// Token: 0x040005F7 RID: 1527
		OffloadWriteFileNotSupported,
		// Token: 0x040005F8 RID: 1528
		AlreadyHasStreamId,
		// Token: 0x040005F9 RID: 1529
		SmrGarbageCollectionRequired,
		// Token: 0x040005FA RID: 1530
		VolumeNotSisEnabled = 4500,
		// Token: 0x040005FB RID: 1531
		SystemIntegrityRollbackDetected = 4550,
		// Token: 0x040005FC RID: 1532
		SystemIntegrityPolicyViolation,
		// Token: 0x040005FD RID: 1533
		SystemIntegrityInvalidPolicy,
		// Token: 0x040005FE RID: 1534
		SystemIntegrityPolicyNotSigned,
		// Token: 0x040005FF RID: 1535
		VsmNotInitialized = 4560,
		// Token: 0x04000600 RID: 1536
		VsmDmaProtectionNotInUse,
		// Token: 0x04000601 RID: 1537
		PlatformManifestNotAuthorized = 4570,
		// Token: 0x04000602 RID: 1538
		PlatformManifestInvalid,
		// Token: 0x04000603 RID: 1539
		PlatformManifestFileNotAuthorized,
		// Token: 0x04000604 RID: 1540
		PlatformManifestCatalogNotAuthorized,
		// Token: 0x04000605 RID: 1541
		PlatformManifestBinaryIdNotFound,
		// Token: 0x04000606 RID: 1542
		PlatformManifestNotActive,
		// Token: 0x04000607 RID: 1543
		PlatformManifestNotSigned,
		// Token: 0x04000608 RID: 1544
		DependentResourceExists = 5001,
		// Token: 0x04000609 RID: 1545
		DependencyNotFound,
		// Token: 0x0400060A RID: 1546
		DependencyAlreadyExists,
		// Token: 0x0400060B RID: 1547
		ResourceNotOnline,
		// Token: 0x0400060C RID: 1548
		HostNodeNotAvailable,
		// Token: 0x0400060D RID: 1549
		ResourceNotAvailable,
		// Token: 0x0400060E RID: 1550
		ResourceNotFound,
		// Token: 0x0400060F RID: 1551
		ShutdownCluster,
		// Token: 0x04000610 RID: 1552
		CantEvictActiveNode,
		// Token: 0x04000611 RID: 1553
		ObjectAlreadyExists,
		// Token: 0x04000612 RID: 1554
		ObjectInList,
		// Token: 0x04000613 RID: 1555
		GroupNotAvailable,
		// Token: 0x04000614 RID: 1556
		GroupNotFound,
		// Token: 0x04000615 RID: 1557
		GroupNotOnline,
		// Token: 0x04000616 RID: 1558
		HostNodeNotResourceOwner,
		// Token: 0x04000617 RID: 1559
		HostNodeNotGroupOwner,
		// Token: 0x04000618 RID: 1560
		ResmonCreateFailed,
		// Token: 0x04000619 RID: 1561
		ResmonOnlineFailed,
		// Token: 0x0400061A RID: 1562
		ResourceOnline,
		// Token: 0x0400061B RID: 1563
		QuorumResource,
		// Token: 0x0400061C RID: 1564
		NotQuorumCapable,
		// Token: 0x0400061D RID: 1565
		ClusterShuttingDown,
		// Token: 0x0400061E RID: 1566
		InvalidState,
		// Token: 0x0400061F RID: 1567
		ResourcePropertiesStored,
		// Token: 0x04000620 RID: 1568
		NotQuorumClass,
		// Token: 0x04000621 RID: 1569
		CoreResource,
		// Token: 0x04000622 RID: 1570
		QuorumResourceOnlineFailed,
		// Token: 0x04000623 RID: 1571
		QuorumlogOpenFailed,
		// Token: 0x04000624 RID: 1572
		ClusterlogCorrupt,
		// Token: 0x04000625 RID: 1573
		ClusterlogRecordExceedsMaxsize,
		// Token: 0x04000626 RID: 1574
		ClusterlogExceedsMaxsize,
		// Token: 0x04000627 RID: 1575
		ClusterlogChkpointNotFound,
		// Token: 0x04000628 RID: 1576
		ClusterlogNotEnoughSpace,
		// Token: 0x04000629 RID: 1577
		QuorumOwnerAlive,
		// Token: 0x0400062A RID: 1578
		NetworkNotAvailable,
		// Token: 0x0400062B RID: 1579
		NodeNotAvailable,
		// Token: 0x0400062C RID: 1580
		AllNodesNotAvailable,
		// Token: 0x0400062D RID: 1581
		ResourceFailed,
		// Token: 0x0400062E RID: 1582
		ClusterInvalidNode,
		// Token: 0x0400062F RID: 1583
		ClusterNodeExists,
		// Token: 0x04000630 RID: 1584
		ClusterJoinInProgress,
		// Token: 0x04000631 RID: 1585
		ClusterNodeNotFound,
		// Token: 0x04000632 RID: 1586
		ClusterLocalNodeNotFound,
		// Token: 0x04000633 RID: 1587
		ClusterNetworkExists,
		// Token: 0x04000634 RID: 1588
		ClusterNetworkNotFound,
		// Token: 0x04000635 RID: 1589
		ClusterNetinterfaceExists,
		// Token: 0x04000636 RID: 1590
		ClusterNetinterfaceNotFound,
		// Token: 0x04000637 RID: 1591
		ClusterInvalidRequest,
		// Token: 0x04000638 RID: 1592
		ClusterInvalidNetworkProvider,
		// Token: 0x04000639 RID: 1593
		ClusterNodeDown,
		// Token: 0x0400063A RID: 1594
		ClusterNodeUnreachable,
		// Token: 0x0400063B RID: 1595
		ClusterNodeNotMember,
		// Token: 0x0400063C RID: 1596
		ClusterJoinNotInProgress,
		// Token: 0x0400063D RID: 1597
		ClusterInvalidNetwork,
		// Token: 0x0400063E RID: 1598
		ClusterNodeUp = 5056,
		// Token: 0x0400063F RID: 1599
		ClusterIpaddrInUse,
		// Token: 0x04000640 RID: 1600
		ClusterNodeNotPaused,
		// Token: 0x04000641 RID: 1601
		ClusterNoSecurityContext,
		// Token: 0x04000642 RID: 1602
		ClusterNetworkNotInternal,
		// Token: 0x04000643 RID: 1603
		ClusterNodeAlreadyUp,
		// Token: 0x04000644 RID: 1604
		ClusterNodeAlreadyDown,
		// Token: 0x04000645 RID: 1605
		ClusterNetworkAlreadyOnline,
		// Token: 0x04000646 RID: 1606
		ClusterNetworkAlreadyOffline,
		// Token: 0x04000647 RID: 1607
		ClusterNodeAlreadyMember,
		// Token: 0x04000648 RID: 1608
		ClusterLastInternalNetwork,
		// Token: 0x04000649 RID: 1609
		ClusterNetworkHasDependents,
		// Token: 0x0400064A RID: 1610
		InvalidOperationOnQuorum,
		// Token: 0x0400064B RID: 1611
		DependencyNotAllowed,
		// Token: 0x0400064C RID: 1612
		ClusterNodePaused,
		// Token: 0x0400064D RID: 1613
		NodeCantHostResource,
		// Token: 0x0400064E RID: 1614
		ClusterNodeNotReady,
		// Token: 0x0400064F RID: 1615
		ClusterNodeShuttingDown,
		// Token: 0x04000650 RID: 1616
		ClusterJoinAborted,
		// Token: 0x04000651 RID: 1617
		ClusterIncompatibleVersions,
		// Token: 0x04000652 RID: 1618
		ClusterMaxnumOfResourcesExceeded,
		// Token: 0x04000653 RID: 1619
		ClusterSystemConfigChanged,
		// Token: 0x04000654 RID: 1620
		ClusterResourceTypeNotFound,
		// Token: 0x04000655 RID: 1621
		ClusterRestypeNotSupported,
		// Token: 0x04000656 RID: 1622
		ClusterResnameNotFound,
		// Token: 0x04000657 RID: 1623
		ClusterNoRpcPackagesRegistered,
		// Token: 0x04000658 RID: 1624
		ClusterOwnerNotInPreflist,
		// Token: 0x04000659 RID: 1625
		ClusterDatabaseSeqmismatch,
		// Token: 0x0400065A RID: 1626
		ResmonInvalidState,
		// Token: 0x0400065B RID: 1627
		ClusterGumNotLocker,
		// Token: 0x0400065C RID: 1628
		QuorumDiskNotFound,
		// Token: 0x0400065D RID: 1629
		DatabaseBackupCorrupt,
		// Token: 0x0400065E RID: 1630
		ClusterNodeAlreadyHasDfsRoot,
		// Token: 0x0400065F RID: 1631
		ResourcePropertyUnchangeable,
		// Token: 0x04000660 RID: 1632
		NoAdminAccessPoint,
		// Token: 0x04000661 RID: 1633
		ClusterMembershipInvalidState = 5890,
		// Token: 0x04000662 RID: 1634
		ClusterQuorumlogNotFound,
		// Token: 0x04000663 RID: 1635
		ClusterMembershipHalt,
		// Token: 0x04000664 RID: 1636
		ClusterInstanceIdMismatch,
		// Token: 0x04000665 RID: 1637
		ClusterNetworkNotFoundForIp,
		// Token: 0x04000666 RID: 1638
		ClusterPropertyDataTypeMismatch,
		// Token: 0x04000667 RID: 1639
		ClusterEvictWithoutCleanup,
		// Token: 0x04000668 RID: 1640
		ClusterParameterMismatch,
		// Token: 0x04000669 RID: 1641
		NodeCannotBeClustered,
		// Token: 0x0400066A RID: 1642
		ClusterWrongOsVersion,
		// Token: 0x0400066B RID: 1643
		ClusterCantCreateDupClusterName,
		// Token: 0x0400066C RID: 1644
		CluscfgAlreadyCommitted,
		// Token: 0x0400066D RID: 1645
		CluscfgRollbackFailed,
		// Token: 0x0400066E RID: 1646
		CluscfgSystemDiskDriveLetterConflict,
		// Token: 0x0400066F RID: 1647
		ClusterOldVersion,
		// Token: 0x04000670 RID: 1648
		ClusterMismatchedComputerAcctName,
		// Token: 0x04000671 RID: 1649
		ClusterNoNetAdapters,
		// Token: 0x04000672 RID: 1650
		ClusterPoisoned,
		// Token: 0x04000673 RID: 1651
		ClusterGroupMoving,
		// Token: 0x04000674 RID: 1652
		ClusterResourceTypeBusy,
		// Token: 0x04000675 RID: 1653
		ResourceCallTimedOut,
		// Token: 0x04000676 RID: 1654
		InvalidClusterIpv6Address,
		// Token: 0x04000677 RID: 1655
		ClusterInternalInvalidFunction,
		// Token: 0x04000678 RID: 1656
		ClusterParameterOutOfBounds,
		// Token: 0x04000679 RID: 1657
		ClusterPartialSend,
		// Token: 0x0400067A RID: 1658
		ClusterRegistryInvalidFunction,
		// Token: 0x0400067B RID: 1659
		ClusterInvalidStringTermination,
		// Token: 0x0400067C RID: 1660
		ClusterInvalidStringFormat,
		// Token: 0x0400067D RID: 1661
		ClusterDatabaseTransactionInProgress,
		// Token: 0x0400067E RID: 1662
		ClusterDatabaseTransactionNotInProgress,
		// Token: 0x0400067F RID: 1663
		ClusterNullData,
		// Token: 0x04000680 RID: 1664
		ClusterPartialRead,
		// Token: 0x04000681 RID: 1665
		ClusterPartialWrite,
		// Token: 0x04000682 RID: 1666
		ClusterCantDeserializeData,
		// Token: 0x04000683 RID: 1667
		DependentResourcePropertyConflict,
		// Token: 0x04000684 RID: 1668
		ClusterNoQuorum,
		// Token: 0x04000685 RID: 1669
		ClusterInvalidIpv6Network,
		// Token: 0x04000686 RID: 1670
		ClusterInvalidIpv6TunnelNetwork,
		// Token: 0x04000687 RID: 1671
		QuorumNotAllowedInThisGroup,
		// Token: 0x04000688 RID: 1672
		DependencyTreeTooComplex,
		// Token: 0x04000689 RID: 1673
		ExceptionInResourceCall,
		// Token: 0x0400068A RID: 1674
		ClusterRhsFailedInitialization,
		// Token: 0x0400068B RID: 1675
		ClusterNotInstalled,
		// Token: 0x0400068C RID: 1676
		ClusterResourcesMustBeOnlineOnTheSameNode,
		// Token: 0x0400068D RID: 1677
		ClusterMaxNodesInCluster,
		// Token: 0x0400068E RID: 1678
		ClusterTooManyNodes,
		// Token: 0x0400068F RID: 1679
		ClusterObjectAlreadyUsed,
		// Token: 0x04000690 RID: 1680
		NoncoreGroupsFound,
		// Token: 0x04000691 RID: 1681
		FileShareResourceConflict,
		// Token: 0x04000692 RID: 1682
		ClusterEvictInvalidRequest,
		// Token: 0x04000693 RID: 1683
		ClusterSingletonResource,
		// Token: 0x04000694 RID: 1684
		ClusterGroupSingletonResource,
		// Token: 0x04000695 RID: 1685
		ClusterResourceProviderFailed,
		// Token: 0x04000696 RID: 1686
		ClusterResourceConfigurationError,
		// Token: 0x04000697 RID: 1687
		ClusterGroupBusy,
		// Token: 0x04000698 RID: 1688
		ClusterNotSharedVolume,
		// Token: 0x04000699 RID: 1689
		ClusterInvalidSecurityDescriptor,
		// Token: 0x0400069A RID: 1690
		ClusterSharedVolumesInUse,
		// Token: 0x0400069B RID: 1691
		ClusterUseSharedVolumesApi,
		// Token: 0x0400069C RID: 1692
		ClusterBackupInProgress,
		// Token: 0x0400069D RID: 1693
		NonCsvPath,
		// Token: 0x0400069E RID: 1694
		CsvVolumeNotLocal,
		// Token: 0x0400069F RID: 1695
		ClusterWatchdogTerminating,
		// Token: 0x040006A0 RID: 1696
		ClusterResourceVetoedMoveIncompatibleNodes,
		// Token: 0x040006A1 RID: 1697
		ClusterInvalidNodeWeight,
		// Token: 0x040006A2 RID: 1698
		ClusterResourceVetoedCall,
		// Token: 0x040006A3 RID: 1699
		ResmonSystemResourcesLacking,
		// Token: 0x040006A4 RID: 1700
		ClusterResourceVetoedMoveNotEnoughResourcesOnDestination,
		// Token: 0x040006A5 RID: 1701
		ClusterResourceVetoedMoveNotEnoughResourcesOnSource,
		// Token: 0x040006A6 RID: 1702
		ClusterGroupQueued,
		// Token: 0x040006A7 RID: 1703
		ClusterResourceLockedStatus,
		// Token: 0x040006A8 RID: 1704
		ClusterSharedVolumeFailoverNotAllowed,
		// Token: 0x040006A9 RID: 1705
		ClusterNodeDrainInProgress,
		// Token: 0x040006AA RID: 1706
		ClusterDiskNotConnected,
		// Token: 0x040006AB RID: 1707
		DiskNotCsvCapable,
		// Token: 0x040006AC RID: 1708
		ResourceNotInAvailableStorage,
		// Token: 0x040006AD RID: 1709
		ClusterSharedVolumeRedirected,
		// Token: 0x040006AE RID: 1710
		ClusterSharedVolumeNotRedirected,
		// Token: 0x040006AF RID: 1711
		ClusterCannotReturnProperties,
		// Token: 0x040006B0 RID: 1712
		ClusterResourceContainsUnsupportedDiffAreaForSharedVolumes,
		// Token: 0x040006B1 RID: 1713
		ClusterResourceIsInMaintenanceMode,
		// Token: 0x040006B2 RID: 1714
		ClusterAffinityConflict,
		// Token: 0x040006B3 RID: 1715
		ClusterResourceIsReplicaVirtualMachine,
		// Token: 0x040006B4 RID: 1716
		ClusterUpgradeIncompatibleVersions,
		// Token: 0x040006B5 RID: 1717
		ClusterUpgradeFixQuorumNotSupported,
		// Token: 0x040006B6 RID: 1718
		ClusterUpgradeRestartRequired,
		// Token: 0x040006B7 RID: 1719
		ClusterUpgradeInProgress,
		// Token: 0x040006B8 RID: 1720
		ClusterUpgradeIncomplete,
		// Token: 0x040006B9 RID: 1721
		ClusterNodeInGracePeriod,
		// Token: 0x040006BA RID: 1722
		ClusterCsvIoPauseTimeout,
		// Token: 0x040006BB RID: 1723
		NodeNotActiveClusterMember,
		// Token: 0x040006BC RID: 1724
		ClusterResourceNotMonitored,
		// Token: 0x040006BD RID: 1725
		ClusterResourceDoesNotSupportUnmonitored,
		// Token: 0x040006BE RID: 1726
		ClusterResourceIsReplicated,
		// Token: 0x040006BF RID: 1727
		ClusterNodeIsolated,
		// Token: 0x040006C0 RID: 1728
		ClusterNodeQuarantined,
		// Token: 0x040006C1 RID: 1729
		ClusterDatabaseUpdateConditionFailed,
		// Token: 0x040006C2 RID: 1730
		ClusterSpaceDegraded,
		// Token: 0x040006C3 RID: 1731
		ClusterTokenDelegationNotSupported,
		// Token: 0x040006C4 RID: 1732
		ClusterCsvInvalidHandle,
		// Token: 0x040006C5 RID: 1733
		ClusterCsvSupportedOnlyOnCoordinator,
		// Token: 0x040006C6 RID: 1734
		GroupsetNotAvailable,
		// Token: 0x040006C7 RID: 1735
		GroupsetNotFound,
		// Token: 0x040006C8 RID: 1736
		GroupsetCantProvide,
		// Token: 0x040006C9 RID: 1737
		ClusterFaultDomainParentNotFound,
		// Token: 0x040006CA RID: 1738
		ClusterFaultDomainInvalidHierarchy,
		// Token: 0x040006CB RID: 1739
		ClusterFaultDomainFailedS2DValidation,
		// Token: 0x040006CC RID: 1740
		ClusterFaultDomainS2DConnectivityLoss,
		// Token: 0x040006CD RID: 1741
		ClusterInvalidInfrastructureFileserverName,
		// Token: 0x040006CE RID: 1742
		ClustersetManagementClusterUnreachable,
		// Token: 0x040006CF RID: 1743
		EncryptionFailed,
		// Token: 0x040006D0 RID: 1744
		DecryptionFailed,
		// Token: 0x040006D1 RID: 1745
		FileEncrypted,
		// Token: 0x040006D2 RID: 1746
		NoRecoveryPolicy,
		// Token: 0x040006D3 RID: 1747
		NoEfs,
		// Token: 0x040006D4 RID: 1748
		WrongEfs,
		// Token: 0x040006D5 RID: 1749
		NoUserKeys,
		// Token: 0x040006D6 RID: 1750
		FileNotEncrypted,
		// Token: 0x040006D7 RID: 1751
		NotExportFormat,
		// Token: 0x040006D8 RID: 1752
		FileReadOnly,
		// Token: 0x040006D9 RID: 1753
		DirEfsDisallowed,
		// Token: 0x040006DA RID: 1754
		EfsServerNotTrusted,
		// Token: 0x040006DB RID: 1755
		BadRecoveryPolicy,
		// Token: 0x040006DC RID: 1756
		EfsAlgBlobTooBig,
		// Token: 0x040006DD RID: 1757
		VolumeNotSupportEfs,
		// Token: 0x040006DE RID: 1758
		EfsDisabled,
		// Token: 0x040006DF RID: 1759
		EfsVersionNotSupport,
		// Token: 0x040006E0 RID: 1760
		CsEncryptionInvalidServerResponse,
		// Token: 0x040006E1 RID: 1761
		CsEncryptionUnsupportedServer,
		// Token: 0x040006E2 RID: 1762
		CsEncryptionExistingEncryptedFile,
		// Token: 0x040006E3 RID: 1763
		CsEncryptionNewEncryptedFile,
		// Token: 0x040006E4 RID: 1764
		CsEncryptionFileNotCse,
		// Token: 0x040006E5 RID: 1765
		EncryptionPolicyDeniesOperation,
		// Token: 0x040006E6 RID: 1766
		NoBrowserServersFound = 6118,
		// Token: 0x040006E7 RID: 1767
		LogSectorInvalid = 6600,
		// Token: 0x040006E8 RID: 1768
		LogSectorParityInvalid,
		// Token: 0x040006E9 RID: 1769
		LogSectorRemapped,
		// Token: 0x040006EA RID: 1770
		LogBlockIncomplete,
		// Token: 0x040006EB RID: 1771
		LogInvalidRange,
		// Token: 0x040006EC RID: 1772
		LogBlocksExhausted,
		// Token: 0x040006ED RID: 1773
		LogReadContextInvalid,
		// Token: 0x040006EE RID: 1774
		LogRestartInvalid,
		// Token: 0x040006EF RID: 1775
		LogBlockVersion,
		// Token: 0x040006F0 RID: 1776
		LogBlockInvalid,
		// Token: 0x040006F1 RID: 1777
		LogReadModeInvalid,
		// Token: 0x040006F2 RID: 1778
		LogNoRestart,
		// Token: 0x040006F3 RID: 1779
		LogMetadataCorrupt,
		// Token: 0x040006F4 RID: 1780
		LogMetadataInvalid,
		// Token: 0x040006F5 RID: 1781
		LogMetadataInconsistent,
		// Token: 0x040006F6 RID: 1782
		LogReservationInvalid,
		// Token: 0x040006F7 RID: 1783
		LogCantDelete,
		// Token: 0x040006F8 RID: 1784
		LogContainerLimitExceeded,
		// Token: 0x040006F9 RID: 1785
		LogStartOfLog,
		// Token: 0x040006FA RID: 1786
		LogPolicyAlreadyInstalled,
		// Token: 0x040006FB RID: 1787
		LogPolicyNotInstalled,
		// Token: 0x040006FC RID: 1788
		LogPolicyInvalid,
		// Token: 0x040006FD RID: 1789
		LogPolicyConflict,
		// Token: 0x040006FE RID: 1790
		LogPinnedArchiveTail,
		// Token: 0x040006FF RID: 1791
		LogRecordNonexistent,
		// Token: 0x04000700 RID: 1792
		LogRecordsReservedInvalid,
		// Token: 0x04000701 RID: 1793
		LogSpaceReservedInvalid,
		// Token: 0x04000702 RID: 1794
		LogTailInvalid,
		// Token: 0x04000703 RID: 1795
		LogFull,
		// Token: 0x04000704 RID: 1796
		CouldNotResizeLog,
		// Token: 0x04000705 RID: 1797
		LogMultiplexed,
		// Token: 0x04000706 RID: 1798
		LogDedicated,
		// Token: 0x04000707 RID: 1799
		LogArchiveNotInProgress,
		// Token: 0x04000708 RID: 1800
		LogArchiveInProgress,
		// Token: 0x04000709 RID: 1801
		LogEphemeral,
		// Token: 0x0400070A RID: 1802
		LogNotEnoughContainers,
		// Token: 0x0400070B RID: 1803
		LogClientAlreadyRegistered,
		// Token: 0x0400070C RID: 1804
		LogClientNotRegistered,
		// Token: 0x0400070D RID: 1805
		LogFullHandlerInProgress,
		// Token: 0x0400070E RID: 1806
		LogContainerReadFailed,
		// Token: 0x0400070F RID: 1807
		LogContainerWriteFailed,
		// Token: 0x04000710 RID: 1808
		LogContainerOpenFailed,
		// Token: 0x04000711 RID: 1809
		LogContainerStateInvalid,
		// Token: 0x04000712 RID: 1810
		LogStateInvalid,
		// Token: 0x04000713 RID: 1811
		LogPinned,
		// Token: 0x04000714 RID: 1812
		LogMetadataFlushFailed,
		// Token: 0x04000715 RID: 1813
		LogInconsistentSecurity,
		// Token: 0x04000716 RID: 1814
		LogAppendedFlushFailed,
		// Token: 0x04000717 RID: 1815
		LogPinnedReservation,
		// Token: 0x04000718 RID: 1816
		InvalidTransaction = 6700,
		// Token: 0x04000719 RID: 1817
		TransactionNotActive,
		// Token: 0x0400071A RID: 1818
		TransactionRequestNotValid,
		// Token: 0x0400071B RID: 1819
		TransactionNotRequested,
		// Token: 0x0400071C RID: 1820
		TransactionAlreadyAborted,
		// Token: 0x0400071D RID: 1821
		TransactionAlreadyCommitted,
		// Token: 0x0400071E RID: 1822
		TmInitializationFailed,
		// Token: 0x0400071F RID: 1823
		ResourcemanagerReadOnly,
		// Token: 0x04000720 RID: 1824
		TransactionNotJoined,
		// Token: 0x04000721 RID: 1825
		TransactionSuperiorExists,
		// Token: 0x04000722 RID: 1826
		CrmProtocolAlreadyExists,
		// Token: 0x04000723 RID: 1827
		TransactionPropagationFailed,
		// Token: 0x04000724 RID: 1828
		CrmProtocolNotFound,
		// Token: 0x04000725 RID: 1829
		TransactionInvalidMarshallBuffer,
		// Token: 0x04000726 RID: 1830
		CurrentTransactionNotValid,
		// Token: 0x04000727 RID: 1831
		TransactionNotFound,
		// Token: 0x04000728 RID: 1832
		ResourcemanagerNotFound,
		// Token: 0x04000729 RID: 1833
		EnlistmentNotFound,
		// Token: 0x0400072A RID: 1834
		TransactionmanagerNotFound,
		// Token: 0x0400072B RID: 1835
		TransactionmanagerNotOnline,
		// Token: 0x0400072C RID: 1836
		TransactionmanagerRecoveryNameCollision,
		// Token: 0x0400072D RID: 1837
		TransactionNotRoot,
		// Token: 0x0400072E RID: 1838
		TransactionObjectExpired,
		// Token: 0x0400072F RID: 1839
		TransactionResponseNotEnlisted,
		// Token: 0x04000730 RID: 1840
		TransactionRecordTooLong,
		// Token: 0x04000731 RID: 1841
		ImplicitTransactionNotSupported,
		// Token: 0x04000732 RID: 1842
		TransactionIntegrityViolated,
		// Token: 0x04000733 RID: 1843
		TransactionmanagerIdentityMismatch,
		// Token: 0x04000734 RID: 1844
		RmCannotBeFrozenForSnapshot,
		// Token: 0x04000735 RID: 1845
		TransactionMustWritethrough,
		// Token: 0x04000736 RID: 1846
		TransactionNoSuperior,
		// Token: 0x04000737 RID: 1847
		HeuristicDamagePossible,
		// Token: 0x04000738 RID: 1848
		TransactionalConflict = 6800,
		// Token: 0x04000739 RID: 1849
		RmNotActive,
		// Token: 0x0400073A RID: 1850
		RmMetadataCorrupt,
		// Token: 0x0400073B RID: 1851
		DirectoryNotRm,
		// Token: 0x0400073C RID: 1852
		TransactionsUnsupportedRemote = 6805,
		// Token: 0x0400073D RID: 1853
		LogResizeInvalidSize,
		// Token: 0x0400073E RID: 1854
		ObjectNoLongerExists,
		// Token: 0x0400073F RID: 1855
		StreamMiniversionNotFound,
		// Token: 0x04000740 RID: 1856
		StreamMiniversionNotValid,
		// Token: 0x04000741 RID: 1857
		MiniversionInaccessibleFromSpecifiedTransaction,
		// Token: 0x04000742 RID: 1858
		CantOpenMiniversionWithModifyIntent,
		// Token: 0x04000743 RID: 1859
		CantCreateMoreStreamMiniversions,
		// Token: 0x04000744 RID: 1860
		RemoteFileVersionMismatch = 6814,
		// Token: 0x04000745 RID: 1861
		HandleNoLongerValid,
		// Token: 0x04000746 RID: 1862
		NoTxfMetadata,
		// Token: 0x04000747 RID: 1863
		LogCorruptionDetected,
		// Token: 0x04000748 RID: 1864
		CantRecoverWithHandleOpen,
		// Token: 0x04000749 RID: 1865
		RmDisconnected,
		// Token: 0x0400074A RID: 1866
		EnlistmentNotSuperior,
		// Token: 0x0400074B RID: 1867
		RecoveryNotNeeded,
		// Token: 0x0400074C RID: 1868
		RmAlreadyStarted,
		// Token: 0x0400074D RID: 1869
		FileIdentityNotPersistent,
		// Token: 0x0400074E RID: 1870
		CantBreakTransactionalDependency,
		// Token: 0x0400074F RID: 1871
		CantCrossRmBoundary,
		// Token: 0x04000750 RID: 1872
		TxfDirNotEmpty,
		// Token: 0x04000751 RID: 1873
		IndoubtTransactionsExist,
		// Token: 0x04000752 RID: 1874
		TmVolatile,
		// Token: 0x04000753 RID: 1875
		RollbackTimerExpired,
		// Token: 0x04000754 RID: 1876
		TxfAttributeCorrupt,
		// Token: 0x04000755 RID: 1877
		EfsNotAllowedInTransaction,
		// Token: 0x04000756 RID: 1878
		TransactionalOpenNotAllowed,
		// Token: 0x04000757 RID: 1879
		LogGrowthFailed,
		// Token: 0x04000758 RID: 1880
		TransactedMappingUnsupportedRemote,
		// Token: 0x04000759 RID: 1881
		TxfMetadataAlreadyPresent,
		// Token: 0x0400075A RID: 1882
		TransactionScopeCallbacksNotSet,
		// Token: 0x0400075B RID: 1883
		TransactionRequiredPromotion,
		// Token: 0x0400075C RID: 1884
		CannotExecuteFileInTransaction,
		// Token: 0x0400075D RID: 1885
		TransactionsNotFrozen,
		// Token: 0x0400075E RID: 1886
		TransactionFreezeInProgress,
		// Token: 0x0400075F RID: 1887
		NotSnapshotVolume,
		// Token: 0x04000760 RID: 1888
		NoSavepointWithOpenFiles,
		// Token: 0x04000761 RID: 1889
		DataLostRepair,
		// Token: 0x04000762 RID: 1890
		SparseNotAllowedInTransaction,
		// Token: 0x04000763 RID: 1891
		TmIdentityMismatch,
		// Token: 0x04000764 RID: 1892
		FloatedSection,
		// Token: 0x04000765 RID: 1893
		CannotAcceptTransactedWork,
		// Token: 0x04000766 RID: 1894
		CannotAbortTransactions,
		// Token: 0x04000767 RID: 1895
		BadClusters,
		// Token: 0x04000768 RID: 1896
		CompressionNotAllowedInTransaction,
		// Token: 0x04000769 RID: 1897
		VolumeDirty,
		// Token: 0x0400076A RID: 1898
		NoLinkTrackingInTransaction,
		// Token: 0x0400076B RID: 1899
		OperationNotSupportedInTransaction,
		// Token: 0x0400076C RID: 1900
		ExpiredHandle,
		// Token: 0x0400076D RID: 1901
		TransactionNotEnlisted,
		// Token: 0x0400076E RID: 1902
		CtxWinstationNameInvalid = 7001,
		// Token: 0x0400076F RID: 1903
		CtxInvalidPd,
		// Token: 0x04000770 RID: 1904
		CtxPdNotFound,
		// Token: 0x04000771 RID: 1905
		CtxWdNotFound,
		// Token: 0x04000772 RID: 1906
		CtxCannotMakeEventlogEntry,
		// Token: 0x04000773 RID: 1907
		CtxServiceNameCollision,
		// Token: 0x04000774 RID: 1908
		CtxClosePending,
		// Token: 0x04000775 RID: 1909
		CtxNoOutbuf,
		// Token: 0x04000776 RID: 1910
		CtxModemInfNotFound,
		// Token: 0x04000777 RID: 1911
		CtxInvalidModemname,
		// Token: 0x04000778 RID: 1912
		CtxModemResponseError,
		// Token: 0x04000779 RID: 1913
		CtxModemResponseTimeout,
		// Token: 0x0400077A RID: 1914
		CtxModemResponseNoCarrier,
		// Token: 0x0400077B RID: 1915
		CtxModemResponseNoDialtone,
		// Token: 0x0400077C RID: 1916
		CtxModemResponseBusy,
		// Token: 0x0400077D RID: 1917
		CtxModemResponseVoice,
		// Token: 0x0400077E RID: 1918
		CtxTdError,
		// Token: 0x0400077F RID: 1919
		CtxWinstationNotFound = 7022,
		// Token: 0x04000780 RID: 1920
		CtxWinstationAlreadyExists,
		// Token: 0x04000781 RID: 1921
		CtxWinstationBusy,
		// Token: 0x04000782 RID: 1922
		CtxBadVideoMode,
		// Token: 0x04000783 RID: 1923
		CtxGraphicsInvalid = 7035,
		// Token: 0x04000784 RID: 1924
		CtxLogonDisabled = 7037,
		// Token: 0x04000785 RID: 1925
		CtxNotConsole,
		// Token: 0x04000786 RID: 1926
		CtxClientQueryTimeout = 7040,
		// Token: 0x04000787 RID: 1927
		CtxConsoleDisconnect,
		// Token: 0x04000788 RID: 1928
		CtxConsoleConnect,
		// Token: 0x04000789 RID: 1929
		CtxShadowDenied = 7044,
		// Token: 0x0400078A RID: 1930
		CtxWinstationAccessDenied,
		// Token: 0x0400078B RID: 1931
		CtxInvalidWd = 7049,
		// Token: 0x0400078C RID: 1932
		CtxShadowInvalid,
		// Token: 0x0400078D RID: 1933
		CtxShadowDisabled,
		// Token: 0x0400078E RID: 1934
		CtxClientLicenseInUse,
		// Token: 0x0400078F RID: 1935
		CtxClientLicenseNotSet,
		// Token: 0x04000790 RID: 1936
		CtxLicenseNotAvailable,
		// Token: 0x04000791 RID: 1937
		CtxLicenseClientInvalid,
		// Token: 0x04000792 RID: 1938
		CtxLicenseExpired,
		// Token: 0x04000793 RID: 1939
		CtxShadowNotRunning,
		// Token: 0x04000794 RID: 1940
		CtxShadowEndedByModeChange,
		// Token: 0x04000795 RID: 1941
		ActivationCountExceeded,
		// Token: 0x04000796 RID: 1942
		CtxWinstationsDisabled,
		// Token: 0x04000797 RID: 1943
		CtxEncryptionLevelRequired,
		// Token: 0x04000798 RID: 1944
		CtxSessionInUse,
		// Token: 0x04000799 RID: 1945
		CtxNoForceLogoff,
		// Token: 0x0400079A RID: 1946
		CtxAccountRestriction,
		// Token: 0x0400079B RID: 1947
		RdpProtocolError,
		// Token: 0x0400079C RID: 1948
		CtxCdmConnect,
		// Token: 0x0400079D RID: 1949
		CtxCdmDisconnect,
		// Token: 0x0400079E RID: 1950
		CtxSecurityLayerError,
		// Token: 0x0400079F RID: 1951
		TsIncompatibleSessions,
		// Token: 0x040007A0 RID: 1952
		TsVideoSubsystemError,
		// Token: 0x040007A1 RID: 1953
		DsNotInstalled = 8200,
		// Token: 0x040007A2 RID: 1954
		DsMembershipEvaluatedLocally,
		// Token: 0x040007A3 RID: 1955
		DsNoAttributeOrValue,
		// Token: 0x040007A4 RID: 1956
		DsInvalidAttributeSyntax,
		// Token: 0x040007A5 RID: 1957
		DsAttributeTypeUndefined,
		// Token: 0x040007A6 RID: 1958
		DsAttributeOrValueExists,
		// Token: 0x040007A7 RID: 1959
		DsBusy,
		// Token: 0x040007A8 RID: 1960
		DsUnavailable,
		// Token: 0x040007A9 RID: 1961
		DsNoRidsAllocated,
		// Token: 0x040007AA RID: 1962
		DsNoMoreRids,
		// Token: 0x040007AB RID: 1963
		DsIncorrectRoleOwner,
		// Token: 0x040007AC RID: 1964
		DsRidmgrInitError,
		// Token: 0x040007AD RID: 1965
		DsObjClassViolation,
		// Token: 0x040007AE RID: 1966
		DsCantOnNonLeaf,
		// Token: 0x040007AF RID: 1967
		DsCantOnRdn,
		// Token: 0x040007B0 RID: 1968
		DsCantModObjClass,
		// Token: 0x040007B1 RID: 1969
		DsCrossDomMoveError,
		// Token: 0x040007B2 RID: 1970
		DsGcNotAvailable,
		// Token: 0x040007B3 RID: 1971
		SharedPolicy,
		// Token: 0x040007B4 RID: 1972
		PolicyObjectNotFound,
		// Token: 0x040007B5 RID: 1973
		PolicyOnlyInDs,
		// Token: 0x040007B6 RID: 1974
		PromotionActive,
		// Token: 0x040007B7 RID: 1975
		NoPromotionActive,
		// Token: 0x040007B8 RID: 1976
		DsOperationsError = 8224,
		// Token: 0x040007B9 RID: 1977
		DsProtocolError,
		// Token: 0x040007BA RID: 1978
		DsTimelimitExceeded,
		// Token: 0x040007BB RID: 1979
		DsSizelimitExceeded,
		// Token: 0x040007BC RID: 1980
		DsAdminLimitExceeded,
		// Token: 0x040007BD RID: 1981
		DsCompareFalse,
		// Token: 0x040007BE RID: 1982
		DsCompareTrue,
		// Token: 0x040007BF RID: 1983
		DsAuthMethodNotSupported,
		// Token: 0x040007C0 RID: 1984
		DsStrongAuthRequired,
		// Token: 0x040007C1 RID: 1985
		DsInappropriateAuth,
		// Token: 0x040007C2 RID: 1986
		DsAuthUnknown,
		// Token: 0x040007C3 RID: 1987
		DsReferral,
		// Token: 0x040007C4 RID: 1988
		DsUnavailableCritExtension,
		// Token: 0x040007C5 RID: 1989
		DsConfidentialityRequired,
		// Token: 0x040007C6 RID: 1990
		DsInappropriateMatching,
		// Token: 0x040007C7 RID: 1991
		DsConstraintViolation,
		// Token: 0x040007C8 RID: 1992
		DsNoSuchObject,
		// Token: 0x040007C9 RID: 1993
		DsAliasProblem,
		// Token: 0x040007CA RID: 1994
		DsInvalidDnSyntax,
		// Token: 0x040007CB RID: 1995
		DsIsLeaf,
		// Token: 0x040007CC RID: 1996
		DsAliasDerefProblem,
		// Token: 0x040007CD RID: 1997
		DsUnwillingToPerform,
		// Token: 0x040007CE RID: 1998
		DsLoopDetect,
		// Token: 0x040007CF RID: 1999
		DsNamingViolation,
		// Token: 0x040007D0 RID: 2000
		DsObjectResultsTooLarge,
		// Token: 0x040007D1 RID: 2001
		DsAffectsMultipleDsas,
		// Token: 0x040007D2 RID: 2002
		DsServerDown,
		// Token: 0x040007D3 RID: 2003
		DsLocalError,
		// Token: 0x040007D4 RID: 2004
		DsEncodingError,
		// Token: 0x040007D5 RID: 2005
		DsDecodingError,
		// Token: 0x040007D6 RID: 2006
		DsFilterUnknown,
		// Token: 0x040007D7 RID: 2007
		DsParamError,
		// Token: 0x040007D8 RID: 2008
		DsNotSupported,
		// Token: 0x040007D9 RID: 2009
		DsNoResultsReturned,
		// Token: 0x040007DA RID: 2010
		DsControlNotFound,
		// Token: 0x040007DB RID: 2011
		DsClientLoop,
		// Token: 0x040007DC RID: 2012
		DsReferralLimitExceeded,
		// Token: 0x040007DD RID: 2013
		DsSortControlMissing,
		// Token: 0x040007DE RID: 2014
		DsOffsetRangeError,
		// Token: 0x040007DF RID: 2015
		DsRidmgrDisabled,
		// Token: 0x040007E0 RID: 2016
		DsRootMustBeNc = 8301,
		// Token: 0x040007E1 RID: 2017
		DsAddReplicaInhibited,
		// Token: 0x040007E2 RID: 2018
		DsAttNotDefInSchema,
		// Token: 0x040007E3 RID: 2019
		DsMaxObjSizeExceeded,
		// Token: 0x040007E4 RID: 2020
		DsObjStringNameExists,
		// Token: 0x040007E5 RID: 2021
		DsNoRdnDefinedInSchema,
		// Token: 0x040007E6 RID: 2022
		DsRdnDoesntMatchSchema,
		// Token: 0x040007E7 RID: 2023
		DsNoRequestedAttsFound,
		// Token: 0x040007E8 RID: 2024
		DsUserBufferToSmall,
		// Token: 0x040007E9 RID: 2025
		DsAttIsNotOnObj,
		// Token: 0x040007EA RID: 2026
		DsIllegalModOperation,
		// Token: 0x040007EB RID: 2027
		DsObjTooLarge,
		// Token: 0x040007EC RID: 2028
		DsBadInstanceType,
		// Token: 0x040007ED RID: 2029
		DsMasterdsaRequired,
		// Token: 0x040007EE RID: 2030
		DsObjectClassRequired,
		// Token: 0x040007EF RID: 2031
		DsMissingRequiredAtt,
		// Token: 0x040007F0 RID: 2032
		DsAttNotDefForClass,
		// Token: 0x040007F1 RID: 2033
		DsAttAlreadyExists,
		// Token: 0x040007F2 RID: 2034
		DsCantAddAttValues = 8320,
		// Token: 0x040007F3 RID: 2035
		DsSingleValueConstraint,
		// Token: 0x040007F4 RID: 2036
		DsRangeConstraint,
		// Token: 0x040007F5 RID: 2037
		DsAttValAlreadyExists,
		// Token: 0x040007F6 RID: 2038
		DsCantRemMissingAtt,
		// Token: 0x040007F7 RID: 2039
		DsCantRemMissingAttVal,
		// Token: 0x040007F8 RID: 2040
		DsRootCantBeSubref,
		// Token: 0x040007F9 RID: 2041
		DsNoChaining,
		// Token: 0x040007FA RID: 2042
		DsNoChainedEval,
		// Token: 0x040007FB RID: 2043
		DsNoParentObject,
		// Token: 0x040007FC RID: 2044
		DsParentIsAnAlias,
		// Token: 0x040007FD RID: 2045
		DsCantMixMasterAndReps,
		// Token: 0x040007FE RID: 2046
		DsChildrenExist,
		// Token: 0x040007FF RID: 2047
		DsObjNotFound,
		// Token: 0x04000800 RID: 2048
		DsAliasedObjMissing,
		// Token: 0x04000801 RID: 2049
		DsBadNameSyntax,
		// Token: 0x04000802 RID: 2050
		DsAliasPointsToAlias,
		// Token: 0x04000803 RID: 2051
		DsCantDerefAlias,
		// Token: 0x04000804 RID: 2052
		DsOutOfScope,
		// Token: 0x04000805 RID: 2053
		DsObjectBeingRemoved,
		// Token: 0x04000806 RID: 2054
		DsCantDeleteDsaObj,
		// Token: 0x04000807 RID: 2055
		DsGenericError,
		// Token: 0x04000808 RID: 2056
		DsDsaMustBeIntMaster,
		// Token: 0x04000809 RID: 2057
		DsClassNotDsa,
		// Token: 0x0400080A RID: 2058
		DsInsuffAccessRights,
		// Token: 0x0400080B RID: 2059
		DsIllegalSuperior,
		// Token: 0x0400080C RID: 2060
		DsAttributeOwnedBySam,
		// Token: 0x0400080D RID: 2061
		DsNameTooManyParts,
		// Token: 0x0400080E RID: 2062
		DsNameTooLong,
		// Token: 0x0400080F RID: 2063
		DsNameValueTooLong,
		// Token: 0x04000810 RID: 2064
		DsNameUnparseable,
		// Token: 0x04000811 RID: 2065
		DsNameTypeUnknown,
		// Token: 0x04000812 RID: 2066
		DsNotAnObject,
		// Token: 0x04000813 RID: 2067
		DsSecDescTooShort,
		// Token: 0x04000814 RID: 2068
		DsSecDescInvalid,
		// Token: 0x04000815 RID: 2069
		DsNoDeletedName,
		// Token: 0x04000816 RID: 2070
		DsSubrefMustHaveParent,
		// Token: 0x04000817 RID: 2071
		DsNcnameMustBeNc,
		// Token: 0x04000818 RID: 2072
		DsCantAddSystemOnly,
		// Token: 0x04000819 RID: 2073
		DsClassMustBeConcrete,
		// Token: 0x0400081A RID: 2074
		DsInvalidDmd,
		// Token: 0x0400081B RID: 2075
		DsObjGuidExists,
		// Token: 0x0400081C RID: 2076
		DsNotOnBacklink,
		// Token: 0x0400081D RID: 2077
		DsNoCrossrefForNc,
		// Token: 0x0400081E RID: 2078
		DsShuttingDown,
		// Token: 0x0400081F RID: 2079
		DsUnknownOperation,
		// Token: 0x04000820 RID: 2080
		DsInvalidRoleOwner,
		// Token: 0x04000821 RID: 2081
		DsCouldntContactFsmo,
		// Token: 0x04000822 RID: 2082
		DsCrossNcDnRename,
		// Token: 0x04000823 RID: 2083
		DsCantModSystemOnly,
		// Token: 0x04000824 RID: 2084
		DsReplicatorOnly,
		// Token: 0x04000825 RID: 2085
		DsObjClassNotDefined,
		// Token: 0x04000826 RID: 2086
		DsObjClassNotSubclass,
		// Token: 0x04000827 RID: 2087
		DsNameReferenceInvalid,
		// Token: 0x04000828 RID: 2088
		DsCrossRefExists,
		// Token: 0x04000829 RID: 2089
		DsCantDelMasterCrossref,
		// Token: 0x0400082A RID: 2090
		DsSubtreeNotifyNotNcHead,
		// Token: 0x0400082B RID: 2091
		DsNotifyFilterTooComplex,
		// Token: 0x0400082C RID: 2092
		DsDupRdn,
		// Token: 0x0400082D RID: 2093
		DsDupOid,
		// Token: 0x0400082E RID: 2094
		DsDupMapiId,
		// Token: 0x0400082F RID: 2095
		DsDupSchemaIdGuid,
		// Token: 0x04000830 RID: 2096
		DsDupLdapDisplayName,
		// Token: 0x04000831 RID: 2097
		DsSemanticAttTest,
		// Token: 0x04000832 RID: 2098
		DsSyntaxMismatch,
		// Token: 0x04000833 RID: 2099
		DsExistsInMustHave,
		// Token: 0x04000834 RID: 2100
		DsExistsInMayHave,
		// Token: 0x04000835 RID: 2101
		DsNonexistentMayHave,
		// Token: 0x04000836 RID: 2102
		DsNonexistentMustHave,
		// Token: 0x04000837 RID: 2103
		DsAuxClsTestFail,
		// Token: 0x04000838 RID: 2104
		DsNonexistentPossSup,
		// Token: 0x04000839 RID: 2105
		DsSubClsTestFail,
		// Token: 0x0400083A RID: 2106
		DsBadRdnAttIdSyntax,
		// Token: 0x0400083B RID: 2107
		DsExistsInAuxCls,
		// Token: 0x0400083C RID: 2108
		DsExistsInSubCls,
		// Token: 0x0400083D RID: 2109
		DsExistsInPossSup,
		// Token: 0x0400083E RID: 2110
		DsRecalcschemaFailed,
		// Token: 0x0400083F RID: 2111
		DsTreeDeleteNotFinished,
		// Token: 0x04000840 RID: 2112
		DsCantDelete,
		// Token: 0x04000841 RID: 2113
		DsAttSchemaReqId,
		// Token: 0x04000842 RID: 2114
		DsBadAttSchemaSyntax,
		// Token: 0x04000843 RID: 2115
		DsCantCacheAtt,
		// Token: 0x04000844 RID: 2116
		DsCantCacheClass,
		// Token: 0x04000845 RID: 2117
		DsCantRemoveAttCache,
		// Token: 0x04000846 RID: 2118
		DsCantRemoveClassCache,
		// Token: 0x04000847 RID: 2119
		DsCantRetrieveDn,
		// Token: 0x04000848 RID: 2120
		DsMissingSupref,
		// Token: 0x04000849 RID: 2121
		DsCantRetrieveInstance,
		// Token: 0x0400084A RID: 2122
		DsCodeInconsistency,
		// Token: 0x0400084B RID: 2123
		DsDatabaseError,
		// Token: 0x0400084C RID: 2124
		DsGovernsidMissing,
		// Token: 0x0400084D RID: 2125
		DsMissingExpectedAtt,
		// Token: 0x0400084E RID: 2126
		DsNcnameMissingCrRef,
		// Token: 0x0400084F RID: 2127
		DsSecurityCheckingError,
		// Token: 0x04000850 RID: 2128
		DsSchemaNotLoaded,
		// Token: 0x04000851 RID: 2129
		DsSchemaAllocFailed,
		// Token: 0x04000852 RID: 2130
		DsAttSchemaReqSyntax,
		// Token: 0x04000853 RID: 2131
		DsGcverifyError,
		// Token: 0x04000854 RID: 2132
		DsDraSchemaMismatch,
		// Token: 0x04000855 RID: 2133
		DsCantFindDsaObj,
		// Token: 0x04000856 RID: 2134
		DsCantFindExpectedNc,
		// Token: 0x04000857 RID: 2135
		DsCantFindNcInCache,
		// Token: 0x04000858 RID: 2136
		DsCantRetrieveChild,
		// Token: 0x04000859 RID: 2137
		DsSecurityIllegalModify,
		// Token: 0x0400085A RID: 2138
		DsCantReplaceHiddenRec,
		// Token: 0x0400085B RID: 2139
		DsBadHierarchyFile,
		// Token: 0x0400085C RID: 2140
		DsBuildHierarchyTableFailed,
		// Token: 0x0400085D RID: 2141
		DsConfigParamMissing,
		// Token: 0x0400085E RID: 2142
		DsCountingAbIndicesFailed,
		// Token: 0x0400085F RID: 2143
		DsHierarchyTableMallocFailed,
		// Token: 0x04000860 RID: 2144
		DsInternalFailure,
		// Token: 0x04000861 RID: 2145
		DsUnknownError,
		// Token: 0x04000862 RID: 2146
		DsRootRequiresClassTop,
		// Token: 0x04000863 RID: 2147
		DsRefusingFsmoRoles,
		// Token: 0x04000864 RID: 2148
		DsMissingFsmoSettings,
		// Token: 0x04000865 RID: 2149
		DsUnableToSurrenderRoles,
		// Token: 0x04000866 RID: 2150
		DsDraGeneric,
		// Token: 0x04000867 RID: 2151
		DsDraInvalidParameter,
		// Token: 0x04000868 RID: 2152
		DsDraBusy,
		// Token: 0x04000869 RID: 2153
		DsDraBadDn,
		// Token: 0x0400086A RID: 2154
		DsDraBadNc,
		// Token: 0x0400086B RID: 2155
		DsDraDnExists,
		// Token: 0x0400086C RID: 2156
		DsDraInternalError,
		// Token: 0x0400086D RID: 2157
		DsDraInconsistentDit,
		// Token: 0x0400086E RID: 2158
		DsDraConnectionFailed,
		// Token: 0x0400086F RID: 2159
		DsDraBadInstanceType,
		// Token: 0x04000870 RID: 2160
		DsDraOutOfMem,
		// Token: 0x04000871 RID: 2161
		DsDraMailProblem,
		// Token: 0x04000872 RID: 2162
		DsDraRefAlreadyExists,
		// Token: 0x04000873 RID: 2163
		DsDraRefNotFound,
		// Token: 0x04000874 RID: 2164
		DsDraObjIsRepSource,
		// Token: 0x04000875 RID: 2165
		DsDraDbError,
		// Token: 0x04000876 RID: 2166
		DsDraNoReplica,
		// Token: 0x04000877 RID: 2167
		DsDraAccessDenied,
		// Token: 0x04000878 RID: 2168
		DsDraNotSupported,
		// Token: 0x04000879 RID: 2169
		DsDraRpcCancelled,
		// Token: 0x0400087A RID: 2170
		DsDraSourceDisabled,
		// Token: 0x0400087B RID: 2171
		DsDraSinkDisabled,
		// Token: 0x0400087C RID: 2172
		DsDraNameCollision,
		// Token: 0x0400087D RID: 2173
		DsDraSourceReinstalled,
		// Token: 0x0400087E RID: 2174
		DsDraMissingParent,
		// Token: 0x0400087F RID: 2175
		DsDraPreempted,
		// Token: 0x04000880 RID: 2176
		DsDraAbandonSync,
		// Token: 0x04000881 RID: 2177
		DsDraShutdown,
		// Token: 0x04000882 RID: 2178
		DsDraIncompatiblePartialSet,
		// Token: 0x04000883 RID: 2179
		DsDraSourceIsPartialReplica,
		// Token: 0x04000884 RID: 2180
		DsDraExtnConnectionFailed,
		// Token: 0x04000885 RID: 2181
		DsInstallSchemaMismatch,
		// Token: 0x04000886 RID: 2182
		DsDupLinkId,
		// Token: 0x04000887 RID: 2183
		DsNameErrorResolving,
		// Token: 0x04000888 RID: 2184
		DsNameErrorNotFound,
		// Token: 0x04000889 RID: 2185
		DsNameErrorNotUnique,
		// Token: 0x0400088A RID: 2186
		DsNameErrorNoMapping,
		// Token: 0x0400088B RID: 2187
		DsNameErrorDomainOnly,
		// Token: 0x0400088C RID: 2188
		DsNameErrorNoSyntacticalMapping,
		// Token: 0x0400088D RID: 2189
		DsConstructedAttMod,
		// Token: 0x0400088E RID: 2190
		DsWrongOmObjClass,
		// Token: 0x0400088F RID: 2191
		DsDraReplPending,
		// Token: 0x04000890 RID: 2192
		DsDsRequired,
		// Token: 0x04000891 RID: 2193
		DsInvalidLdapDisplayName,
		// Token: 0x04000892 RID: 2194
		DsNonBaseSearch,
		// Token: 0x04000893 RID: 2195
		DsCantRetrieveAtts,
		// Token: 0x04000894 RID: 2196
		DsBacklinkWithoutLink,
		// Token: 0x04000895 RID: 2197
		DsEpochMismatch,
		// Token: 0x04000896 RID: 2198
		DsSrcNameMismatch,
		// Token: 0x04000897 RID: 2199
		DsSrcAndDstNcIdentical,
		// Token: 0x04000898 RID: 2200
		DsDstNcMismatch,
		// Token: 0x04000899 RID: 2201
		DsNotAuthoritiveForDstNc,
		// Token: 0x0400089A RID: 2202
		DsSrcGuidMismatch,
		// Token: 0x0400089B RID: 2203
		DsCantMoveDeletedObject,
		// Token: 0x0400089C RID: 2204
		DsPdcOperationInProgress,
		// Token: 0x0400089D RID: 2205
		DsCrossDomainCleanupReqd,
		// Token: 0x0400089E RID: 2206
		DsIllegalXdomMoveOperation,
		// Token: 0x0400089F RID: 2207
		DsCantWithAcctGroupMembershps,
		// Token: 0x040008A0 RID: 2208
		DsNcMustHaveNcParent,
		// Token: 0x040008A1 RID: 2209
		DsCrImpossibleToValidate,
		// Token: 0x040008A2 RID: 2210
		DsDstDomainNotNative,
		// Token: 0x040008A3 RID: 2211
		DsMissingInfrastructureContainer,
		// Token: 0x040008A4 RID: 2212
		DsCantMoveAccountGroup,
		// Token: 0x040008A5 RID: 2213
		DsCantMoveResourceGroup,
		// Token: 0x040008A6 RID: 2214
		DsInvalidSearchFlag,
		// Token: 0x040008A7 RID: 2215
		DsNoTreeDeleteAboveNc,
		// Token: 0x040008A8 RID: 2216
		DsCouldntLockTreeForDelete,
		// Token: 0x040008A9 RID: 2217
		DsCouldntIdentifyObjectsForTreeDelete,
		// Token: 0x040008AA RID: 2218
		DsSamInitFailure,
		// Token: 0x040008AB RID: 2219
		DsSensitiveGroupViolation,
		// Token: 0x040008AC RID: 2220
		DsCantModPrimarygroupid,
		// Token: 0x040008AD RID: 2221
		DsIllegalBaseSchemaMod,
		// Token: 0x040008AE RID: 2222
		DsNonsafeSchemaChange,
		// Token: 0x040008AF RID: 2223
		DsSchemaUpdateDisallowed,
		// Token: 0x040008B0 RID: 2224
		DsCantCreateUnderSchema,
		// Token: 0x040008B1 RID: 2225
		DsInstallNoSrcSchVersion,
		// Token: 0x040008B2 RID: 2226
		DsInstallNoSchVersionInInifile,
		// Token: 0x040008B3 RID: 2227
		DsInvalidGroupType,
		// Token: 0x040008B4 RID: 2228
		DsNoNestGlobalgroupInMixeddomain,
		// Token: 0x040008B5 RID: 2229
		DsNoNestLocalgroupInMixeddomain,
		// Token: 0x040008B6 RID: 2230
		DsGlobalCantHaveLocalMember,
		// Token: 0x040008B7 RID: 2231
		DsGlobalCantHaveUniversalMember,
		// Token: 0x040008B8 RID: 2232
		DsUniversalCantHaveLocalMember,
		// Token: 0x040008B9 RID: 2233
		DsGlobalCantHaveCrossdomainMember,
		// Token: 0x040008BA RID: 2234
		DsLocalCantHaveCrossdomainLocalMember,
		// Token: 0x040008BB RID: 2235
		DsHavePrimaryMembers,
		// Token: 0x040008BC RID: 2236
		DsStringSdConversionFailed,
		// Token: 0x040008BD RID: 2237
		DsNamingMasterGc,
		// Token: 0x040008BE RID: 2238
		DsDnsLookupFailure,
		// Token: 0x040008BF RID: 2239
		DsCouldntUpdateSpns,
		// Token: 0x040008C0 RID: 2240
		DsCantRetrieveSd,
		// Token: 0x040008C1 RID: 2241
		DsKeyNotUnique,
		// Token: 0x040008C2 RID: 2242
		DsWrongLinkedAttSyntax,
		// Token: 0x040008C3 RID: 2243
		DsSamNeedBootkeyPassword,
		// Token: 0x040008C4 RID: 2244
		DsSamNeedBootkeyFloppy,
		// Token: 0x040008C5 RID: 2245
		DsCantStart,
		// Token: 0x040008C6 RID: 2246
		DsInitFailure,
		// Token: 0x040008C7 RID: 2247
		DsNoPktPrivacyOnConnection,
		// Token: 0x040008C8 RID: 2248
		DsSourceDomainInForest,
		// Token: 0x040008C9 RID: 2249
		DsDestinationDomainNotInForest,
		// Token: 0x040008CA RID: 2250
		DsDestinationAuditingNotEnabled,
		// Token: 0x040008CB RID: 2251
		DsCantFindDcForSrcDomain,
		// Token: 0x040008CC RID: 2252
		DsSrcObjNotGroupOrUser,
		// Token: 0x040008CD RID: 2253
		DsSrcSidExistsInForest,
		// Token: 0x040008CE RID: 2254
		DsSrcAndDstObjectClassMismatch,
		// Token: 0x040008CF RID: 2255
		SamInitFailure,
		// Token: 0x040008D0 RID: 2256
		DsDraSchemaInfoShip,
		// Token: 0x040008D1 RID: 2257
		DsDraSchemaConflict,
		// Token: 0x040008D2 RID: 2258
		DsDraEarlierSchemaConflict,
		// Token: 0x040008D3 RID: 2259
		DsDraObjNcMismatch,
		// Token: 0x040008D4 RID: 2260
		DsNcStillHasDsas,
		// Token: 0x040008D5 RID: 2261
		DsGcRequired,
		// Token: 0x040008D6 RID: 2262
		DsLocalMemberOfLocalOnly,
		// Token: 0x040008D7 RID: 2263
		DsNoFpoInUniversalGroups,
		// Token: 0x040008D8 RID: 2264
		DsCantAddToGc,
		// Token: 0x040008D9 RID: 2265
		DsNoCheckpointWithPdc,
		// Token: 0x040008DA RID: 2266
		DsSourceAuditingNotEnabled,
		// Token: 0x040008DB RID: 2267
		DsCantCreateInNondomainNc,
		// Token: 0x040008DC RID: 2268
		DsInvalidNameForSpn,
		// Token: 0x040008DD RID: 2269
		DsFilterUsesContructedAttrs,
		// Token: 0x040008DE RID: 2270
		DsUnicodepwdNotInQuotes,
		// Token: 0x040008DF RID: 2271
		DsMachineAccountQuotaExceeded,
		// Token: 0x040008E0 RID: 2272
		DsMustBeRunOnDstDc,
		// Token: 0x040008E1 RID: 2273
		DsSrcDcMustBeSp4OrGreater,
		// Token: 0x040008E2 RID: 2274
		DsCantTreeDeleteCriticalObj,
		// Token: 0x040008E3 RID: 2275
		DsInitFailureConsole,
		// Token: 0x040008E4 RID: 2276
		DsSamInitFailureConsole,
		// Token: 0x040008E5 RID: 2277
		DsForestVersionTooHigh,
		// Token: 0x040008E6 RID: 2278
		DsDomainVersionTooHigh,
		// Token: 0x040008E7 RID: 2279
		DsForestVersionTooLow,
		// Token: 0x040008E8 RID: 2280
		DsDomainVersionTooLow,
		// Token: 0x040008E9 RID: 2281
		DsIncompatibleVersion,
		// Token: 0x040008EA RID: 2282
		DsLowDsaVersion,
		// Token: 0x040008EB RID: 2283
		DsNoBehaviorVersionInMixeddomain,
		// Token: 0x040008EC RID: 2284
		DsNotSupportedSortOrder,
		// Token: 0x040008ED RID: 2285
		DsNameNotUnique,
		// Token: 0x040008EE RID: 2286
		DsMachineAccountCreatedPrent4,
		// Token: 0x040008EF RID: 2287
		DsOutOfVersionStore,
		// Token: 0x040008F0 RID: 2288
		DsIncompatibleControlsUsed,
		// Token: 0x040008F1 RID: 2289
		DsNoRefDomain,
		// Token: 0x040008F2 RID: 2290
		DsReservedLinkId,
		// Token: 0x040008F3 RID: 2291
		DsLinkIdNotAvailable,
		// Token: 0x040008F4 RID: 2292
		DsAgCantHaveUniversalMember,
		// Token: 0x040008F5 RID: 2293
		DsModifydnDisallowedByInstanceType,
		// Token: 0x040008F6 RID: 2294
		DsNoObjectMoveInSchemaNc,
		// Token: 0x040008F7 RID: 2295
		DsModifydnDisallowedByFlag,
		// Token: 0x040008F8 RID: 2296
		DsModifydnWrongGrandparent,
		// Token: 0x040008F9 RID: 2297
		DsNameErrorTrustReferral,
		// Token: 0x040008FA RID: 2298
		NotSupportedOnStandardServer,
		// Token: 0x040008FB RID: 2299
		DsCantAccessRemotePartOfAd,
		// Token: 0x040008FC RID: 2300
		DsCrImpossibleToValidateV2,
		// Token: 0x040008FD RID: 2301
		DsThreadLimitExceeded,
		// Token: 0x040008FE RID: 2302
		DsNotClosest,
		// Token: 0x040008FF RID: 2303
		DsCantDeriveSpnWithoutServerRef,
		// Token: 0x04000900 RID: 2304
		DsSingleUserModeFailed,
		// Token: 0x04000901 RID: 2305
		DsNtdscriptSyntaxError,
		// Token: 0x04000902 RID: 2306
		DsNtdscriptProcessError,
		// Token: 0x04000903 RID: 2307
		DsDifferentReplEpochs,
		// Token: 0x04000904 RID: 2308
		DsDrsExtensionsChanged,
		// Token: 0x04000905 RID: 2309
		DsReplicaSetChangeNotAllowedOnDisabledCr,
		// Token: 0x04000906 RID: 2310
		DsNoMsdsIntid,
		// Token: 0x04000907 RID: 2311
		DsDupMsdsIntid,
		// Token: 0x04000908 RID: 2312
		DsExistsInRdnattid,
		// Token: 0x04000909 RID: 2313
		DsAuthorizationFailed,
		// Token: 0x0400090A RID: 2314
		DsInvalidScript,
		// Token: 0x0400090B RID: 2315
		DsRemoteCrossrefOpFailed,
		// Token: 0x0400090C RID: 2316
		DsCrossRefBusy,
		// Token: 0x0400090D RID: 2317
		DsCantDeriveSpnForDeletedDomain,
		// Token: 0x0400090E RID: 2318
		DsCantDemoteWithWriteableNc,
		// Token: 0x0400090F RID: 2319
		DsDuplicateIdFound,
		// Token: 0x04000910 RID: 2320
		DsInsufficientAttrToCreateObject,
		// Token: 0x04000911 RID: 2321
		DsGroupConversionError,
		// Token: 0x04000912 RID: 2322
		DsCantMoveAppBasicGroup,
		// Token: 0x04000913 RID: 2323
		DsCantMoveAppQueryGroup,
		// Token: 0x04000914 RID: 2324
		DsRoleNotVerified,
		// Token: 0x04000915 RID: 2325
		DsWkoContainerCannotBeSpecial,
		// Token: 0x04000916 RID: 2326
		DsDomainRenameInProgress,
		// Token: 0x04000917 RID: 2327
		DsExistingAdChildNc,
		// Token: 0x04000918 RID: 2328
		DsReplLifetimeExceeded,
		// Token: 0x04000919 RID: 2329
		DsDisallowedInSystemContainer,
		// Token: 0x0400091A RID: 2330
		DsLdapSendQueueFull,
		// Token: 0x0400091B RID: 2331
		DsDraOutScheduleWindow,
		// Token: 0x0400091C RID: 2332
		DsPolicyNotKnown,
		// Token: 0x0400091D RID: 2333
		NoSiteSettingsObject,
		// Token: 0x0400091E RID: 2334
		NoSecrets,
		// Token: 0x0400091F RID: 2335
		NoWritableDcFound,
		// Token: 0x04000920 RID: 2336
		DsNoServerObject,
		// Token: 0x04000921 RID: 2337
		DsNoNtdsaObject,
		// Token: 0x04000922 RID: 2338
		DsNonAsqSearch,
		// Token: 0x04000923 RID: 2339
		DsAuditFailure,
		// Token: 0x04000924 RID: 2340
		DsInvalidSearchFlagSubtree,
		// Token: 0x04000925 RID: 2341
		DsInvalidSearchFlagTuple,
		// Token: 0x04000926 RID: 2342
		DsHierarchyTableTooDeep,
		// Token: 0x04000927 RID: 2343
		DsDraCorruptUtdVector,
		// Token: 0x04000928 RID: 2344
		DsDraSecretsDenied,
		// Token: 0x04000929 RID: 2345
		DsReservedMapiId,
		// Token: 0x0400092A RID: 2346
		DsMapiIdNotAvailable,
		// Token: 0x0400092B RID: 2347
		DsDraMissingKrbtgtSecret,
		// Token: 0x0400092C RID: 2348
		DsDomainNameExistsInForest,
		// Token: 0x0400092D RID: 2349
		DsFlatNameExistsInForest,
		// Token: 0x0400092E RID: 2350
		InvalidUserPrincipalName,
		// Token: 0x0400092F RID: 2351
		DsOidMappedGroupCantHaveMembers,
		// Token: 0x04000930 RID: 2352
		DsOidNotFound,
		// Token: 0x04000931 RID: 2353
		DsDraRecycledTarget,
		// Token: 0x04000932 RID: 2354
		DsDisallowedNcRedirect,
		// Token: 0x04000933 RID: 2355
		DsHighAdldsFfl,
		// Token: 0x04000934 RID: 2356
		DsHighDsaVersion,
		// Token: 0x04000935 RID: 2357
		DsLowAdldsFfl,
		// Token: 0x04000936 RID: 2358
		DomainSidSameAsLocalWorkstation,
		// Token: 0x04000937 RID: 2359
		DsUndeleteSamValidationFailed,
		// Token: 0x04000938 RID: 2360
		IncorrectAccountType,
		// Token: 0x04000939 RID: 2361
		DsSpnValueNotUniqueInForest,
		// Token: 0x0400093A RID: 2362
		DsUpnValueNotUniqueInForest,
		// Token: 0x0400093B RID: 2363
		DsMissingForestTrust,
		// Token: 0x0400093C RID: 2364
		DsValueKeyNotUnique,
		// Token: 0x0400093D RID: 2365
		IpsecQmPolicyExists = 13000,
		// Token: 0x0400093E RID: 2366
		IpsecQmPolicyNotFound,
		// Token: 0x0400093F RID: 2367
		IpsecQmPolicyInUse,
		// Token: 0x04000940 RID: 2368
		IpsecMmPolicyExists,
		// Token: 0x04000941 RID: 2369
		IpsecMmPolicyNotFound,
		// Token: 0x04000942 RID: 2370
		IpsecMmPolicyInUse,
		// Token: 0x04000943 RID: 2371
		IpsecMmFilterExists,
		// Token: 0x04000944 RID: 2372
		IpsecMmFilterNotFound,
		// Token: 0x04000945 RID: 2373
		IpsecTransportFilterExists,
		// Token: 0x04000946 RID: 2374
		IpsecTransportFilterNotFound,
		// Token: 0x04000947 RID: 2375
		IpsecMmAuthExists,
		// Token: 0x04000948 RID: 2376
		IpsecMmAuthNotFound,
		// Token: 0x04000949 RID: 2377
		IpsecMmAuthInUse,
		// Token: 0x0400094A RID: 2378
		IpsecDefaultMmPolicyNotFound,
		// Token: 0x0400094B RID: 2379
		IpsecDefaultMmAuthNotFound,
		// Token: 0x0400094C RID: 2380
		IpsecDefaultQmPolicyNotFound,
		// Token: 0x0400094D RID: 2381
		IpsecTunnelFilterExists,
		// Token: 0x0400094E RID: 2382
		IpsecTunnelFilterNotFound,
		// Token: 0x0400094F RID: 2383
		IpsecMmFilterPendingDeletion,
		// Token: 0x04000950 RID: 2384
		IpsecTransportFilterPendingDeletion,
		// Token: 0x04000951 RID: 2385
		IpsecTunnelFilterPendingDeletion,
		// Token: 0x04000952 RID: 2386
		IpsecMmPolicyPendingDeletion,
		// Token: 0x04000953 RID: 2387
		IpsecMmAuthPendingDeletion,
		// Token: 0x04000954 RID: 2388
		IpsecQmPolicyPendingDeletion,
		// Token: 0x04000955 RID: 2389
		IpsecIkeNegStatusBegin = 13800,
		// Token: 0x04000956 RID: 2390
		IpsecIkeAuthFail,
		// Token: 0x04000957 RID: 2391
		IpsecIkeAttribFail,
		// Token: 0x04000958 RID: 2392
		IpsecIkeNegotiationPending,
		// Token: 0x04000959 RID: 2393
		IpsecIkeGeneralProcessingError,
		// Token: 0x0400095A RID: 2394
		IpsecIkeTimedOut,
		// Token: 0x0400095B RID: 2395
		IpsecIkeNoCert,
		// Token: 0x0400095C RID: 2396
		IpsecIkeSaDeleted,
		// Token: 0x0400095D RID: 2397
		IpsecIkeSaReaped,
		// Token: 0x0400095E RID: 2398
		IpsecIkeMmAcquireDrop,
		// Token: 0x0400095F RID: 2399
		IpsecIkeQmAcquireDrop,
		// Token: 0x04000960 RID: 2400
		IpsecIkeQueueDropMm,
		// Token: 0x04000961 RID: 2401
		IpsecIkeQueueDropNoMm,
		// Token: 0x04000962 RID: 2402
		IpsecIkeDropNoResponse,
		// Token: 0x04000963 RID: 2403
		IpsecIkeMmDelayDrop,
		// Token: 0x04000964 RID: 2404
		IpsecIkeQmDelayDrop,
		// Token: 0x04000965 RID: 2405
		IpsecIkeError,
		// Token: 0x04000966 RID: 2406
		IpsecIkeCrlFailed,
		// Token: 0x04000967 RID: 2407
		IpsecIkeInvalidKeyUsage,
		// Token: 0x04000968 RID: 2408
		IpsecIkeInvalidCertType,
		// Token: 0x04000969 RID: 2409
		IpsecIkeNoPrivateKey,
		// Token: 0x0400096A RID: 2410
		IpsecIkeSimultaneousRekey,
		// Token: 0x0400096B RID: 2411
		IpsecIkeDhFail,
		// Token: 0x0400096C RID: 2412
		IpsecIkeCriticalPayloadNotRecognized,
		// Token: 0x0400096D RID: 2413
		IpsecIkeInvalidHeader,
		// Token: 0x0400096E RID: 2414
		IpsecIkeNoPolicy,
		// Token: 0x0400096F RID: 2415
		IpsecIkeInvalidSignature,
		// Token: 0x04000970 RID: 2416
		IpsecIkeKerberosError,
		// Token: 0x04000971 RID: 2417
		IpsecIkeNoPublicKey,
		// Token: 0x04000972 RID: 2418
		IpsecIkeProcessErr,
		// Token: 0x04000973 RID: 2419
		IpsecIkeProcessErrSa,
		// Token: 0x04000974 RID: 2420
		IpsecIkeProcessErrProp,
		// Token: 0x04000975 RID: 2421
		IpsecIkeProcessErrTrans,
		// Token: 0x04000976 RID: 2422
		IpsecIkeProcessErrKe,
		// Token: 0x04000977 RID: 2423
		IpsecIkeProcessErrId,
		// Token: 0x04000978 RID: 2424
		IpsecIkeProcessErrCert,
		// Token: 0x04000979 RID: 2425
		IpsecIkeProcessErrCertReq,
		// Token: 0x0400097A RID: 2426
		IpsecIkeProcessErrHash,
		// Token: 0x0400097B RID: 2427
		IpsecIkeProcessErrSig,
		// Token: 0x0400097C RID: 2428
		IpsecIkeProcessErrNonce,
		// Token: 0x0400097D RID: 2429
		IpsecIkeProcessErrNotify,
		// Token: 0x0400097E RID: 2430
		IpsecIkeProcessErrDelete,
		// Token: 0x0400097F RID: 2431
		IpsecIkeProcessErrVendor,
		// Token: 0x04000980 RID: 2432
		IpsecIkeInvalidPayload,
		// Token: 0x04000981 RID: 2433
		IpsecIkeLoadSoftSa,
		// Token: 0x04000982 RID: 2434
		IpsecIkeSoftSaTornDown,
		// Token: 0x04000983 RID: 2435
		IpsecIkeInvalidCookie,
		// Token: 0x04000984 RID: 2436
		IpsecIkeNoPeerCert,
		// Token: 0x04000985 RID: 2437
		IpsecIkePeerCrlFailed,
		// Token: 0x04000986 RID: 2438
		IpsecIkePolicyChange,
		// Token: 0x04000987 RID: 2439
		IpsecIkeNoMmPolicy,
		// Token: 0x04000988 RID: 2440
		IpsecIkeNotcbpriv,
		// Token: 0x04000989 RID: 2441
		IpsecIkeSecloadfail,
		// Token: 0x0400098A RID: 2442
		IpsecIkeFailsspinit,
		// Token: 0x0400098B RID: 2443
		IpsecIkeFailqueryssp,
		// Token: 0x0400098C RID: 2444
		IpsecIkeSrvacqfail,
		// Token: 0x0400098D RID: 2445
		IpsecIkeSrvquerycred,
		// Token: 0x0400098E RID: 2446
		IpsecIkeGetspifail,
		// Token: 0x0400098F RID: 2447
		IpsecIkeInvalidFilter,
		// Token: 0x04000990 RID: 2448
		IpsecIkeOutOfMemory,
		// Token: 0x04000991 RID: 2449
		IpsecIkeAddUpdateKeyFailed,
		// Token: 0x04000992 RID: 2450
		IpsecIkeInvalidPolicy,
		// Token: 0x04000993 RID: 2451
		IpsecIkeUnknownDoi,
		// Token: 0x04000994 RID: 2452
		IpsecIkeInvalidSituation,
		// Token: 0x04000995 RID: 2453
		IpsecIkeDhFailure,
		// Token: 0x04000996 RID: 2454
		IpsecIkeInvalidGroup,
		// Token: 0x04000997 RID: 2455
		IpsecIkeEncrypt,
		// Token: 0x04000998 RID: 2456
		IpsecIkeDecrypt,
		// Token: 0x04000999 RID: 2457
		IpsecIkePolicyMatch,
		// Token: 0x0400099A RID: 2458
		IpsecIkeUnsupportedId,
		// Token: 0x0400099B RID: 2459
		IpsecIkeInvalidHash,
		// Token: 0x0400099C RID: 2460
		IpsecIkeInvalidHashAlg,
		// Token: 0x0400099D RID: 2461
		IpsecIkeInvalidHashSize,
		// Token: 0x0400099E RID: 2462
		IpsecIkeInvalidEncryptAlg,
		// Token: 0x0400099F RID: 2463
		IpsecIkeInvalidAuthAlg,
		// Token: 0x040009A0 RID: 2464
		IpsecIkeInvalidSig,
		// Token: 0x040009A1 RID: 2465
		IpsecIkeLoadFailed,
		// Token: 0x040009A2 RID: 2466
		IpsecIkeRpcDelete,
		// Token: 0x040009A3 RID: 2467
		IpsecIkeBenignReinit,
		// Token: 0x040009A4 RID: 2468
		IpsecIkeInvalidResponderLifetimeNotify,
		// Token: 0x040009A5 RID: 2469
		IpsecIkeInvalidMajorVersion,
		// Token: 0x040009A6 RID: 2470
		IpsecIkeInvalidCertKeylen,
		// Token: 0x040009A7 RID: 2471
		IpsecIkeMmLimit,
		// Token: 0x040009A8 RID: 2472
		IpsecIkeNegotiationDisabled,
		// Token: 0x040009A9 RID: 2473
		IpsecIkeQmLimit,
		// Token: 0x040009AA RID: 2474
		IpsecIkeMmExpired,
		// Token: 0x040009AB RID: 2475
		IpsecIkePeerMmAssumedInvalid,
		// Token: 0x040009AC RID: 2476
		IpsecIkeCertChainPolicyMismatch,
		// Token: 0x040009AD RID: 2477
		IpsecIkeUnexpectedMessageId,
		// Token: 0x040009AE RID: 2478
		IpsecIkeInvalidAuthPayload,
		// Token: 0x040009AF RID: 2479
		IpsecIkeDosCookieSent,
		// Token: 0x040009B0 RID: 2480
		IpsecIkeShuttingDown,
		// Token: 0x040009B1 RID: 2481
		IpsecIkeCgaAuthFailed,
		// Token: 0x040009B2 RID: 2482
		IpsecIkeProcessErrNatoa,
		// Token: 0x040009B3 RID: 2483
		IpsecIkeInvalidMmForQm,
		// Token: 0x040009B4 RID: 2484
		IpsecIkeQmExpired,
		// Token: 0x040009B5 RID: 2485
		IpsecIkeTooManyFilters,
		// Token: 0x040009B6 RID: 2486
		IpsecIkeNegStatusEnd,
		// Token: 0x040009B7 RID: 2487
		IpsecIkeKillDummyNapTunnel,
		// Token: 0x040009B8 RID: 2488
		IpsecIkeInnerIpAssignmentFailure,
		// Token: 0x040009B9 RID: 2489
		IpsecIkeRequireCpPayloadMissing,
		// Token: 0x040009BA RID: 2490
		IpsecKeyModuleImpersonationNegotiationPending,
		// Token: 0x040009BB RID: 2491
		IpsecIkeCoexistenceSuppress,
		// Token: 0x040009BC RID: 2492
		IpsecIkeRatelimitDrop,
		// Token: 0x040009BD RID: 2493
		IpsecIkePeerDoesntSupportMobike,
		// Token: 0x040009BE RID: 2494
		IpsecIkeAuthorizationFailure,
		// Token: 0x040009BF RID: 2495
		IpsecIkeStrongCredAuthorizationFailure,
		// Token: 0x040009C0 RID: 2496
		IpsecIkeAuthorizationFailureWithOptionalRetry,
		// Token: 0x040009C1 RID: 2497
		IpsecIkeStrongCredAuthorizationAndCertmapFailure,
		// Token: 0x040009C2 RID: 2498
		IpsecIkeNegStatusExtendedEnd,
		// Token: 0x040009C3 RID: 2499
		IpsecBadSpi,
		// Token: 0x040009C4 RID: 2500
		IpsecSaLifetimeExpired,
		// Token: 0x040009C5 RID: 2501
		IpsecWrongSa,
		// Token: 0x040009C6 RID: 2502
		IpsecReplayCheckFailed,
		// Token: 0x040009C7 RID: 2503
		IpsecInvalidPacket,
		// Token: 0x040009C8 RID: 2504
		IpsecIntegrityCheckFailed,
		// Token: 0x040009C9 RID: 2505
		IpsecClearTextDrop,
		// Token: 0x040009CA RID: 2506
		IpsecAuthFirewallDrop,
		// Token: 0x040009CB RID: 2507
		IpsecThrottleDrop,
		// Token: 0x040009CC RID: 2508
		IpsecDospBlock = 13925,
		// Token: 0x040009CD RID: 2509
		IpsecDospReceivedMulticast,
		// Token: 0x040009CE RID: 2510
		IpsecDospInvalidPacket,
		// Token: 0x040009CF RID: 2511
		IpsecDospStateLookupFailed,
		// Token: 0x040009D0 RID: 2512
		IpsecDospMaxEntries,
		// Token: 0x040009D1 RID: 2513
		IpsecDospKeymodNotAllowed,
		// Token: 0x040009D2 RID: 2514
		IpsecDospNotInstalled,
		// Token: 0x040009D3 RID: 2515
		IpsecDospMaxPerIpRatelimitQueues,
		// Token: 0x040009D4 RID: 2516
		SxsSectionNotFound = 14000,
		// Token: 0x040009D5 RID: 2517
		SxsCantGenActctx,
		// Token: 0x040009D6 RID: 2518
		SxsInvalidActctxdataFormat,
		// Token: 0x040009D7 RID: 2519
		SxsAssemblyNotFound,
		// Token: 0x040009D8 RID: 2520
		SxsManifestFormatError,
		// Token: 0x040009D9 RID: 2521
		SxsManifestParseError,
		// Token: 0x040009DA RID: 2522
		SxsActivationContextDisabled,
		// Token: 0x040009DB RID: 2523
		SxsKeyNotFound,
		// Token: 0x040009DC RID: 2524
		SxsVersionConflict,
		// Token: 0x040009DD RID: 2525
		SxsWrongSectionType,
		// Token: 0x040009DE RID: 2526
		SxsThreadQueriesDisabled,
		// Token: 0x040009DF RID: 2527
		SxsProcessDefaultAlreadySet,
		// Token: 0x040009E0 RID: 2528
		SxsUnknownEncodingGroup,
		// Token: 0x040009E1 RID: 2529
		SxsUnknownEncoding,
		// Token: 0x040009E2 RID: 2530
		SxsInvalidXmlNamespaceUri,
		// Token: 0x040009E3 RID: 2531
		SxsRootManifestDependencyNotInstalled,
		// Token: 0x040009E4 RID: 2532
		SxsLeafManifestDependencyNotInstalled,
		// Token: 0x040009E5 RID: 2533
		SxsInvalidAssemblyIdentityAttribute,
		// Token: 0x040009E6 RID: 2534
		SxsManifestMissingRequiredDefaultNamespace,
		// Token: 0x040009E7 RID: 2535
		SxsManifestInvalidRequiredDefaultNamespace,
		// Token: 0x040009E8 RID: 2536
		SxsPrivateManifestCrossPathWithReparsePoint,
		// Token: 0x040009E9 RID: 2537
		SxsDuplicateDllName,
		// Token: 0x040009EA RID: 2538
		SxsDuplicateWindowclassName,
		// Token: 0x040009EB RID: 2539
		SxsDuplicateClsid,
		// Token: 0x040009EC RID: 2540
		SxsDuplicateIid,
		// Token: 0x040009ED RID: 2541
		SxsDuplicateTlbid,
		// Token: 0x040009EE RID: 2542
		SxsDuplicateProgid,
		// Token: 0x040009EF RID: 2543
		SxsDuplicateAssemblyName,
		// Token: 0x040009F0 RID: 2544
		SxsFileHashMismatch,
		// Token: 0x040009F1 RID: 2545
		SxsPolicyParseError,
		// Token: 0x040009F2 RID: 2546
		SxsXmlEMissingquote,
		// Token: 0x040009F3 RID: 2547
		SxsXmlECommentsyntax,
		// Token: 0x040009F4 RID: 2548
		SxsXmlEBadstartnamechar,
		// Token: 0x040009F5 RID: 2549
		SxsXmlEBadnamechar,
		// Token: 0x040009F6 RID: 2550
		SxsXmlEBadcharinstring,
		// Token: 0x040009F7 RID: 2551
		SxsXmlEXmldeclsyntax,
		// Token: 0x040009F8 RID: 2552
		SxsXmlEBadchardata,
		// Token: 0x040009F9 RID: 2553
		SxsXmlEMissingwhitespace,
		// Token: 0x040009FA RID: 2554
		SxsXmlEExpectingtagend,
		// Token: 0x040009FB RID: 2555
		SxsXmlEMissingsemicolon,
		// Token: 0x040009FC RID: 2556
		SxsXmlEUnbalancedparen,
		// Token: 0x040009FD RID: 2557
		SxsXmlEInternalerror,
		// Token: 0x040009FE RID: 2558
		SxsXmlEUnexpectedWhitespace,
		// Token: 0x040009FF RID: 2559
		SxsXmlEIncompleteEncoding,
		// Token: 0x04000A00 RID: 2560
		SxsXmlEMissingParen,
		// Token: 0x04000A01 RID: 2561
		SxsXmlEExpectingclosequote,
		// Token: 0x04000A02 RID: 2562
		SxsXmlEMultipleColons,
		// Token: 0x04000A03 RID: 2563
		SxsXmlEInvalidDecimal,
		// Token: 0x04000A04 RID: 2564
		SxsXmlEInvalidHexidecimal,
		// Token: 0x04000A05 RID: 2565
		SxsXmlEInvalidUnicode,
		// Token: 0x04000A06 RID: 2566
		SxsXmlEWhitespaceorquestionmark,
		// Token: 0x04000A07 RID: 2567
		SxsXmlEUnexpectedendtag,
		// Token: 0x04000A08 RID: 2568
		SxsXmlEUnclosedtag,
		// Token: 0x04000A09 RID: 2569
		SxsXmlEDuplicateattribute,
		// Token: 0x04000A0A RID: 2570
		SxsXmlEMultipleroots,
		// Token: 0x04000A0B RID: 2571
		SxsXmlEInvalidatrootlevel,
		// Token: 0x04000A0C RID: 2572
		SxsXmlEBadxmldecl,
		// Token: 0x04000A0D RID: 2573
		SxsXmlEMissingroot,
		// Token: 0x04000A0E RID: 2574
		SxsXmlEUnexpectedeof,
		// Token: 0x04000A0F RID: 2575
		SxsXmlEBadperefinsubset,
		// Token: 0x04000A10 RID: 2576
		SxsXmlEUnclosedstarttag,
		// Token: 0x04000A11 RID: 2577
		SxsXmlEUnclosedendtag,
		// Token: 0x04000A12 RID: 2578
		SxsXmlEUnclosedstring,
		// Token: 0x04000A13 RID: 2579
		SxsXmlEUnclosedcomment,
		// Token: 0x04000A14 RID: 2580
		SxsXmlEUncloseddecl,
		// Token: 0x04000A15 RID: 2581
		SxsXmlEUnclosedcdata,
		// Token: 0x04000A16 RID: 2582
		SxsXmlEReservednamespace,
		// Token: 0x04000A17 RID: 2583
		SxsXmlEInvalidencoding,
		// Token: 0x04000A18 RID: 2584
		SxsXmlEInvalidswitch,
		// Token: 0x04000A19 RID: 2585
		SxsXmlEBadxmlcase,
		// Token: 0x04000A1A RID: 2586
		SxsXmlEInvalidStandalone,
		// Token: 0x04000A1B RID: 2587
		SxsXmlEUnexpectedStandalone,
		// Token: 0x04000A1C RID: 2588
		SxsXmlEInvalidVersion,
		// Token: 0x04000A1D RID: 2589
		SxsXmlEMissingequals,
		// Token: 0x04000A1E RID: 2590
		SxsProtectionRecoveryFailed,
		// Token: 0x04000A1F RID: 2591
		SxsProtectionPublicKeyTooShort,
		// Token: 0x04000A20 RID: 2592
		SxsProtectionCatalogNotValid,
		// Token: 0x04000A21 RID: 2593
		SxsUntranslatableHresult,
		// Token: 0x04000A22 RID: 2594
		SxsProtectionCatalogFileMissing,
		// Token: 0x04000A23 RID: 2595
		SxsMissingAssemblyIdentityAttribute,
		// Token: 0x04000A24 RID: 2596
		SxsInvalidAssemblyIdentityAttributeName,
		// Token: 0x04000A25 RID: 2597
		SxsAssemblyMissing,
		// Token: 0x04000A26 RID: 2598
		SxsCorruptActivationStack,
		// Token: 0x04000A27 RID: 2599
		SxsCorruption,
		// Token: 0x04000A28 RID: 2600
		SxsEarlyDeactivation,
		// Token: 0x04000A29 RID: 2601
		SxsInvalidDeactivation,
		// Token: 0x04000A2A RID: 2602
		SxsMultipleDeactivation,
		// Token: 0x04000A2B RID: 2603
		SxsProcessTerminationRequested,
		// Token: 0x04000A2C RID: 2604
		SxsReleaseActivationContext,
		// Token: 0x04000A2D RID: 2605
		SxsSystemDefaultActivationContextEmpty,
		// Token: 0x04000A2E RID: 2606
		SxsInvalidIdentityAttributeValue,
		// Token: 0x04000A2F RID: 2607
		SxsInvalidIdentityAttributeName,
		// Token: 0x04000A30 RID: 2608
		SxsIdentityDuplicateAttribute,
		// Token: 0x04000A31 RID: 2609
		SxsIdentityParseError,
		// Token: 0x04000A32 RID: 2610
		MalformedSubstitutionString,
		// Token: 0x04000A33 RID: 2611
		SxsIncorrectPublicKeyToken,
		// Token: 0x04000A34 RID: 2612
		UnmappedSubstitutionString,
		// Token: 0x04000A35 RID: 2613
		SxsAssemblyNotLocked,
		// Token: 0x04000A36 RID: 2614
		SxsComponentStoreCorrupt,
		// Token: 0x04000A37 RID: 2615
		AdvancedInstallerFailed,
		// Token: 0x04000A38 RID: 2616
		XmlEncodingMismatch,
		// Token: 0x04000A39 RID: 2617
		SxsManifestIdentitySameButContentsDifferent,
		// Token: 0x04000A3A RID: 2618
		SxsIdentitiesDifferent,
		// Token: 0x04000A3B RID: 2619
		SxsAssemblyIsNotADeployment,
		// Token: 0x04000A3C RID: 2620
		SxsFileNotPartOfAssembly,
		// Token: 0x04000A3D RID: 2621
		SxsManifestTooBig,
		// Token: 0x04000A3E RID: 2622
		SxsSettingNotRegistered,
		// Token: 0x04000A3F RID: 2623
		SxsTransactionClosureIncomplete,
		// Token: 0x04000A40 RID: 2624
		SmiPrimitiveInstallerFailed,
		// Token: 0x04000A41 RID: 2625
		GenericCommandFailed,
		// Token: 0x04000A42 RID: 2626
		SxsFileHashMissing,
		// Token: 0x04000A43 RID: 2627
		EvtInvalidChannelPath = 15000,
		// Token: 0x04000A44 RID: 2628
		EvtInvalidQuery,
		// Token: 0x04000A45 RID: 2629
		EvtPublisherMetadataNotFound,
		// Token: 0x04000A46 RID: 2630
		EvtEventTemplateNotFound,
		// Token: 0x04000A47 RID: 2631
		EvtInvalidPublisherName,
		// Token: 0x04000A48 RID: 2632
		EvtInvalidEventData,
		// Token: 0x04000A49 RID: 2633
		EvtChannelNotFound = 15007,
		// Token: 0x04000A4A RID: 2634
		EvtMalformedXmlText,
		// Token: 0x04000A4B RID: 2635
		EvtSubscriptionToDirectChannel,
		// Token: 0x04000A4C RID: 2636
		EvtConfigurationError,
		// Token: 0x04000A4D RID: 2637
		EvtQueryResultStale,
		// Token: 0x04000A4E RID: 2638
		EvtQueryResultInvalidPosition,
		// Token: 0x04000A4F RID: 2639
		EvtNonValidatingMsxml,
		// Token: 0x04000A50 RID: 2640
		EvtFilterAlreadyscoped,
		// Token: 0x04000A51 RID: 2641
		EvtFilterNoteltset,
		// Token: 0x04000A52 RID: 2642
		EvtFilterInvarg,
		// Token: 0x04000A53 RID: 2643
		EvtFilterInvtest,
		// Token: 0x04000A54 RID: 2644
		EvtFilterInvtype,
		// Token: 0x04000A55 RID: 2645
		EvtFilterParseerr,
		// Token: 0x04000A56 RID: 2646
		EvtFilterUnsupportedop,
		// Token: 0x04000A57 RID: 2647
		EvtFilterUnexpectedtoken,
		// Token: 0x04000A58 RID: 2648
		EvtInvalidOperationOverEnabledDirectChannel,
		// Token: 0x04000A59 RID: 2649
		EvtInvalidChannelPropertyValue,
		// Token: 0x04000A5A RID: 2650
		EvtInvalidPublisherPropertyValue,
		// Token: 0x04000A5B RID: 2651
		EvtChannelCannotActivate,
		// Token: 0x04000A5C RID: 2652
		EvtFilterTooComplex,
		// Token: 0x04000A5D RID: 2653
		EvtMessageNotFound,
		// Token: 0x04000A5E RID: 2654
		EvtMessageIdNotFound,
		// Token: 0x04000A5F RID: 2655
		EvtUnresolvedValueInsert,
		// Token: 0x04000A60 RID: 2656
		EvtUnresolvedParameterInsert,
		// Token: 0x04000A61 RID: 2657
		EvtMaxInsertsReached,
		// Token: 0x04000A62 RID: 2658
		EvtEventDefinitionNotFound,
		// Token: 0x04000A63 RID: 2659
		EvtMessageLocaleNotFound,
		// Token: 0x04000A64 RID: 2660
		EvtVersionTooOld,
		// Token: 0x04000A65 RID: 2661
		EvtVersionTooNew,
		// Token: 0x04000A66 RID: 2662
		EvtCannotOpenChannelOfQuery,
		// Token: 0x04000A67 RID: 2663
		EvtPublisherDisabled,
		// Token: 0x04000A68 RID: 2664
		EvtFilterOutOfRange,
		// Token: 0x04000A69 RID: 2665
		EcSubscriptionCannotActivate = 15080,
		// Token: 0x04000A6A RID: 2666
		EcLogDisabled,
		// Token: 0x04000A6B RID: 2667
		EcCircularForwarding,
		// Token: 0x04000A6C RID: 2668
		EcCredstoreFull,
		// Token: 0x04000A6D RID: 2669
		EcCredNotFound,
		// Token: 0x04000A6E RID: 2670
		EcNoActiveChannel,
		// Token: 0x04000A6F RID: 2671
		MuiFileNotFound = 15100,
		// Token: 0x04000A70 RID: 2672
		MuiInvalidFile,
		// Token: 0x04000A71 RID: 2673
		MuiInvalidRcConfig,
		// Token: 0x04000A72 RID: 2674
		MuiInvalidLocaleName,
		// Token: 0x04000A73 RID: 2675
		MuiInvalidUltimatefallbackName,
		// Token: 0x04000A74 RID: 2676
		MuiFileNotLoaded,
		// Token: 0x04000A75 RID: 2677
		ResourceEnumUserStop,
		// Token: 0x04000A76 RID: 2678
		MuiIntlsettingsUilangNotInstalled,
		// Token: 0x04000A77 RID: 2679
		MuiIntlsettingsInvalidLocaleName,
		// Token: 0x04000A78 RID: 2680
		MrmRuntimeNoDefaultOrNeutralResource = 15110,
		// Token: 0x04000A79 RID: 2681
		MrmInvalidPriconfig,
		// Token: 0x04000A7A RID: 2682
		MrmInvalidFileType,
		// Token: 0x04000A7B RID: 2683
		MrmUnknownQualifier,
		// Token: 0x04000A7C RID: 2684
		MrmInvalidQualifierValue,
		// Token: 0x04000A7D RID: 2685
		MrmNoCandidate,
		// Token: 0x04000A7E RID: 2686
		MrmNoMatchOrDefaultCandidate,
		// Token: 0x04000A7F RID: 2687
		MrmResourceTypeMismatch,
		// Token: 0x04000A80 RID: 2688
		MrmDuplicateMapName,
		// Token: 0x04000A81 RID: 2689
		MrmDuplicateEntry,
		// Token: 0x04000A82 RID: 2690
		MrmInvalidResourceIdentifier,
		// Token: 0x04000A83 RID: 2691
		MrmFilepathTooLong,
		// Token: 0x04000A84 RID: 2692
		MrmUnsupportedDirectoryType,
		// Token: 0x04000A85 RID: 2693
		MrmInvalidPriFile = 15126,
		// Token: 0x04000A86 RID: 2694
		MrmNamedResourceNotFound,
		// Token: 0x04000A87 RID: 2695
		MrmMapNotFound = 15135,
		// Token: 0x04000A88 RID: 2696
		MrmUnsupportedProfileType,
		// Token: 0x04000A89 RID: 2697
		MrmInvalidQualifierOperator,
		// Token: 0x04000A8A RID: 2698
		MrmIndeterminateQualifierValue,
		// Token: 0x04000A8B RID: 2699
		MrmAutomergeEnabled,
		// Token: 0x04000A8C RID: 2700
		MrmTooManyResources,
		// Token: 0x04000A8D RID: 2701
		MrmUnsupportedFileTypeForMerge,
		// Token: 0x04000A8E RID: 2702
		MrmUnsupportedFileTypeForLoadUnloadPriFile,
		// Token: 0x04000A8F RID: 2703
		MrmNoCurrentViewOnThread,
		// Token: 0x04000A90 RID: 2704
		DifferentProfileResourceManagerExist,
		// Token: 0x04000A91 RID: 2705
		OperationNotAllowedFromSystemComponent,
		// Token: 0x04000A92 RID: 2706
		MrmDirectRefToNonDefaultResource,
		// Token: 0x04000A93 RID: 2707
		MrmGenerationCountMismatch,
		// Token: 0x04000A94 RID: 2708
		PriMergeVersionMismatch,
		// Token: 0x04000A95 RID: 2709
		PriMergeMissingSchema,
		// Token: 0x04000A96 RID: 2710
		PriMergeLoadFileFailed,
		// Token: 0x04000A97 RID: 2711
		PriMergeAddFileFailed,
		// Token: 0x04000A98 RID: 2712
		PriMergeWriteFileFailed,
		// Token: 0x04000A99 RID: 2713
		PriMergeMultiplePackageFamiliesNotAllowed,
		// Token: 0x04000A9A RID: 2714
		PriMergeMultipleMainPackagesNotAllowed,
		// Token: 0x04000A9B RID: 2715
		PriMergeBundlePackagesNotAllowed,
		// Token: 0x04000A9C RID: 2716
		PriMergeMainPackageRequired,
		// Token: 0x04000A9D RID: 2717
		PriMergeResourcePackageRequired,
		// Token: 0x04000A9E RID: 2718
		PriMergeInvalidFileName,
		// Token: 0x04000A9F RID: 2719
		McaInvalidCapabilitiesString = 15200,
		// Token: 0x04000AA0 RID: 2720
		McaInvalidVcpVersion,
		// Token: 0x04000AA1 RID: 2721
		McaMonitorViolatesMccsSpecification,
		// Token: 0x04000AA2 RID: 2722
		McaMccsVersionMismatch,
		// Token: 0x04000AA3 RID: 2723
		McaUnsupportedMccsVersion,
		// Token: 0x04000AA4 RID: 2724
		McaInternalError,
		// Token: 0x04000AA5 RID: 2725
		McaInvalidTechnologyTypeReturned,
		// Token: 0x04000AA6 RID: 2726
		McaUnsupportedColorTemperature,
		// Token: 0x04000AA7 RID: 2727
		AmbiguousSystemDevice = 15250,
		// Token: 0x04000AA8 RID: 2728
		SystemDeviceNotFound = 15299,
		// Token: 0x04000AA9 RID: 2729
		HashNotSupported,
		// Token: 0x04000AAA RID: 2730
		HashNotPresent,
		// Token: 0x04000AAB RID: 2731
		SecondaryIcProviderNotRegistered = 15321,
		// Token: 0x04000AAC RID: 2732
		GpioClientInformationInvalid,
		// Token: 0x04000AAD RID: 2733
		GpioVersionNotSupported,
		// Token: 0x04000AAE RID: 2734
		GpioInvalidRegistrationPacket,
		// Token: 0x04000AAF RID: 2735
		GpioOperationDenied,
		// Token: 0x04000AB0 RID: 2736
		GpioIncompatibleConnectMode,
		// Token: 0x04000AB1 RID: 2737
		GpioInterruptAlreadyUnmasked,
		// Token: 0x04000AB2 RID: 2738
		CannotSwitchRunlevel = 15400,
		// Token: 0x04000AB3 RID: 2739
		InvalidRunlevelSetting,
		// Token: 0x04000AB4 RID: 2740
		RunlevelSwitchTimeout,
		// Token: 0x04000AB5 RID: 2741
		RunlevelSwitchAgentTimeout,
		// Token: 0x04000AB6 RID: 2742
		RunlevelSwitchInProgress,
		// Token: 0x04000AB7 RID: 2743
		ServicesFailedAutostart,
		// Token: 0x04000AB8 RID: 2744
		ComTaskStopPending = 15501,
		// Token: 0x04000AB9 RID: 2745
		InstallOpenPackageFailed = 15600,
		// Token: 0x04000ABA RID: 2746
		InstallPackageNotFound,
		// Token: 0x04000ABB RID: 2747
		InstallInvalidPackage,
		// Token: 0x04000ABC RID: 2748
		InstallResolveDependencyFailed,
		// Token: 0x04000ABD RID: 2749
		InstallOutOfDiskSpace,
		// Token: 0x04000ABE RID: 2750
		InstallNetworkFailure,
		// Token: 0x04000ABF RID: 2751
		InstallRegistrationFailure,
		// Token: 0x04000AC0 RID: 2752
		InstallDeregistrationFailure,
		// Token: 0x04000AC1 RID: 2753
		InstallCancel,
		// Token: 0x04000AC2 RID: 2754
		InstallFailed,
		// Token: 0x04000AC3 RID: 2755
		RemoveFailed,
		// Token: 0x04000AC4 RID: 2756
		PackageAlreadyExists,
		// Token: 0x04000AC5 RID: 2757
		NeedsRemediation,
		// Token: 0x04000AC6 RID: 2758
		InstallPrerequisiteFailed,
		// Token: 0x04000AC7 RID: 2759
		PackageRepositoryCorrupted,
		// Token: 0x04000AC8 RID: 2760
		InstallPolicyFailure,
		// Token: 0x04000AC9 RID: 2761
		PackageUpdating,
		// Token: 0x04000ACA RID: 2762
		DeploymentBlockedByPolicy,
		// Token: 0x04000ACB RID: 2763
		PackagesInUse,
		// Token: 0x04000ACC RID: 2764
		RecoveryFileCorrupt,
		// Token: 0x04000ACD RID: 2765
		InvalidStagedSignature,
		// Token: 0x04000ACE RID: 2766
		DeletingExistingApplicationdataStoreFailed,
		// Token: 0x04000ACF RID: 2767
		InstallPackageDowngrade,
		// Token: 0x04000AD0 RID: 2768
		SystemNeedsRemediation,
		// Token: 0x04000AD1 RID: 2769
		AppxIntegrityFailureClrNgen,
		// Token: 0x04000AD2 RID: 2770
		ResiliencyFileCorrupt,
		// Token: 0x04000AD3 RID: 2771
		InstallFirewallServiceNotRunning,
		// Token: 0x04000AD4 RID: 2772
		PackageMoveFailed,
		// Token: 0x04000AD5 RID: 2773
		InstallVolumeNotEmpty,
		// Token: 0x04000AD6 RID: 2774
		InstallVolumeOffline,
		// Token: 0x04000AD7 RID: 2775
		InstallVolumeCorrupt,
		// Token: 0x04000AD8 RID: 2776
		NeedsRegistration,
		// Token: 0x04000AD9 RID: 2777
		InstallWrongProcessorArchitecture,
		// Token: 0x04000ADA RID: 2778
		DevSideloadLimitExceeded,
		// Token: 0x04000ADB RID: 2779
		InstallOptionalPackageRequiresMainPackage,
		// Token: 0x04000ADC RID: 2780
		PackageNotSupportedOnFilesystem,
		// Token: 0x04000ADD RID: 2781
		PackageMoveBlockedByStreaming,
		// Token: 0x04000ADE RID: 2782
		InstallOptionalPackageApplicationidNotUnique,
		// Token: 0x04000ADF RID: 2783
		PackageStagingOnhold,
		// Token: 0x04000AE0 RID: 2784
		InstallInvalidRelatedSetUpdate,
		// Token: 0x04000AE1 RID: 2785
		InstallOptionalPackageRequiresMainPackageFulltrustCapability,
		// Token: 0x04000AE2 RID: 2786
		DeploymentBlockedByUserLogOff,
		// Token: 0x04000AE3 RID: 2787
		ProvisionOptionalPackageRequiresMainPackageProvisioned,
		// Token: 0x04000AE4 RID: 2788
		PackagesReputationCheckFailed,
		// Token: 0x04000AE5 RID: 2789
		PackagesReputationCheckTimedout,
		// Token: 0x04000AE6 RID: 2790
		StateLoadStoreFailed = 15800,
		// Token: 0x04000AE7 RID: 2791
		StateGetVersionFailed,
		// Token: 0x04000AE8 RID: 2792
		StateSetVersionFailed,
		// Token: 0x04000AE9 RID: 2793
		StateStructuredResetFailed,
		// Token: 0x04000AEA RID: 2794
		StateOpenContainerFailed,
		// Token: 0x04000AEB RID: 2795
		StateCreateContainerFailed,
		// Token: 0x04000AEC RID: 2796
		StateDeleteContainerFailed,
		// Token: 0x04000AED RID: 2797
		StateReadSettingFailed,
		// Token: 0x04000AEE RID: 2798
		StateWriteSettingFailed,
		// Token: 0x04000AEF RID: 2799
		StateDeleteSettingFailed,
		// Token: 0x04000AF0 RID: 2800
		StateQuerySettingFailed,
		// Token: 0x04000AF1 RID: 2801
		StateReadCompositeSettingFailed,
		// Token: 0x04000AF2 RID: 2802
		StateWriteCompositeSettingFailed,
		// Token: 0x04000AF3 RID: 2803
		StateEnumerateContainerFailed,
		// Token: 0x04000AF4 RID: 2804
		StateEnumerateSettingsFailed,
		// Token: 0x04000AF5 RID: 2805
		StateCompositeSettingValueSizeLimitExceeded,
		// Token: 0x04000AF6 RID: 2806
		StateSettingValueSizeLimitExceeded,
		// Token: 0x04000AF7 RID: 2807
		StateSettingNameSizeLimitExceeded,
		// Token: 0x04000AF8 RID: 2808
		StateContainerNameSizeLimitExceeded,
		// Token: 0x04000AF9 RID: 2809
		ApiUnavailable = 15841,
		// Token: 0x04000AFA RID: 2810
		AuditingDisabled = -1073151999,
		// Token: 0x04000AFB RID: 2811
		AllSidsFiltered,
		// Token: 0x04000AFC RID: 2812
		BizrulesNotEnabled,
		// Token: 0x04000AFD RID: 2813
		CredRequiresConfirmation = -2146865127,
		// Token: 0x04000AFE RID: 2814
		FltIoComplete = 2031617,
		// Token: 0x04000AFF RID: 2815
		FltNoHandlerDefined = -2145452031,
		// Token: 0x04000B00 RID: 2816
		FltContextAlreadyDefined,
		// Token: 0x04000B01 RID: 2817
		FltInvalidAsynchronousRequest,
		// Token: 0x04000B02 RID: 2818
		FltDisallowFastIo,
		// Token: 0x04000B03 RID: 2819
		FltInvalidNameRequest,
		// Token: 0x04000B04 RID: 2820
		FltNotSafeToPostOperation,
		// Token: 0x04000B05 RID: 2821
		FltNotInitialized,
		// Token: 0x04000B06 RID: 2822
		FltFilterNotReady,
		// Token: 0x04000B07 RID: 2823
		FltPostOperationCleanup,
		// Token: 0x04000B08 RID: 2824
		FltInternalError,
		// Token: 0x04000B09 RID: 2825
		FltDeletingObject,
		// Token: 0x04000B0A RID: 2826
		FltMustBeNonpagedPool,
		// Token: 0x04000B0B RID: 2827
		FltDuplicateEntry,
		// Token: 0x04000B0C RID: 2828
		FltCbdqDisabled,
		// Token: 0x04000B0D RID: 2829
		FltDoNotAttach,
		// Token: 0x04000B0E RID: 2830
		FltDoNotDetach,
		// Token: 0x04000B0F RID: 2831
		FltInstanceAltitudeCollision,
		// Token: 0x04000B10 RID: 2832
		FltInstanceNameCollision,
		// Token: 0x04000B11 RID: 2833
		FltFilterNotFound,
		// Token: 0x04000B12 RID: 2834
		FltVolumeNotFound,
		// Token: 0x04000B13 RID: 2835
		FltInstanceNotFound,
		// Token: 0x04000B14 RID: 2836
		FltContextAllocationNotFound,
		// Token: 0x04000B15 RID: 2837
		FltInvalidContextRegistration,
		// Token: 0x04000B16 RID: 2838
		FltNameCacheMiss,
		// Token: 0x04000B17 RID: 2839
		FltNoDeviceObject,
		// Token: 0x04000B18 RID: 2840
		FltVolumeAlreadyMounted,
		// Token: 0x04000B19 RID: 2841
		FltAlreadyEnlisted,
		// Token: 0x04000B1A RID: 2842
		FltContextAlreadyLinked,
		// Token: 0x04000B1B RID: 2843
		FltNoWaiterForReply = -2145452000,
		// Token: 0x04000B1C RID: 2844
		FltRegistrationBusy = -2145451997,
		// Token: 0x04000B1D RID: 2845
		HungDisplayDriverThread = -2144993279,
		// Token: 0x04000B1E RID: 2846
		MonitorNoDescriptor = 2494465,
		// Token: 0x04000B1F RID: 2847
		MonitorUnknownDescriptorFormat,
		// Token: 0x04000B20 RID: 2848
		MonitorInvalidDescriptorChecksum = -1071247357,
		// Token: 0x04000B21 RID: 2849
		MonitorInvalidStandardTimingBlock,
		// Token: 0x04000B22 RID: 2850
		MonitorWmiDatablockRegistrationFailed,
		// Token: 0x04000B23 RID: 2851
		MonitorInvalidSerialNumberMondscBlock,
		// Token: 0x04000B24 RID: 2852
		MonitorInvalidUserFriendlyMondscBlock,
		// Token: 0x04000B25 RID: 2853
		MonitorNoMoreDescriptorData,
		// Token: 0x04000B26 RID: 2854
		MonitorInvalidDetailedTimingBlock,
		// Token: 0x04000B27 RID: 2855
		MonitorInvalidManufactureDate,
		// Token: 0x04000B28 RID: 2856
		GraphicsNotExclusiveModeOwner = -1071243264,
		// Token: 0x04000B29 RID: 2857
		GraphicsInsufficientDmaBuffer,
		// Token: 0x04000B2A RID: 2858
		GraphicsInvalidDisplayAdapter,
		// Token: 0x04000B2B RID: 2859
		GraphicsAdapterWasReset,
		// Token: 0x04000B2C RID: 2860
		GraphicsInvalidDriverModel,
		// Token: 0x04000B2D RID: 2861
		GraphicsPresentModeChanged,
		// Token: 0x04000B2E RID: 2862
		GraphicsPresentOccluded,
		// Token: 0x04000B2F RID: 2863
		GraphicsPresentDenied,
		// Token: 0x04000B30 RID: 2864
		GraphicsCannotcolorconvert,
		// Token: 0x04000B31 RID: 2865
		GraphicsDriverMismatch,
		// Token: 0x04000B32 RID: 2866
		GraphicsPartialDataPopulated = 1076240394,
		// Token: 0x04000B33 RID: 2867
		GraphicsPresentRedirectionDisabled = -1071243253,
		// Token: 0x04000B34 RID: 2868
		GraphicsPresentUnoccluded,
		// Token: 0x04000B35 RID: 2869
		GraphicsWindowdcNotAvailable,
		// Token: 0x04000B36 RID: 2870
		GraphicsWindowlessPresentDisabled,
		// Token: 0x04000B37 RID: 2871
		GraphicsNoVideoMemory = -1071243008,
		// Token: 0x04000B38 RID: 2872
		GraphicsCantLockMemory,
		// Token: 0x04000B39 RID: 2873
		GraphicsAllocationBusy,
		// Token: 0x04000B3A RID: 2874
		GraphicsTooManyReferences,
		// Token: 0x04000B3B RID: 2875
		GraphicsTryAgainLater,
		// Token: 0x04000B3C RID: 2876
		GraphicsTryAgainNow,
		// Token: 0x04000B3D RID: 2877
		GraphicsAllocationInvalid,
		// Token: 0x04000B3E RID: 2878
		GraphicsUnswizzlingApertureUnavailable,
		// Token: 0x04000B3F RID: 2879
		GraphicsUnswizzlingApertureUnsupported,
		// Token: 0x04000B40 RID: 2880
		GraphicsCantEvictPinnedAllocation,
		// Token: 0x04000B41 RID: 2881
		GraphicsInvalidAllocationUsage = -1071242992,
		// Token: 0x04000B42 RID: 2882
		GraphicsCantRenderLockedAllocation,
		// Token: 0x04000B43 RID: 2883
		GraphicsAllocationClosed,
		// Token: 0x04000B44 RID: 2884
		GraphicsInvalidAllocationInstance,
		// Token: 0x04000B45 RID: 2885
		GraphicsInvalidAllocationHandle,
		// Token: 0x04000B46 RID: 2886
		GraphicsWrongAllocationDevice,
		// Token: 0x04000B47 RID: 2887
		GraphicsAllocationContentLost,
		// Token: 0x04000B48 RID: 2888
		GraphicsGpuExceptionOnDevice = -1071242752,
		// Token: 0x04000B49 RID: 2889
		GraphicsSkipAllocationPreparation = 1076240897,
		// Token: 0x04000B4A RID: 2890
		GraphicsInvalidVidpnTopology = -1071242496,
		// Token: 0x04000B4B RID: 2891
		GraphicsVidpnTopologyNotSupported,
		// Token: 0x04000B4C RID: 2892
		GraphicsVidpnTopologyCurrentlyNotSupported,
		// Token: 0x04000B4D RID: 2893
		GraphicsInvalidVidpn,
		// Token: 0x04000B4E RID: 2894
		GraphicsInvalidVideoPresentSource,
		// Token: 0x04000B4F RID: 2895
		GraphicsInvalidVideoPresentTarget,
		// Token: 0x04000B50 RID: 2896
		GraphicsVidpnModalityNotSupported,
		// Token: 0x04000B51 RID: 2897
		GraphicsModeNotPinned = 2499335,
		// Token: 0x04000B52 RID: 2898
		GraphicsInvalidVidpnSourcemodeset = -1071242488,
		// Token: 0x04000B53 RID: 2899
		GraphicsInvalidVidpnTargetmodeset,
		// Token: 0x04000B54 RID: 2900
		GraphicsInvalidFrequency,
		// Token: 0x04000B55 RID: 2901
		GraphicsInvalidActiveRegion,
		// Token: 0x04000B56 RID: 2902
		GraphicsInvalidTotalRegion,
		// Token: 0x04000B57 RID: 2903
		GraphicsInvalidVideoPresentSourceMode = -1071242480,
		// Token: 0x04000B58 RID: 2904
		GraphicsInvalidVideoPresentTargetMode,
		// Token: 0x04000B59 RID: 2905
		GraphicsPinnedModeMustRemainInSet,
		// Token: 0x04000B5A RID: 2906
		GraphicsPathAlreadyInTopology,
		// Token: 0x04000B5B RID: 2907
		GraphicsModeAlreadyInModeset,
		// Token: 0x04000B5C RID: 2908
		GraphicsInvalidVideopresentsourceset,
		// Token: 0x04000B5D RID: 2909
		GraphicsInvalidVideopresenttargetset,
		// Token: 0x04000B5E RID: 2910
		GraphicsSourceAlreadyInSet,
		// Token: 0x04000B5F RID: 2911
		GraphicsTargetAlreadyInSet,
		// Token: 0x04000B60 RID: 2912
		GraphicsInvalidVidpnPresentPath,
		// Token: 0x04000B61 RID: 2913
		GraphicsNoRecommendedVidpnTopology,
		// Token: 0x04000B62 RID: 2914
		GraphicsInvalidMonitorFrequencyrangeset,
		// Token: 0x04000B63 RID: 2915
		GraphicsInvalidMonitorFrequencyrange,
		// Token: 0x04000B64 RID: 2916
		GraphicsFrequencyrangeNotInSet,
		// Token: 0x04000B65 RID: 2917
		GraphicsNoPreferredMode = 2499358,
		// Token: 0x04000B66 RID: 2918
		GraphicsFrequencyrangeAlreadyInSet = -1071242465,
		// Token: 0x04000B67 RID: 2919
		GraphicsStaleModeset,
		// Token: 0x04000B68 RID: 2920
		GraphicsInvalidMonitorSourcemodeset,
		// Token: 0x04000B69 RID: 2921
		GraphicsInvalidMonitorSourceMode,
		// Token: 0x04000B6A RID: 2922
		GraphicsNoRecommendedFunctionalVidpn,
		// Token: 0x04000B6B RID: 2923
		GraphicsModeIdMustBeUnique,
		// Token: 0x04000B6C RID: 2924
		GraphicsEmptyAdapterMonitorModeSupportIntersection,
		// Token: 0x04000B6D RID: 2925
		GraphicsVideoPresentTargetsLessThanSources,
		// Token: 0x04000B6E RID: 2926
		GraphicsPathNotInTopology,
		// Token: 0x04000B6F RID: 2927
		GraphicsAdapterMustHaveAtLeastOneSource,
		// Token: 0x04000B70 RID: 2928
		GraphicsAdapterMustHaveAtLeastOneTarget,
		// Token: 0x04000B71 RID: 2929
		GraphicsInvalidMonitordescriptorset,
		// Token: 0x04000B72 RID: 2930
		GraphicsInvalidMonitordescriptor,
		// Token: 0x04000B73 RID: 2931
		GraphicsMonitordescriptorNotInSet,
		// Token: 0x04000B74 RID: 2932
		GraphicsMonitordescriptorAlreadyInSet,
		// Token: 0x04000B75 RID: 2933
		GraphicsMonitordescriptorIdMustBeUnique,
		// Token: 0x04000B76 RID: 2934
		GraphicsInvalidVidpnTargetSubsetType,
		// Token: 0x04000B77 RID: 2935
		GraphicsResourcesNotRelated,
		// Token: 0x04000B78 RID: 2936
		GraphicsSourceIdMustBeUnique,
		// Token: 0x04000B79 RID: 2937
		GraphicsTargetIdMustBeUnique,
		// Token: 0x04000B7A RID: 2938
		GraphicsNoAvailableVidpnTarget,
		// Token: 0x04000B7B RID: 2939
		GraphicsMonitorCouldNotBeAssociatedWithAdapter,
		// Token: 0x04000B7C RID: 2940
		GraphicsNoVidpnmgr,
		// Token: 0x04000B7D RID: 2941
		GraphicsNoActiveVidpn,
		// Token: 0x04000B7E RID: 2942
		GraphicsStaleVidpnTopology,
		// Token: 0x04000B7F RID: 2943
		GraphicsMonitorNotConnected,
		// Token: 0x04000B80 RID: 2944
		GraphicsSourceNotInTopology,
		// Token: 0x04000B81 RID: 2945
		GraphicsInvalidPrimarysurfaceSize,
		// Token: 0x04000B82 RID: 2946
		GraphicsInvalidVisibleregionSize,
		// Token: 0x04000B83 RID: 2947
		GraphicsInvalidStride,
		// Token: 0x04000B84 RID: 2948
		GraphicsInvalidPixelformat,
		// Token: 0x04000B85 RID: 2949
		GraphicsInvalidColorbasis,
		// Token: 0x04000B86 RID: 2950
		GraphicsInvalidPixelvalueaccessmode,
		// Token: 0x04000B87 RID: 2951
		GraphicsTargetNotInTopology,
		// Token: 0x04000B88 RID: 2952
		GraphicsNoDisplayModeManagementSupport,
		// Token: 0x04000B89 RID: 2953
		GraphicsVidpnSourceInUse,
		// Token: 0x04000B8A RID: 2954
		GraphicsCantAccessActiveVidpn,
		// Token: 0x04000B8B RID: 2955
		GraphicsInvalidPathImportanceOrdinal,
		// Token: 0x04000B8C RID: 2956
		GraphicsInvalidPathContentGeometryTransformation,
		// Token: 0x04000B8D RID: 2957
		GraphicsPathContentGeometryTransformationNotSupported,
		// Token: 0x04000B8E RID: 2958
		GraphicsInvalidGammaRamp,
		// Token: 0x04000B8F RID: 2959
		GraphicsGammaRampNotSupported,
		// Token: 0x04000B90 RID: 2960
		GraphicsMultisamplingNotSupported,
		// Token: 0x04000B91 RID: 2961
		GraphicsModeNotInModeset,
		// Token: 0x04000B92 RID: 2962
		GraphicsDatasetIsEmpty = 2499403,
		// Token: 0x04000B93 RID: 2963
		GraphicsNoMoreElementsInDataset,
		// Token: 0x04000B94 RID: 2964
		GraphicsInvalidVidpnTopologyRecommendationReason = -1071242419,
		// Token: 0x04000B95 RID: 2965
		GraphicsInvalidPathContentType,
		// Token: 0x04000B96 RID: 2966
		GraphicsInvalidCopyprotectionType,
		// Token: 0x04000B97 RID: 2967
		GraphicsUnassignedModesetAlreadyExists,
		// Token: 0x04000B98 RID: 2968
		GraphicsPathContentGeometryTransformationNotPinned = 2499409,
		// Token: 0x04000B99 RID: 2969
		GraphicsInvalidScanlineOrdering = -1071242414,
		// Token: 0x04000B9A RID: 2970
		GraphicsTopologyChangesNotAllowed,
		// Token: 0x04000B9B RID: 2971
		GraphicsNoAvailableImportanceOrdinals,
		// Token: 0x04000B9C RID: 2972
		GraphicsIncompatiblePrivateFormat,
		// Token: 0x04000B9D RID: 2973
		GraphicsInvalidModePruningAlgorithm,
		// Token: 0x04000B9E RID: 2974
		GraphicsInvalidMonitorCapabilityOrigin,
		// Token: 0x04000B9F RID: 2975
		GraphicsInvalidMonitorFrequencyrangeConstraint,
		// Token: 0x04000BA0 RID: 2976
		GraphicsMaxNumPathsReached,
		// Token: 0x04000BA1 RID: 2977
		GraphicsCancelVidpnTopologyAugmentation,
		// Token: 0x04000BA2 RID: 2978
		GraphicsInvalidClientType,
		// Token: 0x04000BA3 RID: 2979
		GraphicsClientvidpnNotSet,
		// Token: 0x04000BA4 RID: 2980
		GraphicsSpecifiedChildAlreadyConnected = -1071242240,
		// Token: 0x04000BA5 RID: 2981
		GraphicsChildDescriptorNotSupported,
		// Token: 0x04000BA6 RID: 2982
		GraphicsUnknownChildStatus = 1076241455,
		// Token: 0x04000BA7 RID: 2983
		GraphicsNotALinkedAdapter = -1071242192,
		// Token: 0x04000BA8 RID: 2984
		GraphicsLeadlinkNotEnumerated,
		// Token: 0x04000BA9 RID: 2985
		GraphicsChainlinksNotEnumerated,
		// Token: 0x04000BAA RID: 2986
		GraphicsAdapterChainNotReady,
		// Token: 0x04000BAB RID: 2987
		GraphicsChainlinksNotStarted,
		// Token: 0x04000BAC RID: 2988
		GraphicsChainlinksNotPoweredOn,
		// Token: 0x04000BAD RID: 2989
		GraphicsInconsistentDeviceLinkState,
		// Token: 0x04000BAE RID: 2990
		GraphicsLeadlinkStartDeferred = 1076241463,
		// Token: 0x04000BAF RID: 2991
		GraphicsNotPostDeviceDriver = -1071242184,
		// Token: 0x04000BB0 RID: 2992
		GraphicsPollingTooFrequently = 1076241465,
		// Token: 0x04000BB1 RID: 2993
		GraphicsStartDeferred,
		// Token: 0x04000BB2 RID: 2994
		GraphicsAdapterAccessNotExcluded = -1071242181,
		// Token: 0x04000BB3 RID: 2995
		GraphicsDependableChildStatus = 1076241468,
		// Token: 0x04000BB4 RID: 2996
		GraphicsOpmNotSupported = -1071241984,
		// Token: 0x04000BB5 RID: 2997
		GraphicsCoppNotSupported,
		// Token: 0x04000BB6 RID: 2998
		GraphicsUabNotSupported,
		// Token: 0x04000BB7 RID: 2999
		GraphicsOpmInvalidEncryptedParameters,
		// Token: 0x04000BB8 RID: 3000
		GraphicsOpmNoVideoOutputsExist = -1071241979,
		// Token: 0x04000BB9 RID: 3001
		GraphicsOpmInternalError = -1071241973,
		// Token: 0x04000BBA RID: 3002
		GraphicsOpmInvalidHandle,
		// Token: 0x04000BBB RID: 3003
		GraphicsPvpInvalidCertificateLength = -1071241970,
		// Token: 0x04000BBC RID: 3004
		GraphicsOpmSpanningModeEnabled,
		// Token: 0x04000BBD RID: 3005
		GraphicsOpmTheaterModeEnabled,
		// Token: 0x04000BBE RID: 3006
		GraphicsPvpHfsFailed,
		// Token: 0x04000BBF RID: 3007
		GraphicsOpmInvalidSrm,
		// Token: 0x04000BC0 RID: 3008
		GraphicsOpmOutputDoesNotSupportHdcp,
		// Token: 0x04000BC1 RID: 3009
		GraphicsOpmOutputDoesNotSupportAcp,
		// Token: 0x04000BC2 RID: 3010
		GraphicsOpmOutputDoesNotSupportCgmsa,
		// Token: 0x04000BC3 RID: 3011
		GraphicsOpmHdcpSrmNeverSet,
		// Token: 0x04000BC4 RID: 3012
		GraphicsOpmResolutionTooHigh,
		// Token: 0x04000BC5 RID: 3013
		GraphicsOpmAllHdcpHardwareAlreadyInUse,
		// Token: 0x04000BC6 RID: 3014
		GraphicsOpmVideoOutputNoLongerExists = -1071241958,
		// Token: 0x04000BC7 RID: 3015
		GraphicsOpmSessionTypeChangeInProgress,
		// Token: 0x04000BC8 RID: 3016
		GraphicsOpmVideoOutputDoesNotHaveCoppSemantics,
		// Token: 0x04000BC9 RID: 3017
		GraphicsOpmInvalidInformationRequest,
		// Token: 0x04000BCA RID: 3018
		GraphicsOpmDriverInternalError,
		// Token: 0x04000BCB RID: 3019
		GraphicsOpmVideoOutputDoesNotHaveOpmSemantics,
		// Token: 0x04000BCC RID: 3020
		GraphicsOpmSignalingNotSupported,
		// Token: 0x04000BCD RID: 3021
		GraphicsOpmInvalidConfigurationRequest,
		// Token: 0x04000BCE RID: 3022
		GraphicsI2CNotSupported = -1071241856,
		// Token: 0x04000BCF RID: 3023
		GraphicsI2CDeviceDoesNotExist,
		// Token: 0x04000BD0 RID: 3024
		GraphicsI2CErrorTransmittingData,
		// Token: 0x04000BD1 RID: 3025
		GraphicsI2CErrorReceivingData,
		// Token: 0x04000BD2 RID: 3026
		GraphicsDdcciVcpNotSupported,
		// Token: 0x04000BD3 RID: 3027
		GraphicsDdcciInvalidData,
		// Token: 0x04000BD4 RID: 3028
		GraphicsDdcciMonitorReturnedInvalidTimingStatusByte,
		// Token: 0x04000BD5 RID: 3029
		GraphicsMcaInvalidCapabilitiesString,
		// Token: 0x04000BD6 RID: 3030
		GraphicsMcaInternalError,
		// Token: 0x04000BD7 RID: 3031
		GraphicsDdcciInvalidMessageCommand,
		// Token: 0x04000BD8 RID: 3032
		GraphicsDdcciInvalidMessageLength,
		// Token: 0x04000BD9 RID: 3033
		GraphicsDdcciInvalidMessageChecksum,
		// Token: 0x04000BDA RID: 3034
		GraphicsInvalidPhysicalMonitorHandle,
		// Token: 0x04000BDB RID: 3035
		GraphicsMonitorNoLongerExists,
		// Token: 0x04000BDC RID: 3036
		GraphicsDdcciCurrentCurrentValueGreaterThanMaximumValue = -1071241768,
		// Token: 0x04000BDD RID: 3037
		GraphicsMcaInvalidVcpVersion,
		// Token: 0x04000BDE RID: 3038
		GraphicsMcaMonitorViolatesMccsSpecification,
		// Token: 0x04000BDF RID: 3039
		GraphicsMcaMccsVersionMismatch,
		// Token: 0x04000BE0 RID: 3040
		GraphicsMcaUnsupportedMccsVersion,
		// Token: 0x04000BE1 RID: 3041
		GraphicsMcaInvalidTechnologyTypeReturned = -1071241762,
		// Token: 0x04000BE2 RID: 3042
		GraphicsMcaUnsupportedColorTemperature,
		// Token: 0x04000BE3 RID: 3043
		GraphicsOnlyConsoleSessionSupported,
		// Token: 0x04000BE4 RID: 3044
		GraphicsNoDisplayDeviceCorrespondsToName,
		// Token: 0x04000BE5 RID: 3045
		GraphicsDisplayDeviceNotAttachedToDesktop,
		// Token: 0x04000BE6 RID: 3046
		GraphicsMirroringDevicesNotSupported,
		// Token: 0x04000BE7 RID: 3047
		GraphicsInvalidPointer,
		// Token: 0x04000BE8 RID: 3048
		GraphicsNoMonitorsCorrespondToDisplayDevice,
		// Token: 0x04000BE9 RID: 3049
		GraphicsParameterArrayTooSmall,
		// Token: 0x04000BEA RID: 3050
		GraphicsInternalError,
		// Token: 0x04000BEB RID: 3051
		GraphicsSessionTypeChangeInProgress = -1071249944,
		// Token: 0x04000BEC RID: 3052
		NdisInterfaceClosing = -2144075774,
		// Token: 0x04000BED RID: 3053
		NdisBadVersion = -2144075772,
		// Token: 0x04000BEE RID: 3054
		NdisBadCharacteristics,
		// Token: 0x04000BEF RID: 3055
		NdisAdapterNotFound,
		// Token: 0x04000BF0 RID: 3056
		NdisOpenFailed,
		// Token: 0x04000BF1 RID: 3057
		NdisDeviceFailed,
		// Token: 0x04000BF2 RID: 3058
		NdisMulticastFull,
		// Token: 0x04000BF3 RID: 3059
		NdisMulticastExists,
		// Token: 0x04000BF4 RID: 3060
		NdisMulticastNotFound,
		// Token: 0x04000BF5 RID: 3061
		NdisRequestAborted,
		// Token: 0x04000BF6 RID: 3062
		NdisResetInProgress,
		// Token: 0x04000BF7 RID: 3063
		NdisNotSupported = -2144075589,
		// Token: 0x04000BF8 RID: 3064
		NdisInvalidPacket = -2144075761,
		// Token: 0x04000BF9 RID: 3065
		NdisAdapterNotReady = -2144075759,
		// Token: 0x04000BFA RID: 3066
		NdisInvalidLength = -2144075756,
		// Token: 0x04000BFB RID: 3067
		NdisInvalidData,
		// Token: 0x04000BFC RID: 3068
		NdisBufferTooShort,
		// Token: 0x04000BFD RID: 3069
		NdisInvalidOid,
		// Token: 0x04000BFE RID: 3070
		NdisAdapterRemoved,
		// Token: 0x04000BFF RID: 3071
		NdisUnsupportedMedia,
		// Token: 0x04000C00 RID: 3072
		NdisGroupAddressInUse,
		// Token: 0x04000C01 RID: 3073
		NdisFileNotFound,
		// Token: 0x04000C02 RID: 3074
		NdisErrorReadingFile,
		// Token: 0x04000C03 RID: 3075
		NdisAlreadyMapped,
		// Token: 0x04000C04 RID: 3076
		NdisResourceConflict,
		// Token: 0x04000C05 RID: 3077
		NdisMediaDisconnected,
		// Token: 0x04000C06 RID: 3078
		NdisInvalidAddress = -2144075742,
		// Token: 0x04000C07 RID: 3079
		NdisInvalidDeviceRequest = -2144075760,
		// Token: 0x04000C08 RID: 3080
		NdisPaused = -2144075734,
		// Token: 0x04000C09 RID: 3081
		NdisInterfaceNotFound,
		// Token: 0x04000C0A RID: 3082
		NdisUnsupportedRevision,
		// Token: 0x04000C0B RID: 3083
		NdisInvalidPort,
		// Token: 0x04000C0C RID: 3084
		NdisInvalidPortState,
		// Token: 0x04000C0D RID: 3085
		NdisLowPowerState,
		// Token: 0x04000C0E RID: 3086
		NdisReinitRequired,
		// Token: 0x04000C0F RID: 3087
		NdisDot11AutoConfigEnabled = -2144067584,
		// Token: 0x04000C10 RID: 3088
		NdisDot11MediaInUse,
		// Token: 0x04000C11 RID: 3089
		NdisDot11PowerStateInvalid,
		// Token: 0x04000C12 RID: 3090
		NdisPmWolPatternListFull,
		// Token: 0x04000C13 RID: 3091
		NdisPmProtocolOffloadListFull,
		// Token: 0x04000C14 RID: 3092
		NdisDot11ApChannelCurrentlyNotAvailable,
		// Token: 0x04000C15 RID: 3093
		NdisDot11ApBandCurrentlyNotAvailable,
		// Token: 0x04000C16 RID: 3094
		NdisDot11ApChannelNotAllowed,
		// Token: 0x04000C17 RID: 3095
		NdisDot11ApBandNotAllowed,
		// Token: 0x04000C18 RID: 3096
		NdisIndicationRequired = 3407873,
		// Token: 0x04000C19 RID: 3097
		NdisOffloadPolicy = -1070329841,
		// Token: 0x04000C1A RID: 3098
		NdisOffloadConnectionRejected = -1070329838,
		// Token: 0x04000C1B RID: 3099
		NdisOffloadPathRejected,
		// Token: 0x04000C1C RID: 3100
		HvInvalidHypercallCode = -1070268414,
		// Token: 0x04000C1D RID: 3101
		HvInvalidHypercallInput,
		// Token: 0x04000C1E RID: 3102
		HvInvalidAlignment,
		// Token: 0x04000C1F RID: 3103
		HvInvalidParameter,
		// Token: 0x04000C20 RID: 3104
		HvAccessDenied,
		// Token: 0x04000C21 RID: 3105
		HvInvalidPartitionState,
		// Token: 0x04000C22 RID: 3106
		HvOperationDenied,
		// Token: 0x04000C23 RID: 3107
		HvUnknownProperty,
		// Token: 0x04000C24 RID: 3108
		HvPropertyValueOutOfRange,
		// Token: 0x04000C25 RID: 3109
		HvInsufficientMemory,
		// Token: 0x04000C26 RID: 3110
		HvPartitionTooDeep,
		// Token: 0x04000C27 RID: 3111
		HvInvalidPartitionId,
		// Token: 0x04000C28 RID: 3112
		HvInvalidVpIndex,
		// Token: 0x04000C29 RID: 3113
		HvInvalidPortId = -1070268399,
		// Token: 0x04000C2A RID: 3114
		HvInvalidConnectionId,
		// Token: 0x04000C2B RID: 3115
		HvInsufficientBuffers,
		// Token: 0x04000C2C RID: 3116
		HvNotAcknowledged,
		// Token: 0x04000C2D RID: 3117
		HvInvalidVpState,
		// Token: 0x04000C2E RID: 3118
		HvAcknowledged,
		// Token: 0x04000C2F RID: 3119
		HvInvalidSaveRestoreState,
		// Token: 0x04000C30 RID: 3120
		HvInvalidSynicState,
		// Token: 0x04000C31 RID: 3121
		HvObjectInUse,
		// Token: 0x04000C32 RID: 3122
		HvInvalidProximityDomainInfo,
		// Token: 0x04000C33 RID: 3123
		HvNoData,
		// Token: 0x04000C34 RID: 3124
		HvInactive,
		// Token: 0x04000C35 RID: 3125
		HvNoResources,
		// Token: 0x04000C36 RID: 3126
		HvFeatureUnavailable,
		// Token: 0x04000C37 RID: 3127
		HvInsufficientBuffer = -1070268365,
		// Token: 0x04000C38 RID: 3128
		HvInsufficientDeviceDomains = -1070268360,
		// Token: 0x04000C39 RID: 3129
		HvCpuidFeatureValidation = -1070268356,
		// Token: 0x04000C3A RID: 3130
		HvCpuidXsaveFeatureValidation,
		// Token: 0x04000C3B RID: 3131
		HvProcessorStartupTimeout,
		// Token: 0x04000C3C RID: 3132
		HvSmxEnabled,
		// Token: 0x04000C3D RID: 3133
		HvInvalidLpIndex = -1070268351,
		// Token: 0x04000C3E RID: 3134
		HvInvalidRegisterValue = -1070268336,
		// Token: 0x04000C3F RID: 3135
		HvInvalidVtlState,
		// Token: 0x04000C40 RID: 3136
		HvNxNotDetected = -1070268331,
		// Token: 0x04000C41 RID: 3137
		HvInvalidDeviceId = -1070268329,
		// Token: 0x04000C42 RID: 3138
		HvInvalidDeviceState,
		// Token: 0x04000C43 RID: 3139
		HvPendingPageRequests = 3473497,
		// Token: 0x04000C44 RID: 3140
		HvPageRequestInvalid = -1070268320,
		// Token: 0x04000C45 RID: 3141
		HvInvalidCpuGroupId = -1070268305,
		// Token: 0x04000C46 RID: 3142
		HvInvalidCpuGroupState,
		// Token: 0x04000C47 RID: 3143
		HvOperationFailed,
		// Token: 0x04000C48 RID: 3144
		HvNotAllowedWithNestedVirtActive,
		// Token: 0x04000C49 RID: 3145
		HvNotPresent = -1070264320,
		// Token: 0x04000C4A RID: 3146
		VidDuplicateHandler = -1070137343,
		// Token: 0x04000C4B RID: 3147
		VidTooManyHandlers,
		// Token: 0x04000C4C RID: 3148
		VidQueueFull,
		// Token: 0x04000C4D RID: 3149
		VidHandlerNotPresent,
		// Token: 0x04000C4E RID: 3150
		VidInvalidObjectName,
		// Token: 0x04000C4F RID: 3151
		VidPartitionNameTooLong,
		// Token: 0x04000C50 RID: 3152
		VidMessageQueueNameTooLong,
		// Token: 0x04000C51 RID: 3153
		VidPartitionAlreadyExists,
		// Token: 0x04000C52 RID: 3154
		VidPartitionDoesNotExist,
		// Token: 0x04000C53 RID: 3155
		VidPartitionNameNotFound,
		// Token: 0x04000C54 RID: 3156
		VidMessageQueueAlreadyExists,
		// Token: 0x04000C55 RID: 3157
		VidExceededMbpEntryMapLimit,
		// Token: 0x04000C56 RID: 3158
		VidMbStillReferenced,
		// Token: 0x04000C57 RID: 3159
		VidChildGpaPageSetCorrupted,
		// Token: 0x04000C58 RID: 3160
		VidInvalidNumaSettings,
		// Token: 0x04000C59 RID: 3161
		VidInvalidNumaNodeIndex,
		// Token: 0x04000C5A RID: 3162
		VidNotificationQueueAlreadyAssociated,
		// Token: 0x04000C5B RID: 3163
		VidInvalidMemoryBlockHandle,
		// Token: 0x04000C5C RID: 3164
		VidPageRangeOverflow,
		// Token: 0x04000C5D RID: 3165
		VidInvalidMessageQueueHandle,
		// Token: 0x04000C5E RID: 3166
		VidInvalidGpaRangeHandle,
		// Token: 0x04000C5F RID: 3167
		VidNoMemoryBlockNotificationQueue,
		// Token: 0x04000C60 RID: 3168
		VidMemoryBlockLockCountExceeded,
		// Token: 0x04000C61 RID: 3169
		VidInvalidPpmHandle,
		// Token: 0x04000C62 RID: 3170
		VidMbpsAreLocked,
		// Token: 0x04000C63 RID: 3171
		VidMessageQueueClosed,
		// Token: 0x04000C64 RID: 3172
		VidVirtualProcessorLimitExceeded,
		// Token: 0x04000C65 RID: 3173
		VidStopPending,
		// Token: 0x04000C66 RID: 3174
		VidInvalidProcessorState,
		// Token: 0x04000C67 RID: 3175
		VidExceededKmContextCountLimit,
		// Token: 0x04000C68 RID: 3176
		VidKmInterfaceAlreadyInitialized,
		// Token: 0x04000C69 RID: 3177
		VidMbPropertyAlreadySetReset,
		// Token: 0x04000C6A RID: 3178
		VidMmioRangeDestroyed,
		// Token: 0x04000C6B RID: 3179
		VidInvalidChildGpaPageSet,
		// Token: 0x04000C6C RID: 3180
		VidReservePageSetIsBeingUsed,
		// Token: 0x04000C6D RID: 3181
		VidReservePageSetTooSmall,
		// Token: 0x04000C6E RID: 3182
		VidMbpAlreadyLockedUsingReservedPage,
		// Token: 0x04000C6F RID: 3183
		VidMbpCountExceededLimit,
		// Token: 0x04000C70 RID: 3184
		VidSavedStateCorrupt,
		// Token: 0x04000C71 RID: 3185
		VidSavedStateUnrecognizedItem,
		// Token: 0x04000C72 RID: 3186
		VidSavedStateIncompatible,
		// Token: 0x04000C73 RID: 3187
		VidVtlAccessDenied,
		// Token: 0x04000C74 RID: 3188
		VmcomputeTerminatedDuringStart = -1070137088,
		// Token: 0x04000C75 RID: 3189
		VmcomputeImageMismatch,
		// Token: 0x04000C76 RID: 3190
		VmcomputeHypervNotInstalled,
		// Token: 0x04000C77 RID: 3191
		VmcomputeOperationPending,
		// Token: 0x04000C78 RID: 3192
		VmcomputeTooManyNotifications,
		// Token: 0x04000C79 RID: 3193
		VmcomputeInvalidState,
		// Token: 0x04000C7A RID: 3194
		VmcomputeUnexpectedExit,
		// Token: 0x04000C7B RID: 3195
		VmcomputeTerminated,
		// Token: 0x04000C7C RID: 3196
		VmcomputeConnectFailed,
		// Token: 0x04000C7D RID: 3197
		VmcomputeTimeout,
		// Token: 0x04000C7E RID: 3198
		VmcomputeConnectionClosed,
		// Token: 0x04000C7F RID: 3199
		VmcomputeUnknownMessage,
		// Token: 0x04000C80 RID: 3200
		VmcomputeUnsupportedProtocolVersion,
		// Token: 0x04000C81 RID: 3201
		VmcomputeInvalidJson,
		// Token: 0x04000C82 RID: 3202
		VmcomputeSystemNotFound,
		// Token: 0x04000C83 RID: 3203
		VmcomputeSystemAlreadyExists,
		// Token: 0x04000C84 RID: 3204
		VmcomputeSystemAlreadyStopped,
		// Token: 0x04000C85 RID: 3205
		VmcomputeProtocolError,
		// Token: 0x04000C86 RID: 3206
		VmcomputeInvalidLayer,
		// Token: 0x04000C87 RID: 3207
		VmcomputeWindowsInsiderRequired,
		// Token: 0x04000C88 RID: 3208
		VnetVirtualSwitchNameNotFound = -1070136832,
		// Token: 0x04000C89 RID: 3209
		VidRemoteNodeParentGpaPagesUsed = -2143879167,
		// Token: 0x04000C8A RID: 3210
		VolmgrIncompleteRegeneration = -2143813631,
		// Token: 0x04000C8B RID: 3211
		VolmgrIncompleteDiskMigration,
		// Token: 0x04000C8C RID: 3212
		VolmgrDatabaseFull = -1070071807,
		// Token: 0x04000C8D RID: 3213
		VolmgrDiskConfigurationCorrupted,
		// Token: 0x04000C8E RID: 3214
		VolmgrDiskConfigurationNotInSync,
		// Token: 0x04000C8F RID: 3215
		VolmgrPackConfigUpdateFailed,
		// Token: 0x04000C90 RID: 3216
		VolmgrDiskContainsNonSimpleVolume,
		// Token: 0x04000C91 RID: 3217
		VolmgrDiskDuplicate,
		// Token: 0x04000C92 RID: 3218
		VolmgrDiskDynamic,
		// Token: 0x04000C93 RID: 3219
		VolmgrDiskIdInvalid,
		// Token: 0x04000C94 RID: 3220
		VolmgrDiskInvalid,
		// Token: 0x04000C95 RID: 3221
		VolmgrDiskLastVoter,
		// Token: 0x04000C96 RID: 3222
		VolmgrDiskLayoutInvalid,
		// Token: 0x04000C97 RID: 3223
		VolmgrDiskLayoutNonBasicBetweenBasicPartitions,
		// Token: 0x04000C98 RID: 3224
		VolmgrDiskLayoutNotCylinderAligned,
		// Token: 0x04000C99 RID: 3225
		VolmgrDiskLayoutPartitionsTooSmall,
		// Token: 0x04000C9A RID: 3226
		VolmgrDiskLayoutPrimaryBetweenLogicalPartitions,
		// Token: 0x04000C9B RID: 3227
		VolmgrDiskLayoutTooManyPartitions,
		// Token: 0x04000C9C RID: 3228
		VolmgrDiskMissing,
		// Token: 0x04000C9D RID: 3229
		VolmgrDiskNotEmpty,
		// Token: 0x04000C9E RID: 3230
		VolmgrDiskNotEnoughSpace,
		// Token: 0x04000C9F RID: 3231
		VolmgrDiskRevectoringFailed,
		// Token: 0x04000CA0 RID: 3232
		VolmgrDiskSectorSizeInvalid,
		// Token: 0x04000CA1 RID: 3233
		VolmgrDiskSetNotContained,
		// Token: 0x04000CA2 RID: 3234
		VolmgrDiskUsedByMultipleMembers,
		// Token: 0x04000CA3 RID: 3235
		VolmgrDiskUsedByMultiplePlexes,
		// Token: 0x04000CA4 RID: 3236
		VolmgrDynamicDiskNotSupported,
		// Token: 0x04000CA5 RID: 3237
		VolmgrExtentAlreadyUsed,
		// Token: 0x04000CA6 RID: 3238
		VolmgrExtentNotContiguous,
		// Token: 0x04000CA7 RID: 3239
		VolmgrExtentNotInPublicRegion,
		// Token: 0x04000CA8 RID: 3240
		VolmgrExtentNotSectorAligned,
		// Token: 0x04000CA9 RID: 3241
		VolmgrExtentOverlapsEbrPartition,
		// Token: 0x04000CAA RID: 3242
		VolmgrExtentVolumeLengthsDoNotMatch,
		// Token: 0x04000CAB RID: 3243
		VolmgrFaultTolerantNotSupported,
		// Token: 0x04000CAC RID: 3244
		VolmgrInterleaveLengthInvalid,
		// Token: 0x04000CAD RID: 3245
		VolmgrMaximumRegisteredUsers,
		// Token: 0x04000CAE RID: 3246
		VolmgrMemberInSync,
		// Token: 0x04000CAF RID: 3247
		VolmgrMemberIndexDuplicate,
		// Token: 0x04000CB0 RID: 3248
		VolmgrMemberIndexInvalid,
		// Token: 0x04000CB1 RID: 3249
		VolmgrMemberMissing,
		// Token: 0x04000CB2 RID: 3250
		VolmgrMemberNotDetached,
		// Token: 0x04000CB3 RID: 3251
		VolmgrMemberRegenerating,
		// Token: 0x04000CB4 RID: 3252
		VolmgrAllDisksFailed,
		// Token: 0x04000CB5 RID: 3253
		VolmgrNoRegisteredUsers,
		// Token: 0x04000CB6 RID: 3254
		VolmgrNoSuchUser,
		// Token: 0x04000CB7 RID: 3255
		VolmgrNotificationReset,
		// Token: 0x04000CB8 RID: 3256
		VolmgrNumberOfMembersInvalid,
		// Token: 0x04000CB9 RID: 3257
		VolmgrNumberOfPlexesInvalid,
		// Token: 0x04000CBA RID: 3258
		VolmgrPackDuplicate,
		// Token: 0x04000CBB RID: 3259
		VolmgrPackIdInvalid,
		// Token: 0x04000CBC RID: 3260
		VolmgrPackInvalid,
		// Token: 0x04000CBD RID: 3261
		VolmgrPackNameInvalid,
		// Token: 0x04000CBE RID: 3262
		VolmgrPackOffline,
		// Token: 0x04000CBF RID: 3263
		VolmgrPackHasQuorum,
		// Token: 0x04000CC0 RID: 3264
		VolmgrPackWithoutQuorum,
		// Token: 0x04000CC1 RID: 3265
		VolmgrPartitionStyleInvalid,
		// Token: 0x04000CC2 RID: 3266
		VolmgrPartitionUpdateFailed,
		// Token: 0x04000CC3 RID: 3267
		VolmgrPlexInSync,
		// Token: 0x04000CC4 RID: 3268
		VolmgrPlexIndexDuplicate,
		// Token: 0x04000CC5 RID: 3269
		VolmgrPlexIndexInvalid,
		// Token: 0x04000CC6 RID: 3270
		VolmgrPlexLastActive,
		// Token: 0x04000CC7 RID: 3271
		VolmgrPlexMissing,
		// Token: 0x04000CC8 RID: 3272
		VolmgrPlexRegenerating,
		// Token: 0x04000CC9 RID: 3273
		VolmgrPlexTypeInvalid,
		// Token: 0x04000CCA RID: 3274
		VolmgrPlexNotRaid5,
		// Token: 0x04000CCB RID: 3275
		VolmgrPlexNotSimple,
		// Token: 0x04000CCC RID: 3276
		VolmgrStructureSizeInvalid,
		// Token: 0x04000CCD RID: 3277
		VolmgrTooManyNotificationRequests,
		// Token: 0x04000CCE RID: 3278
		VolmgrTransactionInProgress,
		// Token: 0x04000CCF RID: 3279
		VolmgrUnexpectedDiskLayoutChange,
		// Token: 0x04000CD0 RID: 3280
		VolmgrVolumeContainsMissingDisk,
		// Token: 0x04000CD1 RID: 3281
		VolmgrVolumeIdInvalid,
		// Token: 0x04000CD2 RID: 3282
		VolmgrVolumeLengthInvalid,
		// Token: 0x04000CD3 RID: 3283
		VolmgrVolumeLengthNotSectorSizeMultiple,
		// Token: 0x04000CD4 RID: 3284
		VolmgrVolumeNotMirrored,
		// Token: 0x04000CD5 RID: 3285
		VolmgrVolumeNotRetained,
		// Token: 0x04000CD6 RID: 3286
		VolmgrVolumeOffline,
		// Token: 0x04000CD7 RID: 3287
		VolmgrVolumeRetained,
		// Token: 0x04000CD8 RID: 3288
		VolmgrNumberOfExtentsInvalid,
		// Token: 0x04000CD9 RID: 3289
		VolmgrDifferentSectorSize,
		// Token: 0x04000CDA RID: 3290
		VolmgrBadBootDisk,
		// Token: 0x04000CDB RID: 3291
		VolmgrPackConfigOffline,
		// Token: 0x04000CDC RID: 3292
		VolmgrPackConfigOnline,
		// Token: 0x04000CDD RID: 3293
		VolmgrNotPrimaryPack,
		// Token: 0x04000CDE RID: 3294
		VolmgrPackLogUpdateFailed,
		// Token: 0x04000CDF RID: 3295
		VolmgrNumberOfDisksInPlexInvalid,
		// Token: 0x04000CE0 RID: 3296
		VolmgrNumberOfDisksInMemberInvalid,
		// Token: 0x04000CE1 RID: 3297
		VolmgrVolumeMirrored,
		// Token: 0x04000CE2 RID: 3298
		VolmgrPlexNotSimpleSpanned,
		// Token: 0x04000CE3 RID: 3299
		VolmgrNoValidLogCopies,
		// Token: 0x04000CE4 RID: 3300
		VolmgrPrimaryPackPresent,
		// Token: 0x04000CE5 RID: 3301
		VolmgrNumberOfDisksInvalid,
		// Token: 0x04000CE6 RID: 3302
		VolmgrMirrorNotSupported,
		// Token: 0x04000CE7 RID: 3303
		VolmgrRaid5NotSupported,
		// Token: 0x04000CE8 RID: 3304
		BcdNotAllEntriesImported = -2143748095,
		// Token: 0x04000CE9 RID: 3305
		BcdTooManyElements = -1070006270,
		// Token: 0x04000CEA RID: 3306
		BcdNotAllEntriesSynchronized = -2143748093,
		// Token: 0x04000CEB RID: 3307
		VhdDriveFooterMissing = -1069940735,
		// Token: 0x04000CEC RID: 3308
		VhdDriveFooterChecksumMismatch,
		// Token: 0x04000CED RID: 3309
		VhdDriveFooterCorrupt,
		// Token: 0x04000CEE RID: 3310
		VhdFormatUnknown,
		// Token: 0x04000CEF RID: 3311
		VhdFormatUnsupportedVersion,
		// Token: 0x04000CF0 RID: 3312
		VhdSparseHeaderChecksumMismatch,
		// Token: 0x04000CF1 RID: 3313
		VhdSparseHeaderUnsupportedVersion,
		// Token: 0x04000CF2 RID: 3314
		VhdSparseHeaderCorrupt,
		// Token: 0x04000CF3 RID: 3315
		VhdBlockAllocationFailure,
		// Token: 0x04000CF4 RID: 3316
		VhdBlockAllocationTableCorrupt,
		// Token: 0x04000CF5 RID: 3317
		VhdInvalidBlockSize,
		// Token: 0x04000CF6 RID: 3318
		VhdBitmapMismatch,
		// Token: 0x04000CF7 RID: 3319
		VhdParentVhdNotFound,
		// Token: 0x04000CF8 RID: 3320
		VhdChildParentIdMismatch,
		// Token: 0x04000CF9 RID: 3321
		VhdChildParentTimestampMismatch,
		// Token: 0x04000CFA RID: 3322
		VhdMetadataReadFailure,
		// Token: 0x04000CFB RID: 3323
		VhdMetadataWriteFailure,
		// Token: 0x04000CFC RID: 3324
		VhdInvalidSize,
		// Token: 0x04000CFD RID: 3325
		VhdInvalidFileSize,
		// Token: 0x04000CFE RID: 3326
		VirtdiskProviderNotFound,
		// Token: 0x04000CFF RID: 3327
		VirtdiskNotVirtualDisk,
		// Token: 0x04000D00 RID: 3328
		VhdParentVhdAccessDenied,
		// Token: 0x04000D01 RID: 3329
		VhdChildParentSizeMismatch,
		// Token: 0x04000D02 RID: 3330
		VhdDifferencingChainCycleDetected,
		// Token: 0x04000D03 RID: 3331
		VhdDifferencingChainErrorInParent,
		// Token: 0x04000D04 RID: 3332
		VirtualDiskLimitation,
		// Token: 0x04000D05 RID: 3333
		VhdInvalidType,
		// Token: 0x04000D06 RID: 3334
		VhdInvalidState,
		// Token: 0x04000D07 RID: 3335
		VirtdiskUnsupportedDiskSectorSize,
		// Token: 0x04000D08 RID: 3336
		VirtdiskDiskAlreadyOwned,
		// Token: 0x04000D09 RID: 3337
		VirtdiskDiskOnlineAndWritable,
		// Token: 0x04000D0A RID: 3338
		CtlogTrackingNotInitialized,
		// Token: 0x04000D0B RID: 3339
		CtlogLogfileSizeExceededMaxsize,
		// Token: 0x04000D0C RID: 3340
		CtlogVhdChangedOffline,
		// Token: 0x04000D0D RID: 3341
		CtlogInvalidTrackingState,
		// Token: 0x04000D0E RID: 3342
		CtlogInconsistentTrackingFile,
		// Token: 0x04000D0F RID: 3343
		VhdResizeWouldTruncateData,
		// Token: 0x04000D10 RID: 3344
		VhdCouldNotComputeMinimumVirtualSize,
		// Token: 0x04000D11 RID: 3345
		VhdAlreadyAtOrBelowMinimumVirtualSize,
		// Token: 0x04000D12 RID: 3346
		VhdMetadataFull,
		// Token: 0x04000D13 RID: 3347
		VhdInvalidChangeTrackingId,
		// Token: 0x04000D14 RID: 3348
		VhdChangeTrackingDisabled,
		// Token: 0x04000D15 RID: 3349
		VhdMissingChangeTrackingInformation = -1069940688,
		// Token: 0x04000D16 RID: 3350
		QueryStorageError = -2143682559,
		// Token: 0x04000D17 RID: 3351
		SpacesPoolWasDeleted = 15138817,
		// Token: 0x04000D18 RID: 3352
		SpacesFaultDomainTypeInvalid = -2132344831,
		// Token: 0x04000D19 RID: 3353
		SpacesInternalError,
		// Token: 0x04000D1A RID: 3354
		SpacesResiliencyTypeInvalid,
		// Token: 0x04000D1B RID: 3355
		SpacesDriveSectorSizeInvalid,
		// Token: 0x04000D1C RID: 3356
		SpacesDriveRedundancyInvalid = -2132344826,
		// Token: 0x04000D1D RID: 3357
		SpacesNumberOfDataCopiesInvalid,
		// Token: 0x04000D1E RID: 3358
		SpacesParityLayoutInvalid,
		// Token: 0x04000D1F RID: 3359
		SpacesInterleaveLengthInvalid,
		// Token: 0x04000D20 RID: 3360
		SpacesNumberOfColumnsInvalid,
		// Token: 0x04000D21 RID: 3361
		SpacesNotEnoughDrives,
		// Token: 0x04000D22 RID: 3362
		SpacesExtendedError,
		// Token: 0x04000D23 RID: 3363
		SpacesProvisioningTypeInvalid,
		// Token: 0x04000D24 RID: 3364
		SpacesAllocationSizeInvalid,
		// Token: 0x04000D25 RID: 3365
		SpacesEnclosureAwareInvalid,
		// Token: 0x04000D26 RID: 3366
		SpacesWriteCacheSizeInvalid,
		// Token: 0x04000D27 RID: 3367
		SpacesNumberOfGroupsInvalid,
		// Token: 0x04000D28 RID: 3368
		SpacesDriveOperationalStateInvalid,
		// Token: 0x04000D29 RID: 3369
		VolsnapBootfileNotValid = -2138963967,
		// Token: 0x04000D2A RID: 3370
		VolsnapActivationTimeout,
		// Token: 0x04000D2B RID: 3371
		TieringNotSupportedOnVolume = -2138898431,
		// Token: 0x04000D2C RID: 3372
		TieringVolumeDismountInProgress,
		// Token: 0x04000D2D RID: 3373
		TieringStorageTierNotFound,
		// Token: 0x04000D2E RID: 3374
		TieringInvalidFileId,
		// Token: 0x04000D2F RID: 3375
		TieringWrongClusterNode,
		// Token: 0x04000D30 RID: 3376
		TieringAlreadyProcessing,
		// Token: 0x04000D31 RID: 3377
		TieringCannotPinObject,
		// Token: 0x04000D32 RID: 3378
		TieringFileIsNotPinned,
		// Token: 0x04000D33 RID: 3379
		NotATieredVolume,
		// Token: 0x04000D34 RID: 3380
		AttributeNotPresent,
		// Token: 0x04000D35 RID: 3381
		SeccoreInvalidCommand = -1058537472,
		// Token: 0x04000D36 RID: 3382
		NoApplicableAppLicensesFound = -1058406399,
		// Token: 0x04000D37 RID: 3383
		ClipLicenseNotFound,
		// Token: 0x04000D38 RID: 3384
		ClipDeviceLicenseMissing,
		// Token: 0x04000D39 RID: 3385
		ClipLicenseInvalidSignature,
		// Token: 0x04000D3A RID: 3386
		ClipKeyholderLicenseMissingOrInvalid,
		// Token: 0x04000D3B RID: 3387
		ClipLicenseExpired,
		// Token: 0x04000D3C RID: 3388
		ClipLicenseSignedByUnknownSource,
		// Token: 0x04000D3D RID: 3389
		ClipLicenseNotSigned,
		// Token: 0x04000D3E RID: 3390
		ClipLicenseHardwareIdOutOfTolerance,
		// Token: 0x04000D3F RID: 3391
		ClipLicenseDeviceIdMismatch,
		// Token: 0x04000D40 RID: 3392
		DbgCreateProcessFailureLockdown = -2135949311,
		// Token: 0x04000D41 RID: 3393
		DbgAttachProcessFailureLockdown,
		// Token: 0x04000D42 RID: 3394
		DbgConnectServerFailureLockdown,
		// Token: 0x04000D43 RID: 3395
		DbgStartServerFailureLockdown,
		// Token: 0x04000D44 RID: 3396
		IoPreempted = -1996423167,
		// Token: 0x04000D45 RID: 3397
		SvhdxErrorStored = -1067712512,
		// Token: 0x04000D46 RID: 3398
		SvhdxErrorNotAvailable = -1067647232,
		// Token: 0x04000D47 RID: 3399
		SvhdxUnitAttentionAvailable,
		// Token: 0x04000D48 RID: 3400
		SvhdxUnitAttentionCapacityDataChanged,
		// Token: 0x04000D49 RID: 3401
		SvhdxUnitAttentionReservationsPreempted,
		// Token: 0x04000D4A RID: 3402
		SvhdxUnitAttentionReservationsReleased,
		// Token: 0x04000D4B RID: 3403
		SvhdxUnitAttentionRegistrationsPreempted,
		// Token: 0x04000D4C RID: 3404
		SvhdxUnitAttentionOperatingDefinitionChanged,
		// Token: 0x04000D4D RID: 3405
		SvhdxReservationConflict,
		// Token: 0x04000D4E RID: 3406
		SvhdxWrongFileType,
		// Token: 0x04000D4F RID: 3407
		SvhdxVersionMismatch,
		// Token: 0x04000D50 RID: 3408
		VhdShared,
		// Token: 0x04000D51 RID: 3409
		SvhdxNoInitiator,
		// Token: 0x04000D52 RID: 3410
		VhdsetBackingStorageNotFound,
		// Token: 0x04000D53 RID: 3411
		SmbNoPreauthIntegrityHashOverlap = -1067646976,
		// Token: 0x04000D54 RID: 3412
		SmbBadClusterDialect
	}
}
