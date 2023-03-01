using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200002D RID: 45
	public static class Dash
	{
		// Token: 0x06000240 RID: 576 RVA: 0x0000CC7E File Offset: 0x0000AE7E
		static Dash()
		{
			AIBaseClient.OnNewPath += Dash.EventDash;
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000241 RID: 577 RVA: 0x0000CC9C File Offset: 0x0000AE9C
		// (remove) Token: 0x06000242 RID: 578 RVA: 0x0000CCD0 File Offset: 0x0000AED0
		public static event Dash.OnDashEvent OnDash;

		// Token: 0x06000243 RID: 579 RVA: 0x0000CD04 File Offset: 0x0000AF04
		public static Dash.DashArgs GetDashInfo(this AIBaseClient unit)
		{
			Dash.DashArgs result;
			if (!Dash.DetectedDashes.TryGetValue(unit.NetworkId, out result))
			{
				return new Dash.DashArgs();
			}
			return result;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000CD2C File Offset: 0x0000AF2C
		public static bool IsDashing(this AIBaseClient unit)
		{
			Dash.DashArgs dashArgs;
			return Dash.DetectedDashes.TryGetValue(unit.NetworkId, out dashArgs) && unit.Path.Length != 0 && dashArgs.EndTick != 0;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000CD64 File Offset: 0x0000AF64
		private static void EventDash(AIBaseClient sender, AIBaseClientNewPathEventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			AIHeroClient aiheroClient = sender as AIHeroClient;
			if (aiheroClient != null && aiheroClient.IsValid)
			{
				if (!Dash.DetectedDashes.ContainsKey(aiheroClient.NetworkId))
				{
					Dash.DetectedDashes.Add(aiheroClient.NetworkId, new Dash.DashArgs());
				}
				if (args.IsDash)
				{
					List<Vector2> list = new List<Vector2>
					{
						aiheroClient.ServerPosition.ToVector2()
					};
					list.AddRange(args.Path.ToList<Vector3>().ToVector2());
					Dash.DetectedDashes[aiheroClient.NetworkId].Path = list;
					Dash.DetectedDashes[aiheroClient.NetworkId].Speed = args.Speed;
					Dash.DetectedDashes[aiheroClient.NetworkId].StartPos = aiheroClient.ServerPosition.ToVector2();
					Dash.DetectedDashes[aiheroClient.NetworkId].StartTick = Variables.GameTimeTickCount - Game.Ping / 2;
					Dash.DetectedDashes[aiheroClient.NetworkId].EndPos = list.LastOrDefault<Vector2>();
					Dash.DetectedDashes[aiheroClient.NetworkId].EndTick = Dash.DetectedDashes[aiheroClient.NetworkId].StartTick + (int)(1000f * (Dash.DetectedDashes[aiheroClient.NetworkId].EndPos.Distance(Dash.DetectedDashes[aiheroClient.NetworkId].StartPos) / Dash.DetectedDashes[aiheroClient.NetworkId].Speed));
					Dash.DetectedDashes[aiheroClient.NetworkId].Duration = Dash.DetectedDashes[aiheroClient.NetworkId].EndTick - Dash.DetectedDashes[aiheroClient.NetworkId].StartTick;
					Dash.OnDashEvent onDash = Dash.OnDash;
					if (onDash == null)
					{
						return;
					}
					onDash(sender, Dash.DetectedDashes[aiheroClient.NetworkId]);
					return;
				}
				else
				{
					Dash.DetectedDashes[aiheroClient.NetworkId].EndTick = 0;
				}
			}
		}

		// Token: 0x04000108 RID: 264
		private static readonly Dictionary<int, Dash.DashArgs> DetectedDashes = new Dictionary<int, Dash.DashArgs>();

		// Token: 0x0200045D RID: 1117
		// (Invoke) Token: 0x060014A9 RID: 5289
		public delegate void OnDashEvent(AIBaseClient sender, Dash.DashArgs args);

		// Token: 0x0200045E RID: 1118
		public class DashArgs : EventArgs
		{
			// Token: 0x170001AE RID: 430
			// (get) Token: 0x060014AC RID: 5292 RVA: 0x0004B8E8 File Offset: 0x00049AE8
			// (set) Token: 0x060014AD RID: 5293 RVA: 0x0004B8F0 File Offset: 0x00049AF0
			public int Duration { get; set; }

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x060014AE RID: 5294 RVA: 0x0004B8F9 File Offset: 0x00049AF9
			// (set) Token: 0x060014AF RID: 5295 RVA: 0x0004B901 File Offset: 0x00049B01
			public Vector2 EndPos { get; set; }

			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x060014B0 RID: 5296 RVA: 0x0004B90A File Offset: 0x00049B0A
			// (set) Token: 0x060014B1 RID: 5297 RVA: 0x0004B912 File Offset: 0x00049B12
			public int EndTick { get; set; }

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x060014B2 RID: 5298 RVA: 0x0004B91B File Offset: 0x00049B1B
			// (set) Token: 0x060014B3 RID: 5299 RVA: 0x0004B923 File Offset: 0x00049B23
			public List<Vector2> Path { get; set; }

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x060014B4 RID: 5300 RVA: 0x0004B92C File Offset: 0x00049B2C
			// (set) Token: 0x060014B5 RID: 5301 RVA: 0x0004B934 File Offset: 0x00049B34
			public float Speed { get; set; }

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0004B93D File Offset: 0x00049B3D
			// (set) Token: 0x060014B7 RID: 5303 RVA: 0x0004B945 File Offset: 0x00049B45
			public Vector2 StartPos { get; set; }

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x060014B8 RID: 5304 RVA: 0x0004B94E File Offset: 0x00049B4E
			// (set) Token: 0x060014B9 RID: 5305 RVA: 0x0004B956 File Offset: 0x00049B56
			public int StartTick { get; set; }
		}
	}
}
