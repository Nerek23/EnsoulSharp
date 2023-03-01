using System;

namespace SharpDX.Multimedia
{
	// Token: 0x0200007D RID: 125
	public enum WaveFormatEncoding : short
	{
		// Token: 0x04001018 RID: 4120
		Unknown,
		// Token: 0x04001019 RID: 4121
		Adpcm = 2,
		// Token: 0x0400101A RID: 4122
		IeeeFloat,
		// Token: 0x0400101B RID: 4123
		Vselp,
		// Token: 0x0400101C RID: 4124
		IbmCvsd,
		// Token: 0x0400101D RID: 4125
		Alaw,
		// Token: 0x0400101E RID: 4126
		Mulaw,
		// Token: 0x0400101F RID: 4127
		Dts,
		// Token: 0x04001020 RID: 4128
		Drm,
		// Token: 0x04001021 RID: 4129
		Wmavoice9,
		// Token: 0x04001022 RID: 4130
		Wmavoice10,
		// Token: 0x04001023 RID: 4131
		OkiAdpcm = 16,
		// Token: 0x04001024 RID: 4132
		DviAdpcm,
		// Token: 0x04001025 RID: 4133
		ImaAdpcm = 17,
		// Token: 0x04001026 RID: 4134
		MediaspaceAdpcm,
		// Token: 0x04001027 RID: 4135
		SierraAdpcm,
		// Token: 0x04001028 RID: 4136
		G723Adpcm,
		// Token: 0x04001029 RID: 4137
		Digistd,
		// Token: 0x0400102A RID: 4138
		Digifix,
		// Token: 0x0400102B RID: 4139
		DialogicOkiAdpcm,
		// Token: 0x0400102C RID: 4140
		MediavisionAdpcm,
		// Token: 0x0400102D RID: 4141
		CuCodec,
		// Token: 0x0400102E RID: 4142
		HpDynVoice,
		// Token: 0x0400102F RID: 4143
		YamahaAdpcm = 32,
		// Token: 0x04001030 RID: 4144
		Sonarc,
		// Token: 0x04001031 RID: 4145
		DspgroupTruespeech,
		// Token: 0x04001032 RID: 4146
		Echosc1,
		// Token: 0x04001033 RID: 4147
		AudiofileAf36,
		// Token: 0x04001034 RID: 4148
		Aptx,
		// Token: 0x04001035 RID: 4149
		AudiofileAf10,
		// Token: 0x04001036 RID: 4150
		Prosody1612,
		// Token: 0x04001037 RID: 4151
		Lrc,
		// Token: 0x04001038 RID: 4152
		DolbyAc2 = 48,
		// Token: 0x04001039 RID: 4153
		DefaultGsm610,
		// Token: 0x0400103A RID: 4154
		Msnaudio,
		// Token: 0x0400103B RID: 4155
		AntexAdpcme,
		// Token: 0x0400103C RID: 4156
		ControlResVqlpc,
		// Token: 0x0400103D RID: 4157
		Digireal,
		// Token: 0x0400103E RID: 4158
		Digiadpcm,
		// Token: 0x0400103F RID: 4159
		ControlResCr10,
		// Token: 0x04001040 RID: 4160
		NmsVbxadpcm,
		// Token: 0x04001041 RID: 4161
		CsImaadpcm,
		// Token: 0x04001042 RID: 4162
		Echosc3,
		// Token: 0x04001043 RID: 4163
		RockwellAdpcm,
		// Token: 0x04001044 RID: 4164
		RockwellDigitalk,
		// Token: 0x04001045 RID: 4165
		Xebec,
		// Token: 0x04001046 RID: 4166
		G721Adpcm = 64,
		// Token: 0x04001047 RID: 4167
		G728Celp,
		// Token: 0x04001048 RID: 4168
		Msg723,
		// Token: 0x04001049 RID: 4169
		IntelG7231,
		// Token: 0x0400104A RID: 4170
		IntelG729,
		// Token: 0x0400104B RID: 4171
		SharpG726,
		// Token: 0x0400104C RID: 4172
		Mpeg = 80,
		// Token: 0x0400104D RID: 4173
		Rt24 = 82,
		// Token: 0x0400104E RID: 4174
		Pac,
		// Token: 0x0400104F RID: 4175
		Mpeglayer3 = 85,
		// Token: 0x04001050 RID: 4176
		LucentG723 = 89,
		// Token: 0x04001051 RID: 4177
		Cirrus = 96,
		// Token: 0x04001052 RID: 4178
		Espcm,
		// Token: 0x04001053 RID: 4179
		Voxware,
		// Token: 0x04001054 RID: 4180
		CanopusAtrac,
		// Token: 0x04001055 RID: 4181
		G726Adpcm,
		// Token: 0x04001056 RID: 4182
		G722Adpcm,
		// Token: 0x04001057 RID: 4183
		Dsat,
		// Token: 0x04001058 RID: 4184
		DsatDisplay,
		// Token: 0x04001059 RID: 4185
		VoxwareByteAligned = 105,
		// Token: 0x0400105A RID: 4186
		VoxwareAc8 = 112,
		// Token: 0x0400105B RID: 4187
		VoxwareAc10,
		// Token: 0x0400105C RID: 4188
		VoxwareAc16,
		// Token: 0x0400105D RID: 4189
		VoxwareAc20,
		// Token: 0x0400105E RID: 4190
		VoxwareRt24,
		// Token: 0x0400105F RID: 4191
		VoxwareRt29,
		// Token: 0x04001060 RID: 4192
		VoxwareRt29hw,
		// Token: 0x04001061 RID: 4193
		VoxwareVr12,
		// Token: 0x04001062 RID: 4194
		VoxwareVr18,
		// Token: 0x04001063 RID: 4195
		VoxwareTq40,
		// Token: 0x04001064 RID: 4196
		VoxwareSc3,
		// Token: 0x04001065 RID: 4197
		VoxwareSc31,
		// Token: 0x04001066 RID: 4198
		Softsound = 128,
		// Token: 0x04001067 RID: 4199
		VoxwareTq60,
		// Token: 0x04001068 RID: 4200
		Msrt24,
		// Token: 0x04001069 RID: 4201
		G729A,
		// Token: 0x0400106A RID: 4202
		MviMvi2,
		// Token: 0x0400106B RID: 4203
		DfG726,
		// Token: 0x0400106C RID: 4204
		DfGsm610,
		// Token: 0x0400106D RID: 4205
		Isiaudio = 136,
		// Token: 0x0400106E RID: 4206
		Onlive,
		// Token: 0x0400106F RID: 4207
		MultitudeFtSx20,
		// Token: 0x04001070 RID: 4208
		InfocomItsG721Adpcm,
		// Token: 0x04001071 RID: 4209
		ConvediaG729,
		// Token: 0x04001072 RID: 4210
		Congruency,
		// Token: 0x04001073 RID: 4211
		Sbc24 = 145,
		// Token: 0x04001074 RID: 4212
		DolbyAc3Spdif,
		// Token: 0x04001075 RID: 4213
		MediasonicG723,
		// Token: 0x04001076 RID: 4214
		Prosody8kbps,
		// Token: 0x04001077 RID: 4215
		ZyxelAdpcm = 151,
		// Token: 0x04001078 RID: 4216
		PhilipsLpcbb,
		// Token: 0x04001079 RID: 4217
		Packed,
		// Token: 0x0400107A RID: 4218
		MaldenPhonytalk = 160,
		// Token: 0x0400107B RID: 4219
		RacalRecorderGsm,
		// Token: 0x0400107C RID: 4220
		RacalRecorderG720A,
		// Token: 0x0400107D RID: 4221
		RacalRecorderG7231,
		// Token: 0x0400107E RID: 4222
		RacalRecorderTetraAcelp,
		// Token: 0x0400107F RID: 4223
		NecAac = 176,
		// Token: 0x04001080 RID: 4224
		RawAac1 = 255,
		// Token: 0x04001081 RID: 4225
		RhetorexAdpcm,
		// Token: 0x04001082 RID: 4226
		Irat,
		// Token: 0x04001083 RID: 4227
		VivoG723 = 273,
		// Token: 0x04001084 RID: 4228
		VivoSiren,
		// Token: 0x04001085 RID: 4229
		PhilipsCelp = 288,
		// Token: 0x04001086 RID: 4230
		PhilipsGrundig,
		// Token: 0x04001087 RID: 4231
		DigitalG723 = 291,
		// Token: 0x04001088 RID: 4232
		SanyoLdAdpcm = 293,
		// Token: 0x04001089 RID: 4233
		SiprolabAceplnet = 304,
		// Token: 0x0400108A RID: 4234
		SiprolabAcelp4800,
		// Token: 0x0400108B RID: 4235
		SiprolabAcelp8v3,
		// Token: 0x0400108C RID: 4236
		SiprolabG729,
		// Token: 0x0400108D RID: 4237
		SiprolabG729A,
		// Token: 0x0400108E RID: 4238
		SiprolabKelvin,
		// Token: 0x0400108F RID: 4239
		VoiceageAmr,
		// Token: 0x04001090 RID: 4240
		G726ADPCM = 320,
		// Token: 0x04001091 RID: 4241
		DictaphoneCelp68,
		// Token: 0x04001092 RID: 4242
		DictaphoneCelp54,
		// Token: 0x04001093 RID: 4243
		QualcommPurevoice = 336,
		// Token: 0x04001094 RID: 4244
		QualcommHalfrate,
		// Token: 0x04001095 RID: 4245
		Tubgsm = 341,
		// Token: 0x04001096 RID: 4246
		Msaudio1 = 352,
		// Token: 0x04001097 RID: 4247
		Wmaudio2,
		// Token: 0x04001098 RID: 4248
		Wmaudio3,
		// Token: 0x04001099 RID: 4249
		WmaudioLossless,
		// Token: 0x0400109A RID: 4250
		Wmaspdif,
		// Token: 0x0400109B RID: 4251
		UnisysNapAdpcm = 368,
		// Token: 0x0400109C RID: 4252
		UnisysNapUlaw,
		// Token: 0x0400109D RID: 4253
		UnisysNapAlaw,
		// Token: 0x0400109E RID: 4254
		UnisysNap16k,
		// Token: 0x0400109F RID: 4255
		SycomAcmSyc008,
		// Token: 0x040010A0 RID: 4256
		SycomAcmSyc701G726L,
		// Token: 0x040010A1 RID: 4257
		SycomAcmSyc701Celp54,
		// Token: 0x040010A2 RID: 4258
		SycomAcmSyc701Celp68,
		// Token: 0x040010A3 RID: 4259
		KnowledgeAdventureAdpcm,
		// Token: 0x040010A4 RID: 4260
		FraunhoferIisMpeg2Aac = 384,
		// Token: 0x040010A5 RID: 4261
		DtsDs = 400,
		// Token: 0x040010A6 RID: 4262
		CreativeAdpcm = 512,
		// Token: 0x040010A7 RID: 4263
		CreativeFastspeech8 = 514,
		// Token: 0x040010A8 RID: 4264
		CreativeFastspeech10,
		// Token: 0x040010A9 RID: 4265
		UherAdpcm = 528,
		// Token: 0x040010AA RID: 4266
		UleadDvAudio = 533,
		// Token: 0x040010AB RID: 4267
		UleadDvAudio1,
		// Token: 0x040010AC RID: 4268
		Quarterdeck = 544,
		// Token: 0x040010AD RID: 4269
		IlinkVc = 560,
		// Token: 0x040010AE RID: 4270
		RawSport = 576,
		// Token: 0x040010AF RID: 4271
		EsstAc3,
		// Token: 0x040010B0 RID: 4272
		GenericPassthru = 585,
		// Token: 0x040010B1 RID: 4273
		IpiHsx = 592,
		// Token: 0x040010B2 RID: 4274
		IpiRpelp,
		// Token: 0x040010B3 RID: 4275
		Cs2 = 608,
		// Token: 0x040010B4 RID: 4276
		SonyScx = 624,
		// Token: 0x040010B5 RID: 4277
		SonyScy,
		// Token: 0x040010B6 RID: 4278
		SonyAtrac3,
		// Token: 0x040010B7 RID: 4279
		SonySpc,
		// Token: 0x040010B8 RID: 4280
		TelumAudio = 640,
		// Token: 0x040010B9 RID: 4281
		TelumIaAudio,
		// Token: 0x040010BA RID: 4282
		NorcomVoiceSystemsAdpcm = 645,
		// Token: 0x040010BB RID: 4283
		FmTownsSnd = 768,
		// Token: 0x040010BC RID: 4284
		Micronas = 848,
		// Token: 0x040010BD RID: 4285
		MicronasCelp833,
		// Token: 0x040010BE RID: 4286
		BtvDigital = 1024,
		// Token: 0x040010BF RID: 4287
		IntelMusicCoder,
		// Token: 0x040010C0 RID: 4288
		IndeoAudio,
		// Token: 0x040010C1 RID: 4289
		QdesignMusic = 1104,
		// Token: 0x040010C2 RID: 4290
		On2Vp7Audio = 1280,
		// Token: 0x040010C3 RID: 4291
		On2Vp6Audio,
		// Token: 0x040010C4 RID: 4292
		VmeVmpcm = 1664,
		// Token: 0x040010C5 RID: 4293
		Tpc,
		// Token: 0x040010C6 RID: 4294
		LightwaveLossless = 2222,
		// Token: 0x040010C7 RID: 4295
		Oligsm = 4096,
		// Token: 0x040010C8 RID: 4296
		Oliadpcm,
		// Token: 0x040010C9 RID: 4297
		Olicelp,
		// Token: 0x040010CA RID: 4298
		Olisbc,
		// Token: 0x040010CB RID: 4299
		Oliopr,
		// Token: 0x040010CC RID: 4300
		LhCodec = 4352,
		// Token: 0x040010CD RID: 4301
		LhCodecCelp,
		// Token: 0x040010CE RID: 4302
		LhCodecSbc8,
		// Token: 0x040010CF RID: 4303
		LhCodecSbc12,
		// Token: 0x040010D0 RID: 4304
		LhCodecSbc16,
		// Token: 0x040010D1 RID: 4305
		Norris = 5120,
		// Token: 0x040010D2 RID: 4306
		Isiaudio2,
		// Token: 0x040010D3 RID: 4307
		SoundspaceMusicompress = 5376,
		// Token: 0x040010D4 RID: 4308
		MpegAdtsAac = 5632,
		// Token: 0x040010D5 RID: 4309
		MpegRawAac,
		// Token: 0x040010D6 RID: 4310
		MpegLoas,
		// Token: 0x040010D7 RID: 4311
		NokiaMpegAdtsAac = 5640,
		// Token: 0x040010D8 RID: 4312
		NokiaMpegRawAac,
		// Token: 0x040010D9 RID: 4313
		VodafoneMpegAdtsAac,
		// Token: 0x040010DA RID: 4314
		VodafoneMpegRawAac,
		// Token: 0x040010DB RID: 4315
		MpegHeaac = 5648,
		// Token: 0x040010DC RID: 4316
		VoxwareRt24Speech = 6172,
		// Token: 0x040010DD RID: 4317
		SonicfoundryLossless = 6513,
		// Token: 0x040010DE RID: 4318
		InningsTelecomAdpcm = 6521,
		// Token: 0x040010DF RID: 4319
		LucentSx8300p = 7175,
		// Token: 0x040010E0 RID: 4320
		LucentSx5363s = 7180,
		// Token: 0x040010E1 RID: 4321
		Cuseeme = 7939,
		// Token: 0x040010E2 RID: 4322
		NtcsoftAlf2cmAcm = 8132,
		// Token: 0x040010E3 RID: 4323
		Dvm = 8192,
		// Token: 0x040010E4 RID: 4324
		Dts2,
		// Token: 0x040010E5 RID: 4325
		Makeavis = 13075,
		// Token: 0x040010E6 RID: 4326
		DivioMpeg4Aac = 16707,
		// Token: 0x040010E7 RID: 4327
		NokiaAdaptiveMultirate = 16897,
		// Token: 0x040010E8 RID: 4328
		DivioG726 = 16963,
		// Token: 0x040010E9 RID: 4329
		LeadSpeech = 17228,
		// Token: 0x040010EA RID: 4330
		LeadVorbis = 22092,
		// Token: 0x040010EB RID: 4331
		WavpackAudio = 22358,
		// Token: 0x040010EC RID: 4332
		Alac = 27745,
		// Token: 0x040010ED RID: 4333
		OggVorbisMode1 = 26447,
		// Token: 0x040010EE RID: 4334
		OggVorbisMode2,
		// Token: 0x040010EF RID: 4335
		OggVorbisMode3,
		// Token: 0x040010F0 RID: 4336
		OggVorbisMode1Plus = 26479,
		// Token: 0x040010F1 RID: 4337
		OggVorbisMode2Plus,
		// Token: 0x040010F2 RID: 4338
		OggVorbisMode3Plus,
		// Token: 0x040010F3 RID: 4339
		Tag3COMNbx = 28672,
		// Token: 0x040010F4 RID: 4340
		Opus = 28751,
		// Token: 0x040010F5 RID: 4341
		FaadAac = 28781,
		// Token: 0x040010F6 RID: 4342
		AmrNb = 29537,
		// Token: 0x040010F7 RID: 4343
		AmrWb,
		// Token: 0x040010F8 RID: 4344
		AmrWp,
		// Token: 0x040010F9 RID: 4345
		GsmAmrCbr = 31265,
		// Token: 0x040010FA RID: 4346
		GsmAmrVbrSid,
		// Token: 0x040010FB RID: 4347
		ComverseInfosysG7231 = -24320,
		// Token: 0x040010FC RID: 4348
		ComverseInfosysAvqsbc,
		// Token: 0x040010FD RID: 4349
		ComverseInfosysSbc,
		// Token: 0x040010FE RID: 4350
		SymbolG729A,
		// Token: 0x040010FF RID: 4351
		VoiceageAmrWb,
		// Token: 0x04001100 RID: 4352
		IngenientG726,
		// Token: 0x04001101 RID: 4353
		Mpeg4Aac,
		// Token: 0x04001102 RID: 4354
		EncoreG726,
		// Token: 0x04001103 RID: 4355
		ZollAsao,
		// Token: 0x04001104 RID: 4356
		SpeexVoice,
		// Token: 0x04001105 RID: 4357
		VianixMasc,
		// Token: 0x04001106 RID: 4358
		Wm9SpectrumAnalyzer,
		// Token: 0x04001107 RID: 4359
		WmfSpectrumAnayzer,
		// Token: 0x04001108 RID: 4360
		Gsm610,
		// Token: 0x04001109 RID: 4361
		Gsm620,
		// Token: 0x0400110A RID: 4362
		Gsm660,
		// Token: 0x0400110B RID: 4363
		Gsm690,
		// Token: 0x0400110C RID: 4364
		GsmAdaptiveMultirateWb,
		// Token: 0x0400110D RID: 4365
		PolycomG722,
		// Token: 0x0400110E RID: 4366
		PolycomG728,
		// Token: 0x0400110F RID: 4367
		PolycomG729A,
		// Token: 0x04001110 RID: 4368
		PolycomSiren,
		// Token: 0x04001111 RID: 4369
		GlobalIpIlbc,
		// Token: 0x04001112 RID: 4370
		RadiotimeTimeShiftRadio,
		// Token: 0x04001113 RID: 4371
		NiceAca,
		// Token: 0x04001114 RID: 4372
		NiceAdpcm,
		// Token: 0x04001115 RID: 4373
		VocordG721,
		// Token: 0x04001116 RID: 4374
		VocordG726,
		// Token: 0x04001117 RID: 4375
		VocordG7221,
		// Token: 0x04001118 RID: 4376
		VocordG728,
		// Token: 0x04001119 RID: 4377
		VocordG729,
		// Token: 0x0400111A RID: 4378
		VocordG729A,
		// Token: 0x0400111B RID: 4379
		VocordG7231,
		// Token: 0x0400111C RID: 4380
		VocordLbc,
		// Token: 0x0400111D RID: 4381
		NiceG728,
		// Token: 0x0400111E RID: 4382
		FraceTelecomG729,
		// Token: 0x0400111F RID: 4383
		Codian,
		// Token: 0x04001120 RID: 4384
		Flac = -3668,
		// Token: 0x04001121 RID: 4385
		Extensible = -2,
		// Token: 0x04001122 RID: 4386
		Development,
		// Token: 0x04001123 RID: 4387
		Pcm = 1
	}
}
