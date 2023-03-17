using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Utility;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000032 RID: 50
	public static class Teleport
	{
		// Token: 0x0600026D RID: 621 RVA: 0x000100D0 File Offset: 0x0000E2D0
		static Teleport()
		{
			AttackableUnit.OnTeleport += Teleport.OnTeleportInvoke;
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x0600026E RID: 622 RVA: 0x00010154 File Offset: 0x0000E354
		// (remove) Token: 0x0600026F RID: 623 RVA: 0x00010188 File Offset: 0x0000E388
		public static event Teleport.OnTeleportEvent OnTeleport;

		// Token: 0x06000270 RID: 624 RVA: 0x000101BC File Offset: 0x0000E3BC
		private static void OnTeleportInvoke(AttackableUnit sender, AttackableUnitTeleportEventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			AIBaseClient aibaseClient = sender as AIBaseClient;
			if (aibaseClient == null || !aibaseClient.IsValid)
			{
				return;
			}
			Teleport.TeleportEventArgs teleportEventArgs = new Teleport.TeleportEventArgs
			{
				Source = aibaseClient,
				Status = Teleport.TeleportStatus.Unknown,
				Type = Teleport.TeleportType.Unknown
			};
			if (!Teleport.TeleportDataByNetworkId.ContainsKey(aibaseClient.NetworkId))
			{
				Teleport.TeleportDataByNetworkId[aibaseClient.NetworkId] = teleportEventArgs;
			}
			if (!string.IsNullOrEmpty(args.RecallType))
			{
				Teleport.ITeleport teleport;
				if (Teleport.TypeByString.TryGetValue(args.RecallType, out teleport))
				{
					Teleport.ITeleport teleport2 = teleport;
					teleportEventArgs.Status = Teleport.TeleportStatus.Start;
					teleportEventArgs.Duration = teleport2.GetDuration(args);
					teleportEventArgs.Type = teleport2.Type;
					teleportEventArgs.Start = Variables.GameTimeTickCount;
					teleportEventArgs.IsTarget = teleport2.IsTarget(args);
					teleportEventArgs.Source = aibaseClient;
					Teleport.TeleportDataByNetworkId[aibaseClient.NetworkId] = teleportEventArgs;
				}
				else
				{
					Logging.Write(false, true, "OnTeleportInvoke")(LogLevel.Warn, "Teleport type {0} with name {1} is not supported yet. Please report it!", new object[]
					{
						args.RecallType,
						args.RecallName
					});
				}
			}
			else
			{
				teleportEventArgs = Teleport.TeleportDataByNetworkId[aibaseClient.NetworkId];
				bool flag = Variables.GameTimeTickCount - teleportEventArgs.Start < teleportEventArgs.Duration - 100;
				teleportEventArgs.Status = (flag ? Teleport.TeleportStatus.Abort : Teleport.TeleportStatus.Finish);
			}
			Teleport.FireEvent(aibaseClient, teleportEventArgs);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0001031A File Offset: 0x0000E51A
		private static void FireEvent(AIBaseClient sender, Teleport.TeleportEventArgs args)
		{
			Teleport.OnTeleportEvent onTeleport = Teleport.OnTeleport;
			if (onTeleport == null)
			{
				return;
			}
			onTeleport(sender, args);
		}

		// Token: 0x0400011D RID: 285
		private const int ErrorBuffer = 100;

		// Token: 0x0400011E RID: 286
		private static readonly Dictionary<int, Teleport.TeleportEventArgs> TeleportDataByNetworkId = new Dictionary<int, Teleport.TeleportEventArgs>();

		// Token: 0x0400011F RID: 287
		private static readonly Dictionary<string, Teleport.ITeleport> TypeByString = new Dictionary<string, Teleport.ITeleport>
		{
			{
				"Recall",
				new Teleport.RecallTeleport()
			},
			{
				"Teleport",
				new Teleport.TeleportTeleport()
			},
			{
				"Gate",
				new Teleport.TwistedFateTeleport()
			},
			{
				"Shen",
				new Teleport.ShenTeleport()
			},
			{
				"Yuumi_Minimap_Border",
				new Teleport.YuumiWAlly()
			}
		};

		// Token: 0x02000479 RID: 1145
		// (Invoke) Token: 0x0600150B RID: 5387
		public delegate void OnTeleportEvent(AIBaseClient sender, Teleport.TeleportEventArgs args);

		// Token: 0x0200047A RID: 1146
		public enum TeleportStatus
		{
			// Token: 0x04000B86 RID: 2950
			Start,
			// Token: 0x04000B87 RID: 2951
			Abort,
			// Token: 0x04000B88 RID: 2952
			Finish,
			// Token: 0x04000B89 RID: 2953
			Unknown
		}

		// Token: 0x0200047B RID: 1147
		public enum TeleportType
		{
			// Token: 0x04000B8B RID: 2955
			Recall,
			// Token: 0x04000B8C RID: 2956
			Teleport,
			// Token: 0x04000B8D RID: 2957
			TwistedFate,
			// Token: 0x04000B8E RID: 2958
			Shen,
			// Token: 0x04000B8F RID: 2959
			YuumiWAlly,
			// Token: 0x04000B90 RID: 2960
			Unknown
		}

		// Token: 0x0200047C RID: 1148
		public class TeleportEventArgs : EventArgs
		{
			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x0600150E RID: 5390 RVA: 0x0004BD4F File Offset: 0x00049F4F
			// (set) Token: 0x0600150F RID: 5391 RVA: 0x0004BD57 File Offset: 0x00049F57
			public int Duration { get; internal set; }

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06001510 RID: 5392 RVA: 0x0004BD60 File Offset: 0x00049F60
			// (set) Token: 0x06001511 RID: 5393 RVA: 0x0004BD68 File Offset: 0x00049F68
			public bool IsTarget { get; internal set; }

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06001512 RID: 5394 RVA: 0x0004BD71 File Offset: 0x00049F71
			// (set) Token: 0x06001513 RID: 5395 RVA: 0x0004BD79 File Offset: 0x00049F79
			public AIBaseClient Source { get; internal set; }

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06001514 RID: 5396 RVA: 0x0004BD82 File Offset: 0x00049F82
			// (set) Token: 0x06001515 RID: 5397 RVA: 0x0004BD8A File Offset: 0x00049F8A
			public int Start { get; internal set; }

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06001516 RID: 5398 RVA: 0x0004BD93 File Offset: 0x00049F93
			// (set) Token: 0x06001517 RID: 5399 RVA: 0x0004BD9B File Offset: 0x00049F9B
			public Teleport.TeleportStatus Status { get; internal set; }

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x06001518 RID: 5400 RVA: 0x0004BDA4 File Offset: 0x00049FA4
			// (set) Token: 0x06001519 RID: 5401 RVA: 0x0004BDAC File Offset: 0x00049FAC
			public Teleport.TeleportType Type { get; internal set; }
		}

		// Token: 0x0200047D RID: 1149
		internal interface ITeleport
		{
			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x0600151B RID: 5403
			Teleport.TeleportType Type { get; }

			// Token: 0x0600151C RID: 5404
			int GetDuration(AttackableUnitTeleportEventArgs args);

			// Token: 0x0600151D RID: 5405
			bool IsTarget(AttackableUnitTeleportEventArgs args);
		}

		// Token: 0x0200047E RID: 1150
		internal class RecallTeleport : Teleport.ITeleport
		{
			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x0600151E RID: 5406 RVA: 0x0004BDBD File Offset: 0x00049FBD
			public Teleport.TeleportType Type
			{
				get
				{
					return Teleport.TeleportType.Recall;
				}
			}

			// Token: 0x0600151F RID: 5407 RVA: 0x0004BDC0 File Offset: 0x00049FC0
			public int GetDuration(AttackableUnitTeleportEventArgs args)
			{
				int result = 0;
				string a = args.RecallName.ToLower();
				if (a == "recall")
				{
					result = 8000;
				}
				else if (a == "recallimproved")
				{
					result = 7000;
				}
				else if (a == "odinrecall")
				{
					result = 4500;
				}
				else if (a == "odinrecallimproved")
				{
					result = 4000;
				}
				else if (a == "superrecall")
				{
					result = 4000;
				}
				else if (a == "superrecallimproved")
				{
					result = 4000;
				}
				else
				{
					Logging.Write(false, true, "GetDuration")(LogLevel.Warn, "Recall {0} is not supported yet. Please report it!", new object[]
					{
						args.RecallName
					});
				}
				return result;
			}

			// Token: 0x06001520 RID: 5408 RVA: 0x0004BE83 File Offset: 0x0004A083
			public bool IsTarget(AttackableUnitTeleportEventArgs args)
			{
				return false;
			}
		}

		// Token: 0x0200047F RID: 1151
		internal class TeleportTeleport : Teleport.ITeleport
		{
			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x06001522 RID: 5410 RVA: 0x0004BE8E File Offset: 0x0004A08E
			public Teleport.TeleportType Type
			{
				get
				{
					return Teleport.TeleportType.Teleport;
				}
			}

			// Token: 0x06001523 RID: 5411 RVA: 0x0004BE91 File Offset: 0x0004A091
			public int GetDuration(AttackableUnitTeleportEventArgs args)
			{
				return 4000;
			}

			// Token: 0x06001524 RID: 5412 RVA: 0x0004BE98 File Offset: 0x0004A098
			public bool IsTarget(AttackableUnitTeleportEventArgs args)
			{
				return args.RecallName.ToLower() != "summonerteleport";
			}
		}

		// Token: 0x02000480 RID: 1152
		internal class TwistedFateTeleport : Teleport.ITeleport
		{
			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x06001526 RID: 5414 RVA: 0x0004BEB7 File Offset: 0x0004A0B7
			public Teleport.TeleportType Type
			{
				get
				{
					return Teleport.TeleportType.TwistedFate;
				}
			}

			// Token: 0x06001527 RID: 5415 RVA: 0x0004BEBA File Offset: 0x0004A0BA
			public int GetDuration(AttackableUnitTeleportEventArgs args)
			{
				return 1500;
			}

			// Token: 0x06001528 RID: 5416 RVA: 0x0004BEC1 File Offset: 0x0004A0C1
			public bool IsTarget(AttackableUnitTeleportEventArgs args)
			{
				return args.RecallName.ToLower() != "gate";
			}
		}

		// Token: 0x02000481 RID: 1153
		internal class ShenTeleport : Teleport.ITeleport
		{
			// Token: 0x170001CA RID: 458
			// (get) Token: 0x0600152A RID: 5418 RVA: 0x0004BEE0 File Offset: 0x0004A0E0
			public Teleport.TeleportType Type
			{
				get
				{
					return Teleport.TeleportType.Shen;
				}
			}

			// Token: 0x0600152B RID: 5419 RVA: 0x0004BEE3 File Offset: 0x0004A0E3
			public int GetDuration(AttackableUnitTeleportEventArgs args)
			{
				return 3000;
			}

			// Token: 0x0600152C RID: 5420 RVA: 0x0004BEEA File Offset: 0x0004A0EA
			public bool IsTarget(AttackableUnitTeleportEventArgs args)
			{
				return args.RecallName.ToLower() != "shenrchannelmanager";
			}
		}

		// Token: 0x02000482 RID: 1154
		internal class YuumiWAlly : Teleport.ITeleport
		{
			// Token: 0x170001CB RID: 459
			// (get) Token: 0x0600152E RID: 5422 RVA: 0x0004BF09 File Offset: 0x0004A109
			public Teleport.TeleportType Type
			{
				get
				{
					return Teleport.TeleportType.YuumiWAlly;
				}
			}

			// Token: 0x0600152F RID: 5423 RVA: 0x0004BF0C File Offset: 0x0004A10C
			public int GetDuration(AttackableUnitTeleportEventArgs args)
			{
				return 3000;
			}

			// Token: 0x06001530 RID: 5424 RVA: 0x0004BF13 File Offset: 0x0004A113
			public bool IsTarget(AttackableUnitTeleportEventArgs args)
			{
				return args.RecallName.ToLower() != "yuumiwally";
			}
		}
	}
}
