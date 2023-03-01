using System;

namespace SharpDX.Multimedia
{
	// Token: 0x0200007B RID: 123
	public enum UsageId : short
	{
		// Token: 0x04000DD4 RID: 3540
		GenericPointer = 1,
		// Token: 0x04000DD5 RID: 3541
		GenericMouse,
		// Token: 0x04000DD6 RID: 3542
		GenericJoystick = 4,
		// Token: 0x04000DD7 RID: 3543
		GenericGamepad,
		// Token: 0x04000DD8 RID: 3544
		GenericKeyboard,
		// Token: 0x04000DD9 RID: 3545
		GenericKeypad,
		// Token: 0x04000DDA RID: 3546
		GenericMultiAxisController,
		// Token: 0x04000DDB RID: 3547
		GenericTabletPcSystemCtl,
		// Token: 0x04000DDC RID: 3548
		GenericPortableDeviceControl = 13,
		// Token: 0x04000DDD RID: 3549
		GenericInteractiveControl,
		// Token: 0x04000DDE RID: 3550
		GenericCountedBuffer = 58,
		// Token: 0x04000DDF RID: 3551
		GenericSystemCtl = 128,
		// Token: 0x04000DE0 RID: 3552
		GenericX = 48,
		// Token: 0x04000DE1 RID: 3553
		GenericY,
		// Token: 0x04000DE2 RID: 3554
		GenericZ,
		// Token: 0x04000DE3 RID: 3555
		GenericRx,
		// Token: 0x04000DE4 RID: 3556
		GenericRy,
		// Token: 0x04000DE5 RID: 3557
		GenericRz,
		// Token: 0x04000DE6 RID: 3558
		GenericSlider,
		// Token: 0x04000DE7 RID: 3559
		GenericDial,
		// Token: 0x04000DE8 RID: 3560
		GenericWheel,
		// Token: 0x04000DE9 RID: 3561
		GenericHatswitch,
		// Token: 0x04000DEA RID: 3562
		GenericByteCount = 59,
		// Token: 0x04000DEB RID: 3563
		GenericMotionWakeup,
		// Token: 0x04000DEC RID: 3564
		GenericStart,
		// Token: 0x04000DED RID: 3565
		GenericSelect,
		// Token: 0x04000DEE RID: 3566
		GenericVx = 64,
		// Token: 0x04000DEF RID: 3567
		GenericVy,
		// Token: 0x04000DF0 RID: 3568
		GenericVz,
		// Token: 0x04000DF1 RID: 3569
		GenericVbrx,
		// Token: 0x04000DF2 RID: 3570
		GenericVbry,
		// Token: 0x04000DF3 RID: 3571
		GenericVbrz,
		// Token: 0x04000DF4 RID: 3572
		GenericVno,
		// Token: 0x04000DF5 RID: 3573
		GenericFeatureNotification,
		// Token: 0x04000DF6 RID: 3574
		GenericResolutionMultiplier,
		// Token: 0x04000DF7 RID: 3575
		GenericSysctlPower = 129,
		// Token: 0x04000DF8 RID: 3576
		GenericSysctlSleep,
		// Token: 0x04000DF9 RID: 3577
		GenericSysctlWake,
		// Token: 0x04000DFA RID: 3578
		GenericSysctlContextMenu,
		// Token: 0x04000DFB RID: 3579
		GenericSysctlMainMenu,
		// Token: 0x04000DFC RID: 3580
		GenericSysctlAppMenu,
		// Token: 0x04000DFD RID: 3581
		GenericSysctlHelpMenu,
		// Token: 0x04000DFE RID: 3582
		GenericSysctlMenuExit,
		// Token: 0x04000DFF RID: 3583
		GenericSysctlMenuSelect,
		// Token: 0x04000E00 RID: 3584
		GenericSysctlMenuRight,
		// Token: 0x04000E01 RID: 3585
		GenericSysctlMenuLeft,
		// Token: 0x04000E02 RID: 3586
		GenericSysctlMenuUp,
		// Token: 0x04000E03 RID: 3587
		GenericSysctlMenuDown,
		// Token: 0x04000E04 RID: 3588
		GenericSysctlColdRestart,
		// Token: 0x04000E05 RID: 3589
		GenericSysctlWarmRestart,
		// Token: 0x04000E06 RID: 3590
		GenericDpadUp,
		// Token: 0x04000E07 RID: 3591
		GenericDpadDown,
		// Token: 0x04000E08 RID: 3592
		GenericDpadRight,
		// Token: 0x04000E09 RID: 3593
		GenericDpadLeft,
		// Token: 0x04000E0A RID: 3594
		GenericSysctlDock = 160,
		// Token: 0x04000E0B RID: 3595
		GenericSysctlUndock,
		// Token: 0x04000E0C RID: 3596
		GenericSysctlSetup,
		// Token: 0x04000E0D RID: 3597
		GenericSysctlSysBreak,
		// Token: 0x04000E0E RID: 3598
		GenericSysctlSysDbgBreak,
		// Token: 0x04000E0F RID: 3599
		GenericSysctlAppBreak,
		// Token: 0x04000E10 RID: 3600
		GenericSysctlAppDbgBreak,
		// Token: 0x04000E11 RID: 3601
		GenericSysctlMute,
		// Token: 0x04000E12 RID: 3602
		GenericSysctlHibernate,
		// Token: 0x04000E13 RID: 3603
		GenericSysctlDispInvert = 176,
		// Token: 0x04000E14 RID: 3604
		GenericSysctlDispInternal,
		// Token: 0x04000E15 RID: 3605
		GenericSysctlDispExternal,
		// Token: 0x04000E16 RID: 3606
		GenericSysctlDispBoth,
		// Token: 0x04000E17 RID: 3607
		GenericSysctlDispDual,
		// Token: 0x04000E18 RID: 3608
		GenericSysctlDispToggle,
		// Token: 0x04000E19 RID: 3609
		GenericSysctlDispSwap,
		// Token: 0x04000E1A RID: 3610
		GenericSysctlDispAutoscale,
		// Token: 0x04000E1B RID: 3611
		GenericSystemDisplayRotationLockButton = 201,
		// Token: 0x04000E1C RID: 3612
		GenericSystemDisplayRotationLockSliderSwitch,
		// Token: 0x04000E1D RID: 3613
		GenericControlEnable,
		// Token: 0x04000E1E RID: 3614
		SimulationFlightSimulationDevice = 1,
		// Token: 0x04000E1F RID: 3615
		SimulationAutomobileSimulationDevice,
		// Token: 0x04000E20 RID: 3616
		SimulationTankSimulationDevice,
		// Token: 0x04000E21 RID: 3617
		SimulationSpaceshipSimulationDevice,
		// Token: 0x04000E22 RID: 3618
		SimulationSubmarineSimulationDevice,
		// Token: 0x04000E23 RID: 3619
		SimulationSailingSimulationDevice,
		// Token: 0x04000E24 RID: 3620
		SimulationMotorcycleSimulationDevice,
		// Token: 0x04000E25 RID: 3621
		SimulationSportsSimulationDevice,
		// Token: 0x04000E26 RID: 3622
		SimulationAirplaneSimulationDevice,
		// Token: 0x04000E27 RID: 3623
		SimulationHelicopterSimulationDevice,
		// Token: 0x04000E28 RID: 3624
		SimulationMagicCarpetSimulationDevice,
		// Token: 0x04000E29 RID: 3625
		SimulationBicycleSimulationDevice,
		// Token: 0x04000E2A RID: 3626
		SimulationFlightControlStick = 32,
		// Token: 0x04000E2B RID: 3627
		SimulationFlightStick,
		// Token: 0x04000E2C RID: 3628
		SimulationCyclicControl,
		// Token: 0x04000E2D RID: 3629
		SimulationCyclicTrim,
		// Token: 0x04000E2E RID: 3630
		SimulationFlightYoke,
		// Token: 0x04000E2F RID: 3631
		SimulationTrackControl,
		// Token: 0x04000E30 RID: 3632
		SimulationAileron = 176,
		// Token: 0x04000E31 RID: 3633
		SimulationAileronTrim,
		// Token: 0x04000E32 RID: 3634
		SimulationAntiTorqueControl,
		// Token: 0x04000E33 RID: 3635
		SimulationAutopiolotEnable,
		// Token: 0x04000E34 RID: 3636
		SimulationChaffRelease,
		// Token: 0x04000E35 RID: 3637
		SimulationCollectiveControl,
		// Token: 0x04000E36 RID: 3638
		SimulationDiveBrake,
		// Token: 0x04000E37 RID: 3639
		SimulationElectronicCountermeasures,
		// Token: 0x04000E38 RID: 3640
		SimulationElevator,
		// Token: 0x04000E39 RID: 3641
		SimulationElevatorTrim,
		// Token: 0x04000E3A RID: 3642
		SimulationRudder,
		// Token: 0x04000E3B RID: 3643
		SimulationThrottle,
		// Token: 0x04000E3C RID: 3644
		SimulationFlightCommunications,
		// Token: 0x04000E3D RID: 3645
		SimulationFlareRelease,
		// Token: 0x04000E3E RID: 3646
		SimulationLandingGear,
		// Token: 0x04000E3F RID: 3647
		SimulationToeBrake,
		// Token: 0x04000E40 RID: 3648
		SimulationTrigger,
		// Token: 0x04000E41 RID: 3649
		SimulationWeaponsArm,
		// Token: 0x04000E42 RID: 3650
		SimulationWeaponsSelect,
		// Token: 0x04000E43 RID: 3651
		SimulationWingFlaps,
		// Token: 0x04000E44 RID: 3652
		SimulationAccellerator,
		// Token: 0x04000E45 RID: 3653
		SimulationBrake,
		// Token: 0x04000E46 RID: 3654
		SimulationClutch,
		// Token: 0x04000E47 RID: 3655
		SimulationShifter,
		// Token: 0x04000E48 RID: 3656
		SimulationSteering,
		// Token: 0x04000E49 RID: 3657
		SimulationTurretDirection,
		// Token: 0x04000E4A RID: 3658
		SimulationBarrelElevation,
		// Token: 0x04000E4B RID: 3659
		SimulationDivePlane,
		// Token: 0x04000E4C RID: 3660
		SimulationBallast,
		// Token: 0x04000E4D RID: 3661
		SimulationBicycleCrank,
		// Token: 0x04000E4E RID: 3662
		SimulationHandleBars,
		// Token: 0x04000E4F RID: 3663
		SimulationFrontBrake,
		// Token: 0x04000E50 RID: 3664
		SimulationRearBrake,
		// Token: 0x04000E51 RID: 3665
		VrBelt = 1,
		// Token: 0x04000E52 RID: 3666
		VrBodySuit,
		// Token: 0x04000E53 RID: 3667
		VrFlexor,
		// Token: 0x04000E54 RID: 3668
		VrGlove,
		// Token: 0x04000E55 RID: 3669
		VrHeadTracker,
		// Token: 0x04000E56 RID: 3670
		VrHeadMountedDisplay,
		// Token: 0x04000E57 RID: 3671
		VrHandTracker,
		// Token: 0x04000E58 RID: 3672
		VrOculometer,
		// Token: 0x04000E59 RID: 3673
		VrVest,
		// Token: 0x04000E5A RID: 3674
		VrAnimatronicDevice,
		// Token: 0x04000E5B RID: 3675
		VrStereoEnable = 32,
		// Token: 0x04000E5C RID: 3676
		VrDisplayEnable,
		// Token: 0x04000E5D RID: 3677
		SportBaseballBat = 1,
		// Token: 0x04000E5E RID: 3678
		SportGolfClub,
		// Token: 0x04000E5F RID: 3679
		SportRowingMachine,
		// Token: 0x04000E60 RID: 3680
		SportTreadmill,
		// Token: 0x04000E61 RID: 3681
		SportStickType = 56,
		// Token: 0x04000E62 RID: 3682
		SportOar = 48,
		// Token: 0x04000E63 RID: 3683
		SportSlope,
		// Token: 0x04000E64 RID: 3684
		SportRate,
		// Token: 0x04000E65 RID: 3685
		SportStickSpeed,
		// Token: 0x04000E66 RID: 3686
		SportStickFaceAngle,
		// Token: 0x04000E67 RID: 3687
		SportHeelToe,
		// Token: 0x04000E68 RID: 3688
		SportFollowThrough,
		// Token: 0x04000E69 RID: 3689
		SportTempo,
		// Token: 0x04000E6A RID: 3690
		SportHeight = 57,
		// Token: 0x04000E6B RID: 3691
		SportPutter = 80,
		// Token: 0x04000E6C RID: 3692
		Sport1Iron,
		// Token: 0x04000E6D RID: 3693
		Sport2Iron,
		// Token: 0x04000E6E RID: 3694
		Sport3Iron,
		// Token: 0x04000E6F RID: 3695
		Sport4Iron,
		// Token: 0x04000E70 RID: 3696
		Sport5Iron,
		// Token: 0x04000E71 RID: 3697
		Sport6Iron,
		// Token: 0x04000E72 RID: 3698
		Sport7Iron,
		// Token: 0x04000E73 RID: 3699
		Sport8Iron,
		// Token: 0x04000E74 RID: 3700
		Sport9Iron,
		// Token: 0x04000E75 RID: 3701
		Sport10Iron,
		// Token: 0x04000E76 RID: 3702
		Sport11Iron,
		// Token: 0x04000E77 RID: 3703
		SportSandWedge,
		// Token: 0x04000E78 RID: 3704
		SportLoftWedge,
		// Token: 0x04000E79 RID: 3705
		SportPowerWedge,
		// Token: 0x04000E7A RID: 3706
		Sport1Wood,
		// Token: 0x04000E7B RID: 3707
		Sport3Wood,
		// Token: 0x04000E7C RID: 3708
		Sport5Wood,
		// Token: 0x04000E7D RID: 3709
		Sport7Wood,
		// Token: 0x04000E7E RID: 3710
		Sport9Wood,
		// Token: 0x04000E7F RID: 3711
		Game3dGameController = 1,
		// Token: 0x04000E80 RID: 3712
		GamePinballDevice,
		// Token: 0x04000E81 RID: 3713
		GameGunDevice,
		// Token: 0x04000E82 RID: 3714
		GamePointOfView = 32,
		// Token: 0x04000E83 RID: 3715
		GameGunSelector = 50,
		// Token: 0x04000E84 RID: 3716
		GameGamepadFireJump = 55,
		// Token: 0x04000E85 RID: 3717
		GameGamepadTrigger = 57,
		// Token: 0x04000E86 RID: 3718
		GameTurnRightLeft = 33,
		// Token: 0x04000E87 RID: 3719
		GamePitchForwardBack,
		// Token: 0x04000E88 RID: 3720
		GameRollRightLeft,
		// Token: 0x04000E89 RID: 3721
		GameMoveRightLeft,
		// Token: 0x04000E8A RID: 3722
		GameMoveForwardBack,
		// Token: 0x04000E8B RID: 3723
		GameMoveUpDown,
		// Token: 0x04000E8C RID: 3724
		GameLeanRightLeft,
		// Token: 0x04000E8D RID: 3725
		GameLeanForwardBack,
		// Token: 0x04000E8E RID: 3726
		GamePovHeight,
		// Token: 0x04000E8F RID: 3727
		GameFlipper,
		// Token: 0x04000E90 RID: 3728
		GameSecondaryFlipper,
		// Token: 0x04000E91 RID: 3729
		GameBump,
		// Token: 0x04000E92 RID: 3730
		GameNewGame,
		// Token: 0x04000E93 RID: 3731
		GameShootBall,
		// Token: 0x04000E94 RID: 3732
		GamePlayer,
		// Token: 0x04000E95 RID: 3733
		GameGunBolt,
		// Token: 0x04000E96 RID: 3734
		GameGunClip,
		// Token: 0x04000E97 RID: 3735
		GameGunSingleShot = 51,
		// Token: 0x04000E98 RID: 3736
		GameGunBurst,
		// Token: 0x04000E99 RID: 3737
		GameGunAutomatic,
		// Token: 0x04000E9A RID: 3738
		GameGunSafety,
		// Token: 0x04000E9B RID: 3739
		GenericDeviceBatteryStrength = 32,
		// Token: 0x04000E9C RID: 3740
		GenericDeviceWirelessChannel,
		// Token: 0x04000E9D RID: 3741
		GenericDeviceWirelessId,
		// Token: 0x04000E9E RID: 3742
		GenericDeviceDiscoverWirelessControl,
		// Token: 0x04000E9F RID: 3743
		GenericDeviceSecurityCodeCharEntered,
		// Token: 0x04000EA0 RID: 3744
		GenericDeviceSecurityCodeCharErased,
		// Token: 0x04000EA1 RID: 3745
		GenericDeviceSecurityCodeCleared,
		// Token: 0x04000EA2 RID: 3746
		KeyboardNoevent = 0,
		// Token: 0x04000EA3 RID: 3747
		KeyboardRollover,
		// Token: 0x04000EA4 RID: 3748
		KeyboardPostfail,
		// Token: 0x04000EA5 RID: 3749
		KeyboardUndefined,
		// Token: 0x04000EA6 RID: 3750
		KeyboardAA,
		// Token: 0x04000EA7 RID: 3751
		KeyboardZZ = 29,
		// Token: 0x04000EA8 RID: 3752
		KeyboardOne,
		// Token: 0x04000EA9 RID: 3753
		KeyboardZero = 39,
		// Token: 0x04000EAA RID: 3754
		KeyboardLctrl = 224,
		// Token: 0x04000EAB RID: 3755
		KeyboardLshft,
		// Token: 0x04000EAC RID: 3756
		KeyboardLalt,
		// Token: 0x04000EAD RID: 3757
		KeyboardLgui,
		// Token: 0x04000EAE RID: 3758
		KeyboardRctrl,
		// Token: 0x04000EAF RID: 3759
		KeyboardRshft,
		// Token: 0x04000EB0 RID: 3760
		KeyboardRalt,
		// Token: 0x04000EB1 RID: 3761
		KeyboardRgui,
		// Token: 0x04000EB2 RID: 3762
		KeyboardScrollLock = 71,
		// Token: 0x04000EB3 RID: 3763
		KeyboardNumLock = 83,
		// Token: 0x04000EB4 RID: 3764
		KeyboardCapsLock = 57,
		// Token: 0x04000EB5 RID: 3765
		KeyboardF1,
		// Token: 0x04000EB6 RID: 3766
		KeyboardF2,
		// Token: 0x04000EB7 RID: 3767
		KeyboardF3,
		// Token: 0x04000EB8 RID: 3768
		KeyboardF4,
		// Token: 0x04000EB9 RID: 3769
		KeyboardF5,
		// Token: 0x04000EBA RID: 3770
		KeyboardF6,
		// Token: 0x04000EBB RID: 3771
		KeyboardF7,
		// Token: 0x04000EBC RID: 3772
		KeyboardF8,
		// Token: 0x04000EBD RID: 3773
		KeyboardF9,
		// Token: 0x04000EBE RID: 3774
		KeyboardF10,
		// Token: 0x04000EBF RID: 3775
		KeyboardF11,
		// Token: 0x04000EC0 RID: 3776
		KeyboardF12,
		// Token: 0x04000EC1 RID: 3777
		KeyboardF13 = 104,
		// Token: 0x04000EC2 RID: 3778
		KeyboardF14,
		// Token: 0x04000EC3 RID: 3779
		KeyboardF15,
		// Token: 0x04000EC4 RID: 3780
		KeyboardF16,
		// Token: 0x04000EC5 RID: 3781
		KeyboardF17,
		// Token: 0x04000EC6 RID: 3782
		KeyboardF18,
		// Token: 0x04000EC7 RID: 3783
		KeyboardF19,
		// Token: 0x04000EC8 RID: 3784
		KeyboardF20,
		// Token: 0x04000EC9 RID: 3785
		KeyboardF21,
		// Token: 0x04000ECA RID: 3786
		KeyboardF22,
		// Token: 0x04000ECB RID: 3787
		KeyboardF23,
		// Token: 0x04000ECC RID: 3788
		KeyboardF24,
		// Token: 0x04000ECD RID: 3789
		KeyboardReturn = 40,
		// Token: 0x04000ECE RID: 3790
		KeyboardEscape,
		// Token: 0x04000ECF RID: 3791
		KeyboardDelete,
		// Token: 0x04000ED0 RID: 3792
		KeyboardPrintScreen = 70,
		// Token: 0x04000ED1 RID: 3793
		KeyboardDeleteForward = 76,
		// Token: 0x04000ED2 RID: 3794
		LedNumLock = 1,
		// Token: 0x04000ED3 RID: 3795
		LedCapsLock,
		// Token: 0x04000ED4 RID: 3796
		LedScrollLock,
		// Token: 0x04000ED5 RID: 3797
		LedCompose,
		// Token: 0x04000ED6 RID: 3798
		LedKana,
		// Token: 0x04000ED7 RID: 3799
		LedPower,
		// Token: 0x04000ED8 RID: 3800
		LedShift,
		// Token: 0x04000ED9 RID: 3801
		LedDoNotDisturb,
		// Token: 0x04000EDA RID: 3802
		LedMute,
		// Token: 0x04000EDB RID: 3803
		LedToneEnable,
		// Token: 0x04000EDC RID: 3804
		LedHighCutFilter,
		// Token: 0x04000EDD RID: 3805
		LedLowCutFilter,
		// Token: 0x04000EDE RID: 3806
		LedEqualizerEnable,
		// Token: 0x04000EDF RID: 3807
		LedSoundFieldOn,
		// Token: 0x04000EE0 RID: 3808
		LedSurroundFieldOn,
		// Token: 0x04000EE1 RID: 3809
		LedRepeat,
		// Token: 0x04000EE2 RID: 3810
		LedStereo,
		// Token: 0x04000EE3 RID: 3811
		LedSamplingRateDetect,
		// Token: 0x04000EE4 RID: 3812
		LedSpinning,
		// Token: 0x04000EE5 RID: 3813
		LedCav,
		// Token: 0x04000EE6 RID: 3814
		LedClv,
		// Token: 0x04000EE7 RID: 3815
		LedRecordingFormatDet,
		// Token: 0x04000EE8 RID: 3816
		LedOffHook,
		// Token: 0x04000EE9 RID: 3817
		LedRing,
		// Token: 0x04000EEA RID: 3818
		LedMessageWaiting,
		// Token: 0x04000EEB RID: 3819
		LedDataMode,
		// Token: 0x04000EEC RID: 3820
		LedBatteryOperation,
		// Token: 0x04000EED RID: 3821
		LedBatteryOk,
		// Token: 0x04000EEE RID: 3822
		LedBatteryLow,
		// Token: 0x04000EEF RID: 3823
		LedSpeaker,
		// Token: 0x04000EF0 RID: 3824
		LedHeadSet,
		// Token: 0x04000EF1 RID: 3825
		LedHold,
		// Token: 0x04000EF2 RID: 3826
		LedMicrophone,
		// Token: 0x04000EF3 RID: 3827
		LedCoverage,
		// Token: 0x04000EF4 RID: 3828
		LedNightMode,
		// Token: 0x04000EF5 RID: 3829
		LedSendCalls,
		// Token: 0x04000EF6 RID: 3830
		LedCallPickup,
		// Token: 0x04000EF7 RID: 3831
		LedConference,
		// Token: 0x04000EF8 RID: 3832
		LedStandBy,
		// Token: 0x04000EF9 RID: 3833
		LedCameraOn,
		// Token: 0x04000EFA RID: 3834
		LedCameraOff,
		// Token: 0x04000EFB RID: 3835
		LedOnLine,
		// Token: 0x04000EFC RID: 3836
		LedOffLine,
		// Token: 0x04000EFD RID: 3837
		LedBusy,
		// Token: 0x04000EFE RID: 3838
		LedReady,
		// Token: 0x04000EFF RID: 3839
		LedPaperOut,
		// Token: 0x04000F00 RID: 3840
		LedPaperJam,
		// Token: 0x04000F01 RID: 3841
		LedRemote,
		// Token: 0x04000F02 RID: 3842
		LedForward,
		// Token: 0x04000F03 RID: 3843
		LedReverse,
		// Token: 0x04000F04 RID: 3844
		LedStop,
		// Token: 0x04000F05 RID: 3845
		LedRewind,
		// Token: 0x04000F06 RID: 3846
		LedFastForward,
		// Token: 0x04000F07 RID: 3847
		LedPlay,
		// Token: 0x04000F08 RID: 3848
		LedPause,
		// Token: 0x04000F09 RID: 3849
		LedRecord,
		// Token: 0x04000F0A RID: 3850
		LedError,
		// Token: 0x04000F0B RID: 3851
		LedSelectedIndicator,
		// Token: 0x04000F0C RID: 3852
		LedInUseIndicator,
		// Token: 0x04000F0D RID: 3853
		LedMultiModeIndicator,
		// Token: 0x04000F0E RID: 3854
		LedIndicatorOn,
		// Token: 0x04000F0F RID: 3855
		LedIndicatorFlash,
		// Token: 0x04000F10 RID: 3856
		LedIndicatorSlowBlink,
		// Token: 0x04000F11 RID: 3857
		LedIndicatorFastBlink,
		// Token: 0x04000F12 RID: 3858
		LedIndicatorOff,
		// Token: 0x04000F13 RID: 3859
		LedFlashOnTime,
		// Token: 0x04000F14 RID: 3860
		LedSlowBlinkOnTime,
		// Token: 0x04000F15 RID: 3861
		LedSlowBlinkOffTime,
		// Token: 0x04000F16 RID: 3862
		LedFastBlinkOnTime,
		// Token: 0x04000F17 RID: 3863
		LedFastBlinkOffTime,
		// Token: 0x04000F18 RID: 3864
		LedIndicatorColor,
		// Token: 0x04000F19 RID: 3865
		LedRed,
		// Token: 0x04000F1A RID: 3866
		LedGreen,
		// Token: 0x04000F1B RID: 3867
		LedAmber,
		// Token: 0x04000F1C RID: 3868
		LedGenericIndicator,
		// Token: 0x04000F1D RID: 3869
		LedSystemSuspend,
		// Token: 0x04000F1E RID: 3870
		LedExternalPower,
		// Token: 0x04000F1F RID: 3871
		TelephonyPhone = 1,
		// Token: 0x04000F20 RID: 3872
		TelephonyAnsweringMachine,
		// Token: 0x04000F21 RID: 3873
		TelephonyMessageControls,
		// Token: 0x04000F22 RID: 3874
		TelephonyHandset,
		// Token: 0x04000F23 RID: 3875
		TelephonyHeadset,
		// Token: 0x04000F24 RID: 3876
		TelephonyKeypad,
		// Token: 0x04000F25 RID: 3877
		TelephonyProgrammableButton,
		// Token: 0x04000F26 RID: 3878
		TelephonyRedial = 36,
		// Token: 0x04000F27 RID: 3879
		TelephonyTransfer,
		// Token: 0x04000F28 RID: 3880
		TelephonyDrop,
		// Token: 0x04000F29 RID: 3881
		TelephonyLine = 42,
		// Token: 0x04000F2A RID: 3882
		TelephonyRingEnable = 45,
		// Token: 0x04000F2B RID: 3883
		TelephonySend = 49,
		// Token: 0x04000F2C RID: 3884
		TelephonyKeypad0 = 176,
		// Token: 0x04000F2D RID: 3885
		TelephonyKeypadD = 191,
		// Token: 0x04000F2E RID: 3886
		TelephonyHostAvailable = 241,
		// Token: 0x04000F2F RID: 3887
		Consumerctrl = 1,
		// Token: 0x04000F30 RID: 3888
		ConsumerChannelIncrement = 156,
		// Token: 0x04000F31 RID: 3889
		ConsumerChannelDecrement,
		// Token: 0x04000F32 RID: 3890
		ConsumerPlay = 176,
		// Token: 0x04000F33 RID: 3891
		ConsumerPause,
		// Token: 0x04000F34 RID: 3892
		ConsumerRecord,
		// Token: 0x04000F35 RID: 3893
		ConsumerFastForward,
		// Token: 0x04000F36 RID: 3894
		ConsumerRewind,
		// Token: 0x04000F37 RID: 3895
		ConsumerScanNextTrack,
		// Token: 0x04000F38 RID: 3896
		ConsumerScanPrevTrack,
		// Token: 0x04000F39 RID: 3897
		ConsumerStop,
		// Token: 0x04000F3A RID: 3898
		ConsumerPlayPause = 205,
		// Token: 0x04000F3B RID: 3899
		ConsumerGamedvrOpenGamebar = 208,
		// Token: 0x04000F3C RID: 3900
		ConsumerGamedvrToggleRecord,
		// Token: 0x04000F3D RID: 3901
		ConsumerGamedvrRecordClip,
		// Token: 0x04000F3E RID: 3902
		ConsumerGamedvrScreenshot,
		// Token: 0x04000F3F RID: 3903
		ConsumerGamedvrToggleIndicator,
		// Token: 0x04000F40 RID: 3904
		ConsumerGamedvrToggleMicrophone,
		// Token: 0x04000F41 RID: 3905
		ConsumerGamedvrToggleCamera,
		// Token: 0x04000F42 RID: 3906
		ConsumerGamedvrToggleBroadcast,
		// Token: 0x04000F43 RID: 3907
		ConsumerVolume = 224,
		// Token: 0x04000F44 RID: 3908
		ConsumerBalance,
		// Token: 0x04000F45 RID: 3909
		ConsumerMute,
		// Token: 0x04000F46 RID: 3910
		ConsumerBass,
		// Token: 0x04000F47 RID: 3911
		ConsumerTreble,
		// Token: 0x04000F48 RID: 3912
		ConsumerBassBoost,
		// Token: 0x04000F49 RID: 3913
		ConsumerSurroundMode,
		// Token: 0x04000F4A RID: 3914
		ConsumerLoudness,
		// Token: 0x04000F4B RID: 3915
		ConsumerMpx,
		// Token: 0x04000F4C RID: 3916
		ConsumerVolumeIncrement,
		// Token: 0x04000F4D RID: 3917
		ConsumerVolumeDecrement,
		// Token: 0x04000F4E RID: 3918
		ConsumerBassIncrement = 338,
		// Token: 0x04000F4F RID: 3919
		ConsumerBassDecrement,
		// Token: 0x04000F50 RID: 3920
		ConsumerTrebleIncrement,
		// Token: 0x04000F51 RID: 3921
		ConsumerTrebleDecrement,
		// Token: 0x04000F52 RID: 3922
		ConsumerAlConfiguration = 387,
		// Token: 0x04000F53 RID: 3923
		ConsumerAlEmail = 394,
		// Token: 0x04000F54 RID: 3924
		ConsumerAlCalculator = 402,
		// Token: 0x04000F55 RID: 3925
		ConsumerAlBrowser = 404,
		// Token: 0x04000F56 RID: 3926
		ConsumerAlSearch = 454,
		// Token: 0x04000F57 RID: 3927
		ConsumerAcSearch = 545,
		// Token: 0x04000F58 RID: 3928
		ConsumerAcGoto,
		// Token: 0x04000F59 RID: 3929
		ConsumerAcHome,
		// Token: 0x04000F5A RID: 3930
		ConsumerAcBack,
		// Token: 0x04000F5B RID: 3931
		ConsumerAcForward,
		// Token: 0x04000F5C RID: 3932
		ConsumerAcStop,
		// Token: 0x04000F5D RID: 3933
		ConsumerAcRefresh,
		// Token: 0x04000F5E RID: 3934
		ConsumerAcPrevious,
		// Token: 0x04000F5F RID: 3935
		ConsumerAcNext,
		// Token: 0x04000F60 RID: 3936
		ConsumerAcBookmarks,
		// Token: 0x04000F61 RID: 3937
		ConsumerAcPan = 568,
		// Token: 0x04000F62 RID: 3938
		ConsumerExtendedKeyboardAttributesCollection = 704,
		// Token: 0x04000F63 RID: 3939
		ConsumerKeyboardFormFactor,
		// Token: 0x04000F64 RID: 3940
		ConsumerKeyboardKeyType,
		// Token: 0x04000F65 RID: 3941
		ConsumerKeyboardPhysicalLayout,
		// Token: 0x04000F66 RID: 3942
		ConsumerVendorSpecificKeyboardPhysicalLayout,
		// Token: 0x04000F67 RID: 3943
		ConsumerKeyboardIetfLanguageTagIndex,
		// Token: 0x04000F68 RID: 3944
		ConsumerImplementedKeyboardInputAssistControls,
		// Token: 0x04000F69 RID: 3945
		DigitizerDigitizer = 1,
		// Token: 0x04000F6A RID: 3946
		DigitizerPen,
		// Token: 0x04000F6B RID: 3947
		DigitizerLightPen,
		// Token: 0x04000F6C RID: 3948
		DigitizerTouchScreen,
		// Token: 0x04000F6D RID: 3949
		DigitizerTouchPad,
		// Token: 0x04000F6E RID: 3950
		DigitizerWhiteBoard,
		// Token: 0x04000F6F RID: 3951
		DigitizerCoordMeasuring,
		// Token: 0x04000F70 RID: 3952
		Digitizer3dDigitizer,
		// Token: 0x04000F71 RID: 3953
		DigitizerStereoPlotter,
		// Token: 0x04000F72 RID: 3954
		DigitizerArticulatedArm,
		// Token: 0x04000F73 RID: 3955
		DigitizerArmature,
		// Token: 0x04000F74 RID: 3956
		DigitizerMultiPoint,
		// Token: 0x04000F75 RID: 3957
		DigitizerFreeSpaceWand,
		// Token: 0x04000F76 RID: 3958
		DigitizerStylus = 32,
		// Token: 0x04000F77 RID: 3959
		DigitizerPuck,
		// Token: 0x04000F78 RID: 3960
		DigitizerFinger,
		// Token: 0x04000F79 RID: 3961
		DigitizerTabletFuncKeys = 57,
		// Token: 0x04000F7A RID: 3962
		DigitizerProgChangeKeys,
		// Token: 0x04000F7B RID: 3963
		DigitizerTipPressure = 48,
		// Token: 0x04000F7C RID: 3964
		DigitizerBarrelPressure,
		// Token: 0x04000F7D RID: 3965
		DigitizerInRange,
		// Token: 0x04000F7E RID: 3966
		DigitizerTouch,
		// Token: 0x04000F7F RID: 3967
		DigitizerUntouch,
		// Token: 0x04000F80 RID: 3968
		DigitizerTap,
		// Token: 0x04000F81 RID: 3969
		DigitizerQuality,
		// Token: 0x04000F82 RID: 3970
		DigitizerDataValid,
		// Token: 0x04000F83 RID: 3971
		DigitizerTransducerIndex,
		// Token: 0x04000F84 RID: 3972
		DigitizerBatteryStrength = 59,
		// Token: 0x04000F85 RID: 3973
		DigitizerInvert,
		// Token: 0x04000F86 RID: 3974
		DigitizerXTilt,
		// Token: 0x04000F87 RID: 3975
		DigitizerYTilt,
		// Token: 0x04000F88 RID: 3976
		DigitizerAzimuth,
		// Token: 0x04000F89 RID: 3977
		DigitizerAltitude,
		// Token: 0x04000F8A RID: 3978
		DigitizerTwist,
		// Token: 0x04000F8B RID: 3979
		DigitizerTipSwitch,
		// Token: 0x04000F8C RID: 3980
		DigitizerSecondaryTipSwitch,
		// Token: 0x04000F8D RID: 3981
		DigitizerBarrelSwitch,
		// Token: 0x04000F8E RID: 3982
		DigitizerEraser,
		// Token: 0x04000F8F RID: 3983
		DigitizerTabletPick,
		// Token: 0x04000F90 RID: 3984
		HapticsSimpleController = 1,
		// Token: 0x04000F91 RID: 3985
		HapticsWaveformList = 16,
		// Token: 0x04000F92 RID: 3986
		HapticsDurationList,
		// Token: 0x04000F93 RID: 3987
		HapticsAutoTrigger = 32,
		// Token: 0x04000F94 RID: 3988
		HapticsManualTrigger,
		// Token: 0x04000F95 RID: 3989
		HapticsAutoAssociatedControl,
		// Token: 0x04000F96 RID: 3990
		HapticsIntensity,
		// Token: 0x04000F97 RID: 3991
		HapticsRepeatCount,
		// Token: 0x04000F98 RID: 3992
		HapticsRetriggerPeriod,
		// Token: 0x04000F99 RID: 3993
		HapticsWaveformVendorPage,
		// Token: 0x04000F9A RID: 3994
		HapticsWaveformVendorId,
		// Token: 0x04000F9B RID: 3995
		HapticsWaveformCutoffTime,
		// Token: 0x04000F9C RID: 3996
		HapticsWaveformBegin = 4096,
		// Token: 0x04000F9D RID: 3997
		HapticsWaveformStop,
		// Token: 0x04000F9E RID: 3998
		HapticsWaveformNull,
		// Token: 0x04000F9F RID: 3999
		HapticsWaveformClick,
		// Token: 0x04000FA0 RID: 4000
		HapticsWaveformBuzz,
		// Token: 0x04000FA1 RID: 4001
		HapticsWaveformRumble,
		// Token: 0x04000FA2 RID: 4002
		HapticsWaveformPress,
		// Token: 0x04000FA3 RID: 4003
		HapticsWaveformRelease,
		// Token: 0x04000FA4 RID: 4004
		HapticsWaveformEnd = 8191,
		// Token: 0x04000FA5 RID: 4005
		HapticsWaveformVendorBegin,
		// Token: 0x04000FA6 RID: 4006
		HapticsWaveformVendorEnd = 12287,
		// Token: 0x04000FA7 RID: 4007
		AlphanumericAlphanumericDisplay = 1,
		// Token: 0x04000FA8 RID: 4008
		AlphanumericBitmappedDisplay,
		// Token: 0x04000FA9 RID: 4009
		AlphanumericDisplayAttributesReport = 32,
		// Token: 0x04000FAA RID: 4010
		AlphanumericDisplayControlReport = 36,
		// Token: 0x04000FAB RID: 4011
		AlphanumericCharacterReport = 43,
		// Token: 0x04000FAC RID: 4012
		AlphanumericDisplayStatus = 45,
		// Token: 0x04000FAD RID: 4013
		AlphanumericCursorPositionReport = 50,
		// Token: 0x04000FAE RID: 4014
		AlphanumericFontReport = 59,
		// Token: 0x04000FAF RID: 4015
		AlphanumericFontData,
		// Token: 0x04000FB0 RID: 4016
		AlphanumericCharacterAttribute = 72,
		// Token: 0x04000FB1 RID: 4017
		AlphanumericPaletteReport = 133,
		// Token: 0x04000FB2 RID: 4018
		AlphanumericPaletteData = 136,
		// Token: 0x04000FB3 RID: 4019
		AlphanumericBlitReport = 138,
		// Token: 0x04000FB4 RID: 4020
		AlphanumericBlitData = 143,
		// Token: 0x04000FB5 RID: 4021
		AlphanumericSoftButton,
		// Token: 0x04000FB6 RID: 4022
		AlphanumericAsciiCharacterSet = 33,
		// Token: 0x04000FB7 RID: 4023
		AlphanumericDataReadBack,
		// Token: 0x04000FB8 RID: 4024
		AlphanumericFontReadBack,
		// Token: 0x04000FB9 RID: 4025
		AlphanumericClearDisplay = 37,
		// Token: 0x04000FBA RID: 4026
		AlphanumericDisplayEnable,
		// Token: 0x04000FBB RID: 4027
		AlphanumericScreenSaverDelay,
		// Token: 0x04000FBC RID: 4028
		AlphanumericScreenSaverEnable,
		// Token: 0x04000FBD RID: 4029
		AlphanumericVerticalScroll,
		// Token: 0x04000FBE RID: 4030
		AlphanumericHorizontalScroll,
		// Token: 0x04000FBF RID: 4031
		AlphanumericDisplayData = 44,
		// Token: 0x04000FC0 RID: 4032
		AlphanumericStatusNotReady = 46,
		// Token: 0x04000FC1 RID: 4033
		AlphanumericStatusReady,
		// Token: 0x04000FC2 RID: 4034
		AlphanumericErrNotALoadableCharacter,
		// Token: 0x04000FC3 RID: 4035
		AlphanumericErrFontDataCannotBeRead,
		// Token: 0x04000FC4 RID: 4036
		AlphanumericRow = 51,
		// Token: 0x04000FC5 RID: 4037
		AlphanumericColumn,
		// Token: 0x04000FC6 RID: 4038
		AlphanumericRows,
		// Token: 0x04000FC7 RID: 4039
		AlphanumericColumns,
		// Token: 0x04000FC8 RID: 4040
		AlphanumericCursorPixelPositioning,
		// Token: 0x04000FC9 RID: 4041
		AlphanumericCursorMode,
		// Token: 0x04000FCA RID: 4042
		AlphanumericCursorEnable,
		// Token: 0x04000FCB RID: 4043
		AlphanumericCursorBlink,
		// Token: 0x04000FCC RID: 4044
		AlphanumericCharWidth = 61,
		// Token: 0x04000FCD RID: 4045
		AlphanumericCharHeight,
		// Token: 0x04000FCE RID: 4046
		AlphanumericCharSpacingHorizontal,
		// Token: 0x04000FCF RID: 4047
		AlphanumericCharSpacingVertical,
		// Token: 0x04000FD0 RID: 4048
		AlphanumericUnicodeCharSet,
		// Token: 0x04000FD1 RID: 4049
		AlphanumericFont7Segment,
		// Token: 0x04000FD2 RID: 4050
		Alphanumeric7SegmentDirectMap,
		// Token: 0x04000FD3 RID: 4051
		AlphanumericFont14Segment,
		// Token: 0x04000FD4 RID: 4052
		Alphanumeric14SegmentDirectMap,
		// Token: 0x04000FD5 RID: 4053
		AlphanumericDisplayBrightness,
		// Token: 0x04000FD6 RID: 4054
		AlphanumericDisplayContrast,
		// Token: 0x04000FD7 RID: 4055
		AlphanumericAttributeReadback = 73,
		// Token: 0x04000FD8 RID: 4056
		AlphanumericAttributeData,
		// Token: 0x04000FD9 RID: 4057
		AlphanumericCharAttrEnhance,
		// Token: 0x04000FDA RID: 4058
		AlphanumericCharAttrUnderline,
		// Token: 0x04000FDB RID: 4059
		AlphanumericCharAttrBlink,
		// Token: 0x04000FDC RID: 4060
		AlphanumericBitmapSizeX = 128,
		// Token: 0x04000FDD RID: 4061
		AlphanumericBitmapSizeY,
		// Token: 0x04000FDE RID: 4062
		AlphanumericBitDepthFormat = 131,
		// Token: 0x04000FDF RID: 4063
		AlphanumericDisplayOrientation,
		// Token: 0x04000FE0 RID: 4064
		AlphanumericPaletteDataSize = 134,
		// Token: 0x04000FE1 RID: 4065
		AlphanumericPaletteDataOffset,
		// Token: 0x04000FE2 RID: 4066
		AlphanumericBlitRectangleX1 = 139,
		// Token: 0x04000FE3 RID: 4067
		AlphanumericBlitRectangleY1,
		// Token: 0x04000FE4 RID: 4068
		AlphanumericBlitRectangleX2,
		// Token: 0x04000FE5 RID: 4069
		AlphanumericBlitRectangleY2,
		// Token: 0x04000FE6 RID: 4070
		AlphanumericSoftButtonId = 145,
		// Token: 0x04000FE7 RID: 4071
		AlphanumericSoftButtonSide,
		// Token: 0x04000FE8 RID: 4072
		AlphanumericSoftButtonOffset1,
		// Token: 0x04000FE9 RID: 4073
		AlphanumericSoftButtonOffset2,
		// Token: 0x04000FEA RID: 4074
		AlphanumericSoftButtonReport,
		// Token: 0x04000FEB RID: 4075
		CameraAutoFocus = 32,
		// Token: 0x04000FEC RID: 4076
		CameraShutter,
		// Token: 0x04000FED RID: 4077
		MsBthHfDialnumber = 33,
		// Token: 0x04000FEE RID: 4078
		MsBthHfDialmemory
	}
}
