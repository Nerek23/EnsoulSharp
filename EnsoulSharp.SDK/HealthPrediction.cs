using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Utility;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000019 RID: 25
	public class HealthPrediction
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00007B84 File Offset: 0x00005D84
		internal static void Initialize()
		{
			if (HealthPrediction._initialize)
			{
				return;
			}
			HealthPrediction._initialize = true;
			HealthPrediction.Implementations.Add("SDK", new HealthPredictionSDK());
			HealthPrediction.Implementation = HealthPrediction.Implementations["SDK"];
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007BBC File Offset: 0x00005DBC
		public static void AddPrediction(string name, IHealthPrediction pred)
		{
			if (HealthPrediction.Implementations.ContainsKey(name))
			{
				Logging.Write(false, true, "AddPrediction")(LogLevel.Error, "Cant not Add " + name + " HealthPrediction bcz already have it!", Array.Empty<object>());
				return;
			}
			Logging.Write(false, true, "AddPrediction")(LogLevel.Info, "Add " + name + " HealthPrediction", Array.Empty<object>());
			HealthPrediction.Implementations.Add(name, pred);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007C34 File Offset: 0x00005E34
		public static void SetPrediction(string name)
		{
			if (HealthPrediction.Implementations.ContainsKey(name))
			{
				Logging.Write(false, true, "SetPrediction")(LogLevel.Info, "Set " + name + " to Default HealthPrediction", Array.Empty<object>());
				HealthPrediction.Implementation = HealthPrediction.Implementations[name];
				return;
			}
			Logging.Write(false, true, "SetPrediction")(LogLevel.Error, "Cant not Set " + name + " to Default HealthPrediction", Array.Empty<object>());
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007CAD File Offset: 0x00005EAD
		public static IHealthPrediction GetPrediction(string name)
		{
			if (HealthPrediction.Implementations.ContainsKey(name))
			{
				return HealthPrediction.Implementations[name];
			}
			return null;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00007CC9 File Offset: 0x00005EC9
		public static IHealthPrediction GetSDKPrediction()
		{
			return HealthPrediction.Implementations["SDK"];
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007CDA File Offset: 0x00005EDA
		public static AIBaseClient GetAggroTurret(AIMinionClient minion)
		{
			if (HealthPrediction.Implementation == null)
			{
				return HealthPrediction.Implementations.Values.FirstOrDefault<IHealthPrediction>().GetAggroTurret(minion);
			}
			return HealthPrediction.Implementation.GetAggroTurret(minion);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007D04 File Offset: 0x00005F04
		public static float GetPrediction(AIBaseClient unit, int time, int delay = 70, HealthPredictionType type = HealthPredictionType.Default)
		{
			if (HealthPrediction.Implementation == null)
			{
				return HealthPrediction.Implementations.Values.FirstOrDefault<IHealthPrediction>().GetPrediction(unit, time, delay, type);
			}
			return HealthPrediction.Implementation.GetPrediction(unit, time, delay, type);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00007D34 File Offset: 0x00005F34
		public static bool HasMinionAggro(AIMinionClient minion)
		{
			if (HealthPrediction.Implementation == null)
			{
				return HealthPrediction.Implementations.Values.FirstOrDefault<IHealthPrediction>().HasMinionAggro(minion);
			}
			return HealthPrediction.Implementation.HasMinionAggro(minion);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00007D5E File Offset: 0x00005F5E
		public static bool HasTurretAggro(AIMinionClient minion)
		{
			if (HealthPrediction.Implementation == null)
			{
				return HealthPrediction.Implementations.Values.FirstOrDefault<IHealthPrediction>().HasTurretAggro(minion);
			}
			return HealthPrediction.Implementation.HasTurretAggro(minion);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007D88 File Offset: 0x00005F88
		public static int TurretAggroStartTick(AIMinionClient minion)
		{
			if (HealthPrediction.Implementation == null)
			{
				return HealthPrediction.Implementations.Values.FirstOrDefault<IHealthPrediction>().TurretAggroStartTick(minion);
			}
			return HealthPrediction.Implementation.TurretAggroStartTick(minion);
		}

		// Token: 0x04000095 RID: 149
		private static bool _initialize;

		// Token: 0x04000096 RID: 150
		private static IHealthPrediction Implementation;

		// Token: 0x04000097 RID: 151
		private static readonly Dictionary<string, IHealthPrediction> Implementations = new Dictionary<string, IHealthPrediction>();
	}
}
