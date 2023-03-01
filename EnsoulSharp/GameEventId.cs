using System;

namespace EnsoulSharp
{
	// Token: 0x02000024 RID: 36
	public enum GameEventId
	{
		// Token: 0x04000091 RID: 145
		OnDelete,
		// Token: 0x04000092 RID: 146
		OnSpawn,
		// Token: 0x04000093 RID: 147
		OnDie,
		// Token: 0x04000094 RID: 148
		OnKill,
		// Token: 0x04000095 RID: 149
		OnChampionDie,
		// Token: 0x04000096 RID: 150
		OnChampionLevelUp,
		// Token: 0x04000097 RID: 151
		OnChampionKillPre,
		// Token: 0x04000098 RID: 152
		OnChampionKill,
		// Token: 0x04000099 RID: 153
		OnChampionKillPost,
		// Token: 0x0400009A RID: 154
		OnChampionSingleKill,
		// Token: 0x0400009B RID: 155
		OnChampionDoubleKill,
		// Token: 0x0400009C RID: 156
		OnChampionTripleKill,
		// Token: 0x0400009D RID: 157
		OnChampionQuadraKill,
		// Token: 0x0400009E RID: 158
		OnChampionPentaKill,
		// Token: 0x0400009F RID: 159
		OnChampionUnrealKill,
		// Token: 0x040000A0 RID: 160
		OnChampionPossession,
		// Token: 0x040000A1 RID: 161
		OnFirstBlood,
		// Token: 0x040000A2 RID: 162
		OnFirstBloodAssist,
		// Token: 0x040000A3 RID: 163
		OnDamageTaken,
		// Token: 0x040000A4 RID: 164
		OnDamageGiven,
		// Token: 0x040000A5 RID: 165
		OnSpellCast1,
		// Token: 0x040000A6 RID: 166
		OnSpellCast2,
		// Token: 0x040000A7 RID: 167
		OnSpellCast3,
		// Token: 0x040000A8 RID: 168
		OnSpellCast4,
		// Token: 0x040000A9 RID: 169
		OnSpellAvatarCast1,
		// Token: 0x040000AA RID: 170
		OnSpellAvatarCast2,
		// Token: 0x040000AB RID: 171
		OnItemSpellCast,
		// Token: 0x040000AC RID: 172
		OnGoldSpent,
		// Token: 0x040000AD RID: 173
		OnGoldEarned,
		// Token: 0x040000AE RID: 174
		OnExpEarned,
		// Token: 0x040000AF RID: 175
		OnItemConsumeablePurchased,
		// Token: 0x040000B0 RID: 176
		OnCriticalStrike,
		// Token: 0x040000B1 RID: 177
		OnAce,
		// Token: 0x040000B2 RID: 178
		OnReincarnate,
		// Token: 0x040000B3 RID: 179
		OnReviveChampion,
		// Token: 0x040000B4 RID: 180
		OnChangeChampion,
		// Token: 0x040000B5 RID: 181
		OnResetChampion,
		// Token: 0x040000B6 RID: 182
		OnDampenerKill,
		// Token: 0x040000B7 RID: 183
		OnDampenerTakedown,
		// Token: 0x040000B8 RID: 184
		OnDampenerDie,
		// Token: 0x040000B9 RID: 185
		OnDampenerRespawnSoon,
		// Token: 0x040000BA RID: 186
		OnDampenerRespawn,
		// Token: 0x040000BB RID: 187
		OnDampenerDamage,
		// Token: 0x040000BC RID: 188
		OnTurretKill,
		// Token: 0x040000BD RID: 189
		OnTurretTakedown,
		// Token: 0x040000BE RID: 190
		OnTurretDie,
		// Token: 0x040000BF RID: 191
		OnTurretDamage,
		// Token: 0x040000C0 RID: 192
		OnTurretFirstBlood,
		// Token: 0x040000C1 RID: 193
		OnStructureKilled,
		// Token: 0x040000C2 RID: 194
		OnMinionKill,
		// Token: 0x040000C3 RID: 195
		OnNeutralMinionKill,
		// Token: 0x040000C4 RID: 196
		OnNeutralMinionCampCleared,
		// Token: 0x040000C5 RID: 197
		OnAcquireRedBuffFromNeutral,
		// Token: 0x040000C6 RID: 198
		OnAcquireBlueBuffFromNeutral,
		// Token: 0x040000C7 RID: 199
		OnHQDie,
		// Token: 0x040000C8 RID: 200
		OnHQKill,
		// Token: 0x040000C9 RID: 201
		OnHQTakedown,
		// Token: 0x040000CA RID: 202
		OnHQDamage,
		// Token: 0x040000CB RID: 203
		OnCastHeal,
		// Token: 0x040000CC RID: 204
		OnBuff,
		// Token: 0x040000CD RID: 205
		OnCrowdControlDealt,
		// Token: 0x040000CE RID: 206
		OnCrowdControlExpired,
		// Token: 0x040000CF RID: 207
		OnKillingSpree,
		// Token: 0x040000D0 RID: 208
		OnKillingSpreeSet1,
		// Token: 0x040000D1 RID: 209
		OnKillingSpreeSet2,
		// Token: 0x040000D2 RID: 210
		OnKillingSpreeSet3,
		// Token: 0x040000D3 RID: 211
		OnKillingSpreeSet4,
		// Token: 0x040000D4 RID: 212
		OnKillingSpreeSet5,
		// Token: 0x040000D5 RID: 213
		OnKillingSpreeSet6,
		// Token: 0x040000D6 RID: 214
		OnKilledUnitOnKillingSpree,
		// Token: 0x040000D7 RID: 215
		OnKilledUnitOnKillingSpreeSet1,
		// Token: 0x040000D8 RID: 216
		OnKilledUnitOnKillingSpreeSet2,
		// Token: 0x040000D9 RID: 217
		OnKilledUnitOnKillingSpreeSet3,
		// Token: 0x040000DA RID: 218
		OnKilledUnitOnKillingSpreeSet4,
		// Token: 0x040000DB RID: 219
		OnKilledUnitOnKillingSpreeSet5,
		// Token: 0x040000DC RID: 220
		OnKilledUnitOnKillingSpreeSet6,
		// Token: 0x040000DD RID: 221
		OnKilledUnitOnKillingSpreeDoubleKill,
		// Token: 0x040000DE RID: 222
		OnKilledUnitOnKillingSpreeTripleKill,
		// Token: 0x040000DF RID: 223
		OnKilledUnitOnKillingSpreeQuadraKill,
		// Token: 0x040000E0 RID: 224
		OnKilledUnitOnKillingSpreePentaKill,
		// Token: 0x040000E1 RID: 225
		OnKilledUnitOnKillingSpreeUnrealKill,
		// Token: 0x040000E2 RID: 226
		OnDeathAssist,
		// Token: 0x040000E3 RID: 227
		OnRecall,
		// Token: 0x040000E4 RID: 228
		OnJunglePathTerminated,
		// Token: 0x040000E5 RID: 229
		OnQuit,
		// Token: 0x040000E6 RID: 230
		OnLeave,
		// Token: 0x040000E7 RID: 231
		OnReconnect,
		// Token: 0x040000E8 RID: 232
		OnGameEnter,
		// Token: 0x040000E9 RID: 233
		OnGameStart,
		// Token: 0x040000EA RID: 234
		OnAssistingSpreeSet1,
		// Token: 0x040000EB RID: 235
		OnAssistingSpreeSet2,
		// Token: 0x040000EC RID: 236
		OnTripleAssist,
		// Token: 0x040000ED RID: 237
		OnPentaAssist,
		// Token: 0x040000EE RID: 238
		OnPing,
		// Token: 0x040000EF RID: 239
		OnPingPlayer,
		// Token: 0x040000F0 RID: 240
		OnPingBuilding,
		// Token: 0x040000F1 RID: 241
		OnPingOther,
		// Token: 0x040000F2 RID: 242
		OnEndGame,
		// Token: 0x040000F3 RID: 243
		OnSpellLevelUp1,
		// Token: 0x040000F4 RID: 244
		OnSpellLevelUp2,
		// Token: 0x040000F5 RID: 245
		OnSpellLevelUp3,
		// Token: 0x040000F6 RID: 246
		OnSpellLevelUp4,
		// Token: 0x040000F7 RID: 247
		OnSpellEvolve1,
		// Token: 0x040000F8 RID: 248
		OnSpellEvolve2,
		// Token: 0x040000F9 RID: 249
		OnSpellEvolve3,
		// Token: 0x040000FA RID: 250
		OnSpellEvolve4,
		// Token: 0x040000FB RID: 251
		OnItemPurchased,
		// Token: 0x040000FC RID: 252
		OnItemSold,
		// Token: 0x040000FD RID: 253
		OnItemRemoved,
		// Token: 0x040000FE RID: 254
		OnItemUndo,
		// Token: 0x040000FF RID: 255
		OnItemCallout,
		// Token: 0x04000100 RID: 256
		OnItemClientChange,
		// Token: 0x04000101 RID: 257
		OnUndoEnabledChange,
		// Token: 0x04000102 RID: 258
		OnShopItemSubstitutionChange,
		// Token: 0x04000103 RID: 259
		OnShopMenuOpen,
		// Token: 0x04000104 RID: 260
		OnShopMenuClose,
		// Token: 0x04000105 RID: 261
		OnSurrenderVoteStart,
		// Token: 0x04000106 RID: 262
		OnSurrenderVote,
		// Token: 0x04000107 RID: 263
		OnSurrenderVoteAlready,
		// Token: 0x04000108 RID: 264
		OnSurrenderFailedVotes,
		// Token: 0x04000109 RID: 265
		OnSurrenderFailedTooEarly,
		// Token: 0x0400010A RID: 266
		OnSurrenderAgreed,
		// Token: 0x0400010B RID: 267
		OnSurrenderSpam,
		// Token: 0x0400010C RID: 268
		OnNormalAfkSurrenderAllowed,
		// Token: 0x0400010D RID: 269
		OnEarlySurrenderAllowed,
		// Token: 0x0400010E RID: 270
		OnEarlySurrenderAccomplice,
		// Token: 0x0400010F RID: 271
		OnEarlySurrenderOver,
		// Token: 0x04000110 RID: 272
		OnEarlySurrenderFailed,
		// Token: 0x04000111 RID: 273
		OnEarlySurrenderFailedNoLongerAvailable,
		// Token: 0x04000112 RID: 274
		OnEarlySurrenderFailedDisabled,
		// Token: 0x04000113 RID: 275
		OnEarlySurrenderFailedTooEarly,
		// Token: 0x04000114 RID: 276
		OnEarlySurrenderFailedNeverAvailable,
		// Token: 0x04000115 RID: 277
		OnEarlySurrenderVoteStart,
		// Token: 0x04000116 RID: 278
		OnUnanimousSurrenderVoteStart,
		// Token: 0x04000117 RID: 279
		OnUnanimousSurrenderFailedVotes,
		// Token: 0x04000118 RID: 280
		OnUnanimousAfkSurrenderAllowed,
		// Token: 0x04000119 RID: 281
		OnPause,
		// Token: 0x0400011A RID: 282
		OnPauseResume,
		// Token: 0x0400011B RID: 283
		OnMinionsSpawn,
		// Token: 0x0400011C RID: 284
		OnNeutralMinionsSpawn,
		// Token: 0x0400011D RID: 285
		OnStartGameMessage1,
		// Token: 0x0400011E RID: 286
		OnStartGameMessage2,
		// Token: 0x0400011F RID: 287
		OnStartGameMessage3,
		// Token: 0x04000120 RID: 288
		OnStartGameMessage4,
		// Token: 0x04000121 RID: 289
		OnStartGameMessage5,
		// Token: 0x04000122 RID: 290
		OnAlert,
		// Token: 0x04000123 RID: 291
		OnAudioEventFinished,
		// Token: 0x04000124 RID: 292
		OnNexusCrystalStart,
		// Token: 0x04000125 RID: 293
		OnGameModeAnnouncement1,
		// Token: 0x04000126 RID: 294
		OnGameModeAnnouncement2,
		// Token: 0x04000127 RID: 295
		OnGameModeAnnouncement3,
		// Token: 0x04000128 RID: 296
		OnGameModeAnnouncement4,
		// Token: 0x04000129 RID: 297
		OnGameModeAnnouncement5,
		// Token: 0x0400012A RID: 298
		OnGameModeAnnouncement6,
		// Token: 0x0400012B RID: 299
		OnGameModeAnnouncement7,
		// Token: 0x0400012C RID: 300
		OnGameModeAnnouncement8,
		// Token: 0x0400012D RID: 301
		OnGameModeAnnouncement9,
		// Token: 0x0400012E RID: 302
		OnGameModeAnnouncement10,
		// Token: 0x0400012F RID: 303
		OnGameModeAnnouncement11,
		// Token: 0x04000130 RID: 304
		OnGameModeAnnouncement12,
		// Token: 0x04000131 RID: 305
		OnGameModeAnnouncement13,
		// Token: 0x04000132 RID: 306
		OnGameModeAnnouncement14,
		// Token: 0x04000133 RID: 307
		OnGameModeAnnouncement15,
		// Token: 0x04000134 RID: 308
		OnGameModeAnnouncement16,
		// Token: 0x04000135 RID: 309
		OnReplaySeekStart,
		// Token: 0x04000136 RID: 310
		OnReplaySeekEnd,
		// Token: 0x04000137 RID: 311
		OnReplayOnKeyframeFinished,
		// Token: 0x04000138 RID: 312
		OnReplayDestroyAllObjects,
		// Token: 0x04000139 RID: 313
		OnKillDragon,
		// Token: 0x0400013A RID: 314
		OnKillDragonSpectator,
		// Token: 0x0400013B RID: 315
		OnKillDragonSteal,
		// Token: 0x0400013C RID: 316
		OnKillRiftherald,
		// Token: 0x0400013D RID: 317
		OnKillRiftheraldSpectator,
		// Token: 0x0400013E RID: 318
		OnKillRiftheraldSteal,
		// Token: 0x0400013F RID: 319
		OnSummonRiftherald,
		// Token: 0x04000140 RID: 320
		OnKillWorm,
		// Token: 0x04000141 RID: 321
		OnKillWormSpectator,
		// Token: 0x04000142 RID: 322
		OnKillWormSteal,
		// Token: 0x04000143 RID: 323
		OnKillSpiderboss,
		// Token: 0x04000144 RID: 324
		OnKillSpiderbossSpectator,
		// Token: 0x04000145 RID: 325
		OnPlaceWard,
		// Token: 0x04000146 RID: 326
		OnKillWard,
		// Token: 0x04000147 RID: 327
		OnCombatEvent,
		// Token: 0x04000148 RID: 328
		OnMinionAscended,
		// Token: 0x04000149 RID: 329
		OnChampionAscended,
		// Token: 0x0400014A RID: 330
		OnClearAscended,
		// Token: 0x0400014B RID: 331
		OnGameStat,
		// Token: 0x0400014C RID: 332
		OnRelativeTeamColorChange,
		// Token: 0x0400014D RID: 333
		OnMapSkinSwap,
		// Token: 0x0400014E RID: 334
		OnResetGame,
		// Token: 0x0400014F RID: 335
		OnResetGameCompleted,
		// Token: 0x04000150 RID: 336
		OnShutdown,
		// Token: 0x04000151 RID: 337
		OnMute,
		// Token: 0x04000152 RID: 338
		OnSystemMute,
		// Token: 0x04000153 RID: 339
		OnChampionTransformNone,
		// Token: 0x04000154 RID: 340
		OnChampionTransformAssassin,
		// Token: 0x04000155 RID: 341
		OnChampionTransformSlayer,
		// Token: 0x04000156 RID: 342
		OnReceiveShield,
		// Token: 0x04000157 RID: 343
		OnGrantShield,
		// Token: 0x04000158 RID: 344
		OnDamageShielded,
		// Token: 0x04000159 RID: 345
		OnMaterialOverride,
		// Token: 0x0400015A RID: 346
		OnObjectiveStolen,
		// Token: 0x0400015B RID: 347
		OnObjectiveTaken,
		// Token: 0x0400015C RID: 348
		OnEpicMonsterQueued,
		// Token: 0x0400015D RID: 349
		OnGearChanged,
		// Token: 0x0400015E RID: 350
		OnSummonerEmotePlayed,
		// Token: 0x0400015F RID: 351
		OnCustomStatStoneEvent,
		// Token: 0x04000160 RID: 352
		OnStatStoneMilestoneHit,
		// Token: 0x04000161 RID: 353
		OnEnterStealth,
		// Token: 0x04000162 RID: 354
		OnExitStealth,
		// Token: 0x04000163 RID: 355
		OnPetSpawned,
		// Token: 0x04000164 RID: 356
		OnLifeSteal,
		// Token: 0x04000165 RID: 357
		OnSpellVamp,
		// Token: 0x04000166 RID: 358
		OnLocalPlayerLoadoutBound,
		// Token: 0x04000167 RID: 359
		OnTurretPlateDestroyed,
		// Token: 0x04000168 RID: 360
		OnPlantActivated,
		// Token: 0x04000169 RID: 361
		OnPlayerEntersVisibility,
		// Token: 0x0400016A RID: 362
		OnDragonSoulGiven,
		// Token: 0x0400016B RID: 363
		OnConnect,
		// Token: 0x0400016C RID: 364
		OnDisconnect,
		// Token: 0x0400016D RID: 365
		OnObjectiveBountyClaimed,
		// Token: 0x0400016E RID: 366
		OnObjectiveBountySoon,
		// Token: 0x0400016F RID: 367
		OnObjectiveBountyEnded,
		// Token: 0x04000170 RID: 368
		OnObjectiveBountyPrestart,
		// Token: 0x04000171 RID: 369
		OnObjectiveBountyConcluded,
		// Token: 0x04000172 RID: 370
		OnPlayerCreated
	}
}
